using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;

namespace PerceptronLibrary
{
    [Serializable]
    public class Perceptron
    {
        public delegate void PerceptronStateHandler(string message);
        public event PerceptronStateHandler Handler;
        public event PerceptronStateHandler TrainInfo;

        private Neuron[] neurons;
        public readonly double[] outputs;

        public int Size { get; private set; }
        public bool isTrained = false;
        public List<DataPlot> ErrorPlot { get; private set; } //This is the plot data from network training

        public Perceptron(int inputCount, int neuronCount, double Saturation)
        {
            Size = neuronCount;
            neurons = new Neuron[neuronCount];
            outputs = new double[neuronCount];
            for (int i = 0; i < Size; i++)
            {
                neurons[i] = new Neuron(inputCount, Saturation);
            }
        }

        public double[] CalculateOutput(double[] input)
        {
            for (int i = 0; i < neurons.Length; i++)
            {
                outputs[i] = neurons[i].CalculateOutput(input);
            }
            return outputs;
        }

        public void Train(double[,] inputs, double[,] outputs, int maxEpoch)
        {
            ErrorPlot = new List<DataPlot>();
            int currentEpoch = 0;
            double totalError = 0;
            while (currentEpoch < maxEpoch)
            {
                currentEpoch++;
                totalError = 0;
                for (int i = 0; i < neurons.Length; i++)
                {
                    double[] output = SplitToOutput(outputs, i);
                    neurons[i].LearningRateCorrection(currentEpoch, maxEpoch);
                    TrainInfo?.Invoke($"Learning Rate change to - {neurons[i].learningRate}");
                    totalError += neurons[i].Train(inputs, output);
                }
                TrainInfo?.Invoke($"Epoch - {currentEpoch}, Total error - {totalError}");
                ErrorPlot.Add(new DataPlot(currentEpoch, totalError));
            }
            isTrained = true;
            Handler?.Invoke($"Training complete");
            Handler?.Invoke($"Passed epochs - {currentEpoch}, Total error is {totalError}");
        }

        public void Train(double[,] inputs, double[,] outputs, double errorThreshold)
        {
            ErrorPlot = new List<DataPlot>();
            int currentEpoch = 0;
            double totalError = 1;
            while (totalError > errorThreshold)
            {
                currentEpoch++;
                totalError = 0;
                for (int i = 0; i < neurons.Length; i++)
                {
                    double[] output = SplitToOutput(outputs, i);
                    totalError += neurons[i].Train(inputs, output);
                }
                TrainInfo?.Invoke($"Epoch - {currentEpoch}, Total error - {totalError}");
                ErrorPlot.Add(new DataPlot(currentEpoch, totalError));
            }
            isTrained = true;
            Handler?.Invoke($"Training complete");
            Handler?.Invoke($"Passed epochs - {currentEpoch}, Total error - {totalError}");
        }

        private double[] SplitToOutput(double[,] outputs, int number)
        {
            double[] output = new double[outputs.GetLength(0)];
            for (int i = 0; i < outputs.GetLength(0); i++)
            {
                output[i] = outputs[i, number];
            }
            return output;
        }

        public void ExportToDat(string filepath)
        {
            Regex regex = new Regex(@"\w*.dat$");
            MatchCollection matches = regex.Matches(filepath);
            if (matches.Count == 0)
                filepath += ".dat";

            BinaryFormatter serializer = new BinaryFormatter();
            using (FileStream fs = new FileStream(filepath, FileMode.OpenOrCreate))
            {
                serializer.Serialize(fs, neurons);
            }
            Handler?.Invoke($"Network saved successfully");
        }

        public void ImportFromDat(string filepath)
        {
            Regex regex = new Regex(@"\w*.dat$");
            MatchCollection matches = regex.Matches(filepath);
            if (matches.Count == 0)
                filepath += ".dat";

            BinaryFormatter serializer = new BinaryFormatter();
            using (FileStream fs = File.OpenRead(filepath))
            {
                neurons = (Neuron[])serializer.Deserialize(fs);
            }
            Handler?.Invoke($"Network loaded successfully");
        }
    }
}


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
        private double[] outputs;

        public int Size { get; private set; }
        public bool isTrained = false;

        public Perceptron(int inputCount, int neuronCount)
        {
            Size = neuronCount;
            neurons = new Neuron[neuronCount];
            outputs = new double[neuronCount];
            for (int i = 0; i < Size; i++)
            {
                neurons[i] = new Neuron(inputCount);
            }
        }

        public double[] calculateOutput(double[] input)
        {
            for (int i = 0; i < neurons.Length; i++)
            {
                outputs[i] = neurons[i].CalculateOutput(input);
            }
            return outputs;
        }

        public void Train(double[,] inputs, double[,] outputs, int epochMax)
        {
            int epoch = 0;
            double totalError = 0;
            while (epoch < epochMax)
            {
                epoch++;
                totalError = 0;
                for (int i = 0; i < neurons.Length; i++)
                {
                    double[] output = toOutput(outputs, i);
                    totalError += neurons[i].Train(inputs, output);
                }
                TrainInfo?.Invoke($"Epoch - {epoch}, Total error - {totalError}");
            }
            isTrained = true;
            Handler?.Invoke($"Training complete");
            Handler?.Invoke($"Passed epochs - {epoch}, Total error is {totalError}");
        }

        public void Train(double[,] inputs, double[,] outputs, double errorThreshold)
        {
            int epoch = 0;
            double totalError = 1;
            while (totalError > errorThreshold)
            {
                epoch++;
                totalError = 0;
                for (int i = 0; i < neurons.Length; i++)
                {
                    double[] output = toOutput(outputs, i);
                    totalError += neurons[i].Train(inputs, output);
                }
                TrainInfo?.Invoke($"Epoch - {epoch}, Total error - {totalError}");
            }
            isTrained = true;
            Handler?.Invoke($"Training complete");
            Handler?.Invoke($"Passed epochs - {epoch}, Total error - {totalError}");
        }

        private double[] toOutput(double[,] outputs, int number)
        {
            double[] output = new double[outputs.GetLength(0)];
            for (int i = 0; i < outputs.GetLength(0); i++)
            {
                output[i] = outputs[i, number];
            }
            return output;
        } //to Extension

        public void SaveAsDat(string filepath)
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

        public void LoadFromDat(string filepath)
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


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerceptronLibrary
{
    public class Perceptron
    {
        Neuron[] neurons;
        double[] outputs;

        public int Size { get; private set; }

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
            while (epoch < epochMax)
            {
                for (int i = 0; i < neurons.Length; i++)
                {
                    double[] output = toOutput(outputs, i);
                    neurons[i].Train(inputs, output);
                }
                epoch++;
            }
        }

        public void Train(double[,] inputs, double[,] outputs, double errorThreshold)
        {
            int epoch = 0;
            double totalError = 1;
            while (totalError > errorThreshold)
            {
                //Console.WriteLine($"Total Error: {totalError}");
                epoch++;
                totalError = 0;
                for (int i = 0; i < neurons.Length; i++)
                {
                    double[] output = toOutput(outputs, i);
                    totalError += neurons[i].Train(inputs, output, errorThreshold);
                }
            }
            //Console.WriteLine(epoch);
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
    }
}


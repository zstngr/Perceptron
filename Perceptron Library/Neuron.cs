using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;

namespace PerceptronLibrary
{
    [Serializable]
    class Neuron
    {
        internal double output;
        private double[] weights;
        private double biasWeight;
        Random rnd = new Random();
        public double learningRate = 0.1;

        internal Neuron(int inputCount)
        {
            weights = new double[inputCount];
            for (int i = 0; i < weights.Length; i++)
            {
                weights[i] = rnd.NextDouble();
            }
            biasWeight = rnd.NextDouble();
        }

        internal double CalculateOutput(double[] input)
        {
            double state = 0;
            for (int i = 0; i < input.Length; i++)
            {
                state += input[i] * weights[i];
            }
            state += biasWeight;
            return SigmoidLogistic(state, 1.0);
        }

        internal double Train(double[,] inputs, double[] outputs) // In[NumberOfSample, NumberOfInput] Out[NumberOfSample]
        {
            double totalError = 0;
            for (int numberOfSample = 0; numberOfSample < inputs.GetLength(0); numberOfSample++)
            {
                output = CalculateOutput(toInput(inputs, numberOfSample));
                double error = outputs[numberOfSample] - output;
                for (int numberOfInput = 0; numberOfInput < inputs.GetLength(1); numberOfInput++)
                {
                    weights[numberOfInput] += learningRate * error * inputs[numberOfSample, numberOfInput];
                }
                biasWeight += learningRate * error * 1;
                totalError += Math.Abs(error);
            }
            return totalError;
        }

        private double[] toInput(double[,] inputs, int numberOfSample)
        {
            double[] input = new double[inputs.GetLength(1)];
            for (int i = 0; i < inputs.GetLength(1); i++)
            {
                input[i] = inputs[numberOfSample, i];
            }
            return input;
        } //to Extension

        private double SigmoidLogistic(double State, double Alpha)
        {
            return 1 / (Math.Pow(Math.E, (-Alpha * State)) + 1);
        }
    }
}

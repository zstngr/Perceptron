using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerceptronLibrary
{
    class Neuron
    {
        double output;
        double[] weights;
        double biasWeight;
        Random rnd = new Random();
        double learningRate = 0.2;

        public Neuron(int inputCount)
        {
            weights = new double[inputCount];
            for (int i = 0; i < weights.Length; i++)
            {
                weights[i] = rnd.NextDouble();
            }
            biasWeight = rnd.NextDouble();
        }

        public double CalculateOutput(double[] input)
        {
            double state = 0;
            for (int i = 0; i < input.Length; i++)
            {
                state += input[i] * weights[i];
            }
            state += biasWeight;
            return SigmoidLogistic(state, 20.0);
        }

        public void Train(double[,] inputs, double[] outputs) // In[NumberOfSample, NumberOfInput] Out[NumberOfSample]
        {
            for (int numberOfSample = 0; numberOfSample < inputs.GetLength(0); numberOfSample++)
            {
                output = CalculateOutput(toInput(inputs, numberOfSample));
                double error = outputs[numberOfSample] - output;
                for (int numberOfInput = 0; numberOfInput < inputs.GetLength(1); numberOfInput++)
                {
                    weights[numberOfInput] += learningRate * error * inputs[numberOfSample, numberOfInput];
                }
                biasWeight += learningRate * error * 1;
            }
        }

        public double Train(double[,] inputs, double[] outputs, double errorThreshold) // In[NumberOfSample, NumberOfInput] Out[NumberOfSample]
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

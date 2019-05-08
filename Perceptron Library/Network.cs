using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerceptronLibrary
{
    public class Network
    {
        double[] input;
        double[] output;
        Neuron[] neurons;

        public Network(double[] Input, int Size)
        {
            input = Input;
            output = new double[Size];
            neurons = new Neuron[Size];
            for(int i = 0; i < neurons.Length; i++)
            {
                neurons[i] = new Neuron(Input);
                output[i] = neurons[i].output;
            }
        }

        public void Train(double[,] inputTestSample, double[,] outputTestSample, int eraCount) // inputTestSample[numberOfSample, numberOfNeuron]
        {
            int era = 0;
            double velocity = 1;
            double[] currentInput;
            while (era < eraCount)
            {
                Console.WriteLine($"Эра номер {era}");
                double[] delta = new double[neurons.Length];
                for(int k = 0; k < outputTestSample.GetLength(0); k++)
                {
                    currentInput = getCurrentInput(inputTestSample, k);
                    for (int i = 0; i < delta.Length; i++)
                    {
                        neurons[i].enableNeuron(currentInput);
                        output[i] = neurons[i].output;
                        delta[i] = outputTestSample[k, i] - output[i];
                        neurons[i].changeWeights(delta[i], velocity);
                        Console.WriteLine($"Предпологаемое значение = {outputTestSample[k, i]}");
                        Console.WriteLine($"Созданное значение = {output[i]}");
                        Console.WriteLine(new string('-', 50));
                    }
                }
                velocity -= 1 / eraCount;
                era++;
            }
            

        } 
        double[] getCurrentInput(double[,] inputTestSample, int numberOfSample)
        {
            double[] currentInput = new double[inputTestSample.GetLength(1)];
            for(int i = 0; i < currentInput.Length; i++)
            {
                currentInput[i] = inputTestSample[numberOfSample, i];
            }
            return currentInput;
        }
    }
}

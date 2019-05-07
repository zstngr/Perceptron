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
            }
        }

        public void Train(double[] output, double[] outputTestSample)
        {
            double[] delta = new double[neurons.Length];
            
            for(int i = 0; i < delta.Length; i++)
            {
                delta[i] = outputTestSample[i] - output[i];
                neurons[i].GetHashCode();
            }

        }
    }
}

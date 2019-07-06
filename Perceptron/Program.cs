using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerceptronLibrary;
using System.IO;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            double[,] inputSet;
            double[,] outputSet;

            string path = @"C:\Users\zstng\OneDrive\Рабочий стол\dataset.txt";
            DataSetTools.SplitSet(path, out inputSet, out outputSet, 2, 2, 4);
            Perceptron network = new Perceptron(2, 2); // (InputCount, OutputCount/NeuronCount, Saturation param)
            network.Handler += PrintMessage;
            network.Train(inputSet, outputSet, 0.005);

            double[] input = { 0, 1 };
            Console.WriteLine(network.CalculateOutput(input)[0]);
            Console.WriteLine(network.CalculateOutput(input)[1]);
        }

        static void PrintMessage(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
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
            double[] input = { 0, 0.7 };
            double[,] inSet = { { 1, 0 }, { 0, 1 }, { 1, 1 }, { 0, 0 } };
            double[,] outSet = { { 0, 1 }, { 0, 1 }, { 1, 1 }, { 0, 0 } }; // OR AND Logic 

            double[,] inputSet = { { 0, 0.7 }, { 0.5, 1 }, { 0.7, 1 }, { 0.2, 0.6 }, { 1, 0.5 }, { 0.6, 0 }, { 0.2, 0.4 }, { 0.7, 1 }, { 0.9, 0.8 }, { 0.5, 0.3 } };
            double[,] outputSet = { { 0, 0.537 }, { 0.265, 0.951 }, { 0.971, 0.122 }, { 0.235, 0.488 }, { 1, 0.585 }, { 0.941, 0 }, { 0.353, 0.293 }, { 0.441, 1 }, { 0.735, 0.854 }, { 0.676, 0.268 } }; //set from the book works too

            Perceptron network = new Perceptron(2, 2);
            network.Handler += PrintMessage;
            network.Train(inSet, outSet, 0.005);
            network.SaveAsDat(@"C:\Users\zstng\OneDrive\Рабочий стол\network");
            Perceptron nn = new Perceptron(2, 2);
            nn.LoadFromDat(@"C:\Users\zstng\OneDrive\Рабочий стол\network");
            Console.WriteLine(nn.calculateOutput(input)[0]);
            Console.WriteLine(nn.calculateOutput(input)[1]);
        }

        static void PrintMessage(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
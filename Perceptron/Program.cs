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
            double[] input = { 0, 1 };
            double[,] inSet = { { 1, 0 }, { 0, 1 }, { 1, 1 }, { 0, 0 } };
            double[,] outSet = { { 0, 1 }, { 0, 1 }, { 1, 1 }, { 0, 0 } }; // OR AND Logic

            Perceptron network = new Perceptron(2, 2);
            network.Train(inSet, outSet, 0.005); 
            Console.WriteLine(network.calculateOutput(input)[0]);
        }
    }
}
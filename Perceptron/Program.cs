using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerceptronLibrary;

namespace Perceptron
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] input = { 0.2, 0.5 };
            Network nn = new Network(input, 1);
            double[,] inputTest = new double[15, 2]{ { 0.2, 0.7 }, { 0.5, 0.4 }, { 0.1, 0.9 }, { 0.5, 0.6 }, { 0.2, 0.8 }, { 0.2, 0.7 }, { 0.5, 0.4 }, { 0.1, 0.9 }, { 0.5, 0.6 }, { 0.2, 0.8 }, { 0.2, 0.7 }, { 0.5, 0.4 }, { 0.1, 0.9 }, { 0.5, 0.6 }, { 0.2, 0.8 } };
            double[,] outputTest = new double[15, 1];
            
            for(int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    outputTest[i, 0] += inputTest[i, j];
                }
                outputTest[i, 0] = outputTest[i, 0] / 2;
            }

            nn.Train(inputTest, outputTest, 50);
        }
    }
}

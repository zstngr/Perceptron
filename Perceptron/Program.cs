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
            Network nn = new Network(input, 3);
        }
    }
}

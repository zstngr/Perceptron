using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerceptronLibrary
{
    class Neuron
    {
        double[] inputs;
        double[] weights;
        double correctionWeight;
        double state;
        internal double output;

        public Neuron(double[] Inputs)
        {
            inputs = Inputs;
            weights = new double[inputs.Length];
            randomizeWeights();
            setState();
            setOutput("SigmoidLogistic", 2, 2);
            Console.WriteLine(output);
        }

        void randomizeWeights()
        {
            Random rand = new Random();
            for (int i = 0; i < weights.Length; i++)
            {
                weights[i] = Convert.ToDouble(rand.Next(-5, 5)) / 100;
                if (i == 0) correctionWeight = Convert.ToDouble(rand.Next(-5, 5)) / 100;
            }
        }
        void Train(double delta, double velocity)
        {
            for(int i = 0; i < )
        }
        void setState() // Глобальные переменные
        {
            for (int i = 0; i < inputs.Length; i++)
            {
                state += inputs[i] * weights[i];
            }
        }
        void setOutput(string ActivationFunctionType, double Alpha, double Threshold)
        {
            switch (ActivationFunctionType)
            {
                case "SigmoidLogistic":
                    output = ActivationFunctions.SigmoidLogistic(state, Alpha);
                    break;
                case "HyperbolicTangent":
                    output = ActivationFunctions.HyperbolicTangent(state, Alpha);
                    break;
                case "HeavysideUp":
                    break;
                case "HeavysideDown":
                    break;
            }
        }
    }
}

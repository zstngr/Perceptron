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
            weights = new double[Inputs.Length];
            randomizeWeights();
            enableNeuron(Inputs);
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
        public void changeWeights(double delta, double velocity)
        {
            for(int i = 0; i < weights.Length; i++)
            {
                Console.WriteLine($"Старый вес: {weights[i]}");
                weights[i] = weights[i] + velocity * delta * inputs[i];
                Console.WriteLine($"Новый вес: {weights[i]}");
            }
            Console.WriteLine(new string('-', 50));
            correctionWeight = correctionWeight + velocity * delta;
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
        internal void enableNeuron(double[] Inputs)
        {
            inputs = Inputs;
            setState();
            setOutput("SigmoidLogistic", 2, 2);
            Console.WriteLine(output);
        }
    }
}

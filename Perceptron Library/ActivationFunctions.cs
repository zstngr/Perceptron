using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerceptronLibrary
{
    class ActivationFunctions
    {
        //step function
        internal static double HeavysideDown(double State, double Threshold)
        {
            if (State <= Threshold) return 1;
            else if (State >= Threshold) return 0;
            else return 0;
        }
        internal static double HeavysideUp(double State, double Threshold)
        {
            if (State <= Threshold) return 0;
            else if (State >= Threshold) return 1;
            else return 1;
        }
        internal static double SigmoidLogistic(double State, double Alpha)
        {
            return 1 / (Math.Pow(Math.E, -(Alpha * State)) + 1);
        }
        internal static double HyperbolicTangent(double State, double Alpha)
        {
            return (Math.Pow(Math.E, Alpha * State) - 1) / (Math.Pow(Math.E, (Alpha * State)) + 1);
        }
    }
}

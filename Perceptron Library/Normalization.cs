using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerceptronLibrary
{
    public static class Normalization
    {
        public static double[,] Normalize(this int[,] Array, int Min, int Max)
        {
            double[,] normalizedArray = new double[Array.GetLength(0), Array.GetLength(1)];
            for(int i = 0; i < Array.GetLength(0); i++)
            {
                for (int j = 0; j < Array.GetLength(1); j++)
                {
                    normalizedArray[i, j] = Array[i, j].Normalize(Min, Max);
                }
            }
            return normalizedArray;
        }

        private static double Normalize(this int value, int Min, int Max)
        {
            return (double)(value - Min) / (Max - Min);
        }
    }
}

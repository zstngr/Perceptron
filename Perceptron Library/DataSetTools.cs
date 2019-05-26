using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerceptronLibrary
{
    public static class DataSetTools
    {
        public static int[] toIntArray(this string[] Array)
        {
            int[] intArray = new int[Array.Length];
            for (int i = 0; i < Array.Length; i++)
            {
                intArray[i] = int.Parse(Array[i]);
            }
            return intArray;
        }

        public static int[,] toDataSet(this string[] Array, int sampleSize, int IOSize)
        {
            int[,] dataSet = new int[sampleSize, IOSize];
            int k = 0;
            for(int i = 0; i < sampleSize; i++)
            {
                for(int j = 0; j < IOSize; j++)
                {
                    dataSet[i, j] = int.Parse(Array[k++]);
                }
            }
            return dataSet;
        }
    }
}

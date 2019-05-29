using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PerceptronLibrary
{
    public static class DataSetTools
    {
        public static void SplitSet(string PathToSet, out double[,] InputsSet, out double[,] OutputsSet, int InputsCount, int OutputsCount, int SampleCount)
        {
            string[] ArraySet = File.ReadAllText(PathToSet).Split(new char[] { ' ', '\n', '#', '|' }, StringSplitOptions.RemoveEmptyEntries); //System.IO
            OutputsSet = new double[SampleCount, OutputsCount];
            InputsSet = new double[SampleCount, InputsCount];
            int SampleLength = OutputsCount + InputsCount;
            for (int SampleChanger = 0, SampleCounter = 0; (SampleChanger < ArraySet.Length && SampleCounter < SampleCount); SampleChanger += SampleLength, SampleCounter++)
            {
                for (int j = SampleChanger, i = 0; j < InputsCount + SampleChanger; j++, i++)
                {
                    Double.TryParse(ArraySet[j], out InputsSet[SampleCounter, i]);
                }
                for (int j = SampleChanger + InputsCount, i = 0; j < OutputsCount + SampleChanger + InputsCount; j++, i++)
                {
                    Double.TryParse(ArraySet[j], out OutputsSet[SampleCounter, i]);
                }
            }
        }
    }
}

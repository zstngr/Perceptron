using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerceptronLibrary
{
    public struct DataPlot
    {
        public double Epoch { get; private set; }
        public double Error { get; private set; }

        public DataPlot(int Epoch, double Error)
        {
            this.Epoch = Epoch;
            this.Error = Error;
        }
    }
}

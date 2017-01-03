using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gesture_Extractor.Utilities_
{
    public struct Report
    {
        public double E;
        public int i;
        public double etha;
        public Report(double pE, int pi, double pEtha)
        {
            E = pE;
            i = pi;
            etha = pEtha;
        }
    }
}

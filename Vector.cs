using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorsUnit {
    public class Vector {

        public double Theta { get; set; }
        public double R { get; set; }
        
        public Vector(double _r, double _theta) {
            R = _r;
            Theta = _theta;
        }

        public double[] GetRectangular() => Operations.PolarToRectangular(R, Theta);

        public double[] GetPolar() => new double[] { R, Theta };

    }
}

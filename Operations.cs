using System;
using System.Collections.Generic;

namespace VectorsUnit {
    public abstract class Operations {

        public static double[] RectangularToPolar(double x, double y) {

            double[] polar = new double[2];

            polar[0] = Math.Sqrt((x * x) + (y * y));
            polar[1] = RadiansToDegrees(Math.Atan(x / y));

            return polar;
        }

        public static double[] PolarToRectangular(double r, double theta) {

            double[] rect = new double[2];

            rect[0] = r * Math.Cos(theta * Math.PI / 180);
            rect[1] = r * Math.Sin(DegreesToRadians(theta));

            return rect;
        }

        public static double DegreesToRadians(double deg) {
            return deg * Math.PI / 180;
        }

        public static double RadiansToDegrees(double rad) {
            return rad * 180 / Math.PI;
        }

        /// <summary>
        /// Returns the vector as a unit vector.
        /// </summary>
        /// <param name="vector">Starting vector in cartesian coordinates.</param>
        /// <returns>Final vector in cartesian coordinates.</returns>
        public static double[] VectorToUnitVector(double[] vector) {

            if (vector.Length < 3) return Array.Empty<double>();

            double magnitude = Math.Sqrt((vector[0] * vector[0]) + (vector[1] * vector[1]) + (vector[2] * vector[2])); // literally just pythagorean theorem

            return new double[] { vector[0] / magnitude, vector[1] / magnitude, vector[2] / magnitude };
        }

        public static double[] DotProduct(double xOne, double yOne, double xTwo, double yTwo, double zOne = 0, double zTwo = 0) {
            return new double[] { xOne * xTwo, yOne * yTwo, zOne * zTwo };
        }

        public static double[] CrossProduct(double ax, double bx, double ay, double by, double? az = null, double? bz = null) {
            if (az != null && bz != null) { // 3D
                double i = ay * (double)bz - (double)az * by;
                double j = ax * (double)bz - (double)az * bx;
                double k = ax * by - ay * bx;

                return new double[] { i, -j, k };
            } else { // 2D
                double i = ax * by;
                double j = ay * bx;

                return new double[] { i, -j };
            }
        }

        public static double CompAOntoB(double[] va, double[] vb) {
            double[] dotP = Operations.DotProduct(va[0], va[1], vb[0], vb[1], va[2], vb[2]);
            double dotPTotal = dotP[0] + dotP[1] + dotP[2];
            Console.WriteLine($"U dot V: {dotPTotal}");
            double vbMag = Math.Sqrt((dotP[0] * dotP[0]) + (dotP[1] * dotP[1]) + (dotP[2] * dotP[2]));
            return dotPTotal / vbMag; // (a . b) / ||b||
        }

        public static double[] ProjAOntoB(double[] va, double[] vb) {
            double compAOB = CompAOntoB(va, vb);
            double[] uvB = VectorToUnitVector(vb);

            return new double[] { uvB[0] * compAOB, uvB[1] * compAOB, uvB[2] * compAOB };
        }

        public static double AngleBetweenVectors(double[] va, double[] vb) {
            double[] dotP = DotProduct(va[0], vb[0], va[1], vb[1], va[2], vb[2]);

            double dotPTotal = dotP[0] + dotP[1] + dotP[2];

            double magA = Math.Sqrt((va[0] * va[0]) + (va[1] * va[1]) + (va[2] * va[2]));
            double magB = Math.Sqrt((vb[0] * vb[0]) + (vb[1] * vb[1]) + (vb[2] * vb[2]));

            return Operations.RadiansToDegrees(Math.Acos(dotPTotal / (magA * magB)));
        }
    }
}

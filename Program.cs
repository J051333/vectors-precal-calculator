using System;

namespace VectorsUnit {
    public class Program {
        public static void Main(string[] args) {
            bool cont = true;
            string? selection;
            string options = 
@"Please select an option: 

    1. Rectangular to Polar (x, y)
    2. Polar to Rectangular (r, theta)
    3. Degrees to Radians
    4. Radians to Degrees
    5. Vector to Unit Vector (double[])
    6. Dot Product (ax, ay, (az,) bx, by, (bz))
    7. Cross Product (ax, ay, az, bx, by, bz)
    8. Projection of A onto B (ax, ay, az, bx, by, bz)
    9. Angle between two vectors (ax, ay, az, bx, by, bz)

    CLR to clear
    STOP to stop

<Select> ";

            while (cont) {
                Console.Write(options);
                selection = Console.ReadLine();
                if (selection != null) {
                    try {
                        if (selection.ToLower().Equals("stop")) { break; }
                        if (selection.ToLower().Equals("clr")) { Console.Clear(); continue; }

                        HandleSelection(Int32.Parse(selection));
                    } catch (Exception) {
                        Sorry();
                    }
                }
            }
            Console.Write("Stopping");
            Thread.Sleep(500);
            Console.Write(".");
            Thread.Sleep(500);
            Console.Write(".");
            Thread.Sleep(500);
            Console.WriteLine(".");
        }

        public static void HandleSelection(int s) {
            if (s == 1) {
                double x, y;
                try {
                    Console.Write("Please enter x: ");
                    string? xStr = Console.ReadLine();
                    if (xStr != null) {
                        x = double.Parse(xStr);
                    } else {
                        throw new Exception();
                    }

                    Console.Write("Please enter y: ");
                    string? yStr = Console.ReadLine();
                    if (yStr != null) {
                        y = double.Parse(yStr);
                    } else {
                        throw new Exception();
                    }
                } catch (Exception) {
                    Sorry();
                    return;
                }

                double[] rtp = Operations.RectangularToPolar(x, y);

                if (!double.IsNaN(x) && !double.IsNaN(y)) {
                    Console.WriteLine($"\nPolar: ({rtp[0]}, {rtp[1]})\n");
                } else {
                    Sorry();
                }
            } else if (s == 2) { // r to Rect
                double r, theta;

                try {
                    Console.Write("Please enter r: ");
                    string? rStr = Console.ReadLine();
                    if (rStr != null) {
                        r = double.Parse(rStr);
                    } else {
                        throw new Exception();
                    }

                    Console.Write("Please enter theta: ");
                    string? thetaStr = Console.ReadLine();
                    if (thetaStr != null) {
                        theta = double.Parse(thetaStr);
                    } else {
                        throw new Exception();
                    }
                } catch (Exception) {
                    Sorry();
                    return;
                }

                double[] ptr = Operations.PolarToRectangular(r, theta);

                if (!double.IsNaN(r) && !double.IsNaN(theta)) {
                    Console.WriteLine($"\nRectangular: ({ptr[0]}, {ptr[1]})\n");
                } else {
                    Sorry();
                }
            } else if (s == 3) { // Deg to Rad
                double degrees;

                try {
                    Console.Write("Please enter the degrees: ");
                    string? degreesStr = Console.ReadLine();

                    if (degreesStr != null) {
                        degrees = double.Parse(degreesStr);
                    } else {
                        throw new Exception();
                    }
                } catch (Exception) {
                    Sorry();
                    return;
                }

                double radians = Operations.DegreesToRadians(degrees);

                Console.WriteLine($"\nRadians: {radians} or {radians / Math.PI}pi\n");
            } else if (s == 4) { // Rad to Deg
                double radians;

                try {
                    Console.Write("Please enter the radians: ");
                    string? radiansStr = Console.ReadLine();

                    if (radiansStr != null) {
                        radians = double.Parse(radiansStr);
                    } else {
                        throw new Exception();
                    }
                } catch (Exception) {
                    Sorry();
                    return;
                }

                double degrees = Operations.RadiansToDegrees(radians);

                Console.WriteLine($"\nDegrees: {degrees}\n");
            } else if (s == 5) { // Vector to Unit Vector
                double[] vector = new double[3];

                try {
                    Console.Write("Please enter the first component of the vector: ");
                    string? vxStr = Console.ReadLine();

                    if (vxStr != null) {
                        vector[0] = double.Parse(vxStr);
                    } else {
                        throw new Exception();
                    }

                    Console.Write("Please enter the second component of the vector: ");
                    string? vyStr = Console.ReadLine();

                    if (vyStr != null) {
                        vector[1] = double.Parse(vyStr);
                    } else {
                        throw new Exception();
                    }

                    Console.Write("Please enter the third component of the vector: ");
                    string? vzStr = Console.ReadLine();

                    if (vzStr != null) {
                        vector[2] = double.Parse(vzStr);
                    } else {
                        throw new Exception();
                    }
                } catch (Exception) {
                    Sorry();
                    return;
                }

                double[] unitVector = Operations.VectorToUnitVector(vector);

                Console.WriteLine($"\nUnit Vector: ({unitVector[0]}, {unitVector[1]})\n");
            } else if (s == 6) {
                double[] va = new double[3];
                double[] vb = new double[3];
                string? toParse;

                try {
                    Console.Write("Please enter x of vector a: ");
                    toParse = Console.ReadLine();

                    if (toParse != null) {
                        va[0] = double.Parse(toParse);
                    } else {
                        throw new Exception();
                    }

                    Console.Write("Please enter y of vector a: ");
                    toParse = Console.ReadLine();

                    if (toParse != null) {
                        va[1] = double.Parse(toParse);
                    } else {
                        throw new Exception();
                    }

                    Console.Write("Please enter z of vector a: ");
                    toParse = Console.ReadLine();

                    if (toParse != null) {
                        va[2] = double.Parse(toParse);
                    } else {
                        throw new Exception();
                    }

                    Console.Write("Please enter x of vector b: ");
                    toParse = Console.ReadLine();

                    if (toParse != null) {
                        vb[0] = double.Parse(toParse);
                    } else {
                        throw new Exception();
                    }

                    Console.Write("Please enter y of vector b: ");
                    toParse = Console.ReadLine();

                    if (toParse != null) {
                        vb[1] = double.Parse(toParse);
                    } else {
                        throw new Exception();
                    }

                    Console.Write("Please enter z of vector b: ");
                    toParse = Console.ReadLine();

                    if (toParse != null) {
                        vb[2] = double.Parse(toParse);
                    } else {
                        throw new Exception();
                    }
                } catch (Exception) {
                    Sorry();
                    return;
                }

                double[] dotP = Operations.DotProduct(va[0], vb[0], va[1], vb[1], va[2], vb[2]);

                Console.WriteLine($"\nDot Product: x = {dotP[0]}, y = {dotP[1]}, z = {dotP[2]}, total = {dotP[0] + dotP[1] + dotP[2]}\n");
            } else if (s == 7) {
                double[] va = new double[3];
                double[] vb = new double[3];
                string? toParse;

                try {
                    Console.Write("Please enter x of vector a: ");
                    toParse = Console.ReadLine();

                    if (toParse != null) {
                        va[0] = double.Parse(toParse);
                    } else {
                        throw new Exception();
                    }

                    Console.Write("Please enter y of vector a: ");
                    toParse = Console.ReadLine();

                    if (toParse != null) {
                        va[1] = double.Parse(toParse);
                    } else {
                        throw new Exception();
                    }

                    Console.Write("Please enter z of vector a: ");
                    toParse = Console.ReadLine();

                    if (toParse != null) {
                        va[2] = double.Parse(toParse);
                    } else {
                        throw new Exception();
                    }

                    Console.Write("Please enter x of vector b: ");
                    toParse = Console.ReadLine();

                    if (toParse != null) {
                        vb[0] = double.Parse(toParse);
                    } else {
                        throw new Exception();
                    }

                    Console.Write("Please enter y of vector b: ");
                    toParse = Console.ReadLine();

                    if (toParse != null) {
                        vb[1] = double.Parse(toParse);
                    } else {
                        throw new Exception();
                    }

                    Console.Write("Please enter z of vector b: ");
                    toParse = Console.ReadLine();

                    if (toParse != null) {
                        vb[2] = double.Parse(toParse);
                    } else {
                        throw new Exception();
                    }
                } catch (Exception) {
                    Sorry();
                    return;
                }

                double[] crossP = Operations.CrossProduct(va[0], vb[0], va[1], vb[1], va[2], vb[2]);

                Console.WriteLine($"\nCross Product: x = {crossP[0]}, y = {crossP[1]}, z = {crossP[2]}, total = {crossP[0] + crossP[1] + crossP[2]}\n");

            } else if (s == 8) {
                double[] va = new double[3];
                double[] vb = new double[3];
                string? toParse;

                try {
                    Console.Write("Please enter x of vector a: ");
                    toParse = Console.ReadLine();

                    if (toParse != null) {
                        va[0] = double.Parse(toParse);
                    } else {
                        throw new Exception();
                    }

                    Console.Write("Please enter y of vector a: ");
                    toParse = Console.ReadLine();

                    if (toParse != null) {
                        va[1] = double.Parse(toParse);
                    } else {
                        throw new Exception();
                    }

                    Console.Write("Please enter z of vector a: ");
                    toParse = Console.ReadLine();

                    if (toParse != null) {
                        va[2] = double.Parse(toParse);
                    } else {
                        throw new Exception();
                    }

                    Console.Write("Please enter x of vector b: ");
                    toParse = Console.ReadLine();

                    if (toParse != null) {
                        vb[0] = double.Parse(toParse);
                    } else {
                        throw new Exception();
                    }

                    Console.Write("Please enter y of vector b: ");
                    toParse = Console.ReadLine();

                    if (toParse != null) {
                        vb[1] = double.Parse(toParse);
                    } else {
                        throw new Exception();
                    }

                    Console.Write("Please enter z of vector b: ");
                    toParse = Console.ReadLine();

                    if (toParse != null) {
                        vb[2] = double.Parse(toParse);
                    } else {
                        throw new Exception();
                    }
                } catch (Exception) {
                    Sorry();
                    return;
                }

                double[] proj = Operations.ProjAOntoB(va, vb);
                double comp = Operations.CompAOntoB(va, vb);

                Console.WriteLine($"\nProjection of A Onto B: ({proj[0]}, {proj[1]}, {proj[2]})\nComp: {comp}\n");
            } else if (s == 9) {
                double[] va = new double[3];
                double[] vb = new double[3];
                string? toParse;

                try {
                    Console.Write("Please enter x of vector a: ");
                    toParse = Console.ReadLine();

                    if (toParse != null) {
                        va[0] = double.Parse(toParse);
                    } else {
                        throw new Exception();
                    }

                    Console.Write("Please enter y of vector a: ");
                    toParse = Console.ReadLine();

                    if (toParse != null) {
                        va[1] = double.Parse(toParse);
                    } else {
                        throw new Exception();
                    }

                    Console.Write("Please enter z of vector a: ");
                    toParse = Console.ReadLine();

                    if (toParse != null) {
                        va[2] = double.Parse(toParse);
                    } else {
                        throw new Exception();
                    }

                    Console.Write("Please enter x of vector b: ");
                    toParse = Console.ReadLine();

                    if (toParse != null) {
                        vb[0] = double.Parse(toParse);
                    } else {
                        throw new Exception();
                    }

                    Console.Write("Please enter y of vector b: ");
                    toParse = Console.ReadLine();

                    if (toParse != null) {
                        vb[1] = double.Parse(toParse);
                    } else {
                        throw new Exception();
                    }

                    Console.Write("Please enter z of vector b: ");
                    toParse = Console.ReadLine();

                    if (toParse != null) {
                        vb[2] = double.Parse(toParse);
                    } else {
                        throw new Exception();
                    }
                } catch (Exception) {
                    Sorry();
                    return;
                }

                double angle = Operations.AngleBetweenVectors(va, vb);

                Console.WriteLine($"\nAngle between vectors a and b: {angle}");
            }
        }

        public static void Sorry() {
            Console.WriteLine("Sorry, something went wrong, please try again.");
        }
    }
}
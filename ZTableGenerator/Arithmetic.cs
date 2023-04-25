namespace ZTableGenerator
{
    public static class Arithmetic
    {
        /// <summary>
        /// Φ(x) = (1 / √(2π)) ∫e^(-t^2/2) dt, where the integral is evaluated from -∞ to x.
        /// Abramowitz and Stegun approximation formula, which is accurate to within 10^-7 for all values of x
        /// Φ(x) = (1 / 2π^0.5) * e^(-x^2/2) * (a1t + a2t^2 + a3t^3 + a4t^4 + a5t^5)
        /// where t=1/(1+px) and p=0.2316419. The coefficients a1 to a5 are constants that depend on p.
        /// C => 1 / Math.Sqrt(2 * Math.PI) = 0.3989422804014327
        /// </summary>
        /// <param name="x">zcore to calculate</param>
        /// <returns>the calculated value according to the above equations</returns>
        public static double NormalCDF(double x, double p, double a1, double a2, double a3, double a4, double a5)
        {
            double t = 1 / (1 + p * Math.Abs(x));
            double d = 0.3989423 * Math.Exp(-x * x / 2);
            double prob = d * t * (a1 + t * (a2 + t * (a3 + t * (a4 + t * a5))));
            return x > 0 ? 1 - prob : prob;
        }

        /// <summary>
        /// Generates a range of double values around zero, with a specified range and increment.
        /// </summary>
        /// <param name="range">The maximum absolute value of the generated values, such that the generated range will be from -range to range.</param>
        /// <param name="increment">The step size between successive values in the range.</param>
        /// <param name="round">The number of decimal places to round each value in the range to (default is 1).</param>
        /// <returns>An array of double values representing the desired range.</returns>
        public static double[] RangeAroundZero(double range, double increment, int round = 1)
        {
            double[] vals = new double[(int)(range / increment * 2) + 1];
            for (double i = -range, c = 0; i <= range; i = Math.Round(i + increment, round), c++)
                vals[(int)c] = i;
            return vals;
        }

        /// <summary>
        /// Generates a range of double values above zero, with a specified range and increment.
        /// </summary>
        /// <param name="range">The maximum value of the generated values, such that the generated range will be from 0 to range.</param>
        /// <param name="increment">The step size between successive values in the range.</param>
        /// <param name="round">The number of decimal places to round each value in the range to (default is 2).</param>
        /// <returns>An array of double values representing the desired range.</returns>
        public static double[] RangeAboveZero(double range, double increment, int round = 2)
        {
            double[] vals = new double[(int)(range / increment) + 1];
            for (double i = 0, c = 0; i <= range; i = Math.Round(i + increment, round), c++)
                vals[(int)c] = i;
            return vals;
        }

        /// <summary>
        /// Creates a 2D double array representing a range of values calculated from two 1D double arrays.
        /// </summary>
        /// <param name="V">The array of vertical values.</param>
        /// <param name="H">The array of horizontal values.</param>
        /// <param name="digits">The number of decimal places to round each value in the range to (default is 2).</param>
        /// <returns>A 2D double array representing the range of values.</returns>
        public static double[,] CreateRange(double[] V, double[] H, int digits = 2)
        {
            var range = new double[V.Length, H.Length];
            for (int i = 0; i < V.Length; i++)
                for (int j = 0; j < H.Length; j++)
                    range[i, j] = Math.Round(V[i] + H[j], digits);
            return range;
        }
    }
}
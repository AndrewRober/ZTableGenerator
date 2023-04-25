namespace ZTableGenerator
{
    class Program
    {
        //constants but for the symboles to match the equation properly, we let them lower case.
        const double p = 0.2316419, a1 = 0.3193815, a2 = -0.3565638, a3 = 1.781478, a4 = -1.821256, a5 = 1.330274,
            VERTICAL_PRECISION = 0.1, HORIZONTAL_PRECISION = 0.01, VERTICAL_RANGE = 3.4, HORIZONTAL_RANGE = 0.10;
        //vertical range was choosen according to the Empirical Rule aka 3 segma rule 68-95-99.7 which
        //is that -3.4->3.4 range covers (99.7%)
        const bool INCLUDE_NEGATIVE = false;

        static void Main(string[] args)
        {
            var horizontal_range = RangeAboveZero(HORIZONTAL_RANGE, HORIZONTAL_PRECISION);
            var vertical_range = RangeAroundZero(VERTICAL_RANGE, VERTICAL_PRECISION);

            Console.ReadKey();
        }


        /// <summary>
        /// Φ(x) = (1 / √(2π)) ∫e^(-t^2/2) dt, where the integral is evaluated from -∞ to x.
        /// Abramowitz and Stegun approximation formula, which is accurate to within 10^-7 for all values of x
        /// Φ(x) = (1 / 2π^0.5) * e^(-x^2/2) * (a1t + a2t^2 + a3t^3 + a4t^4 + a5t^5)
        /// where t=1/(1+px) and p=0.2316419. The coefficients a1 to a5 are constants that depend on p.
        /// C => 1 / Math.Sqrt(2 * Math.PI) = 0.3989422804014327
        /// </summary>
        /// <param name="x">zcore to calculate</param>
        /// <returns>the calculated value according to the above equations</returns>
        static double NormalCDF(double x)
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
        static double[] RangeAroundZero(double range, double increment, int round = 1)
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
        static double[] RangeAboveZero(double range, double increment, int round = 2)
        {
            double[] vals = new double[(int)(range / increment)];
            for (double i = 0, c = 0; i < range; i = Math.Round(i + increment, round), c++)
                vals[(int)c] = i;
            return vals;
        }
    }
}
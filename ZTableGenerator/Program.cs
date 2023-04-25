namespace ZTableGenerator
{
    public class Program
    {
        //constants but for the symboles to match the equation properly, we let them lower case.
        public const double p = 0.2316419, a1 = 0.3193815, a2 = -0.3565638, a3 = 1.781478, a4 = -1.821256, a5 = 1.330274,
            VERTICAL_PRECISION = 0.1, HORIZONTAL_PRECISION = 0.01, VERTICAL_RANGE = 3.4, HORIZONTAL_RANGE = 0.09;
        //vertical range was choosen according to the Empirical Rule aka 3 segma rule 68-95-99.7 which
        //is that -3.4->3.4 range covers (99.7%)
        const bool INCLUDE_NEGATIVE = false;

        static void Main(string[] args)
        {
            var range = Arithmetic.CreateRange(INCLUDE_NEGATIVE ?
                Arithmetic.RangeAroundZero(VERTICAL_RANGE, VERTICAL_PRECISION)
                : Arithmetic.RangeAboveZero(VERTICAL_RANGE, VERTICAL_PRECISION)
                , Arithmetic.RangeAboveZero(HORIZONTAL_RANGE, HORIZONTAL_PRECISION));

            for (int i = 0; i < range.GetLength(0); i++)
                for (int j = 0; j < range.GetLength(1); j++)
                    range[i, j] = Math.Round(Arithmetic.NormalCDF(range[i, j], p, a1, a2, a3, a4, a5), 4);

            Print2DArrayAsTable(range);
        }

        /// <summary>
        /// Prints a 2D double array as a table to the console.
        /// </summary>
        /// <param name="array">The 2D double array to print as a table.</param>
        static void Print2DArrayAsTable(double[,] array)
        {
            // Get the dimensions of the array
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);

            // Find the maximum length of each column
            int[] maxColumnLengths = new int[cols];
            for (int j = 0; j < cols; j++)
            {
                int max = 0;
                for (int i = 0; i < rows; i++)
                    if (array[i, j].ToString().Length > max)
                        max = array[i, j].ToString().Length;
                maxColumnLengths[j] = max;
            }

            Console.WriteLine(new string('-', 101));
            // Print the table header
            for (int j = 0; j < cols; j++)
                Console.Write("| {0,-" + (maxColumnLengths[j] + 2) + "}", array[0, j]);
            Console.WriteLine("|");
            Console.WriteLine(new string('-', 101));

            // Print the table rows
            for (int i = 1; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                    Console.Write("| {0,-" + (maxColumnLengths[j] + 2) + "}", array[i, j]);
                Console.WriteLine("|");
                Console.WriteLine(new string('-', 101));
            }
        }

    }
}
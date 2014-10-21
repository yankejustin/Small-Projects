using System;
using System.Collections.Generic;
using System.Linq;

namespace prjSmallestMultiple
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();

                try
                {
                    Console.WriteLine("Smallest positive number that is evenly divisible by all of the numbers from 1-10:");
                    Console.WriteLine(SmallestDivisibleNumber(1, 10).ToString());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.ReadKey(true);
            }
        }

        /// <summary>
        /// Returns the smallest integer that is a number divisible with all inclusive elements between the minimum and maximum values.
        /// </summary>
        /// <param name="Minimum"></param>
        /// <param name="Maximum"></param>
        /// <returns></returns>
        private static int SmallestDivisibleNumber(int Minimum, int Maximum)
        {
            if (Minimum > Maximum)
            {
                throw new InvalidOperationException("Minimum number must be greater than the maximum number.");
            }

            List<int> NumbersToMatch = new List<int>();
            for (int i = Minimum; i < Maximum; i++)
            {
                NumbersToMatch.Add(i);
            }

            bool match = false;
            int x = 1;

            while (!match)
            {
                if (NumbersToMatch.All(i => ((x % i) == 0)))
                {
                    match = true;

                    return x;
                }
                else
                {
                    x++;
                }
            }

            throw new Exception("No divisible number has been found.");
        }
    }
}
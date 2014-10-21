/*
 * Name: Sum of Multiples Calculator
 * Author: Justin Yanke
 * Date: 10/21/14
 * Description: Finds the multiples of a number (optionally using more than one multiple), and obtains the sum of them.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace prjSumOfMultiples
{
    class Programs
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Stopwatch watcher = new System.Diagnostics.Stopwatch();

                    watcher.Start();
                    Console.WriteLine("Answer = " + FindSumOfMultiples(60000, 3, 5));
                    watcher.Stop();

                    Console.WriteLine("Done in " + watcher.Elapsed.TotalMilliseconds.ToString() + " ms");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.ReadKey(true);
            }
        }

        /// <summary>
        /// Obtain the sum of all multiples of the integers provided that are in the maximum number provided.
        /// </summary>
        /// <param name="MaximumNumber">The number to find multiples of.</param>
        /// <param name="Numbers">The numbers to find and obtain the sum of from MaximumNumber</param>
        /// <returns></returns>
        static long FindSumOfMultiples(int MaximumNumber, params int[] Numbers)
        {
            // Don't check for overflow to make it faster. Doing this tells the compiler to not check for overflow.
            // To Do: Add check to prevent overflow issues.
            checked
            {
                // Store the matches in a list of longs (for precision).
                List<long> matches = new List<long>();

                int count = Numbers.Count();

                // The first loop is to loop for each number to check for.
                for (int i = 0; i < count; i++)
                {
                    // The second loop (below) is to loop through each number of MaximumNumber
                    // to see if it is a multiple of the number.
                    for (int MainLoop = 1; MainLoop <= MaximumNumber; MainLoop++)
                    {
                        if ((MainLoop % Numbers[i]) == 0)
                        {
                            matches.Add(MainLoop);
                        }
                    }
                }

                long Result = matches.Aggregate((NumberOne, NumberTwo) => (NumberOne + NumberTwo));

                return Result;
            }
        }
    }
}
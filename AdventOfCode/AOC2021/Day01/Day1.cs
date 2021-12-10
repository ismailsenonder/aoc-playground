using System;
using System.IO;

namespace AOC2021
{
    public class Day1
    {
        private static string path = Environment.CurrentDirectory + @"\\Day01\input.txt";
        public static int Part1_MeasurementIncrementCount()
        {
            int prev = 0, curr = 0, count = 0;
            string line;
            
            StreamReader file = new StreamReader(path);
            while ((line = file.ReadLine()) != null)
            {
                prev = curr;
                curr = Convert.ToInt32(line);
                if (curr > prev) count++;
            }
            file.Close();
            return count - 1;
        }

        public static int Part2_ThreeMeasurementIncrementCount()
        {
            int index1 = 0, index2 = 0, index3 = 0,
                count = 0, previousSum = 0, currentSum = 0, skipcount = 0;
            string line;
            StreamReader file = new StreamReader(path);
            while ((line = file.ReadLine()) != null)
            {
                index1 = index2;
                index2 = index3;
                index3 = Convert.ToInt32(line);

                if (skipcount < 2)
                {
                    skipcount++;
                    continue;
                }

                previousSum = currentSum;
                currentSum = index1 + index2 + index3;
                if (currentSum > previousSum) count++;
            }
            file.Close();
            return count - 1;
        }
    }
}

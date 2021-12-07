using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AOC2021
{
    public class Day6
    {
        private static string path = Environment.CurrentDirectory + @"\\Day6\input.txt";
        public static ulong CalculateNumberOfLanternFish(int numberOfDays)
        {
            StreamReader file = new StreamReader(path);
            string[] initialLanternFishes = file.ReadLine().Split(",");
            ulong[] fishCounts = new ulong[10];

            foreach (string s in initialLanternFishes)
            {
                fishCounts[Convert.ToInt32(s)]++;
            }

            for (int i = 0; i < numberOfDays; i++)
            {
                fishCounts[7] += fishCounts[0];
                fishCounts[9] = fishCounts[0];
                for (int j = 0; j < 9; j++)
                {
                    fishCounts[j] = fishCounts[j + 1];
                }
            }

            ulong sum = 0;
            for (int i = 0; i < 9; i++)
            {
                sum += fishCounts[i];
            }

            return sum;
        }
    }
}

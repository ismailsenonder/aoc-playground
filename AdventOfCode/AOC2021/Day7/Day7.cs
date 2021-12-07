using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AOC2021
{
    public class Day7
    {
        private static string path = Environment.CurrentDirectory + @"\\Day7\input.txt";

        //isAccordingToCrab = false => calculate according to submarine
        //isAccordingToCrab = true => calculate according to crabss
        public static int CalculateFuelConsumption(bool isAccordingToCrab)
        {
            StreamReader file = new StreamReader(path);
            string line = file.ReadLine();
            List<int> positions = new List<int>();
            string[] strPositions = line.Split(",");
            foreach (string s in strPositions)
            {
                positions.Add(Convert.ToInt32(s));
            }

            positions.Sort();
            int maxPosition = positions.Last();
            int sum = 0;
            int finalSum = 0;
            int numberOfSteps = 0;


            for (int i = 0; i <= maxPosition; i++)
            {
                sum = 0;

                foreach (int crab in positions)
                {
                    numberOfSteps = Math.Abs(i - crab);
                    if(isAccordingToCrab)
                    {
                        sum = sum + ((numberOfSteps * (numberOfSteps + 1)) / 2);
                    }
                    else
                    {
                        sum = sum + numberOfSteps;
                    }
                }

                if (finalSum == 0)
                    finalSum = sum;
                else if (finalSum > sum)
                    finalSum = sum;
                else
                    continue;
            }

            return finalSum;
        }
    }
}

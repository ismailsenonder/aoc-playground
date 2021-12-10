using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AOC2021
{
    public class Day3
    {
        private static string path = Environment.CurrentDirectory + @"\\Day03\input.txt";

        public static int Part1_CalculateGammaTimesEpsilon()
        {
            string line = "";
            char[] gamma = new char[12];
            char[] epsilon = new char[12];
            int[] countOfOnes = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            StreamReader file = new StreamReader(path);
            while ((line = file.ReadLine()) != null)
            {
                countOfOnes[0] += Convert.ToInt32(line[0].ToString());
                countOfOnes[1] += Convert.ToInt32(line[1].ToString());
                countOfOnes[2] += Convert.ToInt32(line[2].ToString());
                countOfOnes[3] += Convert.ToInt32(line[3].ToString());
                countOfOnes[4] += Convert.ToInt32(line[4].ToString());
                countOfOnes[5] += Convert.ToInt32(line[5].ToString());
                countOfOnes[6] += Convert.ToInt32(line[6].ToString());
                countOfOnes[7] += Convert.ToInt32(line[7].ToString());
                countOfOnes[8] += Convert.ToInt32(line[8].ToString());
                countOfOnes[9] += Convert.ToInt32(line[9].ToString());
                countOfOnes[10] += Convert.ToInt32(line[10].ToString());
                countOfOnes[11] += Convert.ToInt32(line[11].ToString());
            }
            file.Close();
            for (int i = 0; i < 12; i++)
            {
                if (countOfOnes[i] > 500)
                {
                    gamma[i] = '1';
                    epsilon[i] = '0';
                }
                else
                {
                    gamma[i] = '0';
                    epsilon[i] = '1';
                }

            }

            string strGamma = new string(gamma);
            string strEpsilon = new string(epsilon);

            return Convert.ToInt32(strEpsilon, 2) * Convert.ToInt32(strGamma, 2);
        }

        public static int Part2_CalculateO2GeneratorTimesCO2Scrubber()
        {
            string line;
            List<string> inputListForOxygen = new List<string>();
            List<string> inputListForCO2 = new List<string>();

            StreamReader file = new StreamReader(path);
            while ((line = file.ReadLine()) != null)
            {
                inputListForOxygen.Add(line);
                inputListForCO2.Add(line);
            }
            file.Close();

            int indexToCheckForOxygen = 0;
            while (inputListForOxygen.Count > 1)
            {
                inputListForOxygen = FilterMostUsedOnes(inputListForOxygen, indexToCheckForOxygen);
                indexToCheckForOxygen++;
            }

            int indexToCheckForC02 = 0;
            while (inputListForCO2.Count > 1)
            {
                inputListForCO2 = FilterLeastUsedOnes(inputListForCO2, indexToCheckForC02);
                indexToCheckForC02++;
            }

            return Convert.ToInt32(inputListForOxygen.ElementAt(0), 2) *
                Convert.ToInt32(inputListForCO2.ElementAt(0), 2);
        }

        static List<string> FilterMostUsedOnes(List<string> input, int indexToCheck)
        {
            int countOfOnes = 0;
            foreach (string str in input)
            {
                countOfOnes += Convert.ToInt32(str[indexToCheck].ToString());
            }

            if (countOfOnes >= input.Count - countOfOnes)
                return input.Where(x => x[indexToCheck] == '1').ToList();
            else
                return input.Where(x => x[indexToCheck] == '0').ToList();
        }

        static List<string> FilterLeastUsedOnes(List<string> input, int indexToCheck)
        {
            int countOfOnes = 0;
            foreach (string str in input)
            {
                countOfOnes += Convert.ToInt32(str[indexToCheck].ToString());
            }

            if (countOfOnes >= input.Count - countOfOnes)
                return input.Where(x => x[indexToCheck] == '0').ToList();
            else
                return input.Where(x => x[indexToCheck] == '1').ToList();
        }
    }
}

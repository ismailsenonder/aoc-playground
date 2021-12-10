using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AOC2021
{
    public class Day8
    {
        private static string path = Environment.CurrentDirectory + @"\\Day08\input.txt";

        private enum Numbers
        {
            Zero = 6,
            One = 2,
            Two = 5,
            Three = 5,
            Four = 4,
            Five = 5,
            Six = 6,
            Seven = 3,
            Eight = 7,
            Nine = 6
        }

        public static int Part2_TotalOfAllFourDigitInput()
        {
            string one, four, seven, eight;
            string commonElementsOfOneAndSeven = "";
            int numberOfCommonElementsWithFour = 0;
            List<string> zeroSixNine = new List<string>();
            List<string> twoThreeFive = new List<string>();
            int sum = 0;
            string[] allLineElements;
            List<string> firstLineElements = new List<string>();
            List<string> secondLineElements = new List<string>();
            string wholeNumber = "";

            StreamReader file = new StreamReader(path);
            string line = "";

            while ((line = file.ReadLine()) != null)
            {
                allLineElements = line.Split("|");
                firstLineElements = allLineElements[0].Split(" ").ToList();

                one = firstLineElements.Where(x => x.Length == 2).FirstOrDefault();
                four = firstLineElements.Where(x => x.Length == 4).FirstOrDefault();
                seven = firstLineElements.Where(x => x.Length == 3).FirstOrDefault();
                eight = firstLineElements.Where(x => x.Length == 7).FirstOrDefault();

                for (int i = 0; i < 3; i++)
                {
                    if (one.Contains(seven[i]))
                        commonElementsOfOneAndSeven += seven[i];
                }

                secondLineElements = allLineElements[1].Trim().Split(" ").ToList();

                foreach (string digit in secondLineElements)
                {
                    if (digit.Length == 2)
                        wholeNumber += "1";
                    else if (digit.Length == 4)
                        wholeNumber += "4";
                    else if (digit.Length == 3)
                        wholeNumber += "7";
                    else if (digit.Length == 7)
                        wholeNumber += "8";
                    else if (digit.Length == 6)
                    {
                        if (digit.Contains(four[0]) && digit.Contains(four[1])
                            && digit.Contains(four[2]) && digit.Contains(four[3]))
                        {
                            wholeNumber += "9";
                        }
                        else if ((digit.Contains(commonElementsOfOneAndSeven[0])
                            && !digit.Contains(commonElementsOfOneAndSeven[1])) ||
                            (digit.Contains(commonElementsOfOneAndSeven[1])
                            && !digit.Contains(commonElementsOfOneAndSeven[0])))
                        {
                            wholeNumber += "6";
                        }
                        else
                            wholeNumber += "0";
                    }
                    else if (digit.Length == 5)
                    {
                        if (digit.Contains(commonElementsOfOneAndSeven[0])
                            && digit.Contains(commonElementsOfOneAndSeven[1]))
                        {
                            wholeNumber += "3";
                        }
                        else
                        {
                            for (int j = 0; j < 5; j++)
                            {
                                for (int k = 0; k < 4; k++)
                                {
                                    if (digit[j] == four[k])
                                        numberOfCommonElementsWithFour++;
                                }
                            }

                            if (numberOfCommonElementsWithFour == 3)
                                wholeNumber += "5";
                            else
                                wholeNumber += "2";
                        }
                    }
                    else
                        throw new Exception("This number doesn't exist!");

                    numberOfCommonElementsWithFour = 0;
                }

                sum += Convert.ToInt32(wholeNumber);
                commonElementsOfOneAndSeven = "";
                wholeNumber = "";
            }

            return sum;
        }

        public static int Part1_NumberOf1478()
        {
            StreamReader file = new StreamReader(path);
            string line = "";
            int[] numberOfCounts = new int[10];
            string[] allLineElements, secondLineElements;
            while ((line = file.ReadLine()) != null)
            {
                allLineElements = line.Split("|");
                secondLineElements = allLineElements[1].Trim().Split(" ");
                foreach (string s in secondLineElements)
                {
                    numberOfCounts[s.Length]++;
                }
            }

            int sum = numberOfCounts[(int)Numbers.One]
                + numberOfCounts[(int)Numbers.Four]
                + numberOfCounts[(int)Numbers.Seven]
                + numberOfCounts[(int)Numbers.Eight];


            return sum;
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AOC2021
{
    public class Day11
    {
        private static string path = Environment.CurrentDirectory + @"\\Day11\input.txt";
        private static int numberOfFlashes = 0;
        public class Octopus
        {
            public int CurrentValue { get; set; }
            public bool FlashedNow { get; set; }
            public bool FlashedAtThisStep { get; set; }
        }

        public static int Part1_TotalFlashesAfter100Step()
        {
            string line;
            StreamReader file = new StreamReader(path);
            Octopus[,] octopuses = new Octopus[10, 10];
            int lineIndex = 0;

            while ((line = file.ReadLine()) != null)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    octopuses[lineIndex, i] = new Octopus()
                    {
                        CurrentValue = Convert.ToInt32(line[i].ToString()),
                        FlashedNow = false,
                        FlashedAtThisStep = false
                    };
                }
                lineIndex++;
            }


            int numberOfSteps = 100;

            for (int i = 0; i < numberOfSteps; i++)
            {
                //+1 to all
                for (int j = 0; j < 10; j++)
                {
                    for (int k = 0; k < 10; k++)
                    {
                        octopuses[j, k].CurrentValue++;
                    }
                }

                int flashedOctopusCount = 1;

                while (flashedOctopusCount > 0)
                {
                    flashedOctopusCount = 0;

                    //flash octopuses that are > 9 and make them 0
                    for (int j = 0; j < 10; j++)
                    {
                        for (int k = 0; k < 10; k++)
                        {
                            if (octopuses[j, k].CurrentValue > 9)
                            {
                                numberOfFlashes++;
                                flashedOctopusCount++;

                                octopuses[j, k].FlashedNow = true;
                                octopuses[j, k].FlashedAtThisStep = true;
                                octopuses[j, k].CurrentValue = 0;
                            }
                        }
                    }

                    //+1 to all adjacent octopuses of flashed one (if it didn't before)
                    if (flashedOctopusCount > 0)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            for (int k = 0; k < 10; k++)
                            {
                                if (octopuses[j, k].CurrentValue == 0 && octopuses[j, k].FlashedNow)
                                {
                                    octopuses[j, k].FlashedNow = false;

                                    if (j != 0)
                                    {
                                        if (!octopuses[j - 1, k].FlashedAtThisStep)
                                            octopuses[j - 1, k].CurrentValue++;
                                    }

                                    if (j != 9)
                                    {
                                        if (!octopuses[j + 1, k].FlashedAtThisStep)
                                            octopuses[j + 1, k].CurrentValue++;
                                    }

                                    if (k != 0)
                                    {
                                        if (!octopuses[j, k - 1].FlashedAtThisStep)
                                            octopuses[j, k - 1].CurrentValue++;
                                    }

                                    if (k != 9)
                                    {
                                        if (!octopuses[j, k + 1].FlashedAtThisStep)
                                            octopuses[j, k + 1].CurrentValue++;
                                    }

                                    if (j != 0 && k != 0)
                                    {
                                        if (!octopuses[j - 1, k - 1].FlashedAtThisStep)
                                            octopuses[j - 1, k - 1].CurrentValue++;
                                    }

                                    if (j != 0 && k != 9)
                                    {
                                        if (!octopuses[j - 1, k + 1].FlashedAtThisStep)
                                            octopuses[j - 1, k + 1].CurrentValue++;
                                    }

                                    if (j != 9 && k != 0)
                                    {
                                        if (!octopuses[j + 1, k - 1].FlashedAtThisStep)
                                            octopuses[j + 1, k - 1].CurrentValue++;
                                    }

                                    if (j != 9 && k != 9)
                                    {
                                        if (!octopuses[j + 1, k + 1].FlashedAtThisStep)
                                            octopuses[j + 1, k + 1].CurrentValue++;
                                    }
                                }
                            }
                        }
                    }
                }

                for (int j = 0; j < 10; j++)
                {
                    for (int k = 0; k < 10; k++)
                    {
                        octopuses[j, k].FlashedNow = false;
                        octopuses[j, k].FlashedAtThisStep = false;
                    }
                }
            }

            //for testing
            //for (int j = 0; j < 10; j++)
            //{
            //    for (int k = 0; k < 10; k++)
            //    {
            //        Console.Write(octopuses[j, k].CurrentValue + " ");
            //    }
            //    Console.WriteLine();
            //}

            return numberOfFlashes;
        }

        public static int Part2_AllZeroStep()
        {
            string line;
            StreamReader file = new StreamReader(path);
            Octopus[,] octopuses = new Octopus[10, 10];
            int lineIndex = 0;

            while ((line = file.ReadLine()) != null)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    octopuses[lineIndex, i] = new Octopus()
                    {
                        CurrentValue = Convert.ToInt32(line[i].ToString()),
                        FlashedNow = false,
                        FlashedAtThisStep = false
                    };
                }
                lineIndex++;
            }


            int numberOfSteps = 0;
            int totalFlashes = 0;

            while (true)
            {
                numberOfSteps++;

                //+1 to all
                for (int j = 0; j < 10; j++)
                {
                    for (int k = 0; k < 10; k++)
                    {
                        octopuses[j, k].CurrentValue++;
                    }
                }

                int flashedOctopusCount = 1;

                while (flashedOctopusCount > 0)
                {
                    flashedOctopusCount = 0;

                    //flash for >9 and make them 0
                    for (int j = 0; j < 10; j++)
                    {
                        for (int k = 0; k < 10; k++)
                        {
                            if (octopuses[j, k].CurrentValue > 9)
                            {
                                numberOfFlashes++;
                                flashedOctopusCount++;

                                octopuses[j, k].FlashedNow = true;
                                octopuses[j, k].FlashedAtThisStep = true;
                                octopuses[j, k].CurrentValue = 0;
                            }
                        }
                    }

                    //+1 to adjacent octopuses if not flashed
                    if (flashedOctopusCount > 0)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            for (int k = 0; k < 10; k++)
                            {
                                if (octopuses[j, k].CurrentValue == 0 && octopuses[j, k].FlashedNow)
                                {
                                    octopuses[j, k].FlashedNow = false;

                                    if (j != 0)
                                    {
                                        if (!octopuses[j - 1, k].FlashedAtThisStep)
                                            octopuses[j - 1, k].CurrentValue++;
                                    }

                                    if (j != 9)
                                    {
                                        if (!octopuses[j + 1, k].FlashedAtThisStep)
                                            octopuses[j + 1, k].CurrentValue++;
                                    }

                                    if (k != 0)
                                    {
                                        if (!octopuses[j, k - 1].FlashedAtThisStep)
                                            octopuses[j, k - 1].CurrentValue++;
                                    }

                                    if (k != 9)
                                    {
                                        if (!octopuses[j, k + 1].FlashedAtThisStep)
                                            octopuses[j, k + 1].CurrentValue++;
                                    }

                                    if (j != 0 && k != 0)
                                    {
                                        if (!octopuses[j - 1, k - 1].FlashedAtThisStep)
                                            octopuses[j - 1, k - 1].CurrentValue++;
                                    }

                                    if (j != 0 && k != 9)
                                    {
                                        if (!octopuses[j - 1, k + 1].FlashedAtThisStep)
                                            octopuses[j - 1, k + 1].CurrentValue++;
                                    }

                                    if (j != 9 && k != 0)
                                    {
                                        if (!octopuses[j + 1, k - 1].FlashedAtThisStep)
                                            octopuses[j + 1, k - 1].CurrentValue++;
                                    }

                                    if (j != 9 && k != 9)
                                    {
                                        if (!octopuses[j + 1, k + 1].FlashedAtThisStep)
                                            octopuses[j + 1, k + 1].CurrentValue++;
                                    }
                                }
                            }
                        }
                    }
                }

                for (int j = 0; j < 10; j++)
                {
                    for (int k = 0; k < 10; k++)
                    {
                        octopuses[j, k].FlashedNow = false;
                        octopuses[j, k].FlashedAtThisStep = false;
                        totalFlashes += octopuses[j, k].CurrentValue;
                    }
                }


                if (totalFlashes == 0)
                    break;
                else
                    totalFlashes = 0;
            }

            //test
            //for (int j = 0; j < 10; j++)
            //{
            //    for (int k = 0; k < 10; k++)
            //    {
            //        Console.Write(octopuses[j, k].CurrentValue + " ");
            //    }
            //    Console.WriteLine();
            //}

            return numberOfSteps;
        }
    }
}

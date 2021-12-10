using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AOC2021
{
    public class Day5
    {
        private static string path = Environment.CurrentDirectory + @"\\Day05\input.txt";
        public static int Part1_IntersectionsOfOnlyHorizontalAndVerticalLines()
        {
            string line = "";
            int[,] board = new int[1000, 1000];

            string[] collectionOfPoints, firstPoint, lastPoint;
            int x1, y1, x2, y2, temp;

            StreamReader file = new StreamReader(path);
            while ((line = file.ReadLine()) != null)
            {
                collectionOfPoints = line.Split(" -> ");
                firstPoint = collectionOfPoints[0].Split(",");
                lastPoint = collectionOfPoints[1].Split(",");
                x1 = Convert.ToInt32(firstPoint[0]);
                y1 = Convert.ToInt32(firstPoint[1]);
                x2 = Convert.ToInt32(lastPoint[0]);
                y2 = Convert.ToInt32(lastPoint[1]);

                if (x1 == x2)
                {
                    if (y1 > y2)
                    {
                        temp = y2;
                        y2 = y1;
                        y1 = temp;
                    }
                    for (int i = y1; i <= y2; i++)
                    {
                        board[x2, i] += 1;
                    }
                }
                else if (y1 == y2)
                {
                    if (x1 > x2)
                    {
                        temp = x2;
                        x2 = x1;
                        x1 = temp;
                    }
                    for (int i = x1; i <= x2; i++)
                    {
                        board[i, y2] += 1;
                    }
                }
                else
                    continue;
            }
            file.Close();

            int total = 0;
            int numRows = board.GetLength(0);
            int numCols = board.GetLength(1);

            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numCols; j++)
                {
                    if (board[i, j] > 1)
                        total++;
                }
            }

            return total;
        }

        public static int Part2_IntersectionOfAllLines()
        {
            string line = "";
            int[,] board = new int[1000, 1000];

            string[] collectionOfPoints, firstPoint, lastPoint;
            int x1, y1, x2, y2, temp;
            char directionOfYAxis, directionOfXAxis;

            StreamReader file = new StreamReader(path);
            while ((line = file.ReadLine()) != null)
            {
                collectionOfPoints = line.Split(" -> ");
                firstPoint = collectionOfPoints[0].Split(",");
                lastPoint = collectionOfPoints[1].Split(",");
                x1 = Convert.ToInt32(firstPoint[0]);
                y1 = Convert.ToInt32(firstPoint[1]);
                x2 = Convert.ToInt32(lastPoint[0]);
                y2 = Convert.ToInt32(lastPoint[1]);

                if (x1 == x2)
                {
                    if (y1 > y2)
                    {
                        temp = y2;
                        y2 = y1;
                        y1 = temp;
                    }
                    for (int i = y1; i <= y2; i++)
                    {
                        board[x2, i]++;
                    }
                }
                else if (y1 == y2)
                {
                    if (x1 > x2)
                    {
                        temp = x2;
                        x2 = x1;
                        x1 = temp;
                    }
                    for (int i = x1; i <= x2; i++)
                    {
                        board[i, y2]++;
                    }
                }
                else
                {
                    directionOfXAxis = x1 > x2 ? '-' : '+';
                    directionOfYAxis = y1 > y2 ? '-' : '+';

                    while (!(x1 == x2))
                    {
                        board[x1, y1]++;
                        if (directionOfXAxis == '+')
                            x1++;
                        else
                            x1--;

                        if (directionOfYAxis == '+')
                            y1++;
                        else
                            y1--;
                    }

                    board[x1, y1]++;
                }
            }
            file.Close();

            int total = 0;
            int numRows = board.GetLength(0);
            int numCols = board.GetLength(1);

            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numCols; j++)
                {
                    if (board[i, j] > 1)
                        total++;
                }
            }

            return total;
        }
    }
}

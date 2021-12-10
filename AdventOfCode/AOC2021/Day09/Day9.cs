using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AOC2021
{
    public class Day9
    {
        private static string path = Environment.CurrentDirectory + @"\\Day09\input.txt";

        private class Point
        {
            public int HorizontalValue { get; set; }
            public int VerticalValue { get; set; }
        }

        private static List<Point> lowPoints = new List<Point>();

        public static int Part1_SumOfRiskLevelsOfAllLowPoints()
        {

            int[,] heightMap = CreateHeightMap();
            int horizontalSize = heightMap.GetLength(0);
            int verticalSize = heightMap.GetLength(1);
            int sum = 0;

            for (int i = 0; i < horizontalSize; i++)
            {
                for (int j = 0; j < verticalSize; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        if (heightMap[i, j] < heightMap[i + 1, j]
                            & heightMap[i, j] < heightMap[i, j + 1])
                        {
                            sum += heightMap[i, j] + 1;
                            lowPoints.Add(new Point() { HorizontalValue = i, VerticalValue = j });
                        }
                    }
                    else if (i == 0 && j == verticalSize - 1)
                    {
                        if (heightMap[i, j] < heightMap[i + 1, j]
                            & heightMap[i, j] < heightMap[i, j - 1])
                        {
                            sum += heightMap[i, j] + 1;
                            lowPoints.Add(new Point() { HorizontalValue = i, VerticalValue = j });
                        }
                    }
                    else if (i == horizontalSize - 1 && j == 0)
                    {
                        if (heightMap[i, j] < heightMap[i - 1, j]
                            & heightMap[i, j] < heightMap[i, j + 1])
                        {
                            sum += heightMap[i, j] + 1;
                            lowPoints.Add(new Point() { HorizontalValue = i, VerticalValue = j });
                        }
                    }
                    else if (i == horizontalSize - 1 && j == verticalSize - 1)
                    {
                        if (heightMap[i, j] < heightMap[i - 1, j]
                            & heightMap[i, j] < heightMap[i, j - 1])
                        {
                            sum += heightMap[i, j] + 1;
                            lowPoints.Add(new Point() { HorizontalValue = i, VerticalValue = j });
                        }
                    }
                    else if (i == 0)
                    {
                        if (heightMap[i, j] < heightMap[i, j - 1]
                            & heightMap[i, j] < heightMap[i, j + 1]
                            & heightMap[i, j] < heightMap[i + 1, j])
                        {
                            sum += heightMap[i, j] + 1;
                            lowPoints.Add(new Point() { HorizontalValue = i, VerticalValue = j });
                        }
                    }
                    else if (j == 0)
                    {
                        if (heightMap[i, j] < heightMap[i - 1, j]
                            & heightMap[i, j] < heightMap[i + 1, j]
                            & heightMap[i, j] < heightMap[i, j + 1])
                        {
                            sum += heightMap[i, j] + 1;
                            lowPoints.Add(new Point() { HorizontalValue = i, VerticalValue = j });
                        }
                    }
                    else if (i == horizontalSize - 1)
                    {
                        if (heightMap[i, j] < heightMap[i, j - 1]
                            & heightMap[i, j] < heightMap[i, j + 1]
                            & heightMap[i, j] < heightMap[i - 1, j])
                        {
                            sum += heightMap[i, j] + 1;
                            lowPoints.Add(new Point() { HorizontalValue = i, VerticalValue = j });
                        }
                    }
                    else if (j == verticalSize - 1)
                    {
                        if (heightMap[i, j] < heightMap[i - 1, j]
                            & heightMap[i, j] < heightMap[i + 1, j]
                            & heightMap[i, j] < heightMap[i, j - 1])
                        {
                            sum += heightMap[i, j] + 1;
                            lowPoints.Add(new Point() { HorizontalValue = i, VerticalValue = j });
                        }
                    }
                    else
                    {
                        if (heightMap[i, j] < heightMap[i - 1, j]
                            & heightMap[i, j] < heightMap[i + 1, j]
                            & heightMap[i, j] < heightMap[i, j - 1]
                            & heightMap[i, j] < heightMap[i, j + 1])
                        {
                            sum += heightMap[i, j] + 1;
                            lowPoints.Add(new Point() { HorizontalValue = i, VerticalValue = j });
                        }
                    }
                }
            }

            return sum;
        }

        public static int Part2_MultiplicationOfThreeBiggestBasinSizes()
        {
            int[,] heightMap = CreateHeightMap();
            int horizontalSize = heightMap.GetLength(0);
            int verticalSize = heightMap.GetLength(1);
            List<int> basinSizeList = new List<int>();
            List<Point> basinPoints = new List<Point>();
            Point upPoint, downPoint, leftPoint, rightPoint;

            foreach (Point lowPoint in lowPoints)
            {
                basinPoints.Add(lowPoint);

                for (int i = 0; i < 4 * verticalSize * horizontalSize; i++)
                {
                    if (basinPoints.Count > i)
                    {
                        Point point = basinPoints.ElementAt(i);

                        upPoint = new Point()
                        {
                            HorizontalValue = point.HorizontalValue,
                            VerticalValue = point.VerticalValue - 1
                        };

                        if (upPoint.VerticalValue > -1
                            && heightMap[upPoint.HorizontalValue, upPoint.VerticalValue] != 9)
                        {
                            if (!basinPoints.Any(x => x.HorizontalValue == upPoint.HorizontalValue
                                 && x.VerticalValue == upPoint.VerticalValue))
                            {
                                basinPoints.Add(upPoint);
                            }
                        }

                        downPoint = new Point()
                        {
                            HorizontalValue = point.HorizontalValue,
                            VerticalValue = point.VerticalValue + 1
                        };

                        if (downPoint.VerticalValue < verticalSize
                            && heightMap[downPoint.HorizontalValue, downPoint.VerticalValue] != 9)
                        {
                            if (!basinPoints.Any(x => x.HorizontalValue == downPoint.HorizontalValue
                                 && x.VerticalValue == downPoint.VerticalValue))
                            {
                                basinPoints.Add(downPoint);
                            }

                        }

                        leftPoint = new Point()
                        {
                            HorizontalValue = point.HorizontalValue - 1,
                            VerticalValue = point.VerticalValue
                        };

                        if (leftPoint.HorizontalValue > -1
                            && heightMap[leftPoint.HorizontalValue, leftPoint.VerticalValue] != 9)
                        {
                            if (!basinPoints.Any(x => x.HorizontalValue == leftPoint.HorizontalValue
                                 && x.VerticalValue == leftPoint.VerticalValue))
                            {
                                basinPoints.Add(leftPoint);
                            }

                        }

                        rightPoint = new Point()
                        {
                            HorizontalValue = point.HorizontalValue + 1,
                            VerticalValue = point.VerticalValue
                        };

                        if (rightPoint.HorizontalValue < horizontalSize
                            && heightMap[rightPoint.HorizontalValue, rightPoint.VerticalValue] != 9)
                        {
                            if (!basinPoints.Any(x => x.HorizontalValue == rightPoint.HorizontalValue
                                 && x.VerticalValue == rightPoint.VerticalValue))
                            {
                                basinPoints.Add(rightPoint);
                            }

                        }
                    }
                    else
                    {
                        break;
                    }
                }

                basinPoints = basinPoints.Distinct().ToList();
                basinSizeList.Add(basinPoints.Count);
                basinPoints.Clear();
            }

            List<int> sortedBasinSizeList = basinSizeList.OrderByDescending(i => i).ToList();
            return sortedBasinSizeList.ElementAt(0) * sortedBasinSizeList.ElementAt(1) * sortedBasinSizeList.ElementAt(2);
        }

        private static int[,] CreateHeightMap()
        {
            StreamReader file = new StreamReader(path);
            string line = "";
            List<string> lineCollection = new List<string>();

            while ((line = file.ReadLine()) != null)
            {
                lineCollection.Add(line);
            }

            int horizontalSize = lineCollection.ElementAt(0).Length;
            int verticalSize = lineCollection.Count;

            int[,] heightMap = new int[horizontalSize, verticalSize];

            for (int i = 0; i < horizontalSize; i++)
            {
                for (int j = 0; j < verticalSize; j++)
                {
                    heightMap[i, j] = Convert.ToInt32((lineCollection.ElementAt(j)[i]).ToString());
                }
            }

            return heightMap;
        }
    }
}

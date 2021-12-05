using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AOC2021
{
    public class Day2
    {
        private static string path = Environment.CurrentDirectory + @"\\Day2\input.txt";
        public static int Part1_CalculateDepthAndHorizontalPosition()
        {
            string line = "";
            string[] move;
            int step = 0;
            int horizontalValue = 0, verticalValue = 0;

            StreamReader file = new StreamReader(path);
            while ((line = file.ReadLine()) != null)
            {
                move = line.Split(" ");
                step = Convert.ToInt32(move[1]);
                if (move[0] == "forward")
                {
                    horizontalValue = horizontalValue + step;
                }
                else if (move[0] == "down")
                {
                    verticalValue = verticalValue + step;
                }
                else if (move[0] == "up")
                {
                    verticalValue = verticalValue - step;
                }
                else
                {
                    //nothing
                }
            }
            file.Close();

            return horizontalValue * verticalValue;
        }

        public static int Part2_CalculateDepthAndHorizontalPositionWithAim()
        {
            string line = "";
            string[] move;
            int step = 0;
            int horizontalValue = 0, verticalValue = 0, aim = 0;

            StreamReader file = new StreamReader(path);
            while ((line = file.ReadLine()) != null)
            {
                move = line.Split(" ");
                step = Convert.ToInt32(move[1]);
                if (move[0] == "forward")
                {
                    horizontalValue = horizontalValue + step;
                    verticalValue = verticalValue + (aim * step);
                }
                else if (move[0] == "down")
                {
                    aim = aim + step;
                }
                else if (move[0] == "up")
                {
                    aim = aim - step;
                }
                else
                {
                    //nothing
                }
            }
            file.Close();

            return horizontalValue * verticalValue;
        }
    }
}

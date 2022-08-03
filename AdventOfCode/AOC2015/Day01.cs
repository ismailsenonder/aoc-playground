using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2015
{
    public static class Day01
    {
        private static readonly string path = Environment.CurrentDirectory + @"\\Inputs\Day01.txt";
        public static int Part1()
        {
            StreamReader file = new(path);
            string line = file.ReadLine();
            return line.Count(x => x == '(') - line.Count(x => x == ')');
        }

        public static int Part2()
        {
            StreamReader file = new StreamReader(path);
            string line = file.ReadLine();
            int position = 0;
            for (int i = 0; i < line.Length; i++)
            {
                position = line[i] == '(' ? position + 1 : position - 1;
                if (position == -1)
                    return i + 1;
            }
            return 0;
        }
    }
}

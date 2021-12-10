using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AOC2021
{
    public class Day10
    {
        private static string path = Environment.CurrentDirectory + @"\\Day10\input.txt";

        public static int Part1_CalculateSyntaxErrorScore()
        {
            string line = "";
            string chunk1 = "()", chunk2 = "[]", chunk3 = "{}", chunk4 = "<>";
            int syntaxErrorScore = 0;

            StreamReader file = new StreamReader(path);
            while ((line = file.ReadLine()) != null)
            {
                while (line.Contains(chunk1) || line.Contains(chunk2)
                    || line.Contains(chunk3) || line.Contains(chunk4))
                {
                    line = line.Replace(chunk1, "").Replace(chunk2, "")
                        .Replace(chunk3, "").Replace(chunk4, "");
                }

                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] == ')')
                    {
                        syntaxErrorScore += 3;
                        break;
                    }
                    if (line[i] == ']')
                    {
                        syntaxErrorScore += 57;
                        break;
                    }
                    if (line[i] == '}')
                    {
                        syntaxErrorScore += 1197;
                        break;
                    }
                    if (line[i] == '>')
                    {
                        syntaxErrorScore += 25137;
                        break;
                    }
                }
            }

            return syntaxErrorScore;
        }

        public static long Part2_TheMiddleTotalScore()
        {
            string line = "";
            string chunk1 = "()", chunk2 = "[]", chunk3 = "{}", chunk4 = "<>";
            bool isBrokenChunk = false;
            List<string> inCompleteChunks = new List<string>();

            StreamReader file = new StreamReader(path);
            while ((line = file.ReadLine()) != null)
            {
                while (line.Contains(chunk1) || line.Contains(chunk2)
                    || line.Contains(chunk3) || line.Contains(chunk4))
                {
                    line = line.Replace(chunk1, "").Replace(chunk2, "")
                        .Replace(chunk3, "").Replace(chunk4, "");
                }

                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] == ')' || line[i] == ']'
                        || line[i] == '}' || line[i] == '>')
                    {
                        isBrokenChunk = true;
                        break;
                    }
                }

                if (!isBrokenChunk)
                {
                    inCompleteChunks.Add(line);
                }

                isBrokenChunk = false;

            }

            List<long> totalScores = new List<long>();
            long totalScore = 0;
            foreach (string incompleteChunk in inCompleteChunks)
            {
                for (int i = incompleteChunk.Length - 1; i >= 0; i--)
                {
                    totalScore = totalScore * 5;
                    if (incompleteChunk[i] == '(')
                        totalScore += 1;
                    else if (incompleteChunk[i] == '[')
                        totalScore += 2;
                    else if (incompleteChunk[i] == '{')
                        totalScore += 3;
                    else if (incompleteChunk[i] == '<')
                        totalScore += 4;
                    else
                        continue;
                }

                totalScores.Add(totalScore);
                totalScore = 0;
            }

            totalScores.Sort();
            int index = totalScores.Count / 2;
            return totalScores.ElementAt(index);

        }
    }
}

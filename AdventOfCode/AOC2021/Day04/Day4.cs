using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AOC2021
{
    public class Day4
    {
        private static string path = Environment.CurrentDirectory + @"\\Day04\input.txt";
        public static int Part1_ScoreOfWinningBoard()
        {
            string line;
            List<int[,]> bingoCards = new List<int[,]>();
            StreamReader file = new StreamReader(path);

            string selectedNumbers = file.ReadLine();

            int matrixLineNumber = 0;
            int bingoCardCount = 0;

            while ((line = file.ReadLine()) != null)
            {
                if (matrixLineNumber > 5)
                    matrixLineNumber = 0;

                if (matrixLineNumber == 0)
                {
                    bingoCards.Add(new int[5, 5] {
                    {0,0,0,0,0 },{0,0,0,0,0 },{0,0,0,0,0 },{0,0,0,0,0 },{0,0,0,0,0 } });
                    bingoCardCount++;
                    matrixLineNumber++;
                    continue;
                }

                int[,] currentBingoCard = bingoCards.ElementAt(bingoCardCount - 1);
                line = line.Trim();
                string[] currentNumbers = Regex.Split(line, @"\s+");


                for (int i = 0; i < 5; i++)
                {
                    currentBingoCard[matrixLineNumber - 1, i] = Convert.ToInt32(currentNumbers[i].ToString());
                }

                matrixLineNumber++;
            }
            file.Close();

            //Bingo cards collection completed


            int[,] winnerBingoCard = null;
            int totalOfLine = 0;
            int totalOfColumn = 0;
            int calledNumber = 0;
            bool breakOutOf = false;

            foreach (string s in selectedNumbers.Split(","))
            {
                calledNumber = Convert.ToInt32(s);
                foreach (int[,] bingoCard in bingoCards)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            if (bingoCard[i, j] == calledNumber)
                            {
                                bingoCard[i, j] = -1;
                                totalOfLine = bingoCard[i, 0] + bingoCard[i, 1] + bingoCard[i, 2] + bingoCard[i, 3] + bingoCard[i, 4];
                                totalOfColumn = bingoCard[0, j] + bingoCard[1, j] + bingoCard[2, j] + bingoCard[3, j] + bingoCard[4, j];
                                breakOutOf = true;
                                break;
                            }
                        }
                        if (breakOutOf)
                        {
                            breakOutOf = false;
                            break;
                        }
                    }

                    if (totalOfLine == -5 || totalOfColumn == -5)
                        winnerBingoCard = bingoCard;

                    if (winnerBingoCard != null)
                        break;
                }

                if (winnerBingoCard != null)
                    break;
            }

            int total = 0;
            for (int m = 0; m < 5; m++)
            {
                for (int n = 0; n < 5; n++)
                {
                    if (winnerBingoCard[m, n] != -1)
                    {
                        total += winnerBingoCard[m, n];
                    }
                }
            }


            return total * calledNumber;
        }

        public static int Part2_ScoreOfLosingBoard()
        {
            string line;

            List<int[,]> bingoCards = new List<int[,]>();
            StreamReader file = new StreamReader(path);

            string selectedNumbers = file.ReadLine();

            int matrixLineNumber = 0;
            int bingoCardCount = 0;

            while ((line = file.ReadLine()) != null)
            {
                if (matrixLineNumber > 5)
                    matrixLineNumber = 0;

                if (matrixLineNumber == 0)
                {
                    bingoCards.Add(new int[5, 5] {
                    {0,0,0,0,0 },{0,0,0,0,0 },{0,0,0,0,0 },{0,0,0,0,0 },{0,0,0,0,0 } });
                    bingoCardCount++;
                    matrixLineNumber++;
                    continue;
                }

                int[,] currentBingoCard = bingoCards.ElementAt(bingoCardCount - 1);
                line = line.Trim();
                string[] currentNumbers = Regex.Split(line, @"\s+");


                for (int i = 0; i < 5; i++)
                {
                    currentBingoCard[matrixLineNumber - 1, i] = Convert.ToInt32(currentNumbers[i].ToString());
                }

                matrixLineNumber++;
            }
            file.Close();

            //Bingo cards collection completed
            int[,] winnerBingoCard = null;
            int[,] loserBingoCard = null;
            int totalOfLine = 0;
            int totalOfColumn = 0;
            int calledNumber = 0;
            bool breakOutOf = false;
            List<int[,]> winnerCards = new List<int[,]>();

            foreach (string s in selectedNumbers.Split(","))
            {
                if (bingoCards.Count == 0)
                    break;

                calledNumber = Convert.ToInt32(s);

                foreach (int[,] bingoCard in bingoCards)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            if (bingoCard[i, j] == calledNumber)
                            {
                                bingoCard[i, j] = -1;
                                totalOfLine = bingoCard[i, 0] + bingoCard[i, 1] + bingoCard[i, 2] + bingoCard[i, 3] + bingoCard[i, 4];
                                totalOfColumn = bingoCard[0, j] + bingoCard[1, j] + bingoCard[2, j] + bingoCard[3, j] + bingoCard[4, j];
                                if (totalOfLine == -5 || totalOfColumn == -5)
                                {
                                    winnerCards.Add(bingoCard);
                                }
                                breakOutOf = true;
                                break;
                            }
                        }
                        if (breakOutOf)
                        {
                            breakOutOf = false;
                            break;
                        }
                    }
                }

                if (winnerCards.Count > 0)
                {
                    foreach (var card in winnerCards)
                    {
                        bingoCards.Remove(card);
                        if (bingoCards.Count == 0)
                        {
                            loserBingoCard = card;
                        }
                    }

                    winnerCards.Clear();
                }
            }

            int total = 0;
            for (int m = 0; m < 5; m++)
            {
                for (int n = 0; n < 5; n++)
                {
                    if (loserBingoCard[m, n] != -1)
                    {
                        total += loserBingoCard[m, n];
                    }
                }
            }


            return total * calledNumber;
        }
    }
}

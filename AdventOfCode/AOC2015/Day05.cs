namespace AOC2015
{
    public class Day05
    {
        private static readonly string path = Environment.CurrentDirectory + @"\\Inputs\Day05.txt";
        private static readonly List<char> vowels = new List<char>() { 'a', 'e', 'i', 'o', 'u' };
        public static int Part1()
        {
            StreamReader file = new(path);
            string line;
            int niceStringCount = 0;
            int vowelCount = 0;
            bool includesTwinSubstring = false;

            while ((line = file.ReadLine()) != null)
            {
                if (line.IndexOf("ab") > -1)
                    continue;
                if (line.IndexOf("cd") > -1)
                    continue;
                if (line.IndexOf("pq") > -1)
                    continue;
                if (line.IndexOf("xy") > -1)
                    continue;

                for (int i = 0; i < line.Length - 1; i++)
                {
                    if (vowels.Contains(line[i]))
                        vowelCount++;

                    if (line[i] == line[i + 1])
                    {
                        includesTwinSubstring = true;
                    }
                }

                if (vowels.Contains(line[line.Length - 1]))
                    vowelCount++;

                if (vowelCount < 3)
                {
                    vowelCount = 0;
                    includesTwinSubstring = false;
                    continue;
                }

                if (!includesTwinSubstring)
                {
                    vowelCount = 0;
                    continue;
                }

                niceStringCount++;
                vowelCount = 0;
                includesTwinSubstring = false;
            }

            return niceStringCount;
        }

        public static int Part2()
        {
            StreamReader file = new(path);
            string line;
            int niceStringCount = 0;
            bool includesABA = false;
            bool includesAAAA = false;

            while ((line = file.ReadLine()) != null)
            {
                for (int i = 0; i < line.Length - 2; i++)
                {
                    if (line[i] == line[i + 2])
                    {
                        includesABA = true;
                    }

                    if (line.Substring(i + 2)
                        .Contains(line[i].ToString() + line[i + 1].ToString()))
                    {
                        includesAAAA = true;
                    }
                }

                if (includesABA && includesAAAA)
                {
                    niceStringCount++;
                }

                includesABA = false;
                includesAAAA = false;
            }


            return niceStringCount;
        }
    }
}

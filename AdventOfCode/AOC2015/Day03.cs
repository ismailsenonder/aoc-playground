namespace AOC2015
{
    public class Day03
    {
        private static readonly string path = Environment.CurrentDirectory + @"\\Inputs\Day03.txt";

        public class Position
        {
            public int Vertical { get; set; }
            public int Horizontal { get; set; }
        }

        public static int Part1()
        {
            StreamReader file = new(path);
            string line = file.ReadLine();
            file.Close();

            Position prevPos = new Position() { Horizontal = 0, Vertical = 0 };
            List<Position> houseLocations = new()
            {
                new Position() { Horizontal = 0, Vertical = 0 } //starting point
            };

            foreach (char c in line)
            {
                Position p = new();
                if (c == '<')
                {
                    p.Vertical = prevPos.Vertical;
                    p.Horizontal = prevPos.Horizontal - 1;
                }
                if (c == '>')
                {
                    p.Vertical = prevPos.Vertical;
                    p.Horizontal = prevPos.Horizontal + 1;
                }
                if (c == 'v')
                {
                    p.Vertical = prevPos.Vertical - 1;
                    p.Horizontal = prevPos.Horizontal;
                }
                if (c == '^')
                {
                    p.Vertical = prevPos.Vertical + 1;
                    p.Horizontal = prevPos.Horizontal;
                }
                if (!houseLocations.Any(x => x.Horizontal == p.Horizontal 
                    && x.Vertical == p.Vertical))
                {
                    houseLocations.Add(p);
                }
                prevPos = p;
            }

            return houseLocations.Count;
        }

        public static int Part2()
        {
            StreamReader file = new(path);
            string line = file.ReadLine();
            file.Close();

            Position santaLocation = new Position() { Horizontal = 0, Vertical = 0 };
            Position roboSantaLocation = new Position() { Horizontal = 0, Vertical = 0 };
            string move = "santa";
            List<Position> houseLocations = new()
            {
                new Position() { Horizontal = 0, Vertical = 0 } //starting point
            };

            foreach (char c in line)
            {
                Position p = new();

                if(move == "santa")
                {
                    if (c == '<')
                    {
                        p.Vertical = santaLocation.Vertical;
                        p.Horizontal = santaLocation.Horizontal - 1;
                    }
                    if (c == '>')
                    {
                        p.Vertical = santaLocation.Vertical;
                        p.Horizontal = santaLocation.Horizontal + 1;
                    }
                    if (c == 'v')
                    {
                        p.Vertical = santaLocation.Vertical - 1;
                        p.Horizontal = santaLocation.Horizontal;
                    }
                    if (c == '^')
                    {
                        p.Vertical = santaLocation.Vertical + 1;
                        p.Horizontal = santaLocation.Horizontal;
                    }
                    if (!houseLocations.Any(x => x.Horizontal == p.Horizontal
                        && x.Vertical == p.Vertical))
                    {
                        houseLocations.Add(p);
                    }
                    santaLocation = p;
                    move = "robo";
                    continue;
                }

                if(move=="robo")
                {
                    if (c == '<')
                    {
                        p.Vertical = roboSantaLocation.Vertical;
                        p.Horizontal = roboSantaLocation.Horizontal - 1;
                    }
                    if (c == '>')
                    {
                        p.Vertical = roboSantaLocation.Vertical;
                        p.Horizontal = roboSantaLocation.Horizontal + 1;
                    }
                    if (c == 'v')
                    {
                        p.Vertical = roboSantaLocation.Vertical - 1;
                        p.Horizontal = roboSantaLocation.Horizontal;
                    }
                    if (c == '^')
                    {
                        p.Vertical = roboSantaLocation.Vertical + 1;
                        p.Horizontal = roboSantaLocation.Horizontal;
                    }
                    if (!houseLocations.Any(x => x.Horizontal == p.Horizontal
                        && x.Vertical == p.Vertical))
                    {
                        houseLocations.Add(p);
                    }
                    roboSantaLocation = p;
                    move = "santa";
                    continue;
                }
            }

            return houseLocations.Count;
        }
    }
}

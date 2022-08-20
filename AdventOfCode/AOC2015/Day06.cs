namespace AOC2015
{
    public class Day06
    {
        private static readonly string path = Environment.CurrentDirectory + @"\\Inputs\Day06.txt";

        private enum Instruction
        {
            Toggle,
            TurnOff,
            TurnOn,
            None
        }

        private static (int x1, int y1, int x2, int y2, Instruction instruction)
            ConvertInstructionsToLocations(string instructionString)
        {
            Instruction instruction = Instruction.None;
            instructionString = instructionString.Replace("through ", "");
            if (instructionString.StartsWith("turn on"))
            {
                instruction = Instruction.TurnOn;
                instructionString = instructionString.Replace("turn on ", "");
            }
            else if (instructionString.StartsWith("turn off"))
            {
                instruction = Instruction.TurnOff;
                instructionString = instructionString.Replace("turn off ", "");
            }
            else if (instructionString.StartsWith("toggle"))
            {
                instruction = Instruction.Toggle;
                instructionString = instructionString.Replace("toggle ", "");
            }
            else
            {
                throw new ArgumentException("Not a valid instruction.");
            }
            instructionString = instructionString.Replace(",", " ");

            string[] points = instructionString.Split(' ');

            return (Convert.ToInt32(points[0]),
                Convert.ToInt32(points[1]),
                Convert.ToInt32(points[2]),
                Convert.ToInt32(points[03]),
                instruction);
        }

        public static int Part1()
        {
            StreamReader file = new(path);
            string line;
            int[,] lights = new int[1000, 1000];
            int howManyLit = 0;

            while ((line = file.ReadLine()) != null)
            {
                var whatToDo = ConvertInstructionsToLocations(line);
                for (int i = whatToDo.x1; i <= whatToDo.x2; i++)
                {
                    for (int j = whatToDo.y1; j <= whatToDo.y2; j++)
                    {
                        switch (whatToDo.instruction)
                        {
                            case Instruction.TurnOff:
                                if (lights[i, j] == 1)
                                {
                                    howManyLit--;
                                }
                                lights[i, j] = 0;
                                break;
                            case Instruction.TurnOn:
                                if (lights[i, j] == 0)
                                {
                                    howManyLit++;
                                }
                                lights[i, j] = 1;
                                break;
                            case Instruction.Toggle:
                                if (lights[i, j] == 0)
                                {
                                    lights[i, j] = 1;
                                    howManyLit++;
                                }
                                else if (lights[i, j] == 1)
                                {
                                    lights[i, j] = 0;
                                    howManyLit--;
                                }
                                else
                                {
                                    lights[i, j] = 0;
                                }
                                break;
                            default:
                                break;
                        }
                    }
                }
            }

            return howManyLit;
        }

        public static int Part2()
        {
            StreamReader file = new(path);
            string line;
            int[,] lights = new int[1000, 1000];
            int totalBrightness = 0;

            while ((line = file.ReadLine()) != null)
            {
                var whatToDo = ConvertInstructionsToLocations(line);
                for (int i = whatToDo.x1; i <= whatToDo.x2; i++)
                {
                    for (int j = whatToDo.y1; j <= whatToDo.y2; j++)
                    {
                        switch (whatToDo.instruction)
                        {
                            case Instruction.TurnOff:
                                if (lights[i, j] != 0)
                                {
                                    lights[i, j]--;
                                    totalBrightness--;
                                }
                                break;
                            case Instruction.TurnOn:
                                lights[i, j]++;
                                totalBrightness++;
                                break;
                            case Instruction.Toggle:
                                lights[i, j] = lights[i, j] + 2;
                                totalBrightness = totalBrightness + 2;
                                break;
                            default:
                                break;
                        }
                    }
                }
            }

            return totalBrightness;
        }
    }
}

namespace AOC2015
{

    public class Day02
    {
        private static readonly string path = Environment.CurrentDirectory + @"\\Inputs\Day02.txt";

        public static (int total, int ribbon) Part1()
        {
            StreamReader file = new(path);
            string line;
            string[] dimensions;
            int h, w, l, temp;
            int total = 0, ribbon = 0;

            while ((line = file.ReadLine()) != null)
            {
                dimensions = line.Split('x');

                h = int.Parse(dimensions[0]);
                w = int.Parse(dimensions[1]);
                l = int.Parse(dimensions[2]);

                if (w < h)
                {
                    temp = h;
                    h = w;
                    w = temp;
                }

                if(l < w)
                {
                    temp = w;
                    w = l;
                    l = temp;
                    
                    if(w < h)
                    {
                        temp = h;
                        h = w;
                        w = temp;
                    }
                }

                total += (3 * h * w) + (2 * h * l) + (2 * w * l);
                ribbon += (2 * h) + (2 * w) + (h * w * l);
            }
            file.Close();

            return (total, ribbon);
        }
    }
}

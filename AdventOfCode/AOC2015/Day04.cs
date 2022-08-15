namespace AOC2015
{
    public class Day04
    {
        private static readonly string path = Environment.CurrentDirectory + @"\\Inputs\Day04.txt";
        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                return Convert.ToHexString(hashBytes); // .NET 5 +

                // Convert the byte array to hexadecimal string prior to .NET 5
                // StringBuilder sb = new System.Text.StringBuilder();
                // for (int i = 0; i < hashBytes.Length; i++)
                // {
                //     sb.Append(hashBytes[i].ToString("X2"));
                // }
                // return sb.ToString();
            }
        }

        public static string Part1(string privateKey, int zeroesToCheck)
        {
            string zeroesString = "";
            for (int i = 0; i < zeroesToCheck; i++)
            {
                zeroesString += "0";
            }

            int numberToAdd = 1;
            string strToCheck, adventCoin;
            while (true)
            {
                strToCheck = privateKey + numberToAdd.ToString();
                adventCoin = CreateMD5(strToCheck);
                if (adventCoin[..zeroesToCheck] == zeroesString)
                {
                    return strToCheck;
                }
                else
                {
                    numberToAdd++;
                }
            }
        }
    }
}

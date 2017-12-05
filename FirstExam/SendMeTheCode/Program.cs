using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace SendMeTheCode
{
    class Program
    {
        private static char[] alphabet = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        static void Main(string[] args)
        {
            BigInteger N = BigInteger.Parse(Console.ReadLine());
            if(N < 0)
            {
                N *= (-1);
            }
            string nAsString = N.ToString();
            int currentDigit = 0;
            BigInteger currentSum = 0;
            BigInteger result = 0;

            for (int i = nAsString.Length - 1, secI = 1; i >= 0; i--, secI++)
            {
                currentDigit = Int32.Parse(nAsString[i].ToString());
                if (secI % 2 == 0)
                {
                    currentSum = (BigInteger)Math.Pow(currentDigit, 2) * secI;
                }
                else
                {
                    currentSum = currentDigit * (BigInteger)Math.Pow((double)secI, 2);
                }
                result = result + currentSum;
            }

            if (Int32.Parse(result.ToString()[result.ToString().Length - 1].ToString()) == 0)
            {
                Console.WriteLine(result);
                Console.WriteLine("Big Vik wins again!");
                return;
            }
            else
            {
                int messageLength = (int)((BigInteger)result % 10);
                int startLetter = (int)((BigInteger)result % 26);

                StringBuilder finalMessage = new StringBuilder();

                for (int i = 0; i < messageLength; i++)
                {
                    while (startLetter >= alphabet.Length)
                    {
                        startLetter = startLetter - alphabet.Length;
                    }
                    finalMessage.Append(alphabet[startLetter]);
                    startLetter++;
                }
                Console.WriteLine(result);
                Console.WriteLine(finalMessage.ToString());
                return;
            }
        }
    }
}
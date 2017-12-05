using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Move
{
    class Program
    {
        static void Main(string[] args)
        {
            int currentIndex = Int32.Parse(Console.ReadLine());
            int[] array = Console.ReadLine().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(Int32.Parse).ToArray();

            string command = Console.ReadLine();
            BigInteger forwardSum = 0;
            BigInteger backwardsSum = 0;
            while (!command.Equals("exit"))
            {
                string[] splittedCommand = command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                int movesCount = Int32.Parse(splittedCommand[0]);
                string direction = splittedCommand[1];
                int step = Int32.Parse(splittedCommand[2]);

                for (int i = 0; i < movesCount && direction == "forward"; i++)
                {
                    currentIndex += step;
                    while (currentIndex >= array.Length)
                    {
                        currentIndex = currentIndex - array.Length;
                    }
                    forwardSum += array[currentIndex];
                }

                for (int i = 0; i < movesCount && direction == "backwards"; i++)
                {
                    currentIndex -= step;
                    while (currentIndex < 0)
                    {
                        currentIndex = array.Length + currentIndex;
                    }
                    backwardsSum += array[currentIndex];
                }

                command = Console.ReadLine();
            }

            Console.WriteLine("Forward: {0}\nBackwards: {1}", forwardSum, backwardsSum);
        }
    }
}
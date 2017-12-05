using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShips
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixesSizes = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(Int32.Parse).ToArray();
            int[,] firstMatrix = new int[matrixesSizes[0], matrixesSizes[1]];
            int[,] secondMatrix = new int[matrixesSizes[0], matrixesSizes[1]];

            int[] currentMatrixRowValues;
            for (int firstMatrixRow = 0; firstMatrixRow < matrixesSizes[0]; firstMatrixRow++)
            {
                currentMatrixRowValues = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(Int32.Parse).ToArray();
                for (int firstMatrixCol = 0; firstMatrixCol < firstMatrix.GetLength(1); firstMatrixCol++)
                {
                    firstMatrix[firstMatrixRow, firstMatrixCol] = currentMatrixRowValues[firstMatrixCol];
                }
            }

            for (int secondMatrixRow = matrixesSizes[0] - 1; secondMatrixRow >= 0; secondMatrixRow--)
            {
                currentMatrixRowValues = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(Int32.Parse).ToArray();
                for (int secondMatrixCol = 0; secondMatrixCol < secondMatrix.GetLength(1); secondMatrixCol++)
                {
                    secondMatrix[secondMatrixRow, secondMatrixCol] = currentMatrixRowValues[secondMatrixCol];
                }
            }

            string command = Console.ReadLine();
            string[] splittedCommand;
            while(!command.Equals("END"))
            {
                splittedCommand = command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                string currentPlayer = splittedCommand[0];
                int targetPlayerRow = Int32.Parse(splittedCommand[1]);
                int targetPlayerCol = Int32.Parse(splittedCommand[2]);

                if(currentPlayer.Equals("P1"))
                {
                    if (secondMatrix[targetPlayerRow, targetPlayerCol] == 0)
                    {
                        Console.WriteLine("Missed");
                        secondMatrix[targetPlayerRow, targetPlayerCol] = -1;
                    }
                    else if (secondMatrix[targetPlayerRow, targetPlayerCol] == -1)
                    {
                        Console.WriteLine("Try again!");
                    }
                    else if (secondMatrix[targetPlayerRow, targetPlayerCol] == 1)
                    {
                        Console.WriteLine("Booom");
                        secondMatrix[targetPlayerRow, targetPlayerCol] = -1;
                    }
                }
                else
                {
                    if (firstMatrix[targetPlayerRow, targetPlayerCol] == 0)
                    {
                        Console.WriteLine("Missed");
                        firstMatrix[targetPlayerRow, targetPlayerCol] = -1;
                    }
                    else if (firstMatrix[targetPlayerRow, targetPlayerCol] == -1)
                    {
                        Console.WriteLine("Try again!");
                    }
                    else if (firstMatrix[targetPlayerRow, targetPlayerCol] == 1)
                    {
                        Console.WriteLine("Booom");
                        firstMatrix[targetPlayerRow, targetPlayerCol] = -1;
                    }
                }

                command = Console.ReadLine();
            }

            int firstPlayerShipsLeft = 0;
            int secondPlayerShipsLeft = 0;

            for (int row = 0; row < matrixesSizes[0]; row++)
            {
                for (int col = 0; col < matrixesSizes[1]; col++)
                {
                    if(firstMatrix[row,col]==1)
                    {
                        firstPlayerShipsLeft++;
                    }
                }
            }

            for (int row = 0; row < matrixesSizes[0]; row++)
            {
                for (int col = 0; col < matrixesSizes[1]; col++)
                {
                    if (secondMatrix[row, col] == 1)
                    {
                        secondPlayerShipsLeft++;
                    }
                }
            }

            Console.WriteLine("{0}:{1}", firstPlayerShipsLeft, secondPlayerShipsLeft);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expressions
{
    class Program
    {
        private static string possibleDigitsAsString;
        private static string possibleOperatorsAsString = "+*-";
        private static int searchedNumber;
        private static int finalCountOfPossibleExpressions = 0;
        private static int[] operatorsIndexes = new int[3];

        static void Main(string[] args)
        {
            possibleDigitsAsString = Console.ReadLine();
            searchedNumber = Int32.Parse(Console.ReadLine());


            Recursion(0, new StringBuilder(), new List<string>());
            Console.WriteLine(finalCountOfPossibleExpressions);
        }

        private static void Recursion(int currentPosition, StringBuilder currentNumbers, List<string> currentNumbersAsList)
        {
            for (int usedDigits = 1; usedDigits <= possibleDigitsAsString.Length; usedDigits++)
            {
                if (currentPosition + usedDigits > possibleDigitsAsString.Length)
                {
                    if (currentPosition == possibleDigitsAsString.Length)
                    {
                        operatorsIndexes = new int[currentNumbersAsList.Count - 1];
                        if (!currentNumbersAsList.Any(elem => (elem.Length > 1 && elem.StartsWith("0"))))
                        {
                            SecondRecursion(0, currentNumbersAsList);
                        }
                    }

                    if (currentNumbers.Length != 0)
                    {
                        int tempValue = currentPosition >= currentNumbers.Length ? currentNumbers.Length - 1 : currentPosition;
                        string itemForRemoving = currentNumbers.ToString().Substring(tempValue, currentNumbers.Length - tempValue);
                        currentNumbers = currentNumbers.Remove(tempValue, currentNumbers.Length - tempValue);
                        currentNumbersAsList.RemoveAt(currentNumbersAsList.Count - 1);
                    }
                    return;
                }

                currentNumbers.Append(possibleDigitsAsString.Substring(currentPosition, usedDigits));
                currentNumbersAsList.Add(possibleDigitsAsString.Substring(currentPosition, usedDigits));

                Recursion(currentPosition + usedDigits, currentNumbers, currentNumbersAsList);
            }
        }

        private static void SecondRecursion(int currentPosition, List<string> currentNumbersAsList)
        {
            if (currentPosition == operatorsIndexes.Length)
            {
                int currentResult = 0;

                if (operatorsIndexes.Any(oper => oper == 1))
                {
                    List<int> operatorsIndexesAsList = operatorsIndexes.ToList();
                    List<string> copyOfCurrentNumbersAsList = currentNumbersAsList.ToList();


                    for (int i = 0; i < operatorsIndexesAsList.Count; i++)
                    {
                        int currentOperatorIndex = operatorsIndexesAsList[i];
                        if (currentOperatorIndex == 1)
                        {
                            currentResult = Int32.Parse(copyOfCurrentNumbersAsList[i]) * Int32.Parse(copyOfCurrentNumbersAsList[i + 1]);
                            operatorsIndexesAsList.RemoveAt(i);
                            copyOfCurrentNumbersAsList.RemoveAt(i);
                            copyOfCurrentNumbersAsList.RemoveAt(i);
                            copyOfCurrentNumbersAsList.Insert(i, currentResult.ToString());
                            i--;
                        }
                    }

                    currentResult = Int32.Parse(copyOfCurrentNumbersAsList[0]);
                    for (int i = 1, secI = 0; i < copyOfCurrentNumbersAsList.Count; i++, secI++)
                    {
                        switch (possibleOperatorsAsString[operatorsIndexesAsList[secI]])
                        {
                            case '+':
                                currentResult += Int32.Parse(copyOfCurrentNumbersAsList[i].ToString());
                                break;
                            case '-':
                                currentResult -= Int32.Parse(copyOfCurrentNumbersAsList[i].ToString());
                                break;
                            default:
                                break;
                        }
                    }
                }
                else
                {
                    currentResult = Int32.Parse(currentNumbersAsList[0]);
                    for (int i = 1, secI = 0; i < currentNumbersAsList.Count; i++, secI++)
                    {
                        switch (possibleOperatorsAsString[operatorsIndexes[secI]])
                        {
                            case '+':
                                currentResult += Int32.Parse(currentNumbersAsList[i].ToString());
                                break;
                            case '*':
                                currentResult *= Int32.Parse(currentNumbersAsList[i].ToString());
                                break;
                            case '-':
                                currentResult -= Int32.Parse(currentNumbersAsList[i].ToString());
                                break;
                            default:
                                break;
                        }
                    }
                }

                if (currentResult == searchedNumber)
                {
                    finalCountOfPossibleExpressions++;
                }
                return;
            }

            for (int i = 0; i < possibleOperatorsAsString.Length; i++)
            {
                operatorsIndexes[currentPosition] = i;
                SecondRecursion(currentPosition + 1, currentNumbersAsList);
            }
        }
    }
}
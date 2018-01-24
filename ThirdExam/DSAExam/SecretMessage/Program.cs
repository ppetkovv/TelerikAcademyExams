using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (input.Contains('{') && input.Contains('}'))
            {
                int indexOfLastOpenedCurlyBracket = input.LastIndexOf('{');
                int indexOfFirstClosedCurlyBracket = indexOfLastOpenedCurlyBracket;

                while (!input[indexOfFirstClosedCurlyBracket].Equals('}'))
                {
                    indexOfFirstClosedCurlyBracket++;
                }

                int startIndexOfCurrentSubstring = indexOfLastOpenedCurlyBracket;
                string currentSubstringReatTimes = string.Empty;

                for (int i = startIndexOfCurrentSubstring - 1; i >= 0; i--)
                {
                    if (Char.IsDigit(input[i]))
                    {
                        startIndexOfCurrentSubstring--;
                        currentSubstringReatTimes += input[i];
                    }
                    else
                    {
                        break;
                    }
                }

                string currentSubstringForReplacingOld = input.Substring(startIndexOfCurrentSubstring, indexOfFirstClosedCurlyBracket - startIndexOfCurrentSubstring + 1);
                string currentMessage = input.Substring(indexOfLastOpenedCurlyBracket + 1, indexOfFirstClosedCurlyBracket - (indexOfLastOpenedCurlyBracket + 1));
                int repeatTimes = Int32.Parse(new string(currentSubstringReatTimes.ToCharArray().Reverse().ToArray()));
                string currentSubstringForReplacingNew = string.Join("", Enumerable.Repeat(currentMessage, repeatTimes));
                input = input.Replace(currentSubstringForReplacingOld, currentSubstringForReplacingNew);
            }

            Console.WriteLine(input);
        }
    }
}
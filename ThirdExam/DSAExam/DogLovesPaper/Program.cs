using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogLovesPaper
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = Int32.Parse(Console.ReadLine());

            Dictionary<int, List<int>> parents = new Dictionary<int, List<int>>();
            SortedDictionary<int, int> children = new SortedDictionary<int, int>();
            Dictionary<int, bool> visited = new Dictionary<int, bool>();

            string[] currentInputLine;
            int priorityNumber = 0;
            int secondaryNumber = 0;


            for (int i = 0; i < N; i++)
            {
                currentInputLine = Console.ReadLine().Split();
                if (currentInputLine[2].Equals("after"))
                {
                    priorityNumber = Int32.Parse(currentInputLine[3]);
                    secondaryNumber = Int32.Parse(currentInputLine[0]);
                }

                else if (currentInputLine[2].Equals("before"))
                {
                    priorityNumber = Int32.Parse(currentInputLine[0]);
                    secondaryNumber = Int32.Parse(currentInputLine[3]);
                }

                if (!parents.ContainsKey(priorityNumber))
                {
                    parents.Add(priorityNumber, new List<int>());
                }

                parents[priorityNumber].Add(secondaryNumber);

                if (!children.ContainsKey(priorityNumber))
                {
                    children.Add(priorityNumber, 0);
                    visited.Add(priorityNumber, false);
                }

                if (!children.ContainsKey(secondaryNumber))
                {
                    children.Add(secondaryNumber, 0);
                    visited.Add(secondaryNumber, false);
                }

                children[secondaryNumber] += 1;
            }

            bool isFirstCycle = true;

            while (!visited.All(x => x.Value))
            {
                foreach (var item in children)
                {
                    int currentChild = item.Key;

                    if (isFirstCycle && currentChild == 0)
                    {
                        isFirstCycle = false;
                        continue;
                    }

                    if (children[currentChild] == 0 && !visited[currentChild])
                    {
                        Console.Write(currentChild);
                        visited[currentChild] = true;

                        int border = parents.ContainsKey(currentChild) ? parents[currentChild].Count : 0;

                        for (int j = 0; j < border; j++)
                        {
                            int parentCurrentChild = parents[currentChild][j];
                            children[parentCurrentChild]--;
                        }

                        break;
                    }
                }
            }
            Console.WriteLine();
        }
    }
}
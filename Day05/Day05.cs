using System;
using System.Linq;

namespace AdventOfCode.Year2015
{
    partial class Program
    {
        static void Day5()
        {
            string[] input = System.IO.File.ReadAllLines("day05/input.txt");
            string vowels = "aeiou";
            string[] badStrings = { "ab", "cd", "pq", "xy" };

            int niceStringsCount = 0;
            foreach (string line in input)
            {
                bool niceString = false;
                for (int i = 0; i < line.Length - 1; i++)
                {
                    if (line[i] == line[i + 1])
                    {
                        niceString = true;
                    }
                }
                
                int numVowels = line.Sum(c => Convert.ToInt32(vowels.Contains(c)));
                if (numVowels < 3)
                {
                    niceString = false;
                }

                foreach (string s in badStrings)
                {
                    if (line.Contains(s))
                    {
                        niceString = false;
                    }
                }

                if (niceString)
                {
                    niceStringsCount++;
                }
            }

            Console.WriteLine("Part 1: " + niceStringsCount);

            niceStringsCount = 0;
            foreach (string line in input)
            {
                var firstCondition = false;
                for (int i = 0; i < line.Length - 3; i++)
                {
                    string pair = line.Substring(i, 2);
                    if (line.LastIndexOf(pair) > i + 1)
                    {
                        firstCondition = true;
                    }
                }

                var secondCondition = false;
                for (int i = 0; i < line.Length - 2; i++)
                {
                    if (line[i] == line[i + 2] && line[i] != line[i + 1])
                    {
                        secondCondition = true;
                    }
                }
                
                if (firstCondition && secondCondition)
                {
                    niceStringsCount++;
                }
            }
            
            Console.WriteLine("Nice strings, part 2: " + niceStringsCount);
        }
    }
}
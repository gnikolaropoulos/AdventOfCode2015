using System;

namespace AdventOfCode.Year2015
{
    partial class Program
    {
        static void Day1()
        {
            string input = System.IO.File.ReadAllText("day01/input.txt");
            int level = 0;
            bool basementFound = false;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    level++;
                }
                else if (input[i] == ')')
                {
                    level--;
                }
                if (level == -1 && !basementFound)
                {
                    Console.WriteLine("Part 2: " + (i + 1));
                    basementFound = true;
                }
            }
            Console.WriteLine("Part 1: " + level);
        }
    }
}
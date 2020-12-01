using System;
using System.Collections.Generic;

namespace AdventOfCode.Year2015
{
    partial class Program
    {
        static void Main(string[] args)
        {
            List<Action> days = new List<Action> {
                () => Day1()
            };

            for (int i = 0; i < days.Count; i++)
            {
                Console.WriteLine("Day " + (i + 1) + ":");
                days[i].Invoke();
                Console.WriteLine();
            }
            Console.WriteLine("Done!");
            Console.ReadKey();
        }
    }
}

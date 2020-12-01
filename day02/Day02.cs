using System;
using System.Linq;

namespace AdventOfCode.Year2015
{
    partial class Program
    {
        static void Day2()
        {
            int requiredPaper = 0;
            int requiredRibbon = 0;
            var input = System.IO.File.ReadAllLines("day02/input.txt");
            foreach (var line in input)
            {
                var parts = line.Split(new char[] { 'x' });
                int[] lengths = { Int32.Parse(parts[0]), Int32.Parse(parts[1]), Int32.Parse(parts[2]) };
                int[] sides = { lengths[0] * lengths[1], lengths[1] * lengths[2], lengths[2] * lengths[0] };
                requiredPaper += 2 * sides.Sum() + sides.Min();

                int shortestDistance = 2 * (lengths.Sum() - lengths.Max());
                requiredRibbon += shortestDistance + lengths[0] * lengths[1] * lengths[2];
            }
            
            Console.WriteLine("Part 1: " + requiredPaper);
            
            Console.WriteLine("Part 2: " + requiredRibbon);
        }
    }
}
using System;
using System.Collections.Generic;

namespace AdventOfCode.Year2015
{
    partial class Program
    {
        static void Day3()
        {
            var input = System.IO.File.ReadAllText("day03/input.txt");
            var step1VisitiedHouses = CalculateVisitedHouses(input);
            Console.WriteLine("Part 1: " + step1VisitiedHouses.Count);
            
            var step2VisitedHouses = CalculateVisitedHouses(input, 0,2);
            step2VisitedHouses.UnionWith(CalculateVisitedHouses(input, 1,2));

            Console.WriteLine("Part 2: " + step2VisitedHouses.Count);
        }

        private static HashSet<Tuple<int, int>> CalculateVisitedHouses(string input, int start =0, int step=1)
        {
            HashSet<Tuple<int, int>> visitedHouses = new HashSet<Tuple<int, int>>();
            int x=0 , y=0;
            visitedHouses.Add(new Tuple<int, int>(x, y));
            for (int i = start; i < input.Length; i+=step)
            {
                switch (input[i])
                {
                    case '<':
                        x--;
                        break;
                    case '>':
                        x++;
                        break;
                    case '^':
                        y++;
                        break;
                    case 'v':
                        y--;
                        break;
                }

                visitedHouses.Add(new Tuple<int, int>(x, y));
            }

            return visitedHouses;
        }
    }
}
using System;
using System.Linq;

namespace AdventOfCode.Year2015
{
    partial class Program
    {

        static void Day6()
        {
            var commands = new string[] { "turn on", "toggle", "turn off", " " };
            string[] input = System.IO.File.ReadAllLines("day06/input.txt");
            var lightsGrid = new bool[1000, 1000];
            var secondLightsGrid = new int[1000, 10000];
            foreach (var line in input)
            {
                var parts = line.Split("through");
                var to = parts[1].Split(",", StringSplitOptions.RemoveEmptyEntries);
                var endCoords = new Tuple<int, int>(Convert.ToInt32(to[0]), Convert.ToInt32(to[1]));
                var from = parts[0].Split(commands, StringSplitOptions.RemoveEmptyEntries)[0].Split(',');
                var startCoords = new Tuple<int, int>(Convert.ToInt32(from[0]), Convert.ToInt32(from[1]));

                var lineCommand = commands.First(x => line.Contains(x));

                UpdateLigtsGrid(lineCommand, lightsGrid, startCoords, endCoords);
                UpdateBrightness(lineCommand, secondLightsGrid, startCoords, endCoords);
            }

            Console.WriteLine("Part 1: " + lightsGrid.Cast<bool>().Sum(b => Convert.ToInt32(b)));
            Console.WriteLine("Part 2: " + secondLightsGrid.Cast<int>().Sum()); //15343601

        }

        private static void UpdateLigtsGrid(string lineCommand, bool[,] lightsGrid, Tuple<int, int> startCoords, Tuple<int, int> endCoords)
        {
            var action = GenerateBoolAction(lineCommand);

            for (int x = startCoords.Item1; x <= endCoords.Item1; x++)
            {
                for (int y = startCoords.Item2; y <= endCoords.Item2; y++)
                {
                    lightsGrid[x, y] = action(lightsGrid[x, y]);
                }
            }
        }

        private static Func<bool, bool> GenerateBoolAction(string lineCommand)
        {
            switch (lineCommand)
            {
                case "turn on":
                    return b => true;
                case "turn off":
                    return b => false;
                case "toggle":
                    return b => !b;
            }

            return b => b;
        }
        private static void UpdateBrightness(string lineCommand, int[,] secondLightsGrid, Tuple<int, int> startCoords, Tuple<int, int> endCoords)
        {
            var action = GenerateIntAction(lineCommand);

            for (int x = startCoords.Item1; x <= endCoords.Item1; x++)
            {
                for (int y = startCoords.Item2; y <= endCoords.Item2; y++)
                {
                    secondLightsGrid[x, y] = action(secondLightsGrid[x, y]);
                    secondLightsGrid[x, y] = Math.Max(0, secondLightsGrid[x, y]);
                }
            }
        }

        private static Func<int, int> GenerateIntAction(string lineCommand)
        {
            switch (lineCommand)
            {
                case "turn on":
                    return i => ++i;
                case "turn off":
                    return i => --i;
                case "toggle":
                    return i => i + 2;
            }

            return b => b;
        }
    }
}
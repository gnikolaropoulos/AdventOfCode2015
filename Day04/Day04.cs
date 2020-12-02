using System;
using System.Security.Cryptography;
using System.Text;

namespace AdventOfCode.Year2015
{
    partial class Program
    {
        static void Day4()
        {
            var input = System.IO.File.ReadAllLines("day04/input.txt")[0];
            MD5 md5Hash = MD5.Create();
            StringBuilder stringBuilder = new StringBuilder();
            int number = -1;
            bool part1SolutionFound = false;
            while (true)
            {
                number++;
                string canditate = input + number.ToString();
                byte[] hashBytes = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(canditate));
                stringBuilder.Clear();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    stringBuilder.Append(hashBytes[i].ToString("x2"));
                }

                if (!part1SolutionFound && stringBuilder.ToString().StartsWith("00000"))
                {
                    //117946
                    Console.WriteLine("Part 1: " + number);
                    part1SolutionFound = true;
                }

                if (stringBuilder.ToString().StartsWith("000000"))
                {
                    //Part 2: 3938038
                    Console.WriteLine("Part 2: " + number);
                    break;
                }
            }
        }
    }
}
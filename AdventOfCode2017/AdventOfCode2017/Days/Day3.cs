using System;
using System.Linq;

namespace AdventOfCode2017.Days
{
    public class Day3 : IDay
    {
        private static string _input = "325489";
        private static string _sample = "32";

        /* 
         * 65 64 63 62 61 60 59 58 57
         * 66 37 36 35 34 33 32 31 56
         * 67 38 17 16 15 14 13 30 55
         * 68 39 18 05 04 03 12 29 54
    PORT * 69 40 19 06  1 02 11 28 53
         * 70 41 20 07 08 09 10 27 52
         * 71 42 21 22 23 24 25 26 51
         * 72 43 44 45 46 47 48 49 50
         * 73 74 75 76 77 78 79 80 81 -> ..
         */

        public void Part1()
        {
            Console.WriteLine("Spiral Memory P.1");

            int input = int.Parse(_input);
            int stepCount = 1;

            // Check horizontals and verticals until input within value range
            int[] positions = new [] {2, 4, 6, 8};
            int[] diffs = positions.Select(p => p - 1).ToArray();

            while (positions.Max() < input)
            {
                for (int i = 0; i < positions.Length; i++)
                {
                    diffs[i] += 8;
                    positions[i] += diffs[i];
                }

                stepCount += 1;
            }

            stepCount += positions.Min(p => Math.Abs(input - p));

            Console.WriteLine($"Steps: {stepCount}");
        }

        /*
         * 147 142 133 122 059
         * 304 005 004 002 057
    PORT * 330 010 001 001 054
         * 351 011 023 025 026
         * 362 747 806 880 932 -> ..
         */

        public void Part2()
        {
            Console.WriteLine("Spiral Memory P.2");

            // TODO: Day3 Part2
            Console.WriteLine("WIP");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2017.Days
{
    public class Day6 : IDay
    {
        private static readonly int[] _input =
        {
            4, 1, 15, 12, 0, 9, 9, 5, 5, 8, 7, 3, 14, 5, 12, 3
        };

        private static readonly int[] _sample =
        {
            0, 2, 7, 0
        };

        private static decimal CreateRecord(int[] banks) =>
            decimal.Parse(string.Join("", banks));

        public void Part1()
        {
            Console.WriteLine("Memory Reallocation P.1");

            int[] banks = _input;

            IList<decimal> seen = new List<decimal>();

            do
            {
                seen.Add(CreateRecord(banks));

                int index = Array.IndexOf(banks, banks.Max());
                int bank = banks[index];
                banks[index] = 0;

                while (bank > 0)
                {
                    index = index == banks.Length - 1 ?
                        0 : index + 1;

                    banks[index] += 1;
                    bank -= 1;
                }
            }
            while (!seen.Contains(CreateRecord(banks)));

            Console.WriteLine($"Redistribution Cycles: {seen.Count}");
        }

        public void Part2()
        {
            Console.WriteLine("Memory Reallocation P.2");

            int[] banks = _input;

            IList<decimal> seen = new List<decimal>();
            decimal banksRecord = CreateRecord(banks);

            do
            {
                seen.Add(banksRecord);

                int index = Array.IndexOf(banks, banks.Max());
                int bank = banks[index];
                banks[index] = 0;

                while (bank > 0)
                {
                    index = index == banks.Length - 1 ?
                        0 : index + 1;

                    banks[index] += 1;
                    bank -= 1;
                }

                banksRecord = CreateRecord(banks);
            }
            while (!seen.Contains(banksRecord));

            int cycles = 0;

            do
            {
                int index = Array.IndexOf(banks, banks.Max());
                int bank = banks[index];
                banks[index] = 0;

                while (bank > 0)
                {
                    index = index == banks.Length - 1 ?
                        0 : index + 1;

                    banks[index] += 1;
                    bank -= 1;
                }

                cycles += 1;
            }
            while (banksRecord != CreateRecord(banks));

            Console.WriteLine($"Redistribution Cycles: {cycles}");
        }
    }
}

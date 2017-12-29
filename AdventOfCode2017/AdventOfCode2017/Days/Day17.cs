using System;
using System.Collections.Generic;

namespace AdventOfCode2017.Days
{
    public class Day17 : IDay
    {
        private readonly int _input = 366;

        private readonly int _sample = 3;

        public void Part1()
        {
            Console.WriteLine("Spinlock P.1");

            IList<int> buffer = new List<int> { 0 };
            int position = 0;
            
            for (int value = 1; value <= 2017; value++)
                UpdateBuffer(_input, value, ref position, ref buffer);

            Console.WriteLine($"Value after 2017: {buffer[buffer.IndexOf(2017) + 1]}");
        }

        public void Part2()
        {
            Console.WriteLine("Spinlock P.2");

            int valueAtPosition1 = 0;
            int position = 0;

            for (int value = 1; value <= 50_000_000; value++)
            {
                if (IsInsertedAtPosition1(_input, value, ref position))
                    valueAtPosition1 = value;
            }

            Console.WriteLine($"Value after 0: {valueAtPosition1}");
        }

        private void UpdateBuffer(int steps, int value, ref int position, ref IList<int> buffer)
        {
            position += steps;
            position %= buffer.Count;
            position += 1;

            buffer.Insert(position, value);
        }

        private bool IsInsertedAtPosition1(int steps, int bufferSize, ref int position)
        {
            position += steps;
            position %= bufferSize;
            position += 1;

            return position == 1;
        }
    }
}

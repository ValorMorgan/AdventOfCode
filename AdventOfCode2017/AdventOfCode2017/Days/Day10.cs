using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2017.Days
{
    public class Day10 : IDay
    {
        private readonly IEnumerable<int> _input = new List<int>()
        {
            94, 84, 0, 79, 2, 27, 81, 1, 123, 93, 218, 23, 103, 255, 254, 243
        };

        private readonly IEnumerable<int> _sample = new List<int>()
        {
            3, 4, 1, 5
        };
        
        public void Part1()
        {
            Console.WriteLine("Knot Hash P.1");

            int[] numbers = Enumerable.Range(0, 256).ToArray();
            int index = 0;
            int skipSize = 0;
            
            foreach (int length in _input)
            {
                IList<int> sublist = GetSublist(numbers, index, length);

                foreach (int number in sublist.Reverse())
                {
                    numbers[index] = number;
                    index += 1;
                    if (index >= numbers.Length)
                        index = 0;
                }

                index += skipSize;
                if (index >= numbers.Length)
                    index = index - numbers.Length;
                skipSize += 1;
            }

            Console.WriteLine($"Hash Result: {numbers[0] * numbers[1]}");
        }

        public void Part2()
        {
            Console.WriteLine("Knot Hash P.2");
            
            throw new NotImplementedException();
        }

        private static IList<int> GetSublist(int[] numbers, int index, int length)
        {
            if (index + length < numbers.Length)
                return numbers
                    .Skip(index)
                    .Take(length)
                    .ToList();

            List<int> sublist = numbers
                .Skip(index)
                .ToList();

            sublist.AddRange(numbers.Take(length - sublist.Count));

            return sublist;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2017.Days
{
    public class Day10 : IDay
    {
        private readonly string _input = 
            "94,84,0,79,2,27,81,1,123,93,218,23,103,255,254,243";

        private readonly string _sample =
            "3,4,1,5";

        private readonly string _sample2 =
            "1,2,3";
        
        public void Part1()
        {
            Console.WriteLine("Knot Hash P.1");

            IEnumerable<int> lengths = _input.Split(',')
                .Select(l => int.Parse(l.Trim()));
            
            int[] numbers = Enumerable.Range(0, 256).ToArray();
            int index = 0;
            int skipSize = 0;

            DoRound(numbers, lengths, ref index, ref skipSize);

            Console.WriteLine($"Hash Result: {numbers[0] * numbers[1]}");
        }

        public void Part2()
        {
            Console.WriteLine("Knot Hash P.2");

            List<int> lengths = _input
                .Select(c => (int)c)
                .ToList();
            
            lengths.AddRange(new [] { 17, 31, 73, 47, 23 });

            int[] numbers = Enumerable.Range(0, 256).ToArray();
            int index = 0;
            int skipSize = 0;

            for (int _ = 1; _ <= 64; _++)
                DoRound(numbers, lengths, ref index, ref skipSize);
            
            IEnumerable<int> denseHash = GetDenseHash(numbers).ToList();

            Console.WriteLine(string.Join("", denseHash.Select(d => d.ToString("x2"))));
        }

        private IEnumerable<int> GetDenseHash(IEnumerable<int> numbers)
        {
            int blockSize = 16;
            for (int i = 0; i * blockSize < numbers.Count(); i++)
            {
                IEnumerable<int> block = numbers.Skip(i * blockSize).Take(blockSize);
                yield return block.Aggregate((a, b) => a^b);
            }
        }

        private void DoRound(int[] numbers, IEnumerable<int> lengths, ref int index, ref int skipSize)
        {
            foreach (int length in lengths)
            {
                IList<int> sublist = GetSublist(numbers, index, length);

                foreach (int number in sublist.Reverse())
                {
                    numbers[index] = number;
                    index += 1;
                    if (index >= numbers.Length)
                        index = 0;
                }

                index = (index + skipSize) % numbers.Length;
                skipSize += 1;
            }
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

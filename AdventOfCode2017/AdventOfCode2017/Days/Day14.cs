using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2017.Days
{
    public class Day14 : IDay
    {
        private readonly string _input = "stpzcrnm";

        private readonly string _sample = "flqrgnkx";
        
        public void Part1()
        {
            Console.WriteLine("Disk Defragmentation P.1");
            int usedBlocks = 0;

            for (int i = 0; i < 128; i++)
                usedBlocks += GenerateKnotHash($"{_input}-{i}")
                    .Aggregate(0, (a, b) => a + b.Count(c => c == '1'));

            Console.WriteLine($"Used blocks: {usedBlocks}");
        }

        

        public void Part2()
        {
            Console.WriteLine("Disk Defragmentation P.2");
            int regions = 0;

            var grid = GenerateGrid(_sample);
            
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] != 1)
                        continue;
                    
                    
                }
            }

            Console.WriteLine($"Total regions: {regions}");
        }
        
        private int[][] GenerateGrid(string input)
        {
            int[][] grid = new int[128][];

            for (int i = 0; i < 128; i++)
            {
                grid[i] = string.Join("", GenerateKnotHash($"{input}-{i}"))
                    .Select(d => int.Parse(d.ToString()))
                    .ToArray();
            }

            return grid;
        }

        private IEnumerable<string> GenerateKnotHash(string input)
        {
            List<int> lengths = input
                .Select(c => (int)c)
                .ToList();

            lengths.AddRange(new[] { 17, 31, 73, 47, 23 });

            int[] numbers = Enumerable.Range(0, 256).ToArray();
            int index = 0;
            int skipSize = 0;

            for (int _ = 1; _ <= 64; _++)
                DoRound(numbers, lengths, ref index, ref skipSize);

            return GetDenseHash(numbers).Select(n => Convert.ToString(n, 2).PadLeft(8, '0'));
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

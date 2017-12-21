using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2017.Days
{
    public class Day15 : IDay
    {
        private const long FACTOR_A = 16_807;
        private const long FACTOR_B = 48_271;
        private const long DIVIDER = 2_147_483_647;

        private readonly Func<long, bool> CRITERIA_A = n => n % 4 == 0;
        private readonly Func<long, bool> CRITERIA_B = n => n % 8 == 0;

        private const long ITERATIONS_P1 = 40_000_000;
        private const long ITERATIONS_P2 = 5_000_000;

        private readonly string _input = "873;583";
        private readonly string _sample = "65;8921";

        public void Part1()
        {
            Console.WriteLine("Dueling Generators P.1");
            
            long genA = int.Parse(_input.Split(';').First());
            long genB = int.Parse(_input.Split(';').Last());
            
            Console.WriteLine($"Final match count: {GetMatchCount(ref genA, ref genB)}");
        }

        public void Part2()
        {
            Console.WriteLine("Dueling Generators P.2");

            long genA = int.Parse(_input.Split(';').First());
            long genB = int.Parse(_input.Split(';').Last());

            Console.WriteLine($"Final match count: {GetMatchCountWithCriteria(ref genA, ref genB)}");
        }

        private int GetMatchCount(ref long genA, ref long genB)
        {
            int matches = 0;

            for (int i = 1; i <= ITERATIONS_P1; i++)
            {
                PerformIteration(ref genA, ref genB);
                if (IsLastSixteenBitsMatch(genA, genB))
                    matches += 1;
            }

            return matches;
        }

        private int GetMatchCountWithCriteria(ref long genA, ref long genB)
        {
            int matches = 0;
            IList<long> queueA = new List<long>();
            IList<long> queueB = new List<long>();

            while (queueA.Count < ITERATIONS_P2 || queueB.Count < ITERATIONS_P2)
            {
                PerformIteration(ref genA, ref genB);

                if (queueA.Count < ITERATIONS_P2 && CRITERIA_A(genA))
                    queueA.Add(genA);
                if (queueB.Count < ITERATIONS_P2 && CRITERIA_B(genB))
                    queueB.Add(genB);
            }
            
            for (int i = 0; i < ITERATIONS_P2; i++)
            {
                if (IsLastSixteenBitsMatch(queueA[i], queueB[i]))
                    matches += 1;
            }

            return matches;
        }

        private void PerformIteration(ref long genA, ref long genB)
        {
            genA = genA * FACTOR_A % DIVIDER;
            genB = genB * FACTOR_B % DIVIDER;
        }

        private static bool IsLastSixteenBitsMatch(long genA, long genB)
        {
            string binaryA = Convert.ToString(genA, 2).PadLeft(16, '0');
            string binaryB = Convert.ToString(genB, 2).PadLeft(16, '0');

            return binaryA.Substring(binaryA.Length - 16) == binaryB.Substring(binaryB.Length - 16);
        }
    }
}

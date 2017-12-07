using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Day6
{
    [TestFixture]
    public class MemoryReallocation
    {
        private readonly int[] _input =
        {
            4, 1, 15, 12, 0, 9, 9, 5, 5, 8, 7, 3, 14, 5, 12, 3
        };

        private readonly int[] _sample =
        {
            0, 2, 7, 0
        };

        [Test]
        public void Redistribution_Cycles_Until_Infinite()
        {
            int[] banks = _sample;
            
            IList<int[]> seen = new List<int[]> { banks };

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

                seen.Add(banks);
            }
            while (!seen.Contains(banks));

            Console.WriteLine($"Redistribution Cycles: {seen.Count - 1}");
        }
    }
}

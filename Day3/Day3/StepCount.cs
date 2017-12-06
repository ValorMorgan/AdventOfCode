using System;
using NUnit.Framework;

namespace Day3
{
    [TestFixture]
    public class StepCount
    {
        private string _input = "325489";
        private string _sample = "31";
        
        /* 
         * 17 16 15 14 13
         * 18  5  4  3 12
    PORT * 19  6  1  2 11
         * 20  7  8  9 10
         * 21 22 23 -> ..
         */
        
        [Test]
        public void Steps_To_Carry_To_Port()
        {
            int input = int.Parse(_sample);
            int stepCount = 0;
            Console.WriteLine(input);

            stepCount += input / 8 - 1;
            input = input - (int)(8 * (int)(input / 8)) + 1;

            Console.WriteLine($"Jumped to {input} in {stepCount} steps");

            if (input > 1)
            {
                stepCount += (input - 1) % 2 == 0 ? 2 : 1;

                Console.WriteLine("step: " + 1);
            }
            
            Console.WriteLine($"Steps: {stepCount}");
        }
    }
}

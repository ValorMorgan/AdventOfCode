using System;
using AdventOfCode2017.Days;

namespace AdventOfCode2017
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Advent Of Code 2017");
            Console.WriteLine("Enter day number followed by part number to test.");
            Console.WriteLine();

            while (true)
            {
                Console.Write("> ");
                switch (Console.ReadLine().Replace(">", "").Trim().ToLower())
                {
                    case "1":
                        DeterminePart(new Day1());
                        break;
                    case "2":
                        DeterminePart(new Day2());
                        break;
                    case "3":
                        DeterminePart(new Day3());
                        break;
                    case "4":
                        DeterminePart(new Day4());
                        break;
                    case "5":
                        DeterminePart(new Day5());
                        break;
                    case "6":
                        DeterminePart(new Day6());
                        break;
                    default:
                        Console.WriteLine("Unknown command");
                        break;
                }

                Console.WriteLine();
            }
        }

        private static void DeterminePart(IDay day)
        {
            Console.Write("Part: ");
            switch (Console.ReadLine().Replace("Part:", "").Trim().ToLower())
            {
                case "1":
                    day.Part1();
                    break;
                case "2":
                    day.Part2();
                    break;
                default:
                    Console.WriteLine("Unkown Part");
                    break;
            }
        }
    }
}

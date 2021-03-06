﻿using System;
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
                try
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
                        case "7":
                            DeterminePart(new Day7());
                            break;
                        case "8":
                            DeterminePart(new Day8());
                            break;
                        case "9":
                            DeterminePart(new Day9());
                            break;
                        case "10":
                            DeterminePart(new Day10());
                            break;
                        case "11":
                            DeterminePart(new Day11());
                            break;
                        case "12":
                            DeterminePart(new Day12());
                            break;
                        case "13":
                            DeterminePart(new Day13());
                            break;
                        case "14":
                            DeterminePart(new Day14());
                            break;
                        case "15":
                            DeterminePart(new Day15());
                            break;
                        case "16":
                            DeterminePart(new Day16());
                            break;
                        case "17":
                            DeterminePart(new Day17());
                            break;
                        case "18":
                            DeterminePart(new Day18());
                            break;
                        case "19":
                            DeterminePart(new Day19());
                            break;
                        case "20":
                            DeterminePart(new Day20());
                            break;
                        case "21":
                            DeterminePart(new Day21());
                            break;
                        case "22":
                            DeterminePart(new Day22());
                            break;
                        case "23":
                            DeterminePart(new Day23());
                            break;
                        case "24":
                            DeterminePart(new Day24());
                            break;
                        case "25":
                            DeterminePart(new Day25());
                            break;
                        case "exit":
                            return;
                        default:
                            Console.WriteLine("Unkown Day");
                            break;
                    }
                }
                catch (NotImplementedException)
                {
                    Console.WriteLine("Not Implemented");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
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

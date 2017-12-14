using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2017.Days
{
    public class Day13 : IDay
    {
        #region INPUT
        private readonly string _input =
@"0: 4
1: 2
2: 3
4: 4
6: 8
8: 5
10: 8
12: 6
14: 6
16: 8
18: 6
20: 6
22: 12
24: 12
26: 10
28: 8
30: 12
32: 8
34: 12
36: 9
38: 12
40: 8
42: 12
44: 17
46: 14
48: 12
50: 10
52: 20
54: 12
56: 14
58: 14
60: 14
62: 12
64: 14
66: 14
68: 14
70: 14
72: 12
74: 14
76: 14
80: 14
84: 18
88: 14";
        #endregion

        private readonly string _sample =
@"0: 3
1: 2
4: 4
6: 4";
        
        private readonly string _sample2 =
@"0: 3
1: 2
2: 3
4: 4
6: 4
8: 5
10: 8
12: 6
14: 6
16: 8";
        
        public void Part1()
        {
            Console.WriteLine("Packet Scanners P.1");

            var firewall = GetFirewall(_input);
            int severity = 0;

            foreach (int picoSecond in firewall.Keys.Where(k => k > 0))
            {
                double length = firewall[picoSecond] + firewall[picoSecond] - 2;
                
                if (picoSecond % length > 0)
                    continue;
                
                severity += picoSecond * firewall[picoSecond];
            }

            Console.WriteLine($"Severity of Trip: {severity}");
        }

        public void Part2()
        {
            Console.WriteLine("Packet Scanners P.2");

            var firewall = GetFirewall(_input);
            int delay = 0;

            while (!IsDelayEnoughToPass(firewall, delay))
            {
                delay += 1;
            }

            Console.WriteLine($"Shortest Delay: {delay}");
        }
        
        private IDictionary<int, int> GetFirewall(string input) =>
            input.Split('\n').ToDictionary(
                line => int.Parse(line.Split(':').First()), 
                line => int.Parse(line.Split(':').Last())
            );
        
        private bool IsDelayEnoughToPass(IDictionary<int, int> firewall, int delay)
        {
            foreach (int picoSecond in firewall.Keys)
            {
                double length = firewall[picoSecond] + firewall[picoSecond] - 2;
                
                if ((picoSecond + delay) % length <= 0)
                    return false;
            }

            return true;
        }
    }
}

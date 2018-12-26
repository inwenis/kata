using System;
using System.Collections.Generic;
using System.Linq;

namespace kata04.data.munging
{
    public class Parser
    {
        public static List<Row> ParseWeather(string input)
        {
            string[] split = Common(input, 2, 2);
            List<Row> parsed = split
                .Select(x =>
                {
                    return new Row()
                    {
                        Name = x.Substring(2, 2).Trim(),
                        ValueA = int.Parse(x.Substring(6, 2)),
                        ValueB = int.Parse(x.Substring(12, 2))
                    };
                })
                .ToList();
            return parsed;
        }

        public static List<Row> ParseFootball(string input)
        {
            string[] split = Common(input, 1, 1);
            List<Row> parsed = split
                .Where(row => !row.Contains("-------------------------------------------------------"))
                .Select(x =>
                {
                    return new Row()
                    {
                        Name = x.Substring(7, 15).Trim(),
                        ValueB = int.Parse(x.Substring(43, 2)),
                        ValueA = int.Parse(x.Substring(50, 2))
                    };
                })
                .ToList();
            return parsed;
        }

        private static string[] Common(string input, int skipBeginning, int skipEnd)
        {
            string[] split = input.Split("\n");
            var splitTrimmed = split
                .Skip(skipBeginning)
                .Take(split.Length - (skipBeginning + skipEnd))
                .ToArray();
            return splitTrimmed;
        }

        public class Row
        {
            public string Name;
            public int ValueA;
            public int ValueB;

            public int AbsDiff
            {
                get
                {
                    return Math.Abs(ValueB - ValueA);
                }
            }
        }
    }
}

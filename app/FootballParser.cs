using System;
using System.Collections.Generic;
using System.Linq;

namespace kata04.data.munging
{
    public class Parser
    {
        public static List<Row> ParseWeather(string input)
        {
            return Common(input, 2, 2, Range.New(2, 2), Range.New(6, 2), Range.New(12, 2));
        }

        public static List<Row> ParseFootball(string input)
        {
            return Common(input, 1, 1, Range.New(7, 15), Range.New(43, 2), Range.New(50, 2));
        }

        private static List<Row> Common(string input, int skipBeginning, int skipEnd, Range name, Range a, Range b)
        {
            string[] split = input.Split("\n");
            var parsed = split
                .Skip(skipBeginning)
                .Take(split.Length - (skipBeginning + skipEnd))
                .Where(row => !row.Contains("-------------------------------------------------------"))
                .Select(x =>
                {
                    return new Row()
                    {
                        Name = x.Substring(name.From, name.Length).Trim(),
                        ValueA = int.Parse(x.Substring(a.From, a.Length)),
                        ValueB = int.Parse(x.Substring(b.From, b.Length))
                    };
                })
                .ToList();
            return parsed;
        }

        public class Range
        {
            public int From;
            public int Length;

            public static Range New(int from, int length)
            {
                return new Range{From = from, Length = length};
            }
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

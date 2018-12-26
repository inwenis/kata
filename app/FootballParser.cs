using System;
using System.Collections.Generic;
using System.Linq;

namespace kata04.data.munging
{
    public class Parser
    {
        public static List<Row> ParseWeather(string input)
        {
            string[] split = input.Split("\n");
            List<Row> parsed = split
                .Skip(2) // header row + empty row
                .Take(split.Length - 4) // header row + empty row + total row + \n at EOF
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
            string[] split = input.Split("\n");
            List<Row> parsed = split
                .Skip(1) // header row
                .Take(split.Length - 2) // last row
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

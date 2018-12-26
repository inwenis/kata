using System.Collections.Generic;
using System.Linq;

namespace kata04.data.munging
{
    public class FootballParser
    {
        public static List<Row> Parse(string input)
        {
            string[] split = input.Split("\n");
            List<Row> parsed = split
                .Skip(1) // header row + empty row
                .Take(split.Length - 2) // last row
                .Select(x =>
                {
                    return new Row()
                    {
                        Team = x.Substring(7, 15).Trim(),
                        ForScore = int.Parse(x.Substring(43, 2)),
                        AgainstScore = int.Parse(x.Substring(50, 2))
                    };
                })
                .ToList();
            return parsed;
        }

        public class Row
        {
            public string Team;
            public int AgainstScore;
            public int ForScore;

            public int Diff
            {
                get
                {
                    return ForScore - AgainstScore;
                }
            }
        }
    }
}

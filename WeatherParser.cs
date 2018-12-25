using System.Collections.Generic;
using System.Linq;

public class WeatherParser
{
    public static List<Row> Parse(string input)
    {
        string[] split = input.Split("\n");
        List<Row> parsed = split
            .Skip(2) // header row + empty row
            .Take(split.Length - 2 - 1) // header row + empty row + \n at EOF
            .Select(x =>
            {
                return new Row()
                {
                    DayNumber = int.Parse(x.Substring(2, 2)),
                    MaxTemp = int.Parse(x.Substring(6, 2)),
                    MinTemp = int.Parse(x.Substring(12, 2))
                };
            })
            .ToList();
        return parsed;
    }

    public class Row
    {
        public int DayNumber;
        public int MinTemp;
        public int MaxTemp;
    }
}
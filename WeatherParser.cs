using System.Collections.Generic;

public class WeatherParser
{
    public static List<Row> Parse(string input)
    {
        string[] split = input.Split("\n");
        string data = split[2];
        Row row = new Row()
        {
            DayNumber = int.Parse(data.Substring(2, 2)),
            MaxTemp = int.Parse(data.Substring(6, 2)),
            MinTemp = int.Parse(data.Substring(12, 2))
        };
        return new List<Row>()
        {
            row
        };
    }

    public class Row
    {
        public int DayNumber;
        public int MinTemp;
        public int MaxTemp;
    }
}
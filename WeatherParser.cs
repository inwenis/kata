using System.Collections.Generic;

public class WeatherParser
{
    public static List<Row> Parse(string input)
    {
        return new List<Row>();
    }

    public class Row
    {
        public int DayNumber;
        public int MinTemp;
        public int MaxTemp;
    }
}
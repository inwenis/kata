using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using kata04.data.munging;

namespace app
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = File.ReadAllText("weather.dat");
            List<WeatherParser.Row> rows = WeatherParser.Parse(input);
            WeatherParser.Row dayWithSmallestSpread = rows
                .OrderBy(x => x.TempSpread)
                .First();
            Console.WriteLine($"Day: {dayWithSmallestSpread.DayNumber}" +
                $" min: {dayWithSmallestSpread.MinTemp}" +
                $" max: {dayWithSmallestSpread.MaxTemp}" +
                $" spread: {dayWithSmallestSpread.TempSpread}");

            input = File.ReadAllText("football.dat");
            var teamWithSmallestDiff = FootballParser.Parse(input)
                .OrderBy(x => x.Diff)
                .First();
            Console.WriteLine($"Day: {teamWithSmallestDiff.Team}" +
                $" against: {teamWithSmallestDiff.AgainstScore}" +
                $" for: {teamWithSmallestDiff.ForScore}" +
                $" diff: {teamWithSmallestDiff.Diff}");
        }
    }
}

﻿using System;
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
            List<Parser.Row> rows = Parser.ParseWeather(input);
            Parser.Row dayWithSmallestSpread = rows
                .OrderBy(x => x.AbsDiff)
                .First();
            Console.WriteLine($"Day: {dayWithSmallestSpread.Name}" +
                $" min: {dayWithSmallestSpread.ValueB}" +
                $" max: {dayWithSmallestSpread.ValueA}" +
                $" spread: {dayWithSmallestSpread.AbsDiff}");

            input = File.ReadAllText("football.dat");
            var teamWithSmallestDiff = Parser.ParseFootball(input)
                .OrderBy(x => x.AbsDiff)
                .First();
            Console.WriteLine($"Day: {teamWithSmallestDiff.Name}" +
                $" against: {teamWithSmallestDiff.ValueA}" +
                $" for: {teamWithSmallestDiff.ValueB}" +
                $" diff: {teamWithSmallestDiff.AbsDiff}");
        }
    }
}

using System;
using System.Linq;

public static class CharacterSorterUsingLinqu
{
    public static string Sort(string input)
    {
        var characters = input
            .ToLower()
            .Where(x => x >= 'A' && x <= 'z')
            .GroupBy(x => x)
            .Select(x => (x.Key, Count: x.Count()))
            .OrderBy(x => x.Key)
            .Select(x => Enumerable.Repeat(x.Key, x.Count));
        var result = String.Join("", characters);
        return result;
    }
}

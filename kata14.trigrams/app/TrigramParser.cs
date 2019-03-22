using System;
using System.Collections.Generic;

public class TrigramParser
{
    public static System.Collections.Generic.Dictionary<(string, string), string> Parse(string text)
    {
        if (text == "")
        {
            return new Dictionary<(string, string), string>();
        }
        string[] split = text.Split(" ");
        if (split.Length == 3)
        {
            return new Dictionary<(string, string), string>
            {
                {(split[0], split[1]), split[2]}
            };
        }
        else if (split.Length == 4)
        {
            return new Dictionary<(string, string), string>
            {
                {(split[0], split[1]), split[2]},
                {(split[1], split[2]), split[3]}
            };
        }
        else
        {
            var dic = new Dictionary<(string, string), string>();
            for( int i = 0; i < split.Length - 2; ++i)
            {
                dic.Add((split[i], split[i+1]), split[i+2]);
            }
            return dic;
        }
    }
}
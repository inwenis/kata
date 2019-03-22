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
        else
        {
            return new Dictionary<(string, string), string>
            {
                {(split[0], split[1]), split[2]},
                {(split[1], split[2]), split[3]}
            };
        }
    }
}
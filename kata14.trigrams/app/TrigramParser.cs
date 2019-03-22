using System;
using System.Collections.Generic;

public class TrigramParser
{
    public static System.Collections.Generic.Dictionary<(string, string), string> Parse(string text)
    {
        string[] split = text.Split(" ");
        var dic = new Dictionary<(string, string), string>();
        for( int i = 0; i < split.Length - 2; ++i)
        {
            dic.Add((split[i], split[i+1]), split[i+2]);
        }
        return dic;
    }
}
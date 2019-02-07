public static class JavaLinesCounter
{
    public static int Count(string code)
    {
        if(code.Length == 0)
            return 0;
        else if (code.Split('\n').Length > 0)
            return code.Split('\n').Length;
        else
            return 1;
    }
}
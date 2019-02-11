public static class JavaLinesCounter
{
    public static int Count(string code)
    {
        if(code.Length == 0)
            return 0;
        else
            return code.Split('\n').Length;
    }
}
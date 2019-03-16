public class JavaNoRegexCommentsRemover
{
    public static string RemoveComments(string code)
    {
        if(code.Contains("//"))
        {
            return "";
        }
        else
        {
            return code;
        }
    }
}
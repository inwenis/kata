using System.Text;

public class JavaNoRegexCommentsRemover
{
    public static string RemoveComments(string code)
    {
        StringBuilder output = new StringBuilder();
        bool lineComment = false;
        for (int i = 0; i < code.Length; i++)
        {
            if(code[i] == '/' && code[i+1] == '/')
            {
                lineComment = true;
            }

            if (!lineComment)
            {
                output.Append(code[i]);
            }
        }

        return output.ToString();
    }
}
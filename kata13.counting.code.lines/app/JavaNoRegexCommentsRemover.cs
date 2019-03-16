using System.Text;

public class JavaNoRegexCommentsRemover
{
    public static string RemoveComments(string code)
    {
        StringBuilder output = new StringBuilder();
        bool lineComment = false;
        bool blockComment = false;
        for (int i = 0; i < code.Length; i++)
        {
            if (lineComment && LineCommentEnds3(code, i))
            {
                lineComment = false;
            }
            else if (LineCommentStarts(code, i))
            {
                lineComment = true;
            }
            else if (BlockCommentStarts(code, i))
            {
                blockComment = true;
            }

            if (!lineComment && !blockComment)
            {
                output.Append(code[i]);
            }
        }

        return output.ToString();
    }

    private static bool LineCommentEnds3(string code, int i)
    {
        return code[i] == '\n' || code[i] == '\r' && code.Length > i + 1 && code[i + 1] == '\n';
    }

    private static bool BlockCommentStarts(string code, int i)
    {
        return code[i] == '/' && code.Length > i + 1 && code[i + 1] == '*';
    }

    private static bool LineCommentStarts(string code, int i)
    {
        return code[i] == '/' && code.Length > i + 1 && code[i + 1] == '/';
    }
}
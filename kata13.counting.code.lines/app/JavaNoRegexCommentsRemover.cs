using System;
using System.Text;

public class JavaNoRegexCommentsRemover
{
    public static string RemoveComments(string code)
    {
        StringBuilder output = new StringBuilder();
        bool lineComment = false;
        bool blockComment = false;
        bool stringSwitch = false;
        for (int i = 0; i < code.Length; i++)
        {
            if (lineComment && LineCommentEnds(code, i))
            {
                lineComment = false;
            }
            else if (blockComment && BlockCommentEnds(code, i))
            {
                blockComment = false;
            }
            else if (stringSwitch && StringEnds(code, i))
            {
                stringSwitch = false;
            }
            else if (!blockComment && !stringSwitch && LineCommentStarts(code, i))
            {
                lineComment = true;
            }
            else if (!lineComment && !stringSwitch && BlockCommentStarts(code, i))
            {
                blockComment = true;
            }
            else if (StringStarts(code, i))
            {
                stringSwitch = true;
            }

            if (!lineComment && !blockComment)
            {
                output.Append(code[i]);
            }
            else if (blockComment && (code[i] == '\n' || code[i] == '\r'))
            {
                output.Append(code[i]);
            }
        }

        return output.ToString();
    }

    private static bool StringEnds(string code, int i)
    {
        return code[i] == '"';
    }

    private static bool StringStarts(string code, int i)
    {
        return code[i] == '"';
    }

    private static bool BlockCommentEnds(string code, int i)
    {
        return i - 2 >= 0 && code[i-2] == '*' && code[i-1] == '/';
    }

    private static bool LineCommentEnds(string code, int i)
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
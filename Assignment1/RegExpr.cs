using System.Text.RegularExpressions;

namespace Assignment1;

public static class RegExpr
{
    public static IEnumerable<string> SplitLine(IEnumerable<string> lines)
    {
        string splitOn = @"[\s.,;]+";
        foreach (var line in lines)
        {
           string[] output = Regex.Split(line, splitOn);

           foreach (var word in output)
           {
               yield return word;
           }
        }
    }

    public static IEnumerable<(int width, int height)> Resolution(string resolutions) => throw new NotImplementedException();

    public static IEnumerable<string> InnerText(string html, string tag) => throw new NotImplementedException();
}

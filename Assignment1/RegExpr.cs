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

    public static IEnumerable<(int width, int height)> Resolution(string resolutions)
    {
        string splitOn = @"[\s,a-z]";
        string[] splitted = Regex.Split(resolutions, splitOn);

        for (int i = 0; i < splitted.Length; i += 3)
        {
            yield return (int.Parse(splitted[i]), int.Parse(splitted[i + 1]));
        }
    }

    public static IEnumerable<string> InnerText(string html, string tag)
    {
        foreach(Match match in Regex.Matches(html, $@"(?<tag><{tag}[\w\s\d_()\-:\/"":,.=]*>)(?<inner>.*?)(<\/{tag}>)"))
        {
            yield return Regex.Replace(match.Groups["inner"]
                .Value, "<.*?>", "");
        }
    }
    
    
}

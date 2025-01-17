using System.Text.RegularExpressions;

namespace Assignment1.Tests;
using FluentAssertions;
using Xunit;
using Assignment1;

public class RegExprTests
{
    [Fact]
    static void SplitLine_returns_words()
    {
        // Arrange

        string[] input = {"Hype i chatten\nJeg gider ikke mere"};
        string[] expected = {"Hype", "i", "chatten", "Jeg", "gider", "ikke", "mere"};

        // Act
        var result = RegExpr.SplitLine(input.AsEnumerable());

        // Assert
        Assert.Equal(expected, result);

    }

    [Fact]
    static void Resolution_returns_splitted_resolution()
    {
        // Arrange
        string input = "1920x1080, 1024x768, 800x600, 640x480, 320x200";
        (int, int)[] expected =
        {
            (1920, 1080), (1024, 768),
            (800, 600), (640, 480), (320, 200)
        };

        // Act
        var pizza = RegExpr.Resolution(input);

        // Assert
        Assert.Equal(expected, pizza);
    }

    [Fact]
    static void InnerText_returns_text_of_given_HTML_tags()
    {
        // Arrange

        string input_innertext = "<div><p>A <b>regular expression</b>, <b>regex</b> or <b>regexp</b> (sometimes called a <b>rational expression</b>) is, in <a href=\"https://en.wikipedia.org/wiki/Theoretical_computer_science\" title=\"Theoretical computer science\">theoretical computer science</a> and <a href=\"https://en.wikipedia.org/wiki/Formal_language\" title=\"Formal language\">formal language</a> theory, a sequence of <a href=\"https://en.wikipedia.org/wiki/Character_(computing)\" title=\"Character (computing)\">characters</a> that define a <i>search <a href=\"https://en.wikipedia.org/wiki/Pattern_matching\" title=\"Pattern matching\">pattern</a></i>. Usually this pattern is then used by <a href=\"https://en.wikipedia.org/wiki/String_searching_algorithm\" title=\"String searching algorithm\">string searching algorithms</a> for \"find\" or \"find and replace\" operations on <a href=\"https://en.wikipedia.org/wiki/String_(computer_science)\" title=\"String (computer science)\">strings</a>.</p></div>";
        string input_tag = "a";
        string[] expected =
        {
            "theoretical computer science", "formal language", "characters", "pattern",
            "string searching algorithms", "strings"
        };
        
        // Act 

        var tiramisu = RegExpr.InnerText(input_innertext, input_tag);

        // Assert
        Assert.Equal(expected, tiramisu);
    }
    
    [Fact]
    static void Urls_returns_url_and_title_if_title_is_present()
    {
        // Arrange

        string input_innertext = "<div><p>A <b>regular expression</b>, <b>regex</b> or <b>regexp</b> (sometimes called a <b>rational expression</b>) is, in <a href=\"https://en.wikipedia.org/wiki/Theoretical_computer_science\" title=\"Theoretical computer science\">theoretical computer science</a> and <a href=\"https://en.wikipedia.org/wiki/Formal_language\" title=\"Formal language\">formal language</a> theory, a sequence of <a href=\"https://en.wikipedia.org/wiki/Character_(computing)\" title=\"Character (computing)\">characters</a> that define a <i>search <a href=\"https://en.wikipedia.org/wiki/Pattern_matching\" title=\"Pattern matching\">pattern</a></i>. Usually this pattern is then used by <a href=\"https://en.wikipedia.org/wiki/String_searching_algorithm\" title=\"String searching algorithm\">string searching algorithms</a> for \"find\" or \"find and replace\" operations on <a href=\"https://en.wikipedia.org/wiki/String_(computer_science)\" title=\"String (computer science)\">strings</a>.</p></div>";
        (Uri, string)[] expected =
        {
            (new Uri("https://en.wikipedia.org/wiki/Theoretical_computer_science"), "Theoretical computer science"),
            (new Uri("https://en.wikipedia.org/wiki/Formal_language"), "Formal language"),
            (new Uri("https://en.wikipedia.org/wiki/Character_(computing)"), "Character (computing)"),
            (new Uri("https://en.wikipedia.org/wiki/Pattern_matching"), "Pattern matching"),
            (new Uri("https://en.wikipedia.org/wiki/String_searching_algorithm"), "String searching algorithm"),
            (new Uri("https://en.wikipedia.org/wiki/String_(computer_science)"), "String (computer science)")
        };
        
        // Act 
        var tiramisu = RegExpr.Urls(input_innertext);

        // Assert
        Assert.Equal(expected, tiramisu);
    }

    [Fact]
    static void InnerText_returns_all_of_p_tag()
    {
        // Arrange

        string input_innertext =
            "<div><p>The phrase <i>regular expressions</i> (and consequently, regexes) is often used to mean the specific, standard textual syntax for representing <u>patterns</u> that matching <em>text</em> need to conform to.</p></div>";
        
        string[] expected =
        {
            "The phrase regular expressions (and consequently, regexes) is often used to mean the specific, standard textual syntax for representing patterns that matching text need to conform to."
        };

        // Act 
        var fiskefrikadelle = RegExpr.InnerText(input_innertext, "p").ToArray();

        // Assert
        Assert.Equal(expected[0], fiskefrikadelle[0]);
    }

}

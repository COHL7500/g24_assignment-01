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

}

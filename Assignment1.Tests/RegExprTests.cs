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
         string[] expected = {"Hype", 
             "i", 
             "chatten", 
             "Jeg", 
             "gider", 
             "ikke", 
             "mere"};

         // Act
         var result = RegExpr.SplitLine(input.AsEnumerable());

         // Assert
         Assert.Equal(expected, result);

    }
}

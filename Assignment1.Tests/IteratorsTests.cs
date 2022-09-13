namespace Assignment1.Tests;
using FluentAssertions;
using Xunit;
using Assignment1;

public class IteratorsTests
{
    [Fact]
    static void Flatten_should_return_a_stream_of_T()
    {
        // Arrange
        int[] array123 = {1, 2, 3};
        int[] array456 = {4, 5, 6};
        IEnumerable<int>[] arrayLink = {array123, array456};
        int[] expected = {1, 2, 3, 4, 5, 6};

        // Act
        var spaghetti = Iterators.Flatten(arrayLink.AsEnumerable());

        // Assert
        spaghetti.Should()
            .BeEquivalentTo(expected.AsEnumerable());
    }
}

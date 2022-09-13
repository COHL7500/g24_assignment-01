namespace Assignment1.Tests;
using FluentAssertions;
using Xunit;
using Assignment1;

public class IteratorsTests
{
    [Fact]
    static void Flatten__returns_a_stream_of_T()
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

    [Fact]
    static void Filter_returns_true_true()
    {
        // Arrange
        int[] array1324 = {1, 3, 2, 4};
        Predicate<int> even = Even;
        bool Even(int i) => i % 2 == 0;
        int[] expected = {2, 4};

        // Act
        var lasagne = Iterators.Filter(array1324.AsEnumerable(), even);
        
        // Assert
        Assert.Equal(expected, lasagne);
    }

}

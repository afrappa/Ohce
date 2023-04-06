using FluentAssertions;

namespace Ohce.Tests;

public class StringReverserTests
{
    private StringReverser _sut;

    public StringReverserTests()
    {
        _sut = new StringReverser();
    }

    [Theory]
    [InlineData("", "")]
    [InlineData("hola", "aloh")]
    [InlineData("stop", "pots")]
    public void Reverses(string input, string expectedOutput)
    {
        var result = _sut.Reverse(input);
        
        result.Should().Be(expectedOutput);
    }
}
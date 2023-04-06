using FluentAssertions;

namespace Ohce.Tests;

public class PalindromeDetectorTests
{
    private readonly PalindromeDetector _sut;

    public PalindromeDetectorTests()
    {
        _sut = new PalindromeDetector();
    }

    [Theory]
    [InlineData("abc")]
    [InlineData("zyx")]
    [InlineData("MNO")]
    [InlineData("Not Palindrome")]
    public void WhenIsNotPalindrome_ReturnsFalse(string input)
    {
        var result = _sut.IsPalindrome(input);
        result.Should().BeFalse();
    }
    
    [Theory]
    [InlineData("")]
    [InlineData("abba")]
    [InlineData("ini")]
    [InlineData("erre")]
    [InlineData("olutrrtulo")]
    [InlineData("olutrirtulo")]
    public void WhenIsPalindrome_ReturnsTrue(string input)
    {
        var result = _sut.IsPalindrome(input);
        result.Should().BeTrue();
    }
}
using NSubstitute;

namespace Ohce.Tests;

public class OhceTests
{
    private readonly Ohce _sut;
    private readonly IConsole _console;
    private readonly ITime _dateTime;
    private readonly IStringReverser _stringReverser;
    private readonly IPalindromeDetector _palindromeDetector;

    public OhceTests()
    {
        _console = Substitute.For<IConsole>();
        _dateTime = Substitute.For<ITime>();
        _stringReverser = Substitute.For<IStringReverser>();
        _palindromeDetector = Substitute.For<IPalindromeDetector>();
        _sut = new Ohce(_console, _dateTime, _stringReverser, _palindromeDetector);
    }
    
    [Theory]
    [InlineData("Pedro")]
    [InlineData("Luis")]
    [InlineData("Garcia")]
    public void NightGreetings(string name)
    {
        _dateTime.TimeOfDay.Returns(new TimeOnly(22, 12, 10));
        _console.ReadLine().Returns("Stop!");
        
        _sut.Run(name);
        
        _console.Received(1).WriteLine($"¡Buenas noches {name}!");
    }
    
    [Theory]
    [InlineData("Pedro")]
    [InlineData("Luis")]
    [InlineData("Garcia")]
    public void MorningGreetings(string name)
    {
        _dateTime.TimeOfDay.Returns(new TimeOnly(10, 12, 10));
        _console.ReadLine().Returns("Stop!");
        
        _sut.Run(name);
        
        _console.Received(1).WriteLine($"¡Buenos días {name}!");
    }
    
    [Theory]
    [InlineData("Pedro")]
    [InlineData("Luis")]
    [InlineData("Garcia")]
    public void AfternoonGreetings(string name)
    {
        _dateTime.TimeOfDay.Returns(new TimeOnly(17, 12, 10));
        _console.ReadLine().Returns("Stop!");
        
        _sut.Run(name);
        
        _console.Received(1).WriteLine($"¡Buenas tardes {name}!");
    }

    [Fact]
    public void Adios()
    {
        _console.ReadLine().Returns("Stop!");
        
        _sut.Run("Pedro");
        
        Received.InOrder(() =>
        {
            _console.WriteLine(Arg.Any<string>());
            _console.WriteLine("Adios Pedro");
        });
    }
    
    [Fact]
    public void Loop()
    {
        _console.ReadLine().Returns("hola", "oto", "stop", "Stop!");
        _stringReverser.Reverse("hola").Returns("aloh");
        _stringReverser.Reverse("oto").Returns("oto");
        _stringReverser.Reverse("stop").Returns("pots");
        _palindromeDetector.IsPalindrome("oto").Returns(true);
        
        _sut.Run("Pedro");
        
        Received.InOrder(() =>
        {
            _console.WriteLine(Arg.Any<string>());
            _console.WriteLine("aloh");
            _console.WriteLine("oto");
            _console.WriteLine("¡Bonita palabra!");
            _console.WriteLine("pots");
            _console.WriteLine("Adios Pedro");
        });
    }
}
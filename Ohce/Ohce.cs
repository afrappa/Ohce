namespace Ohce;

public class Ohce
{
    private readonly IConsole _console;
    private readonly ITime _dateTime;
    private readonly IStringReverser _stringReverser;
    private readonly IPalindromeDetector _palindromeDetector;

    public Ohce(
        IConsole console,
        ITime time,
        IStringReverser stringReverser,
        IPalindromeDetector palindromeDetector)
    {
        _console = console;
        _dateTime = time;
        _stringReverser = stringReverser;
        _palindromeDetector = palindromeDetector;
    }

    public void Run(string name)
    {
        var timeOfDay = _dateTime.TimeOfDay;
        var greetings = Greetings(name, timeOfDay);

        _console.WriteLine(greetings);

        Loop();
        
        _console.WriteLine($"Adios {name}");
    }

    private void Loop()
    {
        while (true)
        {
            var input = _console.ReadLine();
            if (input == "Stop!")
                break;

            _console.WriteLine(_stringReverser.Reverse(input));
            if (_palindromeDetector.IsPalindrome(input))
                _console.WriteLine("¡Bonita palabra!");
        }
    }

    private static string Greetings(string name, TimeOnly timeOfDay)
    {
        return timeOfDay switch
        {
            { Hour: >= 20 or < 6 } => $"¡Buenas noches {name}!", 
            { Hour: >= 6 and < 12 } => $"¡Buenos días {name}!", 
            { Hour: >= 12 and < 20 } => $"¡Buenas tardes {name}!"
        };
    }
}
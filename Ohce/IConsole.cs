namespace Ohce;

public interface IConsole
{
    void WriteLine(string text);
    string? ReadLine();
}

public class ConsoleImpl : IConsole
{
    public void WriteLine(string text) => Console.WriteLine(text);
    
    public string? ReadLine() => Console.ReadLine();
}
namespace Ohce;

public class StringReverser : IStringReverser
{
    public string Reverse(string input)
    {
        var span = input.ToCharArray().AsSpan();
        span.Reverse();
        return new string(span);
    }
}
namespace Ohce;

public interface ITime
{
    TimeOnly TimeOfDay { get; }
}

public class TimeImpl : ITime
{
    public TimeOnly TimeOfDay => TimeOnly.FromDateTime(DateTime.Now);
}


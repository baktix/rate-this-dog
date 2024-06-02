using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

public static class FakeLogger
{
    public static ILogger<T> Create<T>() => new NullLogger<T>();
}
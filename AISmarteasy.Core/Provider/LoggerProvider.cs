using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace AISmarteasy.Core;

public static class LoggerProvider
{
    public static ILogger Provide(LogConditionKind logCondition, Type type)
    {
        return Provide(logCondition);
    }

    public static ILogger Provide(LogConditionKind logCondition)
    {
        return NullLogger.Instance;
    }
}

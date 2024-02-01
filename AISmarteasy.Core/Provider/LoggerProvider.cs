using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace AISmarteasy.Core;

public static class LoggerProvider
{
    private static ILogger _logger = NullLogger.Instance;

    static void Initialize(LogConditionKind logCondition)
    {
        _logger = NullLogger.Instance;
    }

    public static ILogger Provide()
    {
        return _logger;
    }
}

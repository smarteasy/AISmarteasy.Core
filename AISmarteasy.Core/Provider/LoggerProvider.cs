using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace AISmarteasy.Core;

public static class LoggerProvider
{
    public static ILogger Default => NullLogger.Instance;
}

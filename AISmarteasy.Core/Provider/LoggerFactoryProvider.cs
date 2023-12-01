using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace AISmarteasy.Core;

public static class LoggerFactoryProvider
{
    public static ILoggerFactory Default => NullLoggerFactory.Instance;
}

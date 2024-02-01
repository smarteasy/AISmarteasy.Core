using Microsoft.Extensions.Logging;

namespace AISmarteasy.Core;

public abstract class AIServiceConnector : IAIServiceConnector
{
    protected ILogger Logger { get; set; } = LoggerProvider.Provide();
}

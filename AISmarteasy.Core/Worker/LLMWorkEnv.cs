using Microsoft.Extensions.Logging;

namespace AISmarteasy.Core;

public class LLMWorkEnv(LLMVendorTypeKind vendor, string serviceAPIKey, LLMWorkTypeKind workType, ILogger logger)
{
    public static IWorkerContext WorkerContext { get; set; }
    public static IPluginStore? PluginStore { get; set; }

    static LLMWorkEnv()
    {
        WorkerContext = new WorkerContext(new VariableDictionary());
    }

    public LLMVendorTypeKind Vendor { get; set; } = vendor;
    public string ServiceAPIKey { get; set; } = serviceAPIKey;
    public LLMWorkTypeKind WorkType { get; set; } = workType;

    public ILogger Logger { get; set; } = logger;
}

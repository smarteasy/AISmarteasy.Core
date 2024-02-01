namespace AISmarteasy.Core;

public class LLMWorkEnv(AIWorkTypeKind workType, 
    AIServiceTypeKind aiServiceType, AIServiceVendorKind aiServiceVendor, string aiServiceAPIKey, 
    MemoryServiceTypeKind memoryServiceType = MemoryServiceTypeKind.Serverless, MemoryStoreTypeKind memoryStoreType = MemoryStoreTypeKind.Volatile, 
    MemoryServiceVendorKind memoryServiceVendor = MemoryServiceVendorKind.Pinecone, string? memoryServiceEnvironment = null, string? memoryServiceAPIKey = null) 
    : AIWorkEnv(aiServiceVendor)
{
    public static IPluginStore? PluginStore { get; set; }
    public string AIServiceAPIKey { get; } = aiServiceAPIKey;
    public AIWorkTypeKind WorkType { get; } = workType;
    public AIServiceTypeKind AIServiceType { get; } = aiServiceType;
    public MemoryServiceTypeKind MemoryServiceType { get; } = memoryServiceType;
    public MemoryStoreTypeKind MemoryStoreType { get; } = memoryStoreType;
    public MemoryServiceVendorKind MemoryServiceVendor { get; } = memoryServiceVendor;
    public string? MemoryServiceEnvironment { get; } = memoryServiceEnvironment;
    public string? MemoryServiceAPIKey { get; } = memoryServiceAPIKey;


    public static IWorkerContext WorkerContext { get; set; } = new WorkerContext(new VariableDictionary());
}

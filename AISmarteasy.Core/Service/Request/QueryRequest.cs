namespace AISmarteasy.Core;

public struct QueryRequest(ChatHistory chatHistory, LLMServiceSetting serviceSetting, string memoryCollectionName,
    string queryContent = "", bool isWithImage = false, 
    string memoryCollectionNamespace = "", bool isWithStreaming = false, int memoryTopK = 1, double memoryMinRelevanceScore = 0.8,  
    CancellationToken cancellationToken = default)
{
    public ChatHistory ChatHistory { get; set; } = chatHistory;
    public string QueryContent { get; set; } = queryContent;
    public LLMServiceSetting ServiceSetting { get; set; } = serviceSetting;
    public bool IsWithStreaming { get; set; } = isWithStreaming;
    public bool IsWithImage { get; set; } = isWithImage;
    public CancellationToken CancellationToken { get; set; } = cancellationToken;
    public string MemoryCollectionName { get; set; } = memoryCollectionName;
    public string MemoryCollectionNamespace { get; set; } = memoryCollectionNamespace;
    public int MemoryTopK { get; set; }= memoryTopK;
    public double MemoryRelevanceScore { get; set; } = memoryMinRelevanceScore;

}
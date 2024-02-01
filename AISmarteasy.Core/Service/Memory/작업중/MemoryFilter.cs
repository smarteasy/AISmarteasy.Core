namespace AISmarteasy.Core;

public class MemoryFilter : MemoryTagCollection
{
    public bool IsEmpty()
    {
        return Count == 0;
    }

    public MemoryFilter ByTag(string name, string value)
    {
        Add(name, value);
        return this;
    }

    public MemoryFilter ByDocument(string docId)
    {
        Add(MemoryConstants.RESERVED_DOCUMENT_ID_TAG, docId);
        return this;
    }

    public IEnumerable<KeyValuePair<string, string?>> GetFilters()
    {
        return ToKeyValueList();
    }
}

public static class MemoryFilters
{
    public static MemoryFilter ByTag(string name, string value)
    {
        return new MemoryFilter().ByTag(name, value);
    }

    public static MemoryFilter ByDocument(string docId)
    {
        return new MemoryFilter().ByDocument(docId);
    }
}

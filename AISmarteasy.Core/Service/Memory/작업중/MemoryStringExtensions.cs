namespace AISmarteasy.Core;

public static class MemoryStringExtensions
{
    public static string CleanName(this string? name)
    {
        if (name == null) { return MemoryConstants.DEFAULT_INDEX; }
        name = name.Trim();
        return string.IsNullOrEmpty(name) ? MemoryConstants.DEFAULT_INDEX : name;
    }
}

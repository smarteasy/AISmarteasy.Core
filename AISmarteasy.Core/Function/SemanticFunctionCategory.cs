using Microsoft.Extensions.Logging;

namespace AISmarteasy.Core;

public class SemanticFunctionCategory(string name, string content, ILogger logger)
{
    public string Name { get; init; } = name;
    public string Content { get; init; } = content;
    public readonly List<SemanticFunctionCategory> SubCategories = new();

    public void AddSubCategory(SemanticFunctionCategory subCategory)
    {
        SubCategories.Add(subCategory);
    }
}

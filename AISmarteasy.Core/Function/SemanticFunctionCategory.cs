using Microsoft.Extensions.Logging;

namespace AISmarteasy.Core;

public class SemanticFunctionCategory(string fullyQualifiedName, string name, string content)
{
    public string FullyQualifiedName { get; init; } = fullyQualifiedName;
    public string Name { get; init; } = name;
    public string Content { get; init; } = content;
    public readonly List<SemanticFunctionCategory> SubCategories = new();

    public void AddSubCategory(SemanticFunctionCategory subCategory)
    {
        SubCategories.Add(subCategory);
    }
}

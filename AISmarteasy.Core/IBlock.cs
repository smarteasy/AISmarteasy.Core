namespace AISmarteasy.Core;

public interface IBlock
{
    BlockTypeKind Type { get; }
    string Content { get; }

    string Render(ContextVariableDictionary? variables);
    bool IsValid(out string errorMsg);
}

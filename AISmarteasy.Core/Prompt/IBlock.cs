namespace AISmarteasy.Core;

public interface IBlock
{
    BlockTypeKind Type { get; }
    string Content { get; }

    string Render(ContextVariableDictionary? variables);

    Task<string> RenderAsync(ContextVariableDictionary variables, bool isNeedFunctionRun, CancellationToken cancellationToken = default);
    
    bool IsValid(out string errorMsg);
}

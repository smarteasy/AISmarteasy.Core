namespace AISmarteasy.Core;

public interface IBlock
{
    BlockTypeKind Type { get; }
    string Content { get; }

    string Render(VariableDictionary? variables);

    Task<string> RenderAsync(ITextCompletionConnector serviceConnector, VariableDictionary variables, bool isNeedFunctionRun, CancellationToken cancellationToken = default);
    
    bool IsValid(out string errorMsg);
}

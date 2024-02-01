namespace AISmarteasy.Core;

public class TextPartitioningOptions
{
    public int MaxTokensPerParagraph { get; set; } = 1000;

    public int MaxTokensPerLine { get; set; } = 300;

    public int OverlappingTokens { get; set; } = 100;

    public void Validate()
    {
        if (MaxTokensPerParagraph < 1)
        {
            throw new CoreException("The number of tokens per paragraph cannot be less than 1");
        }

        if (MaxTokensPerLine < 1)
        {
            throw new CoreException("The number of tokens per line cannot be less than 1");
        }

        if (OverlappingTokens < 0)
        {
            throw new CoreException("The number of overlapping tokens cannot be less than 0");
        }

        if (MaxTokensPerLine > MaxTokensPerParagraph)
        {
            throw new CoreException("The number of tokens per line cannot be more than the tokens per paragraph");
        }

        if (OverlappingTokens >= MaxTokensPerParagraph)
        {
            throw new CoreException("The number of overlapping tokens must be less than the tokens per paragraph");
        }
    }
}

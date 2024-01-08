namespace AISmarteasy.Core;

public readonly struct ImageGenerationRequest(string imageDescription, int width, int height)
{
    public string ImageDescription { get; } = imageDescription;
    public int Width { get; } = width;
    public int Height { get; } = height;
}

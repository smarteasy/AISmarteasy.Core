namespace AISmarteasy.Core;

public abstract class ChatMessageBase(AuthorRole role, string content)
{
    public AuthorRole Role { get; set; } = role;
    public string Content { get; set; } = content;
}
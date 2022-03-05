namespace TumblrClient.Core.Utils
{
    public enum PostType
    {
        Any,
        Text,
        Quote,
        Link,
        Answer,
        Video,
        Audio,
        Photo,
        Chat
    }

    public static class PostTypeExtension
    {
        public static string GetText(this PostType postType)
        {
            return postType switch
            {
                PostType.Text => "text",
                PostType.Quote => "quote",
                PostType.Link => "link",
                PostType.Answer => "answer",
                PostType.Video => "video",
                PostType.Audio => "audio",
                PostType.Photo => "photo",
                PostType.Chat => "chat",
                _ => string.Empty
            };
        }
    }
}

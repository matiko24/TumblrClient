using System;
using TumblrClient.Core.Utils;

namespace TumblrClient.Core.Models.Posts
{
    public class PostFactory
    {
        public static Post CretePost(PostType postType)
        {
            return postType switch
            {
                PostType.Text => new TextPost(),
                PostType.Link => new LinkPost(),
                PostType.Quote => new QuotePost(),
                PostType.Chat => new ChatPost(),
                PostType.Audio => new AudioPost(),
                PostType.Photo => new PhotoPost(),
                PostType.Video => new VideoPost(),
                PostType.Answer => new AnswerPost(),
                _ => throw new InvalidOperationException($"Invalid post type")
            };
        }
    }
}

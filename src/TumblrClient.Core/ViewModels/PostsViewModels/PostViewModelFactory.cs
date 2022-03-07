using System;
using TumblrClient.Core.Models.Posts;
using TumblrClient.Core.Utils;

namespace TumblrClient.Core.ViewModels.PostsViewModels
{
    public class PostViewModelFactory
    {
        public static PostViewModel CreatePostViewModel(Post post)
        {
            return post.Type switch
            {
                PostType.Link => new LinkPostViewModel((LinkPost) post),
                PostType.Quote => new QuotePostViewModel((QuotePost) post),
                PostType.Photo => new PhotoPostViewModel((PhotoPost) post),
                PostType.Text => new TextPostViewModel((TextPost) post),
                PostType.Answer => new AnswerPostViewModel(post),
                PostType.Video => new ViedeoPostViewModel(post),
                PostType.Chat => new ChatPostViewModel(post),
                PostType.Audio => new AudioPostViewModel(post),
                _ => throw new InvalidOperationException("Can't create model for this post type")
            };
        }
    }
}

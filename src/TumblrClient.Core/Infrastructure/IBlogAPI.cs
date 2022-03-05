using System.Threading.Tasks;
using Refit;
using TumblrClient.Core.Models;

namespace TumblrClient.Core.Infrastructure
{
    public interface IBlogAPI
    {
        [Get("/blog/{blogIdentifier}.tumblr.com/posts/{postsType}?api_key=qhU2Ip6zF0bRL8fTukmRE6Fh54IJIifIVlhxu4UX1sXttXxnIY")]
        Task<Response<BlogWithPosts>> GetPosts([AliasAs("blogIdentifier")] string blogIdentifier, [AliasAs("postsType")] string postsType);
    }
}

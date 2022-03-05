using System.Threading.Tasks;
using TumblrClient.Core.Models;

namespace TumblrClient.Core.Infrastructure
{
    public interface IBlogService
    {
        Task<BlogWithPosts> GetPosts(PostsFilters filters);
    }
}

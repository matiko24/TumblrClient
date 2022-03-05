using System;
using System.Net;
using System.Threading.Tasks;
using TumblrClient.Core.Models;
using TumblrClient.Core.Utils;

namespace TumblrClient.Core.Infrastructure
{
    public class BlogService : IBlogService
    {
        private IBlogAPI _blogAPI;

        public BlogService(IBlogAPI postsAPI)
        {
            _blogAPI = postsAPI;
        }

        public async Task<BlogWithPosts> GetPosts(PostsFilters filters)
        {
            try
            {
                var result = await _blogAPI.GetPosts(filters.BlogIdentifier, filters.Type.GetText());

                if (result.MetaInformations.Status != HttpStatusCode.OK)
                {
                }

                return result.Data;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}

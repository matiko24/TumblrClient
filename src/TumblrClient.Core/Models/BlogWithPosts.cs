using System.Collections.Generic;
using Newtonsoft.Json;
using TumblrClient.Core.Models.Posts;

namespace TumblrClient.Core.Models
{
    public class BlogWithPosts
    {
        [JsonProperty("blog")]
        public Blog Blog { get; set; }

        [JsonProperty("posts")]
        public IEnumerable<Post> Posts { get; set; }

        [JsonProperty("total_posts")]
        public long PostsNumber { get; set; }
    }
}

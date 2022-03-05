using System.Collections.Generic;
using TumblrClient.Core.Utils;

namespace TumblrClient.Core.Models
{
    public class PostsFilters
    {
        public string BlogIdentifier { get; set; }
        public PostType Type { get; set; }
        public List<string> Tags { get; set; }
        public int Limit { get; set; }
        public int Offset { get; set; }

        public PostsFilters()
        {
            Type = PostType.Any;
        }
    }
}

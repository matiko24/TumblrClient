using Newtonsoft.Json;

namespace TumblrClient.Core.Models.Posts
{
    public class LinkPost : Post
    {
        [JsonProperty("url")]
        public string LinkUrl { get; set; }
    }
}

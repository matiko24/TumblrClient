using Newtonsoft.Json;

namespace TumblrClient.Core.Models.Posts
{
    public class LinkPost : BasePost
    {
        [JsonProperty("url")]
        public string LinkUrl { get; set; }
    }
}

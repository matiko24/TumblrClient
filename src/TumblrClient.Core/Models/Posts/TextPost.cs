using Newtonsoft.Json;

namespace TumblrClient.Core.Models.Posts
{
    public class TextPost : Post
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }
    }
}

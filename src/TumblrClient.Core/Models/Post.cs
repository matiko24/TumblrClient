using Newtonsoft.Json;

namespace TumblrClient.Core.Models
{
    public class Post
    {
        [JsonProperty("blog_name")]
        public string BlogName { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("post_url")]
        public string Url { get; set; }

        [JsonProperty("liked")]
        public bool Liked { get; set; }
    }
}

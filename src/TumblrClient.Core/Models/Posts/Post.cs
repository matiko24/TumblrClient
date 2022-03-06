using Newtonsoft.Json;

namespace TumblrClient.Core.Models.Posts
{
    public abstract class Post
    {
        [JsonProperty("blog_name")]
        public string BlogName { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("post_url")]
        public string Url { get; set; }

        [JsonProperty("liked")]
        public bool Liked { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}

using Newtonsoft.Json;

namespace TumblrClient.Core.Models.Posts
{
    public class QuotePost : BasePost
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }
    }
}

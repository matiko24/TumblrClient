using Newtonsoft.Json;

namespace TumblrClient.Core.Models.Posts
{
    public class VideoPost : BasePost
    {
        [JsonProperty("embeded_code")]
        public string EmbededCode { get; set; }
    }
}

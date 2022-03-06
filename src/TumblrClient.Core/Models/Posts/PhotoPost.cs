using Newtonsoft.Json;

namespace TumblrClient.Core.Models.Posts
{
    public class PhotoPost : BasePost
    {
        [JsonProperty("image_permalink")]
        public string PhotoUrl { get; set; }
    }
}

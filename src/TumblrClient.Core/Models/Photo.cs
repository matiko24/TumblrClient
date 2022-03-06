using Newtonsoft.Json;

namespace TumblrClient.Core.Models
{
    public class Photo
    {
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}

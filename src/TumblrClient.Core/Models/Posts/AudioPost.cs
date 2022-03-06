using System;
using Newtonsoft.Json;

namespace TumblrClient.Core.Models.Posts
{
    public class AudioPost : Post
    {
        [JsonProperty("artist")]
        public string Artist { get; set; }
    }
}

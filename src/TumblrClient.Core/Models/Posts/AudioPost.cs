using System;
using Newtonsoft.Json;

namespace TumblrClient.Core.Models.Posts
{
    public class AudioPost : BasePost
    {
        [JsonProperty("artist")]
        public string Artist { get; set; }
    }
}

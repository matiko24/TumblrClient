using System;
using Newtonsoft.Json;

namespace TumblrClient.Core.Models
{
    public class Blog
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}

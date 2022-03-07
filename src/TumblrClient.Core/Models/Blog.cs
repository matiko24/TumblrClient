using System.Collections.Generic;
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

        [JsonProperty("avatar")]
        public IEnumerable<Photo> Avatars { get; set; }
    }
}

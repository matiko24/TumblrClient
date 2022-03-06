using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TumblrClient.Core.Models
{
    public class PhotoSet
    {
        [JsonProperty("caption")]
        public string Caption { get; set; }

        [JsonProperty("alt_sizes")]
        public IList<Photo> Photos { get; set; }
    }
}

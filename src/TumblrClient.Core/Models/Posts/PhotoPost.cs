using System.Collections.Generic;
using Newtonsoft.Json;

namespace TumblrClient.Core.Models.Posts
{
    public class PhotoPost : BasePost
    {
        [JsonProperty("photos")]
        public IList<PhotoSet> Photoset { get; set; }
    }
}

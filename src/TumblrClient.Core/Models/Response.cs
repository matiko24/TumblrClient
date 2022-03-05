using System.Net;
using Newtonsoft.Json;

namespace TumblrClient.Core.Models
{
    public class Response<T>
    {
        [JsonProperty("meta")]
        public Meta MetaInformations { get; set; }

        [JsonProperty("response")]
        public T Data { get; set; }

        public class Meta
        {
            [JsonProperty("status")]
            public HttpStatusCode Status { get; set; }
            [JsonProperty("msg")]
            public string Message { get; set; }
        }
    }
}

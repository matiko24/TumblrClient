using Newtonsoft.Json;

namespace TumblrClient.Core.Models.Posts
{
    public class AnswerPost : Post
    {
        [JsonProperty("asking_name")]
        public string AskingName { get; set; }
    }
}

using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TumblrClient.Core.Models.Posts;

namespace TumblrClient.Core.Utils
{
    public class PostsJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(BasePost).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jObject = JObject.Load(reader);
            var type = jObject.GetValue("type");
            var postType = PostTypeExtension.ToPostType(type.ToString());

            BasePost postObject = postType switch
            {
                PostType.Text => new TextPost(),
                PostType.Link => new LinkPost(),
                PostType.Quote => new QuotePost(),
                PostType.Chat => new ChatPost(),
                PostType.Audio => new AudioPost(),
                PostType.Photo => new PhotoPost(),
                PostType.Video => new VideoPost(),
                PostType.Answer => new AnswerPost(),
                _ => throw new NotImplementedException()
            };

            serializer.Populate(jObject.CreateReader(), postObject);

            return postObject;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}

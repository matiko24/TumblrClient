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
            return typeof(Post).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jObject = JObject.Load(reader);
            var type = jObject.GetValue("type");
            var postType = PostTypeExtension.ToPostType(type.ToString());
            var post = PostFactory.CretePost(postType);

            serializer.Populate(jObject.CreateReader(), post);
            post.Type = postType;

            return post;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}

using TumblrClient.Core.Models.Posts;

namespace TumblrClient.Core.ViewModels.PostsViewModels
{
    public class PhotoPostViewModel : PostViewModel
    {
        public string PhotoUrl { get; private set; }
        public int Height { get; private set; }

        public PhotoPostViewModel(PhotoPost photoPost) : base(photoPost)
        {
            var photo = photoPost.Photoset[0].Photos[0];

            PhotoUrl = photo.Url;
            Height = photo.Height;
        }
    }
}

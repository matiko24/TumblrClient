using TumblrClient.Core.Models.Posts;

namespace TumblrClient.Core.ViewModels.PostsViewModels
{
    public class PhotoPostViewModel : PostViewModel
    {
        public string PhotoUrl { get; private set; }

        public PhotoPostViewModel(PhotoPost photoPost) : base(photoPost)
        {
            PhotoUrl = photoPost.Photoset[0].Photos[0].Url;
        }
    }
}

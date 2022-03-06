using TumblrClient.Core.Models.Posts;

namespace TumblrClient.Core.ViewModels.PostsViewModels
{
    public class LinkPostViewModel : PostViewModel
    {
        public string LinkUrl { get; private set; }

        public LinkPostViewModel(LinkPost linkPost) : base(linkPost)
        {
            LinkUrl = linkPost.LinkUrl;
        }
    }
}

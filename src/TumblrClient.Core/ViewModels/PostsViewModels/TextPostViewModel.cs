using TumblrClient.Core.Models.Posts;

namespace TumblrClient.Core.ViewModels.PostsViewModels
{
    public class TextPostViewModel : PostViewModel
    {
        public string Text { get; private set; }

        public TextPostViewModel(TextPost textPost) : base(textPost)
        {
            Text = textPost.Title;
        }
    }
}

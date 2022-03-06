using TumblrClient.Core.Models.Posts;

namespace TumblrClient.Core.ViewModels.PostsViewModels
{
    public class QuotePostViewModel : PostViewModel
    {
        public string Quote { get; private set; }

        public QuotePostViewModel(QuotePost quotePost) : base(quotePost)
        {
            Quote = quotePost.Text;
        }
    }
}

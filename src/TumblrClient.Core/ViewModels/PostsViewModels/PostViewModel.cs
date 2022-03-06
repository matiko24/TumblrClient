using MvvmCross.Commands;
using MvvmCross.ViewModels;
using TumblrClient.Core.Models.Posts;
using TumblrClient.Core.Utils;
using Xamarin.Essentials;

namespace TumblrClient.Core.ViewModels.PostsViewModels
{
    public abstract class PostViewModel : MvxViewModel
    {
        public bool Liked { get; set; }
        public string Url { get; private set; }
        public PostType Type { get; private set; }

        public IMvxCommand ShareCommand => new MvxAsyncCommand(async () =>
        {
            await Share.RequestAsync(new ShareTextRequest
            {
                Uri = Url,
                Title = "Udostępnij post"
            });
        });

        public IMvxCommand LikeCommand => new MvxCommand(() =>
        {
        });

        public PostViewModel(Post post)
        {
            Url = post.Url;
            Liked = post.Liked;
            Type = PostTypeExtension.ToPostType(post.Type);
        }
    }
}

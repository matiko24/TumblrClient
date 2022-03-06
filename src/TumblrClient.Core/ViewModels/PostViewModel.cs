using MvvmCross.Commands;
using MvvmCross.ViewModels;
using TumblrClient.Core.Models.Posts;
using Xamarin.Essentials;

namespace TumblrClient.Core.ViewModels
{
    public class PostViewModel<T> : MvxViewModel where T : BasePost
    {
        public T Post { get; set; }

        public IMvxCommand ShareCommand => new MvxAsyncCommand(async () =>
        {
            await Share.RequestAsync(new ShareTextRequest
            {
                Uri = Post.Url,
                Title = "Udostępnij post"
            });
        });

        public IMvxCommand LikeCommand => new MvxCommand(() =>
        {
        });

        public PostViewModel(T post)
        {
            Post = post;
        }
    }
}

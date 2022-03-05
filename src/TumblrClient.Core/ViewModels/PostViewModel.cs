using MvvmCross.Commands;
using MvvmCross.ViewModels;
using TumblrClient.Core.Models;
using Xamarin.Essentials;

namespace TumblrClient.Core.ViewModels
{
    public class PostViewModel : MvxViewModel
    {
        public Post Post { get; set; }

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

        public PostViewModel(Post post)
        {
            Post = post;
        }
    }
}

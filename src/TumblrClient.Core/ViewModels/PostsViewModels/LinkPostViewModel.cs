using MvvmCross;
using MvvmCross.Commands;
using MvvmCross.Plugin.WebBrowser;
using TumblrClient.Core.Models.Posts;

namespace TumblrClient.Core.ViewModels.PostsViewModels
{
    public class LinkPostViewModel : PostViewModel
    {
        public string LinkUrl { get; private set; }

        public IMvxCommand OpenLinkCommand => new MvxCommand(() =>
        {
            var task = Mvx.IoCProvider.Resolve<IMvxWebBrowserTask>();

            task.ShowWebPage(LinkUrl);
        });

        public LinkPostViewModel(LinkPost linkPost) : base(linkPost)
        {
            LinkUrl = linkPost.LinkUrl;
        }
    }
}

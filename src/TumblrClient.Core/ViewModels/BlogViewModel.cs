using System.Linq;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using TumblrClient.Core.Models;

namespace TumblrClient.Core.ViewModels
{
    public class BlogViewModel : MvxViewModel<BlogWithPosts>
    {
        private IMvxNavigationService _navigationService;
        private BlogWithPosts _blogWithPosts;

        public string Title => _blogWithPosts.Blog.Name;

        public MvxObservableCollection<PostViewModel> ItemsSource { get; set; }

        public BlogViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public override void Prepare(BlogWithPosts parameter)
        {
            _blogWithPosts = parameter;

            var postsViewModels = _blogWithPosts.Posts.Select(p => new PostViewModel(p));
            ItemsSource = new MvxObservableCollection<PostViewModel>(postsViewModels);
        }

        public void Close()
        {
            _navigationService.Close(this);
        }
    }
}

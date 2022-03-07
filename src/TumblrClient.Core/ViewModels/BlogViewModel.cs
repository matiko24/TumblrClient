using System.Collections.Generic;
using System.Linq;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using TumblrClient.Core.Infrastructure;
using TumblrClient.Core.Models;
using TumblrClient.Core.ViewModels.PostsViewModels;

namespace TumblrClient.Core.ViewModels
{
    public class BlogViewModel : MvxViewModel<BlogWithPosts>
    {
        private IBlogService _blogService;
        private IMvxNavigationService _navigationService;
        private BlogWithPosts _blogWithPosts;

        public string Title => _blogWithPosts.Blog.Name;

        public MvxObservableCollection<PostViewModel> Posts { get; set; }

        public BlogViewModel(IMvxNavigationService navigationService, IBlogService blogService)
        {
            _navigationService = navigationService;
            _blogService = blogService;
        }

        public override void Prepare(BlogWithPosts parameter)
        {
            _blogWithPosts = parameter;
            InitializeItems();
        }

        private void InitializeItems()
        {
            var postsViewModels = new List<PostViewModel>();
            var blogAvatarPhoto = _blogWithPosts.Blog.Avatars.ElementAt(0);

            foreach(var post in _blogWithPosts.Posts)
            {
                var postViewModel = PostViewModelFactory.CreatePostViewModel(post);

                postViewModel.AvatarUrl = blogAvatarPhoto.Url;
                postsViewModels.Add(postViewModel);
            }

            Posts = new MvxObservableCollection<PostViewModel>(postsViewModels);
        }

        public void LoadMorePosts()
        {
        }

        public void Close()
        {
            _navigationService.Close(this);
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using TumblrClient.Core.Infrastructure;
using TumblrClient.Core.Models;
using TumblrClient.Core.Utils;
using TumblrClient.Core.ViewModels.PostsViewModels;

namespace TumblrClient.Core.ViewModels
{
    public class BlogViewModel : MvxViewModel<BlogWithPosts>
    {
        private IBlogService _blogService;
        private IMvxNavigationService _navigationService;
        private IAppDialogs _appDialogs;
        private BlogWithPosts _blogWithPosts;

        public string Title => _blogWithPosts.Blog.Title;
        public string Name => _blogWithPosts.Blog.Name;
        public string AvatarUrl => _blogWithPosts.Blog.Avatars.ElementAt(0).Url;

        public MvxObservableCollection<PostViewModel> Posts { get; set; }

        public IMvxAsyncCommand OpenFiltersCommand => new MvxAsyncCommand(async () =>
        {
            var postsFilters = new PostsFilters()
            {
                BlogIdentifier = Name
            };
            var result = await _navigationService.Navigate<FiltersViewModel, PostsFilters, ViewModelResult<bool>>(postsFilters);

            if(result == null || !result.Value)
            {
                return;
            }

            await ReloadPosts(postsFilters);
        });

        public BlogViewModel(IMvxNavigationService navigationService, IBlogService blogService, IAppDialogs appDialogs)
        {
            _navigationService = navigationService;
            _blogService = blogService;
            _appDialogs = appDialogs;
        }

        public override void Prepare(BlogWithPosts parameter)
        {
            _blogWithPosts = parameter;
            Posts = new MvxObservableCollection<PostViewModel>();
            InitializePosts();
        }

        private void InitializePosts()
        {
            var postsViewModels = new List<PostViewModel>();
            var blogAvatarPhoto = _blogWithPosts.Blog.Avatars.ElementAt(0);

            foreach(var post in _blogWithPosts.Posts)
            {
                var postViewModel = PostViewModelFactory.CreatePostViewModel(post);

                postViewModel.AvatarUrl = blogAvatarPhoto.Url;
                postsViewModels.Add(postViewModel);
            }

            Posts.Clear();
            Posts.AddRange(postsViewModels);
        }

        private async Task ReloadPosts(PostsFilters postsFilters)
        {
            _appDialogs.ShowLoading();
            var newBlogWithPosts = await _blogService.GetPosts(postsFilters);
            _appDialogs.HideLoading();

            if(newBlogWithPosts == null)
            {
                _appDialogs.ShowToast("Coś poszło nie tak :( Spróbuj ponownie");
            }

            _blogWithPosts = newBlogWithPosts;
            InitializePosts();
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

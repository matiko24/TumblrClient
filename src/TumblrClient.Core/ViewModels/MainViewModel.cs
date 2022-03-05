using MvvmCross.Commands;
using MvvmCross.Navigation;
using TumblrClient.Core.Infrastructure;
using TumblrClient.Core.Models;

namespace TumblrClient.Core.ViewModels.Main
{
    public class MainViewModel : BaseViewModel
    {
        private IAppDialogs _appDialogs;
        private IBlogService _blogService;
        private IMvxNavigationService _navigationService;

        public bool IsNextButtonVisible => !string.IsNullOrEmpty(SearchingBlogName);

        private string _searchingBlogName;
        public string SearchingBlogName
        {
            get => _searchingBlogName;
            set
            {
                _searchingBlogName = value;
                RaisePropertyChanged(() => SearchingBlogName);
                RaisePropertyChanged(() => IsNextButtonVisible);
            }
        }

        public IMvxCommand NextButtonClickCommand => new MvxAsyncCommand(async () =>
        {
            var filters = new PostsFilters
            {
                BlogIdentifier = SearchingBlogName
            };

            _appDialogs.ShowLoading("Szukam");
            var posts = await _blogService.GetPosts(filters);
            _appDialogs.HideLoading();

            if (posts == null)
            {
                _appDialogs.ShowToast("Niestety taki blog nie istnieje :(");
                return;
            }

            await _navigationService.Navigate<BlogViewModel, BlogWithPosts>(posts);
            SearchingBlogName = string.Empty;
        });

        public MainViewModel(IMvxNavigationService navigationService, IBlogService postsService, IAppDialogs appDialogs)
        {
            _navigationService = navigationService;
            _blogService = postsService;
            _appDialogs = appDialogs;
        }
    }
}

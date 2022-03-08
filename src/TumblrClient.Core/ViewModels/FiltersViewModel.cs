using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using TumblrClient.Core.Models;
using TumblrClient.Core.Utils;

namespace TumblrClient.Core.ViewModels
{
    public class FiltersViewModel : MvxViewModel<PostsFilters, ViewModelResult<bool>>
    {
        private IMvxNavigationService _navigationService;
        private PostsFilters _postsFilters;

        public MvxObservableCollection<StringWithId> Items { get; set; }

        public IMvxCommand PostTypeSelectedCommand => new MvxAsyncCommand<StringWithId>(async (StringWithId selectedType) =>
        {
            _postsFilters.Type = (PostType) selectedType.Id;

            await _navigationService.Close(this, new ViewModelResult<bool>(true));
        });

        public FiltersViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public override void Prepare(PostsFilters parameter)
        {
            _postsFilters = parameter;
            InitializeItems();
        }

        private void InitializeItems()
        {
            Items = new MvxObservableCollection<StringWithId>
            {
                new StringWithId { Name = "Wszystkie", Id = (int)PostType.Any},
                new StringWithId { Name = "Tekst", Id = (int)PostType.Text},
                new StringWithId { Name = "Zdjęcie", Id = (int)PostType.Photo},
                new StringWithId { Name = "Cytat", Id = (int)PostType.Quote},
                new StringWithId { Name = "Link", Id = (int)PostType.Link}
            };
        }

        public void Close()
        {
            _navigationService.Close(this);
        }
    }
}

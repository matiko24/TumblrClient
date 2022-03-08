using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using TumblrClient.Core.ViewModels;
using TumblrClient.iOS.Sources;
using UIKit;

namespace TumblrClient.iOS.Views
{
    [MvxModalPresentation(WrapInNavigationController = true)]
    public partial class BlogView : BaseViewController<BlogViewModel>
    {
        private PostsSource _source;

        protected override void CreateView()
        {
            Title = ViewModel.Title;
            NavigationItem.LeftBarButtonItem = new UIBarButtonItem("Zamknij", UIBarButtonItemStyle.Done, (s, e) => { ViewModel.Close(); });
            NavigationItem.RightBarButtonItem = new UIBarButtonItem("Filtruj", UIBarButtonItemStyle.Plain, (s, e) => { ViewModel.OpenFiltersCommand.Execute(); });

            _source = new PostsSource(TableView);
            TableView.Source = _source;
        }

        protected override void BindView()
        {
            var set = this.CreateBindingSet<BlogView, BlogViewModel>();

            set.Bind(_source).For(v => v.ItemsSource).To(vm => vm.Posts);

            set.Apply();
        }
    }
}


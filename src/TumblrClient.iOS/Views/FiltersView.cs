using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Binding.Views;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using TumblrClient.Core.ViewModels;
using UIKit;

namespace TumblrClient.iOS.Views
{
    [MvxModalPresentation(WrapInNavigationController = true)]
    public partial class FiltersView : BaseViewController<FiltersViewModel>
    {
        private MvxStandardTableViewSource _source;

        protected override void CreateView()
        {
            base.CreateView();

            Title = "Filtry";
            NavigationItem.LeftBarButtonItem = new UIBarButtonItem("Zamknij", UIBarButtonItemStyle.Done, (s, e) => { ViewModel.Close(); });

            _source = new MvxStandardTableViewSource(TableView);
            TableView.Source = _source;
        }

        protected override void LayoutView()
        {
            base.LayoutView();
            TableView.TableFooterView = new UIView();
        }

        protected override void BindView()
        {
            base.BindView();

            var set = this.CreateBindingSet<FiltersView, FiltersViewModel>();

            set.Bind(_source).For(v => v.ItemsSource).To(vm => vm.Items);
            set.Bind(_source).For(v => v.SelectionChangedCommand).To(vm => vm.PostTypeSelectedCommand);

            set.Apply();
        }
    }
}


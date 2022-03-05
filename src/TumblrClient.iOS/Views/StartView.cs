using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using TumblrClient.Core.Converters;
using TumblrClient.Core.ViewModels.Main;

namespace TumblrClient.iOS.Views
{
    [MvxRootPresentation]
    public partial class StartView : BaseViewController<MainViewModel>
    {
        protected override void BindView()
        {
            var set = this.CreateBindingSet<StartView, MainViewModel>();

            set.Bind(SearchingBlogName).For(v => v.Text).To(vm => vm.SearchingBlogName);
            set.Bind(NextButton).For(v => v.Hidden).To(vm => vm.IsNextButtonVisible).WithConversion<NotConverter>();
            set.Bind(NextButton).To(vm => vm.NextButtonClickCommand);

            set.Apply();
        }
    }
}


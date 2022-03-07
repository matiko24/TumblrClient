using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using TumblrClient.Core.Converters;
using TumblrClient.Core.ViewModels.Main;
using UIKit;

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

        protected override void CreateView()
        {
            base.CreateView();

            NSNotificationCenter.DefaultCenter.AddObserver(UIKeyboard.DidShowNotification, KeyBoardUpNotification);
            NSNotificationCenter.DefaultCenter.AddObserver(UIKeyboard.WillHideNotification, KeyBoardDownNotification);
        }

        protected void KeyBoardUpNotification(NSNotification notification)
        {
            var size = UIKeyboard.BoundsFromNotification(notification);
            var contentInsets = new UIEdgeInsets(0, 0, size.Height, 0);

            ScrollView.ContentInset = contentInsets;
            ScrollView.ScrollIndicatorInsets = contentInsets;
        }

        protected void KeyBoardDownNotification(NSNotification notification)
        {
            var contentInsets = new UIEdgeInsets(0, 0, 0, 0);

            ScrollView.ContentInset = contentInsets;
            ScrollView.ScrollIndicatorInsets = contentInsets;
        }
    }
}


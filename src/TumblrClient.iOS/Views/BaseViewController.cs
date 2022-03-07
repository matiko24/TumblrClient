using Cirrious.FluentLayouts.Touch;
using MvvmCross.Platforms.Ios.Views;
using MvvmCross.ViewModels;
using UIKit;

namespace TumblrClient.iOS.Views
{
    public abstract class BaseViewController<TViewModel> : MvxViewController<TViewModel>
        where TViewModel : class, IMvxViewModel
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            View.BackgroundColor = UIColor.White;

            SetApperances();
            AddTapRecognizer();
            CreateView();
            LayoutView();
            BindView();
        }

        private void AddTapRecognizer()
        {
            var tapRecognizer = new UITapGestureRecognizer(() => { View.EndEditing(true); })
            {
                CancelsTouchesInView = false
            };

            View.AddGestureRecognizer(tapRecognizer);
        }

        private void SetApperances()
        {
            if(NavigationController == null)
            {
                return;
            }

            var appearance = new UINavigationBarAppearance
            {
                BackgroundColor = UIColor.Clear,
                TitleTextAttributes = new UIStringAttributes
                {
                    Font = UIFont.SystemFontOfSize(17, UIFontWeight.Semibold),
                    ForegroundColor = UIColor.Black,
                }
            };

            appearance.ConfigureWithOpaqueBackground();

            NavigationController.NavigationBar.StandardAppearance = appearance;
            NavigationController.NavigationBar.ScrollEdgeAppearance = appearance;
            NavigationController.NavigationBar.Translucent = false;
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();
        }

        protected virtual void CreateView()
        {
        }

        protected virtual void LayoutView()
        {
        }

        protected virtual void BindView()
        {
        }
    }
}

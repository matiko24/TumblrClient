using Cirrious.FluentLayouts.Touch;
using MvvmCross.Platforms.Ios.Views;
using MvvmCross.ViewModels;
using TumblrClient.iOS.Styles;
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

            if (NavigationController != null)
            {
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

            CreateView();
            LayoutView();
            BindView();
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

using Foundation;
using MvvmCross.Platforms.Ios.Core;
using TumblrClient.Core;

namespace TumblrClient.iOS
{
    [Register(nameof(AppDelegate))]
    public class AppDelegate : MvxApplicationDelegate<Setup, App>
    {
    }
}

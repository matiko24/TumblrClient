
using Android.App;
using MvvmCross.Platforms.Android.Views;

namespace TumblrClient.Droid.Views.Splash
{
    [Activity(
        NoHistory = true,
        MainLauncher = true,
        Label = "@string/app_name",
        Theme = "@style/AppTheme.Splash")]
    public class SplashActivity : MvxSplashScreenActivity
    {
    }
}

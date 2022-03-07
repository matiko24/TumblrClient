
using Android.App;
using Android.OS;
using Android.Views;
using TumblrClient.Core.ViewModels.Main;

namespace TumblrClient.Droid.Views
{
    [Activity(
        Theme = "@style/AppTheme",
        WindowSoftInputMode = SoftInput.AdjustResize | SoftInput.StateHidden)]
    public class MainActivity : BaseActivity<MainViewModel>
    {
        protected override int ActivityLayoutId => Resource.Layout.activity_main;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
        }
    }
}

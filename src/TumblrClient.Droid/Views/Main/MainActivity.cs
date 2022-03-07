using System;

using Android.App;
using Android.OS;
using Android.Views;
using Android.Views.InputMethods;
using TumblrClient.Core.ViewModels.Main;

namespace TumblrClient.Droid.Views.Main
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

        public void HideSoftKeyboard() => HideSoftKeyboard(this, EventArgs.Empty);

        private void HideSoftKeyboard(object sender, EventArgs args)
        {
            if(CurrentFocus != null)
            {
                var inputMethodManager = (InputMethodManager) GetSystemService(InputMethodService);
                inputMethodManager.HideSoftInputFromWindow(CurrentFocus.WindowToken, 0);

                CurrentFocus.ClearFocus();
            }
        }
    }
}

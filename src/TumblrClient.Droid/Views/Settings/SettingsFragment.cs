using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using TumblrClient.Core.ViewModels.Main;
using TumblrClient.Core.ViewModels.Settings;

namespace TumblrClient.Droid.Views.Settings
{
    [MvxFragmentPresentation(typeof(MainContainerViewModel), Resource.Id.content_frame, true)]
    public class SettingsFragment : BaseFragment<SettingsViewModel>
    {
        protected override int FragmentLayoutId => Resource.Layout.fragment_settings;
    }
}

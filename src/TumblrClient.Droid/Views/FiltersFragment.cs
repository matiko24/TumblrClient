using MvvmCross.Platforms.Android.Presenters.Attributes;
using TumblrClient.Core.ViewModels;

namespace TumblrClient.Droid.Views
{
    [MvxFragmentPresentation(typeof(BlogViewModel), Resource.Id.lyt_blog_activity_content_container, true)]
    public class FiltersFragment : BaseFragment<FiltersViewModel>
    {
        protected override int FragmentLayoutId => Resource.Layout.fragment_filters;

        public FiltersFragment()
        {
        }
    }
}


using Android.App;
using TumblrClient.Core.ViewModels;

namespace TumblrClient.Droid.Views
{
    [Activity]
    public class BlogActivity : BaseActivity<BlogViewModel>
    {
        protected override int ActivityLayoutId => Resource.Layout.activity_blog;
    }
}


using Android.App;
using Android.OS;
using Android.Views;
using AndroidX.AppCompat.Widget;
using TumblrClient.Core.ViewModels;

namespace TumblrClient.Droid.Views
{
    [Activity]
    public class BlogActivity : BaseActivity<BlogViewModel>
    {
        protected override int ActivityLayoutId => Resource.Layout.activity_blog;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            var toolbar = FindViewById<Toolbar>(Resource.Id.tb_blog_activity_toolbar);

            SetSupportActionBar(toolbar);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);
            SupportActionBar.Title = ViewModel.Name;
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_blog_activity, menu);

            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if(item.ItemId == Android.Resource.Id.Home)
            {
                Finish();
                return true;
            }
            else if(item.ItemId == Resource.Id.menu_item_filters)
            {
                ViewModel.OpenFiltersCommand.Execute();
                return true;
            }
            else
            {
                return base.OnOptionsItemSelected(item);
            }
        }
    }
}

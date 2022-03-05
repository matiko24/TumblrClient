using Foundation;
using MvvmCross.Platforms.Ios.Binding.Views;
using TumblrClient.iOS.Views.Cells;
using UIKit;

namespace TumblrClient.iOS.Sources
{
    public class PostsSource : MvxTableViewSource
    {
        public PostsSource(UITableView tableView) : base(tableView)
        {
            tableView.RegisterNibForCellReuse(PostViewCell.Nib, PostViewCell.Key);
        }

        protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath, object item)
        {
            return tableView.DequeueReusableCell(PostViewCell.Key);
        }
    }
}

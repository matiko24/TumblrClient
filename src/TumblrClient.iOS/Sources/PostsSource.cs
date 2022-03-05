using System;
using Foundation;
using MvvmCross.Platforms.Ios.Binding.Views;
using TumblrClient.Core.ViewModels;
using TumblrClient.iOS.Utils;
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

        public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
        {
            var item = GetItemAt(indexPath) as PostViewModel;
            var font = UIFont.SystemFontOfSize(17, UIFontWeight.Regular);
            var widht = TableView.Frame.Width - 32;
            var textheight = TextSizer.GetTextHeight(item.Post.Title, widht, font);

            return 90 + textheight;
        }
    }
}

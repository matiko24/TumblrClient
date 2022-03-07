using System;
using Foundation;
using MvvmCross.Platforms.Ios.Binding.Views;
using TumblrClient.Core.Utils;
using TumblrClient.Core.ViewModels.PostsViewModels;
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
            tableView.RegisterNibForCellReuse(PhotoPostViewCell.Nib, PhotoPostViewCell.Key);
            tableView.RegisterNibForCellReuse(QuotePostViewCell.Nib, QuotePostViewCell.Key);
            tableView.RegisterNibForCellReuse(LinkPostViewCell.Nib, LinkPostViewCell.Key);
        }

        protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath, object item)
        {
            var postViewModel = GetItemAt(indexPath) as PostViewModel;
            var cellIdentifier = postViewModel.Type switch
            {
                PostType.Text => PostViewCell.Key,
                PostType.Quote => QuotePostViewCell.Key,
                PostType.Link => LinkPostViewCell.Key,
                PostType.Answer => "answer",
                PostType.Video => "video",
                PostType.Audio => "audio",
                PostType.Photo => PhotoPostViewCell.Key,
                PostType.Chat => "chat",
                _ => string.Empty
            };

            return tableView.DequeueReusableCell(cellIdentifier);
        }

        public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
        {
            var postViewModel = GetItemAt(indexPath) as PostViewModel;
            var postType = postViewModel.Type;

            if(postType == PostType.Text)
            {
                var textPostViewModel = postViewModel as TextPostViewModel;
                var textheight = GetTextheight(textPostViewModel.Text);

                return 146 + textheight;
            }
            else if(postType == PostType.Photo)
            {
                var photoPostViewModel = postViewModel as PhotoPostViewModel;

                return 146 + photoPostViewModel.Height/3;
            }
            else if(postType == PostType.Quote)
            {
                var quotePostViewModel = postViewModel as QuotePostViewModel;
                var textheight = GetTextheight(quotePostViewModel.Quote);

                return 146 + textheight;
            }
            else if(postType == PostType.Link)
            {
                var linkPostViewModel = postViewModel as LinkPostViewModel;
                var textheight = GetTextheight(linkPostViewModel.LinkUrl);

                return 140 + textheight;
            }
            else
            {
                return 200;
            }
        }

        private nfloat GetTextheight(string text)
        {
            var font = UIFont.SystemFontOfSize(17, UIFontWeight.Regular);
            var widht = TableView.Frame.Width - 32;

            return TextSizer.GetTextHeight(text, widht, font);
        }
    }
}

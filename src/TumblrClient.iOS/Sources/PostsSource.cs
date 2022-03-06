using System;
using Foundation;
using MvvmCross.Platforms.Ios.Binding.Views;
using TumblrClient.Core.Models.Posts;
using TumblrClient.Core.Utils;
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
            tableView.RegisterNibForCellReuse(PhotoPostViewCell.Nib, PhotoPostViewCell.Key);
            tableView.RegisterNibForCellReuse(QuotePostViewCell.Nib, QuotePostViewCell.Key);
        }

        protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath, object item)
        {
            var basePostViewModel = GetItemAt(indexPath) as PostViewModel<BasePost>;
            var postType = PostTypeExtension.ToPostType(basePostViewModel.Post.Type);
            var cellIdentifier = postType switch
            {
                PostType.Text => PostViewCell.Key,
                PostType.Quote => QuotePostViewCell.Key,
                PostType.Link => "link",
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
            var postViewModel = GetItemAt(indexPath) as PostViewModel<BasePost>;
            var postType = PostTypeExtension.ToPostType(postViewModel.Post.Type);

            if(postType == PostType.Text)
            {
                var textPost = postViewModel.Post as TextPost;
                var font = UIFont.SystemFontOfSize(17, UIFontWeight.Regular);
                var widht = TableView.Frame.Width - 32;
                var textheight = TextSizer.GetTextHeight(textPost.Title, widht, font);

                return 90 + textheight;
            }
            else if(postType == PostType.Photo)
            {
                return 400;
            }
            else if(postType == PostType.Quote)
            {
                var quotePost = postViewModel.Post as QuotePost;
                var font = UIFont.SystemFontOfSize(17, UIFontWeight.Regular);
                var widht = TableView.Frame.Width - 32;
                var textheight = TextSizer.GetTextHeight(quotePost.Text, widht, font);

                return 90 + textheight;
            }
            else
            {
                return 200;
            }
        }
    }
}

using System;
using CoreAnimation;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Binding.Views;
using TumblrClient.Core.Models.Posts;
using TumblrClient.Core.ViewModels;
using UIKit;

namespace TumblrClient.iOS.Views.Cells
{
    [Register("QuotePostViewCell")]
    public partial class QuotePostViewCell : MvxTableViewCell
    {
        public static readonly NSString Key = new NSString("QuotePostViewCell");
        public static readonly UINib Nib = UINib.FromName("QuotePostViewCell", NSBundle.MainBundle);

        public QuotePostViewCell(IntPtr intPtr) : base(intPtr)
        {
            this.DelayBind(() =>
            {
                var set = this.CreateBindingSet<QuotePostViewCell, PostViewModel<QuotePost>>();

                set.Bind(Text).For(v => v.Text).To(vm => vm.Post.Text);
                set.Bind(Share).To(vm => vm.ShareCommand);

                set.Apply();
            });
        }

        public override void AwakeFromNib()
        {
            base.AwakeFromNib();

            Share.SetTitle(string.Empty, UIControlState.Normal);
            Like.SetTitle(string.Empty, UIControlState.Normal);

            Like.TouchUpInside += Like_TouchUpInside;
        }

        private void Like_TouchUpInside(object sender, EventArgs e)
        {
            var animation = CABasicAnimation.FromKeyPath("transform.scale");

            animation.Duration = 0.2;
            animation.To = NSNumber.FromFloat(1.5f);
            animation.TimingFunction = CAMediaTimingFunction.FromName(CAMediaTimingFunction.EaseInEaseOut);
            animation.AutoReverses = true;
            animation.RepeatCount = 1;

            animation.AnimationStarted += (s1, e1) =>
            {
                var postViewModel = DataContext as PostViewModel<BasePost>;

                postViewModel.Post.Liked = !postViewModel.Post.Liked;
                Like.TintColor = postViewModel.Post.Liked ? UIColor.Red : UIColor.DarkGray;
            };

            Like.Layer.AddAnimation(animation, "pulse");
        }
    }
}

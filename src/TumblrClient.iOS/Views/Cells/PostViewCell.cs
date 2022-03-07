using System;
using CoreAnimation;
using Foundation;
using MvvmCross.Platforms.Ios.Binding.Views;
using TumblrClient.Core.ViewModels.PostsViewModels;
using UIKit;

namespace TumblrClient.iOS.Views.Cells
{
    public abstract class PostViewCell : MvxTableViewCell
    {
        public abstract UIButton ShareButton { get; }
        public abstract UIButton LikeButton { get; }

        public PostViewCell(IntPtr intPtr) : base(intPtr)
        {
        }

        public override void AwakeFromNib()
        {
            base.AwakeFromNib();

            ShareButton.SetTitle(string.Empty, UIControlState.Normal);
            LikeButton.SetTitle(string.Empty, UIControlState.Normal);

            LikeButton.TouchUpInside += Like_TouchUpInside;
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
                var postViewModel = DataContext as PostViewModel;

                postViewModel.Liked = !postViewModel.Liked;
                LikeButton.TintColor = postViewModel.Liked ? UIColor.Red : UIColor.DarkGray;
            };

            LikeButton.Layer.AddAnimation(animation, "pulse");
        }
    }
}

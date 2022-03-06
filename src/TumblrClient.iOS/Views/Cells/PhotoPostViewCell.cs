using System;
using CoreAnimation;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Binding.Views;
using TumblrClient.Core.ViewModels.PostsViewModels;
using UIKit;

namespace TumblrClient.iOS.Views.Cells
{
    [Register("PhotoPostViewCell")]
    public partial class PhotoPostViewCell : MvxTableViewCell
    {
        public static readonly NSString Key = new NSString("PhotoPostViewCell");
        public static readonly UINib Nib = UINib.FromName("PhotoPostViewCell", NSBundle.MainBundle);

        public PhotoPostViewCell(IntPtr intPtr) : base(intPtr)
        {
            this.DelayBind(() =>
            {
                var set = this.CreateBindingSet<PhotoPostViewCell, PhotoPostViewModel>();

                set.Bind(Share).To(vm => vm.ShareCommand);
                set.Bind(Photo).For(v => v.ImagePath).To(vm => vm.PhotoUrl);

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
                var postViewModel = DataContext as PostViewModel;

                postViewModel.Liked = !postViewModel.Liked;
                Like.TintColor = postViewModel.Liked ? UIColor.Red : UIColor.DarkGray;
            };

            Like.Layer.AddAnimation(animation, "pulse");
        }
    }
}

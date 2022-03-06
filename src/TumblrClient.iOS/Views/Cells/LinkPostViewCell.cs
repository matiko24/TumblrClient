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
    [Register("LinkPostViewCell")]
    public partial class LinkPostViewCell : MvxTableViewCell
    {
        public static readonly NSString Key = new NSString("LinkPostViewCell");
        public static readonly UINib Nib = UINib.FromName("LinkPostViewCell", NSBundle.MainBundle);

        public LinkPostViewCell(IntPtr intPtr) : base(intPtr)
        {
            this.DelayBind(() =>
            {
                var set = this.CreateBindingSet<LinkPostViewCell, PostViewModel<LinkPost>>();

                set.Bind(LinkButton).For("Title").To(vm => vm.Post.LinkUrl);
                //set.Bind(LinkButton).To(vm => vm.OpenLinkCommand);
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

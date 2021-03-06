using System;
using Foundation;
using MvvmCross.Binding.BindingContext;
using TumblrClient.Core.ViewModels.PostsViewModels;
using UIKit;

namespace TumblrClient.iOS.Views.Cells
{
    [Register("PhotoPostViewCell")]
    public partial class PhotoPostViewCell : PostViewCell
    {
        public static readonly NSString Key = new NSString("PhotoPostViewCell");
        public static readonly UINib Nib = UINib.FromName("PhotoPostViewCell", NSBundle.MainBundle);

        public override UIButton ShareButton => Share;
        public override UIButton LikeButton => Like;

        public PhotoPostViewCell(IntPtr intPtr) : base(intPtr)
        {
            this.DelayBind(() =>
            {
                var set = this.CreateBindingSet<PhotoPostViewCell, PhotoPostViewModel>();

                set.Bind(Avatar).For(v => v.ImagePath).To(vm => vm.AvatarUrl);
                set.Bind(BlogName).For(v => v.Text).To(vm => vm.BlogName);

                set.Bind(Share).To(vm => vm.ShareCommand);
                set.Bind(Photo).For(v => v.ImagePath).To(vm => vm.PhotoUrl);

                set.Apply();
            });
        }
    }
}

using System;
using Foundation;
using MvvmCross.Binding.BindingContext;
using TumblrClient.Core.ViewModels.PostsViewModels;
using UIKit;

namespace TumblrClient.iOS.Views.Cells
{
    [Register("UnsupportedPostTypeViewCell")]
    public partial class UnsupportedPostTypeViewCell : PostViewCell
    {
        public static readonly NSString Key = new NSString("UnsupportedPostTypeViewCell");
        public static readonly UINib Nib = UINib.FromName("UnsupportedPostTypeViewCell", NSBundle.MainBundle);

        public override UIButton ShareButton => Share;
        public override UIButton LikeButton => Like;

        public UnsupportedPostTypeViewCell(IntPtr intPtr) : base(intPtr)
        {
            this.DelayBind(() =>
            {
                var set = this.CreateBindingSet<UnsupportedPostTypeViewCell, TextPostViewModel>();

                set.Bind(Avatar).For(v => v.ImagePath).To(vm => vm.AvatarUrl);
                set.Bind(BlogName).For(v => v.Text).To(vm => vm.BlogName);

                set.Bind(Share).To(vm => vm.ShareCommand);

                set.Apply();
            });
        }
    }
}

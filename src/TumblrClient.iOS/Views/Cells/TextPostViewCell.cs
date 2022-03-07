using System;
using Foundation;
using MvvmCross.Binding.BindingContext;
using TumblrClient.Core.ViewModels.PostsViewModels;
using UIKit;

namespace TumblrClient.iOS.Views.Cells
{
    [Register("TextPostViewCell")]
    public partial class TextPostViewCell : PostViewCell
    {
        public static readonly NSString Key = new NSString("TextPostViewCell");
        public static readonly UINib Nib = UINib.FromName("TextPostViewCell", NSBundle.MainBundle);

        public override UIButton ShareButton => Share;
        public override UIButton LikeButton => Like;

        public TextPostViewCell(IntPtr intPtr) : base(intPtr)
        {
            this.DelayBind(() =>
            {
                var set = this.CreateBindingSet<TextPostViewCell, TextPostViewModel>();

                set.Bind(Avatar).For(v => v.ImagePath).To(vm => vm.AvatarUrl);
                set.Bind(BlogName).For(v => v.Text).To(vm => vm.BlogName);

                set.Bind(Text).For(v => v.Text).To(vm => vm.Text);
                set.Bind(Share).To(vm => vm.ShareCommand);

                set.Apply();
            });
        }
    }
}

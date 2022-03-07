using System;
using Foundation;
using MvvmCross.Binding.BindingContext;
using TumblrClient.Core.ViewModels.PostsViewModels;
using UIKit;

namespace TumblrClient.iOS.Views.Cells
{
    [Register("QuotePostViewCell")]
    public partial class QuotePostViewCell : PostViewCell
    {
        public static readonly NSString Key = new NSString("QuotePostViewCell");
        public static readonly UINib Nib = UINib.FromName("QuotePostViewCell", NSBundle.MainBundle);

        public override UIButton ShareButton => Share;
        public override UIButton LikeButton => Like;

        public QuotePostViewCell(IntPtr intPtr) : base(intPtr)
        {
            this.DelayBind(() =>
            {
                var set = this.CreateBindingSet<QuotePostViewCell, QuotePostViewModel>();

                set.Bind(Avatar).For(v => v.ImagePath).To(vm => vm.AvatarUrl);
                set.Bind(BlogName).For(v => v.Text).To(vm => vm.BlogName);

                set.Bind(Text).For(v => v.Text).To(vm => vm.Quote);
                set.Bind(Share).To(vm => vm.ShareCommand);

                set.Apply();
            });
        }
    }
}

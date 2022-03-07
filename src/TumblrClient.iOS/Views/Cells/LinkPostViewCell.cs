using System;
using Foundation;
using MvvmCross.Binding.BindingContext;
using TumblrClient.Core.ViewModels.PostsViewModels;
using UIKit;

namespace TumblrClient.iOS.Views.Cells
{
    [Register("LinkPostViewCell")]
    public partial class LinkPostViewCell : PostViewCell
    {
        public static readonly NSString Key = new NSString("LinkPostViewCell");
        public static readonly UINib Nib = UINib.FromName("LinkPostViewCell", NSBundle.MainBundle);

        public override UIButton ShareButton => Share;
        public override UIButton LikeButton => Like;

        public LinkPostViewCell(IntPtr intPtr) : base(intPtr)
        {
            this.DelayBind(() =>
            {
                var set = this.CreateBindingSet<LinkPostViewCell, LinkPostViewModel>();

                set.Bind(Avatar).For(v => v.ImagePath).To(vm => vm.AvatarUrl);
                set.Bind(BlogName).For(v => v.Text).To(vm => vm.BlogName);
                set.Bind(LinkButton).For("Title").To(vm => vm.LinkUrl);

                set.Bind(LinkButton).To(vm => vm.OpenLinkCommand);
                set.Bind(Share).To(vm => vm.ShareCommand);

                set.Apply();
            });
        }
    }
}

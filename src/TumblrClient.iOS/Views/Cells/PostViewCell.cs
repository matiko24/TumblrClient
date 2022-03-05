using System;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Binding.Views;
using TumblrClient.Core.Models;
using UIKit;

namespace TumblrClient.iOS.Views.Cells
{
    [Register("PostViewCell")]
    public partial class PostViewCell : MvxTableViewCell
    {
        public static readonly NSString Key = new NSString("PostViewCell");
        public static readonly UINib Nib = UINib.FromName("PostViewCell", NSBundle.MainBundle);

        public PostViewCell(IntPtr intPtr) : base(intPtr)
        {
            this.DelayBind(() =>
            {
                var set = this.CreateBindingSet<PostViewCell, Post>();

                set.Bind(Text).For(v => v.Text).To(vm => vm.Title);

                set.Apply();
            });
        }
    }
}

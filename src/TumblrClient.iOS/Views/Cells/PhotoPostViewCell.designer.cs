// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace TumblrClient.iOS.Views.Cells
{
	partial class PhotoPostViewCell
	{
		[Outlet]
		UIKit.UIButton Like { get; set; }

		[Outlet]
		FFImageLoading.Cross.MvxCachedImageView Photo { get; set; }

		[Outlet]
		UIKit.UIButton Share { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (Like != null) {
				Like.Dispose ();
				Like = null;
			}

			if (Photo != null) {
				Photo.Dispose ();
				Photo = null;
			}

			if (Share != null) {
				Share.Dispose ();
				Share = null;
			}
		}
	}
}

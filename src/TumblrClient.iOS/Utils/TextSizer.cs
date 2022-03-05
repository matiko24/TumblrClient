using System;
using CoreGraphics;
using Foundation;
using UIKit;

namespace TumblrClient.iOS.Utils
{
    public class TextSizer
    {
        public static nfloat GetTextHeight(string text, nfloat widht, UIFont font)
        {
            var nsString = new NSString(text);
            var cgSize = new CGSize(widht, double.MaxValue);
            var attributes = new UIStringAttributes { Font = font };
            var textSize = nsString.GetBoundingRect(cgSize, NSStringDrawingOptions.UsesLineFragmentOrigin, attributes, null);

            return (nfloat) Math.Ceiling(textSize.Height);
        }
    }
}

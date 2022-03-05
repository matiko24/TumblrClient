using System;
using System.Globalization;
using MvvmCross.Converters;

namespace TumblrClient.Core.Converters
{
    public class NotConverter : MvxValueConverter<bool, bool>
    {
        protected override bool Convert(bool value, Type targetType, object parameter, CultureInfo culture)
        {
            return !value;
        }
    }
}

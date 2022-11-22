using System;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace MarketAbuse.Converters
{
    public class BoolToFavoritedImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool val = (bool)value;
            if (val)
            {
                return new BitmapImage(new Uri("Images/Favorited_True_Icon.png", UriKind.RelativeOrAbsolute));
            }
            else
            {
                return new BitmapImage(new Uri("Images/Favorited_False_Icon.png", UriKind.RelativeOrAbsolute));
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

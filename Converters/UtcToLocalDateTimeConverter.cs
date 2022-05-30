using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace MarketAbuse.Converters
{
    class UtcToLocalDateTimeConverter : IValueConverter
    {
        public DateTime RawConvert(object utcTime)
        {
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            double seconds = double.Parse(utcTime?.ToString());
            dateTime = dateTime.AddSeconds(seconds).ToLocalTime();

            return dateTime;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime dt)
                return dt.ToLocalTime();
            else
            {
                return RawConvert(value);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
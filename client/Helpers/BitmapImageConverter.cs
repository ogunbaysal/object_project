using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace client.Helpers
{
    public class BitmapImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            BitmapImage bi = new BitmapImage();

            bi.BeginInit();
            if (value == null) return null;
            bi.UriSource = new Uri((string)value, UriKind.RelativeOrAbsolute);
            bi.EndInit();

            return bi;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}

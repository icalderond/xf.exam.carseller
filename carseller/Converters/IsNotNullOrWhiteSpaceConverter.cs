using System;
using System.Globalization;
using Xamarin.Forms;

namespace carseller.Converters
{
    public class IsNotNullOrWhiteSpaceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var valueReceived = (string)value;
            return !string.IsNullOrWhiteSpace(valueReceived);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

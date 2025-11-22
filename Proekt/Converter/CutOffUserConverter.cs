using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Proekt.Converter
{
    public class CutOffUserConverter : IValueConverter
    {
        public int Min { get; set; } = int.MinValue;
        public int Max { get; set; } = int.MaxValue;
        public object Convert(object value, Type targetType, object parametr, CultureInfo culture)
        {
            if (value is int rating)
            {
                return rating >= Min && rating <= Max;
            }
            return false;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}

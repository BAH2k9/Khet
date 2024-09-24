using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Khet2._0.CustomTypes
{
    public class ScaleConverter : IValueConverter
    {
        private const double FixedWidth = 100;  // Fixed width of the star in logical units
        private const double FixedHeight = 100; // Fixed height of the star in logical units

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double size)
            {
                // Calculate scale based on the minimum of the actual size compared to fixed size
                double scale = Math.Min(size / FixedWidth, size / FixedHeight);
                return scale;  // Return the calculated scale
            }
            return 1.0; // Default scale if the value is not a double
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}

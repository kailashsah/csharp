using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace array_items_color
{
    class ConverterColor : IValueConverter
    {
        int previousInt = 0;
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            //return int.Parse((string)value) > 18 ? new SolidColorBrush(Colors.Red) : new SolidColorBrush(Colors.Green);
            //if (int.Parse((string)value) > 18)

            if (((int)value) < previousInt)
            {
                previousInt = (int)value;
                return "Red";
            }
            else
            {
                previousInt = (int)value;
                return "Green";
            }
        }
    


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

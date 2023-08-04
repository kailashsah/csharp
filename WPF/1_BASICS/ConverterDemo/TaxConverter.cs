using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ConverterDemo
{
    public class TaxConverter : IValueConverter
    {
        public int Discount { get; set; }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (string.IsNullOrEmpty(value?.ToString()))
                return 0;

            var amount = double.Parse(value.ToString());

            var taxCalc = double.Parse(parameter.ToString());
            return (amount * taxCalc / 100) - Discount;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

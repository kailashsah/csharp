using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace EventAggregatorSample
{
    public class ActionTypeToBackgroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(Enum.TryParse(value.ToString(), out ActionType actionType))
            {
                switch (actionType)
                {
                    case ActionType.Created:
                        return Brushes.LightGreen;
                    case ActionType.Deleted:
                        return Brushes.Red;
                    case ActionType.Updated:
                        return Brushes.LightYellow;
                    default:
                        return Brushes.LightGreen;
                }
            }

            return Brushes.LightYellow;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

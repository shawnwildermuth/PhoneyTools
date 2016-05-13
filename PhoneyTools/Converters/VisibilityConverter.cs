using System;
using System.Windows;
using System.Windows.Data;
using System.Globalization;

namespace AgiliTrain.PhoneyTools.Converters
{
  public class VisibilityConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      if (targetType == typeof(Visibility))
      {
        if (value == null)
        {
          return Visibility.Collapsed;
        }
        else
        {
          var param = parameter as string;
          if (param != null && param == "Reverse")
          {
            return !((bool)value) ? Visibility.Visible : Visibility.Collapsed;
          }
          else
          {
            return ((bool)value) ? Visibility.Visible : Visibility.Collapsed;
          }
        }
      }


      // No Conversion
      return value;
    }

    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
      // No support for converting back
      return value;
    }
  }
}

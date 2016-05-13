using System;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Data;

namespace AgiliTrain.PhoneyTools.Converters
{
  public class UnHtmlConverter : IValueConverter
  {

    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
      if (targetType == typeof(string) && value.GetType() == typeof(string))
      {
        // From Roy Osherove's Blog
        // http://weblogs.asp.net/rosherove/archive/2003/05/13/6963.aspx

        var result = Regex.Replace((string)value, @"</h2>", string.Concat(Environment.NewLine, Environment.NewLine));
        result = Regex.Replace(result, @"</p>", string.Concat(Environment.NewLine, Environment.NewLine));
        result = Regex.Replace(result, @"<(.|\n)*?>", string.Empty);
        result = HttpUtility.HtmlDecode(result);
        result = Regex.Replace(result, @"[ ]+", " ");
        return result;
      }

      // No conversion
      return value;
    }

    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
      // No Conversion
      return value;
    }
  }
}

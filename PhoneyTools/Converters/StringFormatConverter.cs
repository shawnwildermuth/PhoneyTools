using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Data;

namespace AgiliTrain.PhoneyTools.Converters
{
  /// <summary>
  /// Used to format strings during databinding.
  /// </summary>
  public class StringFormatConverter : IValueConverter
  {
    /// <summary>
    /// Called during data binding.  Formats strings with the provided format string.
    /// </summary>
    /// <param name="value">The string to format.</param>
    /// <param name="targetType">Not used, should be a string.</param>
    /// <param name="parameter">The format string.</param>
    /// <param name="culture">The culture to use when formatting.</param>
    /// <returns></returns>
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      if (value == null) return null;

      try
      {
        string format = parameter as string;
        return string.IsNullOrEmpty(format) ? value.ToString() : String.Format(culture, string.Concat("{0:", format, "}"), value);
      }
      catch (Exception ex)
      {
        // if fails to format, we shouldn't throw exception but swallow and report
        Debug.WriteLine(string.Format(culture, "StringFormatConverter Threw Exception in Convert: {0}", ex));
      }
      return value;
    }

    /// <summary>
    /// Not implemented. 
    /// </summary>
    /// <param name="value">Not implemented.</param>
    /// <param name="targetType">Not implemented.</param>
    /// <param name="parameter">Not implemented.</param>
    /// <param name="culture">Not implemented.</param>
    /// <returns></returns>
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }
}

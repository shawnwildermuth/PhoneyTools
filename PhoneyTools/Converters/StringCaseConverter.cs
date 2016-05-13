using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Data;

namespace AgiliTrain.PhoneyTools.Converters
{
  /// <summary>
  /// Converts a Decimal value to a culture sensitive money value.
  /// </summary>
  public class StringCaseConverter : IValueConverter
  {
    #region IValueConverter Members

    /// <summary>
    /// Modifies the source data before passing it to the target for display in the UI.
    /// </summary>
    /// <param name="value">The source data being passed to the target.</param>
    /// <param name="targetType">The <see cref="T:System.Type"/> of data expected by the target dependency property.</param>
    /// <param name="parameter">An optional parameter to be used in the converter logic.</param>
    /// <param name="culture">The culture of the conversion.</param>
    /// <returns>
    /// The value to be passed to the target dependency property.
    /// </returns>
    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
      if (value == null) return value;

      if (value.GetType() == typeof(string))
      {
        var caseParam = parameter as string;

        if (caseParam != null && caseParam.ToLower() == "u")
        {
          return ((string)value).ToUpper();
        }
        else
        {
          return ((string)value).ToLower();
        }
      }

      return value;
    }

    /// <summary>
    /// Modifies the target data before passing it to the source object.  This method is called only in <see cref="F:System.Windows.Data.BindingMode.TwoWay"/> bindings.
    /// </summary>
    /// <param name="value">The target data being passed to the source.</param>
    /// <param name="targetType">The <see cref="T:System.Type"/> of data expected by the source object.</param>
    /// <param name="parameter">An optional parameter to be used in the converter logic.</param>
    /// <param name="culture">The culture of the conversion.</param>
    /// <returns>
    /// The value to be passed to the source object.
    /// </returns>
    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
      return value;
    }

    #endregion
  }
}

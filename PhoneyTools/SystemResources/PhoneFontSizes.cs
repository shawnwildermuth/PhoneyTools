using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace AgiliTrain.PhoneyTools.SystemResources
{
  /// <summary>
  /// Phone Font Size Accessors
  /// </summary>
  public static class PhoneFontSizes
  {

    /// <summary>
    /// Gets the phone font size small.
    /// </summary>
    public static double PhoneFontSizeSmall
    {
      get
      {
        return (double)Application.Current.Resources["PhoneFontSizeSmall"];
      }
    }

    /// <summary>
    /// Gets the phone font size normal.
    /// </summary>
    public static double PhoneFontSizeNormal
    {
      get
      {
        return (double)Application.Current.Resources["PhoneFontSizeNormal"];
      }
    }

    /// <summary>
    /// Gets the phone font size medium.
    /// </summary>
    public static double PhoneFontSizeMedium
    {
      get
      {
        return (double)Application.Current.Resources["PhoneFontSizeMedium"];
      }
    }

    /// <summary>
    /// Gets the phone font size medium large.
    /// </summary>
    public static double PhoneFontSizeMediumLarge
    {
      get
      {
        return (double)Application.Current.Resources["PhoneFontSizeMediumLarge"];
      }
    }

    /// <summary>
    /// Gets the phone font size large.
    /// </summary>
    public static double PhoneFontSizeLarge
    {
      get
      {
        return (double)Application.Current.Resources["PhoneFontSizeLarge"];
      }
    }

    /// <summary>
    /// Gets the phone font size extra large.
    /// </summary>
    public static double PhoneFontSizeExtraLarge
    {
      get
      {
        return (double)Application.Current.Resources["PhoneFontSizeExtraLarge"];
      }
    }

    /// <summary>
    /// Gets the phone font size extra extra large.
    /// </summary>
    public static double PhoneFontSizeExtraExtraLarge
    {
      get
      {
        return (double)Application.Current.Resources["PhoneFontSizeExtraExtraLarge"];
      }
    }

    /// <summary>
    /// Gets the phone font size huge.
    /// </summary>
    public static double PhoneFontSizeHuge
    {
      get
      {
        return (double)Application.Current.Resources["PhoneFontSizeHuge"];
      }
    }
  }
}

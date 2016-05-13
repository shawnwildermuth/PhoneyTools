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
  /// Phone Font Family Accessors
  /// </summary>
  public static class PhoneFontFamilies
  {

    /// <summary>
    /// Gets the phone font family normal.
    /// </summary>
    public static FontFamily PhoneFontFamilyNormal
    {
      get
      {
        return (FontFamily)Application.Current.Resources["PhoneFontFamilyNormal"];
      }
    }

    /// <summary>
    /// Gets the phone font family light.
    /// </summary>
    public static FontFamily PhoneFontFamilyLight
    {
      get
      {
        return (FontFamily)Application.Current.Resources["PhoneFontFamilyLight"];
      }
    }

    /// <summary>
    /// Gets the phone font family semi light.
    /// </summary>
    public static FontFamily PhoneFontFamilySemiLight
    {
      get
      {
        return (FontFamily)Application.Current.Resources["PhoneFontFamilySemiLight"];
      }
    }

    /// <summary>
    /// Gets the phone font family semi bold.
    /// </summary>
    public static FontFamily PhoneFontFamilySemiBold
    {
      get
      {
        return (FontFamily)Application.Current.Resources["PhoneFontFamilySemiBold"];
      }
    }
  }
}

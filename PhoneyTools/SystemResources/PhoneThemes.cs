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
  /// Utility functions for determining the theme.
  /// </summary>
  public static class PhoneTheme
  {
    /// <summary>
    /// Gets a value indicating whether this instance is light theme.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance is light theme; otherwise, <c>false</c>.
    /// </value>
    public static bool IsLightTheme
    {
      get
      {
        var lightVis = (Visibility)Application.Current.Resources["PhoneLightThemeVisibility"];
        return lightVis == Visibility.Visible;
      }
    }

    /// <summary>
    /// Gets a value indicating whether this instance is dark theme.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance is dark theme; otherwise, <c>false</c>.
    /// </value>
    public static bool IsDarkTheme
    {
      get
      {
        return !IsLightTheme;
      }
    }
  }
}

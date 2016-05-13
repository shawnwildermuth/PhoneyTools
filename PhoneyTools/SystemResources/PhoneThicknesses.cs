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
  /// Phone Thickness Accessors
  /// </summary>
  public class PhoneThicknesses
  {

    /// <summary>
    /// Gets the phone horizontal margin.
    /// </summary>
    public static Thickness PhoneHorizontalMargin
    {
      get
      {
        return (Thickness)Application.Current.Resources["PhoneHorizontalMargin"];
      }
    }

    /// <summary>
    /// Gets the phone vertical margin.
    /// </summary>
    public static Thickness PhoneVerticalMargin
    {
      get
      {
        return (Thickness)Application.Current.Resources["PhoneVerticalMargin"];
      }
    }

    /// <summary>
    /// Gets the phone margin.
    /// </summary>
    public static Thickness PhoneMargin
    {
      get
      {
        return (Thickness)Application.Current.Resources["PhoneMargin"];
      }
    }

    /// <summary>
    /// Gets the phone touch target overhang.
    /// </summary>
    public static Thickness PhoneTouchTargetOverhang
    {
      get
      {
        return (Thickness)Application.Current.Resources["PhoneTouchTargetOverhang"];
      }
    }


    /// <summary>
    /// Gets the phone touch target large overhang.
    /// </summary>
    public static Thickness PhoneTouchTargetLargeOverhang
    {
      get
      {
        return (Thickness)Application.Current.Resources["PhoneTouchTargetLargeOverhang"];
      }
    }


    /// <summary>
    /// Gets the phone border thickness.
    /// </summary>
    public static Thickness PhoneBorderThickness
    {
      get
      {
        return (Thickness)Application.Current.Resources["PhoneBorderThickness"];
      }
    }


    /// <summary>
    /// Gets the phone stroke thickness.
    /// </summary>
    public static double PhoneStrokeThickness
    {
      get
      {
        return (double)Application.Current.Resources["PhoneStrokeThickness"];
      }
    }
  }
}

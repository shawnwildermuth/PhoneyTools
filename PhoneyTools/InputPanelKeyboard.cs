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

namespace AgiliTrain.PhoneyTools
{
  /// <summary>
  /// 
  /// </summary>
  public enum InputPanelKeyboard
  {
    /// <summary>
    /// Standard alphanumeric keyboard starting with lower case.
    /// </summary>
    Alphanumeric,
    /// <summary>
    /// Standard alphanumeric keyboard with an inital capital letter.
    /// </summary>
    AlphanumericInitialCap,
    /// <summary>
    /// Standard alphanumeric keyboard but with the number pad shown by default.
    /// </summary>
    Numbers,
    /// <summary>
    /// the T-10 Phone Keyboard
    /// </summary>
    Phone
  }

}

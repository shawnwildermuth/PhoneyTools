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
  /// Class that contains the data to determine the right kind of SIP to show.
  /// </summary>
  public class InputPanelRequirements
  {
    internal InputScopeNameValue InputScopeName { get; set; }

    internal bool AutoCorrectSet { get; set; }
    bool _autoCorrect = false;
    /// <summary>
    /// Gets or sets a value indicating whether the SIP supports AutoCorrect.
    /// </summary>
    /// <value>
    ///   <c>true</c> if [auto correct]; otherwise, <c>false</c>.
    /// </value>
    public bool AutoCorrect
    {
      get { return _autoCorrect; }
      set
      {
        _autoCorrect = value;
        AutoCorrectSet = true;
      }
    }

    internal bool KeyboardTypeSet { get; set; }
    InputPanelKeyboard _keyboardType = InputPanelKeyboard.Alphanumeric;
    /// <summary>
    /// Gets or sets the type of the keyboard to use on the SIP.
    /// </summary>
    /// <value>
    /// The type of the keyboard.
    /// </value>
    public InputPanelKeyboard KeyboardType
    {
      get { return _keyboardType; }
      set
      {
        _keyboardType = value;
        KeyboardTypeSet = true;
      }
    }

    internal bool SpecialKeysSet { get; set; }
    InputPanelSpecialKeys _specialKeys = InputPanelSpecialKeys.None;
    /// <summary>
    /// Gets or sets which special keys to use on the SIP.
    /// </summary>
    /// <value>
    /// The special keys.
    /// </value>
    public InputPanelSpecialKeys SpecialKeys
    {
      get { return _specialKeys; }
      set
      {
        _specialKeys = value;
        SpecialKeysSet = true;
      }
    }


    internal bool EnterKeySet { get; set; }
    InputPanelEnterKey _enterKey = InputPanelEnterKey.Normal;
    /// <summary>
    /// Gets or sets which Enter Key to use on the SIP.
    /// </summary>
    /// <value>
    /// The enter key.
    /// </value>
    public InputPanelEnterKey EnterKey
    {
      get { return _enterKey; }
      set
      {
        _enterKey = value;
        EnterKeySet = true;
      }
    }

  }
}

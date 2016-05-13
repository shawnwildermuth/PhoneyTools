using System;
using System.Linq;
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
  /// Utility Functions to help build InputScopes.
  /// </summary>
  public static class InputScopeHelper
  {
    /// <summary>
    /// Builds the Input Scope.
    /// </summary>
    /// <param name="nameValue">The name value.</param>
    /// <returns>The new InputScope.</returns>
    public static InputScope BuildInputScope(InputScopeNameValue nameValue)
    {
      return new InputScope()
      {
        Names = 
        { 
          new InputScopeName() { NameValue = nameValue } 
        }
      };
    }

    /// <summary>
    /// Gets the first name value.
    /// </summary>
    /// <param name="scope">The scope.</param>
    /// <returns>The first InputScopeNameValue for the InputScope.</returns>
    public static InputScopeNameValue GetFirstNameValue(this InputScope scope)
    {
      return scope.Names.Cast<InputScopeName>().First().NameValue;
    }
  }
}

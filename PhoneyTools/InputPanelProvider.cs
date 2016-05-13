using System;
using System.Diagnostics;
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
using System.Collections.Generic;

namespace AgiliTrain.PhoneyTools
{
  /// <summary>
  /// 
  /// </summary>
  public static class InputPanelProvider
  {
    /// <summary>
    /// Gets the input scope.
    /// </summary>
    /// <param name="req">The req.</param>
    /// <returns></returns>
    public static InputScope GetInputScope(InputPanelRequirements req)
    {
      // If not found, use default
      var found = Search(req);

      // Return an InputScope
      return InputScopeHelper.BuildInputScope(found.InputScopeName);
    }

    static InputPanelRequirements Search(InputPanelRequirements req)
    {
      // No IQueryable Support so I have to hack it together

      InputPanelRequirements found = null;
      IEnumerable<InputPanelRequirements> qry = null;

      // If all are set
      if (req.KeyboardTypeSet && req.AutoCorrectSet && req.EnterKeySet && req.SpecialKeysSet)
      {
        qry = from m in Metadata
              where m.AutoCorrect == req.AutoCorrect &&
                    m.KeyboardType == req.KeyboardType &&
                    m.SpecialKeys == req.SpecialKeys &&
                    m.EnterKey == req.EnterKey
              select m;
      }
      // All but Special
      else if (req.KeyboardTypeSet && req.AutoCorrectSet && req.EnterKeySet && !req.SpecialKeysSet)
      {
        qry = from m in Metadata
              where m.AutoCorrect == req.AutoCorrect &&
                    m.KeyboardType == req.KeyboardType &&
                    m.EnterKey == req.EnterKey
              select m;
      }
      // All but Enter
      else if (req.KeyboardTypeSet && req.AutoCorrectSet && !req.EnterKeySet && req.SpecialKeysSet)
      {
        qry = from m in Metadata
              where m.AutoCorrect == req.AutoCorrect &&
                    m.KeyboardType == req.KeyboardType &&
                    m.SpecialKeys == req.SpecialKeys
              select m;
      }
      // All but AutoCorrect
      else if (req.KeyboardTypeSet && !req.AutoCorrectSet && req.EnterKeySet && req.SpecialKeysSet)
      {
        qry = from m in Metadata
              where m.KeyboardType == req.KeyboardType &&
                    m.SpecialKeys == req.SpecialKeys &&
                    m.EnterKey == req.EnterKey
              select m;
      }
      // All But Keyboard
      else if (!req.KeyboardTypeSet && req.AutoCorrectSet && req.EnterKeySet && req.SpecialKeysSet)
      {
        qry = from m in Metadata
              where m.AutoCorrect == req.AutoCorrect &&
                    m.SpecialKeys == req.SpecialKeys &&
                    m.EnterKey == req.EnterKey
              select m;
      }
      // Keyboard and AutoCorrect
      else if (req.KeyboardTypeSet && req.AutoCorrectSet && !req.EnterKeySet && !req.SpecialKeysSet)
      {
        qry = from m in Metadata
              where m.AutoCorrect == req.AutoCorrect &&
                    m.KeyboardType == req.KeyboardType
              select m;
      }
      // Keyboard and Enter
      else if (req.KeyboardTypeSet && !req.AutoCorrectSet && req.EnterKeySet && !req.SpecialKeysSet)
      {
        qry = from m in Metadata
              where m.KeyboardType == req.KeyboardType &&
                    m.EnterKey == req.EnterKey
              select m;
      }
      // Keyboard and Special
      else if (req.KeyboardTypeSet && !req.AutoCorrectSet && !req.EnterKeySet && req.SpecialKeysSet)
      {
        qry = from m in Metadata
              where m.KeyboardType == req.KeyboardType &&
                    m.EnterKey == req.EnterKey
              select m;
      }
      // AutoCorrect and Enter
      else if (!req.KeyboardTypeSet && req.AutoCorrectSet && req.EnterKeySet && !req.SpecialKeysSet)
      {
        qry = from m in Metadata
              where m.AutoCorrect == req.AutoCorrect &&
                    m.EnterKey == req.EnterKey
              select m;
      }
      // AutoCorrect and Special
      else if (!req.KeyboardTypeSet && req.AutoCorrectSet && !req.EnterKeySet && req.SpecialKeysSet)
      {
        qry = from m in Metadata
              where m.AutoCorrect == req.AutoCorrect &&
                    m.SpecialKeys == req.SpecialKeys
              select m;
      }
      // Keyboard Only
      else if (req.KeyboardTypeSet && !req.AutoCorrectSet && !req.EnterKeySet && !req.SpecialKeysSet)
      {
        qry = from m in Metadata
              where m.KeyboardType == req.KeyboardType
              select m;
      }
      // AutoCorrect Only
      else if (!req.KeyboardTypeSet && req.AutoCorrectSet && !req.EnterKeySet && !req.SpecialKeysSet)
      {
        qry = from m in Metadata
              where m.AutoCorrect == req.AutoCorrect 
              select m;
      }
      // EnterKey Only
      else if (!req.KeyboardTypeSet && !req.AutoCorrectSet && req.EnterKeySet && !req.SpecialKeysSet)
      {
        qry = from m in Metadata
              where m.EnterKey == req.EnterKey
              select m;
      }
      // Special Key only
      else if (!req.KeyboardTypeSet && !req.AutoCorrectSet && !req.EnterKeySet && req.SpecialKeysSet)
      {
        qry = from m in Metadata
              where m.SpecialKeys == req.SpecialKeys 
              select m;
      }
      else
      {
        throw new InvalidOperationException("Must specify at least one requirement in the InputPanelRequirements object.");
      }

      // Perform the Search
      found = qry.FirstOrDefault();
      if (found != null)
      {
        return found;
      }

      throw new InvalidOperationException("Could not find an InputScope to match the requirements. Try reducing the requirements.");
    }


    static IEnumerable<InputPanelRequirements> _metadata = null;
    static IEnumerable<InputPanelRequirements> Metadata
    {
      get
      {
        if (_metadata == null)
        {
          _metadata = BuildMetadata();
        }
        return _metadata;
      }
    }

    static IEnumerable<InputPanelRequirements> BuildMetadata()
    {
      return new InputPanelRequirements[] 
      {
        new InputPanelRequirements()
        {
          InputScopeName = InputScopeNameValue.Default,
        },
         new InputPanelRequirements()
        {
          InputScopeName = InputScopeNameValue.TelephoneNumber,
          KeyboardType = InputPanelKeyboard.Phone
        },
       new InputPanelRequirements()
        {
          InputScopeName = InputScopeNameValue.Text,
          AutoCorrect = true, 
          KeyboardType = InputPanelKeyboard.AlphanumericInitialCap,
          SpecialKeys = InputPanelSpecialKeys.Chat
        },
        new InputPanelRequirements()
        {
          InputScopeName = InputScopeNameValue.Maps,
          EnterKey = InputPanelEnterKey.Highlighted,
          AutoCorrect = true
        },
        new InputPanelRequirements()
        {
          InputScopeName = InputScopeNameValue.Search,
          EnterKey = InputPanelEnterKey.Highlighted
        },
        new InputPanelRequirements()
        {
          InputScopeName = InputScopeNameValue.Url,
          EnterKey = InputPanelEnterKey.Highlighted,
          SpecialKeys = InputPanelSpecialKeys.Internet
        },
        new InputPanelRequirements()
        {
          InputScopeName = InputScopeNameValue.EmailNameOrAddress,
          SpecialKeys = InputPanelSpecialKeys.Email
        },
        new InputPanelRequirements()
        {
          InputScopeName = InputScopeNameValue.Number,
          KeyboardType = InputPanelKeyboard.Numbers
        },
        new InputPanelRequirements()
        {
          InputScopeName = InputScopeNameValue.PersonalFullName,
          KeyboardType = InputPanelKeyboard.AlphanumericInitialCap
        }
      };
    }

    /// <summary>
    /// The Requirements for an InputPanel.
    /// </summary>
    public static readonly DependencyProperty RequirementsProperty =
        DependencyProperty.RegisterAttached("Requirements", typeof(InputPanelRequirements), typeof(InputPanelProvider), new PropertyMetadata(null, new PropertyChangedCallback(OnInputPanelRequirementsPropertiesChanged)));

    /// <summary>
    /// Sets the Requirements on an object.
    /// </summary>
    /// <param name="o">The o.</param>
    /// <param name="value">if set to <c>true</c> [value].</param>
    public static void SetRequirements(DependencyObject o, InputPanelRequirements value)
    {
      o.SetValue(RequirementsProperty, value);
    }

    /// <summary>
    /// Gets the InputPanelRequirements for an object.
    /// </summary>
    /// <param name="o">The object.</param>
    /// <returns>The requirements for the InputPanel</returns>
    public static InputPanelRequirements GetRequirements(DependencyObject o)
    {
      return (InputPanelRequirements)o.GetValue(RequirementsProperty);
    }

    /// <summary>
    /// Called when [auto correct changed].
    /// </summary>
    /// <param name="ctrl">The CTRL.</param>
    /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
    private static void OnInputPanelRequirementsPropertiesChanged(DependencyObject ctrl, DependencyPropertyChangedEventArgs e)
    {
      var tb = ctrl as TextBox;
      var req = e.NewValue as InputPanelRequirements;
      // Only for use on TextBox
      if (tb != null && req != null)
      {
        SetInputScope(tb, req);
      }
    }

    /// <summary>
    /// Sets the input scope for the changed value.
    /// </summary>
    /// <param name="ctrl">The CTRL (must be TextBox.</param>
    static void SetInputScope(TextBox ctrl, InputPanelRequirements req)
    {
      ctrl.InputScope = GetInputScope(req);
    }


  }
}

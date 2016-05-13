using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using AgiliTrain.PhoneyTools;

namespace PhoneyTools.Example.Views
{
  public partial class InputScopeExamples : UserControl
  {
    InputPanelRequirements req = new InputPanelRequirements();
    public InputScopeExamples()
    {
      InitializeComponent();
      keyboardType.ItemsSource = EnumHelper.GetNames<InputPanelKeyboard>();
      enterKey.ItemsSource = EnumHelper.GetNames<InputPanelEnterKey>();
      specialKeys.ItemsSource = EnumHelper.GetNames<InputPanelSpecialKeys>();
      Loaded += new RoutedEventHandler(InputScopeExamples_Loaded);
    }

    bool _isLoaded = false;
    void InputScopeExamples_Loaded(object sender, RoutedEventArgs e)
    {
      _isLoaded = true;
    }

    private void setInputScope_Click(object sender, RoutedEventArgs e)
    {
      try
      {
        testBox.InputScope = InputPanelProvider.GetInputScope(req);
      }
      catch (InvalidOperationException)
      {
        MessageBox.Show("No InputScope matches requirements.");
      }
    }

    private void autoCorrectCheck_Checked(object sender, RoutedEventArgs e)
    {
      if (_isLoaded)
      {
        req.AutoCorrect = autoCorrectCheck.IsChecked.GetValueOrDefault();
      }
    }

    private void keyboardType_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      if (_isLoaded && enterKey.SelectedItem != null)
      {
        req.KeyboardType = EnumHelper.Parse<InputPanelKeyboard>((string)keyboardType.SelectedItem);
      }
    }

    private void specialKeys_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      if (_isLoaded && enterKey.SelectedItem != null)
      {
        req.SpecialKeys = EnumHelper.Parse<InputPanelSpecialKeys>((string)specialKeys.SelectedItem);
      }
    }

    private void enterKey_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      if (_isLoaded && specialKeys.SelectedItem != null)
      {
        req.EnterKey = EnumHelper.Parse<InputPanelEnterKey>((string)enterKey.SelectedItem);
      }
    }

    private void closeButton_Click(object sender, RoutedEventArgs e)
    {
      autoCorrectCheck.Focus();
    }

    private void clearInputData_Click(object sender, RoutedEventArgs e)
    {
      specialKeys.SelectedIndex = 0;
      enterKey.SelectedIndex = 0;
      keyboardType.SelectedIndex = 0;
      autoCorrectCheck.IsChecked = false;
      req = new InputPanelRequirements();
    }

  }
}
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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AgiliTrain.PhoneyTools;
using Microsoft.Silverlight.Testing;

namespace PhoneyTools.Tests.Tests
{
  [TestClass]
  public class InputPanelProviderTests : SilverlightTest
  {
    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void TestDefault()
    {
      var result = InputPanelProvider.GetInputScope(new InputPanelRequirements());
    }

    bool ContainsInputScopeNameValue(InputScope scope, InputScopeNameValue nameValue)
    {
      return scope.Names.Cast<InputScopeName>().Any(n => n.NameValue == nameValue);
    }

    [TestMethod]
    public void TestOnlyAutoCorrect()
    {
      var result = InputPanelProvider.GetInputScope(new InputPanelRequirements()
        {
          AutoCorrect = true
        });
      Assert.IsTrue(ContainsInputScopeNameValue(result, InputScopeNameValue.Text),
        string.Concat("Expected InputScope not expected, found: ", result.GetFirstNameValue()));
    }

    [TestMethod]
    public void TestOnlyHighlightedEnter()
    {
      var result = InputPanelProvider.GetInputScope(new InputPanelRequirements()
      {
        EnterKey = InputPanelEnterKey.Highlighted
      });
      Assert.IsTrue(ContainsInputScopeNameValue(result, InputScopeNameValue.Maps),
        string.Concat("Expected InputScope not expected, found: ", result.GetFirstNameValue()));
    }

    [TestMethod]
    public void TestOnlyInitialCapKeyboard()
    {
      var result = InputPanelProvider.GetInputScope(new InputPanelRequirements()
      {
        KeyboardType = InputPanelKeyboard.AlphanumericInitialCap
      });
      Assert.IsTrue(ContainsInputScopeNameValue(result, InputScopeNameValue.Text),
        string.Concat("Expected InputScope not expected, found: ", result.GetFirstNameValue()));
    }

    [TestMethod]
    public void TestOnlyNumberKeyboard()
    {
      var result = InputPanelProvider.GetInputScope(new InputPanelRequirements()
      {
        KeyboardType = InputPanelKeyboard.Numbers
      });
      Assert.IsTrue(ContainsInputScopeNameValue(result, InputScopeNameValue.Number),
        string.Concat("Expected InputScope not expected, found: ", result.GetFirstNameValue()));
    }

  }
}

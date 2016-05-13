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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AgiliTrain.PhoneyTools.Converters;

namespace PhoneyTools.Tests.Tests
{
  [TestClass]
  public class TestConverters
  {
    [TestMethod]
    public void TestUnHtmlConverter()
    {
      string html = "<p>Hello this is a <strong>Test</strong> of a sample <i>Html</i>.";

      var cvt = new UnHtmlConverter();

      string result = (string)cvt.Convert(html, typeof(string), null, null);

      Assert.IsTrue(result == "Hello this is a Test of a sample Html.", "UnHtmlConverter Failed.");

    }

    [TestMethod]
    public void TestCaseConverter()
    {
      string test = "This is a test.";

      var cvt = new StringCaseConverter();

      string lcResult = (string)cvt.Convert(test, typeof(string), null, null);

      Assert.IsTrue(lcResult == "this is a test.", "StringCaseConvert to lower Failed.");

      string lcDefinedResult = (string)cvt.Convert(test, typeof(string), "l", null);

      Assert.IsTrue(lcDefinedResult == "this is a test.", "StringCaseConvert with parameter to lower Failed.");

      string ucResult = (string)cvt.Convert(test, typeof(string), "u", null);

      Assert.IsTrue(ucResult == "THIS IS A TEST.", "StringCaseConvert to upper Failed.");
    }
  }
}

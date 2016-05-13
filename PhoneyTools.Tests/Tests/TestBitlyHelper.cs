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
using AgiliTrain.PhoneyTools.Net;

namespace PhoneyTools.Tests.Tests
{
  [TestClass]
  public class TestBitlyHelper
  {
    [TestMethod]
    public void TestNoCredentials()
    {
      BitlyHelper.ShortenUrl("", "", "http://wildermuth.com", (result, exception) =>
        {
          Assert.IsInstanceOfType(exception, typeof(ArgumentException));
        });
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void TestEmptyUserID()
    {
      var helper = new BitlyHelper("BADAPIKEY", null);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void TestEmptyAppID()
    {
      var helper = new BitlyHelper(null, "BADUSERID");
    }

  }
}

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
using AgiliTrain.PhoneyTools;

namespace PhoneyTools.Tests
{
  [TestClass]
  public class PhoneLoggerTests
  {
    [TestMethod]
    public void TestLogger()
    {
      PhoneLogger.LogError("Test Logging Message");

      var log = PhoneLogger.LogContents;

      var lines = log.Split(new string[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);

      Assert.IsTrue(lines[lines.Length - 1].Contains("Test Logging Message"));
    }
  }
}

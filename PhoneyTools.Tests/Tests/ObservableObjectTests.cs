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
using Microsoft.Silverlight.Testing;

namespace PhoneyTools.Tests.Tests
{
  [TestClass]
  public class ObservableObjectTests : SilverlightTest
  {
    [TestMethod]
    [Asynchronous]
    public void TestEvents()
    {
      // Test the class that is derived from the class
      var obj = new TestObservableObject();

      bool wasCalled = false;
      obj.PropertyChanged += (s, e) => wasCalled = true;

      // Fire the event then check the change
      EnqueueCallback(() => obj.FireEvent());
      EnqueueCallback(() => Assert.IsTrue(wasCalled, "Firing of the event should have been called."));

      EnqueueTestComplete();
    }

    class TestObservableObject : ObservableObject
    {
      public void FireEvent() { RaisePropertyChanged("foo"); }
    }
  }
}

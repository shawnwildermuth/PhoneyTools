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

namespace PhoneyTools.Example.Views
{
  public partial class ConvertersExamples : UserControl
  {
    public ConvertersExamples()
    {
      InitializeComponent();

      DataContext = new DummyData()
      {
        SomeHtml = "<p>Hello <strong>There</strong>!",
        SomeText = "This is a Test of Mixed Case", 
        SomeDate = DateTime.Now,
        SomeMoney = 99.99m,
        SomeDouble = 1.2345,
        Visibility = true,
        SomeNull = null
      };

    }
  }

  

}
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
using AgiliTrain.PhoneyTools;

namespace PhoneyTools.Example.Views
{
  public partial class LoggerExample : UserControl
  {
    public LoggerExample()
    {
      InitializeComponent();
    }

    private void addButton_Click(object sender, RoutedEventArgs e)
    {
      PhoneLogger.LogError("Error Occurred");
    }

    private void showButton_Click(object sender, RoutedEventArgs e)
    {
      contentsBlock.Text = PhoneLogger.LogContents;
    }
  }
}

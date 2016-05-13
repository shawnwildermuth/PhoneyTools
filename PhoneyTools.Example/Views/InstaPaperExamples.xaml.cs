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
using AgiliTrain.PhoneyTools.Net;
using System.Windows.Media.Imaging;

namespace PhoneyTools.Example.Views
{
  public partial class InstaPaperExamples : UserControl
  {
    public InstaPaperExamples()
    {
      InitializeComponent();
    }

    private void addButton_Click(object sender, RoutedEventArgs e)
    {
      resultText.Text = "Sending to InstaPaper...";
      InstaPaperHelper.AddToInstaPaperAsync(
        userNameBox.Text, 
        pwdBox.Password, 
        new Uri(urlBox.Text), 
        titleBox.Text,
        success =>
        {
          resultText.Text = success ? "Succeeded in adding to InstaPaper" : "Failed to add to InstaPaper";
        });
    }


  }
}
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
using AgiliTrain.PhoneyTools.Net;
//using AgiliTrain.PhoneyTools.Net;

namespace PhoneyTools.Example.Views
{
  public partial class NetworkExamples : UserControl
  {
    public NetworkExamples()
    {
      InitializeComponent();
    }

    private void networkTypeButton_Click(object sender, RoutedEventArgs e)
    {
      PhoneNetworking.GetNetworkTypeAsync(type =>
        {
          networkTypeBlock.Text = Enum.GetName(typeof(PhoneNetworking.NetworkType), type);
        });
      
    }
  }
}
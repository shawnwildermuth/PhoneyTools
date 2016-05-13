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

namespace PhoneyTools.Example
{
  public partial class MainPage : PhoneApplicationPage
  {
    // Constructor
    public MainPage()
    {
      InitializeComponent();

    }

    private void fadingMessageButton_Click(object sender, RoutedEventArgs e)
    {
      NavigationService.Navigate(new Uri("/Views/FadingMessagePage.xaml", UriKind.Relative));
    }

    private void bitlyButton_Click(object sender, RoutedEventArgs e)
    {
      NavigationService.Navigate(new Uri("/Views/BitlyPage.xaml", UriKind.Relative));
    }

    private void convertersButton_Click(object sender, RoutedEventArgs e)
    {
      NavigationService.Navigate(new Uri("/Views/ConvertersPage.xaml", UriKind.Relative));
    }

    private void networkingButton_Click(object sender, RoutedEventArgs e)
    {
      NavigationService.Navigate(new Uri("/Views/NetworkPage.xaml", UriKind.Relative));
    }

    private void mediaButton_Click(object sender, RoutedEventArgs e)
    {
      NavigationService.Navigate(new Uri("/Views/MediaPage.xaml", UriKind.Relative));
    }


  }

}
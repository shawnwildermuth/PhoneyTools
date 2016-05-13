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
  public partial class SocialExamples : UserControl
  {
    public SocialExamples()
    {
      InitializeComponent();
    }

    private void shortenButton_Click(object sender, RoutedEventArgs e)
    {
      BitlyHelper.ShortenUrl(apiKeyBox.Text, userNameBox.Text, urlBox.Text, (result, error) =>
      {
        if (error != null)
        {
          FadingMessage.Show("Error Shortening Url: {0}", error.Message);
        }
        else
        {
          FadingMessage.Show(result, 3000);
        }
      });
    }

    private void gravatarButton_Click(object sender, RoutedEventArgs e)
    {
      gravatarImage.Source = GravatarHelper.GetImageSource(gravatarEmail.Text);
      gravatarBigImage.Source = GravatarHelper.GetImageSource(gravatarEmail.Text, 150);
      gravatarWaveImage.Source = GravatarHelper.GetImageSource(gravatarEmail.Text, 80, GravatarHelper.DefaultImageTypes.Wavatar);
      gravatarXImage.Source = GravatarHelper.GetImageSource(gravatarEmail.Text, 80, GravatarHelper.DefaultImageTypes.Wavatar, GravatarHelper.RatingTypes.X);
      
    }

  }
}
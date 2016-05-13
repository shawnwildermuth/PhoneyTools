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

namespace PhoneyTools.Example.Views
{
  public partial class FadingMessageExamples : UserControl
  {
    public FadingMessageExamples()
    {
      InitializeComponent();
    }

    private void simpleMessageButton_Click(object sender, RoutedEventArgs e)
    {
      status.Text = "";
      if (!FadingMessage.Show("Saved..."))
      {
        status.Text = "Message Not Shown...Can't have concurrent messages.";
      }
    }

    private void longMessageButton_Click(object sender, RoutedEventArgs e)
    {
      status.Text = "";
      if (!FadingMessage.Show("This is a big deal that should be testing the entire message size of the page."))
      {
        status.Text = "Message Not Shown...Can't have concurrent messages.";
      }
    }

    private void customMessageButton_Click(object sender, RoutedEventArgs e)
    {
      status.Text = "";

      FadingMessage msg = new FadingMessage()
      {
        MessageToShow = theMessage,
        VerticalAlignment = VerticalAlignment.Top,
        HorizontalAlignment = HorizontalAlignment.Right
      };

      if (!msg.Show(3000)) // 3 seconds
      {
        status.Text = "Message Not Shown...Can't have concurrent messages.";
      }
    }

    private void derivedButton_Click(object sender, RoutedEventArgs e)
    {
      status.Text = "";
      
      // Cannot use static versions if you want to derive
      // for Concurrent Messages. This is because you'll want to handle the 
      // UI problem of multiple messages (e.g. stacking or moving elements)

      var fadingMsg = new ConcurrentFadingMessage();

      if (!fadingMsg.ShowTextMessage("Concurrent Message"))
      {
        // Should never happen
        status.Text = "Message Not Shown...Can't have concurrent messages.";
      }
    }

  }

  public class ConcurrentFadingMessage : FadingMessage
  {
    protected override bool AllowConcurrentMessages
    {
      get
      {
        return true;
      }
    }
  }
}
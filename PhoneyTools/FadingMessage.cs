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
using System.Windows.Controls.Primitives;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Controls;
using System.Windows.Threading;
using AgiliTrain.PhoneyTools.SystemResources;

namespace AgiliTrain.PhoneyTools
{
  /// <summary>
  /// A Class to show a message as a popup for 
  /// a certain length of time and fade out.
  /// </summary>
  public class FadingMessage
  {
    private static bool _isActive = false;
    private static object _lock = new object();

    /// <summary>
    /// Initializes a new instance of the <see cref="FadingMessage"/> class.
    /// </summary>
    public FadingMessage()
    {
      HorizontalAlignment = HorizontalAlignment.Center;
      VerticalAlignment = VerticalAlignment.Center;
      MessageWrapper = new Popup();
    }

    /// <summary>
    /// Shows the text message. (Does not support concurrent messages.)
    /// </summary>
    /// <param name="message">The message.</param>
    /// <param name="args">The args.</param>
    /// <returns>Did the message Show?</returns>
    public static bool Show(string message, int milliseconds, params object[] args)
    {
      return Show(string.Format(message, args), milliseconds);
    }

    /// <summary>
    /// Shows the text message. (Does not support concurrent messages.)
    /// </summary>
    /// <param name="message">The message.</param>
    /// <param name="args">The args.</param>
    /// <returns>Did the message Show?</returns>
    public static bool Show(string message, params object[] args)
    {
      return Show(string.Format(message, args));
    }

    /// <summary>
    /// Shows the text message. (Does not support concurrent messages.)
    /// </summary>
    /// <param name="message">The message.</param>
    /// <param name="milliseconds">The timeout.</param>
    /// <returns>Did the message Show?</returns>
    public static bool Show(string message, int milliseconds = 2000)
    {
      var fading = new FadingMessage();

      return fading.ShowTextMessage(message, milliseconds);
    }

    /// <summary>
    /// Shows the specified xaml message. (Does not support concurrent messages.)
    /// </summary>
    /// <param name="xamlMessage">The xaml message.</param>
    /// <param name="milliseconds">The milliseconds.</param>
    /// <returns>Did the message Show?</returns>
    public static bool Show(FrameworkElement xamlMessage, int milliseconds = 2000)
    {
      var fading = new FadingMessage()
      {
        MessageToShow = xamlMessage
      };

      return fading.Show(milliseconds);
    }

    /// <summary>
    /// Shows the text message.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <param name="milliseconds">The milliseconds.</param>
    /// <returns>Did the message Show?</returns>
    public bool ShowTextMessage(string message, int milliseconds = 2000)
    {
      MessageToShow = StandardMessage(message);

      return Show(milliseconds);
    }

    /// <summary>
    /// Occurs when Message has completed being shown.
    /// </summary>
    public event EventHandler Completed;

    void RaiseCompleted()
    {
      if (Completed != null)
      {
        Deployment.Current.Dispatcher.BeginInvoke(() => Completed(this, new EventArgs()));
      }
    }

    /// <summary>
    /// Standards the message.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <returns></returns>
    static FrameworkElement StandardMessage(string message)
    {
      var theContainer = new Border()
      {
        Background = PhoneBrushes.PhoneContrastBackgroundBrush,
        BorderBrush = PhoneBrushes.PhoneBorderBrush,
        BorderThickness = PhoneThicknesses.PhoneBorderThickness,
        CornerRadius = new CornerRadius(5)
      };

      theContainer.Child = new TextBlock()
      {
        Margin = PhoneThicknesses.PhoneMargin,
        TextWrapping = TextWrapping.Wrap,
        Style = PhoneTextStyles.PhoneTextNormalStyle,
        Foreground = PhoneBrushes.PhoneAccentBrush,
        Text = message
      };

      return theContainer;
    }

    protected virtual bool AllowConcurrentMessages
    {
      get { return false; }
    }

    /// <summary>
    /// Gets or sets the message to show.
    /// </summary>
    /// <value>
    /// The message to show.
    /// </value>
    public FrameworkElement MessageToShow
    {
      get;
      set;
    }

    /// <summary>
    /// Gets or sets the horizontal alignment.
    /// </summary>
    /// <value>
    /// The horizontal alignment.
    /// </value>
    public HorizontalAlignment HorizontalAlignment
    {
      get;
      set;
    }

    /// <summary>
    /// Gets or sets the vertical alignment.
    /// </summary>
    /// <value>
    /// The vertical alignment.
    /// </value>
    public VerticalAlignment VerticalAlignment
    {
      get;
      set;
    }

    /// <summary>
    /// Shows the specified message duration.
    /// </summary>
    /// <param name="messageDuration">Duration of the message.</param>
    /// <returns>Did the message show?</returns>
    public bool Show(int milliseconds)
    {
      // Prevent Concurrency
      if (!AllowConcurrentMessages)
      {
        lock (_lock)
        {
          if (_isActive)
          {
            return false;
          }
          _isActive = true;
        }
      }

      // Original Values
      var oldOpacity = MessageToShow.Opacity;
      var oldVerticalAlignment = MessageToShow.VerticalAlignment;
      var oldHortizontalAlignment = MessageToShow.HorizontalAlignment;
      var oldVisibility = MessageToShow.Visibility;
      Panel oldParent = null;

      // Get the current Frame
      var frame = Application.Current.RootVisual as PhoneApplicationFrame;
      if (frame == null)
      {
        throw new Exception("PhoneApplicationFrame must be the current Application's RootVisual. Basic Windows Phone 7 applications are set up this way.");
      }

      // Get current Page
      var page = frame.Content as PhoneApplicationPage;
      if (page == null)
      {
        throw new Exception("Current page must derive from Page.");
      }

      // Get the main container
      var panel = VisualTreeHelper.GetChild(page, 0) as Panel;
      if (panel == null)
      {
        throw new Exception("Main page must have a panel (e.g. container) as its child.");
      }

      // Remove from other host if any
      if (MessageToShow.Parent != null)
      {
        if (MessageToShow.Parent is Panel)
        {
          oldParent = (Panel)MessageToShow.Parent;
          oldParent.Children.Remove(MessageToShow);
        }
      }

      // Create the Popup
      var host = new Grid()
      {
        Width = page.ActualWidth,
        Height = page.ActualHeight
      };
      MessageToShow.VerticalAlignment = this.VerticalAlignment;
      MessageToShow.HorizontalAlignment = this.HorizontalAlignment;
      MessageToShow.Visibility = Visibility.Visible;
      host.Children.Add(MessageToShow);
      MessageWrapper.Child = host;

      // Add item to page
      panel.Children.Add(MessageWrapper);

      // Show it
      MessageWrapper.IsOpen = true;

      // Set Start Animation
      var showStory = CreateDisplayStoryboard();
      showStory.Completed += (s, e) =>
        {
          // Wait
          var waitTimer = new DispatcherTimer()
          {
            Interval = TimeSpan.FromMilliseconds(milliseconds)
          };
          waitTimer.Tick += (ts, te) =>
          {
            waitTimer.Stop();

            // Set End Animation
            var hideStory = CreateHideStoryboard();
            hideStory.Completed += (hs, he) =>
              {
                // Allow a new message created
                if (!AllowConcurrentMessages)
                {
                  lock (_lock)
                  {
                    _isActive = false;
                  }
                }

                // Show the contents so that it can be show with the animation
                MessageWrapper.IsOpen = false;

                // Fire the Completed Event
                RaiseCompleted();

                // Remove the Popup
                MessageWrapper.Child = null;
                panel.Children.Remove(MessageWrapper);
                host.Children.Remove(MessageToShow);
                MessageToShow.Visibility = oldVisibility;
                MessageToShow.Opacity = oldOpacity;
                MessageToShow.VerticalAlignment = oldVerticalAlignment;
                MessageToShow.HorizontalAlignment = oldHortizontalAlignment;
                if (oldParent != null)
                {
                  oldParent.Children.Add(MessageToShow);
                }
              };
            hideStory.Begin();
          };
          waitTimer.Start();
        };
      showStory.Begin();

      // We're showing the message
      return true;
    }

    /// <summary>
    /// Gets or sets the message wrapper.
    /// </summary>
    /// <value>
    /// The message wrapper.
    /// </value>
    protected virtual Popup MessageWrapper
    {
      get;
      set;
    }

    /// <summary>
    /// Creates the display storyboard.
    /// </summary>
    /// <param name="messageDuration">Duration of the message.</param>
    /// <returns></returns>
    protected virtual Storyboard CreateDisplayStoryboard()
    {
      var theStory = new Storyboard();

      var theAnimation = new DoubleAnimation()
      {
        Duration = new Duration(TimeSpan.FromMilliseconds(250)),
        From = 0,
        To = 1
      };
      Storyboard.SetTarget(theAnimation, this.MessageToShow);
      Storyboard.SetTargetProperty(theAnimation, new PropertyPath("Opacity"));
      theStory.Children.Add(theAnimation);

      return theStory;
    }

    /// <summary>
    /// Creates the display storyboard.
    /// </summary>
    /// <param name="messageDuration">Duration of the message.</param>
    /// <returns></returns>
    protected virtual Storyboard CreateHideStoryboard()
    {
      var theStory = new Storyboard();

      var theAnimation = new DoubleAnimation()
      {
        Duration = new Duration(TimeSpan.FromMilliseconds(250)),
        From = 1,
        To = 0
      };
      Storyboard.SetTarget(theAnimation, this.MessageToShow);
      Storyboard.SetTargetProperty(theAnimation, new PropertyPath("Opacity"));
      theStory.Children.Add(theAnimation);

      return theStory;
    }
  }
}

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

namespace AgiliTrain.PhoneyTools
{
  /// <summary>
  /// A Class to show a message as a popup for 
  /// a certain length of time and fade out.
  /// </summary>
  public class FadingMessage
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="FadingMessage"/> class.
    /// </summary>
    public FadingMessage()
    {
      HorizontalAlignment = HorizontalAlignment.Center;
      VerticalAlignment = VerticalAlignment.Center;
    }

    /// <summary>
    /// Gets or sets the message to show.
    /// </summary>
    /// <value>
    /// The message to show.
    /// </value>
    public UIElement MessageToShow
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
    public void Show(TimeSpan messageDuration)
    {

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
    protected virtual Storyboard CreateDisplayStoryboard(TimeSpan messageDuration)
    {
      return null;
    }
  }
}

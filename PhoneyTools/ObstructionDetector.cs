using System.Windows;
using System.Windows.Media;
using System.Linq;
using Microsoft.Phone.Controls;

namespace AgiliTrain.PhoneyTools
{
  /// <summary>
  /// Class to detect whether an object is currently obscured on the screen.  
  /// 
  /// This class via Alan Mendelevich (ailon@ailon.org) 
  /// </summary>
  public static class ObstructionDetector
  {
    /// <summary>
    /// Gets the page.
    /// </summary>
    /// <param name="target">The target.</param>
    /// <returns></returns>
    public static PhoneApplicationPage GetPage(DependencyObject target)
    {
      var parent = VisualTreeHelper.GetParent(target);
      while (parent != null && !(parent is PhoneApplicationPage))
      {
        parent = VisualTreeHelper.GetParent(parent);
      }

      return (parent as PhoneApplicationPage);
    }

    /// <summary>
    /// Gets the frame.
    /// </summary>
    /// <param name="target">The target.</param>
    /// <returns></returns>
    public static PhoneApplicationFrame GetFrame(DependencyObject target)
    {
      var parent = VisualTreeHelper.GetParent(target);
      while (parent != null && !(parent is PhoneApplicationFrame))
      {
        parent = VisualTreeHelper.GetParent(parent);
      }

      return (parent as PhoneApplicationFrame);
    }

    /// <summary>
    /// Transforms the bounds to portrait.
    /// </summary>
    /// <param name="bounds">The bounds.</param>
    /// <param name="page">The page.</param>
    /// <returns></returns>
    public static Rect TransformBoundsToPortrait(Rect bounds, PhoneApplicationPage page)
    {
      if ((page.Orientation & PageOrientation.Portrait) > 0)
      {
        return bounds;
      }
      else
      {
        Rect result;

        if (page.Orientation == PageOrientation.LandscapeLeft)
        {
          result = new Rect(bounds.Y, bounds.X, bounds.Height, bounds.Width);
        }
        else
        {
          result = new Rect(bounds.Y, 800 - bounds.X - bounds.Width, bounds.Height, bounds.Width);
        }

        return result;
      }
    }

    /// <summary>
    /// Determines whether [is element obstructed] [the specified target].
    /// </summary>
    /// <param name="target">The target.</param>
    /// <returns>
    ///   <c>true</c> if [is element obstructed] [the specified target]; otherwise, <c>false</c>.
    /// </returns>
    public static bool IsElementObstructed(FrameworkElement target)
    {
      var page = GetPage(target);
      var frame = GetFrame(target);
      var transform = target.TransformToVisual(frame);
      var rect = TransformBoundsToPortrait(transform.TransformBounds(new Rect(0, 0, target.ActualWidth, target.ActualHeight)), page);
      var covers = VisualTreeHelper.FindElementsInHostCoordinates(rect, page);

      if (covers != null && covers.Count() > 0)
      {
        return !IsElementChildOf(covers.First(), target);
      }

      return false;
    }

    public static bool IsElementChildOf(DependencyObject element, DependencyObject parent)
    {
      var current = element;
      while (current != null)
      {
        if (current == parent)
        {
          return true;
        }

        current = VisualTreeHelper.GetParent(current);
      }

      return false;
    }

  }
}

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
using System.Windows.Threading;
using Microsoft.Xna.Framework;

namespace AgiliTrain.PhoneyTools.Media
{
  /// <summary>
  /// Runs the FrameworkDispatcher.Update to allow for XNA 
  /// API's to work
  /// </summary>
  public class GameTimer
  {
    DispatcherTimer _timer = new DispatcherTimer()
    {
      Interval = TimeSpan.FromMilliseconds(50),
    };

    /// <summary>
    /// Initializes a new instance of the <see cref="GameTimer"/> class.
    /// </summary>
    public GameTimer()
    {
      _timer.Tick += new EventHandler(_timer_Tick);
    }

    void _timer_Tick(object sender, EventArgs e)
    {
      FrameworkDispatcher.Update();
      if (Updated != null) Updated(this, new EventArgs());
    }

    /// <summary>
    /// Occurs when the Timer Updates.
    /// </summary>
    public event EventHandler Updated;

    /// <summary>
    /// Starts this instance.
    /// </summary>
    public void Start()
    {
      if (!_timer.IsEnabled) _timer.Start();
    }

    /// <summary>
    /// Stops this instance.
    /// </summary>
    public void Stop()
    {
      if (_timer.IsEnabled) _timer.Stop();
    }

  }
}

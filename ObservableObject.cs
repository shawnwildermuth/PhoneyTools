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
using System.ComponentModel;

namespace AgiliTrain.PhoneyTools
{
  /// <summary>
  /// Base class for any object that requires the INotifyPropertyChanged.
  /// </summary>
  public abstract class ObservableObject : INotifyPropertyChanged
  {
    /// <summary>
    /// Occurs when a property value changes.
    /// </summary>
    public event PropertyChangedEventHandler PropertyChanged;

    /// <summary>
    /// Raises the property changed.
    /// </summary>
    /// <remarks>The event is called on the UI thread.</remarks>
    /// <param name="propertyName">Name of the property.</param>
    protected void RaisePropertyChanged(string propertyName)
    {
      Deployment.Current.Dispatcher.BeginInvoke(() =>
        {
          if (PropertyChanged != null)
          {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
          }
        });
    }
  }
}

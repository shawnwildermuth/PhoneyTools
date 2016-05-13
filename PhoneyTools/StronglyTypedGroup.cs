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
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;

namespace AgiliTrain.PhoneyTools
{
  /// <summary>
  /// A Strongly Typed version of IGrouping to allow for data binding. 
  /// </summary>
  /// <typeparam name="T">The IGrouping result that is typically the result of a LINQ query.</typeparam>
  public class StronglyTypedGroup<T> : ObservableCollection<T>
  {
    /// <summary>
    /// The constructor that creates the object from a grouping interface.
    /// </summary>
    /// <param name="group"></param>
    public StronglyTypedGroup(IGrouping<string,T> group)
    {
      // Strongly type the key to the group name for data binding
      GroupName = group.Key;

      // Add the results to the collection
      foreach (var i in group) this.Add(i);
    }

    /// <summary>
    /// The name of the group
    /// </summary>
    public string GroupName { get; private set; }
  }
}

using System;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections;
using System.Windows.Markup;
using System.Reflection;
using System.IO;

namespace AgiliTrain.PhoneyTools.Controls
{
  public class SimpleLongListSelector : LongListSelector
  {

    static ResourceDictionary _localResources = null;

    static ResourceDictionary LocalResources
    {
      get
      {
        if (_localResources == null)
        {
          var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("AgiliTrain.PhoneyTools.Xaml.SimpleLongListSelector.xaml");
          var rdr = new StreamReader(stream);
          string xaml = rdr.ReadToEnd();
          _localResources = (ResourceDictionary)XamlReader.Load(xaml);
        }
        return _localResources;
      }
    }

    public SimpleLongListSelector()
    {
      GroupItemTemplate = (DataTemplate)LocalResources["SimpleLongListSelectorGroupTemplate"];
      GroupHeaderTemplate = (DataTemplate)LocalResources["SimpleLongListSelectorGroupTemplate"];
      ItemTemplate = (DataTemplate)LocalResources["SimpleLongListSelectorItemTemplate"];
    }

    public override void OnApplyTemplate()
    {
      base.OnApplyTemplate();

      if (ItemsSource == null)
      {
        ItemsSource = _items;
      }
    }

    IList _items;

    public void SetGroupingItemsSource<T>(IEnumerable<IGrouping<string, T>> results) 
    {
      if (_items == null)
      {
        _items = new ObservableCollection<StronglyTypedGroup<T>>();
      }
      else
      {
        _items.Clear();
      }

      foreach (var group in results)
      {
        _items.Add(new StronglyTypedGroup<T>(group));
      }
    }
    
  }
}

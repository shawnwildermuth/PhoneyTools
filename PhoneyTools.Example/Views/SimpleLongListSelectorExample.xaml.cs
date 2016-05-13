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
using VideoGames;

namespace PhoneyTools.Example.Views
{
  public partial class SimpleLongListSelectorExample : UserControl
  {
    public SimpleLongListSelectorExample()
    {
      InitializeComponent();

      var games = new GameList();

      var qry = from g in games
                orderby g.Genre, g.Name
                group g.Name by g.Genre into genre
                select genre;

      longList.SetGroupingItemsSource<string>(qry.ToList());

      // For Complex Object and ItemTemplate
      //var qry = from g in games
      //          orderby g.Genre, g.Name
      //          group g by g.Genre into genre
      //          select genre;

      //longList.SetGroupingItemsSource<Game>(qry.ToList());

    }
  }
}

﻿using System;
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
using Microsoft.Silverlight.Testing;
using Microsoft.Phone.Shell;

namespace PhoneyTools.Tests
{
  public partial class MainPage : PhoneApplicationPage
  {
    // Constructor
    public MainPage()
    {
      InitializeComponent();

      Loaded += new RoutedEventHandler(MainPage_Loaded);
    }

    void MainPage_Loaded(object sender, RoutedEventArgs e)
    {
      SystemTray.IsVisible = false;

      var settings = UnitTestSystem.CreateDefaultSettings();
      settings.ShowTagExpressionEditor = false;
      settings.TagExpression = "InputPanelProviderTests";
      settings.StartRunImmediately = true;
      var testPage = UnitTestSystem.CreateTestPage(settings) as IMobileTestPage;
      BackKeyPress += (x, xe) => xe.Cancel = testPage.NavigateBack();
      (Application.Current.RootVisual as PhoneApplicationFrame).Content = testPage;       
    }
  }
}
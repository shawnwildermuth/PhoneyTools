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
using Microsoft.Phone.Controls;

namespace AgiliTrain.PhoneyTools.Controls
{
  /// <summary>
  /// A TextBox replacement that supports a built-in Clear button
  /// </summary>
  [TemplatePart(Name = TheTextBox, Type = typeof(TextBox))]
  [TemplatePart(Name = ClearButton, Type = typeof(UIElement))]
  [TemplateVisualState(Name = Focused, GroupName = "FocusGroup")]
  [TemplateVisualState(Name = Unfocused, GroupName="FocusGroup")]
#if MANGO
  [Obsolete("The ClearableTextBox has been obsoleted.  Use the PhoneTextBox from the Silverlight Toolkit for Windows Phone 7.1 instead")]
#endif
  public class ClearableTextBox : Control
  {
    private const string TheTextBox = "TheTextBox";
    private const string ClearButton = "ClearButton";
    private const string Focused = "Focused";
    private const string Unfocused = "Unfocused";
    protected TextBox _theTextBox;
    protected UIElement _clearButton;

    /// <summary>
    /// Initializes a new instance of the <see cref="ClearableTextBox"/> class.
    /// </summary>
    public ClearableTextBox()
    {
      this.DefaultStyleKey = typeof(ClearableTextBox);

#if MANGO
      Tap += (s, e) =>
      {
        if (_theTextBox != null) _theTextBox.Focus();
      };
#else
      GestureService.GetGestureListener(this).Tap += (s, e) =>
        {
          if (_theTextBox != null) _theTextBox.Focus();
        };
#endif

    }

    /// <summary>
    /// When overridden in a derived class, is invoked whenever application code or internal processes (such as a rebuilding layout pass) call <see cref="M:System.Windows.Controls.Control.ApplyTemplate"/>. In simplest terms, this means the method is called just before a UI element displays in an application. For more information, see Remarks.
    /// </summary>
    public override void OnApplyTemplate()
    {
      base.OnApplyTemplate();

      // Unwire
      if (_clearButton != null) GestureService.GetGestureListener(_clearButton).Tap -= ClearButton_Tap;
      if (_theTextBox != null)
      {
        _theTextBox.GotFocus -= _theTextBox_GotFocus;
        _theTextBox.LostFocus -= _theTextBox_LostFocus;
      }
 
      // Get the items from the Template
      _theTextBox = (TextBox)GetTemplateChild(TheTextBox);
      _clearButton = (UIElement)GetTemplateChild(ClearButton);

      // Wire the new button
      GestureService.GetGestureListener(_clearButton).Tap += ClearButton_Tap;
      _theTextBox.GotFocus += _theTextBox_GotFocus;
      _theTextBox.LostFocus += _theTextBox_LostFocus;
      _theTextBox.TextChanged += _theTextBox_TextChanged;

      // Set the properties if set by XAML
      _theTextBox.Text = Text ?? "";
      _theTextBox.AcceptsReturn = AcceptsReturn;
      _theTextBox.HorizontalScrollBarVisibility = HorizontalScrollBarVisibility;
      _theTextBox.InputScope = InputScope;
      _theTextBox.IsEnabled = IsEnabled;
      _theTextBox.IsReadOnly = IsReadOnly;
      _theTextBox.SelectedText = SelectedText ?? "";
      _theTextBox.SelectionLength = SelectionLength;
      _theTextBox.SelectionStart = SelectionStart;
      _theTextBox.TextAlignment = TextAlignment;
      _theTextBox.TextWrapping = TextWrapping;
      _theTextBox.VerticalScrollBarVisibility = VerticalScrollBarVisibility;
    }

    void _theTextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
      SetValue(TextProperty, _theTextBox.Text);
    }

    void _theTextBox_LostFocus(object sender, RoutedEventArgs e)
    {
      VisualStateManager.GoToState(this, Unfocused, true);
    }

    void _theTextBox_GotFocus(object sender, RoutedEventArgs e)
    {
      VisualStateManager.GoToState(this, Focused, true);
    }

    void ClearButton_Tap(object sender, Microsoft.Phone.Controls.GestureEventArgs e)
    {
      Text = "";
      _theTextBox.Text = "";
    }

    /// <summary>
    /// A description of the property.
    /// </summary>
    [Category("Text")]
    [Description("The text  in the control.")]
    public string Text
    {
      get { return (string)GetValue(TextProperty); }
      set { SetValue(TextProperty, value); }
    }

    public static readonly DependencyProperty TextProperty =
        DependencyProperty.Register("Text", typeof(string), typeof(ClearableTextBox),
        new PropertyMetadata("", new PropertyChangedCallback(OnTextChanged)));

    /// <summary>
    /// Called when [text changed].
    /// </summary>
    /// <param name="d">The d.</param>
    /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
    private static void OnTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      ((ClearableTextBox)d).OnTextChanged(e);
    }

    /// <summary>
    /// Raises the <see cref="E:TextChanged"/> event.
    /// </summary>
    /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
    protected virtual void OnTextChanged(DependencyPropertyChangedEventArgs e)
    {
      if (_theTextBox != null)
      {
        _theTextBox.Text = (string)e.NewValue;
      }
    }


    #region TextWrapping (DependencyProperty)

    /// <summary>
    /// A description of the property.
    /// </summary>
    public TextWrapping TextWrapping
    {
      get { return (TextWrapping)GetValue(TextWrappingProperty); }
      set { SetValue(TextWrappingProperty, value); }
    }
    public static readonly DependencyProperty TextWrappingProperty =
        DependencyProperty.Register("TextWrapping", typeof(TextWrapping), typeof(ClearableTextBox),
        new PropertyMetadata(TextWrapping.NoWrap, new PropertyChangedCallback(OnTextWrappingChanged)));

    private static void OnTextWrappingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      ((ClearableTextBox)d).OnTextWrappingChanged(e);
    }

    protected virtual void OnTextWrappingChanged(DependencyPropertyChangedEventArgs e)
    {
      if (_theTextBox != null) _theTextBox.TextWrapping = (TextWrapping)e.NewValue;
    }

    #endregion


    #region InputScope (DependencyProperty)

    /// <summary>
    /// The Inputscope for the Underlying TextBox
    /// </summary>
    public InputScope InputScope
    {
      get { return (InputScope)GetValue(InputScopeProperty); }
      set { SetValue(InputScopeProperty, value); }
    }
    public static readonly DependencyProperty InputScopeProperty =
        DependencyProperty.Register("InputScope", typeof(InputScope), typeof(ClearableTextBox),
        new PropertyMetadata(null, new PropertyChangedCallback(OnInputScopeChanged)));

    private static void OnInputScopeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      ((ClearableTextBox)d).OnInputScopeChanged(e);
    }

    protected virtual void OnInputScopeChanged(DependencyPropertyChangedEventArgs e)
    {
      if (_theTextBox != null) _theTextBox.InputScope = (InputScope)e.NewValue;
    }

    #endregion


    #region AcceptsReturn (DependencyProperty)

    /// <summary>
    /// Whether the TextBox can accept a Return key
    /// </summary>
    public bool AcceptsReturn
    {
      get { return (bool)GetValue(AcceptsReturnProperty); }
      set { SetValue(AcceptsReturnProperty, value); }
    }
    public static readonly DependencyProperty AcceptsReturnProperty =
        DependencyProperty.Register("AcceptsReturn", typeof(bool), typeof(ClearableTextBox),
        new PropertyMetadata(false, new PropertyChangedCallback(OnAcceptsReturnChanged)));

    private static void OnAcceptsReturnChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      ((ClearableTextBox)d).OnAcceptsReturnChanged(e);
    }

    protected virtual void OnAcceptsReturnChanged(DependencyPropertyChangedEventArgs e)
    {
      if (_theTextBox != null) _theTextBox.AcceptsReturn = (bool)e.NewValue;
    }

    #endregion


    #region IsReadOnly (DependencyProperty)

    /// <summary>
    /// Whether the TextBox is ReadOnly
    /// </summary>
    public bool IsReadOnly
    {
      get { return (bool)GetValue(IsReadOnlyProperty); }
      set { SetValue(IsReadOnlyProperty, value); }
    }
    public static readonly DependencyProperty IsReadOnlyProperty =
        DependencyProperty.Register("IsReadOnly", typeof(bool), typeof(ClearableTextBox),
        new PropertyMetadata(false, new PropertyChangedCallback(OnIsReadOnlyChanged)));

    private static void OnIsReadOnlyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      ((ClearableTextBox)d).OnIsReadOnlyChanged(e);
    }

    protected virtual void OnIsReadOnlyChanged(DependencyPropertyChangedEventArgs e)
    {
      if (_theTextBox != null)
      {
        _theTextBox.IsReadOnly = (bool)e.NewValue;
        _clearButton.Visibility = _theTextBox.IsReadOnly ? Visibility.Collapsed : Visibility.Visible;
      }
    }

    #endregion


    #region TextAlignment (DependencyProperty)

    /// <summary>
    /// The Text Alignment of the Textbox part of the control.
    /// </summary>
    public TextAlignment TextAlignment
    {
      get { return (TextAlignment)GetValue(TextAlignmentProperty); }
      set { SetValue(TextAlignmentProperty, value); }
    }
    public static readonly DependencyProperty TextAlignmentProperty =
        DependencyProperty.Register("TextAlignment", typeof(TextAlignment), typeof(ClearableTextBox),
        new PropertyMetadata(TextAlignment.Left, new PropertyChangedCallback(OnTextAlignmentChanged)));

    private static void OnTextAlignmentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      ((ClearableTextBox)d).OnTextAlignmentChanged(e);
    }

    protected virtual void OnTextAlignmentChanged(DependencyPropertyChangedEventArgs e)
    {
      if (_theTextBox != null) _theTextBox.TextAlignment = (TextAlignment)e.NewValue;
    }

    #endregion


    #region VerticalScrollBarVisibility (DependencyProperty)

    /// <summary>
    /// Whether to show the ScrollBar
    /// </summary>
    public ScrollBarVisibility VerticalScrollBarVisibility
    {
      get { return (ScrollBarVisibility)GetValue(VerticalScrollBarVisibilityProperty); }
      set { SetValue(VerticalScrollBarVisibilityProperty, value); }
    }
    public static readonly DependencyProperty VerticalScrollBarVisibilityProperty =
        DependencyProperty.Register("VerticalScrollBarVisibility", typeof(ScrollBarVisibility), typeof(ClearableTextBox),
        new PropertyMetadata(ScrollBarVisibility.Auto, new PropertyChangedCallback(OnVerticalScrollBarVisibilityChanged)));

    private static void OnVerticalScrollBarVisibilityChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      ((ClearableTextBox)d).OnVerticalScrollBarVisibilityChanged(e);
    }

    protected virtual void OnVerticalScrollBarVisibilityChanged(DependencyPropertyChangedEventArgs e)
    {
      if (_theTextBox != null) _theTextBox.VerticalScrollBarVisibility = (ScrollBarVisibility)e.NewValue;
    }

    #endregion


    #region HorizontalScrollBarVisibility (DependencyProperty)

    /// <summary>
    /// Whether the scroll bar is shown.
    /// </summary>
    public ScrollBarVisibility HorizontalScrollBarVisibility
    {
      get { return (ScrollBarVisibility)GetValue(HorizontalScrollBarVisibilityProperty); }
      set { SetValue(HorizontalScrollBarVisibilityProperty, value); }
    }
    public static readonly DependencyProperty HorizontalScrollBarVisibilityProperty =
        DependencyProperty.Register("HorizontalScrollBarVisibility", typeof(ScrollBarVisibility), typeof(ClearableTextBox),
        new PropertyMetadata(ScrollBarVisibility.Hidden, new PropertyChangedCallback(OnHorizontalScrollBarVisibilityChanged)));

    private static void OnHorizontalScrollBarVisibilityChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      ((ClearableTextBox)d).OnHorizontalScrollBarVisibilityChanged(e);
    }

    protected virtual void OnHorizontalScrollBarVisibilityChanged(DependencyPropertyChangedEventArgs e)
    {
      if (_theTextBox != null) _theTextBox.HorizontalScrollBarVisibility = (ScrollBarVisibility)e.NewValue;
    }

    #endregion

    /// <summary>
    /// Selects the specified Text.
    /// </summary>
    /// <param name="start">The start.</param>
    /// <param name="length">The length.</param>
    public void Select(int start, int length)
    {
      _theTextBox.Select(start, length);
    }

    /// <summary>
    /// Selects all Text.
    /// </summary>
    public void SelectAll()
    {
      _theTextBox.SelectAll();
    }

    /// <summary>
    /// Gets or sets the selected text.
    /// </summary>
    /// <value>
    /// The selected text.
    /// </value>
    public string SelectedText 
    { 
      set
      {
        _theTextBox.SelectedText = value;
      }
      get
      {
        return _theTextBox.SelectedText;
      }
    }

    /// <summary>
    /// Gets or sets the length of the selection.
    /// </summary>
    /// <value>
    /// The length of the selection.
    /// </value>
    public int SelectionLength 
    {
      set
      {
        _theTextBox.SelectionLength = value;
      }
      get
      {
        return _theTextBox.SelectionLength;
      }
    }

    /// <summary>
    /// Gets or sets the selection start.
    /// </summary>
    /// <value>
    /// The selection start.
    /// </value>
    public int SelectionStart
    {
      set
      {
        _theTextBox.SelectionStart = value;
      }
      get
      {
        return _theTextBox.SelectionStart;
      }
    }

  }
}

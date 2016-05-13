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
using System.Globalization;
using AgiliTrain.PhoneyTools.SystemResources;
using System.ComponentModel;
using Microsoft.Phone.Controls;

namespace AgiliTrain.PhoneyTools.Controls
{
  [TemplateVisualState(Name = OnStateName, GroupName = SwitchStates)]
  [TemplateVisualState(Name = OffStateName, GroupName = SwitchStates)]
  [TemplateVisualState(Name = NormalStateName, GroupName = CommonStates)]
  [TemplateVisualState(Name = DisabledStateName, GroupName = CommonStates)]
  [TemplatePart(Name = TheSwitchPart, Type = typeof(UIElement))]
  [TemplatePart(Name = TextIndicator, Type = typeof(TextBlock))]
  public class SelectSwitch : ContentControl
  {
    private const string TheSwitchPart = "Switch";
    private const string TextIndicator = "TextIndicator";
    private const string SwitchStates = "SwitchStates";
    private const string CommonStates = "CommonStates";
    private const string OnStateName = "OnState";
    private const string OffStateName = "OffState";
    private const string NormalStateName = "NormalState";
    private const string DisabledStateName = "DisabledState";

    private UIElement _theSwitch = null;
    private TextBlock _textIndicator = null;

    public SelectSwitch()
    {
      this.DefaultStyleKey = typeof(SelectSwitch);
    }

    /// <summary>
    /// Occurs when the SelectSwitch
    /// is clicked.
    /// </summary>
    public event EventHandler SelectedChanged;

    /// <summary>
    /// When overridden in a derived class, is invoked whenever application code or internal processes (such as a rebuilding layout pass) call <see cref="M:System.Windows.Controls.Control.ApplyTemplate"/>. In simplest terms, this means the method is called just before a UI element displays in an application. For more information, see Remarks.
    /// </summary>
    public override void OnApplyTemplate()
    {
      base.OnApplyTemplate();

      // Unwire events in case we're changed
      if (_theSwitch != null)
      {
        GestureService.GetGestureListener(_theSwitch).Tap -= SelectSwitch_Tap;
      }

      // Wire up the events to theSwitch
      _theSwitch = GetTemplateChild(TheSwitchPart) as UIElement;
      if (_theSwitch != null)
      {
        GestureService.GetGestureListener(_theSwitch).Tap += SelectSwitch_Tap;
      }

      // Get the TextBlock for the indicator
      _textIndicator = GetTemplateChild(TextIndicator) as TextBlock;
      if (_textIndicator != null)
      {
        _textIndicator.FontFamily = TextIndicatorFontFamily;
        _textIndicator.FontSize = TextIndicatorFontSize;
        _textIndicator.FontWeight = TextIndicatorFontWeight;
        _textIndicator.FontStretch = TextIndicatorFontStretch;
        _textIndicator.FontStyle = TextIndicatorFontStyle;
        _textIndicator.Foreground = TextIndicatorBrush;
        _textIndicator.Style = TextIndicatorStyle;
        SizeTextIndicator();
      }

      // Wire up to change the look of the controls
      IsEnabledChanged += (o, e) => ChangeState();

      // Force a change in case we have a default value
      ChangeState();

    }

    /// <summary>
    /// Handles the Tap event of the SelectSwitch control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="Microsoft.Phone.Controls.GestureEventArgs"/> instance containing the event data.</param>
    void SelectSwitch_Tap(object sender, Microsoft.Phone.Controls.GestureEventArgs e)
    {
      ToggleSelection();
    }

    /// <summary>
    /// Toggles the selection.
    /// </summary>
    void ToggleSelection()
    {
      IsSelected = !IsSelected;
    }


    /// <summary>
    /// Determines if the item is checked (e.g. Selected)
    /// </summary>
    [Category("Common Properties")]
    [Description("Whether the Switch is Selected or not")]
    public bool IsSelected
    {
      get { return (bool)GetValue(IsCheckedProperty); }
      set { SetValue(IsCheckedProperty, value); }
    }
    /// <summary>
    /// Registers the IsChecked property as a dependency property.
    /// </summary>
    public static readonly DependencyProperty IsCheckedProperty =
        DependencyProperty.Register("IsSelected", typeof(bool), typeof(SelectSwitch),
        new PropertyMetadata(false, new PropertyChangedCallback(OnIsSelectedChanged)));

    /// <summary>
    /// Called when [is checked changed].
    /// </summary>
    /// <param name="d">The d.</param>
    /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
    private static void OnIsSelectedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      ((SelectSwitch)d).OnIsSelectedChanged(e);
    }

    /// <summary>
    /// Raises the <see cref="E:IsSelectedChanged"/> event.
    /// </summary>
    /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
    protected virtual void OnIsSelectedChanged(DependencyPropertyChangedEventArgs e)
    {
      ChangeState();
      RaiseSelectChanged();
    }

    /// <summary>
    /// This is the brush that is shown in the small 'light' indicator.
    /// </summary>
    [Category("Brushes")]
    [Description("The brush for the 'light' near the top of the control.")]
    public Brush IndicatorBrush
    {
      get { return (Brush)GetValue(IndicatorBrushProperty); }
      set { SetValue(IndicatorBrushProperty, value); }
    }
    public static readonly DependencyProperty IndicatorBrushProperty =
        DependencyProperty.Register("IndicatorBrush", typeof(Brush), typeof(SelectSwitch),
        new PropertyMetadata(PhoneBrushes.PhoneAccentBrush, new PropertyChangedCallback(OnIndicatorBrushChanged)));

    private static void OnIndicatorBrushChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      ((SelectSwitch)d).OnIndicatorBrushChanged(e);
    }

    protected virtual void OnIndicatorBrushChanged(DependencyPropertyChangedEventArgs e)
    {
      ChangeState(); // Force Repaint of the State in case the brush needs to be updated
    }


    /// <summary>
    /// The Text to show when the item is in the Selected state.
    /// </summary>
    [Category("SelectSwitch")]
    [Description("The text to show when the control is selected.  ('on' by default)")]
    public string SelectedText
    {
      get { return (string)GetValue(SelectedTextProperty); }
      set { SetValue(SelectedTextProperty, value); }
    }
    public static readonly DependencyProperty SelectedTextProperty =
        DependencyProperty.Register("SelectedText", typeof(string), typeof(SelectSwitch),
        new PropertyMetadata("on", new PropertyChangedCallback(OnSelectedTextChanged)));

    private static void OnSelectedTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      ((SelectSwitch)d).OnSelectedTextChanged(e);
    }

    protected virtual void OnSelectedTextChanged(DependencyPropertyChangedEventArgs e)
    {
      ChangeState(); // Force Repaint of the State in case the text needs to be updated
    }

    /// <summary>
    /// The Text to shown in the control when the control is in an Unselected state.
    /// </summary>
    [Category("SelectSwitch")]
    [Description("The text to show when the control is unselected.  ('off' by default)")]
    public string UnSelectedText
    {
      get { return (string)GetValue(UnSelectedTextProperty); }
      set { SetValue(UnSelectedTextProperty, value); }
    }
    public static readonly DependencyProperty UnSelectedTextProperty =
        DependencyProperty.Register("UnSelectedText", typeof(string), typeof(SelectSwitch),
        new PropertyMetadata("off", new PropertyChangedCallback(OnUnSelectedTextChanged)));

    private static void OnUnSelectedTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      ((SelectSwitch)d).OnUnSelectedTextChanged(e);
    }

    protected virtual void OnUnSelectedTextChanged(DependencyPropertyChangedEventArgs e)
    {
      ChangeState(); // Force Repaint of the State in case the text needs to be updated
    }


    /// <summary>
    /// The Size of the font for the Text Indicator
    /// </summary>
    [Category("SelectSwitch")]
    [Description("The FontSize of the text on the indicator button.")]
    public double TextIndicatorFontSize
    {
      get { return (double)GetValue(TextIndicatorFontSizeProperty); }
      set { SetValue(TextIndicatorFontSizeProperty, value); }
    }
    public static readonly DependencyProperty TextIndicatorFontSizeProperty =
        DependencyProperty.Register("TextIndicatorFontSize", typeof(double), typeof(SelectSwitch),
        new PropertyMetadata(14d, new PropertyChangedCallback(OnTextIndicatorFontSizeChanged)));

    private static void OnTextIndicatorFontSizeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      ((SelectSwitch)d).OnTextIndicatorFontSizeChanged(e);
    }

    protected virtual void OnTextIndicatorFontSizeChanged(DependencyPropertyChangedEventArgs e)
    {
      if (_textIndicator != null)
      {
        _textIndicator.FontSize = TextIndicatorFontSize;
        SizeTextIndicator();
      }
    }

    /// <summary>
    /// The Font Family of the Text Indicator
    /// </summary>
    [Category("SelectSwitch")]
    [Description("The FontFamily of the text on the indicator button.")]
    public FontFamily TextIndicatorFontFamily
    {
      get { return (FontFamily)GetValue(TextIndicatorFontFamilyProperty); }
      set { SetValue(TextIndicatorFontFamilyProperty, value); }
    }
    public static readonly DependencyProperty TextIndicatorFontFamilyProperty =
        DependencyProperty.Register("TextIndicatorFontFamily", typeof(FontFamily), typeof(SelectSwitch),
        new PropertyMetadata(null, new PropertyChangedCallback(OnTextIndicatorFontFamilyChanged)));

    private static void OnTextIndicatorFontFamilyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      ((SelectSwitch)d).OnTextIndicatorFontFamilyChanged(e);
    }

    protected virtual void OnTextIndicatorFontFamilyChanged(DependencyPropertyChangedEventArgs e)
    {
      if (_textIndicator != null)
      {
        _textIndicator.FontFamily = TextIndicatorFontFamily;
        SizeTextIndicator();
      }
    }

    /// <summary>
    /// The Font Weight of the Text Indicator
    /// </summary>
    [Category("SelectSwitch")]
    [Description("The FontWeight of the text on the indicator button.")]
    public FontWeight TextIndicatorFontWeight
    {
      get { return (FontWeight)GetValue(TextIndicatorFontWeightProperty); }
      set { SetValue(TextIndicatorFontWeightProperty, value); }
    }
    public static readonly DependencyProperty TextIndicatorFontWeightProperty =
        DependencyProperty.Register("TextIndicatorFontWeight", typeof(FontWeight), typeof(SelectSwitch),
        new PropertyMetadata(FontWeights.Normal, new PropertyChangedCallback(OnTextIndicatorFontWeightChanged)));

    private static void OnTextIndicatorFontWeightChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      ((SelectSwitch)d).OnTextIndicatorFontWeightChanged(e);
    }

    protected virtual void OnTextIndicatorFontWeightChanged(DependencyPropertyChangedEventArgs e)
    {
      if (_textIndicator != null)
      {
        _textIndicator.FontWeight = TextIndicatorFontWeight;
        SizeTextIndicator();
      }
    }

    /// <summary>
    /// The Brush to paint the TextIndicator
    /// </summary>
    [Category("SelectSwitch")]
    [Description("The brush that is used to paint the text on the indicator button.")]
    public Brush TextIndicatorBrush
    {
      get { return (Brush)GetValue(TextIndicatorBrushProperty); }
      set { SetValue(TextIndicatorBrushProperty, value); }
    }
    public static readonly DependencyProperty TextIndicatorBrushProperty =
        DependencyProperty.Register("TextIndicatorBrush", typeof(Brush), typeof(SelectSwitch),
        new PropertyMetadata(PhoneBrushes.PhoneForegroundBrush, new PropertyChangedCallback(OnTextIndicatorBrushChanged)));

    private static void OnTextIndicatorBrushChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      ((SelectSwitch)d).OnTextIndicatorBrushChanged(e);
    }

    protected virtual void OnTextIndicatorBrushChanged(DependencyPropertyChangedEventArgs e)
    {
      if (_textIndicator != null)
      {
        _textIndicator.Foreground = TextIndicatorBrush;
      }
    }

    /// <summary>
    /// The Font Style to use for the TextIndicator
    /// </summary>
    [Category("SelectSwitch")]
    [Description("The FontStyle of the text on the indicator button.")]
    public FontStyle TextIndicatorFontStyle
    {
      get { return (FontStyle)GetValue(TextIndicatorFontStyleProperty); }
      set { SetValue(TextIndicatorFontStyleProperty, value); }
    }
    public static readonly DependencyProperty TextIndicatorFontStyleProperty =
        DependencyProperty.Register("TextIndicatorFontStyle", typeof(FontStyle), typeof(SelectSwitch),
        new PropertyMetadata(FontStyles.Normal, new PropertyChangedCallback(OnTextIndicatorFontStyleChanged)));

    private static void OnTextIndicatorFontStyleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      ((SelectSwitch)d).OnTextIndicatorFontStyleChanged(e);
    }

    protected virtual void OnTextIndicatorFontStyleChanged(DependencyPropertyChangedEventArgs e)
    {
      if (_textIndicator != null)
      {
        _textIndicator.FontStyle = TextIndicatorFontStyle;
        SizeTextIndicator();
      }
    }

    /// <summary>
    /// The FontStretch for the Text Indicator
    /// </summary>
    [Category("SelectSwitch")]
    [Description("The FontStretch of the text on the indicator button.")]
    public FontStretch TextIndicatorFontStretch
    {
      get { return (FontStretch)GetValue(TextIndicatorFontStretchProperty); }
      set { SetValue(TextIndicatorFontStretchProperty, value); }
    }
    public static readonly DependencyProperty TextIndicatorFontStretchProperty =
        DependencyProperty.Register("TextIndicatorFontStretch", typeof(FontStretch), typeof(SelectSwitch),
        new PropertyMetadata(FontStretches.Normal, new PropertyChangedCallback(OnTextIndicatorFontStretchChanged)));

    private static void OnTextIndicatorFontStretchChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      ((SelectSwitch)d).OnTextIndicatorFontStretchChanged(e);
    }

    protected virtual void OnTextIndicatorFontStretchChanged(DependencyPropertyChangedEventArgs e)
    {
      if (_textIndicator != null)
      {
        _textIndicator.FontStretch = TextIndicatorFontStretch;
        SizeTextIndicator();
      }
    }

    /// <summary>
    /// The Style for the TextIndicator (TextBlock Style).
    /// </summary>
    [Category("SelectSwitch")]
    [Description("The Style of the text on the indicator button.")]
    public Style TextIndicatorStyle
    {
      get { return (Style)GetValue(TextIndicatorStyleProperty); }
      set { SetValue(TextIndicatorStyleProperty, value); }
    }
    public static readonly DependencyProperty TextIndicatorStyleProperty =
        DependencyProperty.Register("TextIndicatorStyle", typeof(Style), typeof(SelectSwitch),
        new PropertyMetadata(null, new PropertyChangedCallback(OnTextIndicatorStyleChanged)));

    private static void OnTextIndicatorStyleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      ((SelectSwitch)d).OnTextIndicatorStyleChanged(e);
    }

    protected virtual void OnTextIndicatorStyleChanged(DependencyPropertyChangedEventArgs e)
    {
      if (_textIndicator != null)
      {
        _textIndicator.Style = TextIndicatorStyle;
        SizeTextIndicator();
      }
    }

    /// <summary>
    /// Raises the select changed.
    /// </summary>
    void RaiseSelectChanged()
    {
      if (SelectedChanged != null)
      {
        SelectedChanged(this, new EventArgs());
      }
    }

    /// <summary>
    /// Uses the VSM to change the look of the control.
    /// </summary>
    void ChangeState()
    {
      if (IsSelected)
      {
        VisualStateManager.GoToState(this, OnStateName, true);
      }
      else
      {
        VisualStateManager.GoToState(this, OffStateName, true);
      }

      if (IsEnabled)
      {
        VisualStateManager.GoToState(this, NormalStateName, true);
      }
      else
      {
        VisualStateManager.GoToState(this, DisabledStateName, true);
      }

      if (_textIndicator != null)
      {
        _textIndicator.Text = IsSelected ? SelectedText : UnSelectedText;
      }

    }

    /// <summary>
    /// Sizes the text indicator to ensure the control doesn't change size.
    /// </summary>
    void SizeTextIndicator()
    {
      _textIndicator.Text = SelectedText;
      var selectedWidth = _textIndicator.ActualWidth;
      _textIndicator.Text = UnSelectedText;
      var unselectedWidth = _textIndicator.ActualWidth;
      _textIndicator.Text = IsSelected ? SelectedText : UnSelectedText;
      _textIndicator.MinWidth = Math.Max(selectedWidth, unselectedWidth) + 4; // Padding text to be sure its big enough
    }

    /// <summary>
    /// Returns a <see cref="System.String"/> that represents this instance.
    /// </summary>
    /// <returns>
    /// A <see cref="System.String"/> that represents this instance.
    /// </returns>
    public override string ToString()
    {
      return string.Format(
               CultureInfo.InvariantCulture,
               "{{SelectSwitch IsChecked={0}}}",
               IsSelected
           );
    }
  }
}

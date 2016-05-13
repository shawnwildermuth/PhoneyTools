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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AgiliTrain.PhoneyTools.SystemResources;

namespace PhoneyTools.Tests.Tests
{
  [TestClass]
  public class SystemResourceTests
  {
    [TestMethod]
    public void TestColors()
    {
      Assert.IsInstanceOfType(PhoneColors.PhoneAccentColor, typeof(Color));
      Assert.IsInstanceOfType(PhoneColors.PhoneBackgroundColor, typeof(Color));
      Assert.IsInstanceOfType(PhoneColors.PhoneBorderColor, typeof(Color));
      Assert.IsInstanceOfType(PhoneColors.PhoneChromeColor, typeof(Color));
      Assert.IsInstanceOfType(PhoneColors.PhoneContrastBackgroundColor, typeof(Color));
      Assert.IsInstanceOfType(PhoneColors.PhoneContrastForegroundColor, typeof(Color));
      Assert.IsInstanceOfType(PhoneColors.PhoneDisabledColor, typeof(Color));
      Assert.IsInstanceOfType(PhoneColors.PhoneForegroundColor, typeof(Color));
      Assert.IsInstanceOfType(PhoneColors.PhoneRadioCheckBoxCheckColor, typeof(Color));
      Assert.IsInstanceOfType(PhoneColors.PhoneRadioCheckBoxCheckDisabledColor, typeof(Color));
      Assert.IsInstanceOfType(PhoneColors.PhoneRadioCheckBoxColor, typeof(Color));
      Assert.IsInstanceOfType(PhoneColors.PhoneRadioCheckBoxDisabledColor, typeof(Color));
      Assert.IsInstanceOfType(PhoneColors.PhoneRadioCheckBoxPressedBorderColor, typeof(Color));
      Assert.IsInstanceOfType(PhoneColors.PhoneRadioCheckBoxPressedColor, typeof(Color));
      Assert.IsInstanceOfType(PhoneColors.PhoneSemitransparentColor, typeof(Color));
      Assert.IsInstanceOfType(PhoneColors.PhoneSubtleColor, typeof(Color));
      Assert.IsInstanceOfType(PhoneColors.PhoneTextBoxColor, typeof(Color));
      Assert.IsInstanceOfType(PhoneColors.PhoneTextBoxEditBackgroundColor, typeof(Color));
      Assert.IsInstanceOfType(PhoneColors.PhoneTextBoxEditBorderColor, typeof(Color));
      Assert.IsInstanceOfType(PhoneColors.PhoneTextBoxForegroundColor, typeof(Color));
      Assert.IsInstanceOfType(PhoneColors.PhoneTextBoxReadOnlyColor, typeof(Color));
      Assert.IsInstanceOfType(PhoneColors.PhoneTextBoxSelectionForegroundColor, typeof(Color));
      Assert.IsInstanceOfType(PhoneColors.PhoneTextCaretColor, typeof(Color));
    }

    [TestMethod]
    public void TestThicknesses()
    {
      Assert.IsInstanceOfType(PhoneThicknesses.PhoneBorderThickness, typeof(Thickness));
      Assert.IsInstanceOfType(PhoneThicknesses.PhoneHorizontalMargin, typeof(Thickness));
      Assert.IsInstanceOfType(PhoneThicknesses.PhoneMargin, typeof(Thickness));
      Assert.IsInstanceOfType(PhoneThicknesses.PhoneStrokeThickness, typeof(double));
      Assert.IsInstanceOfType(PhoneThicknesses.PhoneTouchTargetLargeOverhang, typeof(Thickness));
      Assert.IsInstanceOfType(PhoneThicknesses.PhoneTouchTargetOverhang, typeof(Thickness));
      Assert.IsInstanceOfType(PhoneThicknesses.PhoneVerticalMargin, typeof(Thickness));
    }

    [TestMethod]
    public void TestBrushes()
    {
      Assert.IsInstanceOfType(PhoneBrushes.PhoneAccentBrush, typeof(Brush));
      Assert.IsInstanceOfType(PhoneBrushes.PhoneBackgroundBrush, typeof(Brush));
      Assert.IsInstanceOfType(PhoneBrushes.PhoneBorderBrush, typeof(Brush));
      Assert.IsInstanceOfType(PhoneBrushes.PhoneChromeBrush, typeof(Brush));
      Assert.IsInstanceOfType(PhoneBrushes.PhoneContrastBackgroundBrush, typeof(Brush));
      Assert.IsInstanceOfType(PhoneBrushes.PhoneContrastForegroundBrush, typeof(Brush));
      Assert.IsInstanceOfType(PhoneBrushes.PhoneDisabledBrush, typeof(Brush));
      Assert.IsInstanceOfType(PhoneBrushes.PhoneForegroundBrush, typeof(Brush));
      Assert.IsInstanceOfType(PhoneBrushes.PhoneRadioCheckBoxBrush, typeof(Brush));
      Assert.IsInstanceOfType(PhoneBrushes.PhoneRadioCheckBoxCheckBrush, typeof(Brush));
      Assert.IsInstanceOfType(PhoneBrushes.PhoneRadioCheckBoxCheckDisabledBrush, typeof(Brush));
      Assert.IsInstanceOfType(PhoneBrushes.PhoneRadioCheckBoxDisabledBrush, typeof(Brush));
      Assert.IsInstanceOfType(PhoneBrushes.PhoneRadioCheckBoxPressedBorderBrush, typeof(Brush));
      Assert.IsInstanceOfType(PhoneBrushes.PhoneRadioCheckBoxPressedBrush, typeof(Brush));
      Assert.IsInstanceOfType(PhoneBrushes.PhoneSemitransparentBrush, typeof(Brush));
      Assert.IsInstanceOfType(PhoneBrushes.PhoneSubtleBrush, typeof(Brush));
      Assert.IsInstanceOfType(PhoneBrushes.PhoneTextBoxBrush, typeof(Brush));
      Assert.IsInstanceOfType(PhoneBrushes.PhoneTextBoxEditBackgroundBrush, typeof(Brush));
      Assert.IsInstanceOfType(PhoneBrushes.PhoneTextBoxEditBorderBrush, typeof(Brush));
      Assert.IsInstanceOfType(PhoneBrushes.PhoneTextBoxForegroundBrush, typeof(Brush));
      Assert.IsInstanceOfType(PhoneBrushes.PhoneTextBoxReadOnlyBrush, typeof(Brush));
      Assert.IsInstanceOfType(PhoneBrushes.PhoneTextBoxSelectionForegroundBrush, typeof(Brush));
      Assert.IsInstanceOfType(PhoneBrushes.PhoneTextCaretBrush, typeof(Brush));
      Assert.IsInstanceOfType(PhoneBrushes.TransparentBrush, typeof(Brush));
    }

    [TestMethod]
    public void TestFontFamilies()
    {
      Assert.IsInstanceOfType(PhoneFontFamilies.PhoneFontFamilyLight, typeof(FontFamily));
      Assert.IsInstanceOfType(PhoneFontFamilies.PhoneFontFamilyNormal, typeof(FontFamily));
      Assert.IsInstanceOfType(PhoneFontFamilies.PhoneFontFamilySemiBold, typeof(FontFamily));
      Assert.IsInstanceOfType(PhoneFontFamilies.PhoneFontFamilySemiLight, typeof(FontFamily));
    }

    [TestMethod]
    public void TestFontSizes()
    {
      Assert.IsInstanceOfType(PhoneFontSizes.PhoneFontSizeExtraExtraLarge, typeof(double));
      Assert.IsInstanceOfType(PhoneFontSizes.PhoneFontSizeExtraLarge, typeof(double));
      Assert.IsInstanceOfType(PhoneFontSizes.PhoneFontSizeHuge, typeof(double));
      Assert.IsInstanceOfType(PhoneFontSizes.PhoneFontSizeLarge, typeof(double));
      Assert.IsInstanceOfType(PhoneFontSizes.PhoneFontSizeMedium, typeof(double));
      Assert.IsInstanceOfType(PhoneFontSizes.PhoneFontSizeMediumLarge, typeof(double));
      Assert.IsInstanceOfType(PhoneFontSizes.PhoneFontSizeNormal, typeof(double));
      Assert.IsInstanceOfType(PhoneFontSizes.PhoneFontSizeSmall, typeof(double));
    }

    [TestMethod]
    public void TestTextStyles()
    {
      Assert.IsInstanceOfType(PhoneTextStyles.PhoneTextAccentStyle, typeof(Style));
      Assert.IsInstanceOfType(PhoneTextStyles.PhoneTextBlockBase, typeof(Style));
      Assert.IsInstanceOfType(PhoneTextStyles.PhoneTextContrastStyle, typeof(Style));
      Assert.IsInstanceOfType(PhoneTextStyles.PhoneTextExtraLargeStyle, typeof(Style));
      Assert.IsInstanceOfType(PhoneTextStyles.PhoneTextGroupHeaderStyle, typeof(Style));
      Assert.IsInstanceOfType(PhoneTextStyles.PhoneTextLargeStyle, typeof(Style));
      Assert.IsInstanceOfType(PhoneTextStyles.PhoneTextNormalStyle, typeof(Style));
      Assert.IsInstanceOfType(PhoneTextStyles.PhoneTextSmallStyle, typeof(Style));
      Assert.IsInstanceOfType(PhoneTextStyles.PhoneTextTitle1Style, typeof(Style));
      Assert.IsInstanceOfType(PhoneTextStyles.PhoneTextTitle2Style, typeof(Style));
      Assert.IsInstanceOfType(PhoneTextStyles.PhoneTextTitle3Style, typeof(Style));
    }

    [TestMethod]
    public void TestThemes()
    {
      Assert.IsTrue(PhoneTheme.IsDarkTheme);
      Assert.IsFalse(PhoneTheme.IsLightTheme);
    }
  }
}

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
using Microsoft.Xna.Framework.Audio;

namespace AgiliTrain.PhoneyTools.Media
{
  public class SoundEffectPlayer
  {
    GameTimer _xnaTimer = new GameTimer();
    SoundEffectInstance _effect = null;

    public SoundEffectPlayer(SoundEffect effect)
    {
      _effect = effect.CreateInstance();
      _xnaTimer.Updated += new EventHandler(_xnaTimer_Updated);
    }

    void _xnaTimer_Updated(object sender, EventArgs e)
    {
      if (_effect.State == SoundState.Stopped)
      {
        _xnaTimer.Stop();
      }
    }

    public void Play()
    {
      _xnaTimer.Start();
      _effect.Play();
    }
  }
}

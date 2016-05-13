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
using Microsoft.Phone.Controls;
using Microsoft.Xna.Framework.Audio;
using AgiliTrain.PhoneyTools.Media;
using AgiliTrain.PhoneyTools.Microphone;

namespace PhoneyTools.Example.Views
{
  public partial class MediaExamples : UserControl
  {
    public MediaExamples()
    {
      InitializeComponent();
    }

    SoundEffectPlayer _player = null;

    private void playButton_Click(object sender, RoutedEventArgs e)
    {
      var resource = Application.GetResourceStream(new Uri("alert.wav", UriKind.Relative));
      var effect = SoundEffect.FromStream(resource.Stream);
      _player = new SoundEffectPlayer(effect);
      _player.Play();
    }

    MicrophoneRecorder _recorder = new MicrophoneRecorder();

    private void recordButton_Click(object sender, RoutedEventArgs e)
    {
      _recorder.Start();
    }

    private void stopRecordingButton_Click(object sender, RoutedEventArgs e)
    {
      _recorder.Stop();
    }

    SoundEffectPlayer _recordingPlayer = null;

    private void playRecordingButton_Click(object sender, RoutedEventArgs e)
    {
      _recordingPlayer = new SoundEffectPlayer(_recorder.GetSoundEffect());
      _recordingPlayer.Play();
    }

  }
}
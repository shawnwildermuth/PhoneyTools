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
using Microsoft.Xna.Framework;
using System.Threading;
using System.Windows.Threading;
using System.IO;


namespace AgiliTrain.PhoneyTools.Media
{
  /// <summary>
  /// A Wrapper around the default Microphone to simplify Microphone recording
  /// </summary>
  public class MicrophoneRecorder
  {
    GameTimer _xnaTimer = new GameTimer();
    MemoryStream _recording = null;
    bool _isRunning = false;

    /// <summary>
    /// Initializes a new instance of the <see cref="MicrophoneRecorder"/> class.
    /// </summary>
    public MicrophoneRecorder()
    {
    }

    public void Start()
    {
      if (_isRunning) throw new InvalidOperationException("Cannot start the Microphone if its already recording.");

      _isRunning = true;

      // Create a new place for the recording
      _recording = new MemoryStream();

      // Setup event for Microphone
      Microphone.Default.BufferReady += TheMicrophone_BufferReady;

      // Start the Time for the XNA Update
      _xnaTimer.Start();

      // Start the Microphone
      Microphone.Default.Start();
    }

    public void Stop()
    {
      if (!_isRunning) throw new InvalidOperationException("Cannot stop the Microphone if its not recording.");

      _isRunning = false;

      // Stop Recording
      Microphone.Default.Stop();

      // Unwire the event
      Microphone.Default.BufferReady -= TheMicrophone_BufferReady;

      // Stop the 'game loop'
      _xnaTimer.Stop();
    }

    /// <summary>
    /// Gets the raw buffer.
    /// </summary>
    /// <returns></returns>
    public byte[] GetRawBuffer()
    {
      if (!_isRunning &&
          Microphone.Default.State == MicrophoneState.Stopped &&
          _recording != null)
      {
        // Load the SoundEffect
        return _recording.ToArray();
      }

        return null;
    }

    /// <summary>
    /// Gets the sound effect.
    /// </summary>
    /// <returns></returns>
    public SoundEffect GetSoundEffect()
    {
      if (!_isRunning &&
          Microphone.Default.State == MicrophoneState.Stopped &&
          _recording != null)
      {
        // Load the SoundEffect
        return new SoundEffect(_recording.ToArray(),
                               Microphone.Default.SampleRate,
                               AudioChannels.Mono);

      }

      return null;
    }

    void TheMicrophone_BufferReady(object sender, EventArgs e)
    {
      // Grab the Mic
      var mic = Microphone.Default;

      // Determine the #/bites needed for our sample
      var bufferSize = mic.GetSampleSizeInBytes(mic.BufferDuration);

      // Create the buffer
      byte[] buffer = new byte[bufferSize];

      // Get the Data (and return the number of bytes recorded)
      var size = Microphone.Default.GetData(buffer);

      // Write the data to our MemoryStream
      _recording.Write(buffer, 0, size);

    }

  }
}

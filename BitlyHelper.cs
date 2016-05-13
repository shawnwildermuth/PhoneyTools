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

namespace AgiliTrain.PhoneyTools
{
  /// <summary>
  /// Utility Class to help shorten URL's via Bitly.  It requires an API key and a userid from Bitly.
  /// </summary>
  public static class BitlyHelper
  {
    static string _apikey = null;
    static string _userid = null;
    static bool _credentialsSet = false;

    /// <summary>
    /// Sets the credentials.
    /// </summary>
    /// <param name="apikey">The apikey.</param>
    /// <param name="userid">The userid.</param>
    public static void SetCredentials(string apikey, string userid)
    {
      if (apikey == null)
      {
        throw new ArgumentException("apikey must not be null", "apikey");
      }

      if (userid == null)
      {
        throw new ArgumentException("userid must not be null", "userid");
      }
      
      _apikey = apikey;
      _userid = userid;
      _credentialsSet = true;
    }

    /// <summary>
    /// Shortens the specified URI.
    /// </summary>
    /// <param name="uri">The URI.</param>
    /// <param name="callback">The callback.</param>
    public static void Shorten(string uri, Action<string, Exception> callback)
    {
      if (!_credentialsSet)
      {
        callback(null, new InvalidOperationException("You must call BitlyHelper.SetCredentials before you shorten any URLs."));
      }

      var request = string.Format("http://api.bit.ly/v3/shorten?login={0}&apiKey={1}&longUrl={2}&format=txt",
        _userid, _apikey, HttpUtility.UrlEncode(uri));

      var client = new WebClient();
      client.DownloadStringCompleted += (s, e) =>
        {
          if (e.Cancelled)
          {
            callback(null, new Exception("Shortening Cancelled."));
          }
          else if (e.Error != null)
          {
            callback(null, new Exception("Shortening threw an exception.", e.Error));
          }
          else
          {
            callback(e.Result, null);
          }
        };
      client.DownloadStringAsync(new Uri(request));
    }
  }
}

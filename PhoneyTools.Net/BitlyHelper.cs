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

namespace AgiliTrain.PhoneyTools.Net
{
  /// <summary>
  /// Utility Class to help shorten URL's via Bitly.  It requires an API key and a userid from Bitly.
  /// </summary>
  public class BitlyHelper
  {
    string _apikey = null;
    string _userid = null;

    /// <summary>
    /// Shortens the URL.
    /// </summary>
    /// <param name="apikey">The API key.</param>
    /// <param name="userid">The userid.</param>
    /// <param name="uri">The URI.</param>
    /// <param name="callback">The callback.</param>
    public static void ShortenUrl(string apikey, string userid, string uri, Action<string, Exception> callback)
    {
      if (string.IsNullOrEmpty(apikey))
      {
        callback(null, new ArgumentException("API Key cannot be null", "apikey"));
        return;
      }

      if (string.IsNullOrEmpty(userid))
      {
        callback(null, new ArgumentException("UserID cannot be null", "userid"));
        return;
      }

      // Create a temporary helper
      var helper = new BitlyHelper(apikey, userid);

      // Shorten it
      helper.Shorten(uri, callback);
    }

    /// <summary>
    /// Sets the credentials.
    /// </summary>
    /// <param name="apikey">The apikey.</param>
    /// <param name="userid">The userid.</param>
    public BitlyHelper(string apikey, string userid)
    {
      if (string.IsNullOrEmpty(apikey))
      {
        throw new ArgumentException("API Key cannot be null", "apikey");
      }

      if (string.IsNullOrEmpty(userid))
      {
        throw new ArgumentException("UserID cannot be null", "userid");
      }

      _apikey = apikey;
      _userid = userid;
    }

    /// <summary>
    /// Shortens the specified URI.
    /// </summary>
    /// <param name="uri">The URI.</param>
    /// <param name="callback">The callback.</param>
    public void Shorten(string uri, Action<string, Exception> callback)
    {
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

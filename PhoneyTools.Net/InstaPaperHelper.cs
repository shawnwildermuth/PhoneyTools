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
  /// A helper class to allow users to save URI's to InstaPaper to read later.
  /// </summary>
  public class InstaPaperHelper
  {
    string _ipUserName;
    string _ipPassword;

    /// <summary>
    /// Initializes a new instance of the <see cref="InstaPaperHelper"/> class.
    /// </summary>
    /// <param name="ipUserName">The user's InstaPaper username.</param>
    /// <param name="ipPassword">The user's InstaPaper password.</param>
    public InstaPaperHelper(string ipUserName, string ipPassword)
    {
      _ipUserName = ipUserName;
      _ipPassword = ipPassword;
    }

    /// <summary>
    /// Adds a URI to InstaPaper.com for the current user. 
    /// </summary>
    /// <param name="uriToSave">The URI to save.</param>
    /// <param name="title">The title to be shown on InstaPaper.com.</param>
    /// <param name="callback">The callback. The Boolean value will be true if the operation was successful.</param>
    public void AddToInstaPaperAsync(Uri uriToSave, string title, Action<bool> callback)
    {
      if (!uriToSave.IsAbsoluteUri) throw new InvalidOperationException("Uri must be an absolute to save to InstaPaper");

      string ipLink = string.Format("https://www.instapaper.com/api/add?username={0}&password={1}&url={2}&title={3}",
        HttpUtility.UrlEncode(_ipUserName),
        HttpUtility.UrlEncode(_ipPassword),
        HttpUtility.UrlEncode(uriToSave.ToString()),
        HttpUtility.UrlEncode(title));

      var client = new WebClient();
      client.DownloadStringCompleted += (s, a) =>
      {
        if (!a.Cancelled && a.Error == null)
        {
          callback(true);
        }
        else
        {
          callback(false);
        }
      };
      client.DownloadStringAsync(new Uri(ipLink));

    }

    /// <summary>
    /// Adds a URI to InstaPaper.com for user identified in the username/password combination. 
    /// </summary>
    /// <param name="ipUserName">The user's InstaPaper username.</param>
    /// <param name="ipPassword">The user's InstaPaper password.</param>
    /// <param name="uriToSave">The URI to save.</param>
    /// <param name="title">The title to be shown on InstaPaper.com.</param>
    /// <param name="callback">The callback. The Boolean value will be true if the operation was successful.</param>
    public static void AddToInstaPaperAsync(string ipUserName, string ipPassword, Uri uriToSave, string title, Action<bool> callback)
    {
      new InstaPaperHelper(ipUserName, ipPassword).AddToInstaPaperAsync(uriToSave, title, callback);
    }

  }
}

using System;
using System.Diagnostics;
using System.IO;
using System.IO.IsolatedStorage;

namespace AgiliTrain.PhoneyTools
{
  /// <summary>
  /// A class to enable logging to isolated storage.
  /// </summary>
  public class PhoneLogger
  {
    /// <summary>
    /// The level of logging.
    /// </summary>
    public enum LogLevel
    {
      Info,
      Debug,
      Error,
      Critical
    }

    static PhoneLogger _logger = null;
    const string LOGNAME = "AppLog.txt";

    /// <summary>
    /// Gets the logger.
    /// </summary>
    static PhoneLogger TheLogger
    {
      get
      {
        if (_logger == null)
        {
          _logger = new PhoneLogger();
        }
        return _logger;
      }
    }

    /// <summary>
    /// Prevents a default instance of the <see cref="PhoneLogger"/> class from being created.
    /// </summary>
    private PhoneLogger()
    {
    }

    /// <summary>
    /// Logs the specified level.
    /// </summary>
    /// <param name="level">The level.</param>
    /// <param name="msg">The MSG.</param>
    /// <param name="args">The args.</param>
    public void Log(LogLevel level, string msg, params object[] args)
    {
      bool canLog = false;
#if DEBUG
      canLog = true;
#else
      canLog = (int)level >= (int)LogLevel.Error;
#endif
      if (canLog)
      {
        string logMsg = string.Format("{0}: {2} {1}", 
          level.ToString(), 
          string.Format(msg, args), 
          DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

        WriteLog(logMsg);

      }

    }

    /// <summary>
    /// Writes the log.
    /// </summary>
    /// <param name="logMsg">The log MSG.</param>
    private void WriteLog(string logMsg)
    {
      using (var store = IsolatedStorageFile.GetUserStoreForApplication())
      {
        Stream stream = null;
        if (!store.FileExists(LOGNAME))
        {
          stream = store.CreateFile(LOGNAME);
        }
        else
        {
          stream = store.OpenFile(LOGNAME, FileMode.Open, FileAccess.Write);
        }

        var writer = new StreamWriter(stream);
        writer.WriteLine(logMsg);
        writer.Flush();
        writer.Close();
      }

      Debug.WriteLine(logMsg);

    }

    /// <summary>
    /// Gets the log contents.
    /// </summary>
    /// <returns></returns>
    string GetLogContents()
    {
      using (var store = IsolatedStorageFile.GetUserStoreForApplication())
      {
        Stream stream = null;
        if (!store.FileExists(LOGNAME))
        {
          return "";
        }
        else
        {
          stream = store.OpenFile(LOGNAME, FileMode.Open, FileAccess.Read);
        }

        return new StreamReader(stream).ReadToEnd();
      }
    }

    /// <summary>
    /// Gets the log contents.
    /// </summary>
    public static string LogContents
    {
      get
      {
        return TheLogger.GetLogContents();
      }
    }

    /// <summary>
    /// Logs the debug.
    /// </summary>
    /// <param name="msg">The MSG.</param>
    /// <param name="args">The args.</param>
    public static void LogDebug(string msg, params object[] args)
    {
      TheLogger.Log(LogLevel.Debug, msg, args);
    }

    /// <summary>
    /// Logs the info.
    /// </summary>
    /// <param name="msg">The MSG.</param>
    /// <param name="args">The args.</param>
    public static void LogInfo(string msg, params object[] args)
    {
      TheLogger.Log(LogLevel.Info, msg, args);
    }

    /// <summary>
    /// Logs the error.
    /// </summary>
    /// <param name="msg">The MSG.</param>
    /// <param name="args">The args.</param>
    public static void LogError(string msg, params object[] args)
    {
      TheLogger.Log(LogLevel.Error, msg, args);
    }

    /// <summary>
    /// Logs the critical.
    /// </summary>
    /// <param name="msg">The MSG.</param>
    /// <param name="args">The args.</param>
    public static void LogCritical(string msg, params object[] args)
    {
      TheLogger.Log(LogLevel.Critical, msg, args);
    }

  }
}

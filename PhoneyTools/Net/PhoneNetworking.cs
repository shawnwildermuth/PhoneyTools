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
using Microsoft.Phone.Net.NetworkInformation;
using System.Threading;

namespace AgiliTrain.PhoneyTools.Net
{
  /// <summary>
  /// Allows for detecting the type of
  /// networking the phone is currently using.
  /// </summary>
  public static class PhoneNetworking
  {
    /// <summary>
    /// Networking Types
    /// </summary>
    public enum NetworkType
    {
      /// <summary>
      /// Unknown Network Type
      /// </summary>
      Unknown,
      /// <summary>
      /// No Network
      /// </summary>
      None,
      /// <summary>
      /// WiFi Connection
      /// </summary>
      WiFi,
      /// <summary>
      /// 3G or CDMA Connection
      /// </summary>
      Cellular,
      /// <summary>
      /// Ethernet via USB Connection
      /// </summary>
      Desktop
    };

    /// <summary>
    /// Gets the type of the network.
    /// </summary>
    /// <returns>A valid NetworkType enumeration value.</returns>
    public static void GetNetworkTypeAsync(Action<NetworkType> callback, bool callbackOnUiThread = true)
    {

      ThreadPool.QueueUserWorkItem(wc =>
        {
          var payload = (GetNetworkTypePayload)wc;

          switch (NetworkInterface.NetworkInterfaceType)
          {
            case NetworkInterfaceType.None:
              CallbackNetworkType(payload, NetworkType.None);
              break;
            case NetworkInterfaceType.MobileBroadbandCdma:
            case NetworkInterfaceType.MobileBroadbandGsm:
              CallbackNetworkType(payload, NetworkType.Cellular);
              break;
            case NetworkInterfaceType.Wireless80211:
              CallbackNetworkType(payload, NetworkType.WiFi);
              break;
            case NetworkInterfaceType.Ethernet:
              CallbackNetworkType(payload, NetworkType.Desktop);
              break;
            default:
              CallbackNetworkType(payload, NetworkType.Unknown);
              break;
          }
        }, new GetNetworkTypePayload() { Callback = callback, OnUiThread = callbackOnUiThread });


    }

    /// <summary>
    /// Callbacks the type of the network.
    /// </summary>
    /// <param name="payload">The payload.</param>
    /// <param name="result">The result.</param>
    static void CallbackNetworkType(GetNetworkTypePayload payload, NetworkType result)
    {
      if (payload.OnUiThread)
      {
        Deployment.Current.Dispatcher.BeginInvoke(() => payload.Callback(result));
      }
      else
      {
        payload.Callback(result);
      }
    }

    private struct GetNetworkTypePayload
    {
      public Action<NetworkType> Callback { get; set; }
      public bool OnUiThread { get; set; }
    }

  }
}

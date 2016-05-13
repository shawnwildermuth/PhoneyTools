using System;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
#if MANGO
using sysNet = System.Net.NetworkInformation;
#endif
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
#if !MANGO
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
#else
    /// <summary>
    /// Networking Types
    /// </summary>
    public enum NetworkType
    {
      /// <summary>
      /// Unknown Network Type
      /// </summary>
      Unknown = 0,
      /// <summary>
      /// No Network
      /// </summary>
      None = 1,
      /// <summary>
      /// WiFi Connection
      /// </summary>
      WiFi = 2,
      /// <summary>
      /// 2.5G (Edge, GPRS) Cellular Connection
      /// </summary>
      Cellular25G = 4,
      /// <summary>
      /// 3G or CDMA Cellular Connection
      /// </summary>
      Cellular3G = 8,
      /// <summary>
      /// 3.5G (HSPA) Cellular Connection
      /// </summary>
      Cellular35G = 16,
      /// <summary>
      /// 3G Connection (with Compatiblity to 1.0 of Phoney Tools, same as 3G)
      /// </summary>
      Cellular = 8,
      /// <summary>
      /// Ethernet via USB Connection
      /// </summary>
      Desktop = 32
    };
#endif

    /// <summary>
    /// Gets the type of the network.
    /// </summary>
    /// <returns>A valid NetworkType enumeration value.</returns>
    public static void GetNetworkTypeAsync(Action<NetworkType> callback, bool callbackOnUiThread = true)
    {

      ThreadPool.QueueUserWorkItem(wc =>
        {
          var payload = (GetNetworkTypePayload)wc;
#if !MANGO
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
#else
          var netList = new NetworkInterfaceList();
          var net = netList.FirstOrDefault();

          if (net == null)
          {
            CallbackNetworkType(payload, NetworkType.Unknown);
            return;
          }

          switch (net.InterfaceSubtype)
          {
            case NetworkInterfaceSubType.Cellular_1XRTT:
            case NetworkInterfaceSubType.Cellular_EDGE:
            case NetworkInterfaceSubType.Cellular_GPRS:
              CallbackNetworkType(payload, NetworkType.Cellular25G);
              break;
            case NetworkInterfaceSubType.Cellular_3G:
            case NetworkInterfaceSubType.Cellular_EVDO:
            case NetworkInterfaceSubType.Cellular_EVDV:
              CallbackNetworkType(payload, NetworkType.Cellular3G);
              break;
            case NetworkInterfaceSubType.Cellular_HSPA:
              CallbackNetworkType(payload, NetworkType.Cellular35G);
              break;
            case NetworkInterfaceSubType.WiFi:
              CallbackNetworkType(payload, NetworkType.WiFi);
              break;
            case NetworkInterfaceSubType.Desktop_PassThru:
              CallbackNetworkType(payload, NetworkType.Desktop);
              break;
          }
#endif
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

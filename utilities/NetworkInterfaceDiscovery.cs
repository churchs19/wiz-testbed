using System.Net;
using System.Net.NetworkInformation;

namespace WizTestbed.Utilities
{
    public static class NetworkInterfaceDiscovery
    {
        public static Model.NetworkInfo GetNetworkInfo()
        {
            // first find network interface
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if ((nic.OperationalStatus == OperationalStatus.Up) &&
                    ((nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet) || (nic.NetworkInterfaceType == NetworkInterfaceType.Wireless80211))
                   )
                {
                    // then find a valid IPv4 address
                    foreach (UnicastIPAddressInformation ip in nic.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            return new Model.NetworkInfo(ip.Address, nic);
                        }
                    }
                }
            }
            return new Model.NetworkInfo();
        }
    }
}
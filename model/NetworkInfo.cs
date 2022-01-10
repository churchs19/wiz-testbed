using System.Net;
using System.Net.NetworkInformation;

namespace WizTestbed.Model
{
    public class NetworkInfo
    {
        public NetworkInfo()
        {
            HostIP = null;
            HostNIC = null;
        }

        public NetworkInfo(IPAddress? hostIP, NetworkInterface? hostNIC)
        {
            HostIP = hostIP;
            HostNIC = hostNIC;
        }

        public IPAddress? HostIP { get; }
        public NetworkInterface? HostNIC { get; }
    }
}
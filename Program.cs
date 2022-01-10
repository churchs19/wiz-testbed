using WizTestbed.Model;
using WizTestbed.Utilities;

// See https://aka.ms/new-console-template for more information
var hostInfo = NetworkInterfaceDiscovery.GetNetworkInfo();
if(hostInfo.HostIP != null && hostInfo.HostNIC != null)
{
    Console.WriteLine($"Host IP: {hostInfo.HostIP}");
    Console.WriteLine($"Host NIC: {hostInfo.HostNIC.Name}");
}
else
{
    Console.WriteLine("No network interface found");
}

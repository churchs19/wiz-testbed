using WizTestbed.Utilities;
using OpenWiz;
using WizTestbed.Model;
using System.Reflection;
using Microsoft.Extensions.Configuration;

var configuration = new ConfigurationBuilder()
    .AddUserSecrets(Assembly.GetExecutingAssembly())
    .Build();

// See https://aka.ms/new-console-template for more information
var hostInfo = NetworkInterfaceDiscovery.GetNetworkInfo();
if (hostInfo.HostIP != null && hostInfo.HostNIC != null)
{
    Console.WriteLine($"Host IP: {hostInfo.HostIP}");
    Console.WriteLine($"Host NIC: {hostInfo.HostNIC.Name}");

    int wizHome = int.Parse(configuration["WizHome"]);

    var discoveryService = new WizDiscoveryService(wizHome, hostInfo.HostIP.ToString(), hostInfo.MacAddress);

    discoveryService.Start((handle) =>
    {
        Console.WriteLine($"Wiz discovered at {handle.Ip.ToString()}");
    });
    await Task.Delay(15000);
    discoveryService.Stop();
    Console.WriteLine("Discovery completed.");
}
else
{
    Console.WriteLine("No network interface found");
}

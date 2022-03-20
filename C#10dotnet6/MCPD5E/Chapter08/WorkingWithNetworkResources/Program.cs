using System.Net;
using static System.Console;

namespace Program
{
    class Program
    {
        public static void Main(string[] args)
        {

      
Write("Enter a valid web address: ");
string? url = ReadLine();

if (string.IsNullOrWhiteSpace(url))
{
    url = "http://stackoverflow.com/search?q=securestring";
}

Uri uri = new(url);

IPHostEntry entry = Dns.GetHostEntry(uri.Host);
WriteLine($"{entry.HostName} has the following IP addresses:");
foreach (IPAddress address in entry.AddressList)
{
    WriteLine($"    {address} ({address.AddressFamily})");
}

WriteLine($"URL: {url}");
WriteLine($"Schema: {uri.Scheme}");
WriteLine($"Port: {uri.Port}");
WriteLine($"Host: {uri.Host}");
WriteLine($"Path: {uri.AbsolutePath}");
WriteLine($"Query: {uri.Query}");
        }
    }
}
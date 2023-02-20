using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DNSResolver
{
    internal class Program
    {
        static void Main(string[] args)
        {
        Main:
            Console.Clear();
            Console.Write("Enter a domain name: ");
            string domain = Console.ReadLine();

            if (Uri.CheckHostName(domain) == UriHostNameType.Unknown)
            {
                Console.WriteLine($"Invalid domain name: {domain}");
                return;
            }

            try
            {
                IPHostEntry hostEntry = Dns.GetHostEntry(domain);

                Console.WriteLine($"DNS information for {domain}:");
                foreach (IPAddress ipAddress in hostEntry.AddressList)
                {
                    Console.WriteLine(ipAddress);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error getting DNS information for {domain}: {e.Message}");
            }
            Console.ReadKey();
            goto Main;
        }
    }
}

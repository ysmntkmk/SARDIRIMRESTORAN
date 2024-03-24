using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NTierSardırımRes.Common
{
    public static class IPAddressFinder
    {
        public static string GetHostName()
        {
            string ip = " ";

            var hostName = Dns.GetHostName();
            var address = Dns.GetHostAddresses(hostName);


            foreach (var item in address)
            {
                if (item.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    ip = item.ToString();
                }
            }



            return ip;
        }
    }
}

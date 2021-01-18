using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Net;
using System.Net.Sockets;
using FileTransferSystem.Logic.Service.Interface.Network;

namespace FileTransferSystem.Logic.Service.Implementation.Network
{
    public class IpConfiguringService : IIpConfiguringService
    {
        /*
            Parameter is either NetworkInterfaceType.Ethernet or NetworkInterfaceType.Wireless80211
        */
        public IPAddress GetLocalIPAddress(NetworkInterfaceType interfaceType)
        {
            IPAddress output = null;

            foreach (NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (item.NetworkInterfaceType == interfaceType && item.OperationalStatus == OperationalStatus.Up)
                {
                    var adapterProperties = item.GetIPProperties();
                    if (adapterProperties.GatewayAddresses.FirstOrDefault() != null)
                    {
                        foreach (var ip in adapterProperties.UnicastAddresses)
                        {
                            if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                            {
                                output = ip.Address;
                                break;
                            }
                        }
                    }
                }
                if (output != null)
                {
                    break;
                }
            }

            return output;
        }

        public bool GetConnectionStatus()
        {
            return NetworkInterface.GetIsNetworkAvailable();
        }
    }
}

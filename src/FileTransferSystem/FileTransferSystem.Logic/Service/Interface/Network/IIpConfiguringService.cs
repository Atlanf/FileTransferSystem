using System;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;

namespace FileTransferSystem.Logic.Service.Interface.Network
{
    public interface IIpConfiguringService
    {
        IPAddress GetLocalIPAddress(NetworkInterfaceType interfaceType);
        bool GetConnectionStatus();
    }
}

using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace FileTransferSystem.Logic.Service.Interface.Network
{
    interface IIpConfiguringService
    {
        string GetLocalIPAddress(NetworkInterfaceType interfaceType);
        bool GetConnectionStatus();
    }
}

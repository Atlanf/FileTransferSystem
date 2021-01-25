using FileTransferSystem.Logic.Service.Interface.Network;
using FileTransferSystem.Logic.Service.Interface.Network.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileTransferSystem.Logic.Service.Implementation.Network.Client
{
    public class ClientSocketService : IClientSocketService
    {
        private readonly IIpConfiguringService _ipConfiguringService;

        public ClientSocketService(IIpConfiguringService ipConfiguringService)
        {
            _ipConfiguringService = ipConfiguringService;
        }
    }
}

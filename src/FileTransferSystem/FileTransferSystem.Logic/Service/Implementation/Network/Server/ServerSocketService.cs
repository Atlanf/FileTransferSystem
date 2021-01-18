using FileTransferSystem.Logic.Service.Interface.Network;
using FileTransferSystem.Logic.Service.Interface.Network.Server;
using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Net;
using System.Net.NetworkInformation;

namespace FileTransferSystem.Logic.Service.Implementation.Network.Server
{
    public class ServerSocketService : IServerSocketService
    {
        public IPAddress IpAddress { get; private set; }
        public IPEndPoint LocalEndPoint { get; private set; }
        public string ErrorMessage { get; private set; } = "";
        public string Result { get; private set; } = "";
        public bool IsCompleted { get; private set; } = false;
        

        private readonly IIpConfiguringService _ipConfiguringService;
        private int _portNumber { get; set; } = 12011;

        public ServerSocketService(IIpConfiguringService ipConfiguringService)
        {
            _ipConfiguringService = ipConfiguringService;
        }

        public void SendSingleFile(Socket socket, string fileName)
        {
            IsCompleted = false;

            var result = socket.BeginSendFile(fileName, new AsyncCallback(SendSingleFileCallback), socket); 
            
            if (result.IsCompleted)
            {
                IsCompleted = true;
                Result = "\"" + fileName + "\" was successfully delivered.";
            }
        }

        private void SendSingleFileCallback(IAsyncResult ar)
        {
            try
            {
                Socket handler = (Socket)ar.AsyncState;

                handler.EndSendFile(ar);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message.ToString();
            }
        }

        private void SetNetworkInfo(NetworkInterfaceType interfaceType)
        {
            IpAddress = _ipConfiguringService.GetLocalIPAddress(interfaceType);
            LocalEndPoint = new IPEndPoint(IpAddress, _portNumber);
        }
    }
}

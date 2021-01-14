using FileTransferSystem.Logic.Service.Implementation.Network;
using FileTransferSystem.Logic.Service.Implementation.Network.Client;
using FileTransferSystem.Logic.Service.Implementation.Network.Server;
using FileTransferSystem.Logic.Service.Interface.Network;
using FileTransferSystem.Logic.Service.Interface.Network.Client;
using FileTransferSystem.Logic.Service.Interface.Network.Server;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileTransferSystem.Logic
{
    public static class LogicExtensions
    {
        public static IServiceCollection AddLogicServices(this IServiceCollection services)
        {
            services.AddTransient<IIpConfiguringService, IpConfiguringService>();
            services.AddTransient<IClientSocketService, ClientSocketService>();
            services.AddTransient<IServerSocketService, ServerSocketService>();

            return services;
        }
    }
}

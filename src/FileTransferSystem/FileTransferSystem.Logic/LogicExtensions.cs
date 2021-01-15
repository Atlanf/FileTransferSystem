using AutoMapper;
using FileTransferSystem.Logic.Helper;
using FileTransferSystem.Logic.Profiles;
using FileTransferSystem.Logic.Service.Implementation.Files;
using FileTransferSystem.Logic.Service.Implementation.Network;
using FileTransferSystem.Logic.Service.Implementation.Network.Client;
using FileTransferSystem.Logic.Service.Implementation.Network.Server;
using FileTransferSystem.Logic.Service.Interface.Files;
using FileTransferSystem.Logic.Service.Interface.Network;
using FileTransferSystem.Logic.Service.Interface.Network.Client;
using FileTransferSystem.Logic.Service.Interface.Network.Server;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FileTransferSystem.Logic
{
    public static class LogicExtensions
    {
        public static IServiceCollection AddLogicServices(this IServiceCollection services)
        {
            services.AddMapper();

            services.AddTransient<IIpConfiguringService, IpConfiguringService>();
            services.AddTransient<IClientSocketService, ClientSocketService>();
            services.AddTransient<IServerSocketService, ServerSocketService>();
            services.AddTransient<IFileProcessingService, FileProcessingService>();
            services.AddTransient<IDirectoryProcessingService, DirectoryProcessingService>();

            services.AddTransient<ConfigurationFileManager>();

            return services;
        }

        private static void AddMapper(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapperProfile());
            });
            services.AddSingleton(mappingConfig.CreateMapper());
        }
    }
}

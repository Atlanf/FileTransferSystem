using AutoMapper;
using FileTransferSystem.Logic.Helper;
using FileTransferSystem.Logic.Service.Interface.Files;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileTransferSystem.Logic.Service.Implementation.Files
{
    public class DirectoryProcessingService : IDirectoryProcessingService
    {
        private readonly IMapper _mapper;
        private readonly ConfigurationFileManager _configurationFileManager;

        public DirectoryProcessingService(IMapper mapper, ConfigurationFileManager configManager)
        {
            _mapper = mapper;
            _configurationFileManager = configManager;
        }

        public string ChangeWorkingDirectory(string newDirectory)
        {
            var result = _configurationFileManager.SetWorkingDirectoryPath(newDirectory);
            if (result != null)
            {
                return result;
            }
            else
            {
                return "Error occured on changing working directory.";
            }
        }

        public List<string> GetNotSyncedFiles()
        {
            return new List<string>();
        }
    }
}

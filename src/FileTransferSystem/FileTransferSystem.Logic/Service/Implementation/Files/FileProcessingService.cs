using FileTransferSystem.Logic.Service.Interface.Files;
using System;
using System.Collections.Generic;
using System.Text;
using FileTransferSystem.Logic.Helper;
using AutoMapper;
using System.Threading.Tasks;

namespace FileTransferSystem.Logic.Service.Implementation.Files
{
    public class FileProcessingService : IFileProcessingService
    {
        private readonly string _workingDirectoryPath = "";
        private readonly IMapper _mapper;
        private readonly ConfigurationFileManager _configFileManager;

        public FileProcessingService(IMapper mapper, ConfigurationFileManager configFileManager)
        {
            _mapper = mapper;
            _configFileManager = configFileManager;
        }

        public async Task<byte[,]> ProcessSelectedFile(string filePath, int portionSize = 1024)
        {
            var fileSplitter = new FileSplitter(portionSize);

            /* check if everythin OK */
            
            return await fileSplitter.SplitFileAsync(filePath);
        }
    }
}

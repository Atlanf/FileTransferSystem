using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FileTransferSystem.Logic.Service.Interface.Files
{
    interface IFileProcessingService
    {
        Task<byte[,]> ProcessSelectedFile(string filePath, int portionSize);
    }
}

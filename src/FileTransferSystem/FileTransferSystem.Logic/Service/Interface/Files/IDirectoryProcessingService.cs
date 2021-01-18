using System;
using System.Collections.Generic;
using System.Text;

namespace FileTransferSystem.Logic.Service.Interface.Files
{
    public interface IDirectoryProcessingService
    {
        string ChangeWorkingDirectory(string newDirectory);
    }
}

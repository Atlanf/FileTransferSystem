using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace FileTransferSystem.Logic.Helper
{
    public class ConfigurationFileManager
    {
        private readonly string _configFilePath = "";
        private readonly IConfiguration _config;

        public ConfigurationFileManager(IConfiguration config)
        {
            _config = config;
        }

        public string GetWorkingDirectoryPath()
        {
            return "";
        }

        public bool SetWorkingDirectoryPath()
        {
            return false;
        }
    }
}

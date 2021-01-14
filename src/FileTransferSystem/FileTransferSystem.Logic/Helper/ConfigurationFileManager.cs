using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace FileTransferSystem.Logic.Helper
{
    public class ConfigurationFileManager
    {
        private readonly string _configFilePath = "";

        public ConfigurationFileManager(string configFilePath)
        {
            _configFilePath = configFilePath;
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

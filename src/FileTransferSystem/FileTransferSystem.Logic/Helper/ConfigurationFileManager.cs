using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace FileTransferSystem.Logic.Helper
{
    public class ConfigurationFileManager
    {
        private string WorkingDirectoryKey { get; } = "SyncDirectory";

        public string GetWorkingDirectoryPath()
        {
            string result;

            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                result = appSettings[WorkingDirectoryKey] ?? "Not Found";
            }
            catch (ConfigurationErrorsException)
            {
                result = null;
            }

            return result;
        }

        public string SetWorkingDirectoryPath(string path)
        {
            try
            {
                var configManager = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configManager.AppSettings.Settings;

                if (settings[WorkingDirectoryKey] != null)
                {
                    settings[WorkingDirectoryKey].Value = path;
                }
                else
                {
                    settings.Add(WorkingDirectoryKey, path);
                }

                configManager.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configManager.AppSettings.SectionInformation.Name);

                return GetWorkingDirectoryPath();
            }
            catch (ConfigurationErrorsException)
            {
                return null;
            }
        }
    }
}

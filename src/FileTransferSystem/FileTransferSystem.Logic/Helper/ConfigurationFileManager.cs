using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using FileTransferSystem.Logic.Enum;

namespace FileTransferSystem.Logic.Helper
{
    public class ConfigurationFileManager
    {
        public string GetConfigurationValue(ConfigManagerKeys key)
        {
            var configKey = key.ToString();
            string result;
            
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                result = appSettings[configKey] ?? "Not Found";
            }
            catch (ConfigurationErrorsException)
            {
                result = null;
            }

            return result;
        }

        public string SetConfigurationValue(ConfigManagerKeys key, string value)
        {
            var configKey = key.ToString();
            
            try
            {
                var configManager = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configManager.AppSettings.Settings;

                if (settings[configKey] != null)
                {
                    settings[configKey].Value = value;
                }
                else
                {
                    settings.Add(configKey, value);
                }

                configManager.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configManager.AppSettings.SectionInformation.Name);

                return GetConfigurationValue(key);
            }
            catch (ConfigurationErrorsException)
            {
                return null;
            }
        }
    }
}

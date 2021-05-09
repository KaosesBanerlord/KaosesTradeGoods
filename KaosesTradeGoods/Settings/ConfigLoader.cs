using KaosesTradeGoods.Utils;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using TaleWorlds.Engine;

namespace KaosesTradeGoods.Settings
{
    class ConfigLoader
    {
        public static string logPreppend { get; set; } = "KaosesTradeGoods: ";

        public static void LoadConfig()
        {
            BuildVariables();
            LoadModConfigFile();
            ChechMCMProvider();
            if (Statics._settings is null)
            {
                IM.MessageError("Failed to load any config provider");
            }
            IM.logToFile = Statics.LogToFile;
            IM.Debug = Statics.Debug;
            IM.PrePrend = Statics.PrePrend;
            Logging.PrePrend = Statics.PrePrend;
        }

        private static void LoadModConfigFile()
        {
            Settings.Instance = new Settings();
            if (Settings.Instance is not null)
            {
                IM.MessageDebug(logPreppend + "Settings.Instance is not null");
                if (File.Exists(Statics.ConfigFilePath))
                {
                    IM.MessageDebug(logPreppend + "Config file exists " + Statics.ConfigFilePath.ToString());
                    Settings config = JsonConvert.DeserializeObject<Settings>(File.ReadAllText(Statics.ConfigFilePath));
                    Settings.Instance = config;
                }

                if (Settings.Instance.LoadMCMConfigFile && Statics.MCMConfigFileExists)
                {
                    Settings config = JsonConvert.DeserializeObject<Settings>(File.ReadAllText(Statics.MCMConfigFile));
                    Settings.Instance = config;
                }
            }
            Statics._settings = Settings.Instance;

        }
        private static void ChechMCMProvider()
        {
            if (Statics.MCMModuleLoaded)
            {
                if (MCMSettings.Instance is not null)
                {
                    Statics._settings = MCMSettings.Instance;
                    IM.MessageDebug(logPreppend + "using MCM");
                    IM.MessageDebug(logPreppend + "Not Using config settings");
                }
                else
                {
                    IM.MessageError(logPreppend + "Problem loading MCM config");
                }
            }
            else
            {
                IM.MessageDebug(logPreppend + "MCM Module is not loaded");
            }
        }

        private static void BuildVariables()
        {
            IsMCMLoaded();
            CheckMcmConfig();
            CheckModConfig();
        }

        private static void IsMCMLoaded(bool overrideSettings = true)
        {
            var modnames = Utilities.GetModulesNames().ToList();
            //if (modnames.Contains("ModLib") && !overrideSettings)
            if (modnames.Contains("Bannerlord.MBOptionScreen"))// && !overrideSettings
            {
                Statics.MCMModuleLoaded = true;
                IM.MessageDebug(logPreppend + "MCM Module is loaded");
            }
        }

        private static void CheckMcmConfig()
        {
            string RootFolder = System.IO.Path.Combine(Utilities.GetConfigsPath(), "ModSettings/Global/" + Statics.ModuleFolder);
            if (System.IO.Directory.Exists(RootFolder))
            {
                Statics.MCMConfigFolder = RootFolder;
                string fileLoc = System.IO.Path.Combine(RootFolder, Statics.ModuleFolder + ".json");
                if (System.IO.File.Exists(fileLoc))
                {
                    Statics.MCMConfigFileExists = true;
                    Statics.MCMConfigFile = fileLoc;
                    IM.MessageDebug(logPreppend + "MCM Module Config file found");
                }
            }
        }
        private static void CheckModConfig()
        {
            if (File.Exists(Statics.ConfigFilePath))
            {
                Statics.ModConfigFileExists = true;
                IM.MessageDebug(logPreppend + "Config File FOUND");
            }
        }

    }
}

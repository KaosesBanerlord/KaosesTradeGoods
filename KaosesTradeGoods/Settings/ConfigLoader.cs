using KaosesCommon.Utils;

namespace KaosesTradeGoods.Settings
{
    class ConfigLoader
    {
        public static string logPreppend { get; set; } = "KaosesTradeGoods: ";

        public static void LoadConfig()
        {
            Statics.MCMModuleLoaded = KaosesCommon.Kaoses.IsMCMLoaded();
            ChechMCMProvider();
            if (Statics._settings is null)
            {
                IM.MessageError("Failed to load any config provider");
            }
            KaosesCommon.Utils.IM.logToFile = Statics.LogToFile;
            KaosesCommon.Utils.IM.Debug = Statics.Debug;
            KaosesCommon.Utils.IM.PrePrend = Statics.PrePrend;
            KaosesCommon.Utils.IM.GameVersion = Statics.GameVersion;
            KaosesCommon.Utils.IM.ModVersion = Statics.ModVersion;
            KaosesCommon.Utils.Logger.PrePrend = Statics.PrePrend;
            KaosesCommon.Utils.Logger.LogFilePath = Statics.logPath;
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
    }
}

using KaosesCommon.Utils;
using KaosesTradeGoods.Settings;
using System.Reflection;

namespace KaosesTradeGoods.Objects
{

    public static class Factory
    {
        private static Config? _settings = null;

        public static bool MCMModuleLoaded { get; set; } = false;

        public static Config Settings
        {
            get
            {
                if (_settings == null)
                {
                    _settings = Config.Instance;
                    if (_settings is null)
                    {
                        IM.ShowMessageBox("Failed to load any config provider", "MCM Error");
                    }
                }
                return _settings;
            }
            set
            {
                _settings = value;
            }
        }


        private static string ConfigFilePath
        {

            get
            {
                return @"..\\..\\Modules\\" + SubModule.ModuleId + "\\config.json";
            }
            //set {  = value; }

        }
        public static string ModVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();

        #region MCMConfigValues
        //public static string? MCMConfigFolder { get; set; }
        //public static string? MCMConfigFile { get; set; }
        //public static bool MCMConfigFileExists { get; set; } = false;
        //public static bool MCMModuleLoaded { get; set; } = false;
        //public static bool ModConfigFileExists { get; set; } = false;
        #endregion

    }
}

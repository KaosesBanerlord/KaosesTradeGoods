using KaosesTradeGoods.Settings;

namespace KaosesTradeGoods
{
    public static class Statics
    {
        public static ISettingsProviderInterface? _settings;
        public const string ModuleFolder = "KaosesTradeGoods";
        public const string InstanceID = ModuleFolder;
        public const string DisplayName = "Kaoses Trade Goods";
        public const string FormatType = "json";//json2
        public const string logPath = @"..\\..\\Modules\\" + ModuleFolder + "\\KaosLog.txt";
        public const string ConfigFilePath = @"..\\..\\Modules\\" + ModuleFolder + "\\config.json";
        public static string PrePrend { get; set; } = DisplayName;
        public const string HarmonyId = ModuleFolder + ".harmony";
        public const bool UsesHarmony = false;

        #region MCMConfigValues
        public static string? MCMConfigFolder { get; set; }
        public static string? MCMConfigFile { get; set; }
        public static bool MCMConfigFileExists { get; set; } = false;
        public static bool MCMModuleLoaded { get; set; } = false;
        public static bool ModConfigFileExists { get; set; } = false;
        #endregion


        //~DEBUG
        public static bool Debug { get; set; } = false;
        public static bool LogToFile { get; set; } = false;


    }
}
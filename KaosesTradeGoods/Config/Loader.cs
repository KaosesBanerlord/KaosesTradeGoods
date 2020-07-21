using KaosesTradeGoods.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.Engine;

namespace KaosesTradeGoods.Config
{
    public static class Loader
    {

        public static void LoadConfig()
        {
            if (!File.Exists(KaosesTradeGoodsSubModule.ConfigFilePath) && File.Exists(KaosesTradeGoodsSubModule.ConfigFileBasePath))
            {
                try
                {
                    File.Copy(KaosesTradeGoodsSubModule.ConfigFileBasePath, KaosesTradeGoodsSubModule.ConfigFilePath);
                }
                catch (Exception e)
                {
                    Logging.lm(e.ToString());
                }

            }
            if (!File.Exists(KaosesTradeGoodsSubModule.ConfigFilePath))
            {
                Logging.lm("Config File Not FOUND");
            }
            try
            {
                Logging.lm("Config File FOUND Loading object");
                Settings settings = new Settings();
                settings = JsonConvert.DeserializeObject<Settings>(File.ReadAllText(KaosesTradeGoodsSubModule.ConfigFilePath));
                if (!isModlibLoaded(settings.bOverRideModLibSettings))
                {
                    Logging.lm("No Modlib or overriding Modlib  all values set from config");
                    Settings.SetSettings(settings);
                }
                else
                {
                    Logging.lm("Modlib all values set from Modlib");
                }
            }
            catch (Exception e)
            {
                Logging.lm(e.Message.ToString());
                Logging.lm(e.ToString());
            }
        }
        public static bool isModlibLoaded(bool overrideSettings = true)
        {
            var modnames = Utilities.GetModulesNames().ToList();
            bool modLibLoaded = false;
            if (modnames.Contains("ModLib") && !overrideSettings)
            {
                modLibLoaded = true;
            }
            return modLibLoaded;
        }
    }
}

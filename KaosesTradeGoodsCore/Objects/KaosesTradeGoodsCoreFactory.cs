using KaosesCommon;
using KaosesCommon.Objects;
using KaosesCommon.Utils;
using KaosesTradeGoodsCore.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KaosesTradeGoodsCore.Objects
{
    /// <summary>
    /// KaosesTradeGoodsCoreFactory Factory Object
    /// </summary>
    public static class KaosesTradeGoodsCoreFactory
    {
        /// <summary>
        /// Variable to hold the MCM settings object
        /// </summary>
        private static KaosesTradeGoodsCoreConfig _settings = null;

        private static InfoMgr? _im = null;

        public static InfoMgr IM
        {
            get
            {
                return _im;
            }
            set
            {
                _im = value;
            }
        }

        /// <summary>
        /// MCM Settings Object Instance
        /// </summary>
        public static KaosesTradeGoodsCoreConfig Settings
        {
            get
            {
                if (_settings == null)
                {
                    _settings = KaosesTradeGoodsCoreConfig.Instance;
                    if (_settings is null)
                    {
                        //IM.ShowMessageBox("KaosesTradeGoodsCoreConfig Failed to load KaosesTradeGoodsCoreConfig provider", "KaosesTradeGoodsCoreConfig Error");
                    }
                }
                return _settings;
            }
            set
            {
                _settings = value;
            }
        }

        /// <summary>
        /// Mod version
        /// </summary>
        public static string ModVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();

    }
}

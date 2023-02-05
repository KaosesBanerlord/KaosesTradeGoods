using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.Localization;

namespace KaosesTradeGoodsCore.Settings
{
    public class KaosesTradeGoodsCoreConfig
    {
        private static KaosesTradeGoodsCoreConfig _instance = null;

        private KaosesTradeGoodsCoreConfig()
        {

        }

        public static KaosesTradeGoodsCoreConfig Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new KaosesTradeGoodsCoreConfig();
                return _instance;
            }
        }



        #region Debug

        public bool Debug { get; set; } = false;

        public bool LogToFile { get; set; } = false;


        #endregion //~Debug


        ///~ Mod Specific settings 
        #region Mod Specific settings

        public bool bUseAnimalModifiers { get; set; } = false;
        public float weightAnimalMultiplier { get; set; } = 1.0f;
        public float valueAnimalMultiplier { get; set; } = 1.0f;
        public bool bUseTradeGoodsModifiers { get; set; } = false;
        public float weightGoodsMultiplier { get; set; } = 1.5f;
        public float valueGoodsMultiplier { get; set; } = 1.5f;
        public bool bUseFoodTypeModifiers { get; set; } = false;
        public float weightFoodMultiplier { get; set; } = 0.5f;
        public float valueFoodMultiplier { get; set; } = 1.0f;
        public bool bUseFoodMoralModifiers { get; set; } = false;
        public float weightFoodByMoral0Multiplier { get; set; } = 0.5f;
        public float weightFoodByMoral1Multiplier { get; set; } = 1.0f;
        public float weightFoodByMoral2Multiplier { get; set; } = 1.5f;
        public float weightFoodByMoral3Multiplier { get; set; } = 2.0f;
        public float valueFoodByMoral0Multiplier { get; set; } = 0.5f;
        public float valueFoodByMoral1Multiplier { get; set; } = 1.0f;
        public float valueFoodByMoral2Multiplier { get; set; } = 1.5f;
        public float valueFoodByMoral3Multiplier { get; set; } = 2.0f;


        #endregion


    }
}

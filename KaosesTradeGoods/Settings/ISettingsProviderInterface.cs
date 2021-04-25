
namespace KaosesTradeGoods.Settings
{
    public interface ISettingsProviderInterface
    {
        bool Debug { get; set; }
        bool LoadMCMConfigFile { get; set; }
        bool LogToFile { get; set; }
        string ModDisplayName { get; }

        ///~ Mod Specific settings 
        public bool bUseAnimalModifiers { get; set; }

        public float weightAnimalMultiplier { get; set; }

        public float valueAnimalMultiplier { get; set; }

        public bool bUseTradeGoodsModifiers { get; set; }

        public float weightGoodsMultiplier { get; set; }

        public float valueGoodsMultiplier { get; set; }

        public bool bUseFoodTypeModifiers { get; set; }

        public float weightFoodMultiplier { get; set; }

        public float valueFoodMultiplier { get; set; }


        public bool bUseFoodMoralModifiers { get; set; }

        public float weightFoodByMoral0Multiplier { get; set; }

        public float weightFoodByMoral1Multiplier { get; set; }

        public float weightFoodByMoral2Multiplier { get; set; }

        public float weightFoodByMoral3Multiplier { get; set; }

        public float valueFoodByMoral0Multiplier { get; set; }

        public float valueFoodByMoral1Multiplier { get; set; }

        public float valueFoodByMoral2Multiplier { get; set; }

        public float valueFoodByMoral3Multiplier { get; set; }

    }
}

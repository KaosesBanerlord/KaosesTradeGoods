using Bannerlord.BUTR.Shared.Helpers;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace KaosesTradeGoods.Settings
{
    public class Settings : ISettingsProviderInterface
    {
        //private readonly ISettingsProviderInterface _provider;
        public static Settings? Instance;

        public string Id => Statics.InstanceID;
        string modName = Statics.DisplayName;
        public string DisplayName => TextObjectHelper.Create("{=testModDisplayName}" + modName + " {VERSION}", new Dictionary<string, TextObject>()
        {
            { "VERSION", TextObjectHelper.Create(typeof(MCMSettings).Assembly.GetName().Version?.ToString(3) ?? "")! }
        })!.ToString();

        public bool Debug { get; set; } = false;
        public bool LoadMCMConfigFile { get; set; } = false;
        public bool LogToFile { get; set; } = false;
        public string ModDisplayName { get { return DisplayName; } }

        ///~ Mod Specific settings 
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






    }
}

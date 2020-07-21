using ModLib.Definitions;
using ModLib.Definitions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace KaosesTradeGoods.Config
{

    public class Settings : SettingsBase
    {

        public const string InstanceID = KaosesTradeGoodsSubModule.InstanceID;
        public const string ModuleFolder = KaosesTradeGoodsSubModule.ModuleFolder;
        public override string ModName => "Kaoses Trade Goods " + KaosesTradeGoodsSubModule.Version;
        public override string ModuleFolderName => ModuleFolder;

        [XmlElement]
        public override string ID { get; set; } = InstanceID;
        private static Settings _instance;

        public static Settings Instance
        {
            get
            {
                if (_instance == null)
                {
                    //_instance = new Settings();
                    _instance = (Settings)SettingsDatabase.GetSettings<Settings>();
                }
                return _instance;
                //return (Settings)SettingsDatabase.GetSettings<Settings>();
            }
        }

        public static void SetSettings(Settings settings)
        {
            _instance = settings;
        }


        public bool bIsDebug { get; set; } = false;

        public bool bLogToFile { get; set; } = false;

        public bool bOverRideModLibSettings { get; set; } = false;

        public string modVersionOfConfig { get; set; } = KaosesTradeGoodsSubModule.Version;

        [XmlElement]
        [SettingProperty("Modify food values by type Enabled", "Enables modifying all food items by multipliers")]
        [SettingPropertyGroup("Trade/Config")]
        public bool bUseFoodTypeModifiers { get; set; } = false;

        [XmlElement]
        [SettingProperty("Modify food values by moral Enabled", "Enables modifying the values for food based on moral values")]
        [SettingPropertyGroup("Trade/Config")]
        public bool bUseFoodMoralModifiers { get; set; } = false;

        [XmlElement]
        [SettingProperty("Animal Modifiers Enabled", "Enables Animal trade good Multipliers")]
        [SettingPropertyGroup("Trade/Config")]
        public bool bUseAnimalModifiers { get; set; } = false;

        [XmlElement]
        [SettingProperty("Goods Modifiers Enabled", "Enables Goods trade good Multipliers")]
        [SettingPropertyGroup("Trade/Config")]
        public bool bUseTradeGoodsModifiers { get; set; } = false;




        [XmlElement]
        [SettingProperty("Animal Weight Multiplier", 0.1f, 10.0f, "Multiply Animal Weight by the multiplier supplied")]
        [SettingPropertyGroup("Trade/Animal/Weight")]
        public float weightAnimalMultiplier { get; set; } = 1.0f;

        [XmlElement]
        [SettingProperty("Animal Value Multiplier", 0.1f, 10.0f, "Multiply Animal Value by the multiplier supplied")]
        [SettingPropertyGroup("Trade/Animal/Value")]
        public float valueAnimalMultiplier { get; set; } = 1.0f;

        [XmlElement]
        [SettingProperty("Trade goods Weight Multiplier", 0.1f, 10.0f, "Multiply Trade goods Weight by the multiplier supplied")]
        [SettingPropertyGroup("Trade/Goods/Weight")]
        public float weightGoodssMultiplier { get; set; } = 1.5f;

        [XmlElement]
        [SettingProperty("Trade goods Value Multiplier", 0.1f, 10.0f, "Multiply Trade goods Value by the multiplier supplied")]
        [SettingPropertyGroup("Trade/Goods/Value")]
        public float valueGoodsMultiplier { get; set; } = 1.5f;






        [XmlElement]
        [SettingProperty("Food Weight Multiplier", 0.1f, 10.0f, "Multiply Food Weight by the multiplier supplied")]
        [SettingPropertyGroup("Trade/Food By Type/Weight")]
        public float weightFoodMultiplier { get; set; } = 0.5f;

        [XmlElement]
        [SettingProperty("Food Value Multiplier", 0.1f, 10.0f, "Multiply Food Value by the multiplier supplied")]
        [SettingPropertyGroup("Trade/Food By Type/Value")]
        public float valueFoodMultiplier { get; set; } = 1.0f;


        [XmlElement]
        [SettingProperty("Food Weight for Moral 0 Bonus Multiplier", 0.1f, 10.0f, "Multiply Food Weight for Moral 0 Bonus eg. grain")]
        [SettingPropertyGroup("Trade/Food by Moral/Weight")]
        public float weightFoodByMoral0Multiplier { get; set; } = 0.5f;

        [XmlElement]
        [SettingProperty("Food Weight for Moral 1 Multiplier", 0.1f, 10.0f, "Multiply Food Weight for Moral 1 Bouns")]
        [SettingPropertyGroup("Trade/Food by Moral/Weight")]
        public float weightFoodByMoral1Multiplier { get; set; } = 1.0f;

        [XmlElement]
        [SettingProperty("Food Weight for Moral 2 Multiplier", 0.1f, 10.0f, "Multiply Food Weight for Moral 2 Bouns ")]
        [SettingPropertyGroup("Trade/Food by Moral/Weight")]
        public float weightFoodByMoral2Multiplier { get; set; } = 1.5f;

        [XmlElement]
        [SettingProperty("Food Weight for Moral 3 Multiplier", 0.1f, 10.0f, "Multiply Food Weight for Moral 3 Bouns")]
        [SettingPropertyGroup("Trade/Food by Moral/Weight")]
        public float weightFoodByMoral3Multiplier { get; set; } = 2.0f;


        [XmlElement]
        [SettingProperty("Food value for Moral 0 Bouns Multiplier", 0.1f, 10.0f, "Multiply Food value for Moral 0 Bouns  eg. grain")]
        [SettingPropertyGroup("Trade/Food by Moral/Value")]
        public float valueFoodByMoral0Multiplier { get; set; } = 0.5f;

        [XmlElement]
        [SettingProperty("Food value for Moral 1 Multiplier", 0.1f, 10.0f, "Multiply Food value for Moral 1 Bouns")]
        [SettingPropertyGroup("Trade/Food by Moral/Value")]
        public float valueFoodByMoral1Multiplier { get; set; } = 1.0f;

        [XmlElement]
        [SettingProperty("Food value for Moral 2 Multiplier", 0.1f, 10.0f, "Multiply Food value for Moral 2 Bouns")]
        [SettingPropertyGroup("Trade/Food by Moral/Value")]
        public float valueFoodByMoral2Multiplier { get; set; } = 1.5f;

        [XmlElement]
        [SettingProperty("Food value for Moral 3 Multiplier", 0.1f, 10.0f, "Multiply Food value for Moral 3 Bouns")]
        [SettingPropertyGroup("Trade/Food by Moral/Value")]
        public float valueFoodByMoral3Multiplier { get; set; } = 2.0f;


















    }
}

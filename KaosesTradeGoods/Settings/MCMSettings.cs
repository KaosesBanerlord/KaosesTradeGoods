using Bannerlord.BUTR.Shared.Helpers;
using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v2;
using MCM.Abstractions.Dropdown;
using MCM.Abstractions.Settings.Base.Global;
//using MCM.Abstractions.Settings.Base.PerSave;
using System.Collections.Generic;
using TaleWorlds.Localization;

namespace KaosesTradeGoods.Settings
{
    //public class MCMSettings : AttributePerSaveSettings<MCMSettings>, ISettingsProviderInterface
    //public class MCMSettings : AttributeGlobalSettings<MCMSettings>, ISettingsProviderInterface 
    public class MCMSettings : AttributeGlobalSettings<MCMSettings>, ISettingsProviderInterface
    {

        #region ModSettingsStandard
        public override string Id => Statics.InstanceID;

        // Build mod display name with name and version form the project properties version
#pragma warning disable CS8620 // Argument cannot be used for parameter due to differences in the nullability of reference types.
        string modName = Statics.DisplayName;
        public override string DisplayName => TextObjectHelper.Create("{=KTGDisplayName}" + modName + " {VERSION}", new Dictionary<string, TextObject>()
        {
            { "VERSION", TextObjectHelper.Create(typeof(MCMSettings).Assembly.GetName().Version?.ToString(3) ?? "")! }
        })!.ToString();
#pragma warning restore CS8620 // Argument cannot be used for parameter due to differences in the nullability of reference types.

        public override string FolderName => Statics.ModuleFolder;
        public override string FormatType => Statics.FormatType;

        public bool LoadMCMConfigFile { get; set; } = false;
        public string ModDisplayName { get { return DisplayName; } }
        #endregion

        //[SettingPropertyBool("{=debug}Debug", RequireRestart = false, HintText = "{=}{=debug_desc}Displays mod developer debug information and logs them to the file")]
        //[SettingPropertyGroup("Debug", GroupOrder = 100)]
        public bool Debug { get; set; } = Statics.Debug;

        //[SettingPropertyBool("{=debuglog}Log to file", RequireRestart = false, HintText = "{=}{=debuglog_desc}Log information messages to the log file as well as errors and debug")]
        //[SettingPropertyGroup("Debug", GroupOrder = 100)]
        public bool LogToFile { get; set; } = Statics.LogToFile;




        ///~ Mod Specific settings 
        [SettingPropertyBool("Animal Modifiers Enabled", Order = 0, RequireRestart = false, HintText = "Enables Animal trade good Multipliers.")]
        [SettingPropertyGroup("Trade/Config")]
        public bool bUseAnimalModifiers { get; set; } = false;

        [SettingPropertyFloatingInteger("Animal Weight Multiplier", 0.1f, 10.0f, Order = 2, RequireRestart = false, HintText = "Multiply Animal Weight by the multiplier supplied.")]
        [SettingPropertyGroup("Trade/Animal/Weight")]
        public float weightAnimalMultiplier { get; set; } = 1.0f;


        [SettingPropertyFloatingInteger("Animal Value Multiplier", 0.1f, 10.0f, Order = 2, RequireRestart = false, HintText = "Multiply Animal Value by the multiplier supplied.")]
        [SettingPropertyGroup("Trade/Animal/Value")]
        public float valueAnimalMultiplier { get; set; } = 1.0f;



        [SettingPropertyBool("Goods Modifiers Enabled", Order = 0, RequireRestart = false, HintText = "Enables Goods trade good Multipliers.")]
        [SettingPropertyGroup("Trade/Config")]
        public bool bUseTradeGoodsModifiers { get; set; } = false;

        [SettingPropertyFloatingInteger("Trade goods Weight Multiplier", 0.1f, 10.0f, Order = 2, RequireRestart = false, HintText = "Multiply Trade goods Weight by the multiplier supplied.")]
        [SettingPropertyGroup("Trade/Goods/Weight")]
        public float weightGoodsMultiplier { get; set; } = 1.5f;


        [SettingPropertyFloatingInteger("Trade goods Value Multiplier", 0.1f, 10.0f, Order = 2, RequireRestart = false, HintText = "Multiply Trade goods Value by the multiplier supplied.")]
        [SettingPropertyGroup("Trade/Goods/Value")]
        public float valueGoodsMultiplier { get; set; } = 1.5f;





        //[SettingPropertyBool("Modify food values by type Enabled", Order = 0, RequireRestart = false, HintText = "Enables modifying all food items by multipliers.")]
        //[SettingPropertyGroup("Trade/Config")]
        public bool bUseFoodTypeModifiers { get; set; } = false;


        //[SettingPropertyFloatingInteger("Food Weight Multiplier", 0.1f, 10.0f, Order = 2, RequireRestart = false, HintText = "Multiply Food Weight by the multiplier supplied.")]
        //[SettingPropertyGroup("Trade/Food By Type/Weight")]
        public float weightFoodMultiplier { get; set; } = 0.5f;


        //[SettingPropertyFloatingInteger("Food Value Multiplier", 0.1f, 10.0f, Order = 2, RequireRestart = false, HintText = "Multiply Food Value by the multiplier supplied.")]
        //[SettingPropertyGroup("Trade/Food By Type/Value")]
        public float valueFoodMultiplier { get; set; } = 1.0f;





        [SettingPropertyBool("Modify food values by moral Enabled", Order = 0, RequireRestart = false, HintText = "Enables modifying the values for food based on moral values.")]
        [SettingPropertyGroup("Trade/Config")]
        public bool bUseFoodMoralModifiers { get; set; } = false;

        [SettingPropertyFloatingInteger("Food Weight for Moral 0 Bonus Multiplier", 0.1f, 10.0f, Order = 2, RequireRestart = false, HintText = "Multiply Food Weight for Moral 0 Bonus eg. grain.")]
        [SettingPropertyGroup("Trade/Food by Moral/Weight")]
        public float weightFoodByMoral0Multiplier { get; set; } = 0.5f;


        [SettingPropertyFloatingInteger("Food Weight for Moral 1 Multiplier", 0.1f, 10.0f, Order = 2, RequireRestart = false, HintText = "Multiply Food Weight for Moral 1 bonus.")]
        [SettingPropertyGroup("Trade/Food by Moral/Weight")]
        public float weightFoodByMoral1Multiplier { get; set; } = 1.0f;


        [SettingPropertyFloatingInteger("Food Weight for Moral 2 Multiplier", 0.1f, 10.0f, Order = 2, RequireRestart = false, HintText = "Multiply Food Weight for Moral 2 bonus.")]
        [SettingPropertyGroup("Trade/Food by Moral/Weight")]
        public float weightFoodByMoral2Multiplier { get; set; } = 1.5f;


        [SettingPropertyFloatingInteger("Food Weight for Moral 3 Multiplier", 0.1f, 10.0f, Order = 2, RequireRestart = false, HintText = "Multiply Food Weight for Moral 3 bonus.")]
        [SettingPropertyGroup("Trade/Food by Moral/Weight")]
        public float weightFoodByMoral3Multiplier { get; set; } = 2.0f;



        [SettingPropertyFloatingInteger("Food value for Moral 0 bonus Multiplier", 0.1f, 10.0f, Order = 2, RequireRestart = false, HintText = "Multiply Food value for Moral 0 bonus  eg. grain.")]
        [SettingPropertyGroup("Trade/Food by Moral/Value")]
        public float valueFoodByMoral0Multiplier { get; set; } = 0.5f;


        [SettingPropertyFloatingInteger("Food value for Moral 1 Multiplier", 0.1f, 10.0f, Order = 2, RequireRestart = false, HintText = "Multiply Food value for Moral 1 bonus.")]
        [SettingPropertyGroup("Trade/Food by Moral/Value")]
        public float valueFoodByMoral1Multiplier { get; set; } = 1.0f;


        [SettingPropertyFloatingInteger("Food value for Moral 2 Multiplier", 0.1f, 10.0f, Order = 2, RequireRestart = false, HintText = "Multiply Food value for Moral 2 bonus.")]
        [SettingPropertyGroup("Trade/Food by Moral/Value")]
        public float valueFoodByMoral2Multiplier { get; set; } = 1.5f;


        [SettingPropertyFloatingInteger("Food value for Moral 3 Multiplier", 0.1f, 10.0f, Order = 2, RequireRestart = false, HintText = "Multiply Food value for Moral 3 bonus.")]
        [SettingPropertyGroup("Trade/Food by Moral/Value")]
        public float valueFoodByMoral3Multiplier { get; set; } = 2.0f;






    }
}

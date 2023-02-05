using HarmonyLib;
using KaosesCommon.Objects;
using KaosesCommon.Utils;
using KaosesTradeGoods.Objects;
using KaosesTradeGoodsCore.Objects;
using KaosesTradeGoodsCore.Settings;
using MCM.Abstractions;
using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v2;
using MCM.Abstractions.Base.Global;
using MCM.Common;
using System;
using System.Collections.Generic;
using System.Reflection;
using TaleWorlds.Localization;
using static HarmonyLib.Code;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;
using CoreConfig = KaosesTradeGoodsCore.Settings.KaosesTradeGoodsCoreConfig;
using CoreFactory = KaosesTradeGoodsCore.Objects.KaosesTradeGoodsCoreFactory;

//using MCM.Abstractions.Settings.Base.PerSave;


namespace KaosesTradeGoods.Settings
{
    //public class Settings : AttributePerSaveSettings<Settings>, ISettingsProviderInterface
    public class Config : AttributeGlobalSettings<Config>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Config()
        {
            PropertyChanged += Settings_PropertyChanged;
        }


        #region ModSettingsStandard
        public override string Id => SubModule.ModuleId;
        public override string FolderName => SubModule.ModuleId;
        public string ModName => "KaosesTradeGoods";
        public override string FormatType => "json";
        #region Translatable DisplayName 
        // Build mod display name with name and version form the project properties version
#pragma warning disable CS8620 // Argument cannot be used for parameter due to differences in the null ability of reference types.
        public TextObject versionTextObj = new TextObject(typeof(Config).Assembly.GetName().Version?.ToString(3) ?? "");
        public override string DisplayName => new TextObject("{=KaosesTradeGoodsDisplayName}" + ModName + " " + versionTextObj.ToString())!.ToString();
#pragma warning restore CS8620 // Argument cannot be used for parameter due to differences in the null ability of reference types.
        #endregion
        public string ModDisplayName { get { return DisplayName; } }
        #endregion

        #region Debug

        [SettingPropertyBool("{=debug}Debug", RequireRestart = false, HintText = "{=debug_desc}Displays mod developer debug information and logs them to the file")]
        [SettingPropertyGroup("Debug", GroupOrder = 1)]
        public bool Debug { get; set; } = false;
        [SettingPropertyBool("{=debuglog}Log to file", RequireRestart = false, HintText = "{=debuglog_desc}Log information messages to the log file as well as errors and debug")]
        [SettingPropertyGroup("Debug", GroupOrder = 2)]
        public bool LogToFile { get; set; } = false;


        [SettingPropertyBool("{=debugharmony}Debug Harmony", RequireRestart = false, HintText = "{=debugharmony_desc}Enable/Disable harmony's debuging logs")]
        [SettingPropertyGroup("Debug", GroupOrder = 2)]
        public bool IsHarmonyDebug { get; set; } = false;


        #endregion //~Debug


        ///~ Mod Specific settings 
        #region Mod Specific settings


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




        #endregion

        //~ Presets
        #region Presets
        public override IEnumerable<ISettingsPreset> GetBuiltInPresets()
        {
            foreach (var preset in base.GetBuiltInPresets())
            {
                yield return preset;
            }

            yield return new MemorySettingsPreset(Id, "native all off", "Native All Off", () => new Config
            {

            });


            yield return new MemorySettingsPreset(Id, "native all on", "Native All On", () => new Config
            {
                //TownFoodBonus = 4.0f,
                //SettlementFoodBonusEnabled = true,
                //SettlementProsperityFoodMalusDivisor = 100
            });
        }
        #endregion


        private void Settings_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            // Change log to file to false if debug is false. IF build mode is debug sets log to file to true if debug is true
            if (e.PropertyName == nameof(Debug))
            {
                if (Debug == false)
                {
                    LogToFile = false;
                }
                else
                {
                }
            }

            CoreConfig config = CoreFactory.Settings;
            Type typModelCls = this.GetType(); //trans is the object name
            foreach (PropertyInfo prop in typModelCls.GetProperties())
            {
                if (typeof(CoreConfig).GetProperty(prop.Name) != null)
                {
                    if (prop.ToString().Contains("MCM.Common.Dropdown"))
                    {
                        // Set any Drop downs manually here
                        //config.DropDownName = DropDownName.SelectedValue.ToString();
                    }
                    else
                    {
                        typeof(CoreConfig).GetProperty(prop.Name).SetValue(config, prop.GetValue(this, null));

                    }
                }
            }
            DupValues();
        }

        public void DupValues()
        {

            CoreConfig config = CoreFactory.Settings;
            Type typModelCls = this.GetType(); //trans is the object name
            foreach (PropertyInfo prop in typModelCls.GetProperties())
            {
                if (typeof(CoreConfig).GetProperty(prop.Name) != null)
                {
                    string message = "Name: " + prop.Name + " : ";
                    if (!prop.ToString().Contains("MCM.Common.Dropdown"))
                    {
                        message += prop.GetValue(this, null) + "  Core: " + typeof(CoreConfig).GetProperty(prop.Name).GetValue(config, null).ToString();
                    }
                    else
                    {
                        //message += DropDownName.SelectedValue.ToString() + " core: " + config.DropDownName;
                    }
                    Factory.IM.MessageDebug(message);
                    Factory.IM.Lm(message);
                }
            }
        }

        public void DebugConfigProperties()
        {
            Type typModelCls = this.GetType(); //trans is the object name
            foreach (PropertyInfo prop in typModelCls.GetProperties())
            {
                Factory.IM.MessageDebug("Name: " + prop.Name + " : " + prop.GetValue(this, null));
            }
        }

    }
}

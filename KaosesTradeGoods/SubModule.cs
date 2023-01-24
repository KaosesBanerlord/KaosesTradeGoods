using KaosesTradeGoods.Items;
using System;
using HarmonyLib;
using System.Reflection;
using KaosesCommon.Utils;
using KaosesCommon;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;
using KaosesTradeGoods.Objects;

namespace KaosesTradeGoods
{
    public class SubModule : MBSubModuleBase
    {
        public const bool UsesHarmony = true;
        public const string ModuleId = "KaosesTradeGoods";
        public const string modulePath = @"..\\..\\Modules\\" + ModuleId + "\\";
        public const string HarmonyId = ModuleId + ".harmony";
        private Harmony? _harmony;

        protected override void OnBeforeInitialModuleScreenSetAsRoot()
        {
            base.OnBeforeInitialModuleScreenSetAsRoot();
            new Init();
            //IM.MessageModInfo();
            //IM.MessageDebug(ModuleId + " : Mod Logging test");
            try
            {
                if (UsesHarmony)
                {
                    if (Kaoses.IsHarmonyLoaded())
                    {
                        IM.MessageModLoaded();
                        try
                        {
                            if (_harmony == null)
                            {
                                Harmony.DEBUG = true;
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                                _harmony = new Harmony(ModuleId);
                                _harmony.PatchAll(Assembly.GetExecutingAssembly());
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                            }

                        }
                        catch (Exception ex)
                        {
                            IM.ShowError(ex, Factory.Settings.ModName + " Harmony Error:");
                        }
                    }
                    else { IM.MessageHarmonyLoadError(); }
                }
                else
                {
#pragma warning disable CS0162 // Unreachable code detected
                    IM.MessageModLoaded();
#pragma warning restore CS0162 // Unreachable code detected
                }
            }
            catch (Exception ex)
            {
                IM.ShowError(ex, "initial Loading Error " + Factory.Settings.ModName);
            }
        }

        protected override void OnSubModuleLoad()
        {
            base.OnSubModuleLoad();
        }

        protected override void OnGameStart(Game game, IGameStarter gameStarter)
        {
            base.OnGameStart(game, gameStarter);
            if (game.GameType is Campaign)
            {
                CampaignGameStarter campaignGameStarter = (CampaignGameStarter)gameStarter;
                //campaignGameStarter.LoadGameTexts(BasePath.Name + "Modules/" + Statics.ModuleFolder + "/ModuleData/module_strings.xml");
            }
        }



        public override void OnGameInitializationFinished(Game game)
        {
            // Called 4th after choosing (Resume Game, Campaign, Custom Battle) from the main menu.
            base.OnGameInitializationFinished(game);
            Campaign gameType = game.GameType as Campaign;
            if (!(gameType is Campaign))
            {
                return;
            }

            if (gameType != null)
            {
                if (Factory.Settings.bUseTradeGoodsModifiers)
                {


                    if (Factory.Settings.LogToFile) { Logger.Lm("********* TradeGoodsValue  ******************************************************************"); }
                    TradeGoods.ProcessTradeGoodsValue(TaleWorlds.CampaignSystem.Extensions.Items.All);
                    if (Factory.Settings.LogToFile) { Logger.Lm("********* TradeGoodsWeight  *****************************************************************"); }
                    TradeGoods.ProcessTradeGoodsWeight(TaleWorlds.CampaignSystem.Extensions.Items.All);
                }

                if (Factory.Settings.bUseAnimalModifiers)
                {
                    if (Factory.Settings.LogToFile) { Logger.Lm("********* AnimalGoodsValue  *****************************************************************"); }
                    TradeGoods.ProcessAnimalGoodsValue(TaleWorlds.CampaignSystem.Extensions.Items.All);
                    if (Factory.Settings.LogToFile) { Logger.Lm("********* AnimalGoodsWeight  *****************************************************************"); }
                    TradeGoods.ProcessAnimalGoodsWeight(TaleWorlds.CampaignSystem.Extensions.Items.All);
                }

                if (Factory.Settings.bUseFoodMoralModifiers)
                {
                    if (Factory.Settings.LogToFile) { Logger.Lm("********* Moral FoodGoodsValueValue  *****************************************************************"); }
                    TradeGoods.ProcessFoodGoodsValueByMoral(TaleWorlds.CampaignSystem.Extensions.Items.All);
                    if (Factory.Settings.LogToFile) { Logger.Lm("********* Moral FoodGoodsValueWeight  *****************************************************************"); }
                    TradeGoods.ProcessFoodGoodsWeightByMoral(TaleWorlds.CampaignSystem.Extensions.Items.All);
                }

                if (Factory.Settings.bUseFoodTypeModifiers)
                {
                    if (Factory.Settings.LogToFile) { Logger.Lm("********* FoodGoodsValue  *****************************************************************"); }
                    TradeGoods.ProcessFoodGoodsValue(TaleWorlds.CampaignSystem.Extensions.Items.All);
                    if (Factory.Settings.LogToFile) { Logger.Lm("********* FoodGoodsWeight  *****************************************************************"); }
                    TradeGoods.ProcessFoodGoodsWeight(TaleWorlds.CampaignSystem.Extensions.Items.All);
                }
            }



        }

        protected override void OnSubModuleUnloaded()
        {
            base.OnSubModuleUnloaded();
        }
        public override void OnGameEnd(Game game)
        {
        }
    }
}
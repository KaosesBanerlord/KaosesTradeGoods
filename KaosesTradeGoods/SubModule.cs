using KaosesTradeGoods.Settings;
using KaosesTradeGoods.Items;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;
using System;
using KaosesCommon;
using KaosesCommon.Utils;
using HarmonyLib;
using System.Reflection;

namespace KaosesTradeGoods
{
    public class SubModule : MBSubModuleBase
    {
        public static MCMSettings? _settings;
        private Harmony _harmony;

        protected override void OnBeforeInitialModuleScreenSetAsRoot()
        {
            base.OnBeforeInitialModuleScreenSetAsRoot();
            try
            {
                ConfigLoader.LoadConfig();
                bool modUsesHarmoney = Statics.UsesHarmony;
                if (modUsesHarmoney)
                {
                    if (Kaoses.IsHarmonyLoaded())
                    {
                        IM.DisplayModLoadedMessage();
                        try
                        {
                            if (_harmony == null)
                            {
                                _harmony = new Harmony(Statics.HarmonyId);
                                _harmony.PatchAll(Assembly.GetExecutingAssembly());
                            }

                        }
                        catch (Exception ex)
                        {
                            IM.ShowError("Error with harmony patch", "Kaoses Parties error", ex);
                        }
                    }
                    else { IM.DisplayModHarmonyErrorMessage(); }
                }
                else { IM.DisplayModLoadedMessage(); }
            }
            catch (Exception ex)
            {
                IM.ShowError("Error loading", "initial Mod Data", ex);
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
                if (Statics._settings.bUseTradeGoodsModifiers)
                {
                    
                    if (Statics._settings.LogToFile) { Logger.Lm("********* TradeGoodsValue  ******************************************************************");}
                    TradeGoods.processTradeGoodsValue(TaleWorlds.CampaignSystem.Items.All);
                    if (Statics._settings.LogToFile) { Logger.Lm("********* TradeGoodsWeight  *****************************************************************");}
                    TradeGoods.processTradeGoodsWeight(TaleWorlds.CampaignSystem.Items.All);
                }

                if (Statics._settings.bUseAnimalModifiers)
                {
                    if (Statics._settings.LogToFile) { Logger.Lm("********* AnimalGoodsValue  *****************************************************************"); }
                    TradeGoods.processAnimalGoodsValue(TaleWorlds.CampaignSystem.Items.All);
                    if (Statics._settings.LogToFile) { Logger.Lm("********* AnimalGoodsWeight  *****************************************************************"); }
                    TradeGoods.processAnimalGoodsWeight(TaleWorlds.CampaignSystem.Items.All);
                }

                if (Statics._settings.bUseFoodMoralModifiers)
                {
                    if (Statics._settings.LogToFile) { Logger.Lm("********* Moral FoodGoodsValueValue  *****************************************************************"); }
                    TradeGoods.processFoodGoodsValueByMoral(TaleWorlds.CampaignSystem.Items.All);
                    if (Statics._settings.LogToFile) { Logger.Lm("********* Moral FoodGoodsValueWeight  *****************************************************************"); }
                    TradeGoods.processFoodGoodsWeightByMoral(TaleWorlds.CampaignSystem.Items.All);
                }

                if (Statics._settings.bUseFoodTypeModifiers)
                {
                    if (Statics._settings.LogToFile) { Logger.Lm("********* FoodGoodsValue  *****************************************************************"); }
                    TradeGoods.processFoodGoodsValue(TaleWorlds.CampaignSystem.Items.All);
                    if (Statics._settings.LogToFile) { Logger.Lm("********* FoodGoodsWeight  *****************************************************************"); }
                    TradeGoods.processFoodGoodsWeight(TaleWorlds.CampaignSystem.Items.All);
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
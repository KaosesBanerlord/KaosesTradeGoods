using KaosesTradeGoods.Settings;
using KaosesTradeGoods.Utils;
using KaosesTradeGoods.Items;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;
using KaosesTradeGoods.Common;
using System;

namespace KaosesTradeGoods
{
    public class SubModule : MBSubModuleBase
    {
        public static ISettingsProviderInterface? _settings;
        //private Harmony _harmony;

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
                    }
                    else { IM.DisplayModHarmonyErrorMessage(); }
                }
                else { IM.DisplayModLoadedMessage(); }
            }
            catch (Exception ex)
            {
                //Handle exceptions
                IM.MessageError("Error loading initial config: " + ex.ToStringFull());
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

/*
            try
            {
                var harmony = new Harmony(Statics.HarmonyId);
                harmony.PatchAll(Assembly.GetExecutingAssembly());
            }
            catch (Exception ex)
            {
                //Handle exceptions
                IM.MessageError("Error with harmony patch: " + ex.ToStringFull());
            }*/

            if (gameType != null)
            {
                if (Statics._settings.bUseTradeGoodsModifiers)
                {
                    if (Statics._settings.LogToFile) { Logging.Lm("********* TradeGoodsValue  ******************************************************************");}
                    TradeGoods.processTradeGoodsValue(gameType.Items);
                    if (Statics._settings.LogToFile) { Logging.Lm("********* TradeGoodsWeight  *****************************************************************");}
                    TradeGoods.processTradeGoodsWeight(gameType.Items);
                }

                if (Statics._settings.bUseAnimalModifiers)
                {
                    if (Statics._settings.LogToFile) { Logging.Lm("********* AnimalGoodsValue  *****************************************************************"); }
                    TradeGoods.processAnimalGoodsValue(gameType.Items);
                    if (Statics._settings.LogToFile) { Logging.Lm("********* AnimalGoodsWeight  *****************************************************************"); }
                    TradeGoods.processAnimalGoodsWeight(gameType.Items);
                }

                if (Statics._settings.bUseFoodMoralModifiers)
                {
                    if (Statics._settings.LogToFile) { Logging.Lm("********* Moral FoodGoodsValueValue  *****************************************************************"); }
                    TradeGoods.processFoodGoodsValueByMoral(gameType.Items);
                    if (Statics._settings.LogToFile) { Logging.Lm("********* Moral FoodGoodsValueWeight  *****************************************************************"); }
                    TradeGoods.processFoodGoodsWeightByMoral(gameType.Items);
                }

                if (Statics._settings.bUseFoodTypeModifiers)
                {
                    if (Statics._settings.LogToFile) { Logging.Lm("********* FoodGoodsValue  *****************************************************************"); }
                    TradeGoods.processFoodGoodsValue(gameType.Items);
                    if (Statics._settings.LogToFile) { Logging.Lm("********* FoodGoodsWeight  *****************************************************************"); }
                    TradeGoods.processFoodGoodsWeight(gameType.Items);
                }
            }



        }

        protected override void OnSubModuleUnloaded()
        {
            base.OnSubModuleUnloaded();
        }
        public override void OnGameEnd(Game game)
        {
/*
            try
            {
                _harmony?.UnpatchAll(Statics.HarmonyId);
            }
            catch (Exception ex)
            {
                //Handle exceptions
                IM.MessageError("Error OnGameEnd harmony un-patch: " + ex.ToStringFull());
            }*/
        }
    }
}
using KaosesTradeGoods.Settings;
using KaosesTradeGoods.Utils;
using KaosesTradeGoods.Items;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace KaosesTradeGoods
{
    public class SubModule : MBSubModuleBase
    {
        protected override void OnBeforeInitialModuleScreenSetAsRoot()
        {
            base.OnBeforeInitialModuleScreenSetAsRoot();
            ConfigLoader.LoadConfig();
            Ux.MessageInfo("Loaded: " + Statics._settings.ModDisplayName);
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
    }
}
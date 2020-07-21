using System;
using System.Collections.Generic;
using TaleWorlds.MountAndBlade;
using System.Linq;
using System.Text;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using KaosesTradeGoods.Objects;
using StoryMode;
using KaosesTradeGoods.Utils;
using KaosesTradeGoods.Config;

namespace KaosesTradeGoods
{
    public class KaosesTradeGoodsSubModule : MBSubModuleBase
    {
        public const string InstanceID = "Kaoses Trade Goods";
        public const string ModuleFolder = "KaosesTradeGoods";
        public const string Version = "0.0.6";
        public const string logPath = @"..\\..\\Modules\\" + ModuleFolder + "\\KaosLog.txt";
        public const string ConfigFilePath = @"..\\..\\Modules\\" + ModuleFolder + "\\config.json";
        public const string ConfigFileBasePath = @"..\\..\\Modules\\" + ModuleFolder + "\\Config.base.json";

        protected override void OnBeforeInitialModuleScreenSetAsRoot()
        {
            Ux.ShowMessageInfo(InstanceID + " " + Version + " is now enabled.");
        }

        protected override void OnSubModuleLoad()
        {
            // Called 1st during initial loading before intro movie.
            base.OnSubModuleLoad();

            try
            {
                Loader.LoadConfig();
            }
            catch (Exception ex)
            {
                //Handle exceptions
                Logging.lm(ex.ToString());
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
                if (Settings.Instance.bUseTradeGoodsModifiers)
                {
                    Goods.processTradeGoodsValue(gameType.Items);
                    Goods.processTradeGoodsWeight(gameType.Items);
                }

                if (Settings.Instance.bUseAnimalModifiers)
                {
                    Goods.processAnimalGoodsValue(gameType.Items);
                    Goods.processAnimalGoodsWeight(gameType.Items);
                }

                if (Settings.Instance.bUseFoodMoralModifiers)
                {
                    Goods.processFoodGoodsValueByMoral(gameType.Items);
                    Goods.processFoodGoodsWeightByMoral(gameType.Items);
                }

                if (Settings.Instance.bUseFoodTypeModifiers)
                {
                    Goods.processFoodGoodsValue(gameType.Items);
                    Goods.processFoodGoodsWeight(gameType.Items);
                }
            }



        }


    }
}

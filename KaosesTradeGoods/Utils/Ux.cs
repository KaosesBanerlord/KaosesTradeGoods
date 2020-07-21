using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KaosesTradeGoods.Config;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace KaosesTradeGoods.Utils
{

    public static class Ux
    {
        /**
         * colour codes https://cssgenerator.org/rgba-and-hex-color-generator.html
         * colour codes https://quantdev.ssri.psu.edu/sites/qdev/files/Tutorial_ColorR.html
         */
        public static void ShowMessage(string message, Color messageColor, bool printToLog = false)
        {
            InformationManager.DisplayMessage(new InformationMessage(message, messageColor));
            if (printToLog)
            {
                Logging logger = new Logging(KaosesTradeGoodsSubModule.logPath);
                logger.logString(message);
            }
        }

        public static void ShowMessageInfo(string message)
        {
            Ux.ShowMessage(message, Color.ConvertStringToColor("#42FF00FF"), Settings.Instance.bLogToFile);
        }

        public static void ShowMessageDebug(string message)
        {
            if (Settings.Instance.bIsDebug)
            {
                Ux.ShowMessage(message, Color.ConvertStringToColor("#E6FF00FF"));
            }
            Logging.lm(message);
        }

        public static void ShowMessageError(string message)
        {
            Ux.ShowMessage(message, Color.ConvertStringToColor("#FF000000"), true);
            Logging.lm(message);
        }

    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaosesTradeGoods.Utils
{
    class Logging
    {
        private string _logPath;

        public Logging(string logPath)
        {
            this._logPath = logPath;
        }

        public void logString(string message)
        {
            using (StreamWriter sw = File.AppendText(this._logPath))
            {
                sw.WriteLine(message);
            }
        }

        public static void lm(string message)
        {
            using (StreamWriter sw = File.AppendText(KaosesTradeGoodsSubModule.logPath))
            {
                sw.WriteLine(message);
            }
        }
    }
}

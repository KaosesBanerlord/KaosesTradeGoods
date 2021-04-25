using System.IO;

namespace KaosesTradeGoods.Utils
{
    class Logging
    {
        public static void Lm(string message)
        {
            using StreamWriter sw = File.AppendText(Statics.logPath);
            sw.WriteLine(message);
        }

    }
}

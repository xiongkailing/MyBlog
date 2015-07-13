using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalCMS.Infrastructure.SystemLog
{
    public class Log
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private static Log instance;
        public static Log Instance
        {
            get
            {
                if (instance == null)
                    instance = new Log();
                return instance;
            }
        }
        public void WriteLog(LogLevel level,string message, Exception ex = null, int userId = 0)
        {
            LogEventInfo ei = new LogEventInfo(level, "", message);
            ei.Properties["userId"] = userId;
            logger.Log(ei);
        }
    }
}

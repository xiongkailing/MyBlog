using NLog;
using PersonalCMS.Infrastructure.SystemLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalCMS.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Instance.Info(LogLevel.Warn,"Test");
        }
    }
}

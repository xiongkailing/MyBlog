using NLog;
using PersonalCMS.Infrastructure.SystemLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PersonalCMS.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var test=Assembly.GetExecutingAssembly();
            Console.WriteLine(test.GetTypes()[0].Namespace);
        }
    }
}

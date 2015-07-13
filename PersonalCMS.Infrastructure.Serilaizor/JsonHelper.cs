using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PersonalCMS.Infrastructure.Serilaizor
{
    public class JsonHelper
    {
        public static string JsonSerliarize<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
        public static T JsonDeSerliarize<T>(string js)
        {
            return JsonConvert.DeserializeObject<T>(js);
        }
    }
}

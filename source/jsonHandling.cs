using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Bartender_M9D47D
{
    class pathJson
    {
        public string path { get; set; }
    }

    class jsonHandling
    {
        public string setPath()
        {
            string json;
            using (StreamReader r = new StreamReader("resources/serverPath.json"))
            {
                json = r.ReadToEnd();
            }
            pathJson path = JsonConvert.DeserializeObject<pathJson>(json);
            return path.path;
        }
    }
}

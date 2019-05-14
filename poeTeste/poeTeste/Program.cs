using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace poeTeste
{
    class Program
    {
        static void Main(string[] args)
        {
            string jsonreturn = getJson();
            League serialized = JsonConvert.DeserializeObject<League>(jsonreturn);
            Console.WriteLine("Nome da liga: " + serialized.id + "\n" + "Plataforma: "+serialized.realm + "\n" + "Existe delve?: " + serialized.delveEvent);
            Console.ReadKey();
        }
        public static string getJson()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://api.pathofexile.com/leagues/Hardcore");
            WebResponse response = request.GetResponse();
            using(Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                return reader.ReadToEnd();
            }
        }
        internal class League
        {
            public string id;
            public string realm;
            public string url;
            public string startAt;
            public string endAt;
            public bool delveEvent;
        }
    }
}

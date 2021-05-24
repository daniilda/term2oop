using System.IO;
using System.Net;

namespace OOP_78Lab
{
    public class ServerRequester
    {
        public string MakeRequest()
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("https://lenta.ru/rss/last24");
            HttpWebResponse response = (HttpWebResponse)req.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            string strNews = reader.ReadToEnd();
            return strNews;
        }



    }
}
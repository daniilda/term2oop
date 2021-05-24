using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace OOP_78Lab
{
    public static class Editor
    {
        static public List<News> GetNews(string raw)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(raw);
            XmlNode childNode = xDoc.DocumentElement.SelectSingleNode("channel");
            XmlNodeList childNodeList = childNode.SelectNodes("item");
            var list = new List<News>();
            foreach (XmlNode xmlNode in childNodeList)
            {
                var news = new News();
                news.Title = xmlNode.SelectSingleNode("title").InnerText;
                news.Url = xmlNode.SelectSingleNode("link").InnerText;
                news.Desctiprion = xmlNode.SelectSingleNode("description").InnerText;
                news.Time = Convert.ToDateTime(xmlNode.SelectSingleNode("pubDate").InnerText);
            list.Add(news);
            }
            return list;

        }
    }
}

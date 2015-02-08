using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
namespace SimpleLauncher
{
    class xmlController
    {
        public void createXml(string version, string url) 
        {
            XmlWriter xmlWter = XmlWriter.Create("test.xml");

            xmlWter.WriteStartDocument();
            xmlWter.WriteStartElement("app");

            xmlWter.WriteStartElement("version");
            xmlWter.WriteString(version);
            xmlWter.WriteEndElement();

            xmlWter.WriteStartElement("url");
            xmlWter.WriteString(url);

            xmlWter.WriteEndDocument();
            xmlWter.Close();

        }
    }
}

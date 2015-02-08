using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace SimpleLauncher
{
    class updateChecker
    {
        public void checkLocalVersion() {
            XmlDocument doc = new XmlDocument();
            doc.Load("test.xml");
            XmlNodeList node = doc.DocumentElement.SelectNodes("/app");
            string versionNum = "";
            foreach (XmlNode n in node) {
                versionNum = n.SelectSingleNode("version").InnerText;
            }

        }
        public void checkUpdate() {
            XmlDocument doc = new XmlDocument();
            doc.Load("https://raw.githubusercontent.com/Borgdude/borgdude.github.io/master/update.xml");
            XmlNodeList node = doc.DocumentElement.SelectNodes("/app");
            string versionLat = "";
            foreach (XmlNode n in node)
            {
                versionLat = n.SelectSingleNode("version").InnerText;
            }
        }
    }
}

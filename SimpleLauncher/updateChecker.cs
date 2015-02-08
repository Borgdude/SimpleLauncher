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
        string downloadUrl = "";
        public string newDownloadUrl = "";
        public Version curVersion = null;
        public Version newVersion = null;
        string xmlUrl = "http://borgdude.github.io/update.xml";

        public void checkLocalVersion()
        {
            XmlTextReader reader = new XmlTextReader("C:/Users/Borgdude/Documents/Visual Studio 2013/Projects/SimpleLauncher/SimpleLauncher/test.xml");
            reader.MoveToContent();
            string elementName = "";
            if ((reader.NodeType == XmlNodeType.Element) && reader.Name == "app")
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        elementName = reader.Name;
                    }
                    else
                    {
                        if ((reader.NodeType == XmlNodeType.Text) && (reader.HasValue))
                        {
                            switch (elementName)
                            {
                                case "version":
                                    curVersion = new Version(reader.Value);
                                    break;
                                case "url":
                                    downloadUrl = reader.Value;
                                    break;
                            }
                        }
                    }
                }
            }


        }
        public void checkUpdate()
        {
            XmlTextReader reader = new XmlTextReader(xmlUrl);
            reader.MoveToContent();
            string elementName = "";
            if ((reader.NodeType == XmlNodeType.Element) && reader.Name == "app")
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        elementName = reader.Name;
                    }
                    else
                    {
                        if ((reader.NodeType == XmlNodeType.Text) && (reader.HasValue))
                        {
                            switch (elementName)
                            {
                                case "version":
                                    newVersion = new Version(reader.Value);
                                    break;
                                case "url":
                                    newDownloadUrl = reader.Value;
                                    break;
                            }
                        }
                    }
                }
            }
        }

        
       
    }
}

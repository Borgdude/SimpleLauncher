using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

namespace SimpleLauncher
{
    class updateChecker
    {
        xmlController xmlC = new xmlController();
        string downloadUrl = "";
        public string newDownloadUrl = "";
        public Version curVersion = null;
        public Version newVersion = null;
        string newVerStr = "";
        string xmlUrl = "http://borgdude.github.io/update.xml";
        bool localXmlFile = false;

       
        //Checks XML file on server
        public void checkUpdate()
        {
           
                XmlTextReader reader = new XmlTextReader(xmlUrl);
                Console.WriteLine("Got online XML");
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
                                        newVerStr = reader.Value;
                                        Console.WriteLine("newVersion: " + newVersion);
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
        //Checks local xml file
        public void checkLocalVersion()
        {
            
                XmlTextReader reader = new XmlTextReader("test.xml");
                Console.WriteLine("Got local XML");
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
                                        Console.WriteLine("curVersion: " + curVersion);
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

        public void checkLocalXml()
        {
            if(File.Exists("test.xml"))
            {
                localXmlFile = true;
                checkLocalVersion();

            }
            else
            {
                localXmlFile = false;
                MessageBox.Show("XML File not found, created one", "XML File Not Found");
                checkUpdate();
                xmlC.createXml(newVerStr, newDownloadUrl);

            }
        }

        //Puts it all together for one simple function
        public void update() 
        {
            Console.WriteLine("Update Initialised");
            checkLocalXml();
            if (localXmlFile)
            {
                checkUpdate();
                if (curVersion.CompareTo(newVersion) < 0)
                {
                    DialogResult diagRes = MessageBox.Show("There's an update available, Would you like to update now?", "Update available", MessageBoxButtons.YesNo);
                    if (diagRes == DialogResult.Yes)
                    {
                        Process.Start(newDownloadUrl);
                        Console.WriteLine("Downloading...");
                    }
                    else if (diagRes == DialogResult.No)
                    {
                        //Application.Exit();
                    }
                }
                else
                {
                    MessageBox.Show("No update available", "Simple Launcher", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                    Console.WriteLine("App up to date");

                }
            }
            else
            {

            }

        }
        }

        
       
    }


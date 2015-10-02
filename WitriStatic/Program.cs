using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.IO;


namespace WitriStatic
{
    class Program
    {
        public static Dictionary<string, Data.Window> windowDictionary;
        public static Dictionary<string, Compositor> compositorDictionary;
        public static Dictionary<string, Layer> layerDictionary;

        static void Main(string[] args)
        {
           loadDictionaries();
        }
        public static void loadDictionaries()
        {
            string ciaFolderPath = getCiaFolderPath_fromProjectConfig();
            windowDictionary = getWindowDictionary(ciaFolderPath);
        }

        private static Dictionary<string, Window> getWindowDictionary(string ciaFolderPath)
        {
            //search for <window> elements in all the .xml files in 10_CIA folder
            foreach (var xmlFile in Directory.EnumerateFiles(ciaFolderPath))
            {
                XDocument xdoc = XDocument.Load(xmlFile);
                foreach (XElement window in xdoc.Descendants("Window"))
                {
                    string windowName = string.Empty;
                    if(window.Attribute("Name") != null){
                        windowName = window.Attribute("Name").Value;
                        //if the window dictionary doesn't contain the element, create a window object and add it to the dictionary
                        if (!windowDictionary.Keys.Contains(windowName))
                        {
                            //window.Descendants("Buflet").Select(e => e.Attribute("Name").Value).ToList();
                            Window tempWindow = new Window(windowName);
                        }
                    }
                }
            }
            return new Dictionary<string, Window>();
        }
        public static string getCiaFolderPath_fromProjectConfig()
        {
            string relativePath = @"..\..\..\pkg\xcmodel\mdl\ProjectConfig.xml";
            string fullPath = Path.GetFullPath(Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), relativePath));
            
            XElement pjConfig_xdoc = XElement.Load(relativePath);


            string tempCiaPath = @"..\..\brutus\adapt\model\10_CIA\";
            string tempfullPath = Path.GetFullPath(Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), tempCiaPath));
            return tempfullPath;
        }
        public static bool isDetached(string widgetName)
        {
            bool result = false;


            return result;
        }
        public static string getDetachedWidgetLayer(string widgetName)
        {
            string result = string.Empty;



            return result;
        }
        public static string getDetachedWidgetCompositor(string widgetName)
        {
            string result = string.Empty;

            return result;
        }
    }
    
}

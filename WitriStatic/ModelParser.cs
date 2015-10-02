using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.IO;

namespace WitriStatic
{
    public static class ModelParser
    {
        public static string brutusModelPath = @"d:\casdev\sw-frames\GC\213\EL\IC213GC_EL_Series_E009_4.V09.04.pre50_2\tool\brutus\adapt\model\";
        public static string widgetsFolderPath = @"d:\casdev\sw-frames\GC\213\EL\IC213GC_EL_Series_E009_4.V09.04.pre50_2\tool\brutus\adapt\model\60_Widgets\";
        public static string ciaFolderPath = @"d:\casdev\sw-frames\GC\213\EL\IC213GC_EL_Series_E009_4.V09.04.pre50_2\tool\brutus\adapt\model\10_CIA\";

        public static void loadXmlDataIntoModel(DataModel dataModel)
        {
            getWidgetDictionary(widgetsFolderPath, dataModel.widgetDict);
            fillAttachedProperties(ciaFolderPath, dataModel.widgetDict);
        }

        private static Dictionary<string, DataModel.Widget> getWidgetDictionary(string widgetsFolderPath, Dictionary<string, DataModel.Widget> widget_dict)
        {           
            //open each widget xml
            foreach (var file in Directory.EnumerateFiles(widgetsFolderPath, "*.xml"))
            {
                XDocument xdoc = XDocument.Load(file);

                //store every <Widget element
                foreach(XElement widget_xel in xdoc.Descendants("Widget"))
                {
                    //create a widget object and add it to the dictionary
                    if(widget_xel.Attribute("Name")!= null){
                        string widget_name = widget_xel.Attribute("Name").Value;
                        //check if the dictionary contains the widget before adding it : if it does, update the xelement
                        if (!widget_dict.Keys.Contains(widget_name)) {
                            DataModel.Widget tempWidget = new DataModel.Widget(widget_name, widget_xel);
                            widget_dict.Add(widget_name, tempWidget);
                        }
                        else
                        {
                            widget_dict[widget_name].xelem = widget_xel;
                        }
                    }
                }
            }

            return widget_dict;
        }
        private static List<string> fillAttachedProperties(string ciaFolderPath, Dictionary<string, DataModel.Widget> widget_dict)
        {
            List<string> detachedWidgets = new List<string>();
            //search through all the .xml files in the cia folder for <Window> elements that contain section names
            foreach(var file in Directory.EnumerateFiles(ciaFolderPath, "*.xml"))
            {
                XDocument xdoc = XDocument.Load(file);
                var windows = xdoc.Descendants("Window").Where(i => i.Descendants("Section").Count() > 0);
                if (windows.Count() > 0)
                {
                    //these windows contain detached widgets
                    foreach(var window_xel in windows) {
                        string windowName = window_xel.Attribute("Name").Value;

                        DataModel.Window tempWindow = new DataModel.Window(windowName, window_xel);

                        foreach (XElement buflet_xel in window_xel.Descendants("Buflet").Where(i => i.Elements("Section").Count() > 0))
                        {
                            string bufletName = buflet_xel.Attribute("Name").Value; 

                            DataModel.Buflet tempBuflet = new  DataModel.Buflet(bufletName, buflet_xel);

                            foreach(XElement section_xel in buflet_xel.Elements("Section"))
                            {
                                string sectionName = section_xel.Attribute("Name").Value;
                                string widgetName = sectionName.Replace("_Section", "");

                                DataModel.Section tempSection = new DataModel.Section(sectionName, section_xel);

                                if (widget_dict.Keys.Contains(widgetName))
                                {
                                    widget_dict[widgetName].isDetached = true;
                                    widget_dict[widgetName].addSection(tempSection);
                                    widget_dict[widgetName].addBuflet(tempBuflet);
                                    widget_dict[widgetName].addWindow(tempWindow);
                                }
                                else
                                {
                                    Console.Out.WriteLine("Error: " + widgetName + " was found as a section in file " + file.ToString() + " but is not found as a widget");
                                }
                            }
                        }
                    }
                }
            }

            return detachedWidgets;
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
        public static string getCiaFolderPath_fromProjectConfig()
        {
            string relativePath = @"..\..\..\pkg\xcmodel\mdl\ProjectConfig.xml";
            string fullPath = Path.GetFullPath(Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), relativePath));

            XElement pjConfig_xdoc = XElement.Load(relativePath);


            string tempCiaPath = @"..\..\brutus\adapt\model\10_CIA\";
            string tempfullPath = Path.GetFullPath(Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), tempCiaPath));
            return tempfullPath;
        }
    }
}

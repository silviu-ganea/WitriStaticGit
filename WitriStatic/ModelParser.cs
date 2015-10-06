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
            //get widget data into widget dictionary
            parseBrutusModel_Widgets(widgetsFolderPath, dataModel);
            parseBrutusModel_CIA(ciaFolderPath, dataModel);

            //get window data into window dictionary
            getWindowDictionary(ciaFolderPath, dataModel.windowDict);
        }

        private static void getWindowDictionary(string ciaFolderPath, Dictionary<string, DataModel.Window> windowDict)
        {
        }

        private static void parseBrutusModel_Widgets(string widgetsFolderPath, DataModel dataModel)
        {
            Dictionary<string, DataModel.Widget> widget_dict = dataModel.widgetDict;

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
                            //DataModel.Widget tempWidget = new DataModel.Widget(widget_name, widget_xel);
                            DataModel.Widget tempWidget = new DataModel.Widget(widget_name);
                            widget_dict.Add(widget_name, tempWidget);
                        }
                        else
                        {
                            //widget_dict[widget_name].xelem = widget_xel;
                        }
                    }
                }
            }
        }
        private static void parseBrutusModel_CIA(string ciaFolderPath, DataModel dataModel)
        {

            foreach(var file in Directory.EnumerateFiles(ciaFolderPath, "*.xml"))
            {
                XDocument xdoc = XDocument.Load(file);
                getWindowData(xdoc, dataModel);
                getSectionData(xdoc, dataModel);
                getCompositorData(xdoc, dataModel);

            }
        }
        public static void getWindowData(XDocument xdoc, DataModel dataModel)
        {
            Dictionary<string, DataModel.Widget> widget_dict = dataModel.widgetDict;
            Dictionary<string, DataModel.Window> window_dict = dataModel.windowDict;

            foreach (var window_xel in xdoc.Descendants("Window"))
            {
                string windowName = window_xel.Attribute("Name").Value;

                //add window to dictionary
                if (!window_dict.Keys.Contains(windowName))
                {
                    window_dict.Add(windowName, new DataModel.Window(windowName));
                }
                if(window_xel.Descendants("Painter").Count() > 0)
                {
                    string painterName = window_xel.Descendants("Painter").Where(i => i.Attribute("Name") != null).First().Attribute("Name").Value;
                    window_dict[windowName].Painter = painterName;
                }
                if (window_xel.Descendants("Thread").Count() > 0)
                {
                    string threadName = window_xel.Descendants("Thread").Where(i => i.Attribute("Name") != null).First().Attribute("Name").Value;
                    window_dict[windowName].Thread = threadName;
                }
                if (window_xel.Descendants("Section").Count() > 0)
                {
                    foreach (XElement buflet_xel in window_xel.Descendants("Buflet").Where(i => i.Elements("Section").Count() > 0))
                    {
                        string bufletName = buflet_xel.Attribute("Name").Value;
                        foreach (XElement section_xel in buflet_xel.Elements("Section"))
                        {
                            string sectionName = section_xel.Attribute("Name").Value;
                            string widgetName = sectionName.Replace("_Section", "");

                            //add widget to dictionary
                            if (widget_dict.Keys.Contains(widgetName))
                            {
                                dataModel.detachedWidgets.Add(widgetName);
                                widget_dict[widgetName].isDetached = true;
                                dataModel.detachedWidgets.Add(widgetName);
                                if (widget_dict[widgetName].Section != null || widget_dict[widgetName].Buflet != null || widget_dict[widgetName].Window != null)
                                {
                                    Console.WriteLine("Error: " + widgetName + " was found as a section twice and its properties were overwriten");
                                }
                                widget_dict[widgetName].Section = sectionName;
                                widget_dict[widgetName].Buflet = bufletName;
                                widget_dict[widgetName].Window = windowName;
                            }
                            else
                            {
                                Console.Out.WriteLine("Error: " + widgetName + " was found as a section but is not found as a widget");
                            }
                            
                            //add window data to dictionary
                            window_dict[windowName].Buflet = bufletName;
                            window_dict[windowName].Section = sectionName;
                        }
                    }
                }
            }
            
        }
        public static void getCompositorData(XDocument xdoc, DataModel dataModel)
        {
            Dictionary<string, DataModel.Widget> widget_dict = dataModel.widgetDict;
            Dictionary<string, DataModel.Window> window_dict = dataModel.windowDict;
            Dictionary<string, DataModel.Layer> layer_dict = dataModel.layerDict;
            Dictionary<string, DataModel.Section> section_dict = dataModel.sectionDict;

            //look for <Compositor> and <Layer> elements 
            var compositors = xdoc.Descendants("Compositor");
            foreach (var compositor_xel in compositors)
            {
                string compositor_name = string.Empty;
                string compositor_destinationBuflet = string.Empty;
                string layer_name = string.Empty;

                if (compositor_xel.Attribute("Name") != null)
                {
                    compositor_name = compositor_xel.Attribute("Name").Value;
                }
                if (compositor_xel.Attribute("DestinationBuflet") != null)
                {
                    compositor_destinationBuflet = compositor_xel.Attribute("DestinationBuflet").Value;
                }
                foreach (var layer_xel in compositor_xel.Descendants("Layer"))
                {
                    DataModel.Layer tempLayer;
                    if (layer_xel.Attribute("Name") != null)
                    {
                        layer_name = layer_xel.Attribute("Name").Value;
                        tempLayer = new DataModel.Layer(layer_name);
                        if (!layer_dict.ContainsKey(layer_name))
                        {
                            layer_dict.Add(layer_name, tempLayer);
                        }
                    }
                    if (layer_xel.Attribute("BufletSectionID") != null)
                    {
                        string bufletSectionID = layer_xel.Attribute("BufletSectionID").Value;
                        string temp_widgetName = bufletSectionID.Replace("_Section", "");

                        if (widget_dict.ContainsKey(temp_widgetName))
                        {
                            widget_dict[temp_widgetName].Compositor = compositor_name;
                            widget_dict[temp_widgetName].Layer = layer_name;
                        }
                        if (layer_dict.ContainsKey(layer_name))
                        {
                            layer_dict[layer_name].Compositor = compositor_name;
                            layer_dict[layer_name].Section = bufletSectionID;
                        }
                        if (section_dict.ContainsKey(bufletSectionID))
                        {
                            layer_dict[layer_name].Buflet = section_dict[bufletSectionID].Buflet;
                        }
                    }
                }
            }
        }
        public static void getSectionData(XDocument xdoc, DataModel dataModel)
        {
            Dictionary<string, DataModel.Section> section_dict = dataModel.sectionDict;

            var buflets = xdoc.Descendants("Buflet");
            foreach(var buflet_xel in buflets)
            {
                string buflet_name = string.Empty;
                if(buflet_xel.Attribute("Name") != null)
                {
                    buflet_name = buflet_xel.Attribute("Name").Value;
                }
                foreach(var section_xel in buflet_xel.Descendants("Section"))
                {
                    string section_name = string.Empty;
                    if(section_xel.Attribute("Name") != null)
                    {
                        section_name = section_xel.Attribute("Name").Value;
                        DataModel.Section tempSection = new DataModel.Section(section_name);
                        tempSection.Buflet = buflet_name;
                        if (!section_dict.ContainsKey(section_name))
                        {
                            section_dict.Add(section_name, tempSection);                            
                        }
                    }
                }

            }
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

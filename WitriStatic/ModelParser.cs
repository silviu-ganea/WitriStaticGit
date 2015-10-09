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
        public static string framePath = Path.GetFullPath(Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location), "..//..//..//"));
        public static string brutusModelPath = Path.GetFullPath(Path.Combine(framePath, @"tool\brutus\adapt\model\"));
        public static string widgetsFolderPath = Path.GetFullPath(Path.Combine(framePath, @"tool\brutus\adapt\model\60_Widgets\"));
        public static string ciaFolderPath = Path.GetFullPath(Path.Combine(framePath, @"tool\brutus\adapt\model\10_CIA\"));
        public static StringBuilder log = new StringBuilder();

        public static void loadXmlDataIntoModel(DataModel dataModel)
        {
            if (!Directory.Exists(framePath))
            {
                log.AppendLine("Error: path " + framePath + " doesn't exist.");
            }
            else if (!Directory.Exists(brutusModelPath))
            {
                log.AppendLine("Error: path " + brutusModelPath + " doesn't exist.");
            }
            else if(!Directory.Exists(widgetsFolderPath))
            {
                log.AppendLine("Error: path " + widgetsFolderPath + " doesn't exist.");
            }
            else if(!Directory.Exists(ciaFolderPath))
            {
                log.AppendLine("Error: path " + ciaFolderPath + " doesn't exist.");
            }
            else
            {
                try
                {
                    //get widget data into widget dictionary
                    parseBrutusModel_Widgets(widgetsFolderPath, dataModel);
                    parseBrutusModel_CIA(ciaFolderPath, dataModel);
                }
                catch (Exception e)
                {
                    log.AppendLine("Error parsing xml model: " + e.StackTrace + e.Message);
                }
                
            }
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
                    if (widget_xel.Attribute("Name") != null)
                    {
                        string widget_name = widget_xel.Attribute("Name").Value;
                        //check if the dictionary contains the widget before adding it : if it does, update the xelement
                        if (!widget_dict.Keys.Contains(widget_name))
                        {
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
                getBufletSectionData(xdoc, dataModel);
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
                                    //Console.WriteLine("Error: " + widgetName + " was found as a section twice and its properties were overwriten");
                                    log.AppendLine("Error: " + widgetName + " was found as a section twice and its properties were overwriten");
                                }
                                widget_dict[widgetName].Section = sectionName;
                                widget_dict[widgetName].Buflet = bufletName;
                                widget_dict[widgetName].Window = windowName;
                            }
                            else
                            {
                                //Console.Out.WriteLine("Error: " + widgetName + " was found as a section but is not found as a widget");
                                log.AppendLine("Error: " + widgetName + " was found as a section but is not found as a widget");
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
                string bufletSectionID = string.Empty;

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
                        bufletSectionID = layer_xel.Attribute("BufletSectionID").Value;
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
                    if(layer_xel.Attribute("BufletSectionID") != null && layer_name != string.Empty && compositor_name != string.Empty)
                    {
                        DataModel.CompositorLayerSection tempCompLayer = new DataModel.CompositorLayerSection();
                        string tempName = "CompositorLayer" + "_" + compositor_name + "_" + layer_name + "_" + layer_xel.Attribute("BufletSectionID").Value;
                        string tempShortName = layer_name + "_" + layer_xel.Attribute("BufletSectionID").Value;
                        tempCompLayer.Name = tempName;
                        tempCompLayer.ShortName = tempShortName;
                        tempCompLayer.Compositor = compositor_name;
                        tempCompLayer.Layer = layer_name;
                        tempCompLayer.Section = layer_xel.Attribute("BufletSectionID").Value;
                        dataModel.compositorLayerDict.Add(tempName, tempCompLayer);
                    }

                }
            }
        }
        public static void getBufletSectionData(XDocument xdoc, DataModel dataModel)
        {
            Dictionary<string, DataModel.Section> section_dict = dataModel.sectionDict;
            Dictionary<string, DataModel.Buflet> buflet_dict = dataModel.bufletDict;

            var buflets = xdoc.Descendants("Buflet");
            foreach(var buflet_xel in buflets)
            {
                //load all the buflet data
                string buflet_name = string.Empty;
                if(buflet_xel.Attribute("Name") != null)
                {
                    buflet_name = buflet_xel.Attribute("Name").Value;

                    DataModel.Buflet tempBuflet = new DataModel.Buflet(buflet_name);
                    string tempAttrVal = string.Empty;
                    if (buflet_xel.Attribute("Is3D") != null)
                    {
                        tempAttrVal = buflet_xel.Attribute("Is3D").Value;
                        tempBuflet.Is3D = tempAttrVal;
                    }
                    if (buflet_xel.Attribute("Surface") != null)
                    {
                        tempAttrVal = buflet_xel.Attribute("Surface").Value;
                        tempBuflet.Surface = tempAttrVal;
                    }
                    if (buflet_xel.Attribute("Policy") != null)
                    {
                        tempAttrVal = buflet_xel.Attribute("Policy").Value;
                        tempBuflet.Policy = tempAttrVal;
                    }
                    if (buflet_xel.Attribute("IsPreMultiplied") != null)
                    {
                        tempAttrVal = buflet_xel.Attribute("IsPreMultiplied").Value;
                        tempBuflet.IsPreMultiplied = tempAttrVal;
                    }
                    if (buflet_xel.Attribute("SyncCompAndPixelData") != null)
                    {
                        tempAttrVal = buflet_xel.Attribute("SyncCompAndPixelData").Value;
                        tempBuflet.SyncCompAndPixelData = tempAttrVal;
                    }
                    if (buflet_xel.Attribute("Background") != null)
                    {
                        tempAttrVal = buflet_xel.Attribute("Background").Value;
                        tempBuflet.Background = tempAttrVal;
                    }
                    if (!buflet_dict.ContainsKey(buflet_name))
                    {
                        buflet_dict.Add(buflet_name, tempBuflet);
                    }
                    else
                    {
                        buflet_dict[buflet_name] = mergeBuflets(buflet_dict[buflet_name], tempBuflet);
                    }
                    
                }
                foreach (var section_xel in buflet_xel.Descendants("Section"))
                {
                    //load all section attributes into the object
                    string section_name = string.Empty;
                    if(section_xel.Attribute("Name") != null)
                    {
                        section_name = section_xel.Attribute("Name").Value;
                        DataModel.Section tempSection = new DataModel.Section(section_name);
                        tempSection.Buflet = buflet_name;
                        string tempAttrVal = string.Empty;
                        if (section_xel.Attribute("Width") != null)
                        {
                            tempAttrVal = section_xel.Attribute("Width").Value;
                            tempSection.Width = tempAttrVal;
                        }
                        if (section_xel.Attribute("Height") != null)
                        {
                            tempAttrVal = section_xel.Attribute("Height").Value;
                            tempSection.Height = tempAttrVal;
                        }
                        if (section_xel.Attribute("PosX") != null)
                        {
                            tempAttrVal = section_xel.Attribute("PosX").Value;
                            tempSection.PosX = tempAttrVal;
                        }
                        if (section_xel.Attribute("PosY") != null)
                        {
                            tempAttrVal = section_xel.Attribute("PosY").Value;
                            tempSection.PosY = tempAttrVal;
                        }
                        if (section_xel.Attribute("Background") != null)
                        {
                            tempAttrVal = section_xel.Attribute("Background").Value;
                            tempSection.Background = tempAttrVal;
                        }
                        if (!section_dict.ContainsKey(section_name))
                        {
                            section_dict.Add(section_name, tempSection);
                            if(buflet_dict.ContainsKey(buflet_name) && !buflet_dict[buflet_name].Sections.Contains(section_name))
                            {
                                buflet_dict[buflet_name].Sections.Add(section_name);
                            }
                        }
                    }
                    
                }

            }
        }
        public static DataModel.Buflet mergeBuflets(DataModel.Buflet buflet1, DataModel.Buflet buflet2)
        {
            DataModel.Buflet mergedBuflet = new DataModel.Buflet(buflet1.Name);
            if(buflet1 != null && buflet2 != null)
            {
                if(buflet1.ID != null)
                {
                    mergedBuflet.ID = buflet1.ID;
                }
                else
                {
                    mergedBuflet.ID = buflet2.ID;
                }

                if (buflet1.Background != null)
                {
                    mergedBuflet.Background = buflet1.Background;
                }
                else
                {
                    mergedBuflet.Background = buflet2.Background;
                }

                if (buflet1.Is3D != null)
                {
                    mergedBuflet.Is3D = buflet1.Is3D;
                }
                else
                {
                    mergedBuflet.Is3D = buflet2.Is3D;
                }

                if (buflet1.IsPreMultiplied != null)
                {
                    mergedBuflet.IsPreMultiplied = buflet1.IsPreMultiplied;
                }
                else
                {
                    mergedBuflet.IsPreMultiplied = buflet2.IsPreMultiplied;
                }

                if (buflet1.Policy != null)
                {
                    mergedBuflet.Policy = buflet1.Policy;
                }
                else
                {
                    mergedBuflet.Policy = buflet2.Policy;
                }

                if (buflet1.Surface != null)
                {
                    mergedBuflet.Surface = buflet1.Surface;
                }
                else
                {
                    mergedBuflet.Surface = buflet2.Surface;
                }

                if (buflet1.SyncCompAndPixelData != null)
                {
                    mergedBuflet.SyncCompAndPixelData = buflet1.SyncCompAndPixelData;
                }
                else
                {
                    mergedBuflet.SyncCompAndPixelData = buflet2.SyncCompAndPixelData;
                }
                foreach(string section in buflet1.Sections)
                {
                    if (!mergedBuflet.Sections.Contains(section))
                    {
                        mergedBuflet.Sections.Add(section);
                    }
                }
                foreach (string section in buflet2.Sections)
                {
                    if (!mergedBuflet.Sections.Contains(section))
                    {
                        mergedBuflet.Sections.Add(section);
                    }
                }
            }

            return mergedBuflet;
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

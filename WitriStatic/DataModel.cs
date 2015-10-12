using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.IO;

namespace WitriStatic
{
    public class DataModel
    {
        public Dictionary<string, Window> windowDict;
        public Dictionary<string, Widget> widgetDict;
        public Dictionary<string, Layer> layerDict;
        public Dictionary<string, Section> sectionDict;
        public Dictionary<string, Buflet> bufletDict;
        public Dictionary<string, Message> messageDict;
        public Dictionary<string, StateMachine> stateMachineDict;
        public Dictionary<string, CompositorLayerSection> compositorLayerDict;
        public List<string> detachedWidgets;

        public Dictionary<string, string> windowNameIdDict;
        public Dictionary<string, string> widgetNameIdDict;
        public Dictionary<string, string> layerNameIdDict;
        public Dictionary<string, string> sectionNameIdDict;
        public Dictionary<string, string> bufletNameIdDict;
        public Dictionary<string, string> messageNameIdDict;
        public Dictionary<string, string> stateMachineNameIdDict;
        public Dictionary<string, string> compositorLayerNameIdDict;

        public DataModel()
        {
            this.windowDict = new Dictionary<string, Window>();
            this.widgetDict = new Dictionary<string, Widget>();
            this.layerDict = new Dictionary<string, Layer>();
            this.sectionDict = new Dictionary<string, Section>();
            this.bufletDict = new Dictionary<string, Buflet>();
            this.messageDict = new Dictionary<string, Message>();
            this.stateMachineDict = new Dictionary<string, StateMachine>();
            this.compositorLayerDict = new Dictionary<string, CompositorLayerSection>();

            this.windowNameIdDict = new Dictionary<string, string>();
            this.widgetNameIdDict = new Dictionary<string, string>();
            this.layerNameIdDict = new Dictionary<string, string>();
            this.sectionNameIdDict = new Dictionary<string, string>();
            this.bufletNameIdDict = new Dictionary<string, string>();
            this.messageNameIdDict = new Dictionary<string, string>();
            this.stateMachineNameIdDict = new Dictionary<string, string>();
            this.compositorLayerNameIdDict = new Dictionary<string, string>();

            this.detachedWidgets = new List<string>();
        }
        public class Widget
        {
            public string Name { get; set; }
            public string FullName { get; set; }
            public string ID { get; set; }
            public bool isDetached { get; set; }
            public string Section { get; set; }
            public string Buflet { get; set; }
            public string Window { get; set; }
            public string Layer { get; set; }
            public string Compositor { get; set; }
            public XElement xelem { get; set; }

            public Widget(string name)
            {
                this.Name = name;
                this.ID = string.Empty;
            }
            public Widget(string name, XElement xelem) : this(name)
            {
                this.xelem = xelem;
            }
        }
        public class Buflet
        {
            public string Name { get; set; }
            public string FullName { get; set; }
            public string ID { get; set; }
            public string Is3D { get; set; }
            public string Surface { get; set; }
            public string Policy { get; set; }
            public string IsPreMultiplied { get; set; }
            public string SyncCompAndPixelData { get; set; }
            public string Background { get; set; }

            public Buflet(string name)
            {
                this.Name = name;
                this.ID = string.Empty;
                this.Sections = new List<string>();
            }
            public List<string> Sections;
        }
        public class Section
        {
            public string Name { get; set; }
            public string ID { get; set; }
            public string Width { get; set; }
            public string Height { get; set; }
            public string PosX { get; set; }
            public string PosY { get; set; }
            public string Background { get; set; }
            public string Buflet { get; set; }
            public Section(string name)
            {
                this.Name = name;
                this.ID = string.Empty;
            }

        }
        public class Window
        {
            public string Name { get; set; }
            public string FullName { get; set; }
            public string ID { get; set; }
            public string Painter { get; set; }
            public string Buflet { get; set; }
            public string Section { get; set; }
            public string Thread { get; set; }
            public Window(string name)
            {
                this.Name = name;
                this.ID = string.Empty;
            }
        }
        public class Compositor
        {
            public string Name { get; set; }
            public string ID { get; set; }
            public Compositor(string name)
            {
                this.Name = name;
                this.ID = string.Empty;
            }
            Dictionary<string, Layer> layers;
        }
        public class Layer
        {
            public string Name { get; set; }        
            public string FullName { get; set; }
            public string ID { get; set; }
            public string Buflet { get; set; }
            public string Section { get; set; }
            public string Compositor { get; set; }
            public Layer(string name)
            {
                this.Name = name;
                this.ID = string.Empty;
            }
        }
        public class CompositorLayerSection
        {
            public string Name { get; set; }
            public string ShortName { get; set; }
            public string ID { get; set; }
            public string Compositor { get; set; }
            public string Layer { get; set; }
            public string Section { get; set; }
            public CompositorLayerSection()
            {
                this.ID = string.Empty;
            }
            public CompositorLayerSection(string name)
            {
                this.Name = name;
            }
        }
        public class Message
        {
            public string Name { get; set; }
            public string ID { get; set; }
            public Message(string Name, string ID)
            {
                this.Name = Name;
                this.ID = ID;
            }
        }
        public class StateMachine
        {
            public string Name { get; set; }
            public string ID { get; set; }
            public string FullName { get; internal set; }

            public Dictionary<string, string> states;
            public StateMachine(string name)
            {
                this.Name = name;
                this.ID = string.Empty;
                states = new Dictionary<string, string>();
            }
        }

        public void mapWidgetNameID()
        {
            foreach(Window window in windowDict.Values)
            {
                string windowNameID = window.Name;
                if(window.ID != null)
                {
                    windowNameID += " - (" + window.ID + ")";
                }

                windowNameIdDict.Add(window.Name, windowNameID);
            }
            foreach (Widget widget in widgetDict.Values)
            {
                string widgetNameID = widget.Name;
                if (widget.ID != null)
                {
                    widgetNameID += " - (" + widget.ID + ")";
                }
                if (widget.isDetached)
                {
                    widgetNameID += " - (detached)";
                }
                widgetNameIdDict.Add(widget.Name, widgetNameID);
            }
            foreach (Layer layer in layerDict.Values)
            {
                string layerNameID = layer.Name;
                if (layer.ID != null)
                {
                    layerNameID += " - (" + layer.ID + ")";
                }

                layerNameIdDict.Add(layer.Name, layerNameID);
            }
            foreach (Section section in sectionDict.Values)
            {
                string sectionNameID = section.Name;
                if (section.ID != null)
                {
                    sectionNameID += " - (" + section.ID + ")";
                }

                sectionNameIdDict.Add(section.Name, sectionNameID);
            }
            foreach (Buflet buflet in bufletDict.Values)
            {
                string bufletNameID = buflet.Name;
                if (buflet.ID != null)
                {
                    bufletNameID += " - (" + buflet.ID + ")";
                }

                bufletNameIdDict.Add(buflet.Name, bufletNameID);
            }
            foreach (Message message in messageDict.Values)
            {
                string messageNameID = message.Name;
                if (message.ID != null)
                {
                    messageNameID += " - (" + message.ID + ")";
                }

                messageNameIdDict.Add(message.Name, messageNameID);
            }

            foreach (StateMachine stateMachine in stateMachineDict.Values)
            {
                string stateMachineNameID = stateMachine.Name;
                if (stateMachine.ID != null)
                {
                    stateMachineNameID += " - (" + stateMachine.ID + ")";
                }

                stateMachineNameIdDict.Add(stateMachine.Name, stateMachineNameID);
            }

            foreach (CompositorLayerSection cls in compositorLayerDict.Values)
            {
                string compositorLayerSectionNameID = cls.Name;
                if (cls.ID != null)
                {
                    compositorLayerSectionNameID += " - (" + cls.ID + ")";
                }

                compositorLayerNameIdDict.Add(cls.Name, compositorLayerSectionNameID);
            }
        }
    }
}

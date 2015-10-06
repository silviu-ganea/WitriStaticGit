using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace WitriStatic
{
    public class DataModel
    {
        public Dictionary<string, Window> windowDict;
        public Dictionary<string, Widget> widgetDict;
        public Dictionary<string, Layer> layerDict;
        public Dictionary<string, Section> sectionDict;
        public Dictionary<string, Buflet> bufletDict;
        public List<string> detachedWidgets;

        public DataModel(){
            this.windowDict = new Dictionary<string, Window>();
            this.widgetDict = new Dictionary<string, Widget>();
            this.layerDict = new Dictionary<string, Layer>();
            this.sectionDict = new Dictionary<string, Section>();
            this.bufletDict = new Dictionary<string, Buflet>();
            this.detachedWidgets = new List<string>();
    }
        public class Widget
        {
            public string Name { get; set; }
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
            }
            public Widget(string name, XElement xelem) : this(name)
            {
                this.xelem = xelem;
            }    
        }
        public class Buflet
        {
            public string Name { get; set; }
            public string ID { get; set; }
            public string Is3D { get; set; }
            public string Surface { get; set; }
            public string Policy { get; set; }
            public string IsPreMultiplied { get; set; }
            public string SyncCompAndPixelData { get; set; }
            public string Background { get; set; }

            public Buflet(string name) { 
                this.Name = name;
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
            }

        }
        public class Window
        {
            public string Name { get; set; }
            public string ID { get; set; }
            public string Painter { get; set; }
            public string Buflet { get; set; }
            public string Section { get; set; }
            public string Thread { get; set; }
            public Window(string name)
            {
                this.Name = name;
            }
        }
        public class Compositor
        {
            public string Name { get; set; }
            public string ID { get; set; }
            public Compositor(string name) 
            {
                this.Name = name;
            }
            Dictionary<string, Layer> layers;
        }
        public class Layer 
        {
            public string Name { get; set; }
            public string ID { get; set; }
            public string Buflet { get; set; }
            public string Section { get; set; }
            public string Compositor { get; set; }
            public Layer(string name)
            {
                this.Name = name;
            }          
        }   
    }
}

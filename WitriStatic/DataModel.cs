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
        public Dictionary<string, Compositor> compositorDict;
        public Dictionary<string, Layer> layerDict;
        public Dictionary<string, Section> sectionDict;
        public List<string> detachedWidgets;

        public DataModel(){
            this.windowDict = new Dictionary<string, Window>();
            this.widgetDict = new Dictionary<string, Widget>();
            this.compositorDict = new Dictionary<string, Compositor>();
            this.layerDict = new Dictionary<string, Layer>();
            this.sectionDict = new Dictionary<string, Section>();
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
        public class Buflet : Widget
        {
            public Buflet(string name) : base(name)
            {
            }
            public Buflet(string name, XElement xelem) : base(name)
            {
            }
            Dictionary<string, Section> sections;
        }
        public class Section
        {
            public string Name { get; set; }
            public string ID { get; set; }
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
        public class Compositor : Widget
        {
            public Compositor(string name) : base(name)
            {
            }
            public Compositor(string name, XElement xelem) : base(name)
            {
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

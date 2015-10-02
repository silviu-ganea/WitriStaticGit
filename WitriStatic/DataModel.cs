using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace WitriStatic
{
    public class DataModel
    {
        public static Dictionary<string, Window> windowDict;
        public static Dictionary<string, Widget> widgetDict;
        public static Dictionary<string, Compositor> compositorDict;
        public static Dictionary<string, Layer> layerDict;
        
        public class Widget
        {
            public string Name { get; set; }
            public string ID { get; set; }
            public XElement xelem { get; set; }

            public Widget(string name)
            {
                this.Name = name;
            }
            public Widget(string name, XElement xelem)
            {
                this.Name = name;
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
        public class Section : Widget
        {
            public Section(string name) : base(name)
            {
            }
            public Section(string name, XElement xelem) : base(name)
            {
            }
        }
        public class Window : Widget
        {
            public Window(string name) : base(name)
            {
            }
            public Window(string name, XElement xelem) : base(name)
            {
            }
            Dictionary<string, Buflet> buflets;
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
        public class Layer : Widget
        {
            public Layer(string name) : base(name)
            {
            }
            public Layer(string name, XElement xelem) : base(name)
            {
            }
            Dictionary<string, Section> sections;
        }   
    }
}

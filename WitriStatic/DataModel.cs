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
        
        public DataModel(){
            this.windowDict = new Dictionary<string, Window>();
            this.widgetDict = new Dictionary<string, Widget>();
            this.compositorDict = new Dictionary<string, Compositor>();
            this.layerDict = new Dictionary<string, Layer>();
    }
        public class Widget
        {
            public string Name { get; set; }
            public string ID { get; set; }
            public bool isDetached { get; set; }
            public XElement xelem { get; set; }
            List<Section> sections;
            List<Buflet> buflets;
            //List<Painter> painters;
            List<Layer> layers;
            List<Window> windows;

            public Widget()
            {
                sections = new  List<Section>();
                buflets = new List<Buflet>();
                //painters = new List<Section>();
                layers = new List<Layer>();
                windows = new List<Window>();
            }
            public Widget(string name) : this()
            {
                this.Name = name;
            }
            public Widget(string name, XElement xelem) : this(name)
            {
                this.xelem = xelem;
            }    
            internal void addSection(Section tempSection)
            {
                if (!sections.Contains(tempSection)) {
                    sections.Add(tempSection);
                }
            }
            internal void addBuflet(Buflet tempBuflet)
            {
                if (!buflets.Contains(tempBuflet))
                {
                    buflets.Add(tempBuflet);
                }
            }
            internal void addWindow(Window tempWindow)
            {
                if (!windows.Contains(tempWindow))
                {
                    windows.Add(tempWindow);
                }
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
            Buflet buflet;
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

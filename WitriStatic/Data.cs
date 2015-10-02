using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace WitriStatic
{
    class Data
    {
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
        class Buflet : Widget
        {
            public Buflet(string name) : base(name)
            {
            }
            Dictionary<string, Section> sections;
        }
        class Section : Widget
        {
        }

        public class Window : Widget
        {
            public void addBuflet(XElement bufletElement)
            {
                if (bufletElement.Attribute("Name") != null)
                {
                    string bufletName = bufletElement.Attribute("Name").Value;
                    if (!this.buflets.Keys.Contains(bufletName))
                    {
                        Buflet tempBuflet = new Buflet();
                    }
                }

            }

            Dictionary<string, Buflet> buflets;
        }
        class Compositor : Widget
        {
            Dictionary<string, Layer> layers;
        }
        class Layer : Widget
        {
            Dictionary<string, Section> sections;
        }
    }
}

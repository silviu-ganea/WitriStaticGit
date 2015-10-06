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
        static void Main(string[] args)
        {

            DataModel dataModel = new DataModel();
            ModelParser.loadXmlDataIntoModel(dataModel);
            HppParser.loadWidgetsIDs(dataModel.widgetDict);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.IO;
using System.Windows.Forms;


namespace WitriStatic
{
    class Program
    {
        static void Main(string[] args)
        {
            //DataModel dataModel = new DataModel();

            //ModelParser.loadXmlDataIntoModel(dataModel);
            //HppParser.loadHppDataIntoModel(dataModel);

            //#region logger
            //StringBuilder logger = new StringBuilder();
            //logger.Append(ModelParser.log);
            //logger.Append(HppParser.log);
            //File.WriteAllText("log.txt", logger.ToString());
            //#endregion

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new UserInterface());
        }
    }
}

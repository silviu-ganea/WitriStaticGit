using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WitriStatic
{
    class HppParser
    {
        static string filePath = @"d:\casdev\sw-frames\GC\213\EL\IC213GC_EL_Series_E009_4.V09.04.pre50_2\adapt\gen\brutus\WRS_VisualResourceIDs.hpp";

        public static void loadWidgetsIDs(Dictionary<string, DataModel.Widget> d)
        {
            FileInfo fi = new FileInfo(filePath);
            StreamReader reader = fi.OpenText();
            string line = reader.ReadLine();
            int index = -1;
            while (index < 0)
            {
                // get the index where string WidgetIDs is found..
                index = line.IndexOf("WidgetIDs");
                line = reader.ReadLine();
            }
            line = reader.ReadLine();

            //now we are at the line where the widgets are starting to be enumarated
            while (line.Contains("Widget_IC_Root"))
            {
                string wName = line.Split('=')[0];
                wName = wName.Trim();
                wName = wName.Replace("Widget_IC_Root_", "");
                string wId = line.Split('=')[1].Split(',')[0];
                wId = wId.Trim();

                if (d.Keys.Contains(wName))
                {
                    d[wName].ID = wId;
                }
                else
                {
                    Console.Out.WriteLine("Warning: Widget ID " + wId + " " + wName + " Found , but not loaded");
                }



                // Console.WriteLine(wName + " - "+wId);

                line = reader.ReadLine();
            }
            line = reader.ReadLine();

            while (!line.Contains("NumberOfWidgets"))
            {
                string wName = line.Split('=')[0];
                char[] charsToTrim = { ' ', '\t' };
                wName = wName.Trim();
                wName = wName.Replace("Widget_HUD_Root_", "");
                string wId = line.Split('=')[1].Split(',')[0];
                wId = wId.Trim();
                //Console.WriteLine(wName + " - " + wId);

                if (d.Keys.Contains(wName))
                {
                    d[wName].ID = wId;
                }
                else
                {
                    Console.Out.WriteLine("Warning: Widget ID " + wId + " " + wName + " Found , but not loaded");
                }

                line = reader.ReadLine();
            }
        }
    }
}

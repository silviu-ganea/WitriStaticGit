﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace WitriStatic
{
    class HppParser
    {
        public static string framePath = Path.GetFullPath(Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location), "..//..//..//"));
        //public static string framePath = @"D:\casdev\FRAMES\213_EL_E009.4_pre40 - TARGET";
        public static string adaptBrutusPath = Path.GetFullPath(Path.Combine(framePath, @"adapt\gen\brutus\"));
        static string filePath = Path.GetFullPath(Path.Combine(framePath, @"adapt\gen\brutus\WRS_VisualResourceIDs.hpp"));
        static string filePathWidget = Path.GetFullPath(Path.Combine(framePath, @"adapt\gen\brutus\WRS_VisualResourceIDs.hpp"));
        static string filePathBuflet = Path.GetFullPath(Path.Combine(framePath, @"adapt\gen\brutus\WRS_CIAResourceIDs.hpp"));
        public static StringBuilder log = new StringBuilder();

        internal static void loadHppDataIntoModel(DataModel dataModel)
        {
            if (!Directory.Exists(framePath))
            {
                log.AppendLine("Error: path " + framePath + " doesn't exist.");
            }
            else if (!File.Exists(filePath))
            {
                log.AppendLine("Error: path " + filePath + " doesn't exist.");
            }
            else if (!File.Exists(filePathWidget))
            {
                log.AppendLine("Error: path " + filePathWidget + " doesn't exist.");
            }
            else if (!File.Exists(filePathBuflet))
            {
                log.AppendLine("Error: path " + filePathBuflet + " doesn't exist.");
            }
            else
            {
                try
                {
                    loadWidgetsIDs(dataModel.widgetDict);
                    loadDifferentData(dataModel);
                    loadMessagesData(dataModel);
                    loadStateMachineData(dataModel);
                }
                catch (Exception e)
                {
                    log.AppendLine("Error when parsing .hpp files " + e.StackTrace + e.Message);
                }
            }
        }

        public static void loadWidgetsIDs(Dictionary<string, DataModel.Widget> d)
        {
            FileInfo fi = new FileInfo(filePathWidget);
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
                string wNameFull = line.Split('=')[0];
                wNameFull = wNameFull.Trim();
                string wName = wNameFull.Replace("Widget_IC_Root_", "");
                string wId = line.Split('=')[1].Split(',')[0];
                wId = wId.Trim();

                if (d.Keys.Contains(wName))
                {
                    d[wName].ID = wId;
                    d[wName].FullName = wNameFull;
                }
                else
                {
                    //Console.Out.WriteLine("Warning: Widget ID " + wId + " " + wName + " Found , but not loaded");
                    log.AppendLine("Warning: Widget ID " + wId + " " + wName + " Found , but not loaded");
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
                    //Console.Out.WriteLine("Warning: Widget ID " + wId + " " + wName + " Found , but not loaded");
                    log.AppendLine("Warning: Widget ID " + wId + " " + wName + " Found , but not loaded");
                }
                line = reader.ReadLine();
            }
        }
        public static void loadDifferentData(DataModel dM)
        {
            FileInfo fi = new FileInfo(filePathBuflet);
            StreamReader reader = fi.OpenText();
            string line = reader.ReadLine();

            //insert buflets IDs
            while (!line.Contains("BufletIDs"))
            {
                line = reader.ReadLine();
            }
            line = reader.ReadLine();
            int i = 0;//counter that counts how many time 'line' contains' NumberOfLayerBuflets'

            //now we are at the line where the buflets IDs are stored
            while (i < 2)
            {
                if (line.Contains("NumberOfBuflets") || line.Contains("NumberOfLayerBuflets"))
                {
                    i++;
                    line = reader.ReadLine();
                }
                else
                {
                    if (line.Contains("="))
                    {
                        string bName = line.Split('=')[0].Trim();
                        string bId = line.Split('=')[1].Split(',')[0].Trim();
                        string bFullName = line.Split('=')[0].Trim();
                        bName = bName.Replace("Buflet_", "");
                        if (dM.bufletDict.Keys.Contains(bName))
                        {
                            dM.bufletDict[bName].ID = bId;
                            dM.bufletDict[bName].FullName = bFullName;
                            //Console.WriteLine("Buflet : " + bName + " - " + bId);
                        }
                        line = reader.ReadLine();
                    }
                }
            }

            //insert Windows IDs
            while (!line.Contains("WindowIDs"))
            {
                line = reader.ReadLine();
            }
            line = reader.ReadLine();
            //now we are at the line where the Windows IDs are stored
            while (!line.Contains("LastConfiguredWindowsID"))
            {
                if (!line.Contains("//"))
                {
                    string wName = line.Split('=')[0].Trim();
                    string wId = line.Split('=')[1].Split(',')[0].Trim();
                    string wFullName = line.Split('=')[0].Trim();
                    wName = wName.Replace("Window_", "");
                    if (dM.windowDict.Keys.Contains(wName))
                    {
                        dM.windowDict[wName].ID = wId;
                        dM.windowDict[wName].FullName = wFullName;
                        //Console.WriteLine("Window : "+wName+" - "+wId);
                        //log.AppendLine("Window : " + wName + " - " + wId); ;
                    }
                    line = reader.ReadLine();
                }
                else line = reader.ReadLine();
            }

            //insert CompositorIDs
            while (!line.Contains("CompositorIDs"))
            {
                line = reader.ReadLine();
            }
            line = reader.ReadLine();
            //now we are at the line where CompositorIDs are stored
            while (!line.Contains("NumberOfCompositors"))
            {
                string fullName = line.Split('=')[0].Trim();
                string shortName = fullName.Replace("Compositor_", "");
                string id = line.Split('=')[1].Split(',')[0].Trim();
                DataModel.Compositor c = new DataModel.Compositor(shortName);
                c.ID = id;
                c.FullName = fullName;
                dM.compositorDict.Add(shortName, c);
                line = reader.ReadLine();
            }


            //insert CompositorLayerIDs
            while (!line.Contains("CompositorLayerIDs"))
            {
                line = reader.ReadLine();
            }
            line = reader.ReadLine();
            //now we are at the line where the CompositorLayerIDs are stored
            while (!line.Contains("NumberOfCompositorLayers"))
            {
                string lName = line.Split('=')[0].Trim();
                string lID = line.Split('=')[1].Split(',')[0].Trim();
                //lName = lName.Replace("CompositorLayer_", "");
                if (dM.compositorLayerDict.Keys.Contains(lName))
                {
                    dM.compositorLayerDict[lName].ID = lID;
                    //log.AppendLine("Window : " + lName + " - " + lID);
                }
                line = reader.ReadLine();
            }

        }//end of loadDifferentData

        public static void loadStateMachineData(DataModel dataModel)
        {
            string path1 = Path.GetFullPath(Path.Combine(framePath, @"adapt\gen\brutus\WRS_StateMachineResourceIDs.hpp"));

            if (File.Exists(path1))
            {
                FileInfo fi = new FileInfo(path1);
                StreamReader reader = fi.OpenText();
                string line = reader.ReadLine();
                //find out where the line with stateMachines IDs begin
                while (!line.Contains("StateMachineIDs"))
                {
                    line = reader.ReadLine();
                }
                line = reader.ReadLine();

                while (!line.Contains("NumberOfStateMachines"))
                {
                    string stateName = line.Split('=')[0].Trim();
                    string stateFullName = stateName;
                    stateName = stateName.Replace("STATE_MACHINE_", "");
                    string stateID = line.Split('=')[1].Split(',')[0].Trim();
                    DataModel.StateMachine s = new DataModel.StateMachine(stateName);
                    s.ID = stateID;
                    s.Name = stateName;
                    s.FullName = stateFullName;
                    dataModel.stateMachineDict.Add(stateName, s);
                    line = reader.ReadLine();
                }

                //now we have to introduce the states for every state machine
                while (!line.Contains("StateMachineStateIDs"))
                {
                    line = reader.ReadLine();
                }

                while (!line.Contains("NumberOfStates"))
                {
                    if (line.Contains("="))
                    {
                        string stateName = line.Split('=')[0].Trim();
                        stateName = stateName.Replace("STATE_", "");
                        string stateID = line.Split('=')[1].Split(',')[0].Trim();

                        foreach (var d in dataModel.stateMachineDict)
                        {
                            if (stateName.Contains(d.Key))
                            {
                                d.Value.states.Add(stateName, stateID);
                            }
                        }
                        line = reader.ReadLine();
                    }
                    else
                    {
                        line = reader.ReadLine();
                    }
                }
            }
        }

        public static void loadMessagesData(DataModel dataModel)
        {
            string path1 = Path.GetFullPath(Path.Combine(framePath, @"adapt\gen\brutus\WRS_CEnumerations.h"));
            string path2 = Path.GetFullPath(Path.Combine(framePath, @"adapt\gen\brutus\WRS_ExternalEventDefinitions.h"));
            Dictionary<string, DataModel.Message> message_dict = dataModel.messageDict;

            if (File.Exists(path1))
            {
                bool read = false;
                foreach (string line in File.ReadLines(path1))
                {
                    if (line.Contains("enum enFrameworkMessageID"))
                    {
                        read = true;
                        continue;
                    }
                    else if (read && line.Contains("}"))
                    {
                        break;
                    }
                    if (read)
                    {
                        string trimLine = line.Trim();
                        var match = Regex.Matches(trimLine, @"([\w]+)(?:[\s]+=[\s])([\d]+)")[0];
                        string messageName = match.Groups[1].Value;
                        string messageID = match.Groups[2].Value;
                        DataModel.Message message = new DataModel.Message(messageName, messageID);
                        if (!message_dict.ContainsKey(messageName))
                        {
                            message_dict.Add(messageName, message);
                        }
                    }
                }
            }
            if (File.Exists(path2))
            {
                bool read = false;
                foreach (string line in File.ReadLines(path2))
                {
                    if (line.Contains("enum WRS_ExternalEvents"))
                    {
                        read = true;
                        continue;
                    }
                    else if (read && line.Contains("}"))
                    {
                        break;
                    }
                    if (read)
                    {
                        string trimLine = line.Trim();
                        var match = Regex.Matches(trimLine, @"([\w]+)(?:[\s]+=[\s])([\d]+)")[0];
                        string messageName = match.Groups[1].Value;
                        string messageID = match.Groups[2].Value;
                        DataModel.Message message = new DataModel.Message(messageName, messageID);
                        if (!message_dict.ContainsKey(messageName))
                        {
                            message_dict.Add(messageName, message);
                        }
                    }
                }
            }

        }
    }
}

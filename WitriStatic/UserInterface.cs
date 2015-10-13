using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WitriStatic
{
    public partial class UserInterface : Form
    {
        DataModel dataModel = new DataModel();
        public static bool ascendingSort = true;
        public static bool ascendingSort_detach = true;
        public UserInterface()
        {
            ModelParser.loadXmlDataIntoModel(dataModel);
            HppParser.loadHppDataIntoModel(dataModel);
            dataModel.mapWidgetNameID();
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void radioButtons_CheckedChanged(object sender, EventArgs e)
        {
            this.listView1.ListViewItemSorter = null;
            if (listView1.Columns.Count > 3)
            {
                listView1.Columns[3].Dispose();
            }
            if (textBox1.Text.Trim() == string.Empty)
            {
                listView1.Items.Clear();
                listView1.BeginUpdate();

                if (radioButton_Widget.Checked)
                {
                    radioButton_Widget_func();
                }
                else if (radioButton_Message.Checked)
                {
                    radioButton_Message_func();
                }
                else if (radioButton_CompositorLayer.Checked)
                {
                    radioButton_Layer_func();
                }
                else if (radioButton_Buflet.Checked)
                {
                    radioButton_Buflet_func();
                }
                else if (radioButton_Window.Checked)
                {
                    radioButton_Window_func();
                }
                else if (radioButton_StateMachine.Checked)
                {
                    radioButton_StateMachine_func();
                }
                else if (radioButton_Animation.Checked)
                {
                    radioButton_Animation_func();
                }

                selectFirstItemAndResize(listView1, listView2);

                listView1.EndUpdate();
            }
            else
            {
                textBox1_TextChanged(this, new EventArgs());
            }
        }
        private void radioButton_Widget_func()
        {
            listView1.BeginUpdate();
            if (listView1.Columns.Count < 4)
            {
                listView1.Columns.Add("isDetached", 70, HorizontalAlignment.Center);
            }
            foreach (var widgetNameId_kvp in dataModel.widgetNameIdDict)
            {
                ListViewItem lvi = new ListViewItem(new string[] { "", dataModel.widgetDict[widgetNameId_kvp.Key].ID, widgetNameId_kvp.Key, " " });
                if (dataModel.widgetDict[widgetNameId_kvp.Key].isDetached)
                {
                    lvi.SubItems[3].Text = "detached";
                    //lvi.ForeColor = Color.DarkGreen;
                }

                listView1.Items.Add(lvi);

            }
            listView1.EndUpdate();
        }
        private void radioButton_Message_func()
        {
            listView1.BeginUpdate();
            foreach (var messageNameId_kvp in dataModel.messageNameIdDict)
            {
                ListViewItem lvi = new ListViewItem(new string[] { "", dataModel.messageDict[messageNameId_kvp.Key].ID, messageNameId_kvp.Key });
                listView1.Items.Add(lvi);
            }
            listView1.EndUpdate();
        }
        private void radioButton_Layer_func()
        {
            foreach (var clsNameId_kvp in dataModel.compositorLayerNameIdDict)
            {
                ListViewItem lvi = new ListViewItem(new string[] { "", dataModel.compositorLayerDict[clsNameId_kvp.Key].ID, dataModel.compositorLayerDict[clsNameId_kvp.Key].ShortName });
                listView1.Items.Add(lvi);
            }
        }
        private void radioButton_Buflet_func()
        {
            foreach (var bufletNameId_kvp in dataModel.bufletNameIdDict)
            {
                ListViewItem lvi = new ListViewItem(new string[] { "", dataModel.bufletDict[bufletNameId_kvp.Key].ID, bufletNameId_kvp.Key });
                listView1.Items.Add(lvi);
            }
        }
        private void radioButton_Window_func()
        {
            foreach (var windowNameId_kvp in dataModel.windowNameIdDict)
            {
                ListViewItem lvi = new ListViewItem(new string[] { "", dataModel.windowDict[windowNameId_kvp.Key].ID, windowNameId_kvp.Key });
                listView1.Items.Add(lvi);
            }
        }
        private void radioButton_StateMachine_func()
        {
            foreach (var stateMachineNameId_kvp in dataModel.stateMachineNameIdDict)
            {
                ListViewItem lvi = new ListViewItem(new string[] { "", dataModel.stateMachineDict[stateMachineNameId_kvp.Key].ID, stateMachineNameId_kvp.Key });
                listView1.Items.Add(lvi);
            }
        }
        private void radioButton_Animation_func()
        {
           listView2.Items.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listView1.ListViewItemSorter = null;
            listView1.Items.Clear();
            listView1.BeginUpdate();
            string searchText = textBox1.Text.Trim().ToLower();

            if (radioButton_Widget.Checked)
            {
                if (listView1.Columns.Count < 4)
                {
                    listView1.Columns.Add("isDetached", 70, HorizontalAlignment.Center);
                }
                foreach (var widgetNameIdDetached in dataModel.widgetNameIdDict)
                {
                    if (widgetNameIdDetached.Value.ToLower().Contains(searchText))
                    {
                        ListViewItem lvi = new ListViewItem(new string[] {"", dataModel.widgetDict[widgetNameIdDetached.Key].ID,  widgetNameIdDetached.Key, " " });
                        if (dataModel.widgetDict[widgetNameIdDetached.Key].isDetached)
                        {
                            lvi.SubItems[3].Text = "detached";
                        }
                        listView1.Items.Add(lvi);
                    }
                }
            }
            else if (radioButton_Window.Checked)
            {
                foreach (var window_kvp in dataModel.windowNameIdDict)
                {
                    if (window_kvp.Value.ToLower().Contains(searchText))
                    {
                        ListViewItem lvi = new ListViewItem(new string[] { "", dataModel.windowDict[window_kvp.Key].ID, window_kvp.Key});
                        listView1.Items.Add(lvi);
                    }
                }
            }
            else if (radioButton_Message.Checked)
            {
                foreach (var message_kvp in dataModel.messageNameIdDict)
                {
                    if (message_kvp.Value.ToLower().Contains(searchText))
                    {
                        ListViewItem lvi = new ListViewItem(new string[] { "", dataModel.messageDict[message_kvp.Key].ID, message_kvp.Key });
                        listView1.Items.Add(lvi);
                    }
                }
            }
            else if (radioButton_CompositorLayer.Checked)
            {
                foreach (var cls_kvp in dataModel.compositorLayerNameIdDict)
                {
                    if (cls_kvp.Value.ToLower().Contains(searchText))
                    {
                        ListViewItem lvi = new ListViewItem(new string[] { "", dataModel.compositorLayerDict[cls_kvp.Key].ID, dataModel.compositorLayerDict[cls_kvp.Key].ShortName });
                        listView1.Items.Add(lvi);
                    }
                }
            }
            else if (radioButton_Buflet.Checked)
            {
                foreach (var bufletNameId_kvp in dataModel.bufletNameIdDict)
                {
                    if (bufletNameId_kvp.Value.ToLower().Contains(searchText))
                    {
                        ListViewItem lvi = new ListViewItem(new string[] { "", dataModel.bufletDict[bufletNameId_kvp.Key].ID, bufletNameId_kvp.Key });
                        listView1.Items.Add(lvi);
                    }
                }
            }
            else if (radioButton_StateMachine.Checked)
            {
                foreach (var stateMachineNameId_kvp in dataModel.stateMachineNameIdDict)
                {
                    if (stateMachineNameId_kvp.Value.ToLower().Contains(searchText))
                    {
                        ListViewItem lvi = new ListViewItem(new string[] { "", dataModel.stateMachineDict[stateMachineNameId_kvp.Key].ID, stateMachineNameId_kvp.Key });
                        listView1.Items.Add(lvi);
                    }
                }
            }
            listView1.EndUpdate();

        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                listView2.Items.Clear();
                listView2.BeginUpdate();
                //string selectedText = listView1.SelectedItems[2].Text.Trim();
                string selectedText = listView1.SelectedItems[0].SubItems[2].Text;
                if (radioButton_Widget.Checked)
                {
                    string widgetName = string.Empty;
                    //listView2.Items.Add(new ListViewItem(new String[] {"", "Is Detached", Convert.ToString(dataModel.widgetDict[selectedText].isDetached) }));
                    foreach (System.Reflection.PropertyInfo attr in dataModel.widgetDict[selectedText].GetType().GetProperties())
                    {
                        if (attr.PropertyType == typeof(string))
                        {
                            string attrValueString;
                            string ID = string.Empty;
                            
                            var attrValue = attr.GetValue(dataModel.widgetDict[selectedText], null);
                            if (attrValue != null)
                            {
                                attrValueString = attrValue.ToString();
                            }
                            else
                            {
                                attrValueString = string.Empty;
                            }
                            string attrName = attr.Name.ToString();
                            if (attrName == "Name")
                            {
                                widgetName = attrValueString;
                                continue;
                            }
                            else if (attrName == "ID")
                            {

                            }
                            else if (attrName == "Buflet")
                            {
                                string bufletFullName = attrValueString;
                                if (attrValueString != null && attrValueString != string.Empty)
                                {
                                    ID = dataModel.bufletDict[attrValueString].ID;
                                }
                                if (dataModel.bufletDict.ContainsKey(attrValueString))
                                {
                                    bufletFullName = dataModel.bufletDict[attrValueString].FullName;
                                }
                                listView2.Items.Add(new ListViewItem(new String[] { ID, attrName, bufletFullName }));
                                continue;
                            }
                            else if (attrName == "Layer")
                            {
                                string fullName = attrValueString;
                                string tempName = string.Empty;
                                if (dataModel.widgetDict.ContainsKey(widgetName))
                                {
                                    tempName = "CompositorLayer_" + dataModel.widgetDict[widgetName].Compositor + "_" + dataModel.widgetDict[widgetName].Layer + "_" + dataModel.widgetDict[widgetName].Section;
                                    if (dataModel.compositorLayerDict.ContainsKey(tempName))
                                    {
                                        fullName = dataModel.compositorLayerDict[tempName].Name;
                                        ID = dataModel.compositorLayerDict[tempName].ID;
                                    }
                                }
                                listView2.Items.Add(new ListViewItem(new String[] { ID, attrName, fullName }));
                                continue;
                            }
                            else if (attrName == "Section" && attrValueString != null && attrValueString != string.Empty)
                            {
                                ID = dataModel.sectionDict[attrValueString].ID;
                            }
                            else if (attrName == "Window")
                            {
                                string windowFullName = attrValueString;
                                if (attrValueString != null && attrValueString != string.Empty)
                                {
                                    ID = dataModel.windowDict[attrValueString].ID;
                                }
                                if (dataModel.windowDict.ContainsKey(attrValueString))
                                {
                                    windowFullName = dataModel.windowDict[attrValueString].FullName;
                                }
                                listView2.Items.Add(new ListViewItem(new String[] { ID, attrName, windowFullName }));
                                continue;
                            }
                            else if (attrName == "Compositor" && attrValueString != null && attrValueString != string.Empty)
                            {
                                foreach (var compositorLS_kvp in dataModel.compositorLayerDict)
                                {
                                    if (compositorLS_kvp.Value.ShortName == attrValueString)
                                    {
                                        ID = compositorLS_kvp.Value.ID;
                                        break;
                                    }
                                }
                            }

                            listView2.Items.Add(new ListViewItem(new String[] { ID, attrName, attrValueString }));
                        }
                    }
                }
                else if (radioButton_Window.Checked)
                {
                    foreach (System.Reflection.PropertyInfo attr in dataModel.windowDict[selectedText].GetType().GetProperties())
                    {
                        if (attr.PropertyType == typeof(string))
                        {
                            string attrValueString;
                            var attrValue = attr.GetValue(dataModel.windowDict[selectedText], null);
                            if (attrValue != null)
                            {
                                attrValueString = attrValue.ToString();
                            }
                            else
                            {
                                attrValueString = string.Empty;
                            }
                            string attrName = attr.Name.ToString();

                            if (attrName != "Name" && attrName != "ID")
                            {
                                listView2.Items.Add(new ListViewItem(new String[] { "", attrName, attrValueString }));
                            }
                        }
                    }
                }
                else if (radioButton_CompositorLayer.Checked)
                {
                    foreach(var compositorLayer_kvp in dataModel.compositorLayerDict)
                    {
                        if(compositorLayer_kvp.Value.ShortName == selectedText)
                        {
                            foreach (System.Reflection.PropertyInfo attr in compositorLayer_kvp.Value.GetType().GetProperties())
                            {
                                if (attr.PropertyType == typeof(string))
                                {
                                    string attrValueString;
                                    var attrValue = attr.GetValue(compositorLayer_kvp.Value, null);
                                    if (attrValue != null)
                                    {
                                        attrValueString = attrValue.ToString();
                                    }
                                    else
                                    {
                                        attrValueString = string.Empty;
                                    }
                                    string attrName = attr.Name.ToString();
                                    if (attrName != "ShortName")
                                    {
                                        listView2.Items.Add(new ListViewItem(new String[] { "", attrName, attrValueString }));
                                    }
                                }
                            }
                        }
                    } 
                }
                else if (radioButton_Buflet.Checked)
                {
                    foreach (System.Reflection.PropertyInfo attr in dataModel.bufletDict[selectedText].GetType().GetProperties())
                    {
                        if(attr.PropertyType == typeof(string))
                        {
                            string attrValueString;
                            var attrValue = attr.GetValue(dataModel.bufletDict[selectedText], null);
                            if(attrValue != null)
                            {
                                attrValueString = attrValue.ToString();
                            }
                            else
                            {
                                attrValueString = string.Empty;
                            }
                            string attrName = attr.Name.ToString();
                            
                            if (attrName != "Name" && attrName != "ID")
                            {
                                listView2.Items.Add(new ListViewItem(new String[] { "", attrName, attrValueString }));
                            }
                        }
                    }
                }
                else if (radioButton_Message.Checked)
                {
                    foreach (System.Reflection.PropertyInfo attr in dataModel.messageDict[selectedText].GetType().GetProperties())
                    {
                        if (attr.PropertyType == typeof(string))
                        {
                            string attrValueString;
                            var attrValue = attr.GetValue(dataModel.messageDict[selectedText], null);
                            if (attrValue != null)
                            {
                                attrValueString = attrValue.ToString();
                            }
                            else
                            {
                                attrValueString = string.Empty;
                            }
                            string attrName = attr.Name.ToString();
                            listView2.Items.Add(new ListViewItem(new String[] { "", attrName, attrValueString }));
                        }
                    }
                }
                else if (radioButton_StateMachine.Checked)
                {
                    //listView2.Items.Add()
                    foreach (var stateMachineState in dataModel.stateMachineDict[selectedText].states)
                    {
                        listView2.Items.Add(new ListViewItem(new String[] { "", stateMachineState.Key, stateMachineState.Value }));
                    }
                }
                listView2.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                listView2.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
            listView2.EndUpdate();
        }

        private void selectFirstItemAndResize(ListView listView1, ListView listView2)
        {
            if (listView1.Items.Count > 0)
            {
                listView1.Items[0].Selected = true;
            }  
            this.listView2.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.listView2.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void UserInterface_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            //string text = textBox1.Text.Trim();
            // listView1.FindItemWithText(text);

        }

        private void listView1_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
        {
            this.listView1.ListViewItemSorter = new ListViewItemComparer(e.Column);
            this.listView1.Sort();
            ascendingSort = !ascendingSort;
            ascendingSort_detach = !ascendingSort_detach;
        }

        private void listView1_menuCopyID_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(listView1.SelectedItems[0].SubItems[1].Text);
        }
        private void listView1_menuCopyName_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(listView1.SelectedItems[0].SubItems[2].Text);
        }
        private void listView2_menuCopyID_Click(object sender, EventArgs e)
        {
            if(listView2.SelectedItems[0].SubItems[0].Text != null && listView2.SelectedItems[0].SubItems[0].Text != string.Empty)
            {
                Clipboard.SetText(listView2.SelectedItems[0].SubItems[0].Text);
            }
            else if (listView2.SelectedItems[0].SubItems[0].Text != null && listView2.SelectedItems[0].SubItems[0].Text == string.Empty)
            {
                Clipboard.SetText(" ");
            }
            
        }
        private void listView2_menuCopyName_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(listView2.SelectedItems[0].SubItems[2].Text);
        }

    class ListViewItemComparer : IComparer
    {
        private int col;
        public ListViewItemComparer()
        {
            col = 0;
        }
        public ListViewItemComparer(int column)
        {
            col = column;
        }
        public int Compare(object x, object y)
        {
            int returnVal = -1;
            //if the ID column was clicked
            if (col == 1)
            {
                    if(((ListViewItem)x).SubItems[col].Text != string.Empty && ((ListViewItem)y).SubItems[col].Text != string.Empty)
                    {
                            if (Int32.Parse(((ListViewItem)x).SubItems[col].Text) < Int32.Parse(((ListViewItem)y).SubItems[col].Text) && ascendingSort == true)
                            {
                                return 1;
                            }
                            if (Int32.Parse(((ListViewItem)x).SubItems[col].Text) > Int32.Parse(((ListViewItem)y).SubItems[col].Text) && ascendingSort == false)
                            {
                                return 1;
                            } 
                    }
            }
            //if the detached column was clicked
            else if(col == 3)
            {
                var lvItem = ((ListViewItem)x).SubItems[col];
                int result;
                if (lvItem != null)
                {
                    if (lvItem.Text != "detached")
                    {
                            if (ascendingSort_detach)
                            {
                                result = -1;
                            }
                            else
                            {
                                result = 1;
                            }
                    }
                    else
                    {
                            if (ascendingSort_detach)
                            {
                                result = 1;
                            }
                            else
                            {
                                result = -1;
                            }
                    }
                    return result;
                }  
            }
            else
            {
                if (ascendingSort)
                {
                    returnVal = String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);
                }
                else
                {
                    returnVal = String.Compare(((ListViewItem)y).SubItems[col].Text, ((ListViewItem)x).SubItems[col].Text);
                }      
            }
            return returnVal;
            }
        }
    }
}

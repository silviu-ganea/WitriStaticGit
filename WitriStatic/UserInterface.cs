using System;
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
            
            listView1.Items.Clear();
            listView1.BeginUpdate();

            if (listView1.Columns.Count > 3)
            {
                listView1.Columns[3].Dispose();
            }

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
        private void radioButton_Widget_func()
        {
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
        }
        private void radioButton_Message_func()
        {
            foreach (var messageNameId_kvp in dataModel.messageNameIdDict)
            {
                ListViewItem lvi = new ListViewItem(new string[] { "", dataModel.messageDict[messageNameId_kvp.Key].ID, messageNameId_kvp.Key });
                listView1.Items.Add(lvi);
            }
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
           
        }

        //private void radioButton_Widget_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (radioButton_Widget.Checked)
        //    {
        //        this.listView2.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        //        this.listView2.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        //        if (listView1.Columns.Count < 4)
        //        {
        //            listView1.Columns.Add("isDetached", 70, HorizontalAlignment.Center);
        //        }
                
        //        listView1.Items.Clear();
        //        listView1.BeginUpdate();
        //        foreach(var widgetNameId_kvp in dataModel.widgetNameIdDict)
        //        {
        //            ListViewItem lvi = new ListViewItem(new string[]{"", dataModel.widgetDict[widgetNameId_kvp.Key].ID, widgetNameId_kvp.Key," "});
        //            if (dataModel.widgetDict[widgetNameId_kvp.Key].isDetached)
        //            {
        //                lvi.SubItems[3].Text = "detached";
        //                //lvi.ForeColor = Color.DarkGreen;
        //            }

        //            listView1.Items.Add(lvi);

        //        }
        //        listView1.EndUpdate();

        //    }
        //}
        //private void radioButton_Window_CheckedChanged(object sender, EventArgs e)
        //{
        //    this.listView2.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        //    this.listView2.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        //    if (radioButton_Window.Checked)
        //    {
        //        listView1.Items.Clear();
        //        listView1.BeginUpdate();

        //        if(listView1.Columns.Count > 3)
        //        {
        //            listView1.Columns[3].Dispose();
        //        }

        //        foreach (var windowNameId_kvp in dataModel.windowNameIdDict)
        //        {
        //            ListViewItem lvi = new ListViewItem(new string[] { "", dataModel.windowDict[windowNameId_kvp.Key].ID, windowNameId_kvp.Key});
        //            listView1.Items.Add(lvi);
        //        }
        //        listView1.EndUpdate();
        //    }
        //}
        //private void radioButton_Message_CheckedChanged(object sender, EventArgs e)
        //{
        //    this.listView2.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        //    this.listView2.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        //    if (radioButton_Message.Checked)
        //    {
        //        listView1.Items.Clear();
        //        listView1.BeginUpdate();

        //        if (listView1.Columns.Count > 3)
        //        {
        //            listView1.Columns[3].Dispose();
        //        }

        //        foreach (var messageNameId_kvp in dataModel.messageNameIdDict)
        //        {
        //            ListViewItem lvi = new ListViewItem(new string[] { "", dataModel.messageDict[messageNameId_kvp.Key].ID, messageNameId_kvp.Key });
        //            listView1.Items.Add(lvi);
        //        }
        //        listView1.EndUpdate();
        //    }
        //}
        //private void radioButton_CompositorLayer_CheckedChanged(object sender, EventArgs e)
        //{
        //    this.listView2.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        //    this.listView2.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        //    if (radioButton_CompositorLayer.Checked)
        //    {
        //        listView1.Items.Clear();
        //        listView1.BeginUpdate();

        //        if (listView1.Columns.Count > 3)
        //        {
        //            listView1.Columns[3].Dispose();
        //        }

        //        foreach (var clsNameID_kvp in dataModel.compositorLayerNameIdDict)
        //        {
        //            ListViewItem lvi = new ListViewItem(new string[] { "", dataModel.compositorLayerDict[clsNameID_kvp.Key].ID, clsNameID_kvp.Key });
        //            listView1.Items.Add(lvi);
        //        }
        //        listView1.EndUpdate();
        //    }
        //}
        //private void radioButton_Buflet_CheckedChanged(object sender, EventArgs e)
        //{
            
        //    if (radioButton_Buflet.Checked)
        //    {
        //        listView1.Items.Clear();
        //        listView1.BeginUpdate();

        //        if (listView1.Columns.Count > 3)
        //        {
        //            listView1.Columns[3].Dispose();
        //        }

        //        foreach (var bufletNameId_kvp in dataModel.bufletNameIdDict)
        //        {
        //            ListViewItem lvi = new ListViewItem(new string[] { "", dataModel.bufletDict[bufletNameId_kvp.Key].ID, bufletNameId_kvp.Key });
        //            listView1.Items.Add(lvi);
        //        }

        //        selectFirstItemAndResize(listView1, listView2);

        //        listView1.EndUpdate();
        //    }
        //}
        
        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (radioButton_Widget.Checked)
            {
                string searchText = textBox1.Text.Trim().ToLower();
                listView1.Items.Clear();
                listView1.BeginUpdate();
                foreach(var widgetNameIdDetached in dataModel.widgetNameIdDict)
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
                listView1.EndUpdate();
            }
            else if (radioButton_Window.Checked)
            {
                string searchText = textBox1.Text.Trim().ToLower();
                listView1.Items.Clear();
                listView1.BeginUpdate();
                foreach (var window_kvp in dataModel.windowNameIdDict)
                {
                    if (window_kvp.Value.ToLower().Contains(searchText))
                    {
                        ListViewItem lvi = new ListViewItem(new string[] { "", dataModel.windowDict[window_kvp.Key].ID, window_kvp.Key});
                        listView1.Items.Add(lvi);
                    }
                }
                listView1.EndUpdate();
            }
            else if (radioButton_Message.Checked)
            {
                string searchText = textBox1.Text.Trim().ToLower();
                listView1.Items.Clear();
                listView1.BeginUpdate();
                foreach (var message_kvp in dataModel.messageNameIdDict)
                {
                    if (message_kvp.Value.ToLower().Contains(searchText))
                    {
                        ListViewItem lvi = new ListViewItem(new string[] { "", dataModel.messageDict[message_kvp.Key].ID, message_kvp.Key });
                        listView1.Items.Add(lvi);
                    }
                }
                listView1.EndUpdate();
            }
            else if (radioButton_CompositorLayer.Checked)
            {
                string searchText = textBox1.Text.Trim().ToLower();
                listView1.Items.Clear();
                listView1.BeginUpdate();
                foreach (var cls_kvp in dataModel.compositorLayerNameIdDict)
                {
                    if (cls_kvp.Value.ToLower().Contains(searchText))
                    {
                        ListViewItem lvi = new ListViewItem(new string[] { "", dataModel.compositorLayerDict[cls_kvp.Key].ID, dataModel.compositorLayerDict[cls_kvp.Key].ShortName });
                        listView1.Items.Add(lvi);
                    }
                }
                listView1.EndUpdate();
            }
            else if (radioButton_Buflet.Checked)
            {
                string searchText = textBox1.Text.Trim().ToLower();
                listView1.Items.Clear();
                listView1.BeginUpdate();
                foreach (var bufletNameId_kvp in dataModel.bufletNameIdDict)
                {
                    if (bufletNameId_kvp.Value.ToLower().Contains(searchText))
                    {
                        ListViewItem lvi = new ListViewItem(new string[] { "", dataModel.bufletDict[bufletNameId_kvp.Key].ID, bufletNameId_kvp.Key });
                        listView1.Items.Add(lvi);
                    }
                }
                listView1.EndUpdate();
            }
            else if (radioButton_StateMachine.Checked)
            {
                string searchText = textBox1.Text.Trim().ToLower();
                listView1.Items.Clear();
                listView1.BeginUpdate();
                foreach (var stateMachineNameId_kvp in dataModel.stateMachineNameIdDict)
                {
                    if (stateMachineNameId_kvp.Value.ToLower().Contains(searchText))
                    {
                        ListViewItem lvi = new ListViewItem(new string[] { "", dataModel.stateMachineDict[stateMachineNameId_kvp.Key].ID, stateMachineNameId_kvp.Key });
                        listView1.Items.Add(lvi);
                    }
                }
                listView1.EndUpdate();
            }

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
                    listView2.Items.Add(new ListViewItem(new String[] { "Is Detached", Convert.ToString(dataModel.widgetDict[selectedText].isDetached) }));
                    foreach (System.Reflection.PropertyInfo attr in dataModel.widgetDict[selectedText].GetType().GetProperties())
                    {
                        if (attr.PropertyType == typeof(string))
                        {
                            string attrValueString;
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
                            listView2.Items.Add(new ListViewItem(new String[] { attrName, attrValueString }));
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
                            listView2.Items.Add(new ListViewItem(new String[] { attrName, attrValueString }));
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
                                        listView2.Items.Add(new ListViewItem(new String[] { attrName, attrValueString }));
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
                            listView2.Items.Add(new ListViewItem(new String[] { attrName, attrValueString }));
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
                            listView2.Items.Add(new ListViewItem(new String[] { attrName, attrValueString }));
                        }
                    }
                }
                else if (radioButton_StateMachine.Checked)
                {
                    //listView2.Items.Add()
                    foreach (var stateMachineState in dataModel.stateMachineDict[selectedText].states)
                    {
                        listView2.Items.Add(new ListViewItem(new String[] { stateMachineState.Key, stateMachineState.Value }));
                    }
                    
                }
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
    }
}

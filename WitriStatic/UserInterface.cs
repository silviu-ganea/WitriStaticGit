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

        private void radioButton_Widget_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_Widget.Checked)
            {
                listView1.Items.Clear();
                listView1.BeginUpdate();
                foreach(var widgetNameId_kvp in dataModel.widgetNameIdDict)
                {
                    listView1.Items.Add(widgetNameId_kvp.Key);
                } 
                listView1.EndUpdate();
            }
        }
        private void radioButton_Window_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_Window.Checked)
            {
                listView1.Items.Clear();
                listView1.BeginUpdate();
                foreach (var windowNameId_kvp in dataModel.windowNameIdDict)
                {
                    listView1.Items.Add(windowNameId_kvp.Key);
                }
                listView1.EndUpdate();
            }
        }
        private void radioButton_Message_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_Message.Checked)
            {
                listView1.Items.Clear();
                listView1.BeginUpdate();
                foreach (var messageNameId_kvp in dataModel.messageNameIdDict)
                {
                    listView1.Items.Add(messageNameId_kvp.Key);
                }
                listView1.EndUpdate();
            }
        }
        private void radioButton_CompositorLayer_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_CompositorLayer.Checked)
            {
                listView1.Items.Clear();
                listView1.BeginUpdate();
                foreach (var layerNameId_kvp in dataModel.layerNameIdDict)
                {
                    listView1.Items.Add(layerNameId_kvp.Value);
                }
                listView1.EndUpdate();
            }
        }
        private void radioButton_Buflet_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_Buflet.Checked)
            {
                listView1.Items.Clear();
                listView1.BeginUpdate();

                foreach (var bufletNameId_kvp in dataModel.bufletNameIdDict)
                {
                    listView1.Items.Add(bufletNameId_kvp.Value);
                }

                listView1.EndUpdate();
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            //string text = textBox1.Text.Trim();
            // listView1.FindItemWithText(text);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (radioButton_Widget.Checked)
            {
                string searchText = textBox1.Text.Trim().ToLower();
                listView1.Items.Clear();
                listView1.BeginUpdate();
                foreach(var widgetNameIdDetached in dataModel.widgetNameIdDict)
                {
                    if (widgetNameIdDetached.Key.ToLower().Contains(searchText))
                    {
                        if (dataModel.widgetDict[widgetNameIdDetached.Value].isDetached)
                        {
                            ListViewItem tempItem = new ListViewItem();
                            tempItem.Text = widgetNameIdDetached.Key;
                            tempItem.ForeColor = Color.DarkTurquoise;
                            listView1.Items.Add(tempItem);
                        }
                        else
                        {
                            listView1.Items.Add(widgetNameIdDetached.Key);
                        }
                        
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
                    if (window_kvp.Key.ToLower().Contains(searchText))
                    {
                        listView1.Items.Add(window_kvp.Key);
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
                    if (message_kvp.Key.ToLower().Contains(searchText))
                    {
                        listView1.Items.Add(message_kvp.Key);
                    }
                }
                listView1.EndUpdate();
            }
            else if (radioButton_CompositorLayer.Checked)
            {
                string searchText = textBox1.Text.Trim().ToLower();
                listView1.Items.Clear();
                listView1.BeginUpdate();
                foreach (var layer_kvp in dataModel.layerNameIdDict)
                {
                    if (layer_kvp.Key.ToLower().Contains(searchText))
                    {
                        listView1.Items.Add(layer_kvp.Key);
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
                    if (bufletNameId_kvp.Key.ToLower().Contains(searchText))
                    {
                        listView1.Items.Add(bufletNameId_kvp.Key);
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
                string selectedText = listView1.SelectedItems[0].Text.Trim();
                string selectedName = null;
                if (selectedText.Contains("detached"))
                {
                    selectedName = listView1.SelectedItems[0].Text.Trim();
                    selectedName = selectedName.Split('-')[0].Trim();
                }
                else selectedName = selectedText.Split('-')[0].Trim();
                if (radioButton_Widget.Checked)
                {
                    string name = dataModel.widgetNameIdDict[selectedText];
                    listView2.Items.Add(new ListViewItem(new String[] { "Is Detached", Convert.ToString(dataModel.widgetDict[selectedName].isDetached) }));
                    foreach (System.Reflection.PropertyInfo attr in dataModel.widgetDict[name].GetType().GetProperties())
                    {
                        if (attr.PropertyType == typeof(string))
                        {
                            string attrValueString;
                            var attrValue = attr.GetValue(dataModel.widgetDict[name], null);
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
                    string name = dataModel.windowNameIdDict[selectedText];
                    foreach (System.Reflection.PropertyInfo attr in dataModel.windowDict[name].GetType().GetProperties())
                    {
                        if (attr.PropertyType == typeof(string))
                        {
                            string attrValueString;
                            var attrValue = attr.GetValue(dataModel.windowDict[name], null);
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
                    string name = dataModel.layerNameIdDict[selectedText];
                    foreach (System.Reflection.PropertyInfo attr in dataModel.layerDict[name].GetType().GetProperties())
                    {
                        if(attr.PropertyType == typeof(string))
                        {
                            string attrValueString;
                            var attrValue = attr.GetValue(dataModel.layerDict[name], null);
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
                else if (radioButton_Buflet.Checked)
                {
                    string name = dataModel.bufletNameIdDict[selectedText];
                    foreach (System.Reflection.PropertyInfo attr in dataModel.bufletDict[name].GetType().GetProperties())
                    {
                        if(attr.PropertyType == typeof(string))
                        {
                            string attrValueString;
                            var attrValue = attr.GetValue(dataModel.bufletDict[name], null);
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
                    string name = dataModel.messageNameIdDict[selectedText];
                    foreach (System.Reflection.PropertyInfo attr in dataModel.messageDict[name].GetType().GetProperties())
                    {
                        if (attr.PropertyType == typeof(string))
                        {
                            string attrValueString;
                            var attrValue = attr.GetValue(dataModel.messageDict[name], null);
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
            }
        }
    }
}

using System;
using System.Windows.Forms;

namespace WitriStatic
{
    partial class UserInterface
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.radioButton_Widget = new System.Windows.Forms.RadioButton();
            this.radioButton_Window = new System.Windows.Forms.RadioButton();
            this.radioButton_Buflet = new System.Windows.Forms.RadioButton();
            this.radioButton_StateMachine = new System.Windows.Forms.RadioButton();
            this.radioButton_Message = new System.Windows.Forms.RadioButton();
            this.radioButton_CompositorLayer = new System.Windows.Forms.RadioButton();
            this.radioButton_Animation = new System.Windows.Forms.RadioButton();
            this.listView1 = new System.Windows.Forms.ListView();
            this.listView2 = new System.Windows.Forms.ListView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Search";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(52, 29);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(501, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // radioButton_Widget
            // 
            this.radioButton_Widget.Location = new System.Drawing.Point(13, 19);
            this.radioButton_Widget.Name = "radioButton_Widget";
            this.radioButton_Widget.Size = new System.Drawing.Size(71, 17);
            this.radioButton_Widget.TabIndex = 2;
            this.radioButton_Widget.TabStop = true;
            this.radioButton_Widget.Text = "Widget";
            this.radioButton_Widget.UseVisualStyleBackColor = true;
            this.radioButton_Widget.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // radioButton_Window
            // 
            this.radioButton_Window.AutoSize = true;
            this.radioButton_Window.Location = new System.Drawing.Point(13, 42);
            this.radioButton_Window.Name = "radioButton_Window";
            this.radioButton_Window.Size = new System.Drawing.Size(64, 17);
            this.radioButton_Window.TabIndex = 4;
            this.radioButton_Window.TabStop = true;
            this.radioButton_Window.Text = "Window";
            this.radioButton_Window.UseVisualStyleBackColor = true;
            this.radioButton_Window.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // radioButton_Buflet
            // 
            this.radioButton_Buflet.AutoSize = true;
            this.radioButton_Buflet.Location = new System.Drawing.Point(432, 19);
            this.radioButton_Buflet.Name = "radioButton_Buflet";
            this.radioButton_Buflet.Size = new System.Drawing.Size(52, 17);
            this.radioButton_Buflet.TabIndex = 5;
            this.radioButton_Buflet.TabStop = true;
            this.radioButton_Buflet.Text = "Buflet";
            this.radioButton_Buflet.UseVisualStyleBackColor = true;
            this.radioButton_Buflet.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // radioButton_StateMachine
            // 
            this.radioButton_StateMachine.AutoSize = true;
            this.radioButton_StateMachine.Location = new System.Drawing.Point(137, 42);
            this.radioButton_StateMachine.Name = "radioButton_StateMachine";
            this.radioButton_StateMachine.Size = new System.Drawing.Size(91, 17);
            this.radioButton_StateMachine.TabIndex = 6;
            this.radioButton_StateMachine.Text = "StateMachine";
            this.radioButton_StateMachine.UseVisualStyleBackColor = true;
            this.radioButton_StateMachine.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // radioButton_Message
            // 
            this.radioButton_Message.AutoSize = true;
            this.radioButton_Message.Location = new System.Drawing.Point(137, 19);
            this.radioButton_Message.Name = "radioButton_Message";
            this.radioButton_Message.Size = new System.Drawing.Size(68, 17);
            this.radioButton_Message.TabIndex = 8;
            this.radioButton_Message.TabStop = true;
            this.radioButton_Message.Text = "Message";
            this.radioButton_Message.UseVisualStyleBackColor = true;
            this.radioButton_Message.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // radioButton_CompositorLayer
            // 
            this.radioButton_CompositorLayer.AutoSize = true;
            this.radioButton_CompositorLayer.Location = new System.Drawing.Point(269, 19);
            this.radioButton_CompositorLayer.Name = "radioButton_CompositorLayer";
            this.radioButton_CompositorLayer.Size = new System.Drawing.Size(106, 17);
            this.radioButton_CompositorLayer.TabIndex = 9;
            this.radioButton_CompositorLayer.TabStop = true;
            this.radioButton_CompositorLayer.Text = "Compositor Layer";
            this.radioButton_CompositorLayer.UseVisualStyleBackColor = true;
            this.radioButton_CompositorLayer.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // radioButton_Animation
            // 
            this.radioButton_Animation.AutoSize = true;
            this.radioButton_Animation.Location = new System.Drawing.Point(269, 42);
            this.radioButton_Animation.Name = "radioButton_Animation";
            this.radioButton_Animation.Size = new System.Drawing.Size(71, 17);
            this.radioButton_Animation.TabIndex = 10;
            this.radioButton_Animation.TabStop = true;
            this.radioButton_Animation.Text = "Animation";
            this.radioButton_Animation.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 136);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(600, 368);
            this.listView1.TabIndex = 11;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.Columns.Add("", 0);
            this.listView1.Columns.Add("ID", 50, HorizontalAlignment.Center);
            this.listView1.Columns.Add("Search Result", 460);
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView1_ColumnClick);
            
            ContextMenuStrip contextMenuListView1 = new ContextMenuStrip();
            ToolStripMenuItem lv1_menuItem_CopyID = new ToolStripMenuItem("Copy ID");
            ToolStripMenuItem lv1_menuItem_CopyName = new ToolStripMenuItem("Copy Name");
            lv1_menuItem_CopyID.Click += new EventHandler(listView1_menuCopyID_Click);
            lv1_menuItem_CopyName.Click += new EventHandler(listView1_menuCopyName_Click);
            contextMenuListView1.Items.Add(lv1_menuItem_CopyID);
            contextMenuListView1.Items.Add(lv1_menuItem_CopyName);
            listView1.ContextMenuStrip = contextMenuListView1;
            // 
            // listView2
            // 
            this.listView2.FullRowSelect = true;
            this.listView2.Location = new System.Drawing.Point(625, 33);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(662, 470);
            this.listView2.TabIndex = 12;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            this.listView2.Columns.Add("ID");
            this.listView2.Columns.Add("Property");
            this.listView2.Columns.Add("Value");
            this.listView2.ShowItemToolTips = true;
            //this.listView2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView2_MouseClick);

            ContextMenuStrip contextMenuListView2 = new ContextMenuStrip();
            ToolStripMenuItem lv2_menuItem_CopyID = new ToolStripMenuItem("Copy ID");
            ToolStripMenuItem lv2_menuItem_CopyName = new ToolStripMenuItem("Copy Name");
            lv2_menuItem_CopyID.Click += new EventHandler(listView2_menuCopyID_Click);
            lv2_menuItem_CopyName.Click += new EventHandler(listView2_menuCopyName_Click);
            contextMenuListView2.Items.Add(lv2_menuItem_CopyID);
            contextMenuListView2.Items.Add(lv2_menuItem_CopyName);
            listView2.ContextMenuStrip = contextMenuListView2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton_Widget);
            this.groupBox1.Controls.Add(this.radioButton_Window);
            this.groupBox1.Controls.Add(this.radioButton_Message);
            this.groupBox1.Controls.Add(this.radioButton_CompositorLayer);
            this.groupBox1.Controls.Add(this.radioButton_StateMachine);
            this.groupBox1.Controls.Add(this.radioButton_Animation);
            this.groupBox1.Controls.Add(this.radioButton_Buflet);
            this.groupBox1.Location = new System.Drawing.Point(52, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(501, 67);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            //this.groupBox1.Click += new System.EventHandler(this.groupBox_selectedAnyCheckbox);
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 515);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "UserInterface";
            this.Text = "WITRI Static";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RadioButton radioButton_Widget;
        private System.Windows.Forms.RadioButton radioButton_Window;
        private System.Windows.Forms.RadioButton radioButton_Buflet;
        private System.Windows.Forms.RadioButton radioButton_StateMachine;
        private System.Windows.Forms.RadioButton radioButton_Message;
        private System.Windows.Forms.RadioButton radioButton_CompositorLayer;
        private System.Windows.Forms.RadioButton radioButton_Animation;
        private ListView listView1;
        private ListView listView2;
        private GroupBox groupBox1;
    }
}
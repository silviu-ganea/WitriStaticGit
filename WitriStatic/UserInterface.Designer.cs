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
            this.button1 = new System.Windows.Forms.Button();
            this.radioButton_Window = new System.Windows.Forms.RadioButton();
            this.radioButton_Buflet = new System.Windows.Forms.RadioButton();
            this.radioButton_StateMachine = new System.Windows.Forms.RadioButton();
            this.radioButton_StateMachineState = new System.Windows.Forms.RadioButton();
            this.radioButton_Message = new System.Windows.Forms.RadioButton();
            this.radioButton_CompositorLayer = new RadioButton();
            this.radioButton_Animation = new RadioButton();
            this.listView1 = new ListView();
            this.listView2 = new ListView();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(182, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Search";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(234, 37);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(237, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // radioButton_Widget
            // 
            this.radioButton_Widget.Location = new System.Drawing.Point(52, 79);
            this.radioButton_Widget.Name = "radioButton_Widget";
            this.radioButton_Widget.Size = new System.Drawing.Size(71, 25);
            this.radioButton_Widget.TabIndex = 2;
            this.radioButton_Widget.TabStop = true;
            this.radioButton_Widget.Text = "Widget";
            this.radioButton_Widget.UseVisualStyleBackColor = true;
            this.radioButton_Widget.CheckedChanged += new System.EventHandler(this.radioButton_Widget_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(507, 34);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // radioButton_Window
            // 
            this.radioButton_Window.AutoSize = true;
            this.radioButton_Window.Location = new System.Drawing.Point(210, 75);
            this.radioButton_Window.Name = "radioButton_Window";
            this.radioButton_Window.Size = new System.Drawing.Size(64, 17);
            this.radioButton_Window.TabIndex = 4;
            this.radioButton_Window.TabStop = true;
            this.radioButton_Window.Text = "Window";
            this.radioButton_Window.UseVisualStyleBackColor = true;
            this.radioButton_Window.CheckedChanged += new System.EventHandler(this.radioButton_Window_CheckedChanged);
            // 
            // radioButton_Buflet
            // 
            this.radioButton_Buflet.AutoSize = true;
            this.radioButton_Buflet.Location = new System.Drawing.Point(348, 75);
            this.radioButton_Buflet.Name = "radioButton_Buflet";
            this.radioButton_Buflet.Size = new System.Drawing.Size(52, 17);
            this.radioButton_Buflet.TabIndex = 5;
            this.radioButton_Buflet.TabStop = true;
            this.radioButton_Buflet.Text = "Buflet";
            this.radioButton_Buflet.UseVisualStyleBackColor = true;
            this.radioButton_Buflet.CheckedChanged += new System.EventHandler(this.radioButton_Buflet_CheckedChanged);
            // 
            // radioButton_StateMachine
            // 
            this.radioButton_StateMachine.AutoSize = true;
            this.radioButton_StateMachine.Location = new System.Drawing.Point(507, 75);
            this.radioButton_StateMachine.Name = "radioButton_StateMachine";
            this.radioButton_StateMachine.Size = new System.Drawing.Size(91, 17);
            this.radioButton_StateMachine.TabIndex = 6;
            this.radioButton_StateMachine.TabStop = true;
            this.radioButton_StateMachine.Text = "StateMachine";
            this.radioButton_StateMachine.UseVisualStyleBackColor = true;
            // 
            // radioButton_StateMachineState
            // 
            this.radioButton_StateMachineState.AutoSize = true;
            this.radioButton_StateMachineState.Location = new System.Drawing.Point(52, 119);
            this.radioButton_StateMachineState.Name = "radioButton5";
            this.radioButton_StateMachineState.Size = new System.Drawing.Size(116, 17);
            this.radioButton_StateMachineState.TabIndex = 7;
            this.radioButton_StateMachineState.TabStop = true;
            this.radioButton_StateMachineState.Text = "StateMachineState";
            this.radioButton_StateMachineState.UseVisualStyleBackColor = true;
            // 
            // radioButton_Message
            // 
            this.radioButton_Message.AutoSize = true;
            this.radioButton_Message.Location = new System.Drawing.Point(206, 119);
            this.radioButton_Message.Name = "radioButton_Message";
            this.radioButton_Message.Size = new System.Drawing.Size(68, 17);
            this.radioButton_Message.TabIndex = 8;
            this.radioButton_Message.TabStop = true;
            this.radioButton_Message.Text = "Message";
            this.radioButton_Message.UseVisualStyleBackColor = true;
            this.radioButton_Message.CheckedChanged += new System.EventHandler(this.radioButton_Message_CheckedChanged);
            // 
            // radioButton_CompositorLayer
            // 
            this.radioButton_CompositorLayer.AutoSize = true;
            this.radioButton_CompositorLayer.Location = new System.Drawing.Point(348, 119);
            this.radioButton_CompositorLayer.Name = "radioButton7";
            this.radioButton_CompositorLayer.Size = new System.Drawing.Size(106, 17);
            this.radioButton_CompositorLayer.TabIndex = 9;
            this.radioButton_CompositorLayer.TabStop = true;
            this.radioButton_CompositorLayer.Text = "Compositor Layer";
            this.radioButton_CompositorLayer.UseVisualStyleBackColor = true;
            this.radioButton_CompositorLayer.CheckedChanged += new System.EventHandler(this.radioButton_CompositorLayer_CheckedChanged);
            // 
            // radioButton_Animation
            // 
            this.radioButton_Animation.AutoSize = true;
            this.radioButton_Animation.Location = new System.Drawing.Point(507, 119);
            this.radioButton_Animation.Name = "radioButton_Animation";
            this.radioButton_Animation.Size = new System.Drawing.Size(71, 17);
            this.radioButton_Animation.TabIndex = 10;
            this.radioButton_Animation.TabStop = true;
            this.radioButton_Animation.Text = "Animation";
            this.radioButton_Animation.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(12, 190);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(700, 365);
            this.listView1.TabIndex = 11;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.Columns.Add("Search Result");
            this.listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // listView2
            // 
            this.listView2.Location = new System.Drawing.Point(752, 34);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(500, 365);
            this.listView2.TabIndex = 12;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            this.listView2.Columns.Add("Property");
            this.listView2.Columns.Add("Value");
            this.listView2.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.listView2.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1500, 700);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.radioButton_Animation);
            this.Controls.Add(this.radioButton_CompositorLayer);
            this.Controls.Add(this.radioButton_Message);
            this.Controls.Add(this.radioButton_StateMachineState);
            this.Controls.Add(this.radioButton_StateMachine);
            this.Controls.Add(this.radioButton_Buflet);
            this.Controls.Add(this.radioButton_Window);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.radioButton_Widget);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "WITRI Offline";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RadioButton radioButton_Widget;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton radioButton_Window;
        private System.Windows.Forms.RadioButton radioButton_Buflet;
        private System.Windows.Forms.RadioButton radioButton_StateMachine;
        private System.Windows.Forms.RadioButton radioButton_StateMachineState;
        private System.Windows.Forms.RadioButton radioButton_Message;
        private System.Windows.Forms.RadioButton radioButton_CompositorLayer;
        private System.Windows.Forms.RadioButton radioButton_Animation;
        private System.Windows.Forms.ListView listView1;
        private ListView listView2;
    }
}
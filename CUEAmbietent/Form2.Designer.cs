namespace M3dium
{
    partial class Form2
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.CheckBox_startwwindows = new System.Windows.Forms.CheckBox();
            this.CheckBox_startminimized = new System.Windows.Forms.CheckBox();
            this.CheckBox_displaycolor = new System.Windows.Forms.CheckBox();
            this.CheckBox_enablewstart = new System.Windows.Forms.CheckBox();
            this.registry_delete_button = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // CheckBox_startwwindows
            // 
            this.CheckBox_startwwindows.AutoSize = true;
            this.CheckBox_startwwindows.Location = new System.Drawing.Point(13, 13);
            this.CheckBox_startwwindows.Name = "CheckBox_startwwindows";
            this.CheckBox_startwwindows.Size = new System.Drawing.Size(171, 17);
            this.CheckBox_startwwindows.TabIndex = 0;
            this.CheckBox_startwwindows.Text = "Start application with Windows";
            this.CheckBox_startwwindows.UseVisualStyleBackColor = true;
            this.CheckBox_startwwindows.CheckedChanged += new System.EventHandler(this.CheckBox_startwwindows_CheckedChanged);
            // 
            // CheckBox_startminimized
            // 
            this.CheckBox_startminimized.AutoSize = true;
            this.CheckBox_startminimized.Location = new System.Drawing.Point(13, 37);
            this.CheckBox_startminimized.Name = "CheckBox_startminimized";
            this.CheckBox_startminimized.Size = new System.Drawing.Size(96, 17);
            this.CheckBox_startminimized.TabIndex = 1;
            this.CheckBox_startminimized.Text = "Start minimized";
            this.CheckBox_startminimized.UseVisualStyleBackColor = true;
            this.CheckBox_startminimized.CheckedChanged += new System.EventHandler(this.CheckBox_startminimized_CheckedChanged);
            // 
            // CheckBox_displaycolor
            // 
            this.CheckBox_displaycolor.AutoSize = true;
            this.CheckBox_displaycolor.Location = new System.Drawing.Point(13, 61);
            this.CheckBox_displaycolor.Name = "CheckBox_displaycolor";
            this.CheckBox_displaycolor.Size = new System.Drawing.Size(122, 17);
            this.CheckBox_displaycolor.TabIndex = 2;
            this.CheckBox_displaycolor.Text = "Display current color";
            this.CheckBox_displaycolor.UseVisualStyleBackColor = true;
            this.CheckBox_displaycolor.CheckedChanged += new System.EventHandler(this.CheckBox_displaycolor_CheckedChanged);
            // 
            // CheckBox_enablewstart
            // 
            this.CheckBox_enablewstart.AutoSize = true;
            this.CheckBox_enablewstart.Location = new System.Drawing.Point(13, 85);
            this.CheckBox_enablewstart.Name = "CheckBox_enablewstart";
            this.CheckBox_enablewstart.Size = new System.Drawing.Size(158, 17);
            this.CheckBox_enablewstart.TabIndex = 3;
            this.CheckBox_enablewstart.Text = "Enable with application start";
            this.toolTip1.SetToolTip(this.CheckBox_enablewstart, "Recommended in case of run on startup");
            this.CheckBox_enablewstart.UseVisualStyleBackColor = true;
            this.CheckBox_enablewstart.CheckedChanged += new System.EventHandler(this.CheckBox_enablewstart_CheckedChanged);
            // 
            // registry_delete_button
            // 
            this.registry_delete_button.AccessibleDescription = "Deletes the entry added to the registry in order for the program to run on startu" +
    "p";
            this.registry_delete_button.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.registry_delete_button.Location = new System.Drawing.Point(13, 108);
            this.registry_delete_button.Name = "registry_delete_button";
            this.registry_delete_button.Size = new System.Drawing.Size(158, 23);
            this.registry_delete_button.TabIndex = 4;
            this.registry_delete_button.Text = "Delete startup registry entry";
            this.toolTip1.SetToolTip(this.registry_delete_button, resources.GetString("registry_delete_button.ToolTip"));
            this.registry_delete_button.UseVisualStyleBackColor = true;
            this.registry_delete_button.Click += new System.EventHandler(this.registry_delete_button_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 999999999;
            this.toolTip1.AutoPopDelay = 99999999;
            this.toolTip1.InitialDelay = 480;
            this.toolTip1.ReshowDelay = 96;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(183, 137);
            this.Controls.Add(this.registry_delete_button);
            this.Controls.Add(this.CheckBox_enablewstart);
            this.Controls.Add(this.CheckBox_displaycolor);
            this.Controls.Add(this.CheckBox_startminimized);
            this.Controls.Add(this.CheckBox_startwwindows);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form2";
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox CheckBox_startwwindows;
        private System.Windows.Forms.CheckBox CheckBox_startminimized;
        private System.Windows.Forms.CheckBox CheckBox_displaycolor;
        private System.Windows.Forms.CheckBox CheckBox_enablewstart;
        private System.Windows.Forms.Button registry_delete_button;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
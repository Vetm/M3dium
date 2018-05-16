namespace CUEAmbient
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.average_on = new System.Windows.Forms.Button();
            this.average_off = new System.Windows.Forms.Button();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.currentcolor = new System.Windows.Forms.Label();
            this.settings_button = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // average_on
            // 
            this.average_on.Location = new System.Drawing.Point(12, 12);
            this.average_on.Name = "average_on";
            this.average_on.Size = new System.Drawing.Size(116, 76);
            this.average_on.TabIndex = 0;
            this.average_on.Text = "On";
            this.average_on.UseVisualStyleBackColor = true;
            this.average_on.Click += new System.EventHandler(this.average_On);
            // 
            // average_off
            // 
            this.average_off.Location = new System.Drawing.Point(134, 12);
            this.average_off.Name = "average_off";
            this.average_off.Size = new System.Drawing.Size(116, 76);
            this.average_off.TabIndex = 1;
            this.average_off.Text = "Off";
            this.average_off.UseVisualStyleBackColor = true;
            this.average_off.Click += new System.EventHandler(this.average_Off);
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "M3dium";
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // currentcolor
            // 
            this.currentcolor.AutoSize = true;
            this.currentcolor.Location = new System.Drawing.Point(12, 93);
            this.currentcolor.Name = "currentcolor";
            this.currentcolor.Size = new System.Drawing.Size(37, 13);
            this.currentcolor.TabIndex = 2;
            this.currentcolor.Text = "Color: ";
            this.currentcolor.Visible = false;
            // 
            // settings_button
            // 
            this.settings_button.Cursor = System.Windows.Forms.Cursors.Default;
            this.settings_button.FlatAppearance.BorderSize = 0;
            this.settings_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.settings_button.Image = ((System.Drawing.Image)(resources.GetObject("settings_button.Image")));
            this.settings_button.Location = new System.Drawing.Point(242, 87);
            this.settings_button.Name = "settings_button";
            this.settings_button.Size = new System.Drawing.Size(19, 19);
            this.settings_button.TabIndex = 3;
            this.settings_button.UseVisualStyleBackColor = true;
            this.settings_button.Click += new System.EventHandler(this.settings_button_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "setting.ico");
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(261, 108);
            this.Controls.Add(this.settings_button);
            this.Controls.Add(this.currentcolor);
            this.Controls.Add(this.average_off);
            this.Controls.Add(this.average_on);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "M3dium";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button average_on;
        private System.Windows.Forms.Button average_off;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.Label currentcolor;
        private System.Windows.Forms.Button settings_button;
        private System.Windows.Forms.ImageList imageList1;
    }
}


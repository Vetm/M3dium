namespace CUEAmbietent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.average_on = new System.Windows.Forms.Button();
            this.average_off = new System.Windows.Forms.Button();
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(261, 96);
            this.Controls.Add(this.average_off);
            this.Controls.Add(this.average_on);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "M3dium";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button average_on;
        private System.Windows.Forms.Button average_off;
    }
}


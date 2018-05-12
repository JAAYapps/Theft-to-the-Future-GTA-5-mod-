namespace TTTF_Launcher
{
    partial class launcher
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
            this.activitylist = new System.Windows.Forms.ListBox();
            this.launch = new System.Windows.Forms.Button();
            this.scriptmanager = new System.Windows.Forms.Timer(this.components);
            this.closeshare = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // activitylist
            // 
            this.activitylist.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.activitylist.FormattingEnabled = true;
            this.activitylist.Items.AddRange(new object[] {
            "To make sure the script is able to run, this launcher must be running. ",
            "All activity will be displayed in this view including 127.0.0.1 commands from scr" +
                "ipt to main launcher.",
            "The launcher will then send the commands back to the other running scripts in the" +
                " gta\'s scripthookv.net.",
            "The reason for this complicated system is because lot of users in the past compla" +
                "in that the f5 menu would not be available when scenes are running due to task r" +
                "easons. "});
            this.activitylist.Location = new System.Drawing.Point(12, 12);
            this.activitylist.Name = "activitylist";
            this.activitylist.Size = new System.Drawing.Size(823, 316);
            this.activitylist.TabIndex = 0;
            // 
            // launch
            // 
            this.launch.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.launch.Location = new System.Drawing.Point(354, 336);
            this.launch.Name = "launch";
            this.launch.Size = new System.Drawing.Size(148, 23);
            this.launch.TabIndex = 1;
            this.launch.Text = "Launch Gta 5 with TTTF";
            this.launch.UseVisualStyleBackColor = true;
            this.launch.Click += new System.EventHandler(this.launch_Click);
            // 
            // scriptmanager
            // 
            this.scriptmanager.Enabled = true;
            this.scriptmanager.Interval = 1000;
            this.scriptmanager.Tick += new System.EventHandler(this.scriptmanager_Tick);
            // 
            // closeshare
            // 
            this.closeshare.Location = new System.Drawing.Point(638, 346);
            this.closeshare.Name = "closeshare";
            this.closeshare.Size = new System.Drawing.Size(75, 23);
            this.closeshare.TabIndex = 2;
            this.closeshare.Text = "Close share";
            this.closeshare.UseVisualStyleBackColor = true;
            this.closeshare.Click += new System.EventHandler(this.closeshare_Click);
            // 
            // launcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 371);
            this.Controls.Add(this.closeshare);
            this.Controls.Add(this.launch);
            this.Controls.Add(this.activitylist);
            this.Name = "launcher";
            this.Text = "Theft to the Future Launcher";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.launcher_FormClosing);
            this.Load += new System.EventHandler(this.launcher_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListBox activitylist;
        private System.Windows.Forms.Button launch;
        private System.Windows.Forms.Timer scriptmanager;
        private System.Windows.Forms.Button closeshare;
    }
}


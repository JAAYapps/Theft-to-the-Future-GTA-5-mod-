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
            this.root = new System.Windows.Forms.TextBox();
            this.animation = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelPosition = new System.Windows.Forms.Label();
            this.labelPlaybackSpeed = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxModes = new System.Windows.Forms.ComboBox();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.trackBarPlaybackPosition = new System.Windows.Forms.TrackBar();
            this.trackBarPlaybackRate = new System.Windows.Forms.TrackBar();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.clear = new System.Windows.Forms.Button();
            this.number = new System.Windows.Forms.TextBox();
            this.getdigit = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPlaybackPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPlaybackRate)).BeginInit();
            this.SuspendLayout();
            // 
            // activitylist
            // 
            this.activitylist.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
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
            this.launch.Location = new System.Drawing.Point(606, 336);
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
            this.scriptmanager.Interval = 1;
            this.scriptmanager.Tick += new System.EventHandler(this.scriptmanager_Tick);
            // 
            // closeshare
            // 
            this.closeshare.Location = new System.Drawing.Point(760, 336);
            this.closeshare.Name = "closeshare";
            this.closeshare.Size = new System.Drawing.Size(75, 23);
            this.closeshare.TabIndex = 2;
            this.closeshare.Text = "Close share";
            this.closeshare.UseVisualStyleBackColor = true;
            this.closeshare.Click += new System.EventHandler(this.closeshare_Click);
            // 
            // root
            // 
            this.root.Location = new System.Drawing.Point(72, 336);
            this.root.Name = "root";
            this.root.Size = new System.Drawing.Size(222, 20);
            this.root.TabIndex = 3;
            // 
            // animation
            // 
            this.animation.Location = new System.Drawing.Point(359, 336);
            this.animation.Name = "animation";
            this.animation.Size = new System.Drawing.Size(198, 20);
            this.animation.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 339);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "root";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(300, 341);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Animation";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelPosition);
            this.panel1.Controls.Add(this.labelPlaybackSpeed);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.comboBoxModes);
            this.panel1.Controls.Add(this.buttonLoad);
            this.panel1.Controls.Add(this.trackBarPlaybackPosition);
            this.panel1.Controls.Add(this.trackBarPlaybackRate);
            this.panel1.Controls.Add(this.buttonStop);
            this.panel1.Controls.Add(this.buttonPlay);
            this.panel1.Location = new System.Drawing.Point(12, 371);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(402, 200);
            this.panel1.TabIndex = 7;
            // 
            // labelPosition
            // 
            this.labelPosition.AutoSize = true;
            this.labelPosition.Location = new System.Drawing.Point(254, 139);
            this.labelPosition.Name = "labelPosition";
            this.labelPosition.Size = new System.Drawing.Size(34, 13);
            this.labelPosition.TabIndex = 15;
            this.labelPosition.Text = "00:00";
            // 
            // labelPlaybackSpeed
            // 
            this.labelPlaybackSpeed.AutoSize = true;
            this.labelPlaybackSpeed.Location = new System.Drawing.Point(254, 78);
            this.labelPlaybackSpeed.Name = "labelPlaybackSpeed";
            this.labelPlaybackSpeed.Size = new System.Drawing.Size(27, 13);
            this.labelPlaybackSpeed.TabIndex = 16;
            this.labelPlaybackSpeed.Text = "x1.0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Playback Position";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Playback Speed";
            // 
            // comboBoxModes
            // 
            this.comboBoxModes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxModes.FormattingEnabled = true;
            this.comboBoxModes.Location = new System.Drawing.Point(254, 14);
            this.comboBoxModes.Name = "comboBoxModes";
            this.comboBoxModes.Size = new System.Drawing.Size(121, 21);
            this.comboBoxModes.TabIndex = 12;
            this.comboBoxModes.SelectedIndexChanged += new System.EventHandler(this.comboBoxModes_SelectedIndexChanged);
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(13, 14);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(75, 23);
            this.buttonLoad.TabIndex = 11;
            this.buttonLoad.Text = "Load";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // trackBarPlaybackPosition
            // 
            this.trackBarPlaybackPosition.Location = new System.Drawing.Point(18, 139);
            this.trackBarPlaybackPosition.Maximum = 100;
            this.trackBarPlaybackPosition.Name = "trackBarPlaybackPosition";
            this.trackBarPlaybackPosition.Size = new System.Drawing.Size(225, 45);
            this.trackBarPlaybackPosition.SmallChange = 5;
            this.trackBarPlaybackPosition.TabIndex = 9;
            this.trackBarPlaybackPosition.TickFrequency = 5;
            this.trackBarPlaybackPosition.Scroll += new System.EventHandler(this.trackBarPlaybackPosition_Scroll);
            // 
            // trackBarPlaybackRate
            // 
            this.trackBarPlaybackRate.Location = new System.Drawing.Point(13, 78);
            this.trackBarPlaybackRate.Maximum = 20;
            this.trackBarPlaybackRate.Name = "trackBarPlaybackRate";
            this.trackBarPlaybackRate.Size = new System.Drawing.Size(230, 45);
            this.trackBarPlaybackRate.TabIndex = 10;
            this.trackBarPlaybackRate.Value = 5;
            this.trackBarPlaybackRate.Scroll += new System.EventHandler(this.trackBarPlaybackRate_Scroll);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(175, 14);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(73, 23);
            this.buttonStop.TabIndex = 8;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonPlay
            // 
            this.buttonPlay.Location = new System.Drawing.Point(94, 14);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(75, 23);
            this.buttonPlay.TabIndex = 7;
            this.buttonPlay.Text = "Play";
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // clear
            // 
            this.clear.Location = new System.Drawing.Point(431, 371);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(75, 23);
            this.clear.TabIndex = 8;
            this.clear.Text = "Clear list";
            this.clear.UseVisualStyleBackColor = true;
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // number
            // 
            this.number.Location = new System.Drawing.Point(499, 468);
            this.number.Name = "number";
            this.number.Size = new System.Drawing.Size(100, 20);
            this.number.TabIndex = 9;
            // 
            // getdigit
            // 
            this.getdigit.Location = new System.Drawing.Point(605, 466);
            this.getdigit.Name = "getdigit";
            this.getdigit.Size = new System.Drawing.Size(75, 23);
            this.getdigit.TabIndex = 10;
            this.getdigit.Text = "Get Digit";
            this.getdigit.UseVisualStyleBackColor = true;
            this.getdigit.Click += new System.EventHandler(this.getdigit_Click);
            // 
            // launcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 689);
            this.Controls.Add(this.getdigit);
            this.Controls.Add(this.number);
            this.Controls.Add(this.clear);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.animation);
            this.Controls.Add(this.root);
            this.Controls.Add(this.closeshare);
            this.Controls.Add(this.launch);
            this.Controls.Add(this.activitylist);
            this.Name = "launcher";
            this.Text = "Theft to the Future Launcher";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.launcher_FormClosing);
            this.Load += new System.EventHandler(this.launcher_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPlaybackPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPlaybackRate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox activitylist;
        private System.Windows.Forms.Button launch;
        private System.Windows.Forms.Timer scriptmanager;
        private System.Windows.Forms.Button closeshare;
        private System.Windows.Forms.TextBox root;
        private System.Windows.Forms.TextBox animation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelPosition;
        private System.Windows.Forms.Label labelPlaybackSpeed;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxModes;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.TrackBar trackBarPlaybackPosition;
        private System.Windows.Forms.TrackBar trackBarPlaybackRate;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.Button clear;
        private System.Windows.Forms.TextBox number;
        private System.Windows.Forms.Button getdigit;
    }
}


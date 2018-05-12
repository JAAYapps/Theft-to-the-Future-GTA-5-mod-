using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleTCP;

namespace TTTF_Launcher
{
    public partial class launcher : Form
    {
        public launcher()
        {
            InitializeComponent();
        }

        SimpleTCP.SimpleTcpServer server = new SimpleTCP.SimpleTcpServer();
        
        private void launch_Click(object sender, EventArgs e)
        {
            activitylist.Items.Add("Waiting for BTTF time travel 0.9.0.dll to respond.");
            server.DataReceived += server_data;
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            server.Start(ip, 10757);
        }
        
        private void server_data(object sender, SimpleTCP.Message e)
        {
            activitylist.Items.Add(e.MessageString);
            if (e.MessageString.Contains("script running"))
            {
                e.ReplyLine("Launcher running");
            }

            if (e.MessageString.Contains("send saved display xy"))
            {
                int x = Properties.Settings.Default.TimeCircuitsDisplay.X;
                int y = Properties.Settings.Default.TimeCircuitsDisplay.Y;
                e.ReplyLine("change time display x: " + x + " y: " + y);
            }

            if (e.MessageString.Contains("change time display "))
            {
                try
                {
                    string xy = e.MessageString.Replace("change time display ", "");
                    string xystring = xy.Replace("x: ", "").Replace(" y: ", ","); //x: " + x + " y: " + y
                    activitylist.Items.Add("change xy for display");
                    activitylist.Items.Add(xystring.Substring(0, xystring.IndexOf(",")));
                    activitylist.Items.Add(xystring.Substring(xystring.IndexOf(',') + 1, (xystring.LastIndexOf(xystring.Last())) - (xystring.IndexOf(',') + 1)));
                    int x = int.Parse(xystring.Substring(0, xystring.IndexOf(",")));
                    int y = int.Parse(xystring.Substring(xystring.IndexOf(',') + 1, (xystring.LastIndexOf(xystring.Last())) - (xystring.IndexOf(',') + 1)));
                    Properties.Settings.Default.TimeCircuitsDisplay = new Point(x, y);
                    Properties.Settings.Default.Save();
                    e.ReplyLine("Done");
                }
                catch (Exception d)
                {
                    e.ReplyLine("error " + d.Message);
                    activitylist.Items.Add("error " + d.Message);
                }

            }

            if (e.MessageString.Contains("Start tutorial (scene)"))
            {
                server.BroadcastLine("(scene) start tutorial");
                e.ReplyLine("Setting up scene");
            }
            activitylist.SelectedIndex = activitylist.Items.Count - 1;
        }

        private void scriptmanager_Tick(object sender, EventArgs e)
        {
            try
            {

            }
            catch (FileNotFoundException g)
            {
                activitylist.Items.Add("waiting while: " + e);
            }
        }

        private void launcher_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (server.IsStarted)
                server.Stop();
        }

        private void closeshare_Click(object sender, EventArgs e)
        {
            if (server.IsStarted)
                server.Stop();
        }

        private void launcher_Load(object sender, EventArgs e)
        {
            server.Delimiter = 0x13;//enter
            server.StringEncoder = Encoding.UTF8;
        }
    }
}

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
using NAudio.Wave;
using VarispeedDemo.SoundTouch;

namespace TTTF_Launcher
{
    public partial class launcher : Form
    {
        Dictionary<string,soundplayer> soundList;

        public launcher()
        {
            InitializeComponent();
            scriptmanager.Interval = 500;
            scriptmanager.Start();
            Closing += OnMainFormClosing;
            soundList = new Dictionary<string, soundplayer>();
            soundList.Add("test",new soundplayer(false));
            comboBoxModes.Items.Add("Speed");
            comboBoxModes.Items.Add("Tempo");
            comboBoxModes.SelectedIndex = 0;
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            int max = 0;
            soundList["test"].LoadFile(comboBoxModes.SelectedIndex == 1, out max);
            DisplayPosition();
            trackBarPlaybackPosition.Value = 0;
            trackBarPlaybackPosition.Maximum = max;
        }

        private void OnMainFormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            soundList["test"].remove();
            soundList.Remove("test");
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            soundList["test"].Play();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            soundList["test"].Stop();
        }

        private void DisplayPosition()
        {
            labelPosition.Text = soundList["test"].currentTime(true);
        }

        private void trackBarPlaybackPosition_Scroll(object sender, EventArgs e)
        {
            soundList["test"].playBackPosition(trackBarPlaybackPosition.Value);
        }

        private void comboBoxModes_SelectedIndexChanged(object sender, EventArgs e)
        {
            soundList["test"].Modes(comboBoxModes.SelectedIndex == 1);
        }

        private void trackBarPlaybackRate_Scroll(object sender, EventArgs e)
        {
            labelPlaybackSpeed.Text = soundList["test"].playBackRate(0.5f + trackBarPlaybackRate.Value * 0.1f);
        }

        #region server
        SimpleTCP.SimpleTcpServer server = new SimpleTCP.SimpleTcpServer();
        
        private void launch_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Application.StartupPath + "\\..\\PlayGTAV.exe");
            activitylist.Items.Add("Waiting for BTTF time travel 0.9.0.dll to respond.");
            server.DataReceived += server_data;
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            server.Start(ip, 10757);
        }
        
        private void server_data(object sender, SimpleTCP.Message e)
        {
            string message = e.MessageString.Substring(0, e.MessageString.Count() - 1);
            activitylist.Items.Add("M: " + message);
            string[] temp = message.Split('!');
            try
            {
                activitylist.Items.Add("Message: " + temp[0]);
                activitylist.Items.Add("Message: " + temp[1]);
                activitylist.Items.Add("Message: " + temp[2]);
            }
            catch
            {

            }
            if (message.Contains("script running"))
            {
                e.ReplyLine("Launcher running");
                return;
            }

            if (message.StartsWith("vol"))
            {
                soundList[temp[1].Trim()].Volume(float.Parse(temp[2].Trim()));
                return;
            }

            if (message.StartsWith("Play"))
            {
                soundList[temp[1].Trim()].Play();
                activitylist.Items.Add("Playing " + temp[1].Trim());
                return;
            }

            if (message.StartsWith("Stop"))
            {
                soundList[temp[1].Trim()].Stop();
                soundList[temp[1].Trim()].playBackPosition(0);
                return;
            }

            if (message.StartsWith("Pause"))
            {
                soundList[temp[1].Trim()].pause();
                return;
            }

            if (message.StartsWith("Resume"))
            {
                soundList[temp[1].Trim()].resume();
                return;
            }

            if (message.StartsWith("new"))
            {
                try
                {
                    activitylist.Items.Add("new: " + temp[2]);
                    soundList.Add(temp[1],new soundplayer(bool.Parse(temp[2])));
                    soundList[temp[1]].LoadFile(false, out int i, temp[1]);
                    soundList[temp[1]].Play();
                    Thread.Sleep(1);
                    soundList[temp[1]].Stop();
                    activitylist.Items.Add("Loaded: " + temp[1].Split('\\')[temp[1].Split('\\').Count() - 1]);
                }
                catch (Exception f)
                {
                    activitylist.Items.Add("Error: " + f);
                }
                return;
            }

            if (message.StartsWith("time"))
            {
                try
                {
                    e.ReplyLine("soundposition:" + soundList[temp[1]].currentTime(false));
                }
                catch (Exception f)
                {
                    e.ReplyLine("Error: " + f);
                }
                return;
            }

            if (message.StartsWith("timeend"))
            {
                e.ReplyLine("totaltime:" + soundList[temp[1].Trim()].currentTime(false, true));
                return;
            }

            if (message.StartsWith("isplaying"))
            {
                activitylist.Items.Add("playing:" + temp[1]);
                try
                {
                    activitylist.Items.Add("playing:" + soundList[temp[1]].getPlayStateStopped().ToString());
                    e.ReplyLine("playing:" + soundList[temp[1]].getPlayState().ToString());    
                }
                catch (Exception f)
                {
                    activitylist.Items.Add(f);
                    e.ReplyLine("Error: " + f.Message);
                }
                return;
            }

            if (message.StartsWith("ispaused"))
            {
                e.ReplyLine("paused" + soundList[temp[1].Trim()].getPlayStatePaused());
                return;
            }

            if (message.StartsWith("isstopped"))
            {
                activitylist.Items.Add("stopped" + soundList[temp[1].Trim()].getPlayStateStopped().ToString());
                e.ReplyLine("stopped" + soundList[temp[1].Trim()].getPlayStateStopped().ToString());
                return;
            }

            if (message.StartsWith("settime"))
            {
                soundList[temp[1].Trim()].playBackPosition(int.Parse(temp[2].Trim()));
                return;
            }

            if (message.Contains("send animation (script)"))
            {
                e.ReplyLine("anim:" + root.Text + "," + animation.Text);
                activitylist.Items.Add("anim:" + root.Text + "," + animation.Text);
                return;
            }

            if (message.Contains("send saved display xy"))
            {
                int x = Properties.Settings.Default.TimeCircuitsDisplay.X;
                int y = Properties.Settings.Default.TimeCircuitsDisplay.Y;
                e.ReplyLine("change time display x: " + x + " y: " + y);
                return;
            }

            if (message.Contains("send display time"))
            {
                if (!Properties.Settings.Default.savedTime)
                {
                    setPresentTime();
                    Properties.Settings.Default.savedTime = true;
                    Properties.Settings.Default.Save();
                }
                else
                {
                    setPresentTime(Properties.Settings.Default.month1, Properties.Settings.Default.month2, Properties.Settings.Default.day1, Properties.Settings.Default.day2,
                        Properties.Settings.Default.y1, Properties.Settings.Default.y2, Properties.Settings.Default.y3, Properties.Settings.Default.y4,
                        Properties.Settings.Default.h1, Properties.Settings.Default.h2, Properties.Settings.Default.m1, Properties.Settings.Default.m2);
                }
                
                e.ReplyLine("time " + presmonth1 + "" + presmonth2 + "" + presday1 + "" + presday2 + "" + presy1 + "" + presy2 + "" + presy3 + "" + presy4 + "" + presh1 + "" + presh2 + "" + presm1 + "" + presm2);
                return;
            }

            if (message.Contains("save display time "))
            {
                char[] timestr = message.Remove(0, 18).ToArray();
                int[] time = new int[12];
                for (int i = 0; i < 12; i++)
                    time[i] = int.Parse(timestr[i] + "");

                setPresentTime(time[0], time[1], time[2], time[3], time[4], time[5], time[6], time[7], time[8], time[9], time[10], time[11]);
                return;
            }

            if (message.Contains("change time display "))
            {
                try
                {
                    string xy = message.Replace("change time display ", "");
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
                return;
            }

            if (message.Contains("Start tutorial (scene)"))
            {
                server.BroadcastLine("(scene) start tutorial");
                e.ReplyLine("Setting up scene");
                return;
            }
            activitylist.SelectedIndex = activitylist.Items.Count - 1;

            try
            {
                e.ReplyLine("Message does not match any choices. \n" + message);
            }
            catch
            {
            }
        }

        private void scriptmanager_Tick(object sender, EventArgs e)
        {
            try
            {
                trackBarPlaybackPosition.Value = soundList["test"].Tick();
                DisplayPosition();
            }
            catch (FileNotFoundException g)
            {
                activitylist.Items.Add("waiting while: " + g);
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

        public int presday1 = 1, presday2 = 0, presmonth1 = 0, presmonth2 = 9, presy1 = 1, presy2 = 9, presy3 = 9, presy4 = 5, presh1 = 0, presh2 = 6, presm1 = 1, presm2 = 1;

        private void getdigit_Click(object sender, EventArgs e)
        {
            int num = int.Parse(number.Text);
            int d3 = (num % 100) / 10;
            int d4 = (num % 10);

            MessageBox.Show(d3 + " " + d4);

        }

        private void clear_Click(object sender, EventArgs e)
        {
            activitylist.Items.Clear();
        }

        public string presampm = "pm";
        public void setPresentTime()
        {
            DateTime.Now.ToString("yyyy-MM-ddTHH:mm:sszzz");

            presmonth1 = int.Parse(DateTime.Now.ToString("MM").Substring(0,1));
            presmonth2 = int.Parse(DateTime.Now.ToString("MM").Substring(1));
            presday1 = int.Parse(DateTime.Now.ToString("dd").Substring(0,1));
            presday2 = int.Parse(DateTime.Now.ToString("dd").Substring(1));
            presy1 = int.Parse(DateTime.Now.ToString("yyyy").Substring(0, 1));
            presy2 = int.Parse(DateTime.Now.ToString("yyyy").Substring(1, 1));
            presy3 = int.Parse(DateTime.Now.ToString("yyyy").Substring(2, 1));
            presy4 = int.Parse(DateTime.Now.ToString("yyyy").Substring(3));
            presh1 = int.Parse(DateTime.Now.ToString("HH").Substring(0, 1));
            presh2 = int.Parse(DateTime.Now.ToString("HH").Substring(1));
            presm1 = int.Parse(DateTime.Now.ToString("mm").Substring(0, 1));
            presm2 = int.Parse(DateTime.Now.ToString("mm").Substring(1));
            Properties.Settings.Default.month1 = int.Parse(DateTime.Now.ToString("MM").Substring(0, 1));
            Properties.Settings.Default.month2 = int.Parse(DateTime.Now.ToString("MM").Substring(1));
            Properties.Settings.Default.day1 = int.Parse(DateTime.Now.ToString("dd").Substring(0, 1));
            Properties.Settings.Default.day2 = int.Parse(DateTime.Now.ToString("dd").Substring(1));
            Properties.Settings.Default.y1 = int.Parse(DateTime.Now.ToString("yyyy").Substring(0, 1));
            Properties.Settings.Default.y2 = int.Parse(DateTime.Now.ToString("yyyy").Substring(1, 1));
            Properties.Settings.Default.y3 = int.Parse(DateTime.Now.ToString("yyyy").Substring(2, 1));
            Properties.Settings.Default.y4 = int.Parse(DateTime.Now.ToString("yyyy").Substring(3));
            Properties.Settings.Default.h1 = int.Parse(DateTime.Now.ToString("HH").Substring(0, 1));
            Properties.Settings.Default.h2 = int.Parse(DateTime.Now.ToString("HH").Substring(1));
            Properties.Settings.Default.m1 = int.Parse(DateTime.Now.ToString("mm").Substring(0, 1));
            Properties.Settings.Default.m2 = int.Parse(DateTime.Now.ToString("mm").Substring(1));

            //MessageBox.Show("Time: " + presmonth1 + "" + presmonth2 + " : " + presday1 + "" + presday2 + " : " + presy1 + " " + presy2 + " " + presy3 + " " + presy4 + " " + presh1 + " " + presh2 + " " + presm1 + " " + presm2);
        }
        public void setPresentTime(int month1, int month2, int day1, int day2, int y1, int y2, int y3, int y4, int h1, int h2, int m1, int m2)
        {
            presmonth1 = month1;
            presmonth2 = month2;
            presday1 = day1;
            presday2 = day2;
            presy1 = y1;
            presy2 = y2;
            presy3 = y3;
            presy4 = y4;
            presh1 = h1;
            presh2 = h2;
            presm1 = m1;
            presm2 = m2;
            Properties.Settings.Default.month1 = month1;
            Properties.Settings.Default.month2 = month2;
            Properties.Settings.Default.day1 = day1;
            Properties.Settings.Default.day2 = day2;
            Properties.Settings.Default.y1 = y1;
            Properties.Settings.Default.y2 = y2;
            Properties.Settings.Default.y3 = y3;
            Properties.Settings.Default.y4 = y4;
            Properties.Settings.Default.h1 = h1;
            Properties.Settings.Default.h2 = h2;
            Properties.Settings.Default.m1 = m1;
            Properties.Settings.Default.m2 = m2;

            //MessageBox.Show("Time: " + presmonth1 + "" + presmonth2 + " : " + presday1 + "" + presday2 + " : " + presy1 + " " + presy2 + " " + presy3 + " " + presy4 + " " + presh1 + " " + presh2 + " " + presm1 + " " + presm2);
        }
        private void launcher_Load(object sender, EventArgs e)
        {
            server.Delimiter = 0x13;//enter
            server.StringEncoder = Encoding.UTF8;
            System.Diagnostics.Process[] temp = System.Diagnostics.Process.GetProcessesByName("GTA5");
            activitylist.Items.Add("");
            foreach (System.Diagnostics.Process i in temp)
            {
                activitylist.Items.Add("Waiting for BTTF time travel 0.9.0.dll to respond.");
                server.DataReceived += server_data;
                IPAddress ip = IPAddress.Parse("127.0.0.1");
                server.Start(ip, 10757);
            }
        }
        #endregion
    }
}

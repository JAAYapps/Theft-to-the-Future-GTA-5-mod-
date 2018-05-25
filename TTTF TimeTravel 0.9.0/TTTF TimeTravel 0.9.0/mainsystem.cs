using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GTA;
using GTA.Native;

namespace TTTF_TimeTravel_0._9._0
{
    public class mainsystem : Script
    {
        public mainsystem()
        {
            try
            {
                //Game.FadeScreenIn(500);
                Interval = 0;
                Tick += onTick;
                KeyUp += onKeyUp;
                KeyDown += onKeyDown;
                Aborted += onClose;
                //loadscriptsettings();
                Task.Factory.StartNew(() => { Sounds.initialLoad(); }); 
            }
            catch (Exception e)
            {
                while (true)
                {
                    UI.ShowSubtitle(e.Message);
                    Wait(10);
                }
            }
        }

        private void onClose(object sender, EventArgs e)
        {
            UI.ShowSubtitle("Closing TTTF");
            if (client.TcpClient.Connected)
                client.Disconnect();
            Sounds.unLoad();
            Wait(5000);
        }

        Point tempxy = new Point(0,0);
        private void onKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (displaysystem.Displayadjustment)
                {
                    if (e.KeyCode == Keys.Up)
                    {
                        tempxy.Y = tempxy.Y - 10;
                    }
                    if (e.KeyCode == Keys.Down)
                    {
                        tempxy.Y = tempxy.Y + 10;
                    }
                    if (e.KeyCode == Keys.Left)
                    {
                        tempxy.X = tempxy.X - 10;
                    }
                    if (e.KeyCode == Keys.Right)
                    {
                        tempxy.X = tempxy.X + 10;
                    }
                    if (e.KeyCode == Keys.Enter)
                    {
                        displaysystem.Displayadjustment = false;
                        client.WriteLineAndGetReply("change time display x: " + tempxy.X + " y: " + tempxy.Y, new TimeSpan(0, 0, 30));
                        TTTF.Show();
                    }
                    displaysystem.change_time_display_location(tempxy.X, tempxy.Y);
                }
                if (e.KeyCode == Keys.ShiftKey)
                {
                    if (Game.Player.Character.CurrentVehicle != null)
                    {
                        if (Game.Player.Character.CurrentVehicle.Model == "BTTF2F")
                        {
                            if (Game.Player.Character.CurrentVehicle.Acceleration < 0.3f)
                                Game.Player.Character.CurrentVehicle.ApplyForceRelative(new GTA.Math.Vector3(0, (float)1.8, 0));
                            if (Sounds.hoverboost.gettime() == 0)
                            {
                                Sounds.hoverboost.Play();
                            }
                        }
                    }
                }
                else if (e.KeyCode == Keys.Space)
                {
                    if (Game.Player.Character.CurrentVehicle != null)
                    {
                        if (Game.Player.Character.CurrentVehicle.Model == "BTTF2F")
                        {
                            if (Game.Player.Character.CurrentVehicle.Acceleration < 0.3f)
                                Game.Player.Character.CurrentVehicle.ApplyForceRelative(new GTA.Math.Vector3(0, (float)-1.8, 0));
                            if (Sounds.hoverup.gettime() == 0)
                            {
                                Sounds.hoverup.Play();
                            }
                        }
                    }
                }
                //UI.ShowSubtitle("Key: " + e.KeyCode.ToString());
            }
            catch
            {

            }
        }

        static TTTFmenu TTTF;
        private void onKeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.H)
                {
                    //TimeTravel.startMalfunction();
                }
                else if (e.KeyCode == Keys.F5)
                {
                    TTTF.Show();
                }
                else if (e.KeyCode.ToString() == "ControlKey")
                {
                    if (Game.Player.Character.IsInVehicle(timecurcuitssystem.bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].getDelorean()))
                        timecurcuitssystem.Toggleflight();
                }
                else if (e.KeyCode == Keys.Space)
                {
                    if (Sounds.hoverboost.gettimeend())
                    {
                        Sounds.hoverboost.Stop();
                    }
                }
                else if (e.KeyCode.ToString() == "ControlKey")
                {
                    if (Sounds.hoverup.gettimeend())
                    {
                        Sounds.hoverup.Stop();
                    }
                }
                else if (e.KeyCode == Keys.Oemplus || e.KeyCode == Keys.Add)
                {
                    timecurcuitssystem.switchCircuits();
                }
                else if (e.KeyCode == Keys.Subtract || e.KeyCode == Keys.OemMinus)
                {
                    timecurcuitssystem.ToggleMrfusion(Game.Player.Character);
                }

                if (Game.Player.Character.IsInVehicle(timecurcuitssystem.bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].getDelorean()) && !TTTF.myMenu.Visible)
                {
                    timecurcuitssystem.keyset(e.KeyCode);
                }
            }
            catch
            {

            }
        }


        public static bool checkifConnectedToLauncher()
        {
            return servconnected;
        }
        public static void setConnection(bool connection)
        {
            connectstart = connection;
        }
        bool initial = false;
        static bool servconnected = false;
        static bool speakerror = false;
        static bool connectstart = false;
        static bool connection_success = false;
        bool R = false;
        bool C = false;
        bool rcenable = false;
        private void onTick(object sender, EventArgs e)
        {
            string rooterror = "";
            try
            {
                if (!Game.IsLoading)
                {
                    rooterror = "initial";
                    if (!initial)
                    {
                        rooterror = "bus check";
                        foreach (Vehicle v in World.GetAllVehicles())
                        {
                            if (v.Model == VehicleHash.Bus)
                            {
                                v.Delete();
                            }
                            Wait(10);
                        }
                        rooterror = "Game.Player.CanControlCharacter";
                        Game.Player.CanControlCharacter = true;
                        if (Game.Player.Character.IsInVehicle())
                        {
                            Game.Player.Character.CurrentVehicle.IsVisible = true;
                        }
                        rooterror = "connectionstart";
                        try
                        {
                            TTTF = new TTTFmenu();
                            rooterror = "connectionstart begining";
                            if (!connectstart)
                            {
                                rooterror = "new simpleTCP";
                                client = new SimpleTCP.SimpleTcpClient();
                                rooterror = "Encode";
                                client.StringEncoder = Encoding.UTF8;
                                rooterror = "datareceived";
                                client.DataReceived += luancherdata;
                                rooterror = "connect to launcher";
                                client.Connect("127.0.0.1", 10757);
                                rooterror = "WriteLine";
                                client.WriteLineAndGetReply("script running", new TimeSpan(0, 0, 20));
                                rooterror = "connectionstart true";
                                connectstart = true;
                            }
                            rooterror = "new TTTF";
                            
                        }
                        catch
                        {

                        }


                        rooterror = "if sever connect";
                        if (!servconnected)
                        {
                            if (speakerror)
                                UI.ShowSubtitle("Run Process the Theft To The Future launcher to communicate with the other scripts.");
                            speakerror = true;
                        }
                        initial = true;
                    }

                    rooterror = "TTTF on tick";
                    TTTF.OnTick();
                    try
                    {
                        if (Game.Player.Character.IsInVehicle())
                            if (Game.Player.Character.CurrentVehicle.FriendlyName == new Model("dmc12"))
                            {
                                Game.Player.Character.CurrentVehicle.CanBeVisiblyDamaged = !TTTF.invincible;
                                Game.Player.Character.CurrentVehicle.IsInvincible = TTTF.invincible;
                            }
                    }
                    catch
                    {
                        
                    }
                    Libeads.tick();
                    helpFromDoc.tick();
                    Traveler.tick();
                    DeloreanManagement.tick();

                    try
                    {
                        //UI.ShowSubtitle("Velocity: " + Game.Player.Character.CurrentVehicle.DisplayName);
                    }
                    catch
                    {

                    }
                    
                    R = Game.IsKeyPressed(Keys.R);
                    C = Game.IsKeyPressed(Keys.C);

                    if (R && C)
                    {
                        if (!rcenable)
                        {
                            TTTF.quickRC();
                            rcenable = true;
                        }
                    }
                    else
                    {
                        rcenable = false;
                    }

                    if (servconnected)
                    {
                        if (!connection_success)
                        {
                            if (Sounds.Intro.getPlayStateStopped())
                            {
                                Sounds.Intro.Play();
                            }
                            client.WriteLineAndGetReply("send saved display xy", new TimeSpan(0,0,30));
                            connection_success = true;
                        }





                        //if (Properties.Settings.Default.presday1 == 2 && Properties.Settings.Default.presday2 == 9 && Properties.Settings.Default.presmonth1 == 0 && Properties.Settings.Default.presmonth2 == 4 && Properties.Settings.Default.presy1 == 1 && Properties.Settings.Default.presy2 == 9 && Properties.Settings.Default.presy3 == 9 && Properties.Settings.Default.presy4 == 2)
                        //{
                        //    riot();
                        //}
                        //else if (Properties.Settings.Default.presday1 == 3 && Properties.Settings.Default.presday2 == 0 && Properties.Settings.Default.presmonth1 == 0 && Properties.Settings.Default.presmonth2 == 4 && Properties.Settings.Default.presy1 == 1 && Properties.Settings.Default.presy2 == 9 && Properties.Settings.Default.presy3 == 9 && Properties.Settings.Default.presy4 == 2)
                        //{
                        //    riot();
                        //}
                        //else if (Properties.Settings.Default.presday1 == 0 && Properties.Settings.Default.presday2 == 1 && Properties.Settings.Default.presmonth1 == 0 && Properties.Settings.Default.presmonth2 == 5 && Properties.Settings.Default.presy1 == 1 && Properties.Settings.Default.presy2 == 9 && Properties.Settings.Default.presy3 == 9 && Properties.Settings.Default.presy4 == 2)
                        //{
                        //    riot();
                        //}
                        //else if (Properties.Settings.Default.presday1 == 0 && Properties.Settings.Default.presday2 == 2 && Properties.Settings.Default.presmonth1 == 0 && Properties.Settings.Default.presmonth2 == 5 && Properties.Settings.Default.presy1 == 1 && Properties.Settings.Default.presy2 == 9 && Properties.Settings.Default.presy3 == 9 && Properties.Settings.Default.presy4 == 2)
                        //{
                        //    riot();
                        //}
                        //else if (Properties.Settings.Default.presday1 == 0 && Properties.Settings.Default.presday2 == 3 && Properties.Settings.Default.presmonth1 == 0 && Properties.Settings.Default.presmonth2 == 5 && Properties.Settings.Default.presy1 == 1 && Properties.Settings.Default.presy2 == 9 && Properties.Settings.Default.presy3 == 9 && Properties.Settings.Default.presy4 == 2)
                        //{
                        //    riot();
                        //}
                        //else if (Properties.Settings.Default.presday1 == 0 && Properties.Settings.Default.presday2 == 4 && Properties.Settings.Default.presmonth1 == 0 && Properties.Settings.Default.presmonth2 == 5 && Properties.Settings.Default.presy1 == 1 && Properties.Settings.Default.presy2 == 9 && Properties.Settings.Default.presy3 == 9 && Properties.Settings.Default.presy4 == 2)
                        //{
                        //    riot();
                        //}
                    }
                }
            }
            catch (Exception d)
            {
                UIText debug2 = new UIText("object: " + d.TargetSite + " location: " + d.StackTrace + " Error: " + d.Message, new System.Drawing.Point(100, 50), (float)0.6);
                debug2.Draw();
                UIText debug = new UIText("location: " + d.StackTrace, new System.Drawing.Point(100, 200), (float)0.6);
                debug.Draw();
                UIText debug3 = new UIText("Error: " + d.Message, new System.Drawing.Point(100, 350), (float)0.6);
                debug3.Draw();
                UIText debug4 = new UIText("Root Error: " + rooterror, new System.Drawing.Point(100, 500), (float)0.6);
                debug4.Draw();
                UI.ShowSubtitle(d.Message);
            }


            
            if (display_errors)
            {
                UIText debug2 = new UIText(messageerrors[0], new System.Drawing.Point(100, 50), (float)0.6);
                debug2.Draw();
                UIText debug = new UIText(messageerrors[1], new System.Drawing.Point(100, 200), (float)0.6);
                debug.Draw();
                UIText debug3 = new UIText(messageerrors[2], new System.Drawing.Point(100, 350), (float)0.6);
                debug3.Draw();
                UIText debug4 = new UIText(messageerrors[3], new System.Drawing.Point(100, 500), (float)0.6);
                debug4.Draw();
            }
        }
        public static string[] messageerrors = new string[4];
        public static bool display_errors = false;

        public static SimpleTCP.SimpleTcpClient client;
        void connection()
        {
            if (!connectstart)
            {
                client = new SimpleTCP.SimpleTcpClient();
                client.StringEncoder = Encoding.UTF8;
                client.DataReceived += luancherdata;
                client.Connect("127.0.0.1", 10757);
                client.WriteLineAndGetReply("script running", new TimeSpan(0, 0, 20));
                connectstart = true;
            }
        }

        public static void luancherdata(object sender, SimpleTCP.Message e)
        {
            UI.ShowSubtitle("responce:" + e.MessageString);
            if (e.MessageString.Contains("Launcher running"))
            {
                servconnected = true;
            }

            try
            {
                if (e.MessageString.Contains("change time display "))
                {
                    string xy = e.MessageString.Replace("change time display ", "");
                    string xystring = xy.Replace("x: ", "").Replace(" y: ", ","); //x: " + x + " y: " + y
                    int x = int.Parse(xystring.Substring(0, xystring.IndexOf(",")));
                    int y = int.Parse(xystring.Substring(xystring.IndexOf(',') + 1, (xystring.LastIndexOf(xystring.Last())) - (xystring.IndexOf(',') + 1)));
                    displaysystem.change_time_display_location(x, y);
                }

                if (e.MessageString.Contains("anim:"))
                {
                    string anim = e.MessageString.Replace("anim:", "");
                    TTTF.root = anim.Substring(0, anim.IndexOf(','));
                    TTTF.effect = anim.Substring(anim.IndexOf(',') + 1, (anim.LastIndexOf(anim.Last())) - (anim.IndexOf(',') + 1));
                }
            }
            catch (Exception d)
            {
                messageerrors[0] = "object: " + d.TargetSite + " location: " + d.StackTrace + " Error: " + d.Message;
                messageerrors[1] = "location: " + d.StackTrace;
                messageerrors[2] = "Error: " + d.Message;
                messageerrors[3] = "Root Error: " + d.InnerException;
                UI.ShowSubtitle(d.Message);
                display_errors = true;
            }
        }
    }
}

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
                Interval = 2;
                Tick += onTick;
                KeyUp += onKeyUp;
                KeyDown += onKeyDown;
                //Aborted += onClose;

                //this is the hover mode
                //Function.Call((Hash)0xD138FA15C9776837, Game.Player.Character.CurrentVehicle, 1f);
                //Function.Call((Hash)0x438b3d7ca026fe91, Game.Player.Character.CurrentVehicle.Handle, 1f);
                //loadscriptsettings();
            }
            catch (Exception e)
            {
                Tick += errorTick;
                initError = e;
            }
        }

        Exception initError = null;
        private void errorTick(object sender, EventArgs e)
        {
            try
            {
                UI.ShowSubtitle(initError.Message);
            }
            catch
            {

            }
        }

        private void onClose(object sender, EventArgs e)
        {
            try
            {
                UI.ShowSubtitle("Closing TTTF");
                if (client.TcpClient.Connected)
                    client.Disconnect();
                Sounds.unLoad();
                foreach (KeyValuePair<string, PropManager> item in timecurcuitssystem.effectProps)
                {
                    item.Value.removeWormhole();
                    Wait(10);
                }
                timecurcuitssystem.effectProps.Clear();
            }
            catch 
            {

            }
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
                else if (e.KeyCode == Keys.Insert)
                {
                    Sounds.unLoad();
                    foreach (string car in timecurcuitssystem.bttfList.Keys)
                        timecurcuitssystem.effectProps[car].removeWormhole();
                }
                //UI.ShowSubtitle("Key: " + e.KeyCode.ToString());
            }
            catch
            {

            }
        }

        public static TTTFmenu TTTF;
        PropManager icetest = new PropManager();
        private void onKeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.R)
                {
                    //TimeTravel.startMalfunction();
                    icetest.SpawnProp(Game.Player.Character.CurrentVehicle, "bttf_icebody", "chassis", new GTA.Math.Vector3(0, 0, 0), new GTA.Math.Vector3(0, 0, 0));
                }
                if (e.KeyCode == Keys.T)
                {
                    icetest.ice.Alpha++;
                }
                if (e.KeyCode == Keys.G)
                {
                    icetest.ice.Alpha--;
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

        bool initial = false;
        static bool servTime = false;
        //static bool speakerror = false;
        //static bool connectstart = false;
        public static bool connection_success = false;
        bool R = false;
        bool C = false;
        bool rcenable = false;
        private void onTick(object sender, EventArgs e)
        {
            try
            {
                if (!Game.IsLoading)
                {
                    if (!initial)
                    {
                        foreach (Vehicle v in World.GetAllVehicles())
                        {
                            if (v.Model == VehicleHash.Bus)
                            {
                                v.Delete();
                            }
                            Wait(10);
                        }
                        Game.Player.CanControlCharacter = true;
                        if (Game.Player.Character.IsInVehicle())
                        {
                            Game.Player.Character.CurrentVehicle.IsVisible = true;
                        }
                        try
                        {
                            client = new SimpleTCP.SimpleTcpClient();
                            client.StringEncoder = Encoding.UTF8;
                            //client.DataReceived += luancherdata;
                            client.Connect("127.0.0.1", 10757);
                            UI.Notify("Connection: " + client.TcpClient.Connected);
                            string launcher = client.WriteLineAndGetReply("script running", new TimeSpan(0, 0, 1)).MessageString;

                            if (launcher.Contains("Launcher running"))
                            {
                                Sounds.initialLoad(true);
                                if (Sounds.Intro.getPlayState())
                                {
                                    Sounds.Intro.Play();
                                }
                                ResponceList(client.WriteLineAndGetReply("send saved display xy", new TimeSpan(0, 0, 30)).MessageString);
                                
                                connection_success = true;

                                if (servTime)
                                {
                                    ResponceList(client.WriteLineAndGetReply("send display time", new TimeSpan(0, 0, 30)).MessageString);
                                    servTime = false;
                                }
                            }
                            else
                            {

                            }

                            //rooterror = "connectionstart begining";
                            //if (!connectstart)
                            //{
                            //    Wait(10);
                            //    rooterror = "new simpleTCP";
                            //    client = new SimpleTCP.SimpleTcpClient();
                            //    Wait(10);
                            //    rooterror = "Encode";
                            //    client.StringEncoder = Encoding.UTF8;
                            //    Wait(10);
                            //    rooterror = "datareceived";
                            //    client.DataReceived += luancherdata;
                            //    Wait(10);
                            //    rooterror = "connect to launcher";
                            //    client.Connect("127.0.0.1", 10757);
                            //    Wait(10);
                            //    rooterror = "WriteLine";
                            //    connectstart = true;
                            //    client.WriteLineAndGetReply("script running", new TimeSpan(0, 0, 20));
                            //    rooterror = "connectionstart true";
                            //    Wait(10);
                            //}
                            //rooterror = "new TTTF";
                        }
                        catch (Exception f)
                        {
                            try
                            {
                                UI.Notify(f.Message);
                                UI.Notify("load sounds");
                                Sounds.initialLoad(false);
                                UI.Notify("check if not playing");
                                if (Sounds.Intro.getPlayStateStopped())
                                {
                                    UI.Notify("play");
                                    Sounds.Intro.Play();
                                    UI.Notify("No connection to laucher");
                                }
                            }
                            catch ( Exception g)
                            {
                                int count = 0;
                                Sounds.unLoad();
                                while (count < 100)
                                {
                                    UI.Notify(g.Message);
                                    UI.Notify(g.StackTrace);
                                    UI.Notify(g.TargetSite.Name);
                                    UI.Notify(g.ToString());
                                    Wait(10);
                                }
                            }
                        }
                        TTTF = new TTTFmenu();
                        initial = true;
                    }

                    try
                    {
                        TTTF.OnTick();

                        if (Game.Player.Character.IsInVehicle())
                            if (Game.Player.Character.CurrentVehicle.FriendlyName == new Model("dmc12"))
                            {
                                Game.Player.Character.CurrentVehicle.CanBeVisiblyDamaged = !TTTF.invincible;
                                Game.Player.Character.CurrentVehicle.IsInvincible = TTTF.invincible;
                                Game.Player.Character.CurrentVehicle.EngineCanDegrade = !TTTF.invincible;              
                            }

                        //UI.ShowSubtitle("Is in flying vehicle: " + Function.Call<bool>(Hash.IS_PED_IN_FLYING_VEHICLE, Game.Player.Character));
                    }
                    catch
                    {

                    }
                    Libeads.tick();
                    helpFromDoc.tick();
                    Traveler.tick();
                    DeloreanManagement.tick();
                    
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
            catch (Exception d)
            {
                try
                {
                    UIText debug2 = new UIText("object: " + d.TargetSite + " location: " + d.StackTrace + " Error: " + d.Message, new System.Drawing.Point(100, 50), (float)0.6);
                    debug2.Draw();
                    UIText debug = new UIText("location: " + d.StackTrace, new System.Drawing.Point(100, 200), (float)0.6);
                    debug.Draw();
                    UIText debug3 = new UIText("Error: " + d.Message, new System.Drawing.Point(100, 350), (float)0.6);
                    debug3.Draw();
                }
                catch
                {

                }

                Sounds.unLoad();
                while (true)
                {
                    UI.Notify(d.Message);
                    UI.Notify(d.StackTrace);
                    UI.Notify(d.TargetSite.Name);
                    UI.Notify(d.ToString());
                    Wait(10);
                }
            }
        }

        public static SimpleTCP.SimpleTcpClient client;

        public static void ResponceList(string message)
        {
            try
            {
                if (message.Contains("change time display "))
                {
                    string xy = message.Replace("change time display ", "");
                    string xystring = xy.Replace("x: ", "").Replace(" y: ", ","); //x: " + x + " y: " + y
                    int x = int.Parse(xystring.Substring(0, xystring.IndexOf(",")));
                    int y = int.Parse(xystring.Substring(xystring.IndexOf(',') + 1, (xystring.LastIndexOf(xystring.Last())) - (xystring.IndexOf(',') + 1)));
                    displaysystem.change_time_display_location(x, y);
                }

                if (message.Contains("time "))
                {
                    char[] timestr = message.Remove(0, 5).ToArray();
                    int[] time = new int[12];
                    for (int i = 0; i < 12; i++)
                        time[i] = int.Parse(timestr[i] + "");
                    DeloreanManagement.setPresentTime(time[0], time[1], time[2], time[3], time[4], time[5], time[6], time[7]);
                    Function.Call(Hash.SET_CLOCK_TIME, ((time[8] * 10) + time[9]), ((time[10] * 10) + time[11]), 0);
                }

                if (message.Contains("anim:"))
                {
                    string anim = message.Replace("anim:", "");
                    TTTF.root = anim.Substring(0, anim.IndexOf(','));
                    TTTF.effect = anim.Substring(anim.IndexOf(',') + 1, (anim.LastIndexOf(anim.Last())) - (anim.IndexOf(',') + 1));
                }
            }
            catch
            {

            }
        }

        public static void luancherdata(object sender, SimpleTCP.Message e)
        {
            UI.Notify("responce: " + e.MessageString);
            if (e.MessageString.Contains("Launcher running"))
            {

            }
        }
    }
}

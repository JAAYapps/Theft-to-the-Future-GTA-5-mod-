using GTA;
using GTA.Math;
using GTA.Native;
using NativeUI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TTTF_TimeTravel_0._9._0
{
    public class TTTFmenu
    {
        private MenuPool _myMenuPool = new MenuPool();
        public UIMenu myMenu = new UIMenu("Theft to the Future", "Mod Menu");
        UIMenu coop = new UIMenu("Co-op menu", "Co-op Menu");
        UIMenu debuginfo = new UIMenu("Debug info", "Debuging menu");
        string[] soundsFolder = Directory.GetFiles(Sounds.sounds);
        public bool invincible = false, beepsound = false, fluxsoundbool = false;
        public static bool RCmode = false;
        public bool animationTest = false;
        public string root = "";
        public string effect = "";

        void setDebugmenu()
        {
            debuginfo.AddItem(new UIMenuItem("Door debug"));
            debuginfo.AddItem(new UIMenuItem("Sound Test"));
            debuginfo.AddItem(new UIMenuItem("FPS on time display dash"));
            debuginfo.AddItem(new UIMenuItem("Exit"));
            debuginfo.RefreshIndex();
        }

        public TTTFmenu()
        {
            if (File.Exists("Scripts\\menu images\\THEFT-FUTURE-LOGO-BLACK.png"))
            {
                myMenu.SetBannerType("Scripts\\menu images\\THEFT-FUTURE-LOGO-BLACK.png");
            }
            setmenu(false);
            setDebugmenu();
            setCoOp();

            debuginfo.OnItemSelect += debugItemSelectHandler;
            debuginfo.OnListChange += itemChange;
            myMenu.OnCheckboxChange += (sender, item, checked_) =>
            {
                if (item.Text == "invincibility")
                {
                    invincible = checked_;
                }

                if (item.Text == "Collom Beep")
                    beepsound = checked_;

                if (item.Text == "Flux Sound")
                    fluxsoundbool = checked_;
            };
            myMenu.OnItemSelect += ItemSelectHandler;
            coop.OnItemSelect += coopselect;
            _myMenuPool.Add(myMenu);
            _myMenuPool.Add(coop);
            _myMenuPool.Add(debuginfo);
        }

        private void coopselect(UIMenu sender, UIMenuItem selectedItem, int index)
        {
            if (selectedItem.Text == "Run as Host")
            {
                Host();
            }
            else if (selectedItem.Text == "Run as Client")
            {
                client();
            }
            else if (selectedItem.Text == "Connect")
            {
                Client.start(ipaddress);
            }
            else if (selectedItem.Text.Contains("IP Address"))
            {
                ipaddress = Game.GetUserInput(WindowTitle.CELL_EMAIL_BOD, ipaddress, 15);
            }
            else if (selectedItem.Text.Contains("Port"))
            {
                port = Game.GetUserInput(15);
            }
            else if (selectedItem.Text.Contains("Host on port"))
            {
                port = Game.GetUserInput(15);
            }
            else if (selectedItem.Text == "Back")
            {
                coop.Clear();
                setCoOp();
            }
            else if (selectedItem.Text == "Exit")
            {
                myMenu.Visible = true;
                coop.Visible = false;
            }
        }

        string ipaddress = "127.0.0.1";
        string port = "10757";
        void client()
        {
            coop.Clear();
            coop.AddItem(new UIMenuItem("Connect"));
            coop.AddItem(new UIMenuItem("IP Address: " + ipaddress));
            coop.AddItem(new UIMenuItem("Port: " + port));
            coop.AddItem(new UIMenuItem("Back"));
            coop.RefreshIndex();
        }

        void Host()
        {
            coop.Clear();
            coop.AddItem(new UIMenuItem("Connect"));
            coop.AddItem(new UIMenuItem("Host on port: " + port));
            coop.AddItem(new UIMenuItem("Back"));
            coop.RefreshIndex();
        }

        void setCoOp()
        {
            coop.AddItem(new UIMenuItem("Run as Host"));
            coop.AddItem(new UIMenuItem("Run as Client"));
            //coop.AddItem(new UIMenuCheckboxItem("", ));
            coop.AddItem(new UIMenuItem("Exit"));
            coop.RefreshIndex();
        }

        public void setmenu(bool clear)
        {
            if (clear)
                myMenu.Clear();
            if (!mainsystem.connection_success)
            {
                myMenu.AddItem(new UIMenuItem("Connect to Launcher"));
            }
            myMenu.AddItem(new UIMenuItem("Play with friends"));
            myMenu.AddItem(new UIMenuItem("Spawn Delorean (DMC 12)"));
            myMenu.AddItem(new UIMenuItem("Spawn Delorean (DMC 12 Gold Edition)"));
            myMenu.AddItem(new UIMenuItem("Spawn Delorean (BTTF 1)"));
            myMenu.AddItem(new UIMenuItem("Spawn Delorean (BTTF 2)"));
            myMenu.AddItem(new UIMenuItem("Spawn Delorean (BTTF 3)"));
            myMenu.AddItem(new UIMenuItem("Spawn Delorean (BTTF 3 railroad)"));
            myMenu.AddItem(new UIMenuItem("Display Adjustment"));
            myMenu.AddItem(new UIMenuItem("Turn current car into a Time Machine"));
            myMenu.AddItem(new UIMenuItem("Remove Time Travel from current car"));
            myMenu.AddItem(new UIMenuItem("Delete car"));
            myMenu.AddItem(new UIMenuItem("Call Doc to repair Delorean"));
            myMenu.AddItem(new UIMenuCheckboxItem("invincibility", invincible));
            if (!RCmode)
            {
                myMenu.AddItem(new UIMenuItem("RC mode"));
            }
            else
            {
                myMenu.AddItem(new UIMenuItem("RC mode: " + rcmodel.Trim()));
            }
            myMenu.AddItem(new UIMenuCheckboxItem("Collom Beep", beepsound));
            myMenu.AddItem(new UIMenuCheckboxItem("Flux Sound", fluxsoundbool));
            myMenu.AddItem(new UIMenuItem("Play animation on player"));
            myMenu.AddItem(new UIMenuItem("Set Effect"));
            myMenu.AddItem(new UIMenuItem("Tutorial mode"));
            myMenu.AddItem(new UIMenuItem("Debugging"));
            myMenu.AddItem(new UIMenuItem("Exit"));
            myMenu.RefreshIndex();
        }

        string carmodel = "";
        public static string rcmodel = "";
        double movie = 0;
        public void ItemSelectHandler(UIMenu senderb, UIMenuItem selectedItem, int index)
        {
            if (selectedItem.Text == "Connect to Launcher")
            {
                try
                {
                    if (!mainsystem.connection_success)
                    {
                        System.Diagnostics.Process[] temp = System.Diagnostics.Process.GetProcessesByName("TTTF Launcher.exe");
                        bool running = false;
                        foreach (System.Diagnostics.Process i in temp)
                        {
                            running = true;
                        }

                        if (!running)
                        {
                            // Prepare the process to run
                            System.Diagnostics.ProcessStartInfo start = new System.Diagnostics.ProcessStartInfo();
                            // Enter in the command line arguments, everything you would enter after the executable name itself
                            start.Arguments = "";
                            // Enter the executable to run, including the complete path
                            start.FileName = (Application.StartupPath + "\\scripts\\TTTF Launcher.exe");
                            // Do you want to show a console window?
                            start.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                            start.CreateNoWindow = false;
                            // Run the external process & wait for it to finish
                            System.Diagnostics.Process proc = System.Diagnostics.Process.Start(start);
                            Script.Wait(3000);
                            UI.ShowSubtitle("Launcher running: " + proc.ProcessName);
                        }

                        if (!mainsystem.connection_success)
                        {
                            UI.ShowSubtitle("Run Process the Theft To The Future launcher to communicate with the other scripts.");
                        }

                        setmenu(true);
                    }
                }
                catch
                {

                }
            }
            if (selectedItem.Text == "Play with friends")
            {
                myMenu.Visible = false;
                coop.Visible = true;
            }
            else if (selectedItem.Text == "Play animation on player")
            {
                try
                {
                    mainsystem.client.WriteLineAndGetReply("send animation (script)", new TimeSpan(0, 0, 10));
                }
                catch
                {

                }
                Script.Wait(2000);
                Function.Call(Hash.REQUEST_ANIM_DICT, root);
                DateTime tmpTimeOut = DateTime.Now;
                if (root != "")
                {
                    Game.Player.Character.Task.PlayAnimation(root, effect);

                    while(!Function.Call<bool>(Hash.HAS_ANIM_DICT_LOADED, root))
                    {
                        Script.Wait(10);
                    }

                    if (Function.Call<bool>(Hash.HAS_ANIM_DICT_LOADED, root))
                    {
                        Function.Call(Hash.TASK_PLAY_ANIM, Game.Player.Character, root, effect, 8, (8 * -1), -1, 0, 0, false, false, false);
                        Script.Wait(50);
                        tmpTimeOut = DateTime.Now;
                        while ((DateTime.Now.Subtract(tmpTimeOut).TotalMilliseconds < 3000))
                        {
                            UI.ShowSubtitle(("Anim play time: " + Function.Call<double>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, Game.Player.Character, root, effect)));
                            Script.Wait(5);
                        }

                        UI.ShowSubtitle("Reset anim playback time to 0.1 and reduce play speed to 0.25", 5000);
                        Function.Call(Hash.SET_ENTITY_ANIM_CURRENT_TIME, Game.Player.Character, root, effect, 0.1);
                        Function.Call(Hash.SET_ENTITY_ANIM_SPEED, Game.Player.Character, root, effect, 0.25);
                        Script.Wait(5000);
                        UI.ShowSubtitle("End anim playback");
                        Function.Call(Hash.STOP_ANIM_TASK, Game.Player.Character, root, effect, 1);
                    }
                    else
                        UI.ShowSubtitle("Animation dictionary does not exist.");
                }
                else
                {
                    Function.Call(Hash.REQUEST_ANIM_DICT, "ah_1_mcs_1-0");
                    Vector3 animxyz = Game.Player.Character.Position;
                    Vector3 animrot = Game.Player.Character.Rotation;
                    Function.Call(Hash.TASK_PLAY_ANIM_ADVANCED, Game.Player.Character, "ah_1_mcs_1-0", "csb_janitor_dual-0", animxyz.X, animxyz.Y, animxyz.Z, animrot.X, animrot.Y, animrot.Z, 0.8f, 0.5, 6000, (int)AnimationFlags.UpperBodyOnly, 0.35f, false, false);
                
                    
                    tmpTimeOut = DateTime.Now;
                    while ((DateTime.Now.Subtract(tmpTimeOut).TotalMilliseconds < 8000))
                    {
                        UI.ShowSubtitle(("Anim play time: " + Function.Call<double>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, Game.Player.Character, "ah_1_mcs_1-0", "csb_janitor_dual-0")));
                        Script.Wait(5);
                    }
                    /*
                    UI.ShowSubtitle("Reset anim playback time to 0.1 and reduce play speed to 0.25", 5000);
                    Function.Call(Hash.SET_ENTITY_ANIM_CURRENT_TIME, Game.Player.Character, root, effect, 0.1);
                    Function.Call(Hash.SET_ENTITY_ANIM_SPEED, Game.Player.Character, root, effect, 0.25);
                    Script.Wait(5000);
                    UI.ShowSubtitle("End anim playback");
                    Function.Call(Hash.STOP_ANIM_TASK, Game.Player.Character, root, effect, 1);
                    */
                }

                
                
            }
            else if (selectedItem.Text == "Set Effect")
            {
                root = Game.GetUserInput(100);
                effect = Game.GetUserInput(100);
            }
            else if (selectedItem.Text == "Spawn Delorean (DMC 12)")
            {
                Model Deloreanmodel = new Model("DMC12");
                if (Deloreanmodel.IsValid)
                {
                    Vehicle Deloreon = null;

                    Vector3 position = Game.Player.Character.Position;

                    // At 90 degrees to the players heading
                    float heading = Game.Player.Character.Heading - 90;
                    while (Deloreon == null)
                    {
                        Deloreon = World.CreateVehicle(Deloreanmodel, position, heading);
                        Script.Wait(500);
                    }
                    Deloreon.Rotation = Game.Player.Character.Rotation;

                    Deloreon.DirtLevel = 0;
                    Deloreon.NumberPlate = "OutATime";
                    Deloreon.PlaceOnGround();
                    // Set the vehicle mods
                    Function.Call(Hash.SET_VEHICLE_MOD_KIT, Deloreon.Handle, 0);
                    Deloreon.ToggleMod(VehicleToggleMod.Turbo, true);
                    Deloreon.SetMod(VehicleMod.Horns, 16, true);
                    Game.Player.Character.Task.WarpIntoVehicle(Deloreon, VehicleSeat.Driver);
                    Deloreon.PrimaryColor = VehicleColor.BrushedAluminium;
                    Deloreon.SecondaryColor = VehicleColor.BrushedAluminium;
                }
            }
            else if (selectedItem.Text == "Spawn Delorean (DMC 12 Gold Edition)")
            {
                Model Deloreanmodel = new Model("DMC12");
                if (Deloreanmodel.IsValid)
                {
                    Vehicle Deloreon = null;

                    Vector3 position = Game.Player.Character.Position;

                    // At 90 degrees to the players heading
                    float heading = Game.Player.Character.Heading - 90;
                    while (Deloreon == null)
                    {
                        Deloreon = World.CreateVehicle(Deloreanmodel, position, heading);
                        Script.Wait(500);
                    }
                    Deloreon.Rotation = Game.Player.Character.Rotation;

                    Deloreon.DirtLevel = 0;
                    Deloreon.NumberPlate = "OutATime";
                    Deloreon.PlaceOnGround();
                    // Set the vehicle mods
                    Function.Call(Hash.SET_VEHICLE_MOD_KIT, Deloreon.Handle, 0);
                    Deloreon.ToggleMod(VehicleToggleMod.Turbo, true);
                    Deloreon.SetMod(VehicleMod.Horns, 16, true);
                    Game.Player.Character.Task.WarpIntoVehicle(Deloreon, VehicleSeat.Driver);
                    Deloreon.PrimaryColor = VehicleColor.BrushedGold;
                    Deloreon.SecondaryColor = VehicleColor.BrushedGold;
                }
            }
            else if (selectedItem.Text == "Rescue Cutscene")
            {
                spawn_delorean.spawn(new Model(carmodel), movie, true);
                setmenu(true);
                Show();
            }
            else if (selectedItem.Text == "Spawn Delorean")
            {
                spawn_delorean.spawn(new Model(carmodel), movie, false);
                setmenu(true);
                Show();
            }
            else if (selectedItem.Text == "Spawn Delorean (BTTF 1)")
            {
                myMenu.Clear();
                myMenu.AddItem(new UIMenuItem("Spawn Delorean"));
                myMenu.AddItem(new UIMenuItem("Rescue Cutscene"));
                myMenu.RefreshIndex();
                carmodel = "bttf_land";
                movie = 1;
            }
            else if (selectedItem.Text == "Spawn Delorean (BTTF 2)")
            {
                myMenu.Clear();
                myMenu.AddItem(new UIMenuItem("Spawn Delorean"));
                myMenu.AddItem(new UIMenuItem("Rescue Cutscene"));
                myMenu.RefreshIndex();
                carmodel = "bttf_air";
                movie = 2;
            }
            else if (selectedItem.Text == "Spawn Delorean (BTTF 3)")
            {
                myMenu.Clear();
                myMenu.AddItem(new UIMenuItem("Spawn Delorean"));
                myMenu.AddItem(new UIMenuItem("Rescue Cutscene"));
                myMenu.RefreshIndex();
                carmodel = "bttf_land";
                movie = 3;
            }
            else if (selectedItem.Text == "Spawn Delorean (BTTF 3 railroad)")
            {
                myMenu.Clear();
                myMenu.AddItem(new UIMenuItem("Spawn Delorean"));
                myMenu.AddItem(new UIMenuItem("Rescue Cutscene"));
                myMenu.RefreshIndex();
                carmodel = "bttf_land";
                movie = 3.5;
            }
            else if (selectedItem.Text == "Turn current car into a Time Machine")
            {
                timecurcuitssystem.addToList(Game.GetUserInput(7).ToUpper(), 0, Game.Player.Character.CurrentVehicle);
            }
            else if (selectedItem.Text == "Delete car")
            {
                try
                {
                    Delorean delorea = null;
                    if (timecurcuitssystem.bttfList.TryGetValue(Game.Player.Character.CurrentVehicle.NumberPlate.Trim(), out delorea))
                    {
                        if (timecurcuitssystem.bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].RCmode)
                        {
                            timecurcuitssystem.bttfList[rcmodel.Trim()].ToggleRCmode();
                            myMenu.Visible = false;
                            timecurcuitssystem.RemoveDelorean(rcmodel.Trim());
                            rcmodel = "";
                            RCmode = false;
                            setmenu(true);

                            Script.Wait(1000);
                        }
                        else
                        {
                            timecurcuitssystem.RemoveDelorean();
                        }
                    }
                }
                catch
                {

                }
            }
            else if (selectedItem.Text == "Remove Time Travel from current car")
            {
                try
                {
                    Delorean delorea = null;
                    if (timecurcuitssystem.bttfList.TryGetValue(Game.Player.Character.CurrentVehicle.NumberPlate.Trim(), out delorea))
                    {
                        if (timecurcuitssystem.bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].RCmode)
                        {
                            timecurcuitssystem.bttfList[rcmodel.Trim()].ToggleRCmode();
                            myMenu.Visible = false;
                            timecurcuitssystem.RemoveTimeCircuits(rcmodel.Trim());
                            rcmodel = "";
                            RCmode = false;
                            setmenu(true);
                            Script.Wait(100);
                        }
                        else
                        {
                            timecurcuitssystem.RemoveTimeCircuits();
                        }
                    }
                }
                catch
                {

                }
            }
            else if (selectedItem.Text == "Call Doc to repair Delorean")
            {
                helpFromDoc.Docs_help();
            }
            else if (selectedItem.Text == "Display Adjustment")
            {
                displaysystem.Displayadjustment = true;
                Show();
            }
            else if (selectedItem.Text == "RC mode")
            {
                if (!RCmode)
                {
                    //TimeTravel.TTTFRC.Show();
                    myMenu.Clear();
                    myMenu.Visible = true;
                    foreach (string rcCar in timecurcuitssystem.bttfList.Keys)
                    {
                        myMenu.AddItem(new UIMenuItem("RC: " + rcCar));
                    }
                    myMenu.AddItem(new UIMenuItem("Back"));
                    myMenu.RefreshIndex();
                    //myMenu.Visible = false;
                }
                else if (RCmode)
                {
                    Sounds.RCcontrolstop.Play();
                    setmenu(true);
                    //myMenu.Visible = false;
                }
            }
            else if (selectedItem.Text == "Back")
            {
                setmenu(true);
            }
            else if (selectedItem.Text.Contains("RC: "))
            {
                rcmodel = selectedItem.Text.Replace("RC: ", "").Trim();
                Delorean delorea = null;
                if (timecurcuitssystem.bttfList.TryGetValue(rcmodel, out delorea))
                {
                    timecurcuitssystem.bttfList[rcmodel.Trim()].ToggleRCmode();
                    myMenu.Visible = false;
                    RCmode = true;
                    setmenu(true);
                }
            }
            else if (selectedItem.Text == ("RC mode: " + rcmodel.Trim()))
            {
                timecurcuitssystem.bttfList[rcmodel.Trim()].ToggleRCmode();
                myMenu.Visible = false;
                rcmodel = "";
                RCmode = false;
                myMenu.Clear();
                setmenu(true);
            }
            else if (selectedItem.Text == "Tutorial mode")
            {
                mainsystem.client.WriteLineAndGetReply("Start tutorial (scene)", new TimeSpan(0, 0, 10));
                Show();
            }
            else if (selectedItem.Text == "Debugging")
            {
                Show();
                debuginfo.Visible = !debuginfo.Visible;
            }
            else if (selectedItem.Text == "Exit")
            {
                myMenu.Visible = false;
            }
        }

        public void quickRC()
        {
            //TimeTravel.TTTFRC.Show();
            myMenu.Clear();
            myMenu.Visible = true;
            foreach (string rcCar in timecurcuitssystem.bttfList.Keys)
            {
                myMenu.AddItem(new UIMenuItem("RC: " + rcCar));
            }
            myMenu.AddItem(new UIMenuItem("Exit"));
            myMenu.RefreshIndex();
            //myMenu.Visible = false;
        }

        public void Show()
        {
            myMenu.Visible = !myMenu.Visible;
            debuginfo.Visible = false;
        }

        private void itemChange(UIMenu sender, UIMenuListItem listItem, int newIndex)
        {
            file = listItem.IndexToItem(listItem.Index);
        }

        public void OnTick()
        {
            _myMenuPool.ProcessMenus();

            if (Game.CurrentInputMode == InputMode.GamePad)
            {
                if (Game.IsControlJustReleased(0, GTA.Control.LookBehind))
                {
                    Show();
                }
            }

            if (Sounds.testSound != null)
            {
                UIText Instruct = new UIText("PlayState: " + Sounds.testSound.getPlayState() + "\n PlayStatePaused: " + Sounds.testSound.getPlayStatePaused() + "\n PlayStateStopped: " + Sounds.testSound.getPlayStateStopped(), new Point(400, 300), (float)0.9);
                Instruct.Draw();
            }
        }

        string file = "";
        private void debugItemSelectHandler(UIMenu sender, UIMenuItem selectedItem, int index)
        {
            if (selectedItem.Text == "Sound Test")
            {
                debuginfo.Clear();
                debuginfo.AddItem(new UIMenuListItem("Items", soundsFolder.ToList<dynamic>(), 0));
                debuginfo.AddItem(new UIMenuItem("Back"));
                debuginfo.RefreshIndex();
            }
            else if (selectedItem.Text.Contains("FPS on time display dash"))
            {
                displaysystem.fpsdisplay = !displaysystem.fpsdisplay;
            }
            else if (selectedItem.Text.Contains("Items"))
            {
                Sounds.testSound = new soundplayer(file);
                debuginfo.Clear();
                debuginfo.AddItem(new UIMenuItem("Play"));
                debuginfo.AddItem(new UIMenuItem("Pause"));
                debuginfo.AddItem(new UIMenuItem("Stop"));
                debuginfo.AddItem(new UIMenuItem("Back to list"));
                debuginfo.RefreshIndex();
            }
            else if (selectedItem.Text == "Play")
            {
                Sounds.testSound.Play();
            }
            else if (selectedItem.Text == "Pause")
            {
                Sounds.testSound.pause();
            }
            else if (selectedItem.Text == "Stop")
            {
                Sounds.testSound.Stop();
            }
            else if (selectedItem.Text == "Back to list")
            {
                Sounds.testSound.Stop();
                Sounds.testSound = null;
                debuginfo.Clear();
                debuginfo.AddItem(new UIMenuListItem("Items", soundsFolder.ToList<dynamic>(), 0));
                debuginfo.AddItem(new UIMenuItem("Back"));
                debuginfo.RefreshIndex();
            }
            else if (selectedItem.Text == "Back")
            {
                debuginfo.Clear();
                setDebugmenu();
            }
            else if (selectedItem.Text == "Exit")
            {
                Show();
            }
        }
    }
}

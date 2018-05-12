﻿using GTA;
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

namespace TTTF_TimeTravel_0._9._0
{
    class TTTFmenu
    {
        private MenuPool _myMenuPool = new MenuPool();
        public UIMenu myMenu = new UIMenu("Theft to the Future", "Mod Menu");
        UIMenu coop = new UIMenu("Co-op menu", "Co-op Menu");
        UIMenu debuginfo = new UIMenu("Debug info", "Debuging menu");
        string[] soundsFolder = Directory.GetFiles(Sounds.sounds);
        bool invincible = false, beepsound = false, fluxsoundbool = false;
        public static bool RCmode = false;

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
            setmenu();
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

        void setmenu()
        {
            if (!mainsystem.checkifConnectedToLauncher())
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
            myMenu.AddItem(new UIMenuItem("Tutorial mode"));
            myMenu.AddItem(new UIMenuItem("Debugging"));
            myMenu.AddItem(new UIMenuItem("Exit"));
            myMenu.RefreshIndex();
        }

        string carmodel = "";
        public static string rcmodel = "";
        public void ItemSelectHandler(UIMenu senderb, UIMenuItem selectedItem, int index)
        {
            if (selectedItem.Text == "Connect to Launcher")
            {
                try
                {
                    if (!mainsystem.checkifConnectedToLauncher())
                    {
                        mainsystem.client = new SimpleTCP.SimpleTcpClient();
                        mainsystem.client.StringEncoder = Encoding.UTF8;
                        mainsystem.client.DataReceived += mainsystem.luancherdata;
                        mainsystem.client.Connect("127.0.0.1", 10757);
                        mainsystem.client.WriteLineAndGetReply("script running", new TimeSpan(0, 0, 20));
                        mainsystem.setConnection(true);
                        myMenu.Clear();
                        setmenu();
                    }
                }
                catch (Exception d)
                {

                }
            }
            if (selectedItem.Text == "Play with friends")
            {
                myMenu.Visible = false;
                coop.Visible = true;
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
                Model Deloreanmodel = new Model("DMC12g");
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
            else if (selectedItem.Text == "Rescue Cutscene")
            {
                spawn_delorean.spawn(new Model(carmodel), true);
                myMenu.Clear();
                setmenu();
                Show();
            }
            else if (selectedItem.Text == "Spawn Delorean")
            {
                spawn_delorean.spawn(new Model(carmodel), false);
                myMenu.Clear();
                setmenu();
            }
            else if (selectedItem.Text == "Spawn Delorean (BTTF 1)")
            {
                myMenu.Clear();
                myMenu.AddItem(new UIMenuItem("Spawn Delorean"));
                myMenu.AddItem(new UIMenuItem("Rescue Cutscene"));
                myMenu.RefreshIndex();
                carmodel = "BTTF";
            }
            else if (selectedItem.Text == "Spawn Delorean (BTTF 2)")
            {
                myMenu.Clear();
                myMenu.AddItem(new UIMenuItem("Spawn Delorean"));
                myMenu.AddItem(new UIMenuItem("Rescue Cutscene"));
                myMenu.RefreshIndex();
                carmodel = "BTTF2";
            }
            else if (selectedItem.Text == "Spawn Delorean (BTTF 3)")
            {
                myMenu.Clear();
                myMenu.AddItem(new UIMenuItem("Spawn Delorean"));
                myMenu.AddItem(new UIMenuItem("Rescue Cutscene"));
                myMenu.RefreshIndex();
                carmodel = "BTTF3";
            }
            else if (selectedItem.Text == "Spawn Delorean (BTTF 3 railroad)")
            {
                myMenu.Clear();
                myMenu.AddItem(new UIMenuItem("Spawn Delorean"));
                myMenu.AddItem(new UIMenuItem("Rescue Cutscene"));
                myMenu.RefreshIndex();
                carmodel = "BTTF3rr";
            }
            else if (selectedItem.Text == "Turn current car into a Time Machine")
            {
                timecurcuitssystem.addToList(Game.GetUserInput(7).ToUpper(), Game.Player.Character.CurrentVehicle);
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
                            myMenu.Clear();
                            setmenu();

                            Script.Wait(100);
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
                            myMenu.Clear();
                            setmenu();
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
                    myMenu.Clear();
                    setmenu();
                    //myMenu.Visible = false;
                }
            }
            else if (selectedItem.Text == "Back")
            {
                myMenu.Clear();
                setmenu();
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
                    myMenu.Clear();
                    setmenu();
                }
            }
            else if (selectedItem.Text == ("RC mode: " + rcmodel.Trim()))
            {
                timecurcuitssystem.bttfList[rcmodel.Trim()].ToggleRCmode();
                myMenu.Visible = false;
                rcmodel = "";
                RCmode = false;
                myMenu.Clear();
                setmenu();
            }
            else if (selectedItem.Text == "Tutorial mode")
            {
                mainsystem.client.WriteLineAndGetReply("Start tutorial (scene)", new TimeSpan(0,0,10));
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


            if (Sounds.testSound != null)
            {
                UIText Instruct = new UIText("PlayState: " + Sounds.testSound.getPlayState() + "\n PlayStatePaused: " + Sounds.testSound.getPlayStatePaused() + "\n PlayStateStopped: " + Sounds.testSound.getPlayStateStopped(), new Point(400, 300), (float)0.9);
                Instruct.Draw();
            }

            try
            {
                if (Game.Player.Character.IsInVehicle())
                    timecurcuitssystem.bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].getDelorean().IsInvincible = invincible;
            }
            catch
            {

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

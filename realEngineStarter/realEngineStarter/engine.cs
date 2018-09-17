using GTA;
using NativeUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace realEngineStarter
{
    public class engine : Script
    {

        #region needed variables
        Random rand = new Random();

        public int counter = 0;
        public bool starts = false;
        public bool stalled = false;
        public bool starteron = true;
        public bool crank = false;
        public bool startsounddelay = false;
        bool realengine = true;
        bool tick = false;
        #endregion

        private MenuPool _myMenuPool = new MenuPool();
        UIMenu myMenu = new UIMenu("Real Engine Starter", "Mod Menu");

        public engine()
        {
            KeyDown += down;
            KeyUp += up;
            Aborted += onClose;
            try
            {
                Task.Factory.StartNew(() => { getAudio(); });
            }
            catch (Exception e)
            {
                while (true)
                {
                    UI.ShowSubtitle(e.Message);
                    Wait(10);
                }
            }
            Tick += tickEvent;
            Interval = 0;

            myMenu.AddItem(new UIMenuCheckboxItem("Real Engine starter", realengine));
            myMenu.RefreshIndex();
            myMenu.OnCheckboxChange += (sender, item, checked_) =>
            {
                if (item.Text == "Real Engine starter")
                {
                    realengine = checked_;
                    if (realengine)
                    {
                        keyswitch();
                    }
                    else
                    {
                        stopall();
                    }
                }
            };
            _myMenuPool.Add(myMenu);
        }

        private void onClose(object sender, EventArgs e)
        {
            van = null;
            smalltruck = null;
            bigrigtruck = null;
            Delorean = null;
            key = null;
            defaultcarstart = null;
            enginedamage = null;
            knocking = null;
        }

        private void up(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Z)
            {
                engineKeyUp();
            }
            else if (e.KeyCode == Keys.F12)
            {
                Show();
            }
        }

        private void down(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Z)
            {
                engineKeyDown();
            }
        }

        bool keyPressed = false;
        bool keyupPress = false;
        public void engineKeyDown()
        {
            if (realengine)
            {
                if (!keyPressed)
                {
                    if (Game.Player.Character.IsInVehicle())
                    {
                        if (Game.Player.Character.CurrentVehicle.EngineRunning)
                        {
                            enginestarted = false;
                            //audioplayed = false;
                            juststarted = true;
                            //engine.startsounddelay = false;
                        }
                        else if (!Game.Player.Character.CurrentVehicle.EngineRunning)
                        {
                            if (starteron)
                            {
                                if (!crank)
                                {
                                    //engine.startsounddelay = true;
                                    if (!juststarted)
                                        crank = true;
                                }
                            }
                            else
                            {
                                //engine.startsounddelay = true;
                            }
                            //audioplayed = false;
                        }
                    }
                    keyupPress = false;
                    keyPressed = true;
                }
            }
        }
        public void engineKeyUp()
        {
            if (realengine)
            {
                if (!keyupPress)
                {
                    if (starteron)
                    {
                        startsounddelay = false;
                        crank = false;
                        juststarted = false;
                        //audioplayed = false;
                        if (Game.Player.Character.IsInVehicle())
                        {
                            if (!Game.Player.Character.CurrentVehicle.EngineRunning)
                            {
                                if (!crank)
                                    stopall();
                                counter = 0;
                            }
                        }
                    }
                    else
                    {
                        if (starts)
                        {
                            crank = false;
                        }
                    }
                    keyupPress = true;
                    keyPressed = false;
                }
            }
        }

        public void keyswitch()
        {
            key.Play();
        }

        public static string sounds = Application.StartupPath + @"\scripts\Engine Sounds\";
        #region sounds
        soundplayer van;
        soundplayer smalltruck;
        soundplayer bigrigtruck;
        soundplayer Delorean;
        soundplayer key;
        soundplayer defaultcarstart;
        soundplayer enginedamage;
        soundplayer knocking;
        #endregion

        #region starter

        public void Show()
        {
            myMenu.Visible = !myMenu.Visible;
        }

        public void stopall()
        {
            van.Stop();
            smalltruck.Stop();
            bigrigtruck.Stop();
            Delorean.Stop();
            key.Stop();
            defaultcarstart.Stop();
            enginedamage.Stop();
            knocking.Stop();
        }

        void vanstart()
        {
            van.Play();
        }

        void smalltruckstart()
        {
            smalltruck.Play();
        }

        void bigrigtruckstart()
        {
            bigrigtruck.Play();
        }

        void Deloreancrankstart()
        {
            Delorean.Play();
        }

        void motorcycle()
        {

        }

        /*
        void crankloopsound()
        {
            if (Game.Player.Character.CurrentVehicle.Model == GTA.Native.VehicleHash.Baller)
            {
                vancrankloop();
            }
            else if (Game.Player.Character.CurrentVehicle.Model == GTA.Native.VehicleHash.Granger)
            {
                vancrankloop();
            }
            else if (Game.Player.Character.CurrentVehicle.Model == GTA.Native.VehicleHash.GBurrito)
            {
                vancrankloop();
            }
            else if (Game.Player.Character.CurrentVehicle.Model == GTA.Native.VehicleHash.GBurrito2)
            {
                vancrankloop();
            }
            else if (Game.Player.Character.CurrentVehicle.Model == GTA.Native.VehicleHash.Kalahari)
            {
                smalltruckcrankloop();
            }
            else if (Game.Player.Character.CurrentVehicle.Model == GTA.Native.VehicleHash.Bison)
            {
                smalltruckcrankloop();
            }
            else if (Game.Player.Character.CurrentVehicle.Model == GTA.Native.VehicleHash.Insurgent)
            {
                bigrigtruckcrankloop();
            }
            else if (Game.Player.Character.CurrentVehicle.Model == GTA.Native.VehicleHash.Insurgent2)
            {
                bigrigtruckcrankloop();
            }
            else if (Game.Player.Character.CurrentVehicle.Model == GTA.Native.VehicleHash.Hauler)
            {
                bigrigtruckcrankloop();
            }
            else if (Game.Player.Character.CurrentVehicle.Model == GTA.Native.VehicleHash.Flatbed)
            {
                bigrigtruckcrankloop();
            }
            else if (Game.Player.Character.CurrentVehicle.Model == GTA.Native.VehicleHash.Guardian)
            {
                bigrigtruckcrankloop();
            }
            else if (Game.Player.Character.CurrentVehicle.Model == GTA.Native.VehicleHash.Dump)
            {
                bigrigtruckcrankloop();
            }
            else if (Game.Player.Character.CurrentVehicle.Model == GTA.Native.VehicleHash.Benson ||
                Game.Player.Character.CurrentVehicle.Model == GTA.Native.VehicleHash.TowTruck ||
                Game.Player.Character.CurrentVehicle.Model == GTA.Native.VehicleHash.TowTruck2)
            {
                bigrigtruckcrankloop();
            }
            else if (Game.Player.Character.CurrentVehicle.Model == GTA.Native.VehicleHash.Mesa)
            {
                smalltruckcrankloop();
            }
            else if (Game.Player.Character.CurrentVehicle.Model == GTA.Native.VehicleHash.Mesa2)
            {
                smalltruckcrankloop();
            }
            else if (Game.Player.Character.CurrentVehicle.Model == GTA.Native.VehicleHash.Mesa3 ||
                Game.Player.Character.CurrentVehicle.Model == GTA.Native.VehicleHash.Rebel ||
                Game.Player.Character.CurrentVehicle.Model == GTA.Native.VehicleHash.Rebel2 ||
                Game.Player.Character.CurrentVehicle.Model == GTA.Native.VehicleHash.Bodhi2 ||
                Game.Player.Character.CurrentVehicle.Model == GTA.Native.VehicleHash.DLoader ||
                Game.Player.Character.CurrentVehicle.Model == GTA.Native.VehicleHash.Sandking ||
                Game.Player.Character.CurrentVehicle.Model == GTA.Native.VehicleHash.Sandking2 ||
                Game.Player.Character.CurrentVehicle.Model == GTA.Native.VehicleHash.BobcatXL)
            {
                smalltruckcrankloop();
            }
            else if (Game.Player.Character.CurrentVehicle.Model == GTA.Native.VehicleHash.Huntley ||
                Game.Player.Character.CurrentVehicle.Model == GTA.Native.VehicleHash.BJXL ||
                Game.Player.Character.CurrentVehicle.Model == GTA.Native.VehicleHash.Seminole)
            {
                vancrankloop();
            }
            else if (Game.Player.Character.CurrentVehicle.Model == GTA.Native.VehicleHash.Pranger)
            {
                vancrankloop();
            }
            else if (Game.Player.Character.CurrentVehicle.Model == new Model("BTTF"))
            {

            }
            else if (Game.Player.Character.CurrentVehicle.Model == new Model("BTTF2"))
            {

            }
            else if (Game.Player.Character.CurrentVehicle.Model == new Model("BTTF2F"))
            {

            }
            else if (Game.Player.Character.CurrentVehicle.Model == new Model("BTTF3"))
            {

            }
            else if (Game.Player.Character.CurrentVehicle.Model == new Model("BTTF3rr"))
            {

            }
            else
            {
                defaultstarter.Play();
            }
        }
        */

        /*
        void crankstartsound()
        {
            if (Game.Player.Character.CurrentVehicle.Model == GTA.Native.VehicleHash.Baller)
            {
                vancrankstart();
            }
            else if (Game.Player.Character.CurrentVehicle.Model == GTA.Native.VehicleHash.Granger)
            {
                vancrankstart();
            }
            else if (Game.Player.Character.CurrentVehicle.Model == GTA.Native.VehicleHash.GBurrito)
            {
                vancrankstart();
            }
            else if (Game.Player.Character.CurrentVehicle.Model == GTA.Native.VehicleHash.GBurrito2)
            {
                vancrankstart();
            }
            else if (Game.Player.Character.CurrentVehicle.Model == GTA.Native.VehicleHash.Kalahari)
            {
                smalltruckcrankstart();
            }
            else if (Game.Player.Character.CurrentVehicle.Model == GTA.Native.VehicleHash.Bison)
            {
                smalltruckcrankstart();
            }
            else if (Game.Player.Character.CurrentVehicle.Model == GTA.Native.VehicleHash.Insurgent)
            {
                bigrigtruckcrankstart();
            }
            else if (Game.Player.Character.CurrentVehicle.Model == GTA.Native.VehicleHash.Insurgent2)
            {
                bigrigtruckcrankstart();
            }
            else if (Game.Player.Character.CurrentVehicle.Model == GTA.Native.VehicleHash.Hauler)
            {
                bigrigtruckcrankstart();
            }
            else if (Game.Player.Character.CurrentVehicle.Model == GTA.Native.VehicleHash.Flatbed)
            {
                bigrigtruckcrankstart();
            }
            else if (Game.Player.Character.CurrentVehicle.Model == GTA.Native.VehicleHash.Guardian)
            {
                bigrigtruckcrankstart();
            }
            else if (Game.Player.Character.CurrentVehicle.Model == GTA.Native.VehicleHash.Dump)
            {
                bigrigtruckcrankstart();
            }
            else if (Game.Player.Character.CurrentVehicle.Model == GTA.Native.VehicleHash.Benson ||
                Game.Player.Character.CurrentVehicle.Model == GTA.Native.VehicleHash.TowTruck ||
                Game.Player.Character.CurrentVehicle.Model == GTA.Native.VehicleHash.TowTruck2)
            {
                bigrigtruckcrankstart();
            }
            else if (Game.Player.Character.CurrentVehicle.Model == GTA.Native.VehicleHash.Mesa)
            {
                smalltruckcrankstart();
            }
            else if (Game.Player.Character.CurrentVehicle.Model == GTA.Native.VehicleHash.Mesa2)
            {
                smalltruckcrankstart();
            }
            else if (Game.Player.Character.CurrentVehicle.Model == GTA.Native.VehicleHash.Mesa3 ||
                Game.Player.Character.CurrentVehicle.Model == GTA.Native.VehicleHash.Rebel ||
                Game.Player.Character.CurrentVehicle.Model == GTA.Native.VehicleHash.Rebel2 ||
                Game.Player.Character.CurrentVehicle.Model == GTA.Native.VehicleHash.Bodhi2 ||
                Game.Player.Character.CurrentVehicle.Model == GTA.Native.VehicleHash.DLoader ||
                Game.Player.Character.CurrentVehicle.Model == GTA.Native.VehicleHash.Sandking ||
                Game.Player.Character.CurrentVehicle.Model == GTA.Native.VehicleHash.Sandking2 ||
                Game.Player.Character.CurrentVehicle.Model == GTA.Native.VehicleHash.BobcatXL)
            {
                smalltruckcrankstart();
            }
            else if (Game.Player.Character.CurrentVehicle.Model == GTA.Native.VehicleHash.Huntley ||
                Game.Player.Character.CurrentVehicle.Model == GTA.Native.VehicleHash.BJXL ||
                Game.Player.Character.CurrentVehicle.Model == GTA.Native.VehicleHash.Seminole)
            {
                vancrankstart();
            }
            else if (Game.Player.Character.CurrentVehicle.Model == GTA.Native.VehicleHash.Pranger)
            {
                vancrankstart();
            }
            else if (Game.Player.Character.CurrentVehicle.Model == new Model("BTTF"))
            {
                
            }
            else if (Game.Player.Character.CurrentVehicle.Model == new Model("BTTF2"))
            {
                
            }
            else if (Game.Player.Character.CurrentVehicle.Model == new Model("BTTF2F"))
            {
                
            }
            else if (Game.Player.Character.CurrentVehicle.Model == new Model("BTTF3"))
            {
                
            }
            else if (Game.Player.Character.CurrentVehicle.Model == new Model("BTTF3rr"))
            {
                
            }
            else
            {
                defaultstarterstart.Play();
            }
        }
        */

        string vehicletype = "car";
        bool isStarterOn = false;
        double durration = 0;
        public bool juststarted = false;

        
        void normalstart()
        {
            if (crank)
            {
                if (!isStarterOn)
                {
                    if (Game.Player.Character.CurrentVehicle.Model == GTA.Native.VehicleHash.Baller)
                    {
                        vanstart();
                        vehicletype = "van";
                    }
                    else if (Game.Player.Character.CurrentVehicle.Model == GTA.Native.VehicleHash.Granger)
                    {
                        vanstart();
                        vehicletype = "van";
                    }
                    else if (Game.Player.Character.CurrentVehicle.Model == GTA.Native.VehicleHash.GBurrito)
                    {
                        vanstart();
                        vehicletype = "van";
                    }
                    else if (Game.Player.Character.CurrentVehicle.Model == GTA.Native.VehicleHash.GBurrito2)
                    {
                        vanstart();
                        vehicletype = "van";
                    }
                    else if (Game.Player.Character.CurrentVehicle.Model == GTA.Native.VehicleHash.Kalahari)
                    {
                        smalltruckstart();
                        vehicletype = "pickup";
                    }
                    else if (Game.Player.Character.CurrentVehicle.Model == GTA.Native.VehicleHash.Bison)
                    {
                        smalltruckstart();
                        vehicletype = "pickup";
                    }
                    else if (Game.Player.Character.CurrentVehicle.Model == GTA.Native.VehicleHash.Insurgent)
                    {
                        bigrigtruckstart();
                        vehicletype = "truck";
                    }
                    else if (Game.Player.Character.CurrentVehicle.Model == GTA.Native.VehicleHash.Insurgent2)
                    {
                        bigrigtruckstart();
                        vehicletype = "truck";
                    }
                    else if (Game.Player.Character.CurrentVehicle.Model == GTA.Native.VehicleHash.Hauler)
                    {
                        bigrigtruckstart();
                        vehicletype = "truck";
                    }
                    else if (Game.Player.Character.CurrentVehicle.Model == GTA.Native.VehicleHash.Flatbed)
                    {
                        bigrigtruckstart();
                        vehicletype = "truck";
                    }
                    else if (Game.Player.Character.CurrentVehicle.Model == GTA.Native.VehicleHash.Guardian)
                    {
                        bigrigtruckstart();
                        vehicletype = "truck";
                    }
                    else if (Game.Player.Character.CurrentVehicle.Model == GTA.Native.VehicleHash.Dump)
                    {
                        bigrigtruckstart();
                        vehicletype = "truck";
                    }
                    else if (Game.Player.Character.CurrentVehicle.Model == GTA.Native.VehicleHash.Benson ||
                        Game.Player.Character.CurrentVehicle.Model == GTA.Native.VehicleHash.TowTruck ||
                        Game.Player.Character.CurrentVehicle.Model == GTA.Native.VehicleHash.TowTruck2)
                    {
                        bigrigtruckstart();
                        vehicletype = "truck";
                    }
                    else if (Game.Player.Character.CurrentVehicle.Model == GTA.Native.VehicleHash.Mesa)
                    {
                        smalltruckstart();
                        vehicletype = "pickup";
                    }
                    else if (Game.Player.Character.CurrentVehicle.Model == GTA.Native.VehicleHash.Mesa2)
                    {
                        smalltruckstart();
                        vehicletype = "pickup";
                    }
                    else if (Game.Player.Character.CurrentVehicle.Model == GTA.Native.VehicleHash.Mesa3 ||
                        Game.Player.Character.CurrentVehicle.Model == GTA.Native.VehicleHash.Rebel ||
                        Game.Player.Character.CurrentVehicle.Model == GTA.Native.VehicleHash.Rebel2 ||
                        Game.Player.Character.CurrentVehicle.Model == GTA.Native.VehicleHash.Bodhi2 ||
                        Game.Player.Character.CurrentVehicle.Model == GTA.Native.VehicleHash.DLoader ||
                        Game.Player.Character.CurrentVehicle.Model == GTA.Native.VehicleHash.Sandking ||
                        Game.Player.Character.CurrentVehicle.Model == GTA.Native.VehicleHash.Sandking2 ||
                        Game.Player.Character.CurrentVehicle.Model == GTA.Native.VehicleHash.BobcatXL)
                    {
                        smalltruckstart();
                        vehicletype = "pickup";
                    }
                    else if (Game.Player.Character.CurrentVehicle.Model == GTA.Native.VehicleHash.Huntley ||
                        Game.Player.Character.CurrentVehicle.Model == GTA.Native.VehicleHash.BJXL ||
                        Game.Player.Character.CurrentVehicle.Model == GTA.Native.VehicleHash.Seminole)
                    {
                        vanstart();
                        vehicletype = "van";
                    }
                    else if (Game.Player.Character.CurrentVehicle.Model == GTA.Native.VehicleHash.Pranger)
                    {
                        vanstart();
                        vehicletype = "van";
                    }
                    else if (Game.Player.Character.CurrentVehicle.Model == new Model("BTTF"))
                    {
                        Deloreancrankstart();
                        vehicletype = "bttf";
                    }
                    else if (Game.Player.Character.CurrentVehicle.Model == new Model("BTTF2"))
                    {
                        Deloreancrankstart();
                        vehicletype = "bttf";
                    }
                    else if (Game.Player.Character.CurrentVehicle.Model == new Model("BTTF2F"))
                    {
                        Deloreancrankstart();
                        vehicletype = "bttf";
                    }
                    else if (Game.Player.Character.CurrentVehicle.Model == new Model("BTTF3"))
                    {
                        Deloreancrankstart();
                        vehicletype = "bttf";
                    }
                    else if (Game.Player.Character.CurrentVehicle.Model == new Model("BTTF3rr"))
                    {
                        Deloreancrankstart();
                        vehicletype = "bttf";
                    }
                    else
                    {
                        defaultcarstart.Play();
                        vehicletype = "car";
                    }
                    isStarterOn = true;
                }
            }
            else
            {
                isStarterOn = false;
            }

            if (defaultcarstart.getPlayState())
            {
                durration = defaultcarstart.gettime();
            }
            if (van.getPlayState())
            {
                durration = van.gettime();
            }
            if (smalltruck.getPlayState())
            {
                durration = smalltruck.gettime();
            }
            if (bigrigtruck.getPlayState())
            {
                durration = bigrigtruck.gettime();
            }
        }

        public bool stoptick = false;

        void starterloop(double bringBack, double starterLimit)
        {
            if (durration > starterLimit)
            {
                if (defaultcarstart.getPlayState())
                {
                    defaultcarstart.settime(bringBack);
                }
                if (van.getPlayState())
                {
                    van.settime(bringBack);
                }
                if (smalltruck.getPlayState())
                {
                    smalltruck.settime(bringBack);
                }
                if (bigrigtruck.getPlayState())
                {
                    bigrigtruck.settime(bringBack);
                }
            }
        }

        bool delorean_stall = false;
        public void starter()
        {
            if (!stalled)
            {
                if (Game.Player.Character.IsInVehicle())
                {
                    if (Game.Player.Character.CurrentVehicle.EngineHealth <= 200)
                    {
                        if (enginestarted)
                        {
                            int n = 0;
                            if (!stoptick)
                            {
                                if (DateTime.Now.Millisecond % 180 >= 90 && DateTime.Now.Millisecond % 180 <= 180)
                                {
                                    if (!tick)
                                    {
                                        try
                                        {
                                            n = rand.Next(1, (int)Game.Player.Character.CurrentVehicle.EngineHealth + 2);
                                        }
                                        catch
                                        {
                                            n = 1;
                                        }
                                    }
                                }
                                else
                                {
                                    tick = false;
                                }
                                if (n == 1)
                                {
                                    stoptick = true;
                                    n++;
                                }
                            }
                            else
                            {
                                double g = (Game.Player.Character.CurrentVehicle.CurrentRPM * 100);
                                //UI.ShowSubtitle("RPM: " + g);
                                if (DateTime.Now.Millisecond % 240 >= 120 && DateTime.Now.Millisecond % 240 <= 240)
                                {
                                    if (!tick)
                                    {
                                        if ((Game.Player.Character.CurrentVehicle.CurrentRPM * 100) <= 70)
                                            Game.Player.Character.CurrentVehicle.EngineRunning = !Game.Player.Character.CurrentVehicle.EngineRunning;
                                    }
                                }
                                else
                                {
                                    tick = false;
                                }

                                if (g < 30)
                                {
                                    stopall();
                                    enginestarted = false;
                                    starts = false;
                                    stalled = true;
                                    stoptick = false;
                                }

                            }

                            //UI.ShowSubtitle("counter: " + (200 - (int)Game.Player.Character.CurrentVehicle.EngineHealth
                            //+ "RPM: " + (int)(Game.Player.Character.CurrentVehicle.CurrentRPM * 100)));
                        }
                    }
                }
            }
            if (crank)
            {
                if (Game.Player.Character.IsInVehicle())
                {
                    if (vehicletype == "car")
                    {
                        starterloop(410, 720);
                    }
                    if (vehicletype == "van")
                    {
                        starterloop(270, 580);
                    }
                    if (vehicletype == "pickup")
                    {
                        starterloop(410, 720);
                    }
                    if (vehicletype == "truck")
                    {
                        starterloop(300, 650);
                    }

                    int n = 0;
                    int m = 0;
                    if (delorean_stall && Game.Player.Character.CurrentVehicle.Model == "bttf")
                    {
                        if (Game.Player.Character.CurrentVehicle.EngineHealth > 500)
                        {
                            m = 200;
                            n = rand.Next(1, m);
                        }
                        else
                        {
                            m = 500 - (int)Game.Player.Character.CurrentVehicle.EngineHealth + 2;
                            n = rand.Next(1, 1000 - (int)Game.Player.Character.CurrentVehicle.EngineHealth + 2);
                        }
                    }
                    else
                    {
                        if (Game.Player.Character.CurrentVehicle.EngineHealth > 500)
                        {
                            m = 20;
                            n = rand.Next(1, m);
                        }
                        else
                        {
                            m = 500 - (int)Game.Player.Character.CurrentVehicle.EngineHealth + 2;
                            n = rand.Next(1, 1000 - (int)Game.Player.Character.CurrentVehicle.EngineHealth + 2);
                        }
                    }
                    if (n == (m) - 1)
                    {
                        double back = 700;
                        if (defaultcarstart.getPlayState())
                        {
                            defaultcarstart.settime(back);
                        }
                        if (van.getPlayState())
                        {
                            van.settime(back);
                        }
                        if (smalltruck.getPlayState())
                        {
                            smalltruck.settime(back);
                        }
                        if (bigrigtruck.getPlayState())
                        {
                            bigrigtruck.settime(back);
                        }
                        if (Delorean.getPlayState())
                        {
                            Delorean.settime(30100);
                        }
                        starts = true;
                        enginestarted = true;
                        stalled = false;
                        juststarted = true;
                        crank = false;
                        delorean_stall = false;
                    }
                }
                else
                {
                    if (Game.Player.Character.LastVehicle != null)
                    {
                        if (Game.Player.Character.LastVehicle.EngineRunning)
                        {
                            try
                            {
                                enginedamage.playSpeed((Game.Player.Character.CurrentVehicle.CurrentRPM * 100) / 5);
                                knocking.playSpeed((Game.Player.Character.CurrentVehicle.CurrentRPM * 100) / 5);
                            }
                            catch
                            {

                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region checkengine stats
        public bool enginestarted = false;
        bool check = false;
        void checkenginestats()
        {
            if (check)
            {
                if (!enginestarted)
                {
                    if (Game.Player.Character.CurrentVehicle.EngineRunning)
                    {
                        Game.Player.Character.CurrentVehicle.EngineRunning = false;
                        enginedamage.Stop();
                        knocking.Stop();
                        enginedamage.Volume(0.001f);
                        knocking.Volume(0.001f);
                    }
                    Game.Player.Character.CurrentVehicle.EngineRunning = false;
                    Game.Player.Character.CurrentVehicle.CurrentRPM = 0;
                }
                else
                {
                    Game.Player.Character.CurrentVehicle.EngineRunning = Game.Player.Character.CurrentVehicle.IsVisible;
                    if (enginedamage.gettimeend() || enginedamage.gettime() == 0)
                    {
                        Wait(500);
                        enginedamage.Play();
                        enginedamage.Volume(0.001f);
                    }
                    else
                        enginedamage.resume();
                    if (knocking.gettimeend() || knocking.gettime() == 0)
                    {
                        Wait(500);
                        knocking.Play();
                        knocking.Volume(0.001f);
                    }
                    else
                        knocking.resume();
                }
            }
            else
            {
                if (Game.Player.Character.CurrentVehicle.IsAlive)
                {
                    if (!Game.Player.Character.CurrentVehicle.EngineRunning)
                    {
                        if (Game.Player.Character.CurrentVehicle.Model != "bttf2f")
                        {
                            Game.Player.Character.CurrentVehicle.CurrentRPM = 0;
                            enginestarted = false;
                            enginedamage.Stop();
                            knocking.Stop();
                        }
                    }
                    else
                    {
                        enginestarted = true;
                        Wait(10);
                        enginedamage.Volume(0.001f);
                        Wait(10);
                        knocking.Volume(0.001f);
                    }
                    check = true;
                }
            }
        }
        #endregion

        #region feul
        float gastank = 2000;
        bool outofgas = false;
        void feulgadge()
        {
            if (!outofgas)
            {
                gastank -= 1;
            }
        }
        #endregion
        
        #region timer
        bool half_time = false;
        bool initial = false;
        static double c = 2.0;
        static double k = 0.001;
        static double h = 0.1;
        double temp = 20;
        double sidetemp = 15;
        double L = k / (h * h);
        
        double temp_increase()
        {
            double CL = 2 * c * L;
            temp = (sidetemp / L) + (temp / CL) + (sidetemp / L);
            return temp;
        }

        double temp_decrease()
        {
            double CL = 2 * c * L;
            temp = (sidetemp * L) + (temp * CL) + (sidetemp * L);
            return temp;
        }

        static string error = "";
        void logic(Vehicle CurrentVehicle)
        {
            if (CurrentVehicle != null)
            {
                error = "bttf check";
                if (CurrentVehicle.EngineRunning && CurrentVehicle.Model == "bttf")
                {
                    int n = 0;
                    if (DateTime.Now.Millisecond % 180 >= 90 && DateTime.Now.Millisecond % 180 <= 180)
                    {
                        n = rand.Next(1, 2000);
                    }

                    if (n == 1)
                    {
                        n++;
                        enginestarted = false;
                        starts = false;
                        stalled = true;
                        delorean_stall = true;
                    }
                }

                error = "rpm";
                if ((CurrentVehicle.CurrentRPM * 100) == 100)
                {
                    if (DateTime.Now.Millisecond % 125 > 62 && DateTime.Now.Millisecond % 125 <= 125)
                    {
                        if (half_time)
                        {
                            if (temp_increase() > 90)
                            {
                                CurrentVehicle.EngineHealth--;
                            }
                            half_time = false;
                        }
                    }
                    else
                    {
                        half_time = true;
                    }
                    //UI.ShowSubtitle("overrev " + Game.Player.Character.CurrentVehicle.CurrentRPM * 100);
                }
                else
                {
                    if (temp > 20)
                    {
                        temp_decrease();
                    }
                }

                //UI.ShowSubtitle("health " + (CurrentVehicle.EngineHealth / 1000) + " Temp: " + temp);

                error = "engine health";
                if (CurrentVehicle.EngineHealth > 800)
                {
                    enginedamage.Volume(0.00001f);
                    knocking.Volume(0.00001f);
                }
                else if (CurrentVehicle.EngineHealth > 0)
                {
                    enginedamage.Volume(0.8f - CurrentVehicle.EngineHealth / 1000);
                }
                else
                {
                    CurrentVehicle.EngineRunning = false;
                    enginestarted = false;
                    stopall();
                }

                if (CurrentVehicle.EngineHealth > 600)
                    knocking.Volume(0.00001f);
                else if (CurrentVehicle.EngineHealth > 0)
                    knocking.Volume(1f - CurrentVehicle.EngineHealth / 1000f);
                else
                {
                    CurrentVehicle.EngineRunning = false;
                    enginestarted = false;
                }

                try
                {
                    enginedamage.playSpeed((CurrentVehicle.CurrentRPM * 100) / 5);
                    knocking.playSpeed((CurrentVehicle.CurrentRPM * 100) / 5);
                }
                catch
                {

                }
            }
        }

        void getAudio()
        {
            van = new soundplayer(sounds + "Truck.wav", true);
            Wait(10);
            smalltruck = new soundplayer(sounds + "truck2.wav", true);
            Wait(10);
            bigrigtruck = new soundplayer(sounds + "Diesel_Truck_Starter.wav", true);
            Wait(10);
            Delorean = new soundplayer(sounds + "restart_engine.wav", true);
            Wait(10);
            key = new soundplayer(sounds + "key.wav", true);
            Wait(10);
            defaultcarstart = new soundplayer(sounds + "Car start up.wav", true);
            Wait(10);
            enginedamage = new soundplayer(sounds + "engine damage.wav", true);
            Wait(10);
            knocking = new soundplayer(sounds + "knocking.wav", true);
            Wait(10);
        }

        public void tickEvent(object sender, EventArgs e)
        {
            try
            {
                _myMenuPool.ProcessMenus();
                if (realengine)
                {
                    if (!Game.IsLoading)
                    {
                        if (!initial)
                        {
                            if (knocking != null && enginedamage != null)
                            {
                                initial = true;
                            }
                            else
                                getAudio();
                        }

                        if (Game.Player.Character.IsInVehicle())
                        {
                            try
                            {
                                if (Game.CurrentInputMode == InputMode.GamePad)
                                {
                                    if (Game.IsControlPressed(0, GTA.Control.VehiclePushbikeSprint))
                                    {
                                        if (!juststarted)
                                            engineKeyDown();
                                    }
                                    else
                                    {
                                        engineKeyUp();
                                    }
                                }

                                checkenginestats();
                                normalstart();
                                starter();

                                logic(Game.Player.Character.CurrentVehicle);

                            }
                            catch
                            {
                                try
                                {
                                    if (Game.Player.Character.LastVehicle != null)
                                        logic(Game.Player.Character.LastVehicle);
                                }
                                catch (Exception d)
                                {
                                    UIText debug2 = new UIText("object: " + d.TargetSite + " location: " + d.StackTrace + " Error: " + d.Message, new System.Drawing.Point(100, 50), (float)0.6);
                                    debug2.Draw();
                                    UIText debug = new UIText("location: " + d.StackTrace, new System.Drawing.Point(100, 200), (float)0.6);
                                    debug.Draw();
                                    UIText debug3 = new UIText("Error: " + d.Message, new System.Drawing.Point(100, 350), (float)0.6);
                                    debug3.Draw();
                                    UIText debug4 = new UIText("Root Error: " + error, new System.Drawing.Point(100, 500), (float)0.6);
                                    debug4.Draw();
                                    UI.ShowSubtitle(d.Message);
                                }
                            }
                        }
                        else
                        {
                            try
                            {
                                if (Game.Player.Character.LastVehicle != null)
                                    logic(Game.Player.Character.LastVehicle);
                            }
                            catch (Exception d)
                            {
                                UIText debug2 = new UIText("object: " + d.TargetSite + " location: " + d.StackTrace + " Error: " + d.Message, new System.Drawing.Point(100, 50), (float)0.6);
                                debug2.Draw();
                                UIText debug = new UIText("location: " + d.StackTrace, new System.Drawing.Point(100, 200), (float)0.6);
                                debug.Draw();
                                UIText debug3 = new UIText("Error: " + d.Message, new System.Drawing.Point(100, 350), (float)0.6);
                                debug3.Draw();
                                UIText debug4 = new UIText("Root Error: " + error, new System.Drawing.Point(100, 500), (float)0.6);
                                debug4.Draw();
                                UI.ShowSubtitle(d.Message);
                            }
                            check = false;
                            enginestarted = false;
                        }
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
                UIText debug4 = new UIText("Root Error: " + error, new System.Drawing.Point(100, 500), (float)0.6);
                debug4.Draw();
                UI.ShowSubtitle(d.Message);
            }
        }
        #endregion
    }
}

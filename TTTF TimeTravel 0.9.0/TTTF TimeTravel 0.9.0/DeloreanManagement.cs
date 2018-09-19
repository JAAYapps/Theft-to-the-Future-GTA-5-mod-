using GTA;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TTTF_TimeTravel_0._9._0
{
    class DeloreanManagement
    {
        static Random rand = new Random();

        public int timeDifferance()
        {


            return 0;
        }

        public static void currentGameTime()
        {
            int hour = World.CurrentDayTime.Hours;
            if (hour == 0)
            {
                presh1 = 1;
                presh2 = 2;
            }
            else if (hour == 1)
            {
                presh1 = 0;
                presh2 = 1;
            }
            else if (hour == 2)
            {
                presh1 = 0;
                presh2 = 2;
            }
            else if (hour == 3)
            {
                presh1 = 0;
                presh2 = 3;
            }
            else if (hour == 4)
            {
                presh1 = 0;
                presh2 = 4;
            }
            else if (hour == 5)
            {
                presh1 = 0;
                presh2 = 5;
            }
            else if (hour == 6)
            {
                presh1 = 0;
                presh2 = 6;
            }
            else if (hour == 7)
            {
                presh1 = 0;
                presh2 = 7;
            }
            else if (hour == 8)
            {
                presh1 = 0;
                presh2 = 8;
            }
            else if (hour == 9)
            {
                presh1 = 0;
                presh2 = 9;
            }
            else if (hour == 10)
            {
                presh1 = 1;
                presh2 = 0;
            }
            else if (hour == 11)
            {
                presh1 = 1;
                presh2 = 1;
            }
            else if (hour == 12)
            {
                presh1 = 1;
                presh2 = 2;
            }
            else if (hour == 13)
            {
                presh1 = 0;
                presh2 = 1;
            }
            else if (hour == 14)
            {
                presh1 = 0;
                presh2 = 2;
            }
            else if (hour == 15)
            {
                presh1 = 0;
                presh2 = 3;
            }
            else if (hour == 16)
            {
                presh1 = 0;
                presh2 = 4;
            }
            else if (hour == 17)
            {
                presh1 = 0;
                presh2 = 5;
            }
            else if (hour == 18)
            {
                presh1 = 0;
                presh2 = 6;
            }
            else if (hour == 19)
            {
                presh1 = 0;
                presh2 = 7;
            }
            else if (hour == 20)
            {
                presh1 = 0;
                presh2 = 8;
            }
            else if (hour == 21)
            {
                presh1 = 0;
                presh2 = 9;
            }
            else if (hour == 22)
            {
                presh1 = 1;
                presh2 = 0;
            }
            else if (hour == 23)
            {
                presh1 = 1;
                presh2 = 1;
            }

            if (hour >= 12)
            {
                presampm = "pm";
            }
            else
            {
                presampm = "am";
            }

            int presmin = World.CurrentDayTime.Minutes;
            if (presmin < 10)
            {
                presm1 = 0;
                presm2 = presmin;
            }
            else
            {
                if (presmin < 20)
                {
                    presm1 = 1;
                    presm2 = presmin - 10;
                }
                else if (presmin < 30)
                {
                    presm1 = 2;
                    presm2 = presmin - 20;
                }
                else if (presmin < 40)
                {
                    presm1 = 3;
                    presm2 = presmin - 30;
                }
                else if (presmin < 50)
                {
                    presm1 = 4;
                    presm2 = presmin - 40;
                }
                else if (presmin < 60)
                {
                    presm1 = 5;
                    presm2 = presmin - 50;
                }
            }
        }

        public static void setPresentTime()
        {
            presmonth1 = int.Parse(DateTime.Now.ToString("MM").Substring(0, 1));
            presmonth2 = int.Parse(DateTime.Now.ToString("MM").Substring(1));
            presday1 = int.Parse(DateTime.Now.ToString("dd").Substring(0, 1));
            presday2 = int.Parse(DateTime.Now.ToString("dd").Substring(1));
            presy1 = int.Parse(DateTime.Now.ToString("yyyy").Substring(0, 1));
            presy2 = int.Parse(DateTime.Now.ToString("yyyy").Substring(1, 1));
            presy3 = int.Parse(DateTime.Now.ToString("yyyy").Substring(2, 1));
            presy4 = int.Parse(DateTime.Now.ToString("yyyy").Substring(3));
        }

        public static void setPresentTime(int month1, int month2, int day1, int day2, 
            int y1, int y2, int y3, int y4)
        {
            presmonth1 = month1;
            presmonth2 = month2;
            presday1 = day1;
            presday2 = day2;
            presy1 = y1;
            presy2 = y2;
            presy3 = y3;
            presy4 = y4;
        }

        public static int presday1 = 1, presday2 = 0, presmonth1 = 0, presmonth2 = 9, presy1 = 1, presy2 = 9, presy3 = 9, presy4 = 5, presh1 = 0, presh2 = 6, presm1 = 1, presm2 = 1;
        public static string presampm = "pm";
        static bool ticktock = false;
        static Random errorDisplay = new Random();
        static int ranint = 0;
        public static void tick()
        {
            currentGameTime();
            NativeUI.UIResText Timedisplaypres = new NativeUI.UIResText(displaysystem.timedisplay(presmonth1, presmonth2, presday1, presday2, presy1, presy2, presy3, presy4, presh1, presh2, presampm, presm1, presm2), new System.Drawing.Point(20, 20), (float)0.6, System.Drawing.Color.Green);
            Timedisplaypres.Draw();
            if (Game.Player.Character.IsInVehicle())
            {
                Delorean temp = null;
                string car = Game.Player.Character.CurrentVehicle.NumberPlate.Trim();
                if (timecurcuitssystem.bttfList.TryGetValue(car, out temp))
                {
                    timecurcuitssystem.DisplayScreenTimePanel(presmonth1, presmonth2,
                                presday1, presday2,
                                presy1, presy2, presy3, presy4,
                                presh1, presh2,
                                presampm, presm1, presm2);
                }
            }
            else
            {
                if (Game.Player.Character.LastVehicle != null)
                {
                    if (Game.Player.Character.LastVehicle.NumberPlate.Trim() == TTTFmenu.rcmodel)
                    {
                        if (TTTFmenu.RCmode)
                            if (!Game.Player.Character.IsVisible)
                                Game.Player.Character.Task.WarpIntoVehicle(Game.Player.Character.LastVehicle, VehicleSeat.Driver);
                    } 
                }
            }

            try
            {
                int ypos = 50;
                if (timecurcuitssystem.bttfList.Count > 0)
                {
                    foreach (string car in timecurcuitssystem.bttfList.Keys)
                    {
                        #region time check
                        NativeUI.UIResText TimedisplayDelorean =
                            new NativeUI.UIResText(displaysystem.timedisplay(timecurcuitssystem.bttfList[car].presmonth1, timecurcuitssystem.bttfList[car].presmonth2,
                            timecurcuitssystem.bttfList[car].presday1, timecurcuitssystem.bttfList[car].presday2,
                            timecurcuitssystem.bttfList[car].presy1, timecurcuitssystem.bttfList[car].presy2, timecurcuitssystem.bttfList[car].presy3, timecurcuitssystem.bttfList[car].presy4,
                            timecurcuitssystem.bttfList[car].presh1, timecurcuitssystem.bttfList[car].presh2, timecurcuitssystem.bttfList[car].presampm,
                            timecurcuitssystem.bttfList[car].presm1, timecurcuitssystem.bttfList[car].presm2) + car,
                            new System.Drawing.Point(20, ypos), (float)0.6, System.Drawing.Color.GreenYellow);
                        TimedisplayDelorean.Draw();
                        ypos += 30;

                        if (timecurcuitssystem.bttfList[car].getDelorean().Health < 300)
                        {

                            if (ranint == 2)
                            {
                                if (!Sounds.cirerror.getPlayState())
                                {
                                    Sounds.cirerror.Play();
                                    ranint = 3;
                                }
                            }
                            else
                            {
                                if (!Sounds.cirerror.getPlayState())
                                {
                                    ranint = errorDisplay.Next(1, 200);
                                }
                                else
                                {
                                    if (Sounds.cirerror.gettime() < 400)
                                    {
                                        timecurcuitssystem.bttfList[car].bug = true;
                                    }

                                    if (Sounds.cirerror.gettime() < 700)
                                    {
                                        timecurcuitssystem.bttfList[car].bug = false;
                                    }

                                    if (Sounds.cirerror.gettime() < 1100)
                                    {
                                        timecurcuitssystem.bttfList[car].bug = true;
                                    }

                                    if (Sounds.cirerror.gettime() < 1400)
                                    {
                                        timecurcuitssystem.bttfList[car].bug = false;
                                    }

                                    if (Sounds.cirerror.gettime() < 1800)
                                    {
                                        timecurcuitssystem.bttfList[car].bug = true;
                                    }

                                    if (Sounds.cirerror.gettime() < 2100)
                                    {
                                        timecurcuitssystem.bttfList[car].bug = false;
                                    }

                                    if (Sounds.cirerror.gettime() < 2400)
                                    {
                                        timecurcuitssystem.bttfList[car].bug = true;
                                    }

                                    if (Sounds.cirerror.gettime() < 2700)
                                    {
                                        timecurcuitssystem.bttfList[car].bug = false;
                                    }

                                    if (Sounds.cirerror.gettime() < 3000)
                                    {
                                        timecurcuitssystem.bttfList[car].bug = false;
                                    }

                                    if (Sounds.cirerror.gettime() < 3400)
                                    {
                                        timecurcuitssystem.bttfList[car].bug = true;
                                    }
                                }
                            }
                        }

                        timecurcuitssystem.effectProps[car].wormholeTick(timecurcuitssystem.bttfList[car].getDelorean());
                        timecurcuitssystem.effectProps[car].flickerTick(timecurcuitssystem.bttfList[car]);
                        if (DateTime.Now.Millisecond > 500 && DateTime.Now.Millisecond <= 1000)
                        {
                            if (!ticktock)
                            {
                                timecurcuitssystem.effectProps[car].Display(timecurcuitssystem.bttfList[car].getDelorean(),
                                    timecurcuitssystem.bttfList[car].toggletimecurcuits,
                                    timecurcuitssystem.bttfList[car].getDelorean().EngineRunning,
                                    timecurcuitssystem.bttfList[car].refilltimecurcuits,
                                    timecurcuitssystem.bttfList[car].getDelorean().BodyHealth,
                                    timecurcuitssystem.bttfList[car].fmonth1,
                                    timecurcuitssystem.bttfList[car].fmonth2,
                                    timecurcuitssystem.bttfList[car].fday1,
                                    timecurcuitssystem.bttfList[car].fday2,
                                    timecurcuitssystem.bttfList[car].fy1,
                                    timecurcuitssystem.bttfList[car].fy2,
                                    timecurcuitssystem.bttfList[car].fy3,
                                    timecurcuitssystem.bttfList[car].fy4,
                                    timecurcuitssystem.bttfList[car].fh1,
                                    timecurcuitssystem.bttfList[car].fh2,
                                    timecurcuitssystem.bttfList[car].fampm,
                                    timecurcuitssystem.bttfList[car].fm1,
                                    timecurcuitssystem.bttfList[car].fm2,
                                    presmonth1,
                                    presmonth2,
                                    presday1,
                                    presday2,
                                    presy1,
                                    presy2,
                                    presy3,
                                    presy4,
                                    presh1,
                                    presh2,
                                    presampm,
                                    presm1,
                                    presm2,
                                    timecurcuitssystem.bttfList[car].pastmonth1,
                                    timecurcuitssystem.bttfList[car].pastmonth2,
                                    timecurcuitssystem.bttfList[car].pastday1,
                                    timecurcuitssystem.bttfList[car].pastday2,
                                    timecurcuitssystem.bttfList[car].pasty1,
                                    timecurcuitssystem.bttfList[car].pasty2,
                                    timecurcuitssystem.bttfList[car].pasty3,
                                    timecurcuitssystem.bttfList[car].pasty4,
                                    timecurcuitssystem.bttfList[car].pasth1,
                                    timecurcuitssystem.bttfList[car].pasth2,
                                    timecurcuitssystem.bttfList[car].pastampm,
                                    timecurcuitssystem.bttfList[car].pastm1,
                                    timecurcuitssystem.bttfList[car].pastm2,
                                    timecurcuitssystem.bttfList[car].bug);
                                ticktock = true;
                            }
                        }
                        else
                        {
                            if (ticktock)
                            {
                                ticktock = false;
                            }
                        }
                        timecurcuitssystem.circuits[car].runningCircuits(timecurcuitssystem.bttfList[car], timecurcuitssystem.wormhole[car]);
                        effects.flux_capcitor(timecurcuitssystem.bttfList[car].getDelorean());
                        timecurcuitssystem.circuits[car].tickfreeze(timecurcuitssystem.bttfList[car].getDelorean());
                        #endregion

                        if (!timecurcuitssystem.bttfList[car].getDelorean().IsDriveable)
                        {

                            if (!timecurcuitssystem.bttfList[car].deadplay)
                            {
                                Sounds.trend.Play();
                                timecurcuitssystem.bttfList[car].deadplay = true;
                                if (TTTFmenu.RCmode)
                                {
                                    timecurcuitssystem.bttfList[TTTFmenu.rcmodel.Trim()].ToggleRCmode();
                                    TTTFmenu.rcmodel = "";
                                    TTTFmenu.RCmode = false;
                                }
                                timecurcuitssystem.bttfList.Remove(car);
                                timecurcuitssystem.circuits.Remove(car);
                                timecurcuitssystem.effectProps.Remove(car);
                                timecurcuitssystem.wormhole.Remove(car);
                            }
                        }
                    } 
                }
                if (World.GetClosestVehicle(Game.Player.Character.Position, 10) != null)
                {
                    Doors.doors(World.GetClosestVehicle(Game.Player.Character.Position, 10).FriendlyName == "DMC12", World.GetClosestVehicle(Game.Player.Character.Position, 10), false);
                }
            }
            catch (Exception e)
            {
                Sounds.unLoad();
                foreach (string car in timecurcuitssystem.bttfList.Keys)
                    timecurcuitssystem.effectProps[car].removeWormhole();

                string[] error = new string[] { e.ToString(), "\n", e.Message, "\n", e.StackTrace, "\n", e.TargetSite.Name };
                File.WriteAllLines(Application.StartupPath + "\\TTTF Error.log", error);
                while (true)
                {
                    UI.Notify("Problem");
                    //UI.Notify(e.Message);
                    //UI.Notify(e.StackTrace);
                    //UI.Notify(e.TargetSite.Name);
                    UI.Notify(e.ToString());
                    Script.Wait(10);
                }
            }
        }
    }
}

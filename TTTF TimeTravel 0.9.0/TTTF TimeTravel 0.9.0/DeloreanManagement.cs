using GTA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTTF_TimeTravel_0._9._0
{
    class DeloreanManagement
    {
        static Random rand = new Random();

        public void currentGameTime()
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

            if (hour > 12)
            {
                presampm = "pm";
            }
            else
            {
                presampm = "am";
            }
        }

        public void setPresentTime()
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

        public int presday1 = 1, presday2 = 0, presmonth1 = 0, presmonth2 = 9, presy1 = 1, presy2 = 9, presy3 = 9, presy4 = 5, presh1 = 0, presh2 = 6, presm1 = 1, presm2 = 1;
        public string presampm = "pm";


        public static void tick()
        {
            if (Game.Player.Character.IsInVehicle())
            {
                Delorean temp = null;
                string car = Game.Player.Character.CurrentVehicle.NumberPlate.Trim();
                if (timecurcuitssystem.bttfList.TryGetValue(car, out temp))
                {
                    timecurcuitssystem.DisplayScreenTimePanel();
                    effects.flux_capcitor(Game.Player.Character.CurrentVehicle);
                    timecurcuitssystem.circuits[car].runningCircuits(timecurcuitssystem.bttfList[car], timecurcuitssystem.wormhole[car]);
                    timecurcuitssystem.circuits[car].tickfreeze(timecurcuitssystem.bttfList[car].getDelorean());
                }
            }
            else
            {
                if (Game.Player.Character.LastVehicle.NumberPlate.Trim() == TTTFmenu.rcmodel)
                {
                    if (TTTFmenu.RCmode)
                        if (!Game.Player.Character.IsVisible)
                            Game.Player.Character.Task.WarpIntoVehicle(Game.Player.Character.LastVehicle, VehicleSeat.Driver);
                }
            }



            try
            {
                foreach (string car in timecurcuitssystem.bttfList.Keys)
                {
                    #region time check

                    #endregion

                    if (timecurcuitssystem.bttfList[car].getDelorean().IsDead)
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
                        }
                    }
                }
                Doors.doors(World.GetClosestVehicle(Game.Player.Character.Position, 10).FriendlyName == "DMC12", World.GetClosestVehicle(Game.Player.Character.Position, 10), false);
            }
            catch
            {

            }
        }
    }
}

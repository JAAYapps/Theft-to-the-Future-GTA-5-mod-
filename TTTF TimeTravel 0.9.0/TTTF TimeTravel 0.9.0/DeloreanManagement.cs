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
        
        public static void tick()
        {
            if (Game.Player.Character.IsInVehicle())
            {
                Delorean temp = null;
                if (timecurcuitssystem.bttfList.TryGetValue(Game.Player.Character.CurrentVehicle.NumberPlate.Trim(), out temp))
                {
                    timecurcuitssystem.DisplayScreenTimePanel();
                    effects.flux_capcitor(Game.Player.Character.CurrentVehicle);
                    TimeTravel.runningCircuits(timecurcuitssystem.bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()]);
                    TimeTravel.tickfreeze(timecurcuitssystem.bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].getDelorean());
                }
            }
            else
            {
                if (Game.Player.Character.LastVehicle.NumberPlate.Trim() == TTTFmenu.rcmodel)
                {
                    if (TTTFmenu.RCmode)
                        Game.Player.Character.Task.WarpIntoVehicle(Game.Player.Character.LastVehicle, VehicleSeat.Driver);
                }
            }

            

            try
            {
                foreach (string car in timecurcuitssystem.bttfList.Keys)
                {
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
                Doors.doors(World.GetClosestVehicle(Game.Player.Character.Position, 10).FriendlyName == "DMC12", false, World.GetClosestVehicle(Game.Player.Character.Position, 10), false);
            }
            catch
            {

            }
        }
    }
}

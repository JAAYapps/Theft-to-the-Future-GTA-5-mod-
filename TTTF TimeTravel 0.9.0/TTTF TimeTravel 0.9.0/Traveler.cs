using GTA;
using GTA.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TTTF_TimeTravel_0._9._0
{
    class Traveler
    {
        public static bool enabled = false;
        static Ped traveler = null;
        public static void autoSetCircuits()
        {
            Script.Wait(600);
            timecurcuitssystem.keyset(Keys.NumPad0);
            Script.Wait(400);
            timecurcuitssystem.keyset(Keys.NumPad9);
            Script.Wait(400);
            timecurcuitssystem.keyset(Keys.NumPad1);
            Script.Wait(400);
            timecurcuitssystem.keyset(Keys.NumPad0);
            Script.Wait(400);
            timecurcuitssystem.keyset(Keys.NumPad2);
            Script.Wait(400);
            timecurcuitssystem.keyset(Keys.NumPad0);
            Script.Wait(400);
            timecurcuitssystem.keyset(Keys.NumPad1);
            Script.Wait(400);
            timecurcuitssystem.keyset(Keys.NumPad5);
            Script.Wait(400);
            timecurcuitssystem.keyset(Keys.Enter);
        }

        public static void tick()
        {
            try
            {
                while (!traveler.IsInVehicle(timecurcuitssystem.bttfList[traveler.CurrentVehicle.NumberPlate.Trim()].getDelorean()) && traveler.IsAlive)
                {
                    try
                    {
                        if (Game.Player.Character.IsInVehicle())
                        {
                            if (!traveler.IsInVehicle())
                            {
                                traveler.Task.EnterVehicle(Game.Player.Character.CurrentVehicle, VehicleSeat.Passenger);
                            }
                        }
                        else
                        {
                            if (traveler.IsInVehicle())
                                if (!Game.Player.Character.IsInVehicle())
                                    traveler.Task.LeaveVehicle();
                            traveler.Task.RunTo(Game.Player.Character.GetOffsetInWorldCoords(new Vector3(0, -3, 0)));
                        }
                    }
                    catch (Exception e)
                    {
                        UI.ShowSubtitle(e.Message);
                    }
                    Doors.doorswithwait(true, false, timecurcuitssystem.bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].getDelorean(), false, 2000);
                }
                if (!traveler.IsDead)
                    autoSetCircuits();
                else
                    UI.ShowSubtitle("You from the future Died");
            }
            catch
            {

            }
        }
    }
}

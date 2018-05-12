using GTA;
using GTA.Math;
using GTA.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTTF_TimeTravel_0._9._0
{
    class helpFromDoc
    {
        static bool docshelp = false;
        static Ped Doc;
        static Vehicle truck;
        static Vehicle delorean = null;
        public static void Docs_help()
        {
            truck = World.CreateVehicle("benson", World.GetNextPositionOnStreet(Game.Player.Character.GetOffsetInWorldCoords(new Vector3(0, 150, 0))));
            truck.EngineRunning = true;
            Doc = truck.CreatePedOnSeat(VehicleSeat.Driver, PedHash.Scientist01SMM);
            Doc.Task.DriveTo(truck, Game.Player.Character.Position, 10, 30);
            Doc.AddBlip();
            docshelp = true;
            delorean = Game.Player.Character.CurrentVehicle;
        }

        static bool runoncedochelp = false;
        static bool inGreatShock = false;
        public static void tick()
        {
            if (docshelp)
            {
                if (Doc.IsInRangeOf(delorean.Position, 30))
                {
                    if (delorean.EngineHealth >= 500)
                    {
                        if (runoncedochelp)
                        {
                            Doc.Task.ClearAll();
                            Doc.Task.EnterVehicle(truck, VehicleSeat.Driver);
                            Doc.Task.CruiseWithVehicle(truck, 20);
                            runoncedochelp = false;
                        }
                    }
                    else
                    {
                        if (!runoncedochelp)
                        {
                            Doc.Task.ClearAll();
                            Doc.Task.LeaveVehicle();
                            Script.Wait(1000);
                            Doc.Task.RunTo(new Vector3(delorean.Position.X,
                                delorean.Position.Y - (int)2.5,
                                delorean.Position.Z));
                            if (!Doc.IsInVehicle())
                                runoncedochelp = true;
                        }

                        if (Doc.IsInRangeOf(delorean.Position, 3))
                        {
                            Doc.Task.ClearAll();
                            Doc.Task.LookAt(delorean);
                            if (delorean.BodyHealth <= 300)
                            {
                                if (!inGreatShock)
                                    Sounds.greatscott.Play();
                                inGreatShock = true;
                            }

                            delorean.EngineHealth++;
                            UI.ShowSubtitle("Repairing engine");
                        }
                    }
                }
                if (!Doc.IsInRangeOf(delorean.Position, 200))
                {
                    if (delorean.EngineHealth >= 500)
                    {
                        docshelp = false;
                        inGreatShock = false;
                        try
                        {
                            Doc.Delete();
                            truck.Delete();
                        }
                        catch
                        {

                        }
                    }
                }
            }
        }
    }
}

using GTA;
using GTA.Math;
using GTA.Native;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTTF_TimeTravel_0._9._0
{
    class Libeads
    {
        public static Prop plutblip;
        public static int plutonium = 1;
        static Vehicle libeadscar = null;
        static Ped shooter = null;
        static Ped driver = null;
        static bool pedshoot = false;
        static int sendcommand = 0;
        public static bool timejump = false;
        public static void tick()
        {
            if (plutonium == 0)
            {
                if (!timejump)
                {
                    World.DrawMarker(MarkerType.VerticalCylinder, new Vector3(2425.67f, 3093.06f, 48f), new Vector3(0, 0, 0), new Vector3(0, 11, 0), new Vector3(2, 2, 2), Color.Tomato);
                    if (Game.Player.Character.IsInRangeOf(new Vector3(2425.67f, 3093.06f, 48f), 2))
                    {
                        plutblip.Delete();
                        plutonium = 12;
                        libeadscar = World.CreateVehicle(new Model("volkvan"), new Vector3(2361.11f, 3132.86f, 47.94f), 258.04f);
                        libeadscar.CreatePedOnSeat(VehicleSeat.Driver, PedHash.Eastsa01AMM);
                        shooter = World.CreatePed(PedHash.Eastsa02AMM, libeadscar.Position);
                        shooter.HasCollision = false;
                        shooter.IsInvincible = true;
                        driver = libeadscar.GetPedOnSeat(VehicleSeat.Driver);
                        libeadscar.GetPedOnSeat(VehicleSeat.Driver).IsInvincible = true;
                        libeadscar.GetPedOnSeat(VehicleSeat.Driver).AlwaysKeepTask = true;
                        libeadscar.GetPedOnSeat(VehicleSeat.Driver).DrivingStyle = DrivingStyle.AvoidTrafficExtremely;
                        libeadscar.GetPedOnSeat(VehicleSeat.Driver).Task.VehicleChase(Game.Player.Character);
                        libeadscar.GetPedOnSeat(VehicleSeat.Driver).DrivingSpeed = 100;
                        libeadscar.AddBlip();
                        libeadscar.Speed = 6;
                        Script.Wait(10);
                        try
                        {
                            libeadscar.GetPedOnSeat(VehicleSeat.Driver).RelationshipGroup = World.AddRelationshipGroup("Libeads");
                            shooter.RelationshipGroup = libeadscar.GetPedOnSeat(VehicleSeat.Driver).RelationshipGroup;
                            bool first = false;
                            Ped z = null;
                            foreach (Ped i in World.GetAllPeds())
                            {
                                if (i != shooter)
                                {
                                    if (i != driver)
                                    {
                                        if (i != Game.Player.Character)
                                            if (!first)
                                            {
                                                i.RelationshipGroup = World.AddRelationshipGroup("random");
                                                z = i;
                                                first = true;
                                            }
                                            else
                                            {
                                                i.RelationshipGroup = z.RelationshipGroup;
                                                z = i;
                                            }
                                    }
                                }
                            }
                            Game.Player.Character.RelationshipGroup = World.AddRelationshipGroup("Delorean");
                            World.SetRelationshipBetweenGroups(Relationship.Hate, shooter.RelationshipGroup, Game.Player.Character.RelationshipGroup);
                            World.SetRelationshipBetweenGroups(Relationship.Respect, shooter.RelationshipGroup, z.RelationshipGroup);
                            libeadscar.EngineRunning = true;
                            libeadscar.EnginePowerMultiplier = 100;
                            libeadscar.SetMod(VehicleMod.Brakes, 2, true);
                            libeadscar.ApplyForceRelative(new Vector3(0, 6, 0));
                        }
                        catch (Exception f)
                        {
                            UI.ShowSubtitle("Error: " + f.Message);
                        }
                    }
                }
            }
            else
            {
                if (libeadscar != null && shooter != null)
                {
                    if (!timejump)
                    {
                        shooter.Position = libeadscar.Position;
                        if (Game.Player.Character.Model != new Model("S_M_M_Doctor_01"))
                        {
                            if (!libeadscar.IsNearEntity(Game.Player.Character, new Vector3(200, 200, 200)))
                            {
                                libeadscar.Position = World.GetNextPositionOnStreet(Game.Player.Character.GetOffsetInWorldCoords(new Vector3(0, -140, 0)));
                                libeadscar.Rotation = Game.Player.Character.Rotation;
                                libeadscar.Speed = 20;
                            }
                        }
                        if (sendcommand == 100)
                        {
                            if (!driver.IsInVehicle(libeadscar))
                                driver.Task.WarpIntoVehicle(libeadscar, VehicleSeat.Driver);
                            else
                                driver.Task.VehicleChase(Game.Player.Character);
                            sendcommand = 0;
                        }
                        else
                            sendcommand++;
                        if (!pedshoot)
                        {
                            shooter.Weapons.Give(WeaponHash.AssaultRifle, 999, true, true);
                            shooter.Task.ShootAt(Game.Player.Character);
                            pedshoot = true;
                        }
                    }
                    else
                    {
                        pedshoot = false;
                        timejump = false;
                        libeadscar.Explode();
                        Script.Wait(500);
                        libeadscar.GetPedOnSeat(VehicleSeat.Driver).Delete();
                        libeadscar.Delete();
                        shooter.Delete();
                        libeadscar = null;
                        shooter = null;
                    }
                }
            }
        }
    }
}

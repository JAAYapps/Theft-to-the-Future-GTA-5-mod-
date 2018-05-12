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
    class spawn_delorean
    {
        public static void spawn(Model Deloreanmodel, bool rescue)
        {
            if (Deloreanmodel.IsValid)
            {
                try
                {
                    Vehicle Deloreon = null;
                    Vector3 position;
                    if (rescue)
                        position = Game.Player.Character.GetOffsetInWorldCoords(new Vector3(0, 50, 0));
                    else
                        position = Game.Player.Character.GetOffsetInWorldCoords(new Vector3(0, 0, 0));
                    // At 90 degrees to the players heading
                    float heading = Game.Player.Character.Heading - 90;
                    Ped traveler = null;
                    mainsystem.messageerrors[3] = "after traveler is null";
                    while (Deloreon == null)
                    {
                        try
                        {
                            Deloreon = World.CreateVehicle(Deloreanmodel, position, heading);
                            Function.Call(Hash.SET_VEHICLE_MOD_KIT, Deloreon.Handle, 0);
                            Deloreon.SetMod(VehicleMod.RearBumper, 2, true);
                            Deloreon.ToggleMod(VehicleToggleMod.Turbo, true);
                            Deloreon.SetMod(VehicleMod.Frame, -1, true);
                            Deloreon.SetMod(VehicleMod.Horns, 16, true);
                            Deloreon.SetMod(VehicleMod.RearBumper, 0, true);
                            Deloreon.SetMod(VehicleMod.RightFender, 0, true);
                            Deloreon.SetMod(VehicleMod.Fender, 0, true);
                            Deloreon.SetMod(VehicleMod.ArchCover, 0, true);
                            Deloreon.SetMod(VehicleMod.Exhaust, 0, true);
                            Deloreon.SetMod(VehicleMod.Hood, 0, true);
                            Deloreon.SetMod(VehicleMod.Ornaments, 0, true);
                            if (!Function.Call<bool>(Hash.IS_VEHICLE_EXTRA_TURNED_ON, new InputArgument[] { Deloreon, 10 }))
                            {
                                Function.Call(Hash.SET_VEHICLE_EXTRA, new InputArgument[] { Deloreon, 10, 0 });
                            }
                            if (Function.Call<bool>(Hash.IS_VEHICLE_EXTRA_TURNED_ON, new InputArgument[] { Deloreon, 1 }))
                            {
                                Function.Call(Hash.SET_VEHICLE_EXTRA, new InputArgument[] { Deloreon, 1, -1 });
                            }
                        }
                        catch
                        {

                        }
                        if (Deloreon == null && Function.Call<bool>(Hash.IS_VEHICLE_EXTRA_TURNED_ON, new InputArgument[] { Deloreon, 1 }))
                        {
                            Script.Wait(500);
                        }
                        //else
                        //{
                        //    break;
                        //}
                    }
                    if (rescue)
                        Deloreon.Rotation = new Vector3(Game.Player.Character.Rotation.X, Game.Player.Character.Rotation.Y, Game.Player.Character.Rotation.Z + 180);
                    else
                        Deloreon.Rotation = new Vector3(Game.Player.Character.Rotation.X, Game.Player.Character.Rotation.Y, Game.Player.Character.Rotation.Z);
                    Deloreon.PlaceOnGround();
                    Deloreon.DirtLevel = 0;
                    Deloreon.NumberPlate = "OutATime";
                    Script.Wait(50);
                    // Set the vehicle mods
                    Function.Call(Hash.SET_VEHICLE_MOD_KIT, Deloreon.Handle, 0);
                    Deloreon.SetMod(VehicleMod.RearBumper, 2, true);
                    Deloreon.ToggleMod(VehicleToggleMod.Turbo, true);
                    Deloreon.SetMod(VehicleMod.Frame, -1, true);
                    Deloreon.SetMod(VehicleMod.Horns, 16, true);
                    Deloreon.SetMod(VehicleMod.RearBumper, 0, true);
                    Deloreon.SetMod(VehicleMod.RightFender, 0, true);
                    Deloreon.SetMod(VehicleMod.Fender, 0, true);
                    Deloreon.SetMod(VehicleMod.ArchCover, 0, true);
                    Deloreon.SetMod(VehicleMod.Exhaust, 0, true);
                    Deloreon.SetMod(VehicleMod.Hood, 0, true);
                    Deloreon.SetMod(VehicleMod.Ornaments, 0, true);
                    //Game.Player.Character.Task.WarpIntoVehicle(Deloreon, VehicleSeat.Driver);
                    Deloreon.PrimaryColor = VehicleColor.MetallicBlueSilver;
                    Deloreon.SecondaryColor = VehicleColor.BrushedAluminium;
                    Deloreon.AddBlip();
                    Deloreon.CurrentBlip.Color = BlipColor.White;
                    if (rescue)
                    {
                        traveler = Deloreon.CreatePedOnSeat(VehicleSeat.Driver, Game.Player.Character.Model);
                        traveler.RandomizeOutfit();
                        Deloreon.IsVisible = false;
                        timecurcuitssystem.addToList(Game.GetUserInput(7).ToUpper(), Deloreon, true);
                        traveler.CanBeDraggedOutOfVehicle = true;
                        if (Deloreon.Model == "bttf3" || Deloreon.Model == "bttf3rr")
                        {
                            Sounds.reenterybttf3.Play();
                        }
                        else if (Deloreon.Model == "bttf")
                        {
                            Sounds.reenterybttf1.Play();
                        }
                        else
                            Sounds.reenterybttf2.Play();

                        if (Deloreon.Model == new Model("BTTF"))
                        {
                            World.DrawSpotLight(Deloreon.Position, Deloreon.Rotation, Color.SkyBlue, 80, 100, 60, 100, 5);
                            Deloreon.IsVisible = true;
                            Script.Wait(10);
                            Deloreon.Speed = 0;
                            Deloreon.IsVisible = false;
                            Deloreon.Speed = 0;
                            Script.Wait(50);
                            Deloreon.Speed = 0;
                            World.DrawSpotLight(Deloreon.Position, Deloreon.Rotation, Color.SkyBlue, 80, 100, 60, 100, 5);
                            Deloreon.IsVisible = true;
                            Script.Wait(10);
                            Deloreon.Speed = 0;
                            Deloreon.IsVisible = false;
                            Script.Wait(50);
                            Deloreon.Speed = 0;
                            World.DrawSpotLight(Deloreon.Position, Deloreon.Rotation, Color.SkyBlue, 80, 100, 60, 100, 5);
                            Deloreon.IsVisible = true;
                            Script.Wait(10);
                            Deloreon.Speed = 0;
                        }
                        else
                        {
                            try
                            {
                                World.DrawSpotLight(Deloreon.Position, Deloreon.Rotation, Color.DeepSkyBlue, 80, 100, 60, 100, 5);
                                Deloreon.Speed = 0;
                                if (Deloreon.Model == new Model("BTTF3") || Deloreon.Model == new Model("BTTF3rr"))
                                    effects.make_effect("scr_martin1", "scr_sol1_sniper_impact", Deloreon);
                                Script.Wait(700);
                                Deloreon.Speed = 0;
                                if (Deloreon.Model == new Model("BTTF3") || Deloreon.Model == new Model("BTTF3rr"))
                                    effects.make_effect("scr_martin1", "scr_sol1_sniper_impact", Deloreon);
                                World.DrawSpotLight(Deloreon.Position, Deloreon.Rotation, Color.DeepSkyBlue, 80, 100, 60, 100, 5);
                                Script.Wait(700);
                                Deloreon.Speed = 0;
                                if (Deloreon.Model == new Model("BTTF3") || Deloreon.Model == new Model("BTTF3rr"))
                                    effects.make_effect("scr_martin1", "scr_sol1_sniper_impact", Deloreon);
                                World.DrawSpotLight(Deloreon.Position, Deloreon.Rotation, Color.DeepSkyBlue, 80, 100, 60, 100, 5);
                            }
                            catch
                            {

                            }
                        }
                        Deloreon.Speed = 30;
                        Script.Wait(10);
                        Deloreon.IsVisible = true;
                        traveler.IsVisible = true;
                        while (Deloreon.Speed != 0)
                        {
                            Script.Wait(50);
                            Deloreon.ApplyForceRelative(new Vector3(0, 0, 0), new Vector3(30, 0, 0));
                        }
                        traveler.Task.LeaveVehicle(Deloreon, false);
                        for (int count = 0; count < 300; count++)
                        {
                            Doors.doors(true, true, Deloreon, false);
                            Script.Wait(10);
                        }
                        traveler.Task.GoTo(Deloreon.GetOffsetInWorldCoords(new Vector3(3, -3.6f, -5.5f)), false);
                        for (int count = 0; count < 100; count++)
                        {
                            Doors.doors(true, true, Deloreon, false);
                            Script.Wait(10);
                        }
                        traveler.Task.GoTo(Deloreon.GetOffsetInWorldCoords(new Vector3(0, -2.6f, 0.5f)), true);
                        for (int count = 0; count < 70; count++)
                        {
                            Doors.doors(true, true, Deloreon, false);
                            Script.Wait(10);
                        }
                        traveler.Task.ClearAll();
                        traveler.Task.StartScenario("PROP_HUMAN_ATM", Deloreon.GetOffsetInWorldCoords(new Vector3(0, -2.6f, 0.5f)));
                        for (int count = 0; count < 70; count++)
                        {
                            Doors.doors(true, true, Deloreon, false);
                            Script.Wait(10);
                        }
                        traveler.Rotation = Deloreon.Rotation;
                        if (Deloreon != null)
                        {
                            if (Deloreon.Model == "bttf")
                            {
                                Sounds.pr0load.Play();
                                Deloreon.OpenDoor(VehicleDoor.Trunk, false, false);
                                Script.Wait(3000);
                                Deloreon.CloseDoor(VehicleDoor.Trunk, false);
                            }
                            else
                            {
                                Sounds.Mrfrusionfill.Play();
                                Deloreon.OpenDoor(VehicleDoor.Trunk, false, false);
                                Script.Wait(4000);
                                Deloreon.CloseDoor(VehicleDoor.Trunk, false);
                            }
                            Traveler.enabled = true;
                        }
                    }
                    else
                    {
                        Game.Player.Character.Task.WarpIntoVehicle(Deloreon, VehicleSeat.Driver);
                        timecurcuitssystem.addToList(Game.GetUserInput(7).ToUpper(), Deloreon);
                    }
                }
                catch(Exception d)
                {
                    mainsystem.messageerrors[0] = d.Message;
                    mainsystem.messageerrors[1] = d.Source;
                    mainsystem.messageerrors[2] = d.TargetSite.ToString();
                    mainsystem.display_errors = true;
                }
            }
        }
    }
}

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
        public static void spawn(Model Deloreanmodel, double movie, bool rescue)
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
                    //mainsystem.messageerrors[3] = "after traveler is null";
                    while (Deloreon == null)
                    {
                        try
                        {
                            Deloreon = World.CreateVehicle(Deloreanmodel, position, heading);
                            //if (!Function.Call<bool>(Hash.IS_VEHICLE_EXTRA_TURNED_ON, new InputArgument[] { Deloreon, 10 }))
                            //{
                            //    Function.Call(Hash.SET_VEHICLE_EXTRA, new InputArgument[] { Deloreon, 10, 0 });
                            //}
                            //if (Function.Call<bool>(Hash.IS_VEHICLE_EXTRA_TURNED_ON, new InputArgument[] { Deloreon, 1 }))
                            //{
                            //    Function.Call(Hash.SET_VEHICLE_EXTRA, new InputArgument[] { Deloreon, 1, -1 });
                            //}
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
                    //Game.Player.Character.Task.WarpIntoVehicle(Deloreon, VehicleSeat.Driver);
                    Deloreon.AddBlip();
                    if (rescue)
                    {
                        traveler = Deloreon.CreatePedOnSeat(VehicleSeat.Driver, Game.Player.Character.Model);
                        traveler.RandomizeOutfit();
                        Deloreon.IsVisible = false;
                        timecurcuitssystem.addToList(Game.GetUserInput(7).ToUpper(), movie, Deloreon, true);
                        traveler.CanBeDraggedOutOfVehicle = true;
                        if (movie == 3 || movie == 3.5)
                        {
                            Sounds.reenterybttf3.Play();
                        }
                        else if (movie == 1)
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
                        for (int count = 0; count < 100; count++)
                        {
                            Doors.doors(true, Deloreon, false);
                            Script.Wait(10);
                        }
                        traveler.Task.GoTo(Deloreon.GetOffsetInWorldCoords(new Vector3(0, -3.6f, 0)), false);
                        for (int count = 0; count < 100; count++)
                        {
                            Doors.doors(true, Deloreon, false);
                            Script.Wait(10);
                        }
                        traveler.Task.GoTo(Deloreon.GetOffsetInWorldCoords(new Vector3(0, -2.3f, 0)), true);
                        for (int count = 0; count < 70; count++)
                        {
                            Doors.doors(true, Deloreon, false);
                            Script.Wait(10);
                        }
                        traveler.Task.ClearAll();
                        Function.Call(Hash.REQUEST_ANIM_DICT, "ah_1_mcs_1-0");
                        while (!Function.Call<bool>(Hash.HAS_ANIM_DICT_LOADED, "ah_1_mcs_1-0"))
                        {
                            Doors.doors(true, Deloreon, false);
                            Script.Wait(10);
                        }
                        Game.Player.Character.Position = Deloreon.GetOffsetInWorldCoords(new Vector3(0, -2.3f, -1));
                        Game.Player.Character.Rotation = Deloreon.Rotation;

                        Function.Call(Hash.REQUEST_ANIM_DICT, "ah_1_mcs_1-0");
                        Vector3 animxyz = Game.Player.Character.Position;
                        Vector3 animrot = Game.Player.Character.Rotation;
                        Function.Call(Hash.TASK_PLAY_ANIM_ADVANCED, Game.Player.Character, "ah_1_mcs_1-0", "csb_janitor_dual-0", animxyz.X, animxyz.Y, animxyz.Z, animrot.X, animrot.Y, animrot.Z, 0.8f, 0.5, 6000, (int)AnimationFlags.UpperBodyOnly, 0.35f, false, false);
                        for (int count = 0; count < 15; count++)
                        {
                            Doors.doors(true, Deloreon, false);
                            Script.Wait(10);
                        }
                        if (Deloreon != null)
                        {
                            if (Deloreon.Model == "bttf")
                            {
                                Sounds.pr0load.Play();
                                Deloreon.OpenDoor(VehicleDoor.Trunk, false, false);
                                Script.Wait(3000);
                                Deloreon.CloseDoor(VehicleDoor.Trunk, false);
                                Script.Wait(500);
                                Function.Call(Hash.STOP_ANIM_TASK, Game.Player.Character, "ah_1_mcs_1-0", "csb_janitor_dual-0", 1);
                            }
                            else
                            {
                                Sounds.Mrfrusionfill.Play();
                                Deloreon.OpenDoor(VehicleDoor.Trunk, false, false);
                                Script.Wait(4000);
                                Deloreon.CloseDoor(VehicleDoor.Trunk, false);
                            }
                            Traveler.traveler = traveler;
                            Traveler.enabled = false;
                        }
                    }
                    else
                    {
                        Game.Player.Character.Task.WarpIntoVehicle(Deloreon, VehicleSeat.Driver);
                        timecurcuitssystem.addToList(Game.GetUserInput(7).ToUpper(), movie, Deloreon);
                    }
                }
                catch
                {
                    //mainsystem.messageerrors[0] = d.Message;
                    //mainsystem.messageerrors[1] = d.Source;
                    //mainsystem.messageerrors[2] = d.TargetSite.ToString();
                    //mainsystem.display_errors = true;
                }
            }
        }
    }
}

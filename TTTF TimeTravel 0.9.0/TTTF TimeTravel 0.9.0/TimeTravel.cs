using GTA;
using GTA.Math;
using GTA.Native;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TTTF_TimeTravel_0._9._0
{
    class TimeTravel
    {
        #region Delorean functions
        public static bool stoponce = false;

        public static void startMalfunction(Vehicle car)
        {
            if (car.Model == "bttf3" || car.Model == "bttf3rr")
            {
                if (Sounds.cirerrorbttf3.getPlayStateStopped())
                    Sounds.cirerrorbttf3.Play();
            }
            else
            {
                if (Sounds.cirerror.getPlayStateStopped())
                    Sounds.cirerror.Play();
            }
        }

        static void malfunction(Delorean Delorean, bool refilltimecircuits, bool toggle)
        {
            if (Delorean.getDelorean().Model == "bttf3" || Delorean.getDelorean().Model == "bttf3rr")
            {
                if (!Sounds.cirerrorbttf3.getPlayStateStopped())
                {
                    Delorean.getDelorean().SetMod(VehicleMod.SideSkirt, -1, true);
                    if (Sounds.cirerrorbttf3.gettime() > 0 && Sounds.cirerrorbttf3.gettime() < 0.024)
                    {
                        Delorean.getDelorean().SetMod(VehicleMod.SideSkirt, 0, true);
                        Delorean.bug = true;
                    }
                    else if (Sounds.cirerrorbttf3.gettime() > 0.276 && Sounds.cirerrorbttf3.gettime() < 0.815)
                    {
                        Delorean.getDelorean().SetMod(VehicleMod.SideSkirt, 0, true);
                        Delorean.bug = true;
                    }
                    else if (Sounds.cirerrorbttf3.gettime() > 1.074 && Sounds.cirerrorbttf3.gettime() < 1.848)
                    {
                        Delorean.getDelorean().SetMod(VehicleMod.SideSkirt, 0, true);
                        Delorean.bug = true;
                    }
                    else if (Sounds.cirerrorbttf3.gettimeend())
                    {
                        Delorean.getDelorean().SetMod(VehicleMod.SideSkirt, -1, true);
                        Delorean.bug = false;
                    }
                }
            }
            else
            {
                if (!Sounds.cirerror.getPlayStateStopped())
                {
                    Delorean.getDelorean().SetMod(VehicleMod.SideSkirt, -1, true);
                    if (Sounds.cirerror.gettime() > 0 && Sounds.cirerror.gettime() < 0.023)
                    {
                        Delorean.getDelorean().SetMod(VehicleMod.SideSkirt, 0, true);
                        Delorean.bug = false;
                    }
                    else if (Sounds.cirerror.gettime() > 0.189 && Sounds.cirerror.gettime() < 0.858)
                    {
                        Delorean.getDelorean().SetMod(VehicleMod.SideSkirt, 0, true);
                        Delorean.bug = true;
                    }
                    else if (Sounds.cirerror.gettime() > 1.023 && Sounds.cirerror.gettime() < 1.692)
                    {
                        Delorean.getDelorean().SetMod(VehicleMod.SideSkirt, 0, true);
                        Delorean.bug = false;
                    }
                    else if (Sounds.cirerror.gettime() > 1.858 && Sounds.cirerror.gettime() < 2.567)
                    {
                        Delorean.getDelorean().SetMod(VehicleMod.SideSkirt, 0, true);
                        Delorean.bug = true;
                    }
                    else if (Sounds.cirerror.gettime() > 2.733 && Sounds.cirerror.gettime() < 3.624)
                    {
                        Delorean.getDelorean().SetMod(VehicleMod.SideSkirt, 0, true);
                        Delorean.bug = false;
                    }
                    else if (Sounds.cirerror.gettime() > 2.733 && Sounds.cirerror.gettime() < 3.624)
                    {
                        Delorean.getDelorean().SetMod(VehicleMod.SideSkirt, 0, true);
                        Delorean.bug = true;
                    }
                    else if (Sounds.cirerror.gettimeend())
                    {
                        Delorean.getDelorean().SetMod(VehicleMod.SideSkirt, -1, true);
                        Delorean.bug = false;
                    }
                    UI.ShowSubtitle("time: " + Sounds.cirerror.gettime());
                }
            }
        }
        
        static Random rand = new Random();
        Vector3 flyingrotation = new Vector3(0, 0, 0);
        //bool fluxsoundbool = false;
        static bool flyingison = false;
        static bool tickbool = false;
        static bool errorbool = false;
        static string error = "";
        static string error2 = "";
        public static void runningCircuits(Delorean delorean)
        {
            if (delorean != null)
            {
                Vehicle Delorean = delorean.getDelorean();

                #region functions
                if (Delorean.DirtLevel > 0)
                    Delorean.DirtLevel -= 0.001f;
                #endregion

                int tempspeed = (int)((Delorean.Speed / .27777) / 1.60934);

                if (Delorean.Model == new Model("BTTF2F"))
                {
                    if (Delorean.IsDoorBroken(VehicleDoor.BackLeftDoor) || Delorean.IsDoorBroken(VehicleDoor.BackRightDoor))
                    {
                        if (Delorean.EngineHealth > 500)
                            Delorean.EngineHealth--;
                    }
                    else if (Delorean.IsDoorBroken(VehicleDoor.BackLeftDoor) && Delorean.IsDoorBroken(VehicleDoor.BackRightDoor))
                    {
                        if (Delorean.EngineHealth > 0)
                            Delorean.EngineHealth--;
                    }
                }

                if (Delorean.Model == new Model("BTTF3rr"))
                {
                    if (Game.IsKeyPressed(Keys.W))
                        if (tempspeed < 45)
                            Delorean.ApplyForceRelative(new Vector3(0, 0.5f, 0));
                    if (Game.IsKeyPressed(Keys.S))
                        if (tempspeed < 45)
                            Delorean.ApplyForceRelative(new Vector3(0, -0.5f, 0));
                    Delorean.FuelLevel = 0;
                }

                if (Delorean.Model == new Model("BTTF2") && flyingison)
                {
                    if (Delorean.HeightAboveGround > 1)
                    {
                        Delorean.ApplyForce(new Vector3(0, 0, 0.17f));
                    }
                    else
                    {
                        flyingison = false;
                    }
                }
                else if (Delorean.Model == new Model("BTTF2F"))
                {
                    flyingison = true;
                }

                if (Delorean.DirtLevel > 0)
                    Delorean.DirtLevel -= 0.001f;

                if (delorean.toggletimecurcuits)
                {
                    //timedisplay
                    if (delorean.refilltimecurcuits)
                    {
                        Function.Call(Hash.SET_VEHICLE_MOD_KIT, Delorean.Handle, 0);
                        Delorean.SetMod(VehicleMod.SideSkirt, 0, true);
                        if (Delorean.BodyHealth == 0)
                        {
                            malfunction(delorean, delorean.refilltimecurcuits, delorean.toggletimecurcuits);
                        }
                        else if (Delorean.BodyHealth < 700 && Delorean.BodyHealth > 0)
                        {
                            int n = 0;
                            if (DateTime.Now.Millisecond % 180 >= 90 && DateTime.Now.Millisecond % 180 <= 180)
                            {
                                if (!tickbool)
                                {
                                    n = rand.Next(1, (int)Delorean.BodyHealth);
                                    tickbool = true;
                                }
                            }
                            else
                            {
                                if (!delorean.bug)
                                    tickbool = false;
                            }

                            if (n == 1)
                            {
                                n++;
                                malfunction(delorean, delorean.refilltimecurcuits, delorean.toggletimecurcuits);
                            }
                        }
                    }
                    else
                    {
                        Function.Call(Hash.SET_VEHICLE_MOD_KIT, Delorean.Handle, 0);
                        Delorean.SetMod(VehicleMod.SideSkirt, -1, true);
                    }

                    effects.wormhole(Delorean, tempspeed, delorean.refilltimecurcuits);
                    if (tempspeed >= 88)
                    {
                        if (delorean.refilltimecurcuits)
                        {
                            if (delorean.getDelorean().Model == "bttf3")
                                World.DrawLightWithRange(Delorean.GetOffsetInWorldCoords(new Vector3(0, (float)2.2, (float)0.5)), Color.Orange, (float)1.2, 400);
                            else if (delorean.getDelorean().Model == "bttf3rr")
                                World.DrawLightWithRange(Delorean.GetOffsetInWorldCoords(new Vector3(0, (float)2.2, (float)0.5)), Color.Orange, (float)1.2, 400);
                            else
                                World.DrawLightWithRange(Delorean.GetOffsetInWorldCoords(new Vector3(0, (float)2.2, (float)0.5)), Color.DodgerBlue, (float)1.2, 400);
                            
                            if (errorbool)
                            {
                                UI.Notify(error2);
                                UIText debug4 = new UIText("Root Error: " + error + ". Problem: " + error2, new System.Drawing.Point(100, 500), (float)0.6);
                                debug4.Draw();
                            }
                            try
                            {
                                double time = 0;
                                time = Sounds.sparksfeul.gettime();
                                if (time < 3000)
                                {
                                    effects.wormholeAndTravel(Delorean, tempspeed, delorean.refilltimecurcuits);
                                }
                                else
                                {
                                    if (Function.Call<int>(Hash.GET_FOLLOW_VEHICLE_CAM_VIEW_MODE) == 4)
                                    {
                                        Delorean.DirtLevel = 12;
                                        //Function.Call(Hash.SET_CLOCK_DATE, getmonth(), getday(), getyear());
                                        Function.Call(Hash.SET_CLOCK_TIME, ((delorean.fh1 * 10) + delorean.fh2), ((delorean.fm1 * 10) + delorean.fm2), 0);
                                        if (delorean.refilltimecurcuits)
                                        {
                                            if (Delorean.Model == "bttf3")
                                            {
                                                Sounds.sparksbttf3.Stop();
                                            }
                                            Sounds.sparksfeul.Stop();
                                        }
                                        else
                                        {
                                            if (Delorean.Model == "bttf3")
                                            {
                                                Sounds.sparksbttf3.Stop();
                                            }
                                            Sounds.sparks.Stop();
                                        }
                                        Script.Wait(10);
                                        delorean.timetravelentry();
                                        Script.Wait(10);
                                        if (Delorean.Model == "bttf3" || Delorean.Model == "bttf3rr")
                                        {
                                            Sounds.Timetravelreentery3.Play();
                                        }
                                        else if (Delorean.Model == "bttf2")
                                        {
                                            Sounds.Timetravelreentery2.Play();
                                        }
                                        else if (Delorean.Model == "bttf2f")
                                        {
                                            Sounds.Timetravelreentery2f.Play();
                                        }
                                        else
                                        {
                                            Sounds.Timetravelreentery.Play();
                                        }
                                        Script.Wait(10);
                                        Ped[] peds = World.GetNearbyPeds(Game.Player.Character, 1000);
                                        Vehicle[] pedVehicles = World.GetNearbyVehicles(Game.Player.Character, 1000);
                                        for (int i = 0; i < peds.Length; i++)
                                        {
                                            Script.Wait(10);
                                            if (peds[i] != Delorean.GetPedOnSeat(VehicleSeat.Driver))
                                                if (peds[i] != Delorean.GetPedOnSeat(VehicleSeat.Passenger))
                                                    GTA.Native.Function.Call(GTA.Native.Hash.SET_ENTITY_COORDS_NO_OFFSET, peds[i], 0, 0, 0, 0, 0, 1);
                                        }
                                        Array.Clear(peds, 0, peds.Length);
                                        Script.Wait(10);
                                        for (int i = 0; i < pedVehicles.Length; i++)
                                        {
                                            Script.Wait(10);
                                            if (pedVehicles[i] != Delorean)
                                                GTA.Native.Function.Call(GTA.Native.Hash.SET_ENTITY_COORDS_NO_OFFSET, pedVehicles[i], 0, 0, 0, 0, 0, 1);
                                        }
                                        Array.Clear(pedVehicles, 0, pedVehicles.Length);
                                        //End Ped Despawning
                                        GTA.Native.Function.Call(GTA.Native.Hash.SET_RANDOM_WEATHER_TYPE);
                                        Script.Wait(10);
                                        Game.Player.WantedLevel = 0;

                                        Script.Wait(10);
                                        delorean.refilltimecurcuits = false;
                                        Script.Wait(10);
                                        Function.Call(Hash.SET_VEHICLE_MOD_KIT, Delorean.Handle, 0);
                                        Delorean.SetMod(VehicleMod.Spoilers, 1, true);
                                        Delorean.SetMod(VehicleMod.FrontBumper, -1, true);
                                    }
                                    else
                                    {
                                        error = "Is invincible";
                                        Delorean.IsInvincible = true;
                                        error = "check refill";
                                        if (delorean.refilltimecurcuits)
                                        {
                                            error = "check if bttf3";
                                            if (Delorean.Model == "bttf3")
                                            {
                                                error = "stop bttf3 sound";
                                                Sounds.sparksbttf3.Stop();
                                            }
                                            Sounds.sparksfeul.Stop();
                                        }
                                        else
                                        {
                                            error = "check if bttf3";
                                            if (Delorean.Model == "bttf3")
                                            {
                                                error = "stop bttf3 sound";
                                                Sounds.sparksbttf3.Stop();
                                            }
                                            Sounds.sparks.Stop();
                                        }
                                        error = "making effects";
                                        effects.make_effect("scr_rcpaparazzo1", "scr_rcpap1_camera", Delorean);
                                        error = "check bttf3 reentery sound";
                                        if (Delorean.Model == "bttf3" || Delorean.Model == "bttf3rr")
                                        {
                                            error = "play bttf3 reentry";
                                            Sounds.Timetravelreenterycutscene3.Play();
                                        }
                                        else
                                            Sounds.Timetravelreenterycutscene.Play();
                                        error = "stop once";
                                        if (!stoponce)
                                        {
                                            error = "freeze";
                                            Delorean.FreezePosition = true;
                                            error = "no collide";
                                            Delorean.HasCollision = false;
                                            error = "stoponce true";
                                            stoponce = true;
                                        }
                                        error = "is visible";
                                        Delorean.IsVisible = false;
                                        error = "turn off engine";
                                        Delorean.EngineRunning = false;

                                        for (double tempcount = 0; tempcount <= 6; tempcount += 0.2)
                                        {
                                            World.DrawSpotLight(Delorean.Position, Delorean.Rotation, Color.SkyBlue, 80, 100, 60, 100, 5);
                                            effects.make_effecttimetravel(1, tempcount + 3, Delorean);
                                            effects.make_effecttimetravel2(-1, tempcount + 3, Delorean);
                                            tempcount += 0.1;
                                            effects.make_effecttimetravel(1, tempcount + 3, Delorean);
                                            effects.make_effecttimetravel2(-1, tempcount + 3, Delorean);
                                            tempcount += 0.1;
                                            effects.make_effecttimetravel(1, tempcount + 3, Delorean);
                                            effects.make_effecttimetravel2(-1, tempcount + 3, Delorean);
                                            tempcount += 0.1;
                                            effects.make_effecttimetravel(1, tempcount + 3, Delorean);
                                            effects.make_effecttimetravel2(-1, tempcount + 3, Delorean);
                                            Script.Wait(10);
                                        }
                                        if (Game.Player.WantedLevel > 0)
                                        {
                                            Game.Player.WantedLevel = 0;
                                        }
                                        Delorean.OpenDoor(VehicleDoor.Hood, false, false);
                                        if (Function.Call<bool>(Hash.IS_VEHICLE_EXTRA_TURNED_ON, new InputArgument[] { Delorean, 10 }))
                                        {
                                            Function.Call(Hash.SET_VEHICLE_EXTRA, new InputArgument[] { Delorean, 10, -1 });
                                        }
                                        Function.Call(Hash.SET_VEHICLE_MOD_KIT, Delorean.Handle, 0);
                                        Delorean.SetMod(VehicleMod.Spoilers, 1, true);
                                        Delorean.SetMod(VehicleMod.FrontBumper, -1, true);
                                        if (Game.Player.Character.IsInVehicle(Delorean))
                                            reentry(Delorean);
                                        else
                                        {
                                            delorean.timetravelentry();
                                            delorean.refilltimecurcuits = false;
                                            Script.Wait(10);
                                            Function.Call(Hash.SET_VEHICLE_MOD_KIT, Delorean.Handle, 0);
                                            Delorean.SetMod(VehicleMod.Spoilers, 1, true);
                                            Delorean.SetMod(VehicleMod.FrontBumper, -1, true);
                                        }
                                    }
                                }
                            }
                            catch (Exception f)
                            {
                                error2 = f.Message;
                                errorbool = true;
                            }
                        }
                    }
                    else if (tempspeed < 84)
                    {
                        errorbool = false;
                        if (Delorean.Model != new Model("BTTF3") && Delorean.Model != new Model("BTTF3rr"))
                        {
                            Function.Call(Hash.SET_VEHICLE_MOD_KIT, Delorean.Handle, 0);
                            Delorean.SetMod(VehicleMod.Spoilers, 1, true);
                            stoponce = false;
                            Sounds.sparks.Stop();
                            Sounds.sparksbttf3.Stop();
                            Sounds.sparksbttf3.Stop();
                            Sounds.sparksfeul.Stop();
                            Sounds.sparks.Stop();
                            effects.resetwormhole();
                        }
                    }
                    else if (tempspeed < 64)
                    {
                        Sounds.sparksbttf3.Stop();
                        stoponce = false;
                        Sounds.sparks.Stop();
                        Function.Call(Hash.SET_VEHICLE_MOD_KIT, Delorean.Handle, 0);
                        Delorean.SetMod(VehicleMod.Spoilers, 1, true);
                        Sounds.sparksbttf3.Stop();
                        Sounds.sparksfeul.Stop();
                        Sounds.sparks.Stop();
                        effects.resetwormhole();
                    }
                }
                else
                {
                    //fluxsoundbool = false;
                    Function.Call(Hash.SET_VEHICLE_MOD_KIT, Delorean.Handle, 0);
                    Delorean.SetMod(VehicleMod.FrontBumper, -1, true);
                    Delorean.SetMod(VehicleMod.SideSkirt, -1, true);
                    Delorean.SetMod(VehicleMod.Spoilers, -1, true);
                    Delorean.SetMod(VehicleMod.Frame, -1, true);
                    Delorean.SetMod(VehicleMod.Grille, -1, true);
                    Sounds.sparksbttf3.Stop();
                    Sounds.sparksfeul.Stop();
                    Sounds.sparks.Stop();
                    effects.resetwormhole();
                }
            }
        }

        static bool timeentry = false;
        static bool timeenter = false;
        public static void reentry(Vehicle car)
        {
            Libeads.timejump = true;
            Script.Wait(2000);
            Game.FadeScreenOut(600);
            timeenter = true;
            timecurcuitssystem.bttfList[car.NumberPlate.Trim()].timetravelentry();
            effects.reseteffect();
            Script.Wait(1000);
            if (!timeentry)
            {
                //Start Ped Despawning
                Ped[] peds = World.GetNearbyPeds(Game.Player.Character, 100);
                Vehicle[] pedVehicles = World.GetNearbyVehicles(Game.Player.Character, 100);
                for (int i = 0; i < peds.Length; i++)
                {
                    if (peds[i] != timecurcuitssystem.bttfList[car.NumberPlate.Trim()].getDelorean().GetPedOnSeat(VehicleSeat.Driver))
                        if (peds[i] != timecurcuitssystem.bttfList[car.NumberPlate.Trim()].getDelorean().GetPedOnSeat(VehicleSeat.Passenger))
                            if (!Game.MissionFlag)
                                peds[i].Delete();
                    //Function.Call(GTA.Native.Hash.SET_ENTITY_COORDS_NO_OFFSET, peds[i], 0, 0, 0, 0, 0, 1);
                }
                Array.Clear(peds, 0, peds.Length);
                for (int i = 0; i < pedVehicles.Length; i++)
                {
                    if (pedVehicles[i] != timecurcuitssystem.bttfList[car.NumberPlate.Trim()].getDelorean().GetPedOnSeat(VehicleSeat.Driver))
                        if (pedVehicles[i] != timecurcuitssystem.bttfList[car.NumberPlate.Trim()].getDelorean().GetPedOnSeat(VehicleSeat.Passenger))
                            if (!Game.MissionFlag)
                                pedVehicles[i].Delete();
                    //Function.Call(GTA.Native.Hash.SET_ENTITY_COORDS_NO_OFFSET, pedVehicles[i], 0, 0, 0, 0, 0, 1);
                }
                Array.Clear(pedVehicles, 0, pedVehicles.Length);
                //End Ped Despawning

                Function.Call(GTA.Native.Hash.SET_RANDOM_WEATHER_TYPE);
                //Function.Call(Hash.SET_CLOCK_DATE, getmonth(), getday(), getyear());
                Function.Call(Hash.SET_CLOCK_TIME, ((timecurcuitssystem.bttfList[car.NumberPlate.Trim()].fh1 * 10) + timecurcuitssystem.bttfList[car.NumberPlate.Trim()].fh2), 
                    ((timecurcuitssystem.bttfList[car.NumberPlate.Trim()].fm1 * 10) + timecurcuitssystem.bttfList[car.NumberPlate.Trim()].fm2), 0);
                timeentry = true;
            }

            Script.Wait(2000);

            timeentry = false;
            timecurcuitssystem.bttfList[car.NumberPlate.Trim()].getDelorean().CloseDoor(VehicleDoor.Hood, false);       

            Game.FadeScreenIn(300);
            Script.Wait(1000);

            if (timecurcuitssystem.bttfList[car.NumberPlate.Trim()].getDelorean().Model == "bttf3" || timecurcuitssystem.bttfList[car.NumberPlate.Trim()].getDelorean().Model == "bttf3rr")
            {
                Sounds.reenterybttf3.Play();
            }
            else if (timecurcuitssystem.bttfList[car.NumberPlate.Trim()].getDelorean().Model == "bttf")
            {
                Sounds.reenterybttf1.Play();
            }
            else
                Sounds.reenterybttf2.Play();

            if (timecurcuitssystem.bttfList[car.NumberPlate.Trim()].getDelorean().Model == new Model("BTTF"))
            {
                World.DrawSpotLight(timecurcuitssystem.bttfList[car.NumberPlate.Trim()].getDelorean().Position, timecurcuitssystem.bttfList[car.NumberPlate.Trim()].getDelorean().Rotation, Color.SkyBlue, 80, 100, 60, 100, 5);
                timecurcuitssystem.bttfList[car.NumberPlate.Trim()].getDelorean().IsVisible = true;
                Script.Wait(10);
                timecurcuitssystem.bttfList[car.NumberPlate.Trim()].getDelorean().IsVisible = false;
                Script.Wait(50);
                World.DrawSpotLight(timecurcuitssystem.bttfList[car.NumberPlate.Trim()].getDelorean().Position, timecurcuitssystem.bttfList[car.NumberPlate.Trim()].getDelorean().Rotation, Color.SkyBlue, 80, 100, 60, 100, 5);
                timecurcuitssystem.bttfList[car.NumberPlate.Trim()].getDelorean().IsVisible = true;
                Script.Wait(10);
                timecurcuitssystem.bttfList[car.NumberPlate.Trim()].getDelorean().IsVisible = false;
                Script.Wait(50);
                World.DrawSpotLight(timecurcuitssystem.bttfList[car.NumberPlate.Trim()].getDelorean().Position, timecurcuitssystem.bttfList[car.NumberPlate.Trim()].getDelorean().Rotation, Color.SkyBlue, 80, 100, 60, 100, 5);
                timecurcuitssystem.bttfList[car.NumberPlate.Trim()].getDelorean().IsVisible = true;
                Script.Wait(10);
            }
            else
            {
                World.DrawSpotLight(timecurcuitssystem.bttfList[car.NumberPlate.Trim()].getDelorean().Position, timecurcuitssystem.bttfList[car.NumberPlate.Trim()].getDelorean().Rotation, Color.DeepSkyBlue, 80, 100, 60, 100, 5);
                if (timecurcuitssystem.bttfList[car.NumberPlate.Trim()].getDelorean().Model == new Model("BTTF3") || timecurcuitssystem.bttfList[car.NumberPlate.Trim()].getDelorean().Model == new Model("BTTF3rr"))
                    effects.make_effect("scr_martin1", "scr_sol1_sniper_impact", timecurcuitssystem.bttfList[car.NumberPlate.Trim()].getDelorean());
                Script.Wait(700);
                if (timecurcuitssystem.bttfList[car.NumberPlate.Trim()].getDelorean().Model == new Model("BTTF3") || timecurcuitssystem.bttfList[car.NumberPlate.Trim()].getDelorean().Model == new Model("BTTF3rr"))
                    effects.make_effect("scr_martin1", "scr_sol1_sniper_impact", timecurcuitssystem.bttfList[car.NumberPlate.Trim()].getDelorean());
                World.DrawSpotLight(timecurcuitssystem.bttfList[car.NumberPlate.Trim()].getDelorean().Position, timecurcuitssystem.bttfList[car.NumberPlate.Trim()].getDelorean().Rotation, Color.DeepSkyBlue, 80, 100, 60, 100, 5);
                Script.Wait(700);
                if (timecurcuitssystem.bttfList[car.NumberPlate.Trim()].getDelorean().Model == new Model("BTTF3") || timecurcuitssystem.bttfList[car.NumberPlate.Trim()].getDelorean().Model == new Model("BTTF3rr"))
                    effects.make_effect("scr_martin1", "scr_sol1_sniper_impact", timecurcuitssystem.bttfList[car.NumberPlate.Trim()].getDelorean());
                World.DrawSpotLight(timecurcuitssystem.bttfList[car.NumberPlate.Trim()].getDelorean().Position, timecurcuitssystem.bttfList[car.NumberPlate.Trim()].getDelorean().Rotation, Color.DeepSkyBlue, 80, 100, 60, 100, 5);
            }
            Script.Wait(10);
            timecurcuitssystem.bttfList[car.NumberPlate.Trim()].getDelorean().FreezePosition = false;
            Script.Wait(10);
            timecurcuitssystem.bttfList[car.NumberPlate.Trim()].getDelorean().HasCollision = true;
            Script.Wait(10);
            timecurcuitssystem.bttfList[car.NumberPlate.Trim()].getDelorean().IsVisible = true;
            Script.Wait(10);
            timecurcuitssystem.bttfList[car.NumberPlate.Trim()].getDelorean().ApplyForceRelative(new Vector3(0, 55, 0));
            if (timeenter)
            {
                if (timecurcuitssystem.bttfList[car.NumberPlate.Trim()].getDelorean().IsDoorBroken(VehicleDoor.FrontLeftDoor))
                {
                    timecurcuitssystem.bttfList[car.NumberPlate.Trim()].getDelorean().GetPedOnSeat(VehicleSeat.Driver).Kill();
                    timecurcuitssystem.bttfList[car.NumberPlate.Trim()].getDelorean().GetPedOnSeat(VehicleSeat.Passenger).Kill();
                }
                if (timecurcuitssystem.bttfList[car.NumberPlate.Trim()].getDelorean().IsDoorBroken(VehicleDoor.FrontRightDoor))
                {
                    timecurcuitssystem.bttfList[car.NumberPlate.Trim()].getDelorean().GetPedOnSeat(VehicleSeat.Driver).Kill();
                    timecurcuitssystem.bttfList[car.NumberPlate.Trim()].getDelorean().GetPedOnSeat(VehicleSeat.Passenger).Kill();
                }
            }
            //Mrfusionpower -= 3;
            timecurcuitssystem.bttfList[car.NumberPlate.Trim()].refilltimecurcuits = false;
            timecurcuitssystem.bttfList[car.NumberPlate.Trim()].getDelorean().IsInvincible = false;
            Game.Player.CanControlCharacter = true;
            timecurcuitssystem.bttfList[car.NumberPlate.Trim()].getDelorean().DirtLevel = 12;

            startfreeze();
        }

        public static void startfreeze()
        {
            Sounds.cold.Play();
            freeze = true;
        }

        static bool playonce = false;
        public static bool freeze = false;
        static int smokedelay = 0;

        public static void tickfreeze(Vehicle car)
        {
            if (!Sounds.cold.gettimeend() && freeze)
            {
                if (Sounds.Vent.gettime() > 1500 && Sounds.Vent.gettime() < 4300)
                {
                    if (car.Model == "bttf")
                    {
                        if (smokedelay == 0)
                        {
                            effects.make_effect("scr_familyscenem", "scr_meth_pipe_smoke", new Vector3(0.5f, -2f, 0.7f), new Vector3(10, 0, 180), 10.9f, false, false, false, car);
                            effects.make_effect("scr_familyscenem", "scr_meth_pipe_smoke", new Vector3(-0.5f, -2f, 0.7f), new Vector3(10, 0, 180), 10.9f, false, false, false, car);
                        }
                        smokedelay++;
                        if ( smokedelay < 500)
                        {
                            smokedelay = 0;
                        }
                    }
                }

                if (Sounds.cold.gettime() <= 7400)
                {
                    playonce = false;
                }
                else if (Sounds.cold.gettime() <= 8500)
                {
                    if (car.Model == "bttf" || car.Model == "bttf3")
                        Sounds.Vent.Play();
                }
                else if (Sounds.cold.gettime() < 9000)
                {
                    if (!playonce)
                    {
                        Sounds.inputoff.Play();
                        playonce = true;
                    }
                }
            }
            else
            {
                if (playonce && !timecurcuitssystem.bttfList[car.NumberPlate.Trim()].refilltimecurcuits)
                {
                    Sounds.cold.Play();
                    playonce = false;
                }
                freeze = false;
            }
        }
        #endregion
    }
}

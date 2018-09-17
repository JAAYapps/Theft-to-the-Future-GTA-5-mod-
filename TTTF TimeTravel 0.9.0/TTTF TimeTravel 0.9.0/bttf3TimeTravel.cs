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
    class bttf3TimeTravel : TimeTravel
    {
        public double movie { get { return movie; } set {
                if (value == 3 || value == 3.5)
                {
                    movie = value;
                }
            }
        }

        public bttf3TimeTravel(double movie)
        {
            this.movie = movie;
        }

        #region Delorean functions

        void startMalfunction(Vehicle car)
        {
            if (Sounds.cirerrorbttf3.getPlayStateStopped())
                Sounds.cirerrorbttf3.Play();
        }

        void malfunction(Delorean Delorean, bool refilltimecircuits, bool toggle)
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

        void body(int BodyHealth, Delorean delorean)
        {
            if (BodyHealth == 0)
            {
                malfunction(delorean, delorean.refilltimecurcuits, delorean.toggletimecurcuits);
            }
            else if (BodyHealth < 700 && BodyHealth > 0)
            {
                int n = 0;
                if (DateTime.Now.Millisecond % 180 >= 90 && DateTime.Now.Millisecond % 180 <= 180)
                {
                    if (!tickbool)
                    {
                        n = rand.Next(1, BodyHealth);
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

        void displaymodelOnOff(Delorean delorean, bool on)
        {
            if (delorean.refilltimecurcuits)
            {
                Function.Call(Hash.SET_VEHICLE_MOD_KIT, delorean.getDelorean().Handle, 0);
                delorean.getDelorean().SetMod(VehicleMod.SideSkirt, 0, true);
                body((int)delorean.getDelorean().BodyHealth, delorean);
            }
            else
            {
                Function.Call(Hash.SET_VEHICLE_MOD_KIT, delorean.getDelorean().Handle, 0);
                delorean.getDelorean().SetMod(VehicleMod.SideSkirt, -1, true);
            }
        }

        void removePedsandVehicles(Vehicle Delorean)
        {
            //Start Ped Despawning
            Ped[] peds = World.GetNearbyPeds(Game.Player.Character, 100);
            Vehicle[] pedVehicles = World.GetNearbyVehicles(Game.Player.Character, 100);
            for (int i = 0; i < peds.Length; i++)
            {
                try
                {
                    if (!peds[i].IsInVehicle(timecurcuitssystem.bttfList[Delorean.NumberPlate.Trim()].getDelorean()))
                    {
                        if (peds[i].IsInVehicle())
                        {
                            if (!peds[i].IsInVehicle(timecurcuitssystem.bttfList[peds[i].CurrentVehicle.NumberPlate.Trim()].getDelorean()))
                            {
                                if (!Game.MissionFlag)
                                    peds[i].Delete();
                            }

                        }
                        else if (!peds[i].IsInVehicle())
                        {
                            if (!Game.MissionFlag)
                                peds[i].Delete();
                        }
                    }
                }
                catch
                {
                    if (!Game.MissionFlag)
                        peds[i].Delete();
                }
            }
            Array.Clear(peds, 0, peds.Length);
            for (int i = 0; i < pedVehicles.Length; i++)
            {
                try
                {
                    if (pedVehicles[i] != timecurcuitssystem.bttfList[Delorean.NumberPlate.Trim()].getDelorean())
                        if (pedVehicles[i] != timecurcuitssystem.bttfList[pedVehicles[i].NumberPlate.Trim()].getDelorean())
                            if (!Game.MissionFlag)
                                pedVehicles[i].Delete();
                }
                catch
                {
                    if (!Game.MissionFlag)
                        pedVehicles[i].Delete();
                }
            }
            Array.Clear(pedVehicles, 0, pedVehicles.Length);
            //End Ped Despawning
            Function.Call(GTA.Native.Hash.SET_RANDOM_WEATHER_TYPE);
        }

        void insteantTravel(Delorean delorean, effects worm)
        {
            Vehicle DMC = delorean.getDelorean();
            DMC.DirtLevel = 12;
            Function.Call(Hash.SET_CLOCK_TIME, ((delorean.fh1 * 10) + delorean.fh2), ((delorean.fm1 * 10) + delorean.fm2), 0);
            if (delorean.refilltimecurcuits)
            {
                Sounds.sparksbttf3.Stop();
                Sounds.sparksfeul.Stop();
            }
            Script.Wait(10);
            delorean.timetravelentry();
            Script.Wait(10);
            Sounds.Timetravelreentery3.Play();
            if (Game.Player.Character.IsInVehicle(DMC))
            {
                CharacterTravel(delorean);
                if (!delorean.RCmode)
                {
                    removePedsandVehicles(DMC);
                    Script.Wait(10);
                    Game.Player.WantedLevel = 0;
                }
                else
                {
                    TTTFmenu.RCmode = false;
                    TTTFmenu.rcmodel = "";
                    mainsystem.TTTF.setmenu(true);
                    delorean.ToggleRCmode();
                }
                Script.Wait(10);
                delorean.refilltimecurcuits = false;
                Script.Wait(10);
                Function.Call(Hash.SET_VEHICLE_MOD_KIT, DMC.Handle, 0);
                DMC.SetMod(VehicleMod.Spoilers, 1, true);
                DMC.SetMod(VehicleMod.FrontBumper, -1, true);
            }
            else
            {
                delorean.refilltimecurcuits = false;
                Script.Wait(10);
                Function.Call(Hash.SET_VEHICLE_MOD_KIT, DMC.Handle, 0);
                DMC.SetMod(VehicleMod.Spoilers, 1, true);
                DMC.SetMod(VehicleMod.FrontBumper, -1, true);
            }
        }

        void cutScene(Delorean delorean, effects worm)
        {
            Vehicle DMC = delorean.getDelorean();
            DMC.IsInvincible = true;
            if (delorean.refilltimecurcuits)
            {
                Sounds.sparksfeul.Stop();
                Sounds.sparksbttf3.Stop();
            }
            effects.make_effect("scr_rcpaparazzo1", "scr_rcpap1_camera", DMC);
            Sounds.Timetravelreenterycutscene3.Play();
            if (!stoponce)
            {
                DMC.FreezePosition = true;
                DMC.HasCollision = false;
                stoponce = true;
            }
            DMC.IsVisible = false;
            DMC.EngineRunning = false;

            // TODO - replace flame trail effects for bttf3 and bttf3rr

            if (Function.Call<bool>(Hash.IS_VEHICLE_EXTRA_TURNED_ON, new InputArgument[] { DMC, 10 }))
            {
                Function.Call(Hash.SET_VEHICLE_EXTRA, new InputArgument[] { DMC, 10, -1 });
            }
            Function.Call(Hash.SET_VEHICLE_MOD_KIT, DMC.Handle, 0);
            DMC.SetMod(VehicleMod.Spoilers, 1, true);
            DMC.SetMod(VehicleMod.FrontBumper, -1, true);
            if (Game.Player.Character.IsInVehicle(DMC))
            {
                if (Game.Player.WantedLevel > 0)
                {
                    Game.Player.WantedLevel = 0;
                }
                delorean.timetravelentry();
                CharacterTravel(delorean);
                reentry(DMC);
            }
            else
            {
                delorean.timetravelentry();
                delorean.refilltimecurcuits = false;
                Script.Wait(10);
            }
        }

        void to88(int speed, Delorean delorean, effects worm)
        {
            if (delorean.refilltimecurcuits)
            {
                double time = 0;
                time = Sounds.sparksfeul.gettime();
                if (time < 3000)
                    worm.wormholeAndTravel(delorean.getDelorean(), speed, delorean.refilltimecurcuits);
                else
                {
                    delorean.timeTraveled = true;
                    if (Function.Call<int>(Hash.GET_FOLLOW_VEHICLE_CAM_VIEW_MODE) == 4)
                    {
                        insteantTravel(delorean, worm);
                    }
                    else
                    {
                        cutScene(delorean, worm);
                    }
                }
            }
        }

        void below88(Delorean delorean, effects worm)
        {
            Function.Call(Hash.SET_VEHICLE_MOD_KIT, delorean.getDelorean().Handle, 0);
            delorean.getDelorean().SetMod(VehicleMod.Spoilers, 1, true);
            stoponce = false;
            if (worm.below84)
            {
                Sounds.sparksbttf3.Stop();
                Sounds.sparksfeul.Stop();
                worm.resetwormhole();
            }
        }

        void resetTravel(int speed, Delorean delorean, effects worm)
        {
            Function.Call(Hash.SET_VEHICLE_MOD_KIT, delorean.getDelorean().Handle, 0);
            delorean.getDelorean().SetMod(VehicleMod.FrontBumper, -1, true);
            delorean.getDelorean().SetMod(VehicleMod.SideSkirt, -1, true);
            delorean.getDelorean().SetMod(VehicleMod.Spoilers, -1, true);
            delorean.getDelorean().SetMod(VehicleMod.Frame, -1, true);
            delorean.getDelorean().SetMod(VehicleMod.Grille, -1, true);
            if (speed < 84 && delorean.timeTraveled && !worm.below84)
            {
                Sounds.sparksbttf3.Stop();
                Sounds.sparksfeul.Stop();
                worm.resetwormhole();
                delorean.timeTraveled = false;
            }
        }

        public override void runningCircuits(Delorean delorean, effects worm)
        {
            if (delorean != null)
            {
                Vehicle Deloreancar = delorean.getDelorean();
                int tempspeed = (int)((Deloreancar.Speed / .27777) / 1.60934);
                #region functions
                if (Deloreancar.DirtLevel > 0)
                    Deloreancar.DirtLevel -= 0.001f;

                if (Deloreancar.Model == new Model("BTTF3rr"))
                {
                    if (Game.IsKeyPressed(System.Windows.Forms.Keys.W))
                        if (tempspeed < 45)
                            Deloreancar.ApplyForceRelative(new Vector3(0, 0.5f, 0));
                    if (Game.IsKeyPressed(System.Windows.Forms.Keys.S))
                        if (tempspeed < 45)
                            Deloreancar.ApplyForceRelative(new Vector3(0, -0.5f, 0));
                    Deloreancar.FuelLevel = 0;
                }
                #endregion

                if (delorean.toggletimecurcuits)
                {
                    displaymodelOnOff(delorean, delorean.toggletimecurcuits);
                    worm.wormhole(Deloreancar, tempspeed, delorean.refilltimecurcuits);
                    if (tempspeed > 64)
                    {
                        worm.below84 = true;
                    }
                    if (tempspeed >= 88)
                    {
                        to88(tempspeed, delorean, worm);
                    }
                    else if (tempspeed < 64)
                    {
                        errorbool = false;
                        below88(delorean, worm);
                    }
                }
                else
                {
                    resetTravel(tempspeed, delorean, worm);
                }
            }
        }

        void enterEffect(Vehicle car)
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

        public override void reentry(Vehicle car)
        {
            Libeads.timejump = true;
            Script.Wait(2000);
            Game.FadeScreenOut(600);
            timeenter = true;
            timecurcuitssystem.bttfList[car.NumberPlate.Trim()].timetravelentry();
            car.OpenDoor(VehicleDoor.Hood, false, false);
            
            Script.Wait(1000);
            if (!timeentry)
            {
                //Function.Call(Hash.SET_CLOCK_DATE, getmonth(), getday(), getyear());
                Function.Call(Hash.SET_CLOCK_TIME, ((timecurcuitssystem.bttfList[car.NumberPlate.Trim()].fh1 * 10) + timecurcuitssystem.bttfList[car.NumberPlate.Trim()].fh2),
                    ((timecurcuitssystem.bttfList[car.NumberPlate.Trim()].fm1 * 10) + timecurcuitssystem.bttfList[car.NumberPlate.Trim()].fm2), 0);
                timeentry = true;
            }

            Script.Wait(2000);

            removePedsandVehicles(car);

            Script.Wait(2000);

            timeentry = false;
            car.CloseDoor(VehicleDoor.Hood, false);

            Game.FadeScreenIn(300);
            Script.Wait(1000);

            Sounds.reenterybttf3.Play();

            enterEffect(car);
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

        void startfreeze()
        {
            Sounds.cold.Play();
            freeze = true;
        }

        bool playonce = false;
        //int smokedelay = 0;

        public override void tickfreeze(Vehicle car)
        {
            if (!Sounds.cold.gettimeend() && freeze)
            {
                if (Sounds.cold.gettime() <= 7400)
                {
                    playonce = false;
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

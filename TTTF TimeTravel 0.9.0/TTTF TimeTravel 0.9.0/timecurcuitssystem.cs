using GTA;
using GTA.Math;
using GTA.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TTTF_TimeTravel_0._9._0
{
    class timecurcuitssystem
    {
        public static Dictionary<string, Delorean> bttfList = new Dictionary<string, Delorean>();
        public static Dictionary<string, effects> wormhole = new Dictionary<string, effects>();
        public static Dictionary<string, TimeTravel> circuits = new Dictionary<string, TimeTravel>();
        public static Dictionary<string, PropManager> effectProps = new Dictionary<string, PropManager>();

        static void AddParts(string carName, Vehicle dmc12)
        {
            Function.Call(Hash.SET_VEHICLE_MOD_KIT, dmc12.Handle, 0);
            dmc12.ToggleMod(VehicleToggleMod.Turbo, true);
            ITuningParts part = new TuningParts(dmc12);
            part.AttachTurningParts();
            //part.Display(dmc12, false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", 0, 0, false);
            PropManager propManager = new PropManager();
            propManager.loadWormhole(dmc12);
            propManager.SpawnProp(dmc12, "bttf_licenseplate", "licenseplate", Vector3.Zero, dmc12.GetOffsetInWorldCoords(new Vector3(3,0,0)));
            propManager.SpawnProp(dmc12, "bttf_icebody", "chassis", Vector3.Zero, Vector3.Zero);
            propManager.initDisplay(dmc12);
            propManager.ice.Alpha = 0;
            effectProps.Add(carName.Trim(), propManager);
        }

        static void RemoveParts(string carName)
        {
            effectProps[carName].removeWormhole();
            effectProps.Remove(carName);
        }

        public static void addToList(string name, double movie, Vehicle car)
        {
            car.NumberPlate = name;
            bttfList.Add(name, new Delorean(car));
            wormhole.Add(name, new effects());
            if (movie == 1)
                circuits.Add(name, new bttf1TimeTravel());
            else if (movie == 2)
                circuits.Add(name, new bttf2TimeTravel());
            else if (movie == 0)
                circuits.Add(name, new bttf2TimeTravel());
            else if (movie == 3)
                circuits.Add(name, new bttf3TimeTravel(3));
            else if (movie == 3.5)
                circuits.Add(name, new bttf3TimeTravel(3.5));
            else
                circuits.Add(name, new bttf1TimeTravel());
            AddParts(name, car);
        }

        public static void RemoveTimeCircuits()
        {
            Delorean temp = null;
            if (bttfList.TryGetValue(Game.Player.Character.CurrentVehicle.NumberPlate.Trim(), out temp))
            {
                bttfList.Remove(Game.Player.Character.CurrentVehicle.NumberPlate.Trim());
                wormhole.Remove(Game.Player.Character.CurrentVehicle.NumberPlate.Trim());
                circuits.Remove(Game.Player.Character.CurrentVehicle.NumberPlate.Trim());
                RemoveParts(Game.Player.Character.CurrentVehicle.NumberPlate.Trim());
            }
        }

        public static void RemoveTimeCircuits(string name)
        {
            Delorean temp = null;
            if (bttfList.TryGetValue(name, out temp))
            {
                bttfList.Remove(name);
                wormhole.Remove(name);
                circuits.Remove(name);
                RemoveParts(name);
            }
        }

        public static void RemoveDelorean()
        {
            if (bttfList.Count - 1 > 0)
            {
                Delorean temp = null;
                if (bttfList.TryGetValue(Game.Player.Character.CurrentVehicle.NumberPlate.Trim(), out temp))
                {
                    bttfList.Remove(Game.Player.Character.CurrentVehicle.NumberPlate.Trim());
                    wormhole.Remove(Game.Player.Character.CurrentVehicle.NumberPlate.Trim());
                    circuits.Remove(Game.Player.Character.CurrentVehicle.NumberPlate.Trim());
                    RemoveParts(Game.Player.Character.CurrentVehicle.NumberPlate.Trim());
                }
            }
            Game.Player.Character.CurrentVehicle.Delete();
        }

        public static void RemoveDelorean(string name)
        {
            Delorean temp = null;
            if (bttfList.TryGetValue(name, out temp))
            {
                bttfList.Remove(name);
                wormhole.Remove(name);
                circuits.Remove(name);
                RemoveParts(name);
            }
            temp.getDelorean().Delete();
        }

        public static void addToList(string name, double movie, Vehicle car, bool refilledOn)
        {
            car.NumberPlate = name;
            bttfList.Add(name, new Delorean(car, refilledOn));
            bttfList[name].setDelorean(car);
            wormhole.Add(name, new effects());
            if (movie == 1)
                circuits.Add(name, new bttf1TimeTravel());
            else if (movie == 2)
                circuits.Add(name, new bttf2TimeTravel());
            else if (movie == 0)
                circuits.Add(name, new bttf2TimeTravel());
            else if (movie == 3)
                circuits.Add(name, new bttf3TimeTravel(3));
            else if (movie == 3.5)
                circuits.Add(name, new bttf3TimeTravel(3.5));
            else
                circuits.Add(name, new bttf1TimeTravel());
            AddParts(name ,car);
        }

        public static void addToList(string name, double movie, Vehicle car, bool refilledOn, int day1 = 2, int day2 = 9, int month1 = 0, int month2 = 5
            , int y1 = 2, int y2 = 0, int y3 = 1, int y4 = 5, int h1 = 1
            , int h2 = 0, int m1 = 0, int m2 = 9)
        {
            car.NumberPlate = name;
            bttfList.Add(name, new Delorean(car, refilledOn, day1, day2, month1, month2, y1, y2, y3, y4, h1, h2, m1, m2));
            bttfList[name].setDelorean(car);
            wormhole.Add(name, new effects());
            if (movie == 1)
                circuits.Add(name, new bttf1TimeTravel());
            else if (movie == 2)
                circuits.Add(name, new bttf2TimeTravel());
            else if (movie == 0)
                circuits.Add(name, new bttf2TimeTravel());
            else if (movie == 3)
                circuits.Add(name, new bttf3TimeTravel(3));
            else if (movie == 3.5)
                circuits.Add(name, new bttf3TimeTravel(3.5));
            else
                circuits.Add(name, new bttf1TimeTravel());
            AddParts(name ,car);
        }

        public static void Toggleflight()
        {
            string bttfcar = Game.Player.Character.CurrentVehicle.NumberPlate.Trim();
            if (bttfList.TryGetValue(Game.Player.Character.CurrentVehicle.NumberPlate.Trim(), out Delorean delorea))
            {

            }
            //{
            //    if (bttfList[bttfcar].getDelorean().Model == "bttf2" || bttfList[bttfcar].getDelorean().Model == "bttf2f")
            //    {
            //        bool visible = Game.Player.Character.IsVisible;
            //        if (bttfList[bttfcar].flyingison)
            //        {
            //            Vehicle tempv = bttfList[bttfcar].getDelorean();
            //            tempv.HasCollision = false;
            //            Model bttf2 = new Model("BTTF2");
            //            Vehicle tempspawn = World.CreateVehicle(bttf2, tempv.Position);
            //            tempspawn.NumberPlate = tempv.NumberPlate;
            //            tempspawn.IsVisible = false;
            //            Sounds.hoveroff.Play();
            //            tempv.CloseDoor(VehicleDoor.BackRightDoor, false);
            //            tempv.CloseDoor(VehicleDoor.BackLeftDoor, false);
            //            for (int i = 0; i < 50; i++)
            //            {
            //                tempspawn.Position = tempv.Position;
            //                tempspawn.Rotation = tempv.Rotation;
            //                DeloreanManagement.currentGameTime();
            //                DisplayScreenTimePanel(DeloreanManagement.presmonth1, DeloreanManagement.presmonth2,
            //                    DeloreanManagement.presday1, DeloreanManagement.presday2,
            //                    DeloreanManagement.presy1, DeloreanManagement.presy2, DeloreanManagement.presy3, DeloreanManagement.presy4,
            //                    DeloreanManagement.presh1, DeloreanManagement.presh2,
            //                    DeloreanManagement.presampm, DeloreanManagement.presm1, DeloreanManagement.presm2);
            //                Script.Wait(10);
            //            }
            //            bttfList[bttfcar].setDelorean(tempspawn);
            //            Ped driver;
            //            Ped passenger = null;
            //            driver = Game.Player.Character;
            //            if (tempv.GetPedOnSeat(VehicleSeat.Passenger).Exists())
            //                passenger = tempv.GetPedOnSeat(VehicleSeat.Passenger);
            //            driver.Task.WarpOutOfVehicle(tempv);
            //            if (passenger != null)
            //                passenger.Task.WarpOutOfVehicle(tempv);
            //            driver.Task.WarpIntoVehicle(tempspawn, VehicleSeat.Driver);
            //            if (passenger != null)
            //                passenger.Task.WarpIntoVehicle(tempspawn, VehicleSeat.Passenger);
            //            int speed = (int)tempv.Speed;
            //            Script.Wait(100);
            //            tempv.Delete();
            //            tempspawn.IsVisible = true;
            //            try
            //            {
            //                Function.Call(Hash.SET_VEHICLE_MOD_KIT, tempspawn.Handle, 0);
            //                tempspawn.ToggleMod(VehicleToggleMod.Turbo, true);
            //                tempspawn.SetMod(VehicleMod.Frame, -1, true);
            //                tempspawn.SetMod(VehicleMod.Horns, 16, true);
            //                tempspawn.SetMod(VehicleMod.RearBumper, 0, true);
            //                tempspawn.SetMod(VehicleMod.RightFender, 0, true);
            //                tempspawn.SetMod(VehicleMod.Fender, 0, true);
            //                tempspawn.SetMod(VehicleMod.ArchCover, 0, true);
            //                tempspawn.SetMod(VehicleMod.Exhaust, 0, true);
            //                tempspawn.SetMod(VehicleMod.Hood, 0, true);
            //                tempspawn.SetMod(VehicleMod.Ornaments, 0, true);
            //                if (!Function.Call<bool>(Hash.IS_VEHICLE_EXTRA_TURNED_ON, new InputArgument[] { tempspawn, 10 }))
            //                {
            //                    Function.Call(Hash.SET_VEHICLE_EXTRA, new InputArgument[] { tempspawn, 10, 0 });
            //                }
            //                if (Function.Call<bool>(Hash.IS_VEHICLE_EXTRA_TURNED_ON, new InputArgument[] { tempspawn, 1 }))
            //                {
            //                    Function.Call(Hash.SET_VEHICLE_EXTRA, new InputArgument[] { tempspawn, 1, -1 });
            //                }
            //            }
            //            catch
            //            {

            //            }
            //            //    Deloreanlist[index].flycount = 0;
            //            tempspawn.Speed = speed;
            //            Function.Call(Hash.SET_VEHICLE_MOD_KIT, tempspawn.Handle, 0);
            //            tempspawn.SetMod(VehicleMod.RearBumper, 1, true);
            //            tempspawn.ToggleMod(VehicleToggleMod.Turbo, true);
            //            tempspawn.EngineRunning = true;
            //            bttfList[bttfcar].flyingison = false;
            //        }
            //        else
            //        {
            //            Vehicle tempv = bttfList[bttfcar].getDelorean();
            //            Ped driver;
            //            Ped passenger = null;
            //            driver = Game.Player.Character;
            //            if (bttfList[bttfcar].getDelorean().GetPedOnSeat(VehicleSeat.Passenger).Exists())
            //                passenger = bttfList[bttfcar].getDelorean().GetPedOnSeat(VehicleSeat.Passenger);
            //            Model bttf2f = new Model("BTTF2F");
            //            Sounds.hoverboost.Play();
            //            for (int i = 0; i < 60; i++)
            //            {
            //                tempv.ApplyForce(new Vector3(0, 0, 0.6f));
            //                //tempv.Heading = tempv.Heading;
            //                Script.Wait(10);
            //            }
            //            Vehicle tempspawn = null;
            //            while (tempspawn == null)
            //            {
            //                try
            //                {
            //                    tempv.ApplyForce(new Vector3(0, 0, 0.6f));
            //                    tempspawn = World.CreateVehicle(bttf2f, new Vector3(500, 500, 500));
            //                    tempspawn.NumberPlate = tempv.NumberPlate;

            //                    Function.Call(Hash.SET_VEHICLE_MOD_KIT, tempspawn.Handle, 0);
            //                    tempspawn.ToggleMod(VehicleToggleMod.Turbo, true);
            //                    tempspawn.SetMod(VehicleMod.Frame, -1, true);
            //                    tempspawn.SetMod(VehicleMod.Horns, 16, true);
            //                    tempspawn.SetMod(VehicleMod.RearBumper, 0, true);
            //                    tempspawn.SetMod(VehicleMod.RightFender, 0, true);
            //                    tempspawn.SetMod(VehicleMod.Fender, 0, true);
            //                    tempspawn.SetMod(VehicleMod.ArchCover, 0, true);
            //                    tempspawn.SetMod(VehicleMod.Exhaust, 0, true);
            //                    tempspawn.SetMod(VehicleMod.Hood, 0, true);
            //                    tempspawn.SetMod(VehicleMod.Ornaments, 0, true);
            //                    if (!Function.Call<bool>(Hash.IS_VEHICLE_EXTRA_TURNED_ON, new InputArgument[] { tempspawn, 10 }))
            //                    {
            //                        Function.Call(Hash.SET_VEHICLE_EXTRA, new InputArgument[] { tempspawn, 10, 0 });
            //                    }
            //                    if (Function.Call<bool>(Hash.IS_VEHICLE_EXTRA_TURNED_ON, new InputArgument[] { tempspawn, 1 }))
            //                    {
            //                        Function.Call(Hash.SET_VEHICLE_EXTRA, new InputArgument[] { tempspawn, 1, -1 });
            //                    }
            //                    tempspawn.SetMod(VehicleMod.AirFilter, 0, true);
            //                    tempspawn.SetMod(VehicleMod.Aerials, 0, true);
            //                    tempspawn.SetMod(VehicleMod.EngineBlock, 0, true);
            //                }
            //                catch
            //                {

            //                }
            //                Script.Wait(50);
            //            }
            //            int speed = (int)bttfList[bttfcar].getDelorean().Speed;
            //            tempv.HasCollision = false;
            //            Vector3 temppos = bttfList[bttfcar].getDelorean().Position;
            //            Vector3 temprot = bttfList[bttfcar].getDelorean().Rotation;
            //            tempspawn.Position = tempv.Position;
            //            tempspawn.Rotation = tempv.Rotation;
            //            bttfList[bttfcar].setDelorean(tempspawn);
            //            driver.Task.WarpOutOfVehicle(tempv);
            //            if (passenger != null)
            //                passenger.Task.WarpOutOfVehicle(tempv);
            //            driver.HasCollision = false;
            //            if (passenger != null)
            //                passenger.HasCollision = false;
            //            while (!driver.IsInVehicle(tempspawn))
            //            {
            //                tempv.ApplyForce(new Vector3(0, 0, 0.35f));
            //                tempspawn.Position = tempv.Position;
            //                tempspawn.Rotation = tempv.Rotation;
            //                driver.Position = tempv.Position;
            //                driver.Task.WarpIntoVehicle(bttfList[bttfcar].getDelorean(), VehicleSeat.Driver);
            //                Script.Wait(1);
            //            }

            //            if (passenger != null)
            //                while (!passenger.IsInVehicle(tempspawn))
            //                {
            //                    tempv.ApplyForce(new Vector3(0, 0, 0.35f));
            //                    tempspawn.Position = tempv.Position;
            //                    tempspawn.Rotation = tempv.Rotation;
            //                    passenger.Position = tempv.Position;
            //                    passenger.Task.WarpIntoVehicle(bttfList[bttfcar].getDelorean(), VehicleSeat.Passenger);
            //                    Script.Wait(1);
            //                }
            //            tempv.Delete();
            //            bttfList[bttfcar].flyingison = true;
            //            bttfList[bttfcar].getDelorean().Speed = speed;
            //            Sounds.hoveron.Play();
            //            bttfList[bttfcar].getDelorean().OpenDoor(VehicleDoor.BackRightDoor, false, false);
            //            bttfList[bttfcar].getDelorean().OpenDoor(VehicleDoor.BackLeftDoor, false, false);
            //            bttfList[bttfcar].getDelorean().EngineRunning = true;
            //            tempv.Delete();
            //            Function.Call(Hash.SET_VEHICLE_MOD_KIT, bttfList[bttfcar].getDelorean().Handle, 0);
            //            bttfList[bttfcar].getDelorean().SetMod(VehicleMod.RearBumper, 1, true);
            //            bttfList[bttfcar].getDelorean().ToggleMod(VehicleToggleMod.Turbo, true);
            //            driver.HasCollision = true;
            //            passenger.HasCollision = true;
            //        }
            //        Game.Player.Character.IsVisible = visible;
            //    }
            //}
        }

        public static void ToggleMrfusion(Ped ped)
        {
            if (!ped.IsInVehicle())
            {
                Vehicle[] cars = World.GetAllVehicles();
                foreach (Vehicle car in cars)
                {
                    if (ped.IsInRangeOf(car.GetOffsetInWorldCoords(new Vector3(0, -2, 0)), 1.4f))
                    {
                        Delorean delorea = null;
                        if (bttfList.TryGetValue(car.NumberPlate.Trim(), out delorea))
                        {
                            if (!bttfList[car.NumberPlate.Trim()].refilltimecurcuits)
                            {
                                if (bttfList[car.NumberPlate.Trim()].getDelorean().Model == "bttf")
                                {
                                    if (Libeads.plutonium == 0)
                                    {
                                        Sounds.Plut.Play();
                                        Libeads.plutblip = World.CreateProp(new Model("prop_cash_case_01"), new Vector3(2425.67f, 3094.06f, 47f), new Vector3(0, 11, 0), false, false);
                                        Libeads.plutblip.AddBlip();
                                        Libeads.plutblip.CurrentBlip.Color = BlipColor.Yellow;
                                        Libeads.plutblip.CurrentBlip.IsFlashing = true;
                                        Libeads.plutblip.CurrentBlip.ShowRoute = true;
                                        Libeads.timejump = false;
                                    }
                                    else
                                    {
                                        Function.Call(Hash.REQUEST_ANIM_DICT, "ah_1_mcs_1-0");
                                        while (!Function.Call<bool>(Hash.HAS_ANIM_DICT_LOADED, "ah_1_mcs_1-0"))
                                        {
                                            Script.Wait(10);
                                        }
                                        ped.Position = bttfList[car.NumberPlate.Trim()].getDelorean().GetOffsetInWorldCoords(new Vector3(0, -2.3f, -1));
                                        ped.Rotation = bttfList[car.NumberPlate.Trim()].getDelorean().Rotation;

                                        Function.Call(Hash.REQUEST_ANIM_DICT, "ah_1_mcs_1-0");
                                        Vector3 animxyz = ped.Position;
                                        Vector3 animrot = ped.Rotation;
                                        Function.Call(Hash.TASK_PLAY_ANIM_ADVANCED, Game.Player.Character, "ah_1_mcs_1-0", "csb_janitor_dual-0", animxyz.X, animxyz.Y, animxyz.Z, animrot.X, animrot.Y, animrot.Z, 0.8f, 0.5, 6000, (int)AnimationFlags.UpperBodyOnly, 0.35f, false, false);
                                        Script.Wait(1500);
                                        Sounds.pr0load.Play();
                                        bttfList[car.NumberPlate.Trim()].getDelorean().OpenDoor(VehicleDoor.Trunk, false, false);
                                        bttfList[car.NumberPlate.Trim()].refilltimecurcuits = true;
                                        Script.Wait(3000);
                                        bttfList[car.NumberPlate.Trim()].getDelorean().CloseDoor(VehicleDoor.Trunk, false);
                                        Script.Wait(500);
                                        Function.Call(Hash.STOP_ANIM_TASK, ped, "ah_1_mcs_1-0", "csb_janitor_dual-0", 1);
                                        Libeads.plutonium--;
                                    }
                                }
                                else
                                {
                                    Function.Call(Hash.REQUEST_ANIM_DICT, "ah_1_mcs_1-0");
                                    while (!Function.Call<bool>(Hash.HAS_ANIM_DICT_LOADED, "ah_1_mcs_1-0"))
                                    {
                                        Script.Wait(10);
                                    }
                                    ped.Position = bttfList[car.NumberPlate.Trim()].getDelorean().GetOffsetInWorldCoords(new Vector3(0, -2.3f, -1));
                                    ped.Rotation = bttfList[car.NumberPlate.Trim()].getDelorean().Rotation;
                                    
                                    Function.Call(Hash.REQUEST_ANIM_DICT, "ah_1_mcs_1-0");
                                    Vector3 animxyz = ped.Position;
                                    Vector3 animrot = ped.Rotation;
                                    Function.Call(Hash.TASK_PLAY_ANIM_ADVANCED, ped, "ah_1_mcs_1-0", "csb_janitor_dual-0", animxyz.X, animxyz.Y, animxyz.Z, animrot.X, animrot.Y, animrot.Z, 0.8f, 0.5, 6000, (int)AnimationFlags.UpperBodyOnly, 0.35f, false, false);
                                    Script.Wait(1500);
                                    Sounds.Mrfrusionfill.Play();
                                    bttfList[car.NumberPlate.Trim()].getDelorean().OpenDoor(VehicleDoor.Trunk, false, false);
                                    bttfList[car.NumberPlate.Trim()].refilltimecurcuits = true;
                                    effects.make_effect("scr_rcpaparazzo1", "scr_rcpap1_smoke_vent", new Vector3(0f, 1.3f, 0.9f), new Vector3(15, 0, 180), 4f, false, false, false, car);
                                    Script.Wait(4000);
                                    effects.make_effect("scr_rcpaparazzo1", "scr_rcpap1_smoke_vent", new Vector3(0f, 1.3f, 0.9f), new Vector3(15, 0, 180), 4f, false, false, false, car);

                                    bttfList[car.NumberPlate.Trim()].getDelorean().CloseDoor(VehicleDoor.Trunk, false);
                                }
                                break;
                            }
                        }
                    }
                }
            }
            else if (ped.IsInVehicle())
            {
                Delorean delorea = null;
                if (bttfList.TryGetValue(ped.CurrentVehicle.NumberPlate.Trim(), out delorea))
                {
                    if (!bttfList[ped.CurrentVehicle.NumberPlate.Trim()].refilltimecurcuits)
                    {
                        Sounds.Mrfrusionfill.Play();
                        bttfList[ped.CurrentVehicle.NumberPlate.Trim()].getDelorean().OpenDoor(VehicleDoor.Trunk, false, false);
                        bttfList[ped.CurrentVehicle.NumberPlate.Trim()].refilltimecurcuits = true;
                        Script.Wait(4000);
                        bttfList[ped.CurrentVehicle.NumberPlate.Trim()].getDelorean().CloseDoor(VehicleDoor.Trunk, false);
                    }
                }
            }
        }

        public static void switchCircuits()
        {
            if (Game.Player.Character.IsInVehicle())
            {
                Delorean delorea = null;
                if (bttfList.TryGetValue(Game.Player.Character.CurrentVehicle.NumberPlate.Trim(), out delorea))
                {
                    Sounds.inputonempty.Play();
                    bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].toggletimecurcuits = !bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].toggletimecurcuits;
                    if (bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].refilltimecurcuits)
                    {
                        if (!bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].toggletimecurcuits)
                        {
                            Sounds.inputoff.Play();
                        }
                        else if (bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].toggletimecurcuits)
                        {
                            Sounds.inputon.Play();
                        }
                    }
                }
            }
        }
        static bool emptyNotify = false;
        static bool enginestate = false;
        public static void DisplayScreenTimePanel(int presmonth1, int presmonth2, int presday1, 
            int presday2, int presy1, int presy2, int presy3, int presy4, 
            int presh1, int presh2, string presampm, int presm1, int presm2)
        {
            Delorean delorea = null;
            if (bttfList.TryGetValue(Game.Player.Character.CurrentVehicle.NumberPlate.Trim(), out delorea))
            {
                #region Engine
                if (bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].getDelorean().EngineRunning != enginestate)
                {
                    if (bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].getDelorean().EngineRunning)
                    {
                        if (!bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].getDelorean().IsDead)
                        {
                            if (!enginestate)
                            {
                                try
                                {
                                    if (Sounds.engineon.getPlayStateStopped())
                                        if (!Sounds.engineon.gettimeend())
                                        {
                                            Sounds.engineoff.Stop();
                                            Sounds.engineon.Play();
                                            enginestate = true;
                                        }
                                }
                                catch (Exception d)
                                {
                                    UI.ShowSubtitle(d.Message);
                                }
                            }
                        }
                    }
                    else if (!bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].getDelorean().EngineRunning)
                    {
                        if (!bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].getDelorean().IsDead)
                        {
                            if (enginestate)
                            {
                                try
                                {
                                    if (Sounds.engineoff.getPlayStateStopped())
                                        if (!Sounds.engineoff.gettimeend())
                                        {
                                            Sounds.engineon.Stop();
                                            Sounds.engineoff.Play();
                                            enginestate = false;
                                        }

                                }
                                catch (Exception d)
                                {
                                    UI.ShowSubtitle(d.Message);
                                }
                            }
                        }
                    }
                }
                #endregion
                displaysystem.display_background(bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].getDelorean(), bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].refilltimecurcuits, bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].toggletimecurcuits);
                if (bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].toggletimecurcuits)
                {
                    if (!circuits[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].freeze && !emptyNotify && !bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].refilltimecurcuits)
                    {
                        displaysystem.runempty();
                        emptyNotify = true;
                    }
                    displaysystem.emptytick(bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].getDelorean(), 
                        bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].refilltimecurcuits, 
                        bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].toggletimecurcuits);

                    displaysystem.tick(bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].getDelorean(), 
                        bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].refilltimecurcuits,
                        bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].fmonth1, 
                        bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].fmonth2, 
                        bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].fday1, 
                        bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].fday2, 
                        bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].fy1, 
                        bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].fy2, 
                        bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].fy3, 
                        bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].fy4, 
                        bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].fh1, 
                        bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].fh2, 
                        bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].fampm, 
                        bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].fm1, 
                        bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].fm2,
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
                        bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].pastmonth1,
                        bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].pastmonth2,
                        bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].pastday1,
                        bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].pastday2,
                        bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].pasty1,
                        bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].pasty2,
                        bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].pasty3,
                        bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].pasty4,
                        bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].pasth1,
                        bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].pasth2,
                        bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].pastampm,
                        bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].pastm1,
                        bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].pastm2, 
                        true);
                }
                else
                {
                    emptyNotify = false;
                }
            }
        }

        public static void Settime(int day1 = 2, int day2 = 9, int month1 = 0, int month2 = 5
            , int y1 = 2, int y2 = 0, int y3 = 1, int y4 = 5, int h1 = 1
            , int h2 = 2, int m1 = 0, int m2 = 9, string ampm = "pm")
        {
            Delorean delorea = null;
            if (bttfList.TryGetValue(Game.Player.Character.CurrentVehicle.NumberPlate.Trim(), out delorea))
            {
                bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].fday1 = day1;
                bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].fday2 = day2;
                bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].fmonth1 = month1;
                bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].fmonth2 = month2;
                bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].fy1 = y1;
                bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].fy2 = y2;
                bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].fy3 = y3;
                bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].fy4 = y4;
                bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].fh1 = h1;
                bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].fh2 = h2;
                bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].fm1 = m1;
                bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].fm2 = m2;
                bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].fampm = ampm;
            }
        }

        private static void timeinput(int numpadnumber, int count)
        {
            Delorean delorea = null;
            if (bttfList.TryGetValue(Game.Player.Character.CurrentVehicle.NumberPlate.Trim(), out delorea))
            {
                if (count > 11)
                {
                    Sounds.inputerror.Play();
                }
                else
                {
                    switch (count)
                    {
                        case 0:
                            bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].tmonth1 = numpadnumber;
                            break;
                        case 1:
                            bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].tmonth2 = numpadnumber;
                            break;
                        case 2:
                            bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].tday1 = numpadnumber;
                            break;
                        case 3:
                            bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].tday2 = numpadnumber;
                            break;
                        case 4:
                            bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].ty1 = numpadnumber;
                            break;
                        case 5:
                            bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].ty2 = numpadnumber;
                            break;
                        case 6:
                            bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].ty3 = numpadnumber;
                            break;
                        case 7:
                            bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].ty4 = numpadnumber;
                            break;
                        case 8:
                            bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].th1 = numpadnumber;
                            break;
                        case 9:
                            bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].th2 = numpadnumber;
                            break;
                        case 10:
                            bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].tm1 = numpadnumber;
                            break;
                        case 11:
                            bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].tm2 = numpadnumber;
                            break;
                    }
                    bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].datecount++;
                }
            }
        }

        public static void keyset(Keys key)
        {
            Delorean delorea = null;
            if (bttfList.TryGetValue(Game.Player.Character.CurrentVehicle.NumberPlate.Trim(), out delorea))
            {
                if (bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].toggletimecurcuits && 
                    bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].refilltimecurcuits)
                {
                    switch (key)
                    {
                        case Keys.NumPad0:
                            if (bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].datecount < 12)
                            {
                                Sounds.num0.Play();
                                timeinput(0, bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].datecount);
                            }
                            break;
                        case Keys.D0:
                            if (bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].datecount < 12)
                            {
                                Sounds.num0.Play();
                                timeinput(0, bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].datecount);
                            }

                            break;
                        case Keys.NumPad1:
                            if (bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].datecount < 12)
                            {
                                Sounds.num1.Play();
                                timeinput(1, bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].datecount);
                            }
                            break;
                        case Keys.D1:
                            if (bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].datecount < 12)
                            {
                                Sounds.num1.Play();
                                timeinput(1, bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].datecount);
                            }
                            break;
                        case Keys.NumPad2:
                            if (bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].datecount < 12)
                            {
                                Sounds.num2.Play();
                                timeinput(2, bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].datecount);
                            }
                            break;
                        case Keys.D2:
                            if (bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].datecount < 12)
                            {
                                Sounds.num2.Play();
                                timeinput(2, bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].datecount);
                            }
                            break;
                        case Keys.NumPad3:
                            if (bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].datecount < 12)
                            {
                                Sounds.num3.Play();
                                timeinput(3, bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].datecount);
                            }
                            break;
                        case Keys.D3:
                            if (bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].datecount < 12)
                            {
                                Sounds.num3.Play();
                                timeinput(3, bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].datecount);
                            }
                            break;
                        case Keys.NumPad4:
                            if (bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].datecount < 12)
                            {
                                Sounds.num4.Play();
                                timeinput(4, bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].datecount);
                            }
                            break;
                        case Keys.D4:
                            if (bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].datecount < 12)
                            {
                                Sounds.num4.Play();
                                timeinput(4, bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].datecount);
                            }
                            break;
                        case Keys.NumPad5:
                            if (bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].datecount < 12)
                            {
                                Sounds.num5.Play();
                                timeinput(5, bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].datecount);
                            }
                            break;
                        case Keys.D5:
                            if (bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].datecount < 12)
                            {
                                Sounds.num5.Play();
                                timeinput(5, bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].datecount);
                            }
                            break;
                        case Keys.NumPad6:
                            if (bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].datecount < 12)
                            {
                                Sounds.num6.Play();
                                timeinput(6, bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].datecount);
                            }
                            break;
                        case Keys.D6:
                            if (bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].datecount < 12)
                            {
                                Sounds.num6.Play();
                                timeinput(6, bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].datecount);
                            }
                            break;
                        case Keys.NumPad7:
                            if (bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].datecount < 12)
                            {
                                Sounds.num7.Play();
                                timeinput(7, bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].datecount);
                            }
                            break;
                        case Keys.D7:
                            if (bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].datecount < 12)
                            {
                                Sounds.num7.Play();
                                timeinput(7, bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].datecount);
                            }
                            break;
                        case Keys.NumPad8:
                            if (bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].datecount < 12)
                            {
                                Sounds.num8.Play();
                                timeinput(8, bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].datecount);
                            }
                            break;
                        case Keys.D8:
                            if (bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].datecount < 12)
                            {
                                Sounds.num8.Play();
                                timeinput(8, bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].datecount);
                            }
                            break;
                        case Keys.NumPad9:
                            if (bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].datecount < 12)
                            {
                                Sounds.num9.Play();
                                timeinput(9, bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].datecount);
                            }
                            break;
                        case Keys.D9:
                            if (bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].datecount < 12)
                            {
                                Sounds.num9.Play();
                                timeinput(9, bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].datecount);
                            }
                            break;
                        case Keys.Enter:
                            int month = (bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].tmonth1 * 10) + bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].tmonth2;
                            int day = (bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].tday1 * 10) + bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].tday2;

                            if (bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].datecount == 12)
                            {
                                if ((month > 0 && month < 13) && (day > 0 && day < 31))
                                {
                                    Sounds.inputenter.Play();
                                    for (int i = 0; i < 20; i++)
                                    {
                                        displaysystem.display_background(bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].getDelorean(),
                                            bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].refilltimecurcuits,
                                            bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].toggletimecurcuits);
                                        Script.Wait(10);
                                    }

                                    Settime(bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].tday1,
                                        bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].tday2,
                                        bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].tmonth1,
                                        bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].tmonth2,
                                        bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].ty1,
                                        bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].ty2,
                                        bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].ty3,
                                        bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].ty4,
                                        bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].th1,
                                        bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].th2,
                                        bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].tm1,
                                        bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].tm2,
                                        bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].tampm);
                                    bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].datecount = 0;
                                    bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].tday1 = 0;
                                    bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].tday2 = 0;
                                    bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].tmonth1 = 0;
                                    bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].tmonth2 = 0;
                                    bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].ty1 = 0;
                                    bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].ty2 = 0;
                                    bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].ty3 = 0;
                                    bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].ty4 = 0;
                                    bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].th1 = 0;
                                    bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].th2 = 0;
                                    bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].tm1 = 0;
                                    bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].tm2 = 0;
                                    bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].tampm = "am";
                                    bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].datecount = 0;
                                }
                            }
                            else if (bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].datecount == 8)
                            {
                                if ((month > 0 && month < 13) && (day > 0 && day < 31))
                                {
                                    Sounds.inputenter.Play();
                                    for (int i = 0; i < 20; i++)
                                    {
                                        displaysystem.display_background(bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].getDelorean(),
                                            bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].refilltimecurcuits,
                                            bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].toggletimecurcuits);
                                        Script.Wait(10);
                                    }
                                    Settime(bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].tday1,
                                        bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].tday2,
                                        bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].tmonth1,
                                        bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].tmonth2,
                                        bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].ty1,
                                        bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].ty2,
                                        bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].ty3,
                                        bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].ty4,
                                        bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].fh1,
                                        bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].fh2,
                                        bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].fm1,
                                        bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].fm2,
                                        bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].fampm);
                                    bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].datecount = 0;
                                    bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].tday1 = 0;
                                    bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].tday2 = 0;
                                    bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].tmonth1 = 0;
                                    bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].tmonth2 = 0;
                                    bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].ty1 = 0;
                                    bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].ty2 = 0;
                                    bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].ty3 = 0;
                                    bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].ty4 = 0;
                                    bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].th1 = 0;
                                    bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].th2 = 0;
                                    bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].tm1 = 0;
                                    bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].tm2 = 0;
                                    bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].tampm = "am";
                                    bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].datecount = 0;
                                }
                            }
                            else if (bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].datecount == 4)
                            {
                                Sounds.inputenter.Play();
                                for (int i = 0; i < 20; i++)
                                {
                                    displaysystem.display_background(bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].getDelorean(),
                                        bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].refilltimecurcuits,
                                        bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].toggletimecurcuits);
                                    Script.Wait(10);
                                }
                                Settime(bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].fday1,
                                    bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].fday2,
                                    bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].fmonth1,
                                    bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].fmonth2,
                                    bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].fy1,
                                    bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].fy2,
                                    bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].fy3,
                                    bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].fy4,
                                    bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].tmonth1,
                                    bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].tmonth2,
                                    bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].tday1,
                                    bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].tday2,
                                    bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].tampm);
                                bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].datecount = 0;
                                bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].tday1 = 0;
                                bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].tday2 = 0;
                                bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].tmonth1 = 0;
                                bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].tmonth2 = 0;
                                bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].ty1 = 0;
                                bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].ty2 = 0;
                                bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].ty3 = 0;
                                bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].ty4 = 0;
                                bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].th1 = 0;
                                bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].th2 = 0;
                                bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].tm1 = 0;
                                bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].tm2 = 0;
                                bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].tampm = "am";
                                bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].datecount = 0;
                            }
                            else
                            {
                                Sounds.inputerror.Play();
                                bttfList[Game.Player.Character.CurrentVehicle.NumberPlate.Trim()].datecount = 0;
                            }
                            break;
                    }
                }
            }
        }
    }
}

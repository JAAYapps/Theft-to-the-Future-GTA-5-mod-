using System;
using GTA;
using GTA.Native;
using System.Drawing;
using System.Media;
using GTA.Math;
using System.IO;
using System.Windows.Forms;

namespace BTTF_Time_Travel
{
    class startingscene:Variableclass
    {
        static void spawn()
        {
            Vector3 position;
            position = new Vector3(1212.39f, 3102.92f, 40.48f);
            // At 90 degrees to the players heading
            float heading = 90;
            if (ExperimentScene.Deloreon != null)
                ExperimentScene.Deloreon.Position = position;
            while (ExperimentScene.Deloreon == null)
            {
                ExperimentScene.Deloreon = World.CreateVehicle(new Model("BTTF"), position, heading);
                Script.Wait(20);
                try
                {
                    Function.Call(Hash.SET_VEHICLE_MOD_KIT, ExperimentScene.Deloreon.Handle, 0);
                    ExperimentScene.Deloreon.SetMod(VehicleMod.RearBumper, 2, true);
                    ExperimentScene.Deloreon.ToggleMod(VehicleToggleMod.Turbo, true);
                    ExperimentScene.Deloreon.SetMod(VehicleMod.Frame, -1, true);
                    ExperimentScene.Deloreon.SetMod(VehicleMod.Horns, 16, true);
                    ExperimentScene.Deloreon.SetMod(VehicleMod.RearBumper, 0, true);
                    ExperimentScene.Deloreon.SetMod(VehicleMod.RightFender, 0, true);
                    ExperimentScene.Deloreon.SetMod(VehicleMod.Fender, 0, true);
                    ExperimentScene.Deloreon.SetMod(VehicleMod.ArchCover, 0, true);
                    ExperimentScene.Deloreon.SetMod(VehicleMod.Exhaust, 0, true);
                    ExperimentScene.Deloreon.SetMod(VehicleMod.Hood, 0, true);
                    ExperimentScene.Deloreon.SetMod(VehicleMod.Ornaments, 0, true);
                    if (!Function.Call<bool>(Hash.IS_VEHICLE_EXTRA_TURNED_ON, new InputArgument[] { ExperimentScene.Deloreon, 10 }))
                    {
                        Function.Call(Hash.SET_VEHICLE_EXTRA, new InputArgument[] { ExperimentScene.Deloreon, 10, 0 });
                    }
                    if (Function.Call<bool>(Hash.IS_VEHICLE_EXTRA_TURNED_ON, new InputArgument[] { ExperimentScene.Deloreon, 1 }))
                    {
                        Function.Call(Hash.SET_VEHICLE_EXTRA, new InputArgument[] { ExperimentScene.Deloreon, 1, -1 });
                    }
                }
                catch
                {

                }
                if (ExperimentScene.Deloreon == null)
                    Script.Wait(500);
            }
            ExperimentScene.Deloreon.Rotation = new Vector3(ExperimentScene.Docstruck.Rotation.X, ExperimentScene.Docstruck.Rotation.Y, ExperimentScene.Docstruck.Rotation.Z);
            TimeTravel.instantDelorean.Deloreanlist.Add(new TimeCircuits());
            TimeTravel.instantDelorean.Deloreanlist[TimeTravel.instantDelorean.Deloreanlist.Count - 1].Deloreon = ExperimentScene.Deloreon;
            TimeTravel.instantDelorean.Deloreanlist[TimeTravel.instantDelorean.Deloreanlist.Count - 1].candeloreanfly();
            ExperimentScene.Deloreon.DirtLevel = 0;
            ExperimentScene.Deloreon.NumberPlate = "OutATime";
        }

        static Ped Character = null;
        public static void Start()
        {
            Game.FadeScreenOut(500);

            Character = Game.Player.Character;

            foreach (Blip m in World.GetActiveBlips())
            {
                m.Remove();
            }

            Intro.Play();
            Script.Wait(10);
            string img;
            string image = Application.StartupPath + "\\scripts\\menu images";
            while (Intro.gettime() < 20.357)
            {
                if (Intro.gettime() > 2.846 && Intro.gettime() < 4.706)
                {
                    UIText debug = new UIText("Joshua Vanderzee" + Environment.NewLine + "       Presents", new Point(280, 300), (float)1.5);
                    debug.Draw();
                    img = "\\Tutorial Josh.jpg";
                    if (File.Exists(image + img))
                    {
                        NativeUI.Sprite.DrawTexture(image + img, new Point(500, 600), new Size(520, 360));
                    }
                    else
                    {

                    }
                }
                else if (Intro.gettime() > 8.975 && Intro.gettime() < 10.972)
                {
                    UIText debug = new UIText("               A" + Environment.NewLine + "Grand Theft Auto V BTTF" + Environment.NewLine + "             Mod", new Point(280, 200), (float)1.5);
                    debug.Draw();
                    img = "\\Tutorial mod.jpg";
                    if (File.Exists(image + img))
                    {
                        NativeUI.Sprite.DrawTexture(image + img, new Point(500, 600), new Size(520, 360));
                    }
                    else
                    {

                    }
                }
                else if (Intro.gettime() > 14.202 && Intro.gettime() < 16.499)
                {
                    UIText debug = new UIText("Go to the Desert air feild", new Point(280, 200), (float)1.5);
                    debug.Draw();
                    img = "\\Tutorial Time.jpg";
                    if (File.Exists(image + img))
                    {
                        NativeUI.Sprite.DrawTexture(image + img, new Point(500, 900), new Size(520, 360));
                    }
                    else
                    {

                    }
                }
                Script.Wait(10);
            }

            try
            {
                if (!(ExperimentScene.Docstruck == null))
                {
                    ExperimentScene.Docstruck.Delete();
                }
                Model gmcvan = VehicleHash.Benson;
                if (gmcvan.IsValid)
                {
                    ExperimentScene.Docstruck = World.CreateVehicle(gmcvan, new Vector3(2471.61f, 5563.09f, 44.40f), 201.16f);
                }

                if (!(ExperimentScene.Doc == null))
                {
                    ExperimentScene.Doc.Delete();
                }
                ExperimentScene.Doc = ExperimentScene.Docstruck.CreatePedOnSeat(VehicleSeat.Driver, new Model("S_M_M_Doctor_01"));

                Script.Wait(100);
                if (!(ExperimentScene.Einstein == null))
                {
                    ExperimentScene.Einstein.Delete();
                }
                ExperimentScene.Einstein = ExperimentScene.Docstruck.CreatePedOnSeat(VehicleSeat.Passenger, PedHash.Retriever);
                ExperimentScene.Einstein.IsInvincible = true;
                ExperimentScene.Docstruck.ApplyForceRelative(new Vector3(0, 6, 0));
                ExperimentScene.Doc.Task.CruiseWithVehicle(ExperimentScene.Docstruck, 40);
            }       
            catch (Exception e)
            {
                UI.ShowSubtitle("Error: " + e.Message);
            }
            Game.FadeScreenIn(500);
            Script.Wait(100);
            Function.Call(Hash.CHANGE_PLAYER_PED, Game.Player, ExperimentScene.Doc, true, true);
            Script.Wait(200);
            TimeTravel.instantDelorean.plutblip = World.CreateProp(new Model("prop_cash_case_01"), new Vector3(1264, 3136, 40), new Vector3(0, 11, 0), false, false);
            TimeTravel.instantDelorean.plutblip.AddBlip();
            TimeTravel.instantDelorean.plutblip.CurrentBlip.Color = BlipColor.Yellow;
            TimeTravel.instantDelorean.plutblip.CurrentBlip.IsFlashing = true;
            TimeTravel.instantDelorean.plutblip.CurrentBlip.ShowRoute = true;
            while (!Game.Player.Character.IsInRangeOf(new Vector3(1264, 3141, 40), 100))
            {
                UI.ShowSubtitle("Go to the the air feild");
                Script.Wait(10);
            }

            spawn();

            ExperimentScene.Docstruck.OpenDoor(VehicleDoor.Trunk, false, false);
            TimeTravel.instantDelorean.plutblip.Delete();

            while (!ExperimentScene.Deloreon.IsInRangeOf(ExperimentScene.Docstruck.GetOffsetInWorldCoords(new Vector3(0, -1, 1)), 1))
            {
                UI.ShowSubtitle("Drive the Delorean into the Truck");
                Script.Wait(10);
            }

            ExperimentScene.Docstruck.CloseDoor(VehicleDoor.Trunk, false);
            

            if (Game.Player.Character.Model == new Model("S_M_M_Doctor_01"))
            {
                Game.FadeScreenOut(500);
                Script.Wait(900);
                ExperimentScene.Einstein.Task.ClearAll();
                ExperimentScene.Einstein.Task.LeaveVehicle();
                ExperimentScene.Einstein.Task.RunTo(ExperimentScene.Docstruck.GetOffsetInWorldCoords(new Vector3(0, -3, -2)));
                Back_to_charactor();
            }
        }


        public static void Back_to_charactor()
        {
            Function.Call(Hash.CHANGE_PLAYER_PED, Game.Player, Character, true, true);
            Script.Wait(500);
            Game.FadeScreenIn(500);

            Blip loction = World.CreateBlip(new Vector3(1264, 3141, 40));
            loction.Color = BlipColor.Green;

            while (!Game.Player.Character.IsInRangeOf(new Vector3(1264, 3141, 40), 20))
            {
                UI.ShowSubtitle("Drive to Doc's Location");
                Script.Wait(10);
            }

            loction.Remove();

            ExperimentScene.Delorean_scene_start();
        }
    }
}

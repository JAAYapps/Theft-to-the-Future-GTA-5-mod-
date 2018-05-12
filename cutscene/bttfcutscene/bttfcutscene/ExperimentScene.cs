using GTA;
using GTA.Math;
using GTA.Native;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTTF_Time_Travel
{
    class ExperimentScene:Variableclass
    {

        #region Variables
        static bool reentry = false;
        static public bool Docwithremote = false;
        public static bool Libeadsappear = false;
        public static bool possiondisplay = false;
        #endregion

        static public Vehicle Docstruck;
        static public Vehicle Deloreon = null;

        #region Doc
        static public Ped Doc = null;
        static public Ped Einstein = null;
        #endregion

        static bool pressede = false;

        static public void Delorean_scene_start()
        {
            Deloreon.CanTiresBurst = false;

            while (!Game.Player.Character.IsInRangeOf(Deloreon.GetOffsetInWorldCoords(new Vector3(0, 0, 0)), (float)20.8))
            {
                if (Doc.IsDead)
                {
                    UI.ShowSubtitle("Doc Died.");
                    return;
                }
                Script.Wait(10);
            }

            DeloreonEnter.Play();
            while (DeloreonEnter.gettime() < 16.388)
            {
                if (Doc.IsDead)
                {
                    UI.ShowSubtitle("Doc Died.");
                    DeloreonEnter.Stop();
                    return;
                }
                Script.Wait(10);
            }
            Docstruck.OpenDoor(VehicleDoor.Trunk, false, false);
            while (DeloreonEnter.gettime() < 24.660)
            {
                if (Doc.IsDead)
                {
                    UI.ShowSubtitle("Doc Died.");
                    DeloreonEnter.Stop();
                    return;
                }
                Script.Wait(10);
            }
            Deloreon.EngineRunning = true;
            while (DeloreonEnter.gettime() < 26.758)
            {
                if (Doc.IsDead)
                {
                    UI.ShowSubtitle("Doc Died.");
                    DeloreonEnter.Stop();
                    return;
                }
                Script.Wait(10);
            }

            while (DeloreonEnter.gettime() < 42.063)
            {
                if (Doc.IsDead)
                {
                    UI.ShowSubtitle("Doc Died.");
                    DeloreonEnter.Stop();
                    return;
                }
                Deloreon.Speed = (float)-0.9;
                Script.Wait(10);
            }

            while (DeloreonEnter.gettime() < 48.322)
            {
                if (Doc.IsDead)
                {
                    UI.ShowSubtitle("Doc Died.");
                    DeloreonEnter.Stop();
                    return;
                }
                Script.Wait(10);
            }
            Doc.Task.LeaveVehicle(Deloreon, false);
            while (DeloreonEnter.gettime() < 50.904)
            {
                if (Doc.IsDead)
                {
                    UI.ShowSubtitle("Doc Died.");
                    DeloreonEnter.Stop();
                    return;
                }
                Script.Wait(10);
            }
            Doc.Task.GoTo(Game.Player.Character.GetOffsetInWorldCoords(new Vector3(0, 3, 0)));

            while (DeloreonEnter.gettime() < 54.904)
            {
                if (Doc.IsDead)
                {
                    UI.ShowSubtitle("Doc Died.");
                    DeloreonEnter.Stop();
                    return;
                }
                Script.Wait(10);
            }
            Experimentstart.Play();
            Doc.Task.TurnTo(Game.Player.Character);
            while (Experimentstart.gettime() < 5.758)
            {
                if (Doc.IsDead)
                {
                    UI.ShowSubtitle("Doc Died.");
                    Experimentstart.Stop();
                    return;
                }
                Script.Wait(10);
            }

            bool active = false;
            while(!active)
            {
                if (Doc.IsDead)
                {
                    UI.ShowSubtitle("Doc Died.");
                    Experimentstart.Stop();
                    return;
                }

                UIText Instruct2 = new UIText("Take out phone and open the camera app", new Point(400, 300), (float)0.9);
                Instruct2.Draw();

                if (Game.IsKeyPressed(Keys.Up))
                {
                    hitup = true;
                }

                if (hitup)
                {
                    if (Game.IsKeyPressed(Keys.Enter))
                    {
                        hitenter = true;
                        active = true;
                    }
                }
                if (hitup)
                    if (hitenter)
                        Experimentstartintro.Play();
                Script.Wait(10);
            }
            DocsExparamentstart = true;            
        }

        static bool hitup = false;
        static bool hitenter = false;
        static void make_effect(string root, string effect)
        {
            Function.Call(Hash._0xDD19FA1C6D657305, new InputArgument[] { Deloreon.Position.X, Deloreon.Position.Y, Deloreon.Position.Z, 10 });
            Function.Call(Hash._0xB80D8756B4668AB6, new InputArgument[] { root });
            Function.Call(Hash._0x6C38AF3693A69A91, new InputArgument[] { root });
            Function.Call(Hash._0x0D53A3B8DA0809D2, new InputArgument[] { effect, Game.Player.Character.CurrentVehicle.Handle, 0.0, 3.0, 0.5, 0.0, 0.0, 0.0, 3.0, 0, 0, 0 });
        }
        static void make_effect(string root, string effect, Vector3 pos, Vector3 rot, float scale, bool axisX, bool axisY, bool axisZ)
        {
            Function.Call(Hash._0xDD19FA1C6D657305, new InputArgument[] { Deloreon.Position.X, Deloreon.Position.Y, Deloreon.Position.Z, 10 });
            Function.Call(Hash._0xB80D8756B4668AB6, new InputArgument[] { root });
            Function.Call(Hash._0x6C38AF3693A69A91, new InputArgument[] { root });
            Function.Call(Hash._0x0D53A3B8DA0809D2, new InputArgument[] { effect, Deloreon.Handle, pos.X, pos.Y, pos.Z, rot.X, rot.Y, rot.Z, scale, axisX, axisY, axisZ });
        }
        static List<Prop> prop = new List<Prop>();
        static void make_effecttimetravel(double x, double y, int index)
        {
            var model = new Model("prop_beach_fire");
            model.Request(250);
            // Check the model is valid
            if (model.IsInCdImage && model.IsValid)
            {
                // Ensure the model is loaded before we try to create it in the world
                while (!model.IsLoaded) Script.Wait(50);

                // Create the prop in the world
                prop.Add(World.CreateProp(model, Deloreon.GetOffsetInWorldCoords(new Vector3((float)x, (float)y, (float)-1.3)), true, false));
            }
        }
        static List<Prop> prop2 = new List<Prop>();
        static void make_effecttimetravel2(double x, double y, int index)
        {
            var model = new Model("prop_beach_fire");
            model.Request(250);
            // Check the model is valid
            if (model.IsInCdImage && model.IsValid)
            {
                // Ensure the model is loaded before we try to create it in the world
                while (!model.IsLoaded) Script.Wait(50);

                // Create the prop in the world
                prop2.Add(World.CreateProp(model, Deloreon.GetOffsetInWorldCoords(new Vector3((float)x, (float)y, (float)-1.3)), true, false));
            }
        }
        static void reseteffect()
        {
            for (int i = prop.Count - 1; i >= 0; i--)
            {
                prop[i].Delete();
                prop.Remove(prop[i]);
                prop2[i].Delete();
                prop2.Remove(prop2[i]);
            }
        }
        static public void tick()
        {
            if (DocsExparamentstart)
            {
                UI.ShowSubtitle("Experiment with Einstein: " + Experimentstartintro.gettime());
                Deloreon.OpenDoor(VehicleDoor.FrontLeftDoor, false, false);
                while (Experimentstartintro.gettime() < 9.639)
                {
                    if (Doc.IsDead)
                    {
                        UI.ShowSubtitle("Doc Died.");
                        Experimentstartintro.Stop();
                        DocsExparamentstart = false;
                        return;
                    }
                    Script.Wait(10);
                }
                Doc.Task.GoTo(Deloreon.GetOffsetInWorldCoords(new Vector3(-2, -1, 0)));

                Einstein.Task.RunTo(Deloreon.GetOffsetInWorldCoords(new Vector3(-2, 0, 0)), true);

                while (Experimentstartintro.gettime() < 13.639)
                {
                    if (Doc.IsDead)
                    {
                        UI.ShowSubtitle("Doc Died.");
                        Experimentstartintro.Stop();
                        DocsExparamentstart = false;
                        return;
                    }
                    Script.Wait(10);
                }

                Einstein.Task.ClearAll();
                Einstein.Task.EnterVehicle(Deloreon, VehicleSeat.Driver);

                while (Experimentstartintro.gettime() < 15.639)
                {
                    if (Doc.IsDead)
                    {
                        UI.ShowSubtitle("Doc Died.");
                        Experimentstartintro.Stop();
                        DocsExparamentstart = false;
                        return;
                    }
                    Script.Wait(10);
                }

                while (!Einstein.IsInVehicle(Deloreon))
                {
                    if (Doc.IsDead)
                    {
                        UI.ShowSubtitle("Doc Died.");
                        Experimentstartintro.Stop();
                        DocsExparamentstart = false;
                        return;
                    }
                    Experimentstartintro.pause();
                    Script.Wait(10);
                }

                Experimentstartintro.resume();

                while (Experimentstartintro.gettime() < 20.791)
                {
                    if (Doc.IsDead)
                    {
                        UI.ShowSubtitle("Doc Died.");
                        Experimentstartintro.Stop();
                        DocsExparamentstart = false;
                        return;
                    }
                    Script.Wait(10);
                }

                while (Experimentstartintro.gettime() < 28.791)
                {
                    if (Doc.IsDead)
                    {
                        UI.ShowSubtitle("Doc Died.");
                        DocsExparamentstart = false;
                        Experimentstartintro.Stop();
                        return;
                    }
                    Script.Wait(10);
                }
                Deloreon.EngineRunning = true;
                DocsExparamentstart = false;
                Docwithremote = true;
            }
            else if (Docwithremote)
            {
                try
                {
                    if (Doc.IsDead)
                    {
                        UI.ShowSubtitle("Doc Died.");
                        Docwithremote = false;
                        return;
                    }

                    if (!pressede)
                    {
                        if (!TimeTravel.instantDelorean.Deloreanlist[TimeTravel.instantDelorean.Deloreanlist.Count - 1].RCmode)
                        {
                            UIText Instruct2 = new UIText("Press F5 and select Remote Control Mode (RCmode) in the menu. Select Delorean " + (TimeTravel.instantDelorean.Deloreanlist.Count), new Point(400, 300), (float)0.9);
                            Instruct2.Draw();
                        }
                        else if (TimeTravel.instantDelorean.Deloreanlist[TimeTravel.instantDelorean.Deloreanlist.Count - 1].RCmode)
                        {
                            Deloreon.CloseDoor(VehicleDoor.FrontLeftDoor, false);
                            while (!Game.IsKeyPressed(Keys.E))
                            {
                                if (Doc.IsDead)
                                {
                                    UI.ShowSubtitle("Doc committed suicide.");
                                    Docwithremote = false;
                                    return;
                                }
                                UIText Instruct2 = new UIText("Put phone away and press E when ready", new Point(400, 300), (float)0.9);
                                Instruct2.Draw();
                                Script.Wait(10);
                            }

                            Experimentstartwithremote.Play();

                            bool untilgo = false;

                            while (Experimentstartwithremote.gettime() < 10.688)
                            {
                                if (Doc.IsDead)
                                {
                                    UI.ShowSubtitle("Doc Died.");
                                    Docwithremote = false;
                                    Experimentstartwithremote.Stop();
                                    return;
                                }
                                Deloreon.Speed = 0;
                                Script.Wait(10);
                            }

                            while (!untilgo)
                            {
                                if (Doc.IsDead)
                                {
                                    UI.ShowSubtitle("Doc Died.");
                                    Docwithremote = false;
                                    Experimentstartwithremote.Stop();
                                    return;
                                }
                                if (Experimentstartwithremote.gettime() >= 10.688 && Experimentstartwithremote.gettime() <= 36.850)
                                {
                                    Deloreon.Speed = 0;

                                    if (Deloreon.IsInBurnout())
                                    {
                                        Experimentstartwithremote.resume();
                                    }
                                    else
                                    {
                                        Experimentstartwithremote.pause();
                                    }
                                }
                                else
                                {
                                    untilgo = true;
                                }
                                Script.Wait(10);
                            }

                            while (Experimentstartwithremote.gettime() <= 49.877)
                            {
                                if (Doc.IsDead)
                                {
                                    UI.ShowSubtitle("Doc committed suicide.");
                                    Docwithremote = false;
                                    Experimentstartwithremote.Stop();
                                    return;
                                }
                                Script.Wait(10);
                            }


                            while (Experimentstartwithremote.gettime() > 49.877 && Experimentstartwithremote.gettime() < 54.877)
                            {
                                if (Doc.IsDead)
                                {
                                    UI.ShowSubtitle("Doc committed suicide.");
                                    Docwithremote = false;
                                    Experimentstartwithremote.Stop();
                                    return;
                                }

                                int tempspeed = (int)((Deloreon.Speed / .27777) / 1.60934);

                                if (tempspeed > 84)
                                {
                                    Function.Call(Hash.SET_VEHICLE_MOD_KIT, Deloreon.Handle, 0);
                                    Deloreon.SetMod(VehicleMod.Spoilers, 0, true);
                                    Deloreon.SetMod(VehicleMod.Frame, 5, true);
                                    if (Game.Player.Character.CurrentVehicle.Model == "bttf3")
                                        World.DrawLightWithRange(Deloreon.GetOffsetInWorldCoords(new Vector3(0, (float)2.2, (float)0.5)), Color.Orange, (float)1.2, 400);
                                    else if (Game.Player.Character.CurrentVehicle.Model == "bttf3rr")
                                        World.DrawLightWithRange(Deloreon.GetOffsetInWorldCoords(new Vector3(0, (float)2.2, (float)0.5)), Color.Orange, (float)1.2, 400);
                                    else
                                        World.DrawLightWithRange(Deloreon.GetOffsetInWorldCoords(new Vector3(0, (float)2.2, (float)0.5)), Color.DodgerBlue, (float)1.2, 400);

                                    make_effect("scr_mp_house", "scr_sh_lighter_sparks", new Vector3(-0.8f, 1.1f, -0.5f), new Vector3(100, 0, 0), 2.9f, false, false, false);
                                    make_effect("scr_mp_house", "scr_sh_lighter_sparks", new Vector3(0.8f, 1.1f, -0.5f), new Vector3(100, 0, 0), 2.9f, false, false, false);
                                    make_effect("scr_mp_house", "scr_sh_lighter_sparks", new Vector3(-0.8f, -1.4f, -0.5f), new Vector3(100, 0, 0), 2.9f, false, false, false);
                                    make_effect("scr_mp_house", "scr_sh_lighter_sparks", new Vector3(0.8f, -1.4f, -0.5f), new Vector3(100, 0, 0), 2.9f, false, false, false);
                                    make_effect("scr_martin1", "scr_sol1_sniper_impact");
                                    if (Experimentstartwithremote.gettime() < 52.877)
                                        Experimentstartwithremote.resume();
                                    else
                                        if (tempspeed >= 88)
                                        Experimentstartwithremote.resume();
                                }
                                else
                                {
                                    Experimentstartwithremote.pause();
                                }
                                Script.Wait(10);
                            }

                            while (Experimentstartwithremote.gettime() < 53.877)
                            {
                                if (Doc.IsDead)
                                {
                                    UI.ShowSubtitle("Doc committed suicide.");
                                    Docwithremote = false;
                                    Experimentstartwithremote.Stop();
                                    return;
                                }
                                Script.Wait(10);
                            }

                            Deloreon.IsVisible = false;
                            Deloreon.Speed = 0;

                            for (double tempcount = 0; tempcount <= 8; tempcount += 0.1)
                            {
                                if (Doc.IsDead)
                                {
                                    UI.ShowSubtitle("Doc Died.");
                                    Docwithremote = false;
                                    Experimentstartwithremote.Stop();
                                    return;
                                }
                                World.DrawSpotLight(Deloreon.Position, Deloreon.Rotation, Color.SkyBlue, 80, 100, 60, 100, 5);
                                make_effecttimetravel(1, tempcount + 3, TimeTravel.instantDelorean.Deloreanlist.Count - 1);
                                make_effecttimetravel2(-1, tempcount + 3, TimeTravel.instantDelorean.Deloreanlist.Count - 1);
                                tempcount += 0.1;
                                make_effecttimetravel(1, tempcount + 3, TimeTravel.instantDelorean.Deloreanlist.Count - 1);
                                make_effecttimetravel2(-1, tempcount + 3, TimeTravel.instantDelorean.Deloreanlist.Count - 1);
                                tempcount += 0.1;
                                make_effecttimetravel(1, tempcount + 3, TimeTravel.instantDelorean.Deloreanlist.Count - 1);
                                make_effecttimetravel2(-1, tempcount + 3, TimeTravel.instantDelorean.Deloreanlist.Count - 1);
                                tempcount += 0.1;
                                make_effecttimetravel(1, tempcount + 3, TimeTravel.instantDelorean.Deloreanlist.Count - 1);
                                make_effecttimetravel2(-1, tempcount + 3, TimeTravel.instantDelorean.Deloreanlist.Count - 1);
                                Script.Wait(5);
                            }
                            reseteffect();
                            Script.Wait(2000);

                            System.Windows.Media.MediaPlayer RCcontrolstop = new System.Windows.Media.MediaPlayer();
                            RCcontrolstop.Open(new Uri(Variableclass.sounds + "stop_RC_control.wav"));
                            RCcontrolstop.Play();
                            Deloreon.EngineRunning = false;
                            Function.Call(Hash.CHANGE_PLAYER_PED, Game.Player, TimeTravel.instantDelorean.Deloreanlist[Variableclass.RCfeqency].playerped, true, true);
                            TimeTravel.instantDelorean.Deloreanlist[Variableclass.RCfeqency].RCmodeactive = false;
                            TimeTravel.instantDelorean.Deloreanlist[Variableclass.RCfeqency].RCped = null;
                            TimeTravel.instantDelorean.Deloreanlist[Variableclass.RCfeqency].RCmodeenabled = false;

                            Experimentsuccess.Play();

                            while (Experimentsuccess.gettime() < 6.281)
                            {
                                if (Doc.IsDead)
                                {
                                    UI.ShowSubtitle("Doc Died.");
                                    Docwithremote = false;
                                    Experimentsuccess.Stop();
                                    return;
                                }
                                Script.Wait(10);
                            }

                            while (Experimentsuccess.gettime() < 9.728)
                            {
                                if (Doc.IsDead)
                                {
                                    UI.ShowSubtitle("Doc Died.");
                                    Docwithremote = false;
                                    Experimentsuccess.Stop();
                                    return;
                                }
                                Doc.Task.Jump();
                                Script.Wait(100);
                            }
                            Doc.Task.UseMobilePhone();
                            Doc.Task.GoTo(Game.Player.Character.GetOffsetInWorldCoords(new Vector3(0, 3,0)));
                            while (Experimentsuccess.gettime() < 42.035)
                            {
                                if (Doc.IsDead)
                                {
                                    UI.ShowSubtitle("Doc Died.");
                                    Docwithremote = false;
                                    Experimentsuccess.Stop();
                                    return;
                                }
                                Script.Wait(10);
                            }

                            Doc.Task.ClearAll();
                            Doc.Task.PutAwayMobilePhone();
                            Script.Wait(6000);
                            Docwithremote = false;
                            reentry = true;
                            pressede = true;
                        }
                    }
                }
                catch (Exception e)
                {
                    UI.ShowSubtitle(e.Message + " " + e.Source);
                }            
            }
            else if (reentry)
            {
                Experimentstartwithreentry.Play();

                while (Experimentstartwithreentry.gettime() < 1.740)
                {
                    if (Doc.IsDead)
                    {
                        UI.ShowSubtitle("Doc Died.");
                        reentry = false;
                        Experimentstartwithreentry.Stop();
                        return;
                    }
                    Script.Wait(10);
                }
                Doc.Task.RunTo(Doc.GetOffsetInWorldCoords(new Vector3(-3, 0, 0)));
                Deloreon.Position = new Vector3(1274.99f, 3131.37f, 39.97f);
                Deloreon.Heading = 105.07f;
                Deloreon.Rotation = Docstruck.Rotation;
                World.DrawSpotLight(Deloreon.Position, Deloreon.Rotation, Color.SkyBlue, 80, 100, 60, 100, 5);
                Deloreon.IsVisible = true;
                Script.Wait(10);
                Deloreon.IsVisible = false;
                Script.Wait(50);
                World.DrawSpotLight(Deloreon.Position, Deloreon.Rotation, Color.SkyBlue, 80, 100, 60, 100, 5);
                Deloreon.IsVisible = true;
                Script.Wait(10);
                Deloreon.IsVisible = false;
                Script.Wait(50);
                World.DrawSpotLight(Deloreon.Position, Deloreon.Rotation, Color.SkyBlue, 80, 100, 60, 100, 5);
                Deloreon.IsVisible = true;
                Script.Wait(10);
                Deloreon.Speed = 20;

                Function.Call(Hash.SET_VEHICLE_MOD_KIT, Deloreon.Handle, 0);
                Deloreon.SetMod(VehicleMod.Spoilers, -1, true);
                Deloreon.SetMod(VehicleMod.Frame, -1, true);

                while (Experimentstartwithreentry.gettime() < 18.823)
                {
                    if (Doc.IsDead)
                    {
                        UI.ShowSubtitle("Doc Died.");
                        reentry = false;
                        Experimentstartwithreentry.Stop();
                        return;
                    }
                    Script.Wait(10);
                }
                Doc.Task.GoTo(Deloreon);
                while (Experimentstartwithreentry.gettime() < 24.398)
                {
                    if (Doc.IsDead)
                    {
                        UI.ShowSubtitle("Doc Died.");
                        reentry = false;
                        Experimentstartwithreentry.Stop();
                        return;
                    }
                    Script.Wait(10);
                }
                Doc.Task.ClearAll();
                while (Experimentstartwithreentry.gettime() < 28.154 && Experimentstartwithreentry.gettime() > 24.398)
                {
                    if (Doc.IsDead)
                    {
                        UI.ShowSubtitle("Doc Died.");
                        reentry = false;
                        Experimentstartwithreentry.Stop();
                        return;
                    }
                    make_effect("scr_familyscenem", "scr_meth_pipe_smoke", new Vector3(0.5f, -2f, 0.7f), new Vector3(10, 0, 180), 10.9f, false, false, false);
                    make_effect("scr_familyscenem", "scr_meth_pipe_smoke", new Vector3(-0.5f, -2f, 0.7f), new Vector3(10, 0, 180), 10.9f, false, false, false);
                    Script.Wait(10);
                }

                while (Experimentstartwithreentry.gettime() < 24.398)
                {
                    if (Doc.IsDead)
                    {
                        UI.ShowSubtitle("Doc Died.");
                        reentry = false;
                        Experimentstartwithreentry.Stop();
                        return;
                    }
                    Script.Wait(10);
                }
                Doc.Task.RunTo(Deloreon.GetOffsetInWorldCoords(new Vector3(-2,0,0)), true);

                while (Experimentstartwithreentry.gettime() < 46.147)
                {
                    if (Doc.IsDead)
                    {
                        UI.ShowSubtitle("Doc Died.");
                        reentry = false;
                        Experimentstartwithreentry.Stop();
                        return;
                    }
                    Script.Wait(10);
                }

                Doc.Task.EnterVehicle(Deloreon, VehicleSeat.Driver);

                while (Experimentstartwithreentry.gettime() < 46.582)
                {
                    if (Doc.IsDead)
                    {
                        UI.ShowSubtitle("Doc Died.");
                        reentry = false;
                        Experimentstartwithreentry.Stop();
                        return;
                    }
                    Script.Wait(10);
                }

                Doc.Task.ClearAll();

                while (Experimentstartwithreentry.gettime() < 49.073)
                {
                    if (Doc.IsDead)
                    {
                        UI.ShowSubtitle("Doc Died.");
                        reentry = false;
                        Experimentstartwithreentry.Stop();
                        return;
                    }
                    Script.Wait(10);
                }

                Doc.Task.EnterVehicle(Deloreon, VehicleSeat.Driver);

                while (Experimentstartwithreentry.gettime() < 50.457)
                {
                    if (Doc.IsDead)
                    {
                        UI.ShowSubtitle("Doc Died.");
                        reentry = false;
                        Experimentstartwithreentry.Stop();
                        return;
                    }
                    Script.Wait(10);
                }

                Deloreon.OpenDoor(VehicleDoor.FrontLeftDoor, false, false);
                Doc.Task.ClearAll();

                while (Experimentstartwithreentry.gettime() < 61)
                {
                    if (Doc.IsDead)
                    {
                        UI.ShowSubtitle("Doc Died.");
                        reentry = false;
                        Experimentstartwithreentry.Stop();
                        return;
                    }
                    Script.Wait(10);
                }

                Einstein.Task.LeaveVehicle();

                while (Experimentstartwithreentry.gettime() < 63)
                {
                    if (Doc.IsDead)
                    {
                        UI.ShowSubtitle("Doc Died.");
                        reentry = false;
                        Experimentstartwithreentry.Stop();
                        return;
                    }
                    Script.Wait(10);
                }

                Einstein.Task.GoTo(Docstruck);

                while (Experimentstartwithreentry.gettime() < 77)
                {
                    if (Doc.IsDead)
                    {
                        UI.ShowSubtitle("Doc Died.");
                        reentry = false;
                        Experimentstartwithreentry.Stop();
                        return;
                    }
                    Script.Wait(10);
                }

                Doc.Task.ClearAll();
                Doc.Task.EnterVehicle(Deloreon, VehicleSeat.Driver);

                while (Experimentstartwithreentry.gettime() < 79)
                {
                    if (Doc.IsDead)
                    {
                        UI.ShowSubtitle("Doc Died.");
                        reentry = false;
                        Experimentstartwithreentry.Stop();
                        return;
                    }
                    Script.Wait(10);
                }

                while (Experimentstartwithreentry.gettime() < 82)
                {
                    if (Doc.IsDead)
                    {
                        UI.ShowSubtitle("Doc Died.");
                        reentry = false;
                        Experimentstartwithreentry.Stop();
                        return;
                    }
                    TimeTravel.instantDelorean.Deloreanlist[TimeTravel.instantDelorean.Deloreanlist.Count - 1].display_background();
                    Script.Wait(10);
                }

                while (Experimentstartwithreentry.gettime() < 97)
                {
                    if (Doc.IsDead)
                    {
                        UI.ShowSubtitle("Doc Died.");
                        reentry = false;
                        Experimentstartwithreentry.Stop();
                        return;
                    }
                    TimeTravel.instantDelorean.Deloreanlist[TimeTravel.instantDelorean.Deloreanlist.Count - 1].display_background();
                    TimeTravel.instantDelorean.Deloreanlist[TimeTravel.instantDelorean.Deloreanlist.Count - 1].tick();
                    Script.Wait(10);
                }
                TimeTravel.instantDelorean.Deloreanlist[TimeTravel.instantDelorean.Deloreanlist.Count - 1].Settime(0, 4, 0, 7, 1, 7, 7, 6, 0, 8, 1, 2, "am");
                while (Experimentstartwithreentry.gettime() < 102)
                {
                    if (Doc.IsDead)
                    {
                        UI.ShowSubtitle("Doc Died.");
                        reentry = false;
                        Experimentstartwithreentry.Stop();
                        return;
                    }
                    TimeTravel.instantDelorean.Deloreanlist[TimeTravel.instantDelorean.Deloreanlist.Count - 1].display_background();
                    TimeTravel.instantDelorean.Deloreanlist[TimeTravel.instantDelorean.Deloreanlist.Count - 1].tick();
                    Script.Wait(10);
                }

                TimeTravel.instantDelorean.Deloreanlist[TimeTravel.instantDelorean.Deloreanlist.Count - 1].Settime(2, 5, 1, 2, 0, 0, 0, 0, 1, 1, 1, 2, "am");

                while (Experimentstartwithreentry.gettime() < 109)
                {
                    if (Doc.IsDead)
                    {
                        UI.ShowSubtitle("Doc Died.");
                        reentry = false;
                        Experimentstartwithreentry.Stop();
                        return;
                    }
                    TimeTravel.instantDelorean.Deloreanlist[TimeTravel.instantDelorean.Deloreanlist.Count - 1].display_background();
                    TimeTravel.instantDelorean.Deloreanlist[TimeTravel.instantDelorean.Deloreanlist.Count - 1].tick();
                    Script.Wait(10);
                }

                TimeTravel.instantDelorean.Deloreanlist[TimeTravel.instantDelorean.Deloreanlist.Count - 1].Settime(0, 5, 1, 1, 1, 9, 5, 5, 0, 5, 1, 2, "am");

                while (Experimentstartwithreentry.gettime() < 119)
                {
                    if (Doc.IsDead)
                    {
                        UI.ShowSubtitle("Doc Died.");
                        reentry = false;
                        Experimentstartwithreentry.Stop();
                        return;
                    }
                    TimeTravel.instantDelorean.Deloreanlist[TimeTravel.instantDelorean.Deloreanlist.Count - 1].display_background();
                    TimeTravel.instantDelorean.Deloreanlist[TimeTravel.instantDelorean.Deloreanlist.Count - 1].tick();
                    Script.Wait(10);
                }
                
                Libeadsappear = true;
            }
            if (Libeadsappear)
            {
                reentry = false;
                Game.FadeScreenOut(300);

                for (int i = 0; i < 10; i++)
                {
                    Script.Wait(10);
                }

                Einstein.Task.WarpIntoVehicle(Docstruck, VehicleSeat.Passenger);
                Deloreon.Position = new Vector3(1221.02f, 3118.34f, 39.97f);
                Deloreon.Heading = 103.44f;
                Doc.Task.WarpIntoVehicle(Deloreon, VehicleSeat.Driver);
                Game.Player.Character.Position = new Vector3(1257.35f, 3126.28f, 40.41f);
                Game.Player.Character.Heading = 92.70f;
                Vehicle libeadscar = World.CreateVehicle(new Model("volkvan"), new Vector3(1328.71f, 3172.37f, 40.42f), 101.83f);
                libeadscar.CreatePedOnSeat(VehicleSeat.Driver, PedHash.Eastsa01AMM);
                Ped shooter = World.CreatePed(PedHash.Eastsa02AMM, libeadscar.Position);
                shooter.HasCollision = false;
                libeadscar.GetPedOnSeat(VehicleSeat.Driver).DrivingStyle = DrivingStyle.AvoidTrafficExtremely;
                libeadscar.EnginePowerMultiplier = 100;
                shooter.IsInvincible = true;

                
                for (int i = 0; i < 10; i++)
                {
                    Script.Wait(10);
                }

                Game.FadeScreenIn(300);

                bool active = false;
                while (!active)
                {
                    if (Doc.IsDead)
                    {
                        UI.ShowSubtitle("Doc Died.");
                        Libeadsappear = false;
                        return;
                    }
                    UIText Instruct2 = new UIText("Take out phone and open the camera app", new Point(400, 300), (float)0.9);
                    Instruct2.Draw();

                    if (Game.IsKeyPressed(Keys.Up))
                    {
                        hitup = true;
                    }

                    if (hitup)
                    {
                        if (Game.IsKeyPressed(Keys.Enter))
                        {
                            hitenter = true;
                            active = true;
                        }
                    }
                    Script.Wait(10);
                }

                Deloreon.OpenDoor(VehicleDoor.FrontLeftDoor, false, false);
                Script.Wait(10);
                Doc.Task.LeaveVehicle(Deloreon, false);

                Doc.Task.TurnTo(Game.Player.Character);
                Libeads.Play();
                while (Libeads.gettime() < 29.371)
                {
                    if (Doc.IsDead)
                    {
                        UI.ShowSubtitle("Doc Died.");
                        Libeadsappear = false;
                        Libeads.Stop();
                        return;
                    }
                    Script.Wait(10);
                }

                shooter.Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);

                while (Libeads.gettime() < 32.371)
                {
                    if (Doc.IsDead)
                    {
                        UI.ShowSubtitle("Doc Died.");
                        Libeadsappear = false;
                        Libeads.Stop();
                        return;
                    }
                    //libeadscar.ApplyForceRelative(new Vector3(0, 1, 0));
                    Script.Wait(10);
                }

                libeadscar.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(libeadscar, Docstruck.Position, 20, 30);

                Libeads.resume();

                while (Libeads.gettime() < 41.394)
                {
                    if (Doc.IsDead)
                    {
                        UI.ShowSubtitle("Doc Died.");
                        Libeadsappear = false;
                        Libeads.Stop();
                        return;
                    }
                    shooter.Position = libeadscar.Position;
                    shooter.Task.AimAt(Doc, 10);
                    Script.Wait(10);
                }

                while (!libeadscar.IsNearEntity(Docstruck, new Vector3(30, 30, 30)))
                {
                    if (Doc.IsDead)
                    {
                        UI.ShowSubtitle("Doc Died.");
                        Libeadsappear = false;
                        Libeads.Stop();
                        return;
                    }
                    Libeads.pause();
                    shooter.Position = libeadscar.Position;
                    shooter.Task.AimAt(Doc, 10);
                    Script.Wait(10);
                }

                Chasescene.Play();

                libeadscar.GetPedOnSeat(VehicleSeat.Driver).Task.ClearAll();
                libeadscar.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(libeadscar, new Vector3(1215.54f, 3111.78f, 39.98f), 15, 100);
                Doc.Task.ClearAll();
                Doc.Task.RunTo(new Vector3(1259.13f, 3122.06f, 40.44f), true);
                Doc.Weapons.Give(WeaponHash.APPistol, 1, true, false);
                Doc.IsInvincible = true;

                while (Chasescene.gettime() < 3.662)
                {
                    if (Doc.IsDead)
                    {
                        UI.ShowSubtitle("Doc Died.");
                        Libeadsappear = false;
                        Chasescene.Stop();
                        return;
                    }
                    shooter.Position = libeadscar.Position;
                    shooter.Task.AimAt(Doc, 10);
                    shooter.Task.ShootAt(Doc);
                    Script.Wait(10);
                }

                Doc.Task.ClearAll();
                Doc.Task.RunTo(new Vector3(1265.08f, 3121.11f, 40.46f), true);
                Doc.Task.AimAt(shooter, 1000);
                shooter.Task.ClearAll();

                while (Chasescene.gettime() < 16.25)
                {
                    if (Doc.IsDead)
                    {
                        UI.ShowSubtitle("Doc Died.");
                        Libeadsappear = false;
                        Chasescene.Stop();
                        return;
                    }
                    shooter.Position = libeadscar.Position;
                    shooter.Task.AimAt(Doc, 10);
                    Script.Wait(10);
                }

                libeadscar.GetPedOnSeat(VehicleSeat.Driver).Task.ClearAll();
                libeadscar.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(libeadscar, new Vector3(1271.83f, 3124.76f, 40f), 2, 100);
                Doc.Task.ClearAll();
                Doc.Task.RunTo(Docstruck.GetOffsetInWorldCoords(new Vector3(0, -6, 0)));

                while (Chasescene.gettime() < 25)
                {
                    if (Doc.IsDead)
                    {
                        UI.ShowSubtitle("Doc Died.");
                        Libeadsappear = false;
                        Chasescene.Stop();
                        return;
                    }
                    shooter.Position = libeadscar.Position;
                    shooter.Task.AimAt(Doc, 10);
                    Script.Wait(10);
                }

                Doc.Task.ClearAll();
                Doc.Weapons.Drop();
                pedshoot = false;

                while (Chasescene.gettime() < 28.870)
                {
                    if (Doc.IsDead)
                    {
                        UI.ShowSubtitle("Doc Died.");
                        Libeadsappear = false;
                        Chasescene.Stop();
                        return;
                    }
                    shooter.Position = libeadscar.Position;
                    shooter.Task.AimAt(Doc, 10);
                    Script.Wait(10);
                }

                shooter.Task.ClearAll();
                shooter.Task.ShootAt(Doc);
                Doc.CanRagdoll = true;
                Doc.Kill();

                while (Chasescene.gettime() < 33)
                {
                    shooter.Position = libeadscar.Position;
                    shooter.Task.AimAt(Doc, 10);
                    Script.Wait(10);
                }

                while (Chasescene.gettime() < 36.987)
                {
                    UI.ShowSubtitle("Run to the left of the truck");
                    shooter.Position = libeadscar.Position;
                    shooter.Task.AimAt(Game.Player.Character, 10);
                    Script.Wait(10);
                }

                shooter.Task.ClearAll();
                shooter.Task.ShootAt(Game.Player.Character);
                libeadscar.GetPedOnSeat(VehicleSeat.Driver).Task.ClearAll();
                libeadscar.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(libeadscar, Docstruck.GetOffsetInWorldCoords(new Vector3(5f, -3f, 0f)), 2, 100);

                while (Chasescene.gettime() < 49.194)
                {
                    UI.ShowSubtitle("Run to the Delorean");
                    shooter.Position = libeadscar.Position;
                    shooter.Task.AimAt(Game.Player.Character, 10);
                    Script.Wait(10);
                }

                libeadscar.EngineRunning = false;

                while (Chasescene.gettime() < 58.838)
                {
                    shooter.Position = libeadscar.Position;
                    shooter.Task.AimAt(Game.Player.Character, 10);
                    Script.Wait(10);
                }

                libeadscar.EngineRunning = true;

                while (Chasescene.gettime() < 63)
                {
                    Deloreon.EngineRunning = false;
                    shooter.Position = libeadscar.Position;
                    shooter.Task.AimAt(Game.Player.Character, 10);
                    Script.Wait(10);
                }

                libeadscar.GetPedOnSeat(VehicleSeat.Driver).Task.VehicleChase(Game.Player.Character);


                while (Chasescene.gettime() < 63)
                {
                    shooter.Position = libeadscar.Position;
                    shooter.Task.AimAt(Game.Player.Character, 10);
                    shooter.Task.ShootAt(Game.Player.Character, 10);
                    Script.Wait(10);
                }

                while (Chasescene.gettime() < 146)
                {
                    shooter.Position = libeadscar.Position;
                    shooter.Task.AimAt(Game.Player.Character, 10);
                    shooter.Task.ShootAt(Game.Player.Character, 10);
                    Script.Wait(10);
                }

                while (Chasescene.gettime() > 146 && Chasescene.gettime() < 149)
                {
                    int tempspeed = (int)((Deloreon.Speed / .27777) / 1.60934);

                    if (tempspeed > 84)
                    {
                        Function.Call(Hash.SET_VEHICLE_MOD_KIT, Deloreon.Handle, 0);
                        Deloreon.SetMod(VehicleMod.Spoilers, 0, true);
                        Deloreon.SetMod(VehicleMod.Frame, 5, true);
                        if (Game.Player.Character.CurrentVehicle.Model == "bttf3")
                            World.DrawLightWithRange(Deloreon.GetOffsetInWorldCoords(new Vector3(0, (float)2.2, (float)0.5)), Color.Orange, (float)1.2, 400);
                        else if (Game.Player.Character.CurrentVehicle.Model == "bttf3rr")
                            World.DrawLightWithRange(Deloreon.GetOffsetInWorldCoords(new Vector3(0, (float)2.2, (float)0.5)), Color.Orange, (float)1.2, 400);
                        else
                            World.DrawLightWithRange(Deloreon.GetOffsetInWorldCoords(new Vector3(0, (float)2.2, (float)0.5)), Color.DodgerBlue, (float)1.2, 400);

                        make_effect("scr_mp_house", "scr_sh_lighter_sparks", new Vector3(-0.8f, 1.1f, -0.5f), new Vector3(100, 0, 0), 2.9f, false, false, false);
                        make_effect("scr_mp_house", "scr_sh_lighter_sparks", new Vector3(0.8f, 1.1f, -0.5f), new Vector3(100, 0, 0), 2.9f, false, false, false);
                        make_effect("scr_mp_house", "scr_sh_lighter_sparks", new Vector3(-0.8f, -1.4f, -0.5f), new Vector3(100, 0, 0), 2.9f, false, false, false);
                        make_effect("scr_mp_house", "scr_sh_lighter_sparks", new Vector3(0.8f, -1.4f, -0.5f), new Vector3(100, 0, 0), 2.9f, false, false, false);
                        make_effect("scr_martin1", "scr_sol1_sniper_impact");
                        Chasescene.resume();
                    }
                    else
                    {
                        Chasescene.pause();
                    }
                    Script.Wait(10);
                }

                if (Function.Call<int>(Hash.GET_FOLLOW_VEHICLE_CAM_VIEW_MODE) == 4)
                {
                    Delorean_class.timejump = true;
                    Deloreon.DirtLevel = 12;
                    //Function.Call(Hash.SET_CLOCK_DATE, getmonth(), getday(), getyear());
                    Function.Call(Hash.SET_CLOCK_TIME, ((TimeTravel.instantDelorean.Deloreanlist[TimeTravel.instantDelorean.Deloreanlist.Count - 1].fh1 * 10) + TimeTravel.instantDelorean.Deloreanlist[TimeTravel.instantDelorean.Deloreanlist.Count - 1].fh2), TimeTravel.instantDelorean.Deloreanlist[TimeTravel.instantDelorean.Deloreanlist.Count - 1].getminute(), 0);
                    if (TimeTravel.instantDelorean.Deloreanlist[TimeTravel.instantDelorean.Deloreanlist.Count - 1].refilltimecurcuits)
                    {
                        if (Deloreon.Model == "bttf3")
                        {
                            Variableclass.sparksbttf3.Stop();
                        }
                        Variableclass.sparksfeul.Stop();
                    }
                    else
                    {
                        if (Deloreon.Model == "bttf3")
                        {
                            Variableclass.sparksbttf3.Stop();
                        }
                        Variableclass.sparks.Stop();
                    }
                    Script.Wait(10);
                    Script.Wait(10);
                    if (Deloreon.Model == "bttf3" || Deloreon.Model == "bttf3rr")
                    {
                        Variableclass.Timetravelreentery3.Play();
                    }
                    else if (Deloreon.Model == "bttf2")
                    {
                        Variableclass.Timetravelreentery2.Play();
                    }
                    else if (Deloreon.Model == "bttf2f")
                    {
                        Variableclass.Timetravelreentery2f.Play();
                    }
                    else
                    {
                        Variableclass.Timetravelreentery.Play();
                    }
                    Script.Wait(10);
                    Ped[] peds = World.GetNearbyPeds(Game.Player.Character, 1000);
                    Vehicle[] pedVehicles = World.GetNearbyVehicles(Game.Player.Character, 1000);
                    for (int i = 0; i < peds.Length; i++)
                    {
                        Script.Wait(10);
                        if (peds[i] != Deloreon.GetPedOnSeat(VehicleSeat.Driver))
                            if (peds[i] != Deloreon.GetPedOnSeat(VehicleSeat.Passenger))
                                GTA.Native.Function.Call(GTA.Native.Hash.SET_ENTITY_COORDS_NO_OFFSET, peds[i], 0, 0, 0, 0, 0, 1);
                    }
                    Array.Clear(peds, 0, peds.Length);
                    Script.Wait(10);
                    for (int i = 0; i < pedVehicles.Length; i++)
                    {
                        Script.Wait(10);
                        if (pedVehicles[i] != Deloreon)
                            GTA.Native.Function.Call(GTA.Native.Hash.SET_ENTITY_COORDS_NO_OFFSET, pedVehicles[i], 0, 0, 0, 0, 0, 1);
                    }
                    Array.Clear(pedVehicles, 0, pedVehicles.Length);
                    //End Ped Despawning
                    GTA.Native.Function.Call(GTA.Native.Hash.SET_RANDOM_WEATHER_TYPE);
                    Script.Wait(10);
                    Game.Player.WantedLevel = 0;

                    Properties.Settings.Default.presday1 = TimeTravel.instantDelorean.Deloreanlist[TimeTravel.instantDelorean.Deloreanlist.Count - 1].presday1;
                    Properties.Settings.Default.presday2 = TimeTravel.instantDelorean.Deloreanlist[TimeTravel.instantDelorean.Deloreanlist.Count - 1].presday2;
                    Properties.Settings.Default.presmonth1 = TimeTravel.instantDelorean.Deloreanlist[TimeTravel.instantDelorean.Deloreanlist.Count - 1].presmonth1;
                    Properties.Settings.Default.presmonth2 = TimeTravel.instantDelorean.Deloreanlist[TimeTravel.instantDelorean.Deloreanlist.Count - 1].presmonth2;
                    Properties.Settings.Default.presy1 = TimeTravel.instantDelorean.Deloreanlist[TimeTravel.instantDelorean.Deloreanlist.Count - 1].presy1;
                    Properties.Settings.Default.presy2 = TimeTravel.instantDelorean.Deloreanlist[TimeTravel.instantDelorean.Deloreanlist.Count - 1].presy2;
                    Properties.Settings.Default.presy3 = TimeTravel.instantDelorean.Deloreanlist[TimeTravel.instantDelorean.Deloreanlist.Count - 1].presy3;
                    Properties.Settings.Default.presy4 = TimeTravel.instantDelorean.Deloreanlist[TimeTravel.instantDelorean.Deloreanlist.Count - 1].presy4;
                    Properties.Settings.Default.Save();
                    Script.Wait(10);
                    Script.Wait(10);
                    Function.Call(Hash.SET_VEHICLE_MOD_KIT, Deloreon.Handle, 0);
                    Deloreon.SetMod(VehicleMod.Spoilers, 1, true);
                    Deloreon.SetMod(VehicleMod.FrontBumper, -1, true);
                }

                libeadscar.Explode();
                Script.Wait(500);
                libeadscar.GetPedOnSeat(VehicleSeat.Driver).Delete();
                libeadscar.Delete();
                shooter.Delete();
                libeadscar = null;
                shooter = null;
                if (Game.Player.Character.Model == new Model("S_M_M_Doctor_01"))
                {
                    Game.FadeScreenOut(500);
                    Script.Wait(500);
                    startingscene.Back_to_charactor();
                }

                TimeTravel.instantDelorean.Deloreanlist[TimeTravel.instantDelorean.Deloreanlist.Count - 1].timetravelentry();

                Libeadsappear = false;

                Deloreon.Position = new Vector3(2219.35f, 5640.13f, 55.99f);
                Deloreon.Heading = 141.37f;

                //x 2219.35 y 5640.13 z 55.99 head 141.37
            }
        }

        static bool pedshoot = true;
        static int sendcommand = 0;

        static void libeadscontrol(Vehicle libeadscar, Ped shooter)
        {
            Ped driver = libeadscar.GetPedOnSeat(VehicleSeat.Driver);

            if (libeadscar != null && shooter != null)
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
        }
    }
}

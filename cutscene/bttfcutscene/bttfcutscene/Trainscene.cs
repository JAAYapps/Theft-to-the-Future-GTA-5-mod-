using GTA;
using GTA.Math;
using GTA.Native;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTTF_Time_Travel
{
    class Trainscene
    {


        public static Vehicle train = null;
        static Vehicle de = null;
        static Vehicle docstrain = null;
        public static bool istrainpresent = false;
        static Ped doc = null;

        void waitingForTimeSubmit()
        {
            if (Trainscene.istrainpresent)
            {
                if (Trainscene.train.Speed < 2)
                {
                    if ((int)((Trainscene.train.Speed / .27777) / 1.60934) < 10)
                        Trainscene.train.Speed += 0.1f;
                    else
                        Trainscene.train.Speed -= 0.1f;
                }
                else
                {
                    if ((int)((Trainscene.train.Speed / .27777) / 1.60934) < 10)
                        Trainscene.train.Speed += 0.01f;
                    else
                        Trainscene.train.Speed -= 0.01f;
                }
                Trainscene.tick(28);
                if (toggletimecurcuits)
                {
                    if (!TimeTravel.instantDelorean.Deloreanlist[index].refilltimecurcuits)
                    {
                        Variableclass.Mrfrusionfill.Play();
                        TimeTravel.instantDelorean.Deloreanlist[index].Deloreon.OpenDoor(VehicleDoor.Trunk, false, false);
                        TimeTravel.instantDelorean.Deloreanlist[index].refilltimecurcuits = true;
                        for (int i = 0; i < 80; i++)
                        {
                            Trainscene.tick(28);
                            Script.Wait(10);
                        }
                        TimeTravel.instantDelorean.Deloreanlist[index].Deloreon.CloseDoor(VehicleDoor.Trunk, false);
                    }
                    circuit_gadge_active();
                    if (!Trainscene.active)
                    {
                        Trainscene.timeon();
                        Trainscene.active = true;
                    }
                }
            }
        }

        public static void delete_incomplete_scene()
        {
            train.Delete();
            de.Delete();
            docstrain.Delete();
            foreach (Vehicle i in World.GetNearbyVehicles(Game.Player.Character, 1000))
            {
                if (i.Model.IsTrain)
                    i.Delete();
                Script.Wait(10);
            }
            istrainpresent = false;
        }

        public static void Startscene()
        {
            if (Game.Player.Character.IsInVehicle())
            {
                foreach (Vehicle i in World.GetNearbyVehicles(Game.Player.Character, 30))
                {
                    if (i.Model.IsTrain)
                        if (i.Model == new Model(VehicleHash.Freight))
                        {
                            //Game.FadeScreenOut(300);
                            docstrain = i;
                            istrainpresent = true;
                        }

                    Script.Wait(10);
                }
                if (Game.Player.Character.CurrentVehicle.Model == new Model("BTTF3rr") && istrainpresent)
                {
                    Vector3 trainv = docstrain.GetOffsetInWorldCoords(new Vector3(0, 200, 0));
                    train = Function.Call<Vehicle>(Hash.CREATE_MISSION_TRAIN, 1, trainv.X, trainv.Y, trainv.Z, true);
                    train.HasCollision = false;
                    train.Alpha = 0;
                    Script.Wait(100);
                    train.Speed = 0;
                    Script.Wait(100);
                    foreach (Vehicle i in World.GetNearbyVehicles(train.Position, 300))
                    {
                        if (i.Model.IsTrain)
                            if (i.Model != new Model(VehicleHash.Freight))
                                i.Delete();
                        Script.Wait(1);
                    }
                    docstrain.Speed = 10;
                    Script.Wait(100);
                    de = Game.Player.Character.CurrentVehicle;
                    de.Position = train.Position;
                    de.Heading = train.Heading;
                    doc = de.CreatePedOnSeat(VehicleSeat.Passenger, PedHash.Scientist01SMM);
                    //Game.FadeScreenIn(300);
                    Variableclass.trainenter.Play();
                    docstrain.Speed = 0;
                    while (Variableclass.trainenter.gettime() < 24.220)
                    {
                        de.Position = train.Position;
                        de.Heading = train.Heading;
                        UI.ShowSubtitle("Train away from docs train: " + Math.Round(train.GetOffsetFromWorldCoords(docstrain.Position).Y, 1));
                        if (-Math.Round(de.GetOffsetFromWorldCoords(docstrain.Position).Y, 1) < 11.5)
                        {
                            docstrain.Speed = 0;
                        }
                        else if (-Math.Round(de.GetOffsetFromWorldCoords(docstrain.Position).Y, 1) < 40)
                        {
                            if (docstrain.Speed > 3)
                                docstrain.Speed -= 0.01f;
                        }
                        else
                        {
                            docstrain.Speed = 7f;
                        }
                        Script.Wait(10);
                    }
                    while (docstrain.Speed > 0)
                    {
                        if (-Math.Round(de.GetOffsetFromWorldCoords(docstrain.Position).Y, 1) < 11.5)
                        {
                            docstrain.Speed = 0;
                        }
                        Script.Wait(10);
                    }

                    if (de.IsTouching(docstrain))
                    {
                        delete_incomplete_scene();
                        return;
                    }
                    de.Position = train.Position;
                    de.Heading = train.Heading;
                    Variableclass.trainstart.Play();
                    de.OpenDoor(VehicleDoor.FrontRightDoor, false, false);
                    doc.Task.LeaveVehicle();
                    while (Variableclass.trainstart.gettime() < 4.206)
                    {
                        UI.ShowSubtitle("Train away from docs train: " + Math.Round(train.GetOffsetFromWorldCoords(docstrain.Position).Y, 1));
                        Script.Wait(10);
                    }
                    doc.Task.ClearAll();
                    doc.Task.GoTo(docstrain.GetOffsetInWorldCoords(new Vector3(0,-6,3)), true);
                    while (Variableclass.trainstart.gettime() < 21.532)
                    {
                        UI.ShowSubtitle("Train away from docs train: " + Math.Round(train.GetOffsetFromWorldCoords(docstrain.Position).Y, 1));
                        Script.Wait(10);
                    }
                    doc.Task.ClearAll();
                    doc.Task.Climb();
                    Variableclass.trainstart.pause();
                    Script.Wait(600);
                    doc.Task.ClearAll();
                    doc.Task.GoTo(de.GetOffsetInWorldCoords(new Vector3(0, 0, 0)), true);
                    while (!Game.Player.Character.IsInVehicle(de))
                    {
                        Script.Wait(10);
                    }
                    Variableclass.trainstart.resume();
                    doc.HasCollision = false;
                    while (Variableclass.trainstart.gettime() < 25.726)
                    {
                        doc.Position = docstrain.GetOffsetInWorldCoords(trainstandingpos);
                        Script.Wait(10);
                    }
                    doc.Task.ClearAll();
                    doc.Task.GoTo(de.GetOffsetInWorldCoords(new Vector3(0, 0, 0)), true);
                    de.Position = train.Position;
                    de.Heading = train.Heading;
                    while (Variableclass.trainstart.gettime() < 48.860)
                    {
                        doc.Position = docstrain.GetOffsetInWorldCoords(trainstandingpos);
                        tick(10);
                        Script.Wait(10);
                    }
                    doc.Task.ClearAll();
                    doc.Task.GoTo(de.GetOffsetInWorldCoords(new Vector3(0, 0, 0)), true);
                    while (Variableclass.trainstart.gettime() < 54.344)
                    {
                        doc.Position = docstrain.GetOffsetInWorldCoords(trainstandingpos);
                        tick(10);
                        Script.Wait(10);
                    }
                    doc.Task.ClearAll();
                    doc.Task.GoTo(de.GetOffsetInWorldCoords(new Vector3(0, 0, 0)), true);
                    Variableclass.trainstart.pause();
                }
                else
                {
                    UI.ShowSubtitle("Train is not present.");
                }
            }

            
        }

        public static bool active = false;
        public static void timeon()
        {
            Variableclass.trainstart.resume();
            doc.Task.ClearAll();
            doc.Task.GoTo(de.GetOffsetInWorldCoords(new Vector3(0, 0, 0)), true);
            while (Variableclass.trainstart.gettime() < 59.376)
            {
                doc.Position = docstrain.GetOffsetInWorldCoords(trainstandingpos);
                tick(26);
                Script.Wait(10);
            }
            doc.Task.ClearAll();
            doc.Task.GoTo(de.GetOffsetInWorldCoords(new Vector3(0, 0, 0)), true);
            Variableclass.trainstart.pause();
        }

        public static void timeenter()
        {
            de.IsInvincible = true;
            de.CanBeVisiblyDamaged = false;

            Variableclass.trainstart.resume();
            doc.Task.ClearAll();
            doc.Task.GoTo(de.GetOffsetInWorldCoords(new Vector3(0, 0, 0)), true);
            while (Variableclass.trainstart.gettime() < 98.6)
            {
                doc.Position = docstrain.GetOffsetInWorldCoords(trainstandingpos);
                tick(28);
                Script.Wait(10);
            }
            doc.Task.ClearAll();
            doc.Task.GoTo(de.GetOffsetInWorldCoords(new Vector3(0, 0, 0)), true);
            World.AddExplosion(docstrain.GetOffsetInWorldCoords(new Vector3(0, -4, 0)), ExplosionType.Car, 3, 5);
            while (Variableclass.trainstart.gettime() < 107.5)
            {
                doc.Position = docstrain.GetOffsetInWorldCoords(trainstandingpos);
                if (doc.IsDead)
                {
                    delete_incomplete_scene();
                    return;
                }
                tick(37);
                Script.Wait(10);
            }
            doc.Task.ClearAll();
            doc.Task.GoTo(de.GetOffsetInWorldCoords(new Vector3(0, 0, 0)), true);
            while (Variableclass.trainstart.gettime() < 135.6)
            {
                doc.Position = docstrain.GetOffsetInWorldCoords(trainstandingpos);
                tick(37);
                Script.Wait(10);
            }
            doc.Task.ClearAll();
            doc.Task.GoTo(de.GetOffsetInWorldCoords(new Vector3(0, 0, 0)), true);
            doc.IsInvincible = true;
            World.AddExplosion(docstrain.GetOffsetInWorldCoords(new Vector3(0, -4, 0)), ExplosionType.Car, 3, 10);
            while (Variableclass.trainstart.gettime() < 144)
            {
                doc.Position = docstrain.GetOffsetInWorldCoords(trainstandingpos);
                if (doc.IsDead)
                {
                    delete_incomplete_scene();
                    return;
                }
                tick(41);
                Script.Wait(10);
            }
            doc.Task.ClearAll();
            doc.Task.GoTo(de.GetOffsetInWorldCoords(new Vector3(0, 0, 0)), true);
            while (Variableclass.trainstart.gettime() < 177)
            {
                doc.Position = docstrain.GetOffsetInWorldCoords(trainstandingpos);
                tick(47);
                Script.Wait(10);
            }
            doc.HasCollision = true;
            doc.Task.ClearAll();
            doc.Task.GoTo(de.GetOffsetInWorldCoords(new Vector3(0, 0, 0)), true);
            Function.Call(Hash.CHANGE_PLAYER_PED, Game.Player, doc, true, true);
            while (Variableclass.trainstart.gettime() < 188)
            {
                tick(52);
                Script.Wait(10);
            }
            docstrain.Speed = 55;
            while (Variableclass.trainstart.gettime() < 193)
            {
                tick(60);
                Script.Wait(10);
            }
            docstrain.Speed = 67;
            while (Variableclass.trainstart.gettime() < 198)
            {
                tick(70);
                Script.Wait(10);
            }
            while (Variableclass.trainstart.gettime() < 202.6)
            {
                tick(78);
                Script.Wait(10);
            }
            World.AddExplosion(docstrain.GetOffsetInWorldCoords(new Vector3(0, -4, 0)), ExplosionType.Car, 3, 20);
            while (Variableclass.trainstart.gettime() < 234)
            {
                if (doc.IsDead)
                {
                    delete_incomplete_scene();
                    Variableclass.trainstart.Stop();
                    return;
                }
                tick(78);
                Script.Wait(10);
            }
            while (Variableclass.trainstart.gettime() < 237)
            {
                UI.ShowSubtitle("Jump NOW!");
                tick(78);
                Script.Wait(10);
            }
            Variableclass.trainstart.pause();
            doc.MaxHealth = 3000;
            doc.Health = 3000;
            while (!doc.IsTouching(de))
            {
                if (doc.IsDead)
                {
                    Function.Call(Hash.CHANGE_PLAYER_PED, Game.Player, de.GetPedOnSeat(VehicleSeat.Driver), true, true);
                    delete_incomplete_scene();
                    return;
                }
                if (doc.HeightAboveGround < 1)
                {
                    Function.Call(Hash.CHANGE_PLAYER_PED, Game.Player, de.GetPedOnSeat(VehicleSeat.Driver), true, true);
                    delete_incomplete_scene();
                    return;
                }
                tick(82);
                Script.Wait(10);
            }
            Variableclass.trainstart.resume();
            Function.Call(Hash.CHANGE_PLAYER_PED, Game.Player, de.GetPedOnSeat(VehicleSeat.Driver), true, true);
            doc.HasCollision = false;
            while (Variableclass.trainstart.gettime() < 240)
            {
                doc.Position = de.Position;
                tick(82);
                Script.Wait(10);
            }
            doc.Task.WarpIntoVehicle(de, VehicleSeat.Passenger);
            doc.HasCollision = true;
            while (Variableclass.trainstart.gettime() < 250)
            {
                tick(82);
                Script.Wait(10);
            }
            doc.Task.ClearAll();
            de.CloseDoor(VehicleDoor.FrontRightDoor, false);
            while (Variableclass.trainstart.gettime() < 264)
            {
                tick(89);
                Script.Wait(10);
            }            
            while (Variableclass.trainstart.gettime() < 278)
            {
                make_effect("scr_mp_house", "scr_sh_lighter_sparks", new Vector3(-0.8f, 1.1f, -0.5f), new Vector3(100, 0, 0), 2.9f, false, false, false);
                make_effect("scr_mp_house", "scr_sh_lighter_sparks", new Vector3(0.8f, 1.1f, -0.5f), new Vector3(100, 0, 0), 2.9f, false, false, false);
                make_effect("scr_mp_house", "scr_sh_lighter_sparks", new Vector3(-0.8f, -1.4f, -0.5f), new Vector3(100, 0, 0), 2.9f, false, false, false);
                make_effect("scr_mp_house", "scr_sh_lighter_sparks", new Vector3(0.8f, -1.4f, -0.5f), new Vector3(100, 0, 0), 2.9f, false, false, false);
                make_effect("scr_family4", "scr_fam4_trailer_sparks", new Vector3(0, 2.5f, 1.7f), new Vector3(100, 0, 0), 0.9f, false, false, false);
                tick(89);
                de.CloseDoor(VehicleDoor.FrontRightDoor, true);
                Script.Wait(10);
            }
            de.IsVisible = false;
            de.FreezePosition = true;
            de.HasCollision = false;
            train.Speed = 0;

            for (double tempcount = 0; tempcount <= 8; tempcount += 0.1)
            {
                World.DrawSpotLight(de.Position, de.Rotation, Color.SkyBlue, 80, 100, 60, 100, 5);
                make_effecttimetravel(1, tempcount + 3, 0);
                make_effecttimetravel2(-1, tempcount + 3, 0);
                tempcount += 0.1;
                make_effecttimetravel(1, tempcount + 3, 0);
                make_effecttimetravel2(-1, tempcount + 3, 0);
                tempcount += 0.1;
                make_effecttimetravel(1, tempcount + 3, 0);
                make_effecttimetravel2(-1, tempcount + 3, 0);
                tempcount += 0.1;
                make_effecttimetravel(1, tempcount + 3, 0);
                make_effecttimetravel2(-1, tempcount + 3, 0);
                Script.Wait(10);
            }
            while (Variableclass.trainstart.gettime() < 283)
            {
                Script.Wait(10);
            }
            reseteffect();
            Game.FadeScreenOut(500);
            while (Variableclass.trainstart.gettime() < 284)
            {
                Script.Wait(10);
            }
            foreach (TimeCircuits i in TimeTravel.instantDelorean.Deloreanlist)
            {
                if (i.Deloreon == Game.Player.Character.CurrentVehicle)
                {
                    Function.Call(Hash.SET_CLOCK_TIME, ((i.fh1 * 10) + i.fh2), i.getminute(), 0);
                    i.timetravelentry();
                }
            }
            while (Variableclass.trainstart.gettime() < 286)
            {
                Script.Wait(10);
            }
            Game.FadeScreenIn(500);
            while (Variableclass.trainstart.gettime() < 287)
            {
                Script.Wait(10);
            }
            World.DrawSpotLight(de.Position, de.Rotation, Color.DeepSkyBlue, 80, 100, 60, 100, 5);
            if (de.Model == new Model("BTTF3") || de.Model == new Model("BTTF3rr"))
                make_effect("scr_martin1", "scr_sol1_sniper_impact");
            Script.Wait(700);
            if (de.Model == new Model("BTTF3") || de.Model == new Model("BTTF3rr"))
                make_effect("scr_martin1", "scr_sol1_sniper_impact");
            World.DrawSpotLight(de.Position, de.Rotation, Color.DeepSkyBlue, 80, 100, 60, 100, 5);
            Script.Wait(700);
            if (de.Model == new Model("BTTF3") || de.Model == new Model("BTTF3rr"))
                make_effect("scr_martin1", "scr_sol1_sniper_impact");
            World.DrawSpotLight(de.Position, de.Rotation, Color.DeepSkyBlue, 80, 100, 60, 100, 5);
            de.FreezePosition = false;
            de.HasCollision = true;
            de.IsVisible = true;
            Game.Player.WantedLevel = 0;
            Vector3 temppos = train.Position;
            train.Speed = 40;
            de.Speed = 40;
            Script.Wait(1000);
            Vehicle moderntrain = Function.Call<Vehicle>(Hash.CREATE_MISSION_TRAIN, 1, temppos.X, temppos.Y, temppos.Z, true);
            while (Variableclass.trainstart.gettime() < 236)
            {
                if (Math.Round(de.GetOffsetFromWorldCoords(train.Position).X, 1) < 0)
                    de.Heading = train.Heading + -((float)Math.Round(de.GetOffsetFromWorldCoords(train.Position).X, 1) - 0.7f);
                if (Math.Round(de.GetOffsetFromWorldCoords(train.Position).X, 1) > 0)
                    de.Heading = train.Heading - ((float)Math.Round(de.GetOffsetFromWorldCoords(train.Position).X, 1) + 0.7f);
                train.Speed -= 0.03f;
                de.Speed = train.Speed + 0.5f;
                Script.Wait(10);
            }
            while (Variableclass.trainstart.gettime() < 334)
            {
                if (Math.Round(de.GetOffsetFromWorldCoords(train.Position).X, 1) < 0)
                    de.Heading = train.Heading + -((float)Math.Round(de.GetOffsetFromWorldCoords(train.Position).X, 1) - 0.7f);
                if (Math.Round(de.GetOffsetFromWorldCoords(train.Position).X, 1) > 0)
                    de.Heading = train.Heading - ((float)Math.Round(de.GetOffsetFromWorldCoords(train.Position).X, 1) + 0.7f);
                train.Speed -= 0.03f;
                de.Speed = train.Speed + 0.5f;
                Script.Wait(10);
            }
            train.Speed = 0;
            de.Speed = 0;
            moderntrain.Speed = 50;
            moderntrain.AddBlip();
            moderntrain.CurrentBlip.Color = BlipColor.Red;
            Game.Player.Character.IsInvincible = true;
            doc.IsInvincible = true;
            de.IsInvincible = false;
            de.CanBeVisiblyDamaged = true;
            doc.Task.ClearAll();
            doc.Task.LeaveVehicle();
            doc.Task.RunTo(de.GetOffsetInWorldCoords(new Vector3(10, 0, 0)));
            while (Variableclass.trainstart.gettime() < 336)
            {
                UI.ShowSubtitle("Get out NOW!");
                Script.Wait(10);
            }
            Variableclass.trainstart.pause();
            int temp = 1000;
            while (!moderntrain.IsTouching(de))
            {
                if (temp <= 0)
                    break;
                temp--;
                Script.Wait(10);
            }
            moderntrain.CurrentBlip.Remove();
            Variableclass.trainstart.resume();
            de.BreakDoor(VehicleDoor.FrontLeftDoor);
            de.BreakDoor(VehicleDoor.FrontRightDoor);
            de.BreakDoor(VehicleDoor.BackLeftDoor);
            de.BreakDoor(VehicleDoor.BackLeftDoor);
            de.BreakDoor(VehicleDoor.Trunk);
            de.BreakDoor(VehicleDoor.Hood);
            
            World.AddExplosion(de.Position, ExplosionType.Car, 3, 10);
            de.Explode();
            
            while (Variableclass.trainstart.gettime() < 383)
            {
                Script.Wait(10);
            }
            Game.Player.Character.IsInvincible = false;
            doc.IsInvincible = false;
            moderntrain.Delete();
            train.Delete();
            docstrain.Delete();
            istrainpresent = false;
        }

        static void make_effect(string root, string effect)
        {
            Function.Call(Hash._0xDD19FA1C6D657305, new InputArgument[] { de.Position.X, de.Position.Y, de.Position.Z, 10 });
            Function.Call(Hash._0xB80D8756B4668AB6, new InputArgument[] { root });
            Function.Call(Hash._0x6C38AF3693A69A91, new InputArgument[] { root });
            Function.Call(Hash._0x0D53A3B8DA0809D2, new InputArgument[] { effect, Game.Player.Character.CurrentVehicle.Handle, 0.0, 3.0, 0.5, 0.0, 0.0, 0.0, 3.0, 0, 0, 0 });
        }
        static void make_effect(string root, string effect, Vector3 pos, Vector3 rot, float scale, bool axisX, bool axisY, bool axisZ)
        {
            Function.Call(Hash._0xDD19FA1C6D657305, new InputArgument[] { de.Position.X, de.Position.Y, de.Position.Z, 10 });
            Function.Call(Hash._0xB80D8756B4668AB6, new InputArgument[] { root });
            Function.Call(Hash._0x6C38AF3693A69A91, new InputArgument[] { root });
            Function.Call(Hash._0x0D53A3B8DA0809D2, new InputArgument[] { effect, Game.Player.Character.CurrentVehicle.Handle, pos.X, pos.Y, pos.Z, rot.X, rot.Y, rot.Z, scale, axisX, axisY, axisZ });
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
                prop.Add(World.CreateProp(model, de.GetOffsetInWorldCoords(new Vector3((float)x, (float)y, (float)-1.3)), true, false));
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
                prop2.Add(World.CreateProp(model, de.GetOffsetInWorldCoords(new Vector3((float)x, (float)y, (float)-1.3)), true, false));
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
        static string img = "";
        static string image = Application.StartupPath + "\\scripts\\images";
        static Vector3 trainstandingpos = new Vector3(0.85f,4,0.8f);
        public static void tick(int mph)
        {
            try
            {
                if (istrainpresent)
                {
                    try
                    {
                        img = "\\setto88.png";
                        if (File.Exists(image + img))
                        {
                            Sprite.DrawTexture(image + img, new Point(TimeCircuits.loc.X, TimeCircuits.loc.Y - 60), new Size(191, 62));
                        }
                        else
                        {

                        }
                        int tempspeed = 0;
                        try
                        {
                            tempspeed = (int)((de.Speed / .27777) / 1.60934);
                        }
                        catch
                        {

                        }

                        if (tempspeed >= 88)
                        {
                            tempspeed = 88;
                        }
                        /*if (tempspeed != speed)
                        {
                            speedp.Stop();
                            speedp.Play();
                            speed = tempspeed;
                        }*/
                        string speed1 = "" + tempspeed / 10;
                        string speed2 = "" + tempspeed % 10;
                        img = "\\speed\\1\\" + speed1 + ".jpg";
                        de.SetMod(VehicleMod.SteeringWheels, (tempspeed % 10), true);
                        if (File.Exists(image + img))
                        {
                            if (speed1 != "0")
                                Sprite.DrawTexture(image + img, new Point(TimeCircuits.loc.X + 45, TimeCircuits.loc.Y - 44), new Size(27, 35));
                        }
                        else
                        {

                        }
                        img = "\\speed\\2\\" + speed2 + ".jpg";
                        de.SetMod(VehicleMod.DialDesign, (tempspeed / 10) - 1, true);
                        if (File.Exists(image + img))
                        {
                            Sprite.DrawTexture(image + img, new Point(TimeCircuits.loc.X + 75, TimeCircuits.loc.Y - 44), new Size(27, 35));
                        }
                        else
                        {

                        }
                    }
                    catch
                    {

                    }
                    if (de.HeightAboveGround < 0.8)
                    {
                        de.Heading = train.Heading;
                        de.ApplyForceRelative(new Vector3(0, 0, -(de.HeightAboveGround) + 2));
                        if (Math.Round(de.GetOffsetFromWorldCoords(train.Position).X, 1) < 0)
                            de.Heading = train.Heading + -((float)Math.Round(de.GetOffsetFromWorldCoords(train.Position).X, 1) - 0.7f);
                        if (Math.Round(de.GetOffsetFromWorldCoords(train.Position).X, 1) > 0)
                            de.Heading = train.Heading - ((float)Math.Round(de.GetOffsetFromWorldCoords(train.Position).X, 1) + 0.7f);
                        if (Math.Round(de.GetOffsetFromWorldCoords(train.Position).X, 1) > 0.2)
                        {
                            de.Position = docstrain.GetOffsetInWorldCoords(new Vector3(0, 11.5f, 1));
                        }
                        if (Math.Round(de.GetOffsetFromWorldCoords(train.Position).X, 1) < -0.2)
                        {
                            de.Position = docstrain.GetOffsetInWorldCoords(new Vector3(0, 11.5f, 1));
                        }

                        UI.ShowSubtitle("Train away from docs train: " + Math.Round(train.GetOffsetFromWorldCoords(docstrain.Position).Y, 1));
                        if (docstrain.Speed < 2)
                        {
                            if ((int)((train.Speed / .27777) / 1.60934) < mph)
                            {
                                train.Speed += 0.1f;
                                if (Math.Round(train.GetOffsetFromWorldCoords(docstrain.Position).Y, 1) < -11.6)
                                {
                                    docstrain.Speed = train.Speed - 1;
                                }
                                else
                                    docstrain.Speed = train.Speed + 1;
                            }
                            else
                            {
                                train.Speed -= 0.1f;
                                if (Math.Round(train.GetOffsetFromWorldCoords(docstrain.Position).Y, 1) < -11.6)
                                {
                                    docstrain.Speed = train.Speed - 1;
                                }
                                else
                                    docstrain.Speed = train.Speed + 1;
                            }
                            de.Rotation = train.Rotation;
                            if (Math.Round(de.GetOffsetFromWorldCoords(docstrain.Position).Y, 1) < -11.6)
                            {
                                de.Speed = docstrain.Speed + 2;            
                            }
                            else
                                de.Speed = docstrain.Speed;
                        }
                        else
                        {
                            if ((int)((train.Speed / .27777) / 1.60934) < mph)
                            {
                                train.Speed += 0.1f;
                                if (Math.Round(train.GetOffsetFromWorldCoords(docstrain.Position).Y, 1) < -11.6)
                                {
                                    docstrain.Speed = train.Speed - 0.1f;
                                }
                                else
                                    docstrain.Speed = train.Speed + 0.1f;
                            }
                            else
                            {
                                train.Speed -= 0.1f;
                                if (Math.Round(train.GetOffsetFromWorldCoords(docstrain.Position).Y, 1) < -11.6)
                                {
                                    docstrain.Speed = train.Speed + 0.1f;
                                }
                                else
                                    docstrain.Speed = train.Speed - 0.1f;
                            }
                            if (Math.Round(de.GetOffsetFromWorldCoords(docstrain.Position).Y, 1) < -11.6)
                            {
                                de.Speed = docstrain.Speed + 2;
                            }
                            else
                                de.Speed = docstrain.Speed;
                        }
                    }
                    else
                        de.Position = docstrain.GetOffsetInWorldCoords(new Vector3(0, 11.5f, 1));
                }
                else
                {
                    try
                    {
                        if (Game.Player.Character.IsInVehicle())
                        {
                            if (Game.Player.Character.CurrentVehicle.Model == new Model("BTTF3rr"))
                            {
                                foreach (Vehicle i in World.GetNearbyVehicles(Game.Player.Character, 1000))
                                {
                                    if (i.Model.IsTrain)
                                        if (i.Model == new Model(VehicleHash.Freight))
                                        {
                                            World.DrawMarker(MarkerType.VerticalCylinder, i.GetOffsetInWorldCoords(new Vector3(0, 12f, -1)), i.Position, i.Rotation, new Vector3(10, 10, 10), Color.Tomato);
                                            i.Speed = 20;
                                            if (Game.Player.Character.IsInRangeOf(i.GetOffsetInWorldCoords(new Vector3(0, 12f, -1)), 10))
                                                Startscene();
                                        }
                                }
                            }
                        }
                    }
                    catch (Exception g)
                    {
                        UI.ShowSubtitle("Error: " + g.Message);
                    }
                }
            }
            catch
            {

            }
        }

    }
}

using GTA;
using GTA.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTTF_TimeTravel_0._9._0
{
    public class OffsetProp : Entity
    {
        private Prop prop;
        public Vector3 Offset { get; set; }
        public int index { get; set; }

        public OffsetProp(Prop prop, Vector3 offset, int index) : base(prop.Handle)
        {
            this.prop = prop;
            this.Offset = offset;
            this.index = index;
        }
    }

    class PropManager
    {
        Dictionary<string, Prop> TCD = new Dictionary<string, Prop>();
        private List<OffsetProp> flashProps = new List<OffsetProp>();
        private List<OffsetProp> wormholeProps = new List<OffsetProp>();
        private List<OffsetProp> sparkProps = new List<OffsetProp>();

        private Prop coilsProp;

        private Prop licenseplate;

        public Prop ice;

        private int currentFrame = 1;
        private int nextAnimate;

        private bool doneLoading;

        private int delay = 50;

        private int nextPositionAnimate;

        public bool traveling { get; set; }

        public void SpawnProp(Vehicle dmc12, string propName, string dummy, Vector3 pos, Vector3 rot)
        {
            var model = new Model(propName);
            model.Request(250);
            if (model.IsInCdImage && model.IsValid)
            {
                while (!model.IsLoaded) Script.Wait(50);

                var boneOffset = dmc12.GetOffsetFromWorldCoords(dmc12.GetBoneCoord(dummy));

                var prop = World.CreateProp(propName, dmc12.GetOffsetInWorldCoords(boneOffset), false, false);

                if (dummy.Equals("licenseplate"))
                {
                    licenseplate = prop;
                    prop.AttachTo(dmc12, 0, boneOffset, rot);
                }

                if (propName.Equals("bttf_icebody"))
                {
                    ice = prop;
                    ice.Alpha = 0;
                    prop.AttachTo(dmc12, 0, Vector3.Zero, rot);
                }
            }
            else
            {
                UI.Notify(" Does not exist");
            }

            //if (Game.Player.Character.IsInVehicle())
            //{
            //    var model = new Model(propName);
            //    model.Request(250);

            //    // Check the model is valid
            //    if (model.IsInCdImage && model.IsValid)
            //    {
            //        // Ensure the model is loaded before we try to create it in the world
            //        while (!model.IsLoaded) Script.Wait(50);

            //        // Create the prop in the world
            //        Prop temp = World.CreateProp(model, Game.Player.Character.GetOffsetInWorldCoords(new GTA.Math.Vector3(0, 5, 0)), true, true);


            //        float x = 0;
            //        float y = 0;
            //        float z = 0;
            //        float rx = 0;
            //        float ry = 0;
            //        float rz = 0;
            //        while (true)
            //        {
            //            try
            //            {
            //                UI.Notify("Key: " + Keys.KeyCode.ToString());

            //                UI.Notify("Key up");
            //                if (Game.IsKeyPressed(Keys.Up))
            //                {
            //                    z += 0.01f;
            //                }
            //                UI.Notify("Key down");
            //                if (Game.IsKeyPressed(Keys.Down))
            //                {
            //                    z -= 0.01f;
            //                }

            //                if (Game.IsKeyPressed(Keys.I))
            //                {
            //                    rx += 0.01f;
            //                }
            //                if (Game.IsKeyPressed(Keys.O))
            //                {
            //                    rx -= 0.01f;
            //                }

            //                if (Game.IsKeyPressed(Keys.PageUp))
            //                {
            //                    ry += 0.01f;
            //                }
            //                if (Game.IsKeyPressed(Keys.PageDown))
            //                {
            //                    ry -= 0.01f;
            //                }


            //                UI.Notify("Key not shift");
            //                if (!Game.IsKeyPressed(Keys.ShiftKey))
            //                {
            //                    if (Game.IsKeyPressed(Keys.PageUp))
            //                    {
            //                        rz += 0.01f;
            //                    }
            //                    if (Game.IsKeyPressed(Keys.PageDown))
            //                    {
            //                        rz -= 0.01f;
            //                    }


            //                    UI.Notify("Key left");
            //                    if (Game.IsKeyPressed(Keys.Left))
            //                    {
            //                        y += 0.01f;
            //                    }
            //                    UI.Notify("Key right");
            //                    if (Game.IsKeyPressed(Keys.Right))
            //                    {
            //                        y -= 0.01f;
            //                    }
            //                }
            //                else
            //                {
            //                    UI.Notify("Key shift and left");
            //                    if (Game.IsKeyPressed(Keys.Left))
            //                    {
            //                        x += 0.01f;
            //                    }
            //                    UI.Notify("Key shift and right");
            //                    if (Game.IsKeyPressed(Keys.Right))
            //                    {
            //                        x -= 0.01f;
            //                    }
            //                }
            //            }
            //            catch
            //            {

            //            }
            //            UI.Notify("Key space");
            //            if (Game.IsKeyPressed(Keys.Space))
            //            {
            //                break;
            //            }
            //            UI.Notify("Keys");
            //            temp.AttachTo(dmc12, 0, new GTA.Math.Vector3(x, y, z), new GTA.Math.Vector3(rx, ry, rz));
            //            UI.Notify("door");
            //            Wait(10);
            //        }
            //    }
            //    else
            //    {
            //        UI.Notify(" Does not exist");
            //    }

            //    // Mark the model as no longer needed to remove it from memory.
            //    model.MarkAsNoLongerNeeded();
            //}
        }

        public void loadWormhole(Vehicle dmc12)
        {
            UI.Notify("Loading props...");
            
            for (int i = 1; i < 76; i++)
            {
                UI.Notify("Loading props... %" + ((i / 76f) * 100));
                var wormholeString = "wormhole_frame" + i.ToString();
                var sparkString = "spark_frame" + i.ToString();
                var flashString = "flash_frame" + i.ToString();

                var wormholeModel = new Model("wormhole_frame" + i.ToString());
                var sparkModel = new Model("spark_frame" + i.ToString());
                var flashModel = new Model("flash_frame" + i.ToString());

                if (wormholeModel.IsValid)
                {
                    while (!wormholeModel.IsLoaded)
                    {
                        wormholeModel.Request(50);
                        Script.Wait(10);
                    }

                    var boneOffset = Game.Player.Character.CurrentVehicle.GetOffsetFromWorldCoords(Game.Player.Character.CurrentVehicle.GetBoneCoord("wormhole"));

                    var prop = World.CreateProp(wormholeModel, Game.Player.Character.CurrentVehicle.GetOffsetInWorldCoords(boneOffset), false, false);
                    prop.Rotation = Game.Player.Character.CurrentVehicle.Rotation;
                    prop.IsVisible = false;
                    //prop.AttachTo(Game.Player.Character.CurrentVehicle, 0, new Vector3(-0.03936548f, 2.538605f, 0.7339981f), Vector3.Zero);
                    wormholeProps.Add(new OffsetProp(prop, boneOffset, i));
                }

                if (flashModel.IsValid)
                {
                    while (!flashModel.IsLoaded)
                    {
                        flashModel.Request(50);
                        Script.Wait(10);
                    }

                    var boneOffset = Game.Player.Character.CurrentVehicle.GetOffsetFromWorldCoords(Game.Player.Character.CurrentVehicle.GetBoneCoord(flashString));

                    UI.ShowSubtitle(boneOffset.ToString());

                    var prop = World.CreateProp(flashModel, Game.Player.Character.CurrentVehicle.GetOffsetInWorldCoords(boneOffset), false, false);
                    prop.IsVisible = false;
                    flashProps.Add(new OffsetProp(prop, boneOffset, i));
                }

                if (sparkModel.IsValid)
                {
                    while (!sparkModel.IsLoaded)
                    {
                        sparkModel.Request(50);
                        Script.Wait(10);
                    }

                    var prop = World.CreateProp(sparkModel, Game.Player.Character.CurrentVehicle.Position, false, false);
                    prop.IsVisible = false;
                    prop.AttachTo(Game.Player.Character.CurrentVehicle, 0, new Vector3(0, 0, 0), Vector3.Zero);
                    sparkProps.Add(new OffsetProp(prop, new Vector3(0, 0, 0), i));
                }
            }

            var newModel = new Model("bttf_coils_glowing");
            newModel.Request(50);

            while (!newModel.IsLoaded)
            {
                newModel.Request(50);
                Script.Wait(10);
            }

            coilsProp = World.CreateProp(newModel, Vector3.Zero, false, false);

            coilsProp.AttachTo(Game.Player.Character.CurrentVehicle, 0, Vector3.Zero, Vector3.Zero);

            coilsProp.IsVisible = false;

            doneLoading = true;
        }

        //handle coordenites
        //X -0.03805999 Y -0.0819466 Z 0.5508024 

        void propControl(List<OffsetProp> prop, int index, bool canAnim, bool sparkProp)
        {
            try
            {
                if (!sparkProp)
                {
                    prop[index].Rotation = new Vector3(0, 0, (prop[index].Position - GameplayCamera.Position).ToHeading() + 180f);

                    if (Game.GameTime > nextPositionAnimate)
                        prop[index].Position = Game.Player.Character.CurrentVehicle.GetOffsetInWorldCoords(prop[index].Offset);
                }

                if (canAnim)
                {
                    if (currentFrame == prop[index].index)
                        prop[index].IsVisible = true;
                    else
                        prop[index].IsVisible = false;
                }
            }
            catch
            {

            }
        }

        public void wormholeTick(Vehicle dmc12)
        {
            if (doneLoading)
            {
                if (traveling)
                {
                    coilsProp.IsVisible = true;

                    if (currentFrame > 60)
                        currentFrame = 1;

                    var currentIndex = currentFrame - 1;

                    var canAnimate = Game.GameTime > nextAnimate;

                    #region sparkProps
                    propControl(sparkProps, 0, canAnimate, true);
                    propControl(sparkProps, 1, canAnimate, true);
                    propControl(sparkProps, 2, canAnimate, true);
                    propControl(sparkProps, 3, canAnimate, true);
                    propControl(sparkProps, 4, canAnimate, true);
                    propControl(sparkProps, 5, canAnimate, true);
                    propControl(sparkProps, 6, canAnimate, true);
                    propControl(sparkProps, 7, canAnimate, true);
                    propControl(sparkProps, 8, canAnimate, true);
                    propControl(sparkProps, 9, canAnimate, true);
                    propControl(sparkProps, 10, canAnimate, true);
                    propControl(sparkProps, 11, canAnimate, true);
                    propControl(sparkProps, 12, canAnimate, true);
                    propControl(sparkProps, 13, canAnimate, true);
                    propControl(sparkProps, 14, canAnimate, true);
                    propControl(sparkProps, 15, canAnimate, true);
                    propControl(sparkProps, 16, canAnimate, true);
                    propControl(sparkProps, 17, canAnimate, true);
                    propControl(sparkProps, 18, canAnimate, true);
                    propControl(sparkProps, 19, canAnimate, true);
                    propControl(sparkProps, 20, canAnimate, true);
                    propControl(sparkProps, 21, canAnimate, true);
                    propControl(sparkProps, 22, canAnimate, true);
                    propControl(sparkProps, 23, canAnimate, true);
                    propControl(sparkProps, 24, canAnimate, true);
                    propControl(sparkProps, 25, canAnimate, true);
                    propControl(sparkProps, 26, canAnimate, true);
                    propControl(sparkProps, 27, canAnimate, true);
                    propControl(sparkProps, 28, canAnimate, true);
                    propControl(sparkProps, 29, canAnimate, true);
                    propControl(sparkProps, 30, canAnimate, true);
                    propControl(sparkProps, 31, canAnimate, true);
                    propControl(sparkProps, 32, canAnimate, true);
                    propControl(sparkProps, 33, canAnimate, true);
                    propControl(sparkProps, 34, canAnimate, true);
                    propControl(sparkProps, 35, canAnimate, true);
                    propControl(sparkProps, 36, canAnimate, true);
                    propControl(sparkProps, 37, canAnimate, true);
                    propControl(sparkProps, 38, canAnimate, true);
                    propControl(sparkProps, 39, canAnimate, true);
                    propControl(sparkProps, 40, canAnimate, true);
                    propControl(sparkProps, 41, canAnimate, true);
                    propControl(sparkProps, 42, canAnimate, true);
                    propControl(sparkProps, 43, canAnimate, true);
                    propControl(sparkProps, 44, canAnimate, true);
                    propControl(sparkProps, 45, canAnimate, true);
                    propControl(sparkProps, 46, canAnimate, true);
                    propControl(sparkProps, 47, canAnimate, true);
                    propControl(sparkProps, 48, canAnimate, true);
                    propControl(sparkProps, 49, canAnimate, true);
                    propControl(sparkProps, 50, canAnimate, true);
                    propControl(sparkProps, 51, canAnimate, true);
                    propControl(sparkProps, 52, canAnimate, true);
                    propControl(sparkProps, 53, canAnimate, true);
                    propControl(sparkProps, 54, canAnimate, true);
                    propControl(sparkProps, 55, canAnimate, true);
                    propControl(sparkProps, 56, canAnimate, true);
                    propControl(sparkProps, 57, canAnimate, true);
                    propControl(sparkProps, 58, canAnimate, true);
                    propControl(sparkProps, 59, canAnimate, true);
                    propControl(sparkProps, 60, canAnimate, true);
                    propControl(sparkProps, 61, canAnimate, true);
                    propControl(sparkProps, 62, canAnimate, true);
                    propControl(sparkProps, 63, canAnimate, true);
                    propControl(sparkProps, 64, canAnimate, true);
                    propControl(sparkProps, 65, canAnimate, true);
                    propControl(sparkProps, 66, canAnimate, true);
                    propControl(sparkProps, 67, canAnimate, true);
                    propControl(sparkProps, 68, canAnimate, true);
                    propControl(sparkProps, 69, canAnimate, true);
                    propControl(sparkProps, 70, canAnimate, true);
                    propControl(sparkProps, 71, canAnimate, true);
                    propControl(sparkProps, 72, canAnimate, true);
                    propControl(sparkProps, 73, canAnimate, true);
                    propControl(sparkProps, 74, canAnimate, true);
                    #endregion

                    #region wormholeProps
                    propControl(wormholeProps, 0, canAnimate, false);
                    propControl(wormholeProps, 1, canAnimate, false);
                    propControl(wormholeProps, 2, canAnimate, false);
                    propControl(wormholeProps, 3, canAnimate, false);
                    propControl(wormholeProps, 4, canAnimate, false);
                    propControl(wormholeProps, 5, canAnimate, false);
                    propControl(wormholeProps, 6, canAnimate, false);
                    propControl(wormholeProps, 7, canAnimate, false);
                    propControl(wormholeProps, 8, canAnimate, false);
                    propControl(wormholeProps, 9, canAnimate, false);
                    propControl(wormholeProps, 10, canAnimate, false);
                    propControl(wormholeProps, 11, canAnimate, false);
                    propControl(wormholeProps, 12, canAnimate, false);
                    propControl(wormholeProps, 13, canAnimate, false);
                    propControl(wormholeProps, 14, canAnimate, false);
                    propControl(wormholeProps, 15, canAnimate, false);
                    propControl(wormholeProps, 16, canAnimate, false);
                    propControl(wormholeProps, 17, canAnimate, false);
                    propControl(wormholeProps, 18, canAnimate, false);
                    propControl(wormholeProps, 19, canAnimate, false);
                    propControl(wormholeProps, 20, canAnimate, false);
                    propControl(wormholeProps, 21, canAnimate, false);
                    propControl(wormholeProps, 22, canAnimate, false);
                    propControl(wormholeProps, 23, canAnimate, false);
                    propControl(wormholeProps, 24, canAnimate, false);
                    propControl(wormholeProps, 25, canAnimate, false);
                    propControl(wormholeProps, 26, canAnimate, false);
                    propControl(wormholeProps, 27, canAnimate, false);
                    propControl(wormholeProps, 28, canAnimate, false);
                    propControl(wormholeProps, 29, canAnimate, false);
                    propControl(wormholeProps, 30, canAnimate, false);
                    propControl(wormholeProps, 31, canAnimate, false);
                    propControl(wormholeProps, 32, canAnimate, false);
                    propControl(wormholeProps, 33, canAnimate, false);
                    propControl(wormholeProps, 34, canAnimate, false);
                    propControl(wormholeProps, 35, canAnimate, false);
                    propControl(wormholeProps, 36, canAnimate, false);
                    propControl(wormholeProps, 37, canAnimate, false);
                    propControl(wormholeProps, 38, canAnimate, false);
                    propControl(wormholeProps, 39, canAnimate, false);
                    propControl(wormholeProps, 40, canAnimate, false);
                    propControl(wormholeProps, 41, canAnimate, false);
                    propControl(wormholeProps, 42, canAnimate, false);
                    propControl(wormholeProps, 43, canAnimate, false);
                    propControl(wormholeProps, 44, canAnimate, false);
                    propControl(wormholeProps, 45, canAnimate, false);
                    propControl(wormholeProps, 46, canAnimate, false);
                    propControl(wormholeProps, 47, canAnimate, false);
                    propControl(wormholeProps, 48, canAnimate, false);
                    propControl(wormholeProps, 49, canAnimate, false);
                    propControl(wormholeProps, 50, canAnimate, false);
                    propControl(wormholeProps, 51, canAnimate, false);
                    propControl(wormholeProps, 52, canAnimate, false);
                    propControl(wormholeProps, 53, canAnimate, false);
                    propControl(wormholeProps, 54, canAnimate, false);
                    propControl(wormholeProps, 55, canAnimate, false);
                    propControl(wormholeProps, 56, canAnimate, false);
                    propControl(wormholeProps, 57, canAnimate, false);
                    propControl(wormholeProps, 58, canAnimate, false);
                    propControl(wormholeProps, 59, canAnimate, false);
                    propControl(wormholeProps, 60, canAnimate, false);
                    propControl(wormholeProps, 61, canAnimate, false);
                    propControl(wormholeProps, 62, canAnimate, false);
                    propControl(wormholeProps, 63, canAnimate, false);
                    propControl(wormholeProps, 64, canAnimate, false);
                    propControl(wormholeProps, 65, canAnimate, false);
                    propControl(wormholeProps, 66, canAnimate, false);
                    propControl(wormholeProps, 67, canAnimate, false);
                    propControl(wormholeProps, 68, canAnimate, false);
                    propControl(wormholeProps, 69, canAnimate, false);
                    propControl(wormholeProps, 70, canAnimate, false);
                    propControl(wormholeProps, 71, canAnimate, false);
                    propControl(wormholeProps, 72, canAnimate, false);
                    propControl(wormholeProps, 73, canAnimate, false);
                    propControl(wormholeProps, 74, canAnimate, false);
                    #endregion

                    #region flashProps
                    propControl(flashProps, 0, canAnimate, false);
                    propControl(flashProps, 1, canAnimate, false);
                    propControl(flashProps, 2, canAnimate, false);
                    propControl(flashProps, 3, canAnimate, false);
                    propControl(flashProps, 4, canAnimate, false);
                    propControl(flashProps, 5, canAnimate, false);
                    propControl(flashProps, 6, canAnimate, false);
                    propControl(flashProps, 7, canAnimate, false);
                    propControl(flashProps, 8, canAnimate, false);
                    propControl(flashProps, 9, canAnimate, false);
                    propControl(flashProps, 10, canAnimate, false);
                    propControl(flashProps, 11, canAnimate, false);
                    propControl(flashProps, 12, canAnimate, false);
                    propControl(flashProps, 13, canAnimate, false);
                    propControl(flashProps, 14, canAnimate, false);
                    propControl(flashProps, 15, canAnimate, false);
                    propControl(flashProps, 16, canAnimate, false);
                    propControl(flashProps, 17, canAnimate, false);
                    propControl(flashProps, 18, canAnimate, false);
                    propControl(flashProps, 19, canAnimate, false);
                    propControl(flashProps, 20, canAnimate, false);
                    propControl(flashProps, 21, canAnimate, false);
                    propControl(flashProps, 22, canAnimate, false);
                    propControl(flashProps, 23, canAnimate, false);
                    propControl(flashProps, 24, canAnimate, false);
                    propControl(flashProps, 25, canAnimate, false);
                    propControl(flashProps, 26, canAnimate, false);
                    propControl(flashProps, 27, canAnimate, false);
                    propControl(flashProps, 28, canAnimate, false);
                    propControl(flashProps, 29, canAnimate, false);
                    propControl(flashProps, 30, canAnimate, false);
                    propControl(flashProps, 31, canAnimate, false);
                    propControl(flashProps, 32, canAnimate, false);
                    propControl(flashProps, 33, canAnimate, false);
                    propControl(flashProps, 34, canAnimate, false);
                    propControl(flashProps, 35, canAnimate, false);
                    propControl(flashProps, 36, canAnimate, false);
                    propControl(flashProps, 37, canAnimate, false);
                    #endregion

                    if (canAnimate)
                    {
                        nextAnimate = Game.GameTime + delay;
                        nextPositionAnimate = Game.GameTime + 10;
                        currentFrame++;
                    } 
                }
                else
                {
                    coilsProp.IsVisible = false;
                    currentFrame = 0;


                    #region sparkProps
                    propControl(sparkProps, 0, true, true);
                    propControl(sparkProps, 1, true, true);
                    propControl(sparkProps, 2, true, true);
                    propControl(sparkProps, 3, true, true);
                    propControl(sparkProps, 4, true, true);
                    propControl(sparkProps, 5, true, true);
                    propControl(sparkProps, 6, true, true);
                    propControl(sparkProps, 7, true, true);
                    propControl(sparkProps, 8, true, true);
                    propControl(sparkProps, 9, true, true);
                    propControl(sparkProps, 10, true, true);
                    propControl(sparkProps, 11, true, true);
                    propControl(sparkProps, 12, true, true);
                    propControl(sparkProps, 13, true, true);
                    propControl(sparkProps, 14, true, true);
                    propControl(sparkProps, 15, true, true);
                    propControl(sparkProps, 16, true, true);
                    propControl(sparkProps, 17, true, true);
                    propControl(sparkProps, 18, true, true);
                    propControl(sparkProps, 19, true, true);
                    propControl(sparkProps, 20, true, true);
                    propControl(sparkProps, 21, true, true);
                    propControl(sparkProps, 22, true, true);
                    propControl(sparkProps, 23, true, true);
                    propControl(sparkProps, 24, true, true);
                    propControl(sparkProps, 25, true, true);
                    propControl(sparkProps, 26, true, true);
                    propControl(sparkProps, 27, true, true);
                    propControl(sparkProps, 28, true, true);
                    propControl(sparkProps, 29, true, true);
                    propControl(sparkProps, 30, true, true);
                    propControl(sparkProps, 31, true, true);
                    propControl(sparkProps, 32, true, true);
                    propControl(sparkProps, 33, true, true);
                    propControl(sparkProps, 34, true, true);
                    propControl(sparkProps, 35, true, true);
                    propControl(sparkProps, 36, true, true);
                    propControl(sparkProps, 37, true, true);
                    propControl(sparkProps, 38, true, true);
                    propControl(sparkProps, 39, true, true);
                    propControl(sparkProps, 40, true, true);
                    propControl(sparkProps, 41, true, true);
                    propControl(sparkProps, 42, true, true);
                    propControl(sparkProps, 43, true, true);
                    propControl(sparkProps, 44, true, true);
                    propControl(sparkProps, 45, true, true);
                    propControl(sparkProps, 46, true, true);
                    propControl(sparkProps, 47, true, true);
                    propControl(sparkProps, 48, true, true);
                    propControl(sparkProps, 49, true, true);
                    propControl(sparkProps, 50, true, true);
                    propControl(sparkProps, 51, true, true);
                    propControl(sparkProps, 52, true, true);
                    propControl(sparkProps, 53, true, true);
                    propControl(sparkProps, 54, true, true);
                    propControl(sparkProps, 55, true, true);
                    propControl(sparkProps, 56, true, true);
                    propControl(sparkProps, 57, true, true);
                    propControl(sparkProps, 58, true, true);
                    propControl(sparkProps, 59, true, true);
                    propControl(sparkProps, 60, true, true);
                    propControl(sparkProps, 61, true, true);
                    propControl(sparkProps, 62, true, true);
                    propControl(sparkProps, 63, true, true);
                    propControl(sparkProps, 64, true, true);
                    propControl(sparkProps, 65, true, true);
                    propControl(sparkProps, 66, true, true);
                    propControl(sparkProps, 67, true, true);
                    propControl(sparkProps, 68, true, true);
                    propControl(sparkProps, 69, true, true);
                    propControl(sparkProps, 70, true, true);
                    propControl(sparkProps, 71, true, true);
                    propControl(sparkProps, 72, true, true);
                    propControl(sparkProps, 73, true, true);
                    propControl(sparkProps, 74, true, true);
                    #endregion

                    #region wormholeProps
                    propControl(wormholeProps, 0, true, false);
                    propControl(wormholeProps, 1, true, false);
                    propControl(wormholeProps, 2, true, false);
                    propControl(wormholeProps, 3, true, false);
                    propControl(wormholeProps, 4, true, false);
                    propControl(wormholeProps, 5, true, false);
                    propControl(wormholeProps, 6, true, false);
                    propControl(wormholeProps, 7, true, false);
                    propControl(wormholeProps, 8, true, false);
                    propControl(wormholeProps, 9, true, false);
                    propControl(wormholeProps, 10, true, false);
                    propControl(wormholeProps, 11, true, false);
                    propControl(wormholeProps, 12, true, false);
                    propControl(wormholeProps, 13, true, false);
                    propControl(wormholeProps, 14, true, false);
                    propControl(wormholeProps, 15, true, false);
                    propControl(wormholeProps, 16, true, false);
                    propControl(wormholeProps, 17, true, false);
                    propControl(wormholeProps, 18, true, false);
                    propControl(wormholeProps, 19, true, false);
                    propControl(wormholeProps, 20, true, false);
                    propControl(wormholeProps, 21, true, false);
                    propControl(wormholeProps, 22, true, false);
                    propControl(wormholeProps, 23, true, false);
                    propControl(wormholeProps, 24, true, false);
                    propControl(wormholeProps, 25, true, false);
                    propControl(wormholeProps, 26, true, false);
                    propControl(wormholeProps, 27, true, false);
                    propControl(wormholeProps, 28, true, false);
                    propControl(wormholeProps, 29, true, false);
                    propControl(wormholeProps, 30, true, false);
                    propControl(wormholeProps, 31, true, false);
                    propControl(wormholeProps, 32, true, false);
                    propControl(wormholeProps, 33, true, false);
                    propControl(wormholeProps, 34, true, false);
                    propControl(wormholeProps, 35, true, false);
                    propControl(wormholeProps, 36, true, false);
                    propControl(wormholeProps, 37, true, false);
                    propControl(wormholeProps, 38, true, false);
                    propControl(wormholeProps, 39, true, false);
                    propControl(wormholeProps, 40, true, false);
                    propControl(wormholeProps, 41, true, false);
                    propControl(wormholeProps, 42, true, false);
                    propControl(wormholeProps, 43, true, false);
                    propControl(wormholeProps, 44, true, false);
                    propControl(wormholeProps, 45, true, false);
                    propControl(wormholeProps, 46, true, false);
                    propControl(wormholeProps, 47, true, false);
                    propControl(wormholeProps, 48, true, false);
                    propControl(wormholeProps, 49, true, false);
                    propControl(wormholeProps, 50, true, false);
                    propControl(wormholeProps, 51, true, false);
                    propControl(wormholeProps, 52, true, false);
                    propControl(wormholeProps, 53, true, false);
                    propControl(wormholeProps, 54, true, false);
                    propControl(wormholeProps, 55, true, false);
                    propControl(wormholeProps, 56, true, false);
                    propControl(wormholeProps, 57, true, false);
                    propControl(wormholeProps, 58, true, false);
                    propControl(wormholeProps, 59, true, false);
                    propControl(wormholeProps, 60, true, false);
                    propControl(wormholeProps, 61, true, false);
                    propControl(wormholeProps, 62, true, false);
                    propControl(wormholeProps, 63, true, false);
                    propControl(wormholeProps, 64, true, false);
                    propControl(wormholeProps, 65, true, false);
                    propControl(wormholeProps, 66, true, false);
                    propControl(wormholeProps, 67, true, false);
                    propControl(wormholeProps, 68, true, false);
                    propControl(wormholeProps, 69, true, false);
                    propControl(wormholeProps, 70, true, false);
                    propControl(wormholeProps, 71, true, false);
                    propControl(wormholeProps, 72, true, false);
                    propControl(wormholeProps, 73, true, false);
                    propControl(wormholeProps, 74, true, false);
                    #endregion

                    #region flashProps
                    propControl(flashProps, 0, true, false);
                    propControl(flashProps, 1, true, false);
                    propControl(flashProps, 2, true, false);
                    propControl(flashProps, 3, true, false);
                    propControl(flashProps, 4, true, false);
                    propControl(flashProps, 5, true, false);
                    propControl(flashProps, 6, true, false);
                    propControl(flashProps, 7, true, false);
                    propControl(flashProps, 8, true, false);
                    propControl(flashProps, 9, true, false);
                    propControl(flashProps, 10, true, false);
                    propControl(flashProps, 11, true, false);
                    propControl(flashProps, 12, true, false);
                    propControl(flashProps, 13, true, false);
                    propControl(flashProps, 14, true, false);
                    propControl(flashProps, 15, true, false);
                    propControl(flashProps, 16, true, false);
                    propControl(flashProps, 17, true, false);
                    propControl(flashProps, 18, true, false);
                    propControl(flashProps, 19, true, false);
                    propControl(flashProps, 20, true, false);
                    propControl(flashProps, 21, true, false);
                    propControl(flashProps, 22, true, false);
                    propControl(flashProps, 23, true, false);
                    propControl(flashProps, 24, true, false);
                    propControl(flashProps, 25, true, false);
                    propControl(flashProps, 26, true, false);
                    propControl(flashProps, 27, true, false);
                    propControl(flashProps, 28, true, false);
                    propControl(flashProps, 29, true, false);
                    propControl(flashProps, 30, true, false);
                    propControl(flashProps, 31, true, false);
                    propControl(flashProps, 32, true, false);
                    propControl(flashProps, 33, true, false);
                    propControl(flashProps, 34, true, false);
                    propControl(flashProps, 35, true, false);
                    propControl(flashProps, 36, true, false);
                    propControl(flashProps, 37, true, false);
                    #endregion
                }
            }
        }

        public void wormholeHide(Vehicle dmc12)
        {
            if (doneLoading)
            {
                //coilsProp.IsVisible = false;
                //currentFrame = 1;

                //foreach (OffsetProp prop in flashProps)
                //{
                //    prop.IsVisible = false;
                //    Script.Wait(1);
                //}

                //foreach (OffsetProp prop in wormholeProps)
                //{
                //    prop.IsVisible = false;
                //    Script.Wait(1);
                //}

                //foreach (OffsetProp prop in sparkProps)
                //{
                //    prop.IsVisible = false;
                //    Script.Wait(1);
                //}

                coilsProp.IsVisible = false;
                currentFrame = 0;
                for (int i = 0; i < 10; i++)
                {

                    #region sparkProps
                    propControl(sparkProps, 0, true, true);
                    propControl(sparkProps, 1, true, true);
                    propControl(sparkProps, 2, true, true);
                    propControl(sparkProps, 3, true, true);
                    propControl(sparkProps, 4, true, true);
                    propControl(sparkProps, 5, true, true);
                    propControl(sparkProps, 6, true, true);
                    propControl(sparkProps, 7, true, true);
                    propControl(sparkProps, 8, true, true);
                    propControl(sparkProps, 9, true, true);
                    propControl(sparkProps, 10, true, true);
                    propControl(sparkProps, 11, true, true);
                    propControl(sparkProps, 12, true, true);
                    propControl(sparkProps, 13, true, true);
                    propControl(sparkProps, 14, true, true);
                    propControl(sparkProps, 15, true, true);
                    propControl(sparkProps, 16, true, true);
                    propControl(sparkProps, 17, true, true);
                    propControl(sparkProps, 18, true, true);
                    propControl(sparkProps, 19, true, true);
                    propControl(sparkProps, 20, true, true);
                    propControl(sparkProps, 21, true, true);
                    propControl(sparkProps, 22, true, true);
                    propControl(sparkProps, 23, true, true);
                    propControl(sparkProps, 24, true, true);
                    propControl(sparkProps, 25, true, true);
                    propControl(sparkProps, 26, true, true);
                    propControl(sparkProps, 27, true, true);
                    propControl(sparkProps, 28, true, true);
                    propControl(sparkProps, 29, true, true);
                    propControl(sparkProps, 30, true, true);
                    propControl(sparkProps, 31, true, true);
                    propControl(sparkProps, 32, true, true);
                    propControl(sparkProps, 33, true, true);
                    propControl(sparkProps, 34, true, true);
                    propControl(sparkProps, 35, true, true);
                    propControl(sparkProps, 36, true, true);
                    propControl(sparkProps, 37, true, true);
                    propControl(sparkProps, 38, true, true);
                    propControl(sparkProps, 39, true, true);
                    propControl(sparkProps, 40, true, true);
                    propControl(sparkProps, 41, true, true);
                    propControl(sparkProps, 42, true, true);
                    propControl(sparkProps, 43, true, true);
                    propControl(sparkProps, 44, true, true);
                    propControl(sparkProps, 45, true, true);
                    propControl(sparkProps, 46, true, true);
                    propControl(sparkProps, 47, true, true);
                    propControl(sparkProps, 48, true, true);
                    propControl(sparkProps, 49, true, true);
                    propControl(sparkProps, 50, true, true);
                    propControl(sparkProps, 51, true, true);
                    propControl(sparkProps, 52, true, true);
                    propControl(sparkProps, 53, true, true);
                    propControl(sparkProps, 54, true, true);
                    propControl(sparkProps, 55, true, true);
                    propControl(sparkProps, 56, true, true);
                    propControl(sparkProps, 57, true, true);
                    propControl(sparkProps, 58, true, true);
                    propControl(sparkProps, 59, true, true);
                    propControl(sparkProps, 60, true, true);
                    propControl(sparkProps, 61, true, true);
                    propControl(sparkProps, 62, true, true);
                    propControl(sparkProps, 63, true, true);
                    propControl(sparkProps, 64, true, true);
                    propControl(sparkProps, 65, true, true);
                    propControl(sparkProps, 66, true, true);
                    propControl(sparkProps, 67, true, true);
                    propControl(sparkProps, 68, true, true);
                    propControl(sparkProps, 69, true, true);
                    propControl(sparkProps, 70, true, true);
                    propControl(sparkProps, 71, true, true);
                    propControl(sparkProps, 72, true, true);
                    propControl(sparkProps, 73, true, true);
                    propControl(sparkProps, 74, true, true);
                    #endregion

                    #region wormholeProps
                    propControl(wormholeProps, 0, true, false);
                    propControl(wormholeProps, 1, true, false);
                    propControl(wormholeProps, 2, true, false);
                    propControl(wormholeProps, 3, true, false);
                    propControl(wormholeProps, 4, true, false);
                    propControl(wormholeProps, 5, true, false);
                    propControl(wormholeProps, 6, true, false);
                    propControl(wormholeProps, 7, true, false);
                    propControl(wormholeProps, 8, true, false);
                    propControl(wormholeProps, 9, true, false);
                    propControl(wormholeProps, 10, true, false);
                    propControl(wormholeProps, 11, true, false);
                    propControl(wormholeProps, 12, true, false);
                    propControl(wormholeProps, 13, true, false);
                    propControl(wormholeProps, 14, true, false);
                    propControl(wormholeProps, 15, true, false);
                    propControl(wormholeProps, 16, true, false);
                    propControl(wormholeProps, 17, true, false);
                    propControl(wormholeProps, 18, true, false);
                    propControl(wormholeProps, 19, true, false);
                    propControl(wormholeProps, 20, true, false);
                    propControl(wormholeProps, 21, true, false);
                    propControl(wormholeProps, 22, true, false);
                    propControl(wormholeProps, 23, true, false);
                    propControl(wormholeProps, 24, true, false);
                    propControl(wormholeProps, 25, true, false);
                    propControl(wormholeProps, 26, true, false);
                    propControl(wormholeProps, 27, true, false);
                    propControl(wormholeProps, 28, true, false);
                    propControl(wormholeProps, 29, true, false);
                    propControl(wormholeProps, 30, true, false);
                    propControl(wormholeProps, 31, true, false);
                    propControl(wormholeProps, 32, true, false);
                    propControl(wormholeProps, 33, true, false);
                    propControl(wormholeProps, 34, true, false);
                    propControl(wormholeProps, 35, true, false);
                    propControl(wormholeProps, 36, true, false);
                    propControl(wormholeProps, 37, true, false);
                    propControl(wormholeProps, 38, true, false);
                    propControl(wormholeProps, 39, true, false);
                    propControl(wormholeProps, 40, true, false);
                    propControl(wormholeProps, 41, true, false);
                    propControl(wormholeProps, 42, true, false);
                    propControl(wormholeProps, 43, true, false);
                    propControl(wormholeProps, 44, true, false);
                    propControl(wormholeProps, 45, true, false);
                    propControl(wormholeProps, 46, true, false);
                    propControl(wormholeProps, 47, true, false);
                    propControl(wormholeProps, 48, true, false);
                    propControl(wormholeProps, 49, true, false);
                    propControl(wormholeProps, 50, true, false);
                    propControl(wormholeProps, 51, true, false);
                    propControl(wormholeProps, 52, true, false);
                    propControl(wormholeProps, 53, true, false);
                    propControl(wormholeProps, 54, true, false);
                    propControl(wormholeProps, 55, true, false);
                    propControl(wormholeProps, 56, true, false);
                    propControl(wormholeProps, 57, true, false);
                    propControl(wormholeProps, 58, true, false);
                    propControl(wormholeProps, 59, true, false);
                    propControl(wormholeProps, 60, true, false);
                    propControl(wormholeProps, 61, true, false);
                    propControl(wormholeProps, 62, true, false);
                    propControl(wormholeProps, 63, true, false);
                    propControl(wormholeProps, 64, true, false);
                    propControl(wormholeProps, 65, true, false);
                    propControl(wormholeProps, 66, true, false);
                    propControl(wormholeProps, 67, true, false);
                    propControl(wormholeProps, 68, true, false);
                    propControl(wormholeProps, 69, true, false);
                    propControl(wormholeProps, 70, true, false);
                    propControl(wormholeProps, 71, true, false);
                    propControl(wormholeProps, 72, true, false);
                    propControl(wormholeProps, 73, true, false);
                    propControl(wormholeProps, 74, true, false);
                    #endregion

                    #region flashProps
                    propControl(flashProps, 0, true, false);
                    propControl(flashProps, 1, true, false);
                    propControl(flashProps, 2, true, false);
                    propControl(flashProps, 3, true, false);
                    propControl(flashProps, 4, true, false);
                    propControl(flashProps, 5, true, false);
                    propControl(flashProps, 6, true, false);
                    propControl(flashProps, 7, true, false);
                    propControl(flashProps, 8, true, false);
                    propControl(flashProps, 9, true, false);
                    propControl(flashProps, 10, true, false);
                    propControl(flashProps, 11, true, false);
                    propControl(flashProps, 12, true, false);
                    propControl(flashProps, 13, true, false);
                    propControl(flashProps, 14, true, false);
                    propControl(flashProps, 15, true, false);
                    propControl(flashProps, 16, true, false);
                    propControl(flashProps, 17, true, false);
                    propControl(flashProps, 18, true, false);
                    propControl(flashProps, 19, true, false);
                    propControl(flashProps, 20, true, false);
                    propControl(flashProps, 21, true, false);
                    propControl(flashProps, 22, true, false);
                    propControl(flashProps, 23, true, false);
                    propControl(flashProps, 24, true, false);
                    propControl(flashProps, 25, true, false);
                    propControl(flashProps, 26, true, false);
                    propControl(flashProps, 27, true, false);
                    propControl(flashProps, 28, true, false);
                    propControl(flashProps, 29, true, false);
                    propControl(flashProps, 30, true, false);
                    propControl(flashProps, 31, true, false);
                    propControl(flashProps, 32, true, false);
                    propControl(flashProps, 33, true, false);
                    propControl(flashProps, 34, true, false);
                    propControl(flashProps, 35, true, false);
                    propControl(flashProps, 36, true, false);
                    propControl(flashProps, 37, true, false);
                    #endregion

                    coilsProp.IsVisible = false; 
                }
            }
        }

        public void removeWormhole()
        {
            foreach (var prop in flashProps)
            {
                if (prop != null)
                    prop.Delete();
            }

            foreach (var prop in wormholeProps)
            {
                if (prop != null)
                    prop.Delete();
            }

            foreach (var prop in sparkProps)
            {
                if (prop != null)
                    prop.Delete();
            }

            coilsProp.Delete();
        }


    }
}

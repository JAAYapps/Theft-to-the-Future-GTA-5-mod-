using GTA;
using GTA.Native;
using NativeUI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TTTF_TimeTravel_0._9._0
{
    class displaysystem
    {
        #region empty system

        public static void runempty()
        {
            Sounds.empty.Play();
        }
        
        public static string emptystr = "\\EMPTY_OFF.png";
        public static void emptytick(Vehicle delorean, bool refilltimecurcuits, bool toggleTimeCircuits)
        {
            try
            {
                if (Sounds.empty.gettime() <= 300)
                {
                    Function.Call(Hash.SET_VEHICLE_MOD_KIT, delorean.Handle, 0);
                    delorean.SetMod(VehicleMod.Roof, -1, true);
                    emptystr = "\\EMPTY_OFF.png";
                }
                else if (Sounds.empty.gettime() <= 700)
                {
                    Function.Call(Hash.SET_VEHICLE_MOD_KIT, delorean.Handle, 0);
                    delorean.SetMod(VehicleMod.Roof, 0, true);
                    emptystr = "\\EMPTY_ON.png";
                }
                else if (Sounds.empty.gettime() <= 1000)
                {
                    Function.Call(Hash.SET_VEHICLE_MOD_KIT, delorean.Handle, 0);
                    delorean.SetMod(VehicleMod.Roof, -1, true);
                    emptystr = "\\EMPTY_OFF.png";
                }
                else if (Sounds.empty.gettime() <= 1500)
                {
                    if (!refilltimecurcuits)
                        //empty.Play();
                        Function.Call(Hash.SET_VEHICLE_MOD_KIT, delorean.Handle, 0);
                    delorean.SetMod(VehicleMod.Roof, 0, true);
                    emptystr = "\\EMPTY_ON.png";
                }
                else if (Sounds.empty.gettime() <= 1800)
                {
                    Function.Call(Hash.SET_VEHICLE_MOD_KIT, delorean.Handle, 0);
                    delorean.SetMod(VehicleMod.Roof, -1, true);
                    emptystr = "\\EMPTY_OFF.png";
                }
                else if (Sounds.empty.gettime() <= 2200)
                {
                    if (!refilltimecurcuits)
                        //empty.Play();
                        Function.Call(Hash.SET_VEHICLE_MOD_KIT, delorean.Handle, 0);
                    delorean.SetMod(VehicleMod.Roof, 0, true);
                    emptystr = "\\EMPTY_ON.png";
                }
                else if (Sounds.empty.gettime() <= 2700)
                {
                    Function.Call(Hash.SET_VEHICLE_MOD_KIT, delorean.Handle, 0);
                    delorean.SetMod(VehicleMod.Roof, -1, true);
                    emptystr = "\\EMPTY_OFF.png";
                }
                else if (Sounds.empty.gettime() <= 3000)
                {
                    if (!refilltimecurcuits)
                        //empty.Play();
                        Function.Call(Hash.SET_VEHICLE_MOD_KIT, delorean.Handle, 0);
                    delorean.SetMod(VehicleMod.Roof, 0, true);
                    emptystr = "\\EMPTY_ON.png";
                }
                else if (Sounds.empty.gettime() <= 3400)
                {
                    Function.Call(Hash.SET_VEHICLE_MOD_KIT, delorean.Handle, 0);
                    delorean.SetMod(VehicleMod.Roof, -1, true);
                    emptystr = "\\EMPTY_OFF.png";
                }
                else if (Sounds.empty.gettime() <= 3900)
                {
                    if (!refilltimecurcuits)
                        //empty.Play();
                        Function.Call(Hash.SET_VEHICLE_MOD_KIT, delorean.Handle, 0);
                    delorean.SetMod(VehicleMod.Roof, 0, true);
                    emptystr = "\\EMPTY_ON.png";
                }
                else if (Sounds.empty.gettime() <= 4200)
                {
                    Function.Call(Hash.SET_VEHICLE_MOD_KIT, delorean.Handle, 0);
                    delorean.SetMod(VehicleMod.Roof, -1, true);
                    emptystr = "\\EMPTY_OFF.png";
                }
                else if (Sounds.empty.gettime() <= 4700)
                {
                    if (!refilltimecurcuits)
                        //empty.Play();
                        Function.Call(Hash.SET_VEHICLE_MOD_KIT, delorean.Handle, 0);
                    delorean.SetMod(VehicleMod.Roof, 0, true);
                    emptystr = "\\EMPTY_ON.png";
                }
            }
            catch
            {

            }
        }
        #endregion

        public static bool Displayadjustment = false;

        public static string timedisplay(int month1, int month2, int day1, int day2, int y1, int y2, int y3, int y4, int h1, int h2, string ampm, int m1, int m2)
        {
            string fmonthname = "";
            if ((month1 * 10) + month2 == 1)
            {
                fmonthname = "JAN";
            }
            else if ((month1 * 10) + month2 == 2)
            {
                fmonthname = "FEB";
            }
            else if ((month1 * 10) + month2 == 3)
            {
                fmonthname = "MAR";
            }
            else if ((month1 * 10) + month2 == 4)
            {
                fmonthname = "APR";
            }
            else if ((month1 * 10) + month2 == 5)
            {
                fmonthname = "MAY";
            }
            else if ((month1 * 10) + month2 == 6)
            {
                fmonthname = "JUN";
            }
            else if ((month1 * 10) + month2 == 7)
            {
                fmonthname = "JUL";
            }
            else if ((month1 * 10) + month2 == 8)
            {
                fmonthname = "AUG";
            }
            else if ((month1 * 10) + month2 == 9)
            {
                fmonthname = "SEP";
            }
            else if ((month1 * 10) + month2 == 10)
            {
                fmonthname = "OCT";
            }
            else if ((month1 * 10) + month2 == 11)
            {
                fmonthname = "NOV";
            }
            else if ((month1 * 10) + month2 == 12)
            {
                fmonthname = "DEC";
            }

            return (fmonthname.PadLeft(5) + " " + (day1.ToString()
                + day2.ToString()).PadRight(3) + (y1.ToString() + y2.ToString() + y3.ToString()
                + y4.ToString()).PadLeft(5) + "   " + ((h1 == 0 && h2 == 0) ? "12" : ((h1).ToString() + (h2).ToString())
                + ":" + m1.ToString() + m2.ToString()).PadRight(6)) + ampm;
        }

        #region time circuits display
        public static bool beepsound = false;

        public static string image = Application.StartupPath + "\\scripts\\images";
        public static Point loc = new Point(Game.ScreenResolution.Width - 530, Game.ScreenResolution.Height - 370);
        //static int temptick = 0;
        static bool ticktock = false;
        static string img = "";

        enum time
        {
            Future,
            Present,
            Past
        }

        public static bool fpsdisplay = false;
        public static void DrawTexture(string path, int displayTime, Point position, Size size)
        {
            int fpsTimeScale = (int)(displayTime + (150 - (2 * Game.FPS)));
            if (fpsdisplay)
                UI.ShowSubtitle("FPS: " + Game.FPS + " refresh: " + fpsTimeScale);
            Size screenResolution = Game.ScreenResolution;
            int width = screenResolution.Width;
            int height = screenResolution.Height;
            float resRatio = 1080f * ((float)width / (float)height);
            float scaledWidth = (float)UI.WIDTH / resRatio;
            float ScaledHeight = (float)UI.HEIGHT / 1080f;
            Point point = new Point(0, 0);
            if (width == 1914 && height == 1052)
                point = new Point(15, 0);
            UI.DrawTexture(path, 1, 1, fpsTimeScale, new Point(Convert.ToInt32((float)position.X * scaledWidth) + point.X, Convert.ToInt32((float)position.Y * ScaledHeight) + point.Y), new PointF(0.0f, 0.0f), new Size(Convert.ToInt32((float)size.Width * scaledWidth), Convert.ToInt32((float)size.Height * ScaledHeight)), 0.0f, Color.White);
        }

        public static void change_time_display_location(int X, int Y)
        {
            loc = new Point(X, Y);
        }

        static string displaymonth(int month, time display)
        {
            switch (month)
            {
                case 1:
                    if (display == time.Future)
                    {
                        int num = 10;
                        return "\\red " + num + ".jpg";
                    }
                    else if (display == time.Present)
                    {
                        int num = 10;
                        return "\\green " + num + ".jpg";
                    }
                    else if (display == time.Past)
                    {
                        int num = 10;
                        return "\\amber " + num + ".jpg";
                    }
                    break;
                case 2:
                    if (display == time.Future)
                    {
                        int num = 11;
                        return "\\red " + num + ".jpg";
                    }
                    else if (display == time.Present)
                    {
                        int num = 11;
                        return "\\green " + num + ".jpg";
                    }
                    else if (display == time.Past)
                    {
                        int num = 11;
                        return "\\amber " + num + ".jpg";
                    }
                    break;
                case 3:
                    if (display == time.Future)
                    {
                        int num = 12;
                        return "\\red " + num + ".jpg";
                    }
                    else if (display == time.Present)
                    {
                        int num = 12;
                        return "\\green " + num + ".jpg";
                    }
                    else if (display == time.Past)
                    {
                        int num = 12;
                        return "\\amber " + num + ".jpg";
                    }
                    break;
                case 4:
                    if (display == time.Future)
                    {
                        int num = 13;
                        return "\\red " + num + ".jpg";
                    }
                    else if (display == time.Present)
                    {
                        int num = 13;
                        return "\\green " + num + ".jpg";
                    }
                    else if (display == time.Past)
                    {
                        int num = 13;
                        return "\\amber " + num + ".jpg";
                    }
                    break;
                case 5:
                    if (display == time.Future)
                    {
                        int num = 14;
                        return "\\red " + num + ".jpg";
                    }
                    else if (display == time.Present)
                    {
                        int num = 14;
                        return "\\green " + num + ".jpg";
                    }
                    else if (display == time.Past)
                    {
                        int num = 14;
                        return "\\amber " + num + ".jpg";
                    }
                    break;
                case 6:
                    if (display == time.Future)
                    {
                        int num = 15;
                        return "\\red " + num + ".jpg";
                    }
                    else if (display == time.Present)
                    {
                        int num = 15;
                        return "\\green " + num + ".jpg";
                    }
                    else if (display == time.Past)
                    {
                        int num = 15;
                        return "\\amber " + num + ".jpg";
                    }
                    break;
                case 7:
                    if (display == time.Future)
                    {
                        int num = 16;
                        return "\\red " + num + ".jpg";
                    }
                    else if (display == time.Present)
                    {
                        int num = 16;
                        return "\\green " + num + ".jpg";
                    }
                    else if (display == time.Past)
                    {
                        int num = 16;
                        return "\\amber " + num + ".jpg";
                    }
                    break;
                case 8:
                    if (display == time.Future)
                    {
                        int num = 17;
                        return "\\red " + num + ".jpg";
                    }
                    else if (display == time.Present)
                    {
                        int num = 17;
                        return "\\green " + num + ".jpg";
                    }
                    else if (display == time.Past)
                    {
                        int num = 17;
                        return "\\amber " + num + ".jpg";
                    }
                    break;
                case 9:
                    if (display == time.Future)
                    {
                        int num = 18;
                        return "\\red " + num + ".jpg";
                    }
                    else if (display == time.Present)
                    {
                        int num = 18;
                        return "\\green " + num + ".jpg";
                    }
                    else if (display == time.Past)
                    {
                        int num = 18;
                        return "\\amber " + num + ".jpg";
                    }
                    break;
                case 10:
                    if (display == time.Future)
                    {
                        int num = 19;
                        return "\\red " + num + ".jpg";
                    }
                    else if (display == time.Present)
                    {
                        int num = 19;
                        return "\\green " + num + ".jpg";
                    }
                    else if (display == time.Past)
                    {
                        int num = 19;
                        return "\\amber " + num + ".jpg";
                    }
                    break;
                case 11:
                    if (display == time.Future)
                    {
                        int num = 20;
                        return "\\red " + num + ".jpg";
                    }
                    else if (display == time.Present)
                    {
                        int num = 20;
                        return "\\green " + num + ".jpg";
                    }
                    else if (display == time.Past)
                    {
                        int num = 20;
                        return "\\amber " + num + ".jpg";
                    }
                    break;
                case 12:
                    if (display == time.Future)
                    {
                        int num = 21;
                        return "\\red " + num + ".jpg";
                    }
                    else if (display == time.Present)
                    {
                        int num = 21;
                        return "\\green " + num + ".jpg";
                    }
                    else if (display == time.Past)
                    {
                        int num = 21;
                        return "\\amber " + num + ".jpg";
                    }
                    break;
            }
            return "nothing";
        }

        static string displaymunber(int number1, time display)
        {
            switch (number1)
            {
                case 0:
                    if (display == time.Future)
                    {
                        int num = 0;
                        return "\\red " + num + ".jpg";
                    }
                    else if (display == time.Present)
                    {
                        int num = 0;
                        return "\\green " + num + ".jpg";
                    }
                    else if (display == time.Past)
                    {
                        int num = 0;
                        return "\\amber " + num + ".jpg";
                    }
                    break;
                case 1:
                    if (display == time.Future)
                    {
                        int num = 1;
                        return "\\red " + num + ".jpg";
                    }
                    else if (display == time.Present)
                    {
                        int num = 1;
                        return "\\green " + num + ".jpg";
                    }
                    else if (display == time.Past)
                    {
                        int num = 1;
                        return "\\amber " + num + ".jpg";
                    }
                    break;
                case 2:
                    if (display == time.Future)
                    {
                        int num = 2;
                        return "\\red " + num + ".jpg";
                    }
                    else if (display == time.Present)
                    {
                        int num = 2;
                        return "\\green " + num + ".jpg";
                    }
                    else if (display == time.Past)
                    {
                        int num = 2;
                        return "\\amber " + num + ".jpg";
                    }
                    break;
                case 3:
                    if (display == time.Future)
                    {
                        int num = 3;
                        return "\\red " + num + ".jpg";
                    }
                    else if (display == time.Present)
                    {
                        int num = 3;
                        return "\\green " + num + ".jpg";
                    }
                    else if (display == time.Past)
                    {
                        int num = 3;
                        return "\\amber " + num + ".jpg";
                    }
                    break;
                case 4:
                    if (display == time.Future)
                    {
                        int num = 4;
                        return "\\red " + num + ".jpg";
                    }
                    else if (display == time.Present)
                    {
                        int num = 4;
                        return "\\green " + num + ".jpg";
                    }
                    else if (display == time.Past)
                    {
                        int num = 4;
                        return "\\amber " + num + ".jpg";
                    }
                    break;
                case 5:
                    if (display == time.Future)
                    {
                        int num = 5;
                        return "\\red " + num + ".jpg";
                    }
                    else if (display == time.Present)
                    {
                        int num = 5;
                        return "\\green " + num + ".jpg";
                    }
                    else if (display == time.Past)
                    {
                        int num = 5;
                        return "\\amber " + num + ".jpg";
                    }
                    break;
                case 6:
                    if (display == time.Future)
                    {
                        int num = 6;
                        return "\\red " + num + ".jpg";
                    }
                    else if (display == time.Present)
                    {
                        int num = 6;
                        return "\\green " + num + ".jpg";
                    }
                    else if (display == time.Past)
                    {
                        int num = 6;
                        return "\\amber " + num + ".jpg";
                    }
                    break;
                case 7:
                    if (display == time.Future)
                    {
                        int num = 7;
                        return "\\red " + num + ".jpg";
                    }
                    else if (display == time.Present)
                    {
                        int num = 7;
                        return "\\green " + num + ".jpg";
                    }
                    else if (display == time.Past)
                    {
                        int num = 7;
                        return "\\amber " + num + ".jpg";
                    }
                    break;
                case 8:
                    if (display == time.Future)
                    {
                        int num = 8;
                        return "\\red " + num + ".jpg";
                    }
                    else if (display == time.Present)
                    {
                        int num = 8;
                        return "\\green " + num + ".jpg";
                    }
                    else if (display == time.Past)
                    {
                        int num = 8;
                        return "\\amber " + num + ".jpg";
                    }
                    break;
                case 9:
                    if (display == time.Future)
                    {
                        int num = 9;
                        return "\\red " + num + ".jpg";
                    }
                    else if (display == time.Present)
                    {
                        int num = 9;
                        return "\\green " + num + ".jpg";
                    }
                    else if (display == time.Past)
                    {
                        int num = 9;
                        return "\\amber " + num + ".jpg";
                    }
                    break;
            }
            return "nothing";
        }

        //int speed = 0;
        public static void display_background(Vehicle delorean, bool refilltimecurcuits, bool toggleTimeCircuits)
        {
            if (Displayadjustment)
            {
                UIText debug2 = new UIText("Display Adjustment. Use arrow keys to move display, and enter to Apply change.", new System.Drawing.Point(200, 100), (float)0.6);
                debug2.Draw();
            }

            if (refilltimecurcuits || !toggleTimeCircuits)
            {
                emptystr = "\\EMPTY_OFF.png";
            }

            img = "\\background.jpg";
            if (File.Exists(image + img))
            {
                DrawTexture(image + img, 60, loc, new Size(520, 360));
            }
            else
            {

            }
            img = "\\setto88.png";
            if (File.Exists(image + img))
            {
                DrawTexture(image + img, 60, new Point(loc.X, loc.Y - 60), new Size(191, 62));
            }
            else
            {

            }

            try
            {
                int tempspeed = 0;
                try
                {
                    tempspeed = (int)((Game.Player.Character.CurrentVehicle.Speed / .27777) / 1.60934);
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
                //UI.ShowSubtitle(tempspeed + " / " + tempspeed / 10 + " % " + tempspeed % 10);
                img = "\\speed\\1\\" + speed1 + ".jpg";
                if (File.Exists(image + img))
                {
                    if (speed1 != "0")
                        DrawTexture(image + img, 60, new Point(loc.X + 45, loc.Y - 44), new Size(27, 35));
                }
                else
                {

                }
                img = "\\speed\\2\\" + speed2 + ".jpg";
                if (File.Exists(image + img))
                {
                    DrawTexture(image + img, 60, new Point(loc.X + 75, loc.Y - 44), new Size(27, 35));
                }
                else
                {

                }
            }
            catch
            {

            }

            img = emptystr;
            if (File.Exists(image + img))
            {
                DrawTexture(image + img, 60, new Point(loc.X + 190, loc.Y - 62), new Size(90, 70));
            }
            else
            {

            }
        }

        public static bool displaycheck = false;

        static bool beepplay = false;
        public static void tick(Vehicle delorean, bool refilltimecurcuits, int fmonth1, int fmonth2, int fday1, int fday2, int fy1, int fy2, int fy3, int fy4, int fh1, int fh2, string fampm, int fm1, int fm2,
            int presmonth1, int presmonth2, int presday1, int presday2, int presy1, int presy2, int presy3, int presy4, int presh1, int presh2, string presampm, int presm1, int presm2,
            int pastmonth1, int pastmonth2, int pastday1, int pastday2, int pasty1, int pasty2, int pasty3, int pasty4, int pasth1, int pasth2, string pastampm, int pastm1, int pastm2, bool bug)
        {
            if (Directory.Exists(image))
            {
                if (refilltimecurcuits)
                {
                    if (DateTime.Now.Millisecond > 500 && DateTime.Now.Millisecond <= 1000)
                    {
                        if (!ticktock)
                        {

                            ticktock = true;
                        }
                    }
                    else
                    {
                        if (ticktock)
                        {
                            ticktock = false;
                        }
                    }

                    int h1 = 1, h2 = 2;
                    if (!bug)
                    {
                        #region future

                        //month display
                        img = displaymonth((fmonth1 * 10) + fmonth2, time.Future);
                        if (File.Exists(image + img))
                        {
                            DrawTexture(image + img, 60, new Point(loc.X + 27, loc.Y + 65), new Size(88, 29));
                        }
                        else
                        {
                            UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                            debug2.Draw();
                        }

                        //Day display
                        img = displaymunber(fday1, time.Future);
                        if (File.Exists(image + "\\day\\1" + img))
                        {
                            DrawTexture(image + "\\day\\1" + img, 60, new Point(loc.X + 140, loc.Y + 65), new Size(20, 29));
                        }
                        else
                        {
                            UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                            debug2.Draw();
                        }
                        img = displaymunber(fday2, time.Future);
                        if (File.Exists(image + "\\day\\2" + img))
                        {
                            DrawTexture(image + "\\day\\2" + img, 60, new Point(loc.X + 166, loc.Y + 65), new Size(20, 29));
                        }
                        else
                        {
                            UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                            debug2.Draw();
                        }

                        //yeardisplay
                        img = displaymunber(fy1, time.Future);
                        if (File.Exists(image + "\\year\\1" + img))
                        {
                            DrawTexture(image + "\\year\\1" + img, 60, new Point(loc.X + 220, loc.Y + 65), new Size(20, 29));
                        }
                        else
                        {
                            UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                            debug2.Draw();
                        }
                        img = displaymunber(fy2, time.Future);
                        if (File.Exists(image + "\\year\\2" + img))
                        {
                            DrawTexture(image + "\\year\\2" + img, 60, new Point(loc.X + 249, loc.Y + 65), new Size(20, 29));
                        }
                        else
                        {
                            UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                            debug2.Draw();
                        }
                        img = displaymunber(fy3, time.Future);
                        if (File.Exists(image + "\\year\\3" + img))
                        {
                            DrawTexture(image + "\\year\\3" + img, 60, new Point(loc.X + 278, loc.Y + 65), new Size(20, 29));
                        }
                        else
                        {
                            UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                            debug2.Draw();
                        }
                        img = displaymunber(fy4, time.Future);
                        if (File.Exists(image + "\\year\\4" + img))
                        {
                            DrawTexture(image + "\\year\\4" + img, 60, new Point(loc.X + 307, loc.Y + 65), new Size(20, 29));
                        }
                        else
                        {
                            UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                            debug2.Draw();
                        }

                        if (((fh1 * 10) + fh2) == 0)
                        {
                            h1 = 1;
                            h2 = 2;
                        }
                        else if (((fh1 * 10) + fh2) == 1)
                        {
                            h1 = 0;
                            h2 = 1;
                        }
                        else if (((fh1 * 10) + fh2) == 2)
                        {
                            h1 = 0;
                            h2 = 2;
                        }
                        else if (((fh1 * 10) + fh2) == 3)
                        {
                            h1 = 0;
                            h2 = 3;
                        }
                        else if (((fh1 * 10) + fh2) == 4)
                        {
                            h1 = 0;
                            h2 = 4;
                        }
                        else if (((fh1 * 10) + fh2) == 5)
                        {
                            h1 = 0;
                            h2 = 5;
                        }
                        else if (((fh1 * 10) + fh2) == 6)
                        {
                            h1 = 0;
                            h2 = 6;
                        }
                        else if (((fh1 * 10) + fh2) == 7)
                        {
                            h1 = 0;
                            h2 = 7;
                        }
                        else if (((fh1 * 10) + fh2) == 8)
                        {
                            h1 = 0;
                            h2 = 8;
                        }
                        else if (((fh1 * 10) + fh2) == 9)
                        {
                            h1 = 0;
                            h2 = 9;
                        }
                        else if (((fh1 * 10) + fh2) == 10)
                        {
                            h1 = 1;
                            h2 = 0;
                        }
                        else if (((fh1 * 10) + fh2) == 11)
                        {
                            h1 = 1;
                            h2 = 1;
                        }
                        else if (((fh1 * 10) + fh2) == 12)
                        {
                            h1 = 1;
                            h2 = 2;
                        }
                        else if (((fh1 * 10) + fh2) == 13)
                        {
                            h1 = 0;
                            h2 = 1;
                        }
                        else if (((fh1 * 10) + fh2) == 14)
                        {
                            h1 = 0;
                            h2 = 2;
                        }
                        else if (((fh1 * 10) + fh2) == 15)
                        {
                            h1 = 0;
                            h2 = 3;
                        }
                        else if (((fh1 * 10) + fh2) == 16)
                        {
                            h1 = 0;
                            h2 = 4;
                        }
                        else if (((fh1 * 10) + fh2) == 17)
                        {
                            h1 = 0;
                            h2 = 5;
                        }
                        else if (((fh1 * 10) + fh2) == 18)
                        {
                            h1 = 0;
                            h2 = 6;
                        }
                        else if (((fh1 * 10) + fh2) == 19)
                        {
                            h1 = 0;
                            h2 = 7;
                        }
                        else if (((fh1 * 10) + fh2) == 20)
                        {
                            h1 = 0;
                            h2 = 8;
                        }
                        else if (((fh1 * 10) + fh2) == 21)
                        {
                            h1 = 0;
                            h2 = 9;
                        }
                        else if (((fh1 * 10) + fh2) == 22)
                        {
                            h1 = 1;
                            h2 = 0;
                        }
                        else if (((fh1 * 10) + fh2) == 23)
                        {
                            h1 = 1;
                            h2 = 1;
                        }


                        //hour display
                        img = displaymunber(h1, time.Future);
                        if (File.Exists(image + "\\hour\\1" + img))
                        {
                            DrawTexture(image + "\\hour\\1" + img, 60, new Point(loc.X + 366, loc.Y + 65), new Size(20, 29));
                        }
                        else
                        {
                            UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                            debug2.Draw();
                        }
                        img = displaymunber(h2, time.Future);
                        if (File.Exists(image + "\\hour\\2" + img))
                        {
                            DrawTexture(image + "\\hour\\2" + img, 60, new Point(loc.X + 388, loc.Y + 65), new Size(20, 29));
                        }
                        else
                        {
                            UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                            debug2.Draw();
                        }

                        if (((fh1 * 10) + fh2) >= 12)
                        {
                            fampm = "pm";
                        }
                        else
                        {
                            fampm = "am";
                        }

                        //ampm
                        img = "\\red " + fampm + ".jpg";
                        if (File.Exists(image + img))
                        {
                            DrawTexture(image + img, 60, new Point(loc.X + 330, loc.Y + 53), new Size(30, 43));
                        }
                        else
                        {
                            UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                            debug2.Draw();
                        }

                        //tick
                        {
                            if (ticktock)
                            {
                                if (beepsound)
                                {
                                    if (!beepplay)
                                    {
                                        beepplay = true;
                                        Sounds.Beep.Play();
                                    }
                                }
                                img = "\\red colon on.jpg";
                                if (File.Exists(image + img))
                                {
                                    DrawTexture(image + img, 60, new Point(loc.X + 420, loc.Y + 69), new Size(16, 24));
                                }
                                else
                                {
                                    UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                                    debug2.Draw();
                                }
                            }
                            else
                            {
                                if (beepsound)
                                {
                                    if (beepplay)
                                    {
                                        beepplay = false;
                                    }
                                }
                            }
                        }

                        //minute display
                        img = displaymunber(fm1, time.Future);
                        if (File.Exists(image + "\\min\\1" + img))
                        {
                            DrawTexture(image + "\\min\\1" + img, 60, new Point(loc.X + 447, loc.Y + 65), new Size(20, 29));
                        }
                        else
                        {
                            UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                            debug2.Draw();
                        }
                        img = displaymunber(fm2, time.Future);
                        if (File.Exists(image + "\\min\\2" + img))
                        {
                            DrawTexture(image + "\\min\\2" + img, 60, new Point(loc.X + 474, loc.Y + 65), new Size(20, 29));
                        }
                        else
                        {
                            UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                            debug2.Draw();
                        }
                        #endregion
                    }
                    #region present

                    img = displaymonth((presmonth1 * 10) + presmonth2, time.Present);
                    if (File.Exists(image + img))
                    {
                        DrawTexture(image + img, 60, new Point(loc.X + 27, loc.Y + 157), new Size(88, 29));
                    }
                    else
                    {
                        UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                        debug2.Draw();
                    }

                    //Day display
                    img = displaymunber(presday1, time.Present);
                    if (File.Exists(image + "\\day\\1" + img))
                    {
                        DrawTexture(image + "\\day\\1" + img, 60, new Point(loc.X + 140, loc.Y + 157), new Size(20, 29));
                    }
                    else
                    {
                        UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                        debug2.Draw();
                    }
                    img = displaymunber(presday2, time.Present);
                    if (File.Exists(image + "\\day\\2" + img))
                    {
                        DrawTexture(image + "\\day\\2" + img, 60, new Point(loc.X + 166, loc.Y + 157), new Size(20, 29));
                    }
                    else
                    {
                        UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                        debug2.Draw();
                    }

                    //yeardisplay
                    img = displaymunber(presy1, time.Present);
                    if (File.Exists(image + "\\year\\1" + img))
                    {
                        DrawTexture(image + "\\year\\1" + img, 60, new Point(loc.X + 220, loc.Y + 157), new Size(20, 29));
                    }
                    else
                    {
                        UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                        debug2.Draw();
                    }
                    img = displaymunber(presy2, time.Present);
                    if (File.Exists(image + "\\year\\2" + img))
                    {
                        DrawTexture(image + "\\year\\2" + img, 60, new Point(loc.X + 249, loc.Y + 157), new Size(20, 29));
                    }
                    else
                    {
                        UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                        debug2.Draw();
                    }
                    img = displaymunber(presy3, time.Present);
                    if (File.Exists(image + "\\year\\3" + img))
                    {
                        DrawTexture(image + "\\year\\3" + img, 60, new Point(loc.X + 278, loc.Y + 157), new Size(20, 29));
                    }
                    else
                    {
                        UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                        debug2.Draw();
                    }
                    img = displaymunber(presy4, time.Present);
                    if (File.Exists(image + "\\year\\4" + img))
                    {
                        DrawTexture(image + "\\year\\4" + img, 60, new Point(loc.X + 307, loc.Y + 157), new Size(20, 29));
                    }
                    else
                    {
                        UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                        debug2.Draw();
                    }

                    //ampm
                    img = "\\green " + presampm + ".jpg";
                    if (File.Exists(image + img))
                    {
                        DrawTexture(image + img, 60, new Point(loc.X + 330, loc.Y + 145), new Size(30, 42));
                    }
                    else
                    {
                        UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                        debug2.Draw();
                    }

                    //hour display
                    img = displaymunber(presh1, time.Present);
                    if (File.Exists(image + "\\hour\\1" + img))
                    {
                        DrawTexture(image + "\\hour\\1" + img, 60, new Point(loc.X + 366, loc.Y + 157), new Size(20, 29));
                    }
                    else
                    {
                        UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                        debug2.Draw();
                    }
                    img = displaymunber(presh2, time.Present);
                    if (File.Exists(image + "\\hour\\2" + img))
                    {
                        DrawTexture(image + "\\hour\\2" + img, 60, new Point(loc.X + 388, loc.Y + 157), new Size(20, 29));
                    }
                    else
                    {
                        UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                        debug2.Draw();
                    }

                    //tick
                    if (ticktock)
                    {
                        img = "\\green colon on.jpg";
                        if (File.Exists(image + img))
                        {
                            DrawTexture(image + img, 60, new Point(loc.X + 420, loc.Y + 159), new Size(16, 24));
                            delorean.SetMod(VehicleMod.Grille, 0, true);
                        }
                        else
                        {
                            UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                            debug2.Draw();
                        }
                    }
                    else
                    {
                        delorean.SetMod(VehicleMod.Grille, -1, true);
                    }

                    //minute display
                    img = displaymunber(presm1, time.Present);
                    if (File.Exists(image + "\\min\\1" + img))
                    {
                        DrawTexture(image + "\\min\\1" + img, 60, new Point(loc.X + 447, loc.Y + 157), new Size(20, 29));
                    }
                    else
                    {
                        UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                        debug2.Draw();
                    }
                    img = displaymunber(presm2, time.Present);
                    if (File.Exists(image + "\\min\\2" + img))
                    {
                        DrawTexture(image + "\\min\\2" + img, 60, new Point(loc.X + 474, loc.Y + 157), new Size(20, 29));
                    }
                    else
                    {
                        UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                        debug2.Draw();
                    }
                    #endregion

                    #region past
                    //month display
                    img = displaymonth((pastmonth1 * 10) + pastmonth2, time.Past);
                    if (File.Exists(image + img))
                    {
                        DrawTexture(image + img, 60, new Point(loc.X + 27, loc.Y + 243), new Size(88, 29));
                    }
                    else
                    {
                        UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                        debug2.Draw();
                    }

                    //Day display
                    img = displaymunber(pastday1, time.Past);
                    if (File.Exists(image + "\\day\\1" + img))
                    {
                        DrawTexture(image + "\\day\\1" + img, 60, new Point(loc.X + 140, loc.Y + 243), new Size(20, 29));
                    }
                    else
                    {
                        UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                        debug2.Draw();
                    }
                    img = displaymunber(pastday2, time.Past);
                    if (File.Exists(image + "\\day\\2" + img))
                    {
                        DrawTexture(image + "\\day\\2" + img, 60, new Point(loc.X + 166, loc.Y + 243), new Size(20, 29));
                    }
                    else
                    {
                        UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                        debug2.Draw();
                    }

                    //yeardisplay
                    img = displaymunber(pasty1, time.Past);
                    if (File.Exists(image + "\\year\\1" + img))
                    {
                        DrawTexture(image + "\\year\\1" + img, 60, new Point(loc.X + 220, loc.Y + 243), new Size(20, 29));
                    }
                    else
                    {
                        UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                        debug2.Draw();
                    }
                    img = displaymunber(pasty2, time.Past);
                    if (File.Exists(image + "\\year\\2" + img))
                    {
                        DrawTexture(image + "\\year\\2" + img, 60, new Point(loc.X + 249, loc.Y + 243), new Size(20, 29));
                    }
                    else
                    {
                        UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                        debug2.Draw();
                    }
                    img = displaymunber(pasty3, time.Past);
                    if (File.Exists(image + "\\year\\3" + img))
                    {
                        DrawTexture(image + "\\year\\3" + img, 60, new Point(loc.X + 278, loc.Y + 243), new Size(20, 29));
                    }
                    else
                    {
                        UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                        debug2.Draw();
                    }
                    img = displaymunber(pasty4, time.Past);
                    if (File.Exists(image + "\\year\\4" + img))
                    {
                        DrawTexture(image + "\\year\\4" + img, 60, new Point(loc.X + 307, loc.Y + 243), new Size(20, 29));
                    }
                    else
                    {
                        UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                        debug2.Draw();
                    }

                    if (((pasth1 * 10) + pasth2) == 0)
                    {
                        h1 = 1;
                        h2 = 2;
                    }
                    else if (((pasth1 * 10) + pasth2) == 1)
                    {
                        h1 = 0;
                        h2 = 1;
                    }
                    else if (((pasth1 * 10) + pasth2) == 2)
                    {
                        h1 = 0;
                        h2 = 2;
                    }
                    else if (((pasth1 * 10) + pasth2) == 3)
                    {
                        h1 = 0;
                        h2 = 3;
                    }
                    else if (((pasth1 * 10) + pasth2) == 4)
                    {
                        h1 = 0;
                        h2 = 4;
                    }
                    else if (((pasth1 * 10) + pasth2) == 5)
                    {
                        h1 = 0;
                        h2 = 5;
                    }
                    else if (((pasth1 * 10) + pasth2) == 6)
                    {
                        h1 = 0;
                        h2 = 6;
                    }
                    else if (((pasth1 * 10) + pasth2) == 7)
                    {
                        h1 = 0;
                        h2 = 7;
                    }
                    else if (((pasth1 * 10) + pasth2) == 8)
                    {
                        h1 = 0;
                        h2 = 8;
                    }
                    else if (((pasth1 * 10) + pasth2) == 9)
                    {
                        h1 = 0;
                        h2 = 9;
                    }
                    else if (((pasth1 * 10) + pasth2) == 10)
                    {
                        h1 = 1;
                        h2 = 0;
                    }
                    else if (((pasth1 * 10) + pasth2) == 11)
                    {
                        h1 = 1;
                        h2 = 1;
                    }
                    else if (((pasth1 * 10) + pasth2) == 12)
                    {
                        h1 = 1;
                        h2 = 2;
                    }
                    else if (((pasth1 * 10) + pasth2) == 13)
                    {
                        h1 = 0;
                        h2 = 1;
                    }
                    else if (((pasth1 * 10) + pasth2) == 14)
                    {
                        h1 = 0;
                        h2 = 2;
                    }
                    else if (((pasth1 * 10) + pasth2) == 15)
                    {
                        h1 = 0;
                        h2 = 3;
                    }
                    else if (((pasth1 * 10) + pasth2) == 16)
                    {
                        h1 = 0;
                        h2 = 4;
                    }
                    else if (((pasth1 * 10) + pasth2) == 17)
                    {
                        h1 = 0;
                        h2 = 5;
                    }
                    else if (((pasth1 * 10) + pasth2) == 18)
                    {
                        h1 = 0;
                        h2 = 6;
                    }
                    else if (((pasth1 * 10) + pasth2) == 19)
                    {
                        h1 = 0;
                        h2 = 7;
                    }
                    else if (((pasth1 * 10) + pasth2) == 20)
                    {
                        h1 = 0;
                        h2 = 8;
                    }
                    else if (((pasth1 * 10) + pasth2) == 21)
                    {
                        h1 = 0;
                        h2 = 9;
                    }
                    else if (((pasth1 * 10) + pasth2) == 22)
                    {
                        h1 = 1;
                        h2 = 0;
                    }
                    else if (((pasth1 * 10) + pasth2) == 23)
                    {
                        h1 = 1;
                        h2 = 1;
                    }

                    //hour display
                    img = displaymunber(h1, time.Past);
                    if (File.Exists(image + "\\hour\\1" + img))
                    {
                        DrawTexture(image + "\\hour\\1" + img, 60, new Point(loc.X + 366, loc.Y + 243), new Size(20, 29));
                    }
                    else
                    {
                        UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                        debug2.Draw();
                    }
                    img = displaymunber(h2, time.Past);
                    if (File.Exists(image + "\\hour\\2" + img))
                    {
                        DrawTexture(image + "\\hour\\2" + img, 60, new Point(loc.X + 388, loc.Y + 243), new Size(20, 29));
                    }
                    else
                    {
                        UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                        debug2.Draw();
                    }

                    if (((pasth1 * 10) + pasth2) >= 12)
                    {
                        pastampm = "pm";
                    }
                    else
                    {
                        pastampm = "am";
                    }

                    //ampm
                    img = "\\amber " + pastampm + ".jpg";
                    if (File.Exists(image + img))
                    {
                        DrawTexture(image + img, 60, new Point(loc.X + 330, loc.Y + 234), new Size(30, 40));
                    }
                    else
                    {
                        UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                        debug2.Draw();
                    }

                    //tick
                    if (ticktock)
                    {
                        img = "\\amber colon on.jpg";
                        if (File.Exists(image + img))
                        {
                            DrawTexture(image + img, 60, new Point(loc.X + 421, loc.Y + 246), new Size(14, 24));
                        }
                        else
                        {
                            UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                            debug2.Draw();
                        }
                    }

                    //minute display
                    img = displaymunber(pastm1, time.Past);
                    if (File.Exists(image + "\\min\\1" + img))
                    {
                        DrawTexture(image + "\\min\\1" + img, 60, new Point(loc.X + 447, loc.Y + 243), new Size(20, 29));
                    }
                    else
                    {
                        UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                        debug2.Draw();
                    }
                    img = displaymunber(pastm2, time.Past);
                    if (File.Exists(image + "\\min\\2" + img))
                    {
                        DrawTexture(image + "\\min\\2" + img, 60, new Point(loc.X + 474, loc.Y + 243), new Size(20, 29));
                    }
                    else
                    {
                        UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                        debug2.Draw();
                    }
                    #endregion
                }
            }
            else
            {
                if (!refilltimecurcuits)
                {
                    UIResText Mrfusion = new UIResText("Empty", new Point(1600, 900), (float)0.6, Color.Orange);
                    Mrfusion.Draw();
                }
                UIResText Timedisplayf = new UIResText(timedisplay(fmonth1, fmonth2, fday1, fday2, fy1, fy2, fy3, fy4, fh1, fh2, fampm, fm1, fm2), new Point(1450, 940), (float)0.6, Color.Red);
                UIResText Timedisplaypres = new UIResText(timedisplay(presmonth1, presmonth2, presday1, presday2, presy1, presy2, presy3, presy4, presh1, presh2, presampm, presm1, presm2), new Point(1450, 980), (float)0.6, Color.Green);
                UIResText Timedisplaypast = new UIResText(timedisplay(pastmonth1, pastmonth2, pastday1, pastday2, pasty1, pasty2, pasty3, pasty4, pasth1, pasth2, pastampm, pastm1, pastm2), new Point(1450, 1020), (float)0.6, Color.Yellow);
                Timedisplayf.DropShadow = true;
                Timedisplaypres.DropShadow = true;
                Timedisplaypast.DropShadow = true;
                Timedisplayf.Draw();
                Timedisplaypres.Draw();
                Timedisplaypast.Draw();
            }
        }

        //public void tick(int X, int Y, int index)
        //{
        //    int tick = DateTime.Now.Second;
        //    Application.DoEvents();
        //    if (Directory.Exists(image))
        //    {
        //        #region future

        //        //month display
        //        img = displaymonth((fmonth1 * 10) + fmonth2, time.Future);
        //        if (File.Exists(image + img))
        //        {
        //            DrawTexture(image + img, 60, new Point(loc.X + X, loc.Y + Y), new Size(88, 29));
        //        }
        //        else
        //        {
        //            UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
        //            debug2.Draw();
        //        }

        //        //Day display
        //        img = displaymunber(fday1, time.Future);
        //        if (File.Exists(image + "\\day\\1" + img))
        //        {
        //            DrawTexture(image + "\\day\\1" + img, new Point(loc.X + X + 90, loc.Y + Y), new Size(20, 29));
        //        }
        //        else
        //        {
        //            UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
        //            debug2.Draw();
        //        }
        //        img = displaymunber(fday2, time.Future);
        //        if (File.Exists(image + "\\day\\2" + img))
        //        {
        //            DrawTexture(image + "\\day\\2" + img, new Point(loc.X + X + 110, loc.Y + Y), new Size(20, 29));
        //        }
        //        else
        //        {
        //            UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
        //            debug2.Draw();
        //        }

        //        //yeardisplay
        //        img = displaymunber(fy1, time.Future);
        //        if (File.Exists(image + "\\year\\1" + img))
        //        {
        //            DrawTexture(image + "\\year\\1" + img, new Point(loc.X + X + 140, loc.Y + Y), new Size(20, 29));
        //        }
        //        else
        //        {
        //            UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
        //            debug2.Draw();
        //        }
        //        img = displaymunber(fy2, time.Future);
        //        if (File.Exists(image + "\\year\\2" + img))
        //        {
        //            DrawTexture(image + "\\year\\2" + img, new Point(loc.X + X + 160, loc.Y + Y), new Size(20, 29));
        //        }
        //        else
        //        {
        //            UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
        //            debug2.Draw();
        //        }
        //        img = displaymunber(fy3, time.Future);
        //        if (File.Exists(image + "\\year\\3" + img))
        //        {
        //            DrawTexture(image + "\\year\\3" + img, new Point(loc.X + X + 180, loc.Y + Y), new Size(20, 29));
        //        }
        //        else
        //        {
        //            UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
        //            debug2.Draw();
        //        }
        //        img = displaymunber(fy4, time.Future);
        //        if (File.Exists(image + "\\year\\4" + img))
        //        {
        //            DrawTexture(image + "\\year\\4" + img, new Point(loc.X + X + 200, loc.Y + Y), new Size(20, 29));
        //        }
        //        else
        //        {
        //            UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
        //            debug2.Draw();
        //        }

        //        #region ampm
        //        int h1 = 1, h2 = 2;
        //        if (((fh1 * 10) + fh2) == 0)
        //        {
        //            h1 = 1;
        //            h2 = 2;
        //        }
        //        else if (((fh1 * 10) + fh2) == 1)
        //        {
        //            h1 = 0;
        //            h2 = 1;
        //        }
        //        else if (((fh1 * 10) + fh2) == 2)
        //        {
        //            h1 = 0;
        //            h2 = 2;
        //        }
        //        else if (((fh1 * 10) + fh2) == 3)
        //        {
        //            h1 = 0;
        //            h2 = 3;
        //        }
        //        else if (((fh1 * 10) + fh2) == 4)
        //        {
        //            h1 = 0;
        //            h2 = 4;
        //        }
        //        else if (((fh1 * 10) + fh2) == 5)
        //        {
        //            h1 = 0;
        //            h2 = 5;
        //        }
        //        else if (((fh1 * 10) + fh2) == 6)
        //        {
        //            h1 = 0;
        //            h2 = 6;
        //        }
        //        else if (((fh1 * 10) + fh2) == 7)
        //        {
        //            h1 = 0;
        //            h2 = 7;
        //        }
        //        else if (((fh1 * 10) + fh2) == 8)
        //        {
        //            h1 = 0;
        //            h2 = 8;
        //        }
        //        else if (((fh1 * 10) + fh2) == 9)
        //        {
        //            h1 = 0;
        //            h2 = 9;
        //        }
        //        else if (((fh1 * 10) + fh2) == 10)
        //        {
        //            h1 = 1;
        //            h2 = 0;
        //        }
        //        else if (((fh1 * 10) + fh2) == 11)
        //        {
        //            h1 = 1;
        //            h2 = 1;
        //        }
        //        else if (((fh1 * 10) + fh2) == 12)
        //        {
        //            h1 = 1;
        //            h2 = 2;
        //        }
        //        else if (((fh1 * 10) + fh2) == 13)
        //        {
        //            h1 = 0;
        //            h2 = 1;
        //        }
        //        else if (((fh1 * 10) + fh2) == 14)
        //        {
        //            h1 = 0;
        //            h2 = 2;
        //        }
        //        else if (((fh1 * 10) + fh2) == 15)
        //        {
        //            h1 = 0;
        //            h2 = 3;
        //        }
        //        else if (((fh1 * 10) + fh2) == 16)
        //        {
        //            h1 = 0;
        //            h2 = 4;
        //        }
        //        else if (((fh1 * 10) + fh2) == 17)
        //        {
        //            h1 = 0;
        //            h2 = 5;
        //        }
        //        else if (((fh1 * 10) + fh2) == 18)
        //        {
        //            h1 = 0;
        //            h2 = 6;
        //        }
        //        else if (((fh1 * 10) + fh2) == 19)
        //        {
        //            h1 = 0;
        //            h2 = 7;
        //        }
        //        else if (((fh1 * 10) + fh2) == 20)
        //        {
        //            h1 = 0;
        //            h2 = 8;
        //        }
        //        else if (((fh1 * 10) + fh2) == 21)
        //        {
        //            h1 = 0;
        //            h2 = 9;
        //        }
        //        else if (((fh1 * 10) + fh2) == 22)
        //        {
        //            h1 = 1;
        //            h2 = 0;
        //        }
        //        else if (((fh1 * 10) + fh2) == 23)
        //        {
        //            h1 = 1;
        //            h2 = 1;
        //        }
        //        #endregion
        //        Application.DoEvents();
        //        //hour display
        //        img = displaymunber(h1, time.Future);
        //        if (File.Exists(image + "\\hour\\1" + img))
        //        {
        //            DrawTexture(image + "\\hour\\1" + img, new Point(loc.X + X + 250, loc.Y + Y), new Size(20, 29));
        //        }
        //        else
        //        {
        //            UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
        //            debug2.Draw();
        //        }
        //        img = displaymunber(h2, time.Future);
        //        if (File.Exists(image + "\\hour\\2" + img))
        //        {
        //            DrawTexture(image + "\\hour\\2" + img, new Point(loc.X + X + 270, loc.Y + Y), new Size(20, 29));
        //        }
        //        else
        //        {
        //            UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
        //            debug2.Draw();
        //        }

        //        if (((fh1 * 10) + fh2) > 12)
        //        {
        //            fampm = "pm";
        //        }
        //        else
        //        {
        //            fampm = "am";
        //        }

        //        UIResText Timedisplayf = new UIResText(timedisplayfuture(), new Point(1100, 570), (float)0.6, Color.Red);
        //        Timedisplayf.DropShadow = true;
        //        Timedisplayf.Draw();
        //        //ampm
        //        img = "\\red " + fampm + ".jpg";
        //        if (File.Exists(image + img))
        //        {
        //            DrawTexture(image + img, 60, new Point(loc.X + X + 220, loc.Y + Y + 2), new Size(20, 28));
        //        }
        //        else
        //        {
        //            UIText debug2 = new UIText("File is not present: " + img, new Point(loc.X + X, loc.Y + Y), (float)0.6);
        //            debug2.Draw();
        //        }

        //        //tick
        //        if (tick != temptick)
        //        {
        //            Application.DoEvents();
        //            if (ticktock)
        //            {
        //                ticktock = false;
        //            }
        //            else
        //            {
        //                ticktock = true;
        //            }
        //            temptick = tick;
        //        }
        //        else
        //        {
        //            Application.DoEvents();
        //            if (ticktock)
        //            {
        //                img = "\\red colon on.jpg";
        //                if (File.Exists(image + img))
        //                {
        //                    DrawTexture(image + img, 60, new Point(loc.X + X + 287, loc.Y + Y + 10), new Size(10, 14));
        //                }
        //                else
        //                {
        //                    UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
        //                    debug2.Draw();
        //                }
        //            }
        //            else
        //            {
        //                img = "\\red colon off.jpg";
        //                if (File.Exists(image + img))
        //                {
        //                    DrawTexture(image + img, 60, new Point(loc.X + X + 287, loc.Y + Y + 10), new Size(10, 14));
        //                }
        //                else
        //                {
        //                    UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
        //                    debug2.Draw();
        //                }
        //            }
        //        }

        //        //minute display
        //        img = displaymunber(fm1, time.Future);
        //        if (File.Exists(image + "\\min\\1" + img))
        //        {
        //            DrawTexture(image + "\\min\\1" + img, new Point(loc.X + X + 300, loc.Y + Y), new Size(20, 29));
        //        }
        //        else
        //        {
        //            UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
        //            debug2.Draw();
        //        }
        //        img = displaymunber(fm2, time.Future);
        //        if (File.Exists(image + "\\min\\2" + img))
        //        {
        //            DrawTexture(image + "\\min\\2" + img, new Point(loc.X + X + 320, loc.Y + Y), new Size(20, 29));
        //        }
        //        else
        //        {
        //            UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
        //            debug2.Draw();
        //        }
        //        #endregion

        //        #region Present

        //        //month display
        //        img = displaymonth((presmonth1 * 10) + presmonth2, time.Present);
        //        if (File.Exists(image + img))
        //        {
        //            DrawTexture(image + img, 60, new Point(loc.X + X, loc.Y + Y + 30), new Size(88, 29));
        //        }
        //        else
        //        {
        //            UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
        //            debug2.Draw();
        //        }

        //        //Day display
        //        img = displaymunber(presday1, time.Present);
        //        if (File.Exists(image + "\\day\\1" + img))
        //        {
        //            DrawTexture(image + "\\day\\1" + img, new Point(loc.X + X + 90, loc.Y + Y + 30), new Size(20, 29));
        //        }
        //        else
        //        {
        //            UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
        //            debug2.Draw();
        //        }
        //        img = displaymunber(presday2, time.Present);
        //        if (File.Exists(image + "\\day\\2" + img))
        //        {
        //            DrawTexture(image + "\\day\\2" + img, new Point(loc.X + X + 110, loc.Y + Y + 30), new Size(20, 29));
        //        }
        //        else
        //        {
        //            UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
        //            debug2.Draw();
        //        }

        //        //yeardisplay
        //        img = displaymunber(presy1, time.Present);
        //        if (File.Exists(image + "\\year\\1" + img))
        //        {
        //            DrawTexture(image + "\\year\\1" + img, new Point(loc.X + X + 140, loc.Y + Y + 30), new Size(20, 29));
        //        }
        //        else
        //        {
        //            UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
        //            debug2.Draw();
        //        }
        //        img = displaymunber(presy2, time.Present);
        //        if (File.Exists(image + "\\year\\2" + img))
        //        {
        //            DrawTexture(image + "\\year\\2" + img, new Point(loc.X + X + 160, loc.Y + Y + 30), new Size(20, 29));
        //        }
        //        else
        //        {
        //            UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
        //            debug2.Draw();
        //        }
        //        img = displaymunber(presy3, time.Present);
        //        if (File.Exists(image + "\\year\\3" + img))
        //        {
        //            DrawTexture(image + "\\year\\3" + img, new Point(loc.X + X + 180, loc.Y + Y + 30), new Size(20, 29));
        //        }
        //        else
        //        {
        //            UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
        //            debug2.Draw();
        //        }
        //        img = displaymunber(presy4, time.Present);
        //        if (File.Exists(image + "\\year\\4" + img))
        //        {
        //            DrawTexture(image + "\\year\\4" + img, new Point(loc.X + X + 200, loc.Y + Y + 30), new Size(20, 29));
        //        }
        //        else
        //        {
        //            UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
        //            debug2.Draw();
        //        }

        //        #region ampm
        //        presampm = "am";
        //        int hour = World.CurrentDayTime.Hours;
        //        if (hour == 0)
        //        {
        //            h1 = 1;
        //            h2 = 2;
        //        }
        //        else if (hour == 1)
        //        {
        //            h1 = 0;
        //            h2 = 1;
        //        }
        //        else if (hour == 2)
        //        {
        //            h1 = 0;
        //            h2 = 2;
        //        }
        //        else if (hour == 3)
        //        {
        //            h1 = 0;
        //            h2 = 3;
        //        }
        //        else if (hour == 4)
        //        {
        //            h1 = 0;
        //            h2 = 4;
        //        }
        //        else if (hour == 5)
        //        {
        //            h1 = 0;
        //            h2 = 5;
        //        }
        //        else if (hour == 6)
        //        {
        //            h1 = 0;
        //            h2 = 6;
        //        }
        //        else if (hour == 7)
        //        {
        //            h1 = 0;
        //            h2 = 7;
        //        }
        //        else if (hour == 8)
        //        {
        //            h1 = 0;
        //            h2 = 8;
        //        }
        //        else if (hour == 9)
        //        {
        //            h1 = 0;
        //            h2 = 9;
        //        }
        //        else if (hour == 10)
        //        {
        //            h1 = 1;
        //            h2 = 0;
        //        }
        //        else if (hour == 11)
        //        {
        //            h1 = 1;
        //            h2 = 1;
        //        }
        //        else if (hour == 12)
        //        {
        //            h1 = 1;
        //            h2 = 2;
        //        }
        //        else if (hour == 13)
        //        {
        //            h1 = 0;
        //            h2 = 1;
        //        }
        //        else if (hour == 14)
        //        {
        //            h1 = 0;
        //            h2 = 2;
        //        }
        //        else if (hour == 15)
        //        {
        //            h1 = 0;
        //            h2 = 3;
        //        }
        //        else if (hour == 16)
        //        {
        //            h1 = 0;
        //            h2 = 4;
        //        }
        //        else if (hour == 17)
        //        {
        //            h1 = 0;
        //            h2 = 5;
        //        }
        //        else if (hour == 18)
        //        {
        //            h1 = 0;
        //            h2 = 6;
        //        }
        //        else if (hour == 19)
        //        {
        //            h1 = 0;
        //            h2 = 7;
        //        }
        //        else if (hour == 20)
        //        {
        //            h1 = 0;
        //            h2 = 8;
        //        }
        //        else if (hour == 21)
        //        {
        //            h1 = 0;
        //            h2 = 9;
        //        }
        //        else if (hour == 22)
        //        {
        //            h1 = 1;
        //            h2 = 0;
        //        }
        //        else if (hour == 23)
        //        {
        //            h1 = 1;
        //            h2 = 1;
        //        }
        //        Application.DoEvents();
        //        if (hour > 12)
        //        {
        //            fampm = "pm";
        //        }
        //        else
        //        {
        //            fampm = "am";
        //        }

        //        //ampm
        //        img = "\\green " + fampm + ".jpg";
        //        if (File.Exists(image + img))
        //        {
        //            DrawTexture(image + img, 60, new Point(loc.X + X + 220, loc.Y + Y + 32), new Size(20, 28));
        //        }
        //        else
        //        {
        //            UIText debug2 = new UIText("File is not present: " + img, new Point(loc.X + X, loc.Y + Y), (float)0.6);
        //            debug2.Draw();
        //        }
        //        #endregion

        //        //hour display
        //        img = displaymunber(h1, time.Present);
        //        if (File.Exists(image + "\\hour\\1" + img))
        //        {
        //            DrawTexture(image + "\\hour\\1" + img, new Point(loc.X + X + 250, loc.Y + Y + 30), new Size(20, 29));
        //        }
        //        else
        //        {
        //            UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
        //            debug2.Draw();
        //        }
        //        img = displaymunber(h2, time.Present);
        //        if (File.Exists(image + "\\hour\\2" + img))
        //        {
        //            DrawTexture(image + "\\hour\\2" + img, new Point(loc.X + X + 270, loc.Y + Y + 30), new Size(20, 29));
        //        }
        //        else
        //        {
        //            UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
        //            debug2.Draw();
        //        }

        //        //tick
        //        if (tick != temptick)
        //        {
        //            if (ticktock)
        //            {
        //                ticktock = false;
        //            }
        //            else
        //            {
        //                ticktock = true;
        //            }
        //            temptick = tick;
        //        }
        //        else
        //        {
        //            if (ticktock)
        //            {
        //                img = "\\green colon on.jpg";
        //                if (File.Exists(image + img))
        //                {
        //                    DrawTexture(image + img, 60, new Point(loc.X + X + 287, loc.Y + Y + 40), new Size(10, 14));
        //                    Deloreon.SetMod(VehicleMod.Grille, 0, true);
        //                }
        //                else
        //                {
        //                    UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
        //                    debug2.Draw();
        //                }
        //            }
        //            else
        //            {
        //                img = "\\green colon off.jpg";
        //                if (File.Exists(image + img))
        //                {
        //                    DrawTexture(image + img, 60, new Point(loc.X + X + 287, loc.Y + Y + 40), new Size(10, 14));
        //                    Deloreon.SetMod(VehicleMod.Grille, -1, true);
        //                }
        //                else
        //                {
        //                    UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
        //                    debug2.Draw();
        //                }
        //            }
        //        }

        //        //minute display
        //        int presmin = World.CurrentDayTime.Minutes;
        //        if (presmin < 10)
        //        {
        //            presm1 = 0;
        //            presm2 = presmin;
        //        }
        //        else
        //        {
        //            if (presmin < 20)
        //            {
        //                presm1 = 1;
        //                presm2 = presmin - 10;
        //            }
        //            else if (presmin < 30)
        //            {
        //                presm1 = 2;
        //                presm2 = presmin - 20;
        //            }
        //            else if (presmin < 40)
        //            {
        //                presm1 = 3;
        //                presm2 = presmin - 30;
        //            }
        //            else if (presmin < 50)
        //            {
        //                presm1 = 4;
        //                presm2 = presmin - 40;
        //            }
        //            else if (presmin < 60)
        //            {
        //                presm1 = 5;
        //                presm2 = presmin - 50;
        //            }
        //        }

        //        //minute display
        //        img = displaymunber(presm1, time.Present);
        //        if (File.Exists(image + "\\min\\1" + img))
        //        {
        //            DrawTexture(image + "\\min\\1" + img, new Point(loc.X + X + 300, loc.Y + Y + 30), new Size(20, 29));
        //        }
        //        else
        //        {
        //            UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
        //            debug2.Draw();
        //        }
        //        img = displaymunber(presm2, time.Present);
        //        if (File.Exists(image + "\\min\\2" + img))
        //        {
        //            DrawTexture(image + "\\min\\2" + img, new Point(loc.X + X + 320, loc.Y + Y + 30), new Size(20, 29));
        //        }
        //        else
        //        {
        //            UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
        //            debug2.Draw();
        //        }
        //        #endregion

        //        #region Past

        //        //month display
        //        img = displaymonth((pastmonth1 * 10) + pastmonth2, time.Past);
        //        if (File.Exists(image + img))
        //        {
        //            DrawTexture(image + img, 60, new Point(loc.X + X, loc.Y + Y + 60), new Size(88, 29));
        //        }
        //        else
        //        {
        //            UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
        //            debug2.Draw();
        //        }

        //        //Day display
        //        img = displaymunber(pastday1, time.Past);
        //        if (File.Exists(image + "\\day\\1" + img))
        //        {
        //            DrawTexture(image + "\\day\\1" + img, new Point(loc.X + X + 90, loc.Y + Y + 60), new Size(20, 29));
        //        }
        //        else
        //        {
        //            UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
        //            debug2.Draw();
        //        }
        //        img = displaymunber(pastday2, time.Past);
        //        if (File.Exists(image + "\\day\\2" + img))
        //        {
        //            DrawTexture(image + "\\day\\2" + img, new Point(loc.X + X + 110, loc.Y + Y + 60), new Size(20, 29));
        //        }
        //        else
        //        {
        //            UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
        //            debug2.Draw();
        //        }

        //        //yeardisplay
        //        img = displaymunber(pasty1, time.Past);
        //        if (File.Exists(image + "\\year\\1" + img))
        //        {
        //            DrawTexture(image + "\\year\\1" + img, new Point(loc.X + X + 140, loc.Y + Y + 60), new Size(20, 29));
        //        }
        //        else
        //        {
        //            UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
        //            debug2.Draw();
        //        }
        //        img = displaymunber(pasty2, time.Past);
        //        if (File.Exists(image + "\\year\\2" + img))
        //        {
        //            DrawTexture(image + "\\year\\2" + img, new Point(loc.X + X + 160, loc.Y + Y + 60), new Size(20, 29));
        //        }
        //        else
        //        {
        //            UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
        //            debug2.Draw();
        //        }
        //        img = displaymunber(pasty3, time.Past);
        //        if (File.Exists(image + "\\year\\3" + img))
        //        {
        //            DrawTexture(image + "\\year\\3" + img, new Point(loc.X + X + 180, loc.Y + Y + 60), new Size(20, 29));
        //        }
        //        else
        //        {
        //            UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
        //            debug2.Draw();
        //        }
        //        img = displaymunber(pasty4, time.Past);
        //        if (File.Exists(image + "\\year\\4" + img))
        //        {
        //            DrawTexture(image + "\\year\\4" + img, new Point(loc.X + X + 200, loc.Y + Y + 60), new Size(20, 29));
        //        }
        //        else
        //        {
        //            UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
        //            debug2.Draw();
        //        }

        //        #region ampm
        //        h1 = 1; h2 = 2;
        //        if (((pasth1 * 10) + pasth2) == 0)
        //        {
        //            h1 = 1;
        //            h2 = 2;
        //        }
        //        else if (((pasth1 * 10) + pasth2) == 1)
        //        {
        //            h1 = 0;
        //            h2 = 1;
        //        }
        //        else if (((pasth1 * 10) + pasth2) == 2)
        //        {
        //            h1 = 0;
        //            h2 = 2;
        //        }
        //        else if (((pasth1 * 10) + pasth2) == 3)
        //        {
        //            h1 = 0;
        //            h2 = 3;
        //        }
        //        else if (((pasth1 * 10) + pasth2) == 4)
        //        {
        //            h1 = 0;
        //            h2 = 4;
        //        }
        //        else if (((pasth1 * 10) + pasth2) == 5)
        //        {
        //            h1 = 0;
        //            h2 = 5;
        //        }
        //        else if (((pasth1 * 10) + pasth2) == 6)
        //        {
        //            h1 = 0;
        //            h2 = 6;
        //        }
        //        else if (((pasth1 * 10) + pasth2) == 7)
        //        {
        //            h1 = 0;
        //            h2 = 7;
        //        }
        //        else if (((pasth1 * 10) + pasth2) == 8)
        //        {
        //            h1 = 0;
        //            h2 = 8;
        //        }
        //        else if (((pasth1 * 10) + pasth2) == 9)
        //        {
        //            h1 = 0;
        //            h2 = 9;
        //        }
        //        else if (((pasth1 * 10) + pasth2) == 10)
        //        {
        //            h1 = 1;
        //            h2 = 0;
        //        }
        //        else if (((pasth1 * 10) + pasth2) == 11)
        //        {
        //            h1 = 1;
        //            h2 = 1;
        //        }
        //        else if (((pasth1 * 10) + pasth2) == 12)
        //        {
        //            h1 = 1;
        //            h2 = 2;
        //        }
        //        else if (((pasth1 * 10) + pasth2) == 13)
        //        {
        //            h1 = 0;
        //            h2 = 1;
        //        }
        //        else if (((pasth1 * 10) + pasth2) == 14)
        //        {
        //            h1 = 0;
        //            h2 = 2;
        //        }
        //        else if (((pasth1 * 10) + pasth2) == 15)
        //        {
        //            h1 = 0;
        //            h2 = 3;
        //        }
        //        else if (((pasth1 * 10) + pasth2) == 16)
        //        {
        //            h1 = 0;
        //            h2 = 4;
        //        }
        //        else if (((pasth1 * 10) + pasth2) == 17)
        //        {
        //            h1 = 0;
        //            h2 = 5;
        //        }
        //        else if (((pasth1 * 10) + pasth2) == 18)
        //        {
        //            h1 = 0;
        //            h2 = 6;
        //        }
        //        else if (((pasth1 * 10) + pasth2) == 19)
        //        {
        //            h1 = 0;
        //            h2 = 7;
        //        }
        //        else if (((pasth1 * 10) + pasth2) == 20)
        //        {
        //            h1 = 0;
        //            h2 = 8;
        //        }
        //        else if (((pasth1 * 10) + pasth2) == 21)
        //        {
        //            h1 = 0;
        //            h2 = 9;
        //        }
        //        else if (((pasth1 * 10) + pasth2) == 22)
        //        {
        //            h1 = 1;
        //            h2 = 0;
        //        }
        //        else if (((pasth1 * 10) + pasth2) == 23)
        //        {
        //            h1 = 1;
        //            h2 = 1;
        //        }
        //        #endregion

        //        //hour display
        //        img = displaymunber(h1, time.Past);
        //        if (File.Exists(image + "\\hour\\1" + img))
        //        {
        //            DrawTexture(image + "\\hour\\1" + img, new Point(loc.X + X + 250, loc.Y + Y + 60), new Size(20, 29));
        //        }
        //        else
        //        {
        //            UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
        //            debug2.Draw();
        //        }
        //        img = displaymunber(h2, time.Past);
        //        if (File.Exists(image + "\\hour\\2" + img))
        //        {
        //            DrawTexture(image + "\\hour\\2" + img, new Point(loc.X + X + 270, loc.Y + Y + 60), new Size(20, 29));
        //        }
        //        else
        //        {
        //            UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
        //            debug2.Draw();
        //        }

        //        if (((fh1 * 10) + fh2) > 12)
        //        {
        //            fampm = "pm";
        //        }
        //        else
        //        {
        //            fampm = "am";
        //        }

        //        //ampm
        //        img = "\\amber " + pastampm + ".jpg";
        //        if (File.Exists(image + img))
        //        {
        //            DrawTexture(image + img, 60, new Point(loc.X + X + 220, loc.Y + Y + 62), new Size(20, 28));
        //        }
        //        else
        //        {
        //            UIText debug2 = new UIText("File is not present: " + img, new Point(loc.X + X, loc.Y + Y + 50), (float)0.6);
        //            debug2.Draw();
        //        }

        //        //tick
        //        if (tick != temptick)
        //        {
        //            if (ticktock)
        //            {
        //                ticktock = false;
        //            }
        //            else
        //            {
        //                ticktock = true;
        //            }
        //            temptick = tick;
        //        }
        //        else
        //        {
        //            if (ticktock)
        //            {
        //                img = "\\amber colon on.jpg";
        //                if (File.Exists(image + img))
        //                {
        //                    DrawTexture(image + img, 60, new Point(loc.X + X + 287, loc.Y + Y + 70), new Size(10, 14));
        //                }
        //                else
        //                {
        //                    UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
        //                    debug2.Draw();
        //                }
        //            }
        //            else
        //            {
        //                img = "\\amber colon off.jpg";
        //                if (File.Exists(image + img))
        //                {
        //                    DrawTexture(image + img, 60, new Point(loc.X + X + 287, loc.Y + Y + 70), new Size(10, 14));
        //                }
        //                else
        //                {
        //                    UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
        //                    debug2.Draw();
        //                }
        //            }
        //        }

        //        //minute display
        //        img = displaymunber(pastm1, time.Past);
        //        if (File.Exists(image + "\\min\\1" + img))
        //        {
        //            DrawTexture(image + "\\min\\1" + img, new Point(loc.X + X + 300, loc.Y + Y + 60), new Size(20, 29));
        //        }
        //        else
        //        {
        //            UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
        //            debug2.Draw();
        //        }
        //        img = displaymunber(pastm2, time.Past);
        //        if (File.Exists(image + "\\min\\2" + img))
        //        {
        //            DrawTexture(image + "\\min\\2" + img, new Point(loc.X + X + 320, loc.Y + Y + 60), new Size(20, 29));
        //        }
        //        else
        //        {
        //            UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
        //            debug2.Draw();
        //        }
        //        #endregion
        //    }
        //    else
        //    {
        //        if (!refilltimecurcuits)
        //        {
        //            UIResText Mrfusion = new UIResText("Empty", new Point(1600, 900), (float)0.6, Color.Orange);
        //            Mrfusion.Draw();
        //        }
        //        UIResText Timedisplayf = new UIResText(timedisplayfuture(), new Point(1450, 940), (float)0.6, Color.Red);
        //        UIResText Timedisplaypres = new UIResText(timedisplaypresent(), new Point(1450, 980), (float)0.6, Color.Green);
        //        UIResText Timedisplaypast = new UIResText(timedisplaypast(), new Point(1450, 1020), (float)0.6, Color.Yellow);
        //        Timedisplayf.DropShadow = true;
        //        Timedisplaypres.DropShadow = true;
        //        Timedisplaypast.DropShadow = true;
        //        Timedisplayf.Draw();
        //        Timedisplaypres.Draw();
        //        Timedisplaypast.Draw();
        //    }

        //}

        #endregion
    }
}

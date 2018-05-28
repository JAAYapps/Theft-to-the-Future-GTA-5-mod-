using GTA;
using GTA.Native;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTTF_TimeTravel_0._9._0
{
    class Doors
    {
        static bool ice = false;
        static bool doorisopen = false;
        static bool doorisopen2 = false;
        static bool doorisclosed = true;
        static bool doorisclosed2 = true;
        static bool closeactive = false;

        public static void doors(bool enabled, Vehicle delorean, bool doorDebug)
        {
            if (enabled)
            {
                int door = (int)Math.Round(Function.Call<float>(Hash.GET_VEHICLE_DOOR_ANGLE_RATIO, delorean, 0) * 10);
                int door2 = (int)Math.Round(Function.Call<float>(Hash.GET_VEHICLE_DOOR_ANGLE_RATIO, delorean, 1) * 10);

                if (doorDebug)
                {
                    UIText Instruct = new UIText("door: " + door + " door2 " + door2, new Point(400, 300), (float)0.9);
                    Instruct.Draw();
                }

                if (door != 0)
                {
                    if (!doorisopen)
                    {
                        if (ice)
                            Sounds.doorcold.Play();
                        Sounds.dooropen.Play();
                    }
                    doorisopen = true;
                    if (door >= 9)
                        closeactive = true;
                }
                else
                {
                    doorisopen = false;
                }
                if (door2 != 0)
                {
                    if (!doorisopen2)
                    {
                        if (ice)
                            Sounds.doorcold.Play();
                        Sounds.dooropen.Play();
                    }
                    doorisopen2 = true;
                    if (door2 >= 9)
                        closeactive = true;
                }
                else
                {
                    doorisopen2 = false;
                }

                if (closeactive)
                {
                    if (door < 8)
                    {
                        if (!doorisclosed)
                        {
                            if (ice)
                                Sounds.doorcold.Play();
                            Sounds.doorclose.Play();
                            closeactive = false;
                        }
                        doorisclosed = true;
                    }
                    else
                    {
                        doorisclosed = false;
                    }
                    if (door2 < 8)
                    {
                        if (!doorisclosed2)
                        {
                            if (ice)
                                Sounds.doorcold.Play();
                            Sounds.doorclose.Play();
                            closeactive = false;
                        }
                        doorisclosed2 = true;
                    }
                    else
                    {
                        doorisclosed2 = false;
                    }
                }
            }
        }

        public static void doorswithwait(bool enabled, bool ice, Vehicle delorean, bool doorDebug, int wait)
        {
            for (int i = 0; i <= wait; i++)
            {
                if (enabled)
                {
                    int door = (int)Math.Round(Function.Call<float>(Hash.GET_VEHICLE_DOOR_ANGLE_RATIO, delorean, 0) * 10);
                    int door2 = (int)Math.Round(Function.Call<float>(Hash.GET_VEHICLE_DOOR_ANGLE_RATIO, delorean, 1) * 10);

                    if (doorDebug)
                    {
                        UIText Instruct = new UIText("door: " + door + " door2 " + door2, new Point(400, 300), (float)0.9);
                        Instruct.Draw();
                    }

                    if (door != 0)
                    {
                        if (!doorisopen)
                        {
                            if (ice)
                                Sounds.doorcold.Play();
                            Sounds.dooropen.Play();
                        }
                        doorisopen = true;
                        if (door >= 9)
                            closeactive = true;
                    }
                    else
                    {
                        doorisopen = false;
                    }
                    if (door2 != 0)
                    {
                        if (!doorisopen2)
                        {
                            if (ice)
                                Sounds.doorcold.Play();
                            Sounds.dooropen.Play();
                        }
                        doorisopen2 = true;
                        if (door2 >= 9)
                            closeactive = true;
                    }
                    else
                    {
                        doorisopen2 = false;
                    }

                    if (closeactive)
                    {
                        if (door < 8)
                        {
                            if (!doorisclosed)
                            {
                                if (ice)
                                    Sounds.doorcold.Play();
                                Sounds.doorclose.Play();
                                closeactive = false;
                            }
                            doorisclosed = true;
                        }
                        else
                        {
                            doorisclosed = false;
                        }
                        if (door2 < 8)
                        {
                            if (!doorisclosed2)
                            {
                                if (ice)
                                    Sounds.doorcold.Play();
                                Sounds.doorclose.Play();
                                closeactive = false;
                            }
                            doorisclosed2 = true;
                        }
                        else
                        {
                            doorisclosed2 = false;
                        }
                    }
                }
                Script.Wait(1);
            }          
        }
    }
}

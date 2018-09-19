using GTA;
using GTA.Native;

namespace TTTF_TimeTravel_0._9._0
{
    class Delorean
    {
        Vehicle car = null;
        Ped rcMode = null;
        Ped playermemory = null;
        public bool timeTraveled = false;
        public bool flyingison = false;
        public bool RCmode = false;
        bool RCmodeactive = true;
        public bool RCInvisible = false;
        public void ToggleRCmode()
        {
            string error = "";
            try
            {
                error = "rcmode negate";
                RCmode = !RCmode;
                if (RCmode)
                {
                    Sounds.RCcontrolstart.Play();
                    error = "rcactive check";
                    if (RCmodeactive)
                    {
                        error = "car check";
                        if (!car.IsSeatFree(VehicleSeat.Driver))
                        {
                            error = "wait to player = playermemory";
                            while (playermemory != Game.Player.Character)
                                playermemory = Game.Player.Character;
                            error = "get driver";
                            rcMode = car.GetPedOnSeat(VehicleSeat.Driver);
                            rcMode.CanBeDraggedOutOfVehicle = true;
                            error = "change player";
                            Function.Call(Hash.CHANGE_PLAYER_PED, Game.Player, rcMode, true, true);
                            RCmodeactive = false;
                        }
                        else
                        {
                            error = "wait to player = playermemory";
                            while (playermemory != Game.Player.Character)
                            {
                                playermemory = Game.Player.Character;
                            }
                            playermemory.AddBlip();
                            playermemory.CurrentBlip.Color = BlipColor.Yellow;
                            error = "create driver";
                            rcMode = car.CreatePedOnSeat(VehicleSeat.Driver, Game.Player.Character.Model);
                            rcMode.IsVisible = false;
                            rcMode.CanBeDraggedOutOfVehicle = false;
                            error = "change player";
                            Function.Call(Hash.CHANGE_PLAYER_PED, Game.Player, rcMode, true, true);
                            RCmodeactive = false;
                        }
                    }
                }
                else if (!RCmode)
                {
                    Sounds.RCcontrolstop.Play();
                    car.EngineRunning = false;
                    if (rcMode != null)
                    {
                        if (Game.Player.Character == rcMode)
                        {
                            Function.Call(Hash.CHANGE_PLAYER_PED, Game.Player, playermemory, true, true);
                        }
                        RCmodeactive = true;
                        if (!rcMode.IsVisible)
                            rcMode.Delete();
                        rcMode = null;
                    }
                }
            }
            catch
            {
                while(true)
                {
                    UI.ShowSubtitle("Error: " + error);
                    RCmode = false;
                    Script.Wait(100);
                }
                
            }
        }
        public void timetravelentry()
        {
            pastday1 = presday1;
            pastday2 = presday2;
            pastmonth1 = presmonth1;
            pastmonth2 = presmonth2;
            pasty1 = presy1;
            pasty2 = presy2;
            pasty3 = presy3;
            pasty4 = presy4;
            pasth1 = presh1;
            pasth2 = presh2;
            pastm1 = presm1;
            pastm2 = presm2;
            pastampm = presampm;
            presday1 = fday1;
            presday2 = fday2;
            presmonth1 = fmonth1;
            presmonth2 = fmonth2;
            presy1 = fy1;
            presy2 = fy2;
            presy3 = fy3;
            presy4 = fy4;
            presh1 = fh1;
            presh2 = fh2;
            presm1 = fm1;
            presm2 = fm2;
            presampm = fampm;
        }
        public bool refilltimecurcuits = false;
        public bool toggletimecurcuits = false;
        public int datecount = 0;
        public bool deadplay = false;
        public bool bug = false;
        public Delorean(Vehicle currentvehicle)
        {
            car = currentvehicle;
            GTA.UI.ShowSubtitle("User: " + Game.Player.Character.CurrentVehicle.NumberPlate.Trim() + " temp: " + car.NumberPlate.Trim(), 5000);
        }

        public Delorean(Vehicle currectvehicle, bool refilled)
        {
            car = currectvehicle;
            refilltimecurcuits = refilled;
        }

        public Delorean(Vehicle currectvehicle, bool refilled, int day1 = 2, int day2 = 9, int month1 = 0, int month2 = 5
            , int y1 = 2, int y2 = 0, int y3 = 1, int y4 = 5, int h1 = 1
            , int h2 = 0, int m1 = 0, int m2 = 9)
        {
            car = currectvehicle;
            refilltimecurcuits = refilled;
            fday1 = day1;
            fday2 = day2;
            fmonth1 = month1;
            fmonth2 = month2;
            fy1 = y1;
            fy2 = y2;
            fy3 = y3;
            fy4 = y4;
            fh1 = h1;
            fh2 = h2;
            fm1 = m1;
            fm2 = m2;
        }

        public Vehicle getDelorean()
        {
            return car;
        }

        public void setDelorean(Vehicle selectedCar)
        {
            if (selectedCar.FriendlyName == "DMC12")
                car = selectedCar;
        }

        public int fday1 = 2, fday2 = 9, fmonth1 = 0, fmonth2 = 5
            , fy1 = 2, fy2 = 0, fy3 = 1, fy4 = 5, fh1 = 1
            , fh2 = 0, fm1 = 0, fm2 = 9, presday1 = 1, presday2 = 0
            , presmonth1 = 0, presmonth2 = 9, presy1 = 1, presy2 = 9
            , presy3 = 9, presy4 = 5, presh1 = 0, presh2 = 6
            , presm1 = 1, presm2 = 1, pastday1 = 3, pastday2 = 0
            , pastmonth1 = 1, pastmonth2 = 0, pasty1 = 1, pasty2 = 9
            , pasty3 = 9, pasty4 = 5, pasth1 = 1, pasth2 = 2, pastm1 = 4, pastm2 = 6;
        public string fampm = "am", presampm = "pm", pastampm = "am";

        public int tday1, tday2, tmonth1, tmonth2, ty1, ty2, ty3, ty4, th1, th2, tm1, tm2;
        public string tampm = "";

    }
}

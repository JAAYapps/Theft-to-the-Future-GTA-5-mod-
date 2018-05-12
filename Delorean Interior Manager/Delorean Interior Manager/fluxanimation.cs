using GTA;
using GTA.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delorean_Interior_Manager
{
    class fluxanimation
    {
        #region flux capcitor
        bool enabled = false;
        int fluxanim = 0;
        static List<Vehicle> Deloreans = new List<Vehicle>();
        bool timeonce = false;
        void flux_capcitor()
        {
            Vehicle[] bttf1s = World.GetAllVehicles("bttf");
            Vehicle[] bttf2s = World.GetAllVehicles("bttf2");
            Vehicle[] bttf2fs = World.GetAllVehicles("bttf2f");
            Vehicle[] bttf3s = World.GetAllVehicles("bttf3");
            Vehicle[] bttf3rrs = World.GetAllVehicles("bttf3rr");

            foreach(Vehicle car in bttf1s)
            {
                if (!Deloreans.Contains(car))
                {
                    Deloreans.Add(car);
                }
            }
            foreach (Vehicle car in bttf2s)
            {
                if (!Deloreans.Contains(car))
                {
                    Deloreans.Add(car);
                }
            }
            foreach (Vehicle car in bttf2fs)
            {
                if (!Deloreans.Contains(car))
                {
                    Deloreans.Add(car);
                }
            }
            foreach (Vehicle car in bttf3s)
            {
                if (!Deloreans.Contains(car))
                {
                    Deloreans.Add(car);
                }
            }
            foreach (Vehicle car in bttf3rrs)
            {
                if (!Deloreans.Contains(car))
                {
                    Deloreans.Add(car);
                }
            }

            foreach (Vehicle Delorean in Deloreans)
            {
                if (!Delorean.Exists())

                if (enabled)
                {
                    if (DateTime.Now.Millisecond % 60 > 30 && DateTime.Now.Millisecond % 60 <= 60)
                    {
                        Function.Call(Hash.SET_VEHICLE_MOD_KIT, Delorean.Handle, 0);

                        if (!timeonce)
                        {
                            fluxanim++;

                            if (fluxanim == 8)
                            {
                                fluxanim = 0;
                                Delorean.SetMod(VehicleMod.Frame, 4, true);
                            }

                            if (fluxanim == 6)
                            {
                                Delorean.SetMod(VehicleMod.Frame, 3, true);
                            }

                            if (fluxanim == 4)
                            {
                                Delorean.SetMod(VehicleMod.Frame, 2, true);
                            }

                            if (fluxanim == 2)
                            {
                                Delorean.SetMod(VehicleMod.Frame, 1, true);
                            }

                            if (fluxanim == 0)
                            {
                                Delorean.SetMod(VehicleMod.Frame, 0, true);
                            }
                            timeonce = true;
                        }
                    }
                    else
                    {
                        timeonce = false;
                    }
                }
            }
        }
        #endregion
    }
}

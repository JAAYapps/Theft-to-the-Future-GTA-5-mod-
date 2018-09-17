using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTA;
using GTA.Math;
using GTA.Native;

namespace TTTF_TimeTravel_0._9._0
{
    class TuningParts : ITuningParts
    {
        public TuningParts(Vehicle dmc12)
        {
            this.dmc12 = dmc12;
        }

        public void AttachTurningParts()
        {
            dmc12.SetMod(VehicleMod.Spoilers, 0, true);
            dmc12.SetMod(VehicleMod.Horns, 16, true);
            dmc12.SetMod(VehicleMod.FrontBumper, 0, true);
            dmc12.SetMod(VehicleMod.Exhaust, 1, true);
            dmc12.SetMod(VehicleMod.SideSkirt, 0, true);
            dmc12.SetMod(VehicleMod.Hood, -1, true);
            dmc12.SetMod(VehicleMod.Tank, 0, true);
            dmc12.SetMod(VehicleMod.TrimDesign, 0, true);
            dmc12.SetMod(VehicleMod.SteeringWheels, 0, true);
            dmc12.SetMod(VehicleMod.Windows, 0, true);
            dmc12.SetMod(VehicleMod.ColumnShifterLevers, 0, true);
            dmc12.SetMod(VehicleMod.SteeringWheels, 0, true);
            dmc12.SetMod(VehicleMod.DialDesign, 0, true);
        }

        public Vehicle dmc12;
        public bool plutLightOnOff
        {
            get
            {
                if (plutLightOnOff)
                    dmc12.SetMod(VehicleMod.Frame, 0, true);
                else
                    dmc12.SetMod(VehicleMod.Frame, -1, true);
                return plutLightOnOff;
            }

            set { plutLightOnOff = value; }
        }

        public void EnableBands(Vehicle delorean)
        {
            Function.Call(Hash.SET_VEHICLE_MOD_KIT, delorean.Handle, 0);
            delorean.SetMod(VehicleMod.Spoilers, 1, true);
            delorean.SetMod(VehicleMod.SideSkirt, 0, true);
        }
    }
}

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

        public void initDisplay(Vehicle delorean, bool refilltimecurcuits, int fmonth1, int fmonth2, int fday1, int fday2, int fy1, int fy2, int fy3, int fy4, int fh1, int fh2, string fampm, int fm1, int fm2, int presmonth1, int presmonth2, int presday1, int presday2, int presy1, int presy2, int presy3, int presy4, int presh1, int presh2, string presampm, int presm1, int presm2, int pastmonth1, int pastmonth2, int pastday1, int pastday2, int pasty1, int pasty2, int pasty3, int pasty4, int pasth1, int pasth2, string pastampm, int pastm1, int pastm2, bool bug)
        {
            //tcd_month_yellow
            timecurcuitssystem.effectProps[delorean.NumberPlate.Trim()].SpawnProp(delorean, "aug_yellow", "tcd_month_yellow", delorean.GetBoneCoord("tcd_month_yellow"), new Vector3(0, 0, 0));
        }

        public void EnableBands(Vehicle delorean)
        {
            Function.Call(Hash.SET_VEHICLE_MOD_KIT, delorean.Handle, 0);
            delorean.SetMod(VehicleMod.Spoilers, 1, true);
            delorean.SetMod(VehicleMod.SideSkirt, 0, true);
        }
    }
}

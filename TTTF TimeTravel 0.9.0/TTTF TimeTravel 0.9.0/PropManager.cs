using GTA;
using GTA.Math;
using System.Collections.Generic;

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

        enum time
        {
            Future,
            Present,
            Past
        }

        List<Prop> fday1, fday2, fmonth, fy1, fy2, fy3, fy4, fh1, fh2, fm1, fm2, 
            presday1, presday2, presmonth, presy1, presy2, presy3, presy4, presh1, presh2, presm1, presm2, 
            pastday1, pastday2, pastmonth, pasty1, pasty2, pasty3, pasty4, pasth1, pasth2, pastm1, pastm2;
        List<Prop> fampm, presampm, pastampm;
        Prop collum;
        private List<Prop> getDigits(Vehicle delorean, string dummy, time displayType)
        {
            List<Prop> temp = new List<Prop>();
            for (int i = 0; i < 10; i++)
            {
                if (displayType == time.Present)
                    temp.Add(SpawnProp(delorean, "digit_" + i + "_green", dummy, Vector3.Zero, Vector3.Zero, true));
                if (displayType == time.Future)
                    temp.Add(SpawnProp(delorean, "digit_" + i + "_red", dummy, Vector3.Zero, Vector3.Zero, true));
                if (displayType == time.Past)
                    temp.Add(SpawnProp(delorean, "digit_" + i + "_yellow", dummy, Vector3.Zero, Vector3.Zero, true));
                Script.Wait(1);
            }

            return temp;
        }

        public void initDisplay(Vehicle delorean)
        {
            fmonth.Add(SpawnProp(delorean, "jan_red", "tcd_month_red", Vector3.Zero, Vector3.Zero, true));
            fmonth.Add(SpawnProp(delorean, "feb_red", "tcd_month_red", Vector3.Zero, Vector3.Zero, true));
            fmonth.Add(SpawnProp(delorean, "mar_red", "tcd_month_red", Vector3.Zero, Vector3.Zero, true));
            fmonth.Add(SpawnProp(delorean, "apr_red", "tcd_month_red", Vector3.Zero, Vector3.Zero, true));
            fmonth.Add(SpawnProp(delorean, "may_red", "tcd_month_red", Vector3.Zero, Vector3.Zero, true));
            fmonth.Add(SpawnProp(delorean, "jun_red", "tcd_month_red", Vector3.Zero, Vector3.Zero, true));
            fmonth.Add(SpawnProp(delorean, "jul_red", "tcd_month_red", Vector3.Zero, Vector3.Zero, true));
            fmonth.Add(SpawnProp(delorean, "aug_red", "tcd_month_red", Vector3.Zero, Vector3.Zero, true));
            fmonth.Add(SpawnProp(delorean, "sep_red", "tcd_month_red", Vector3.Zero, Vector3.Zero, true));
            fmonth.Add(SpawnProp(delorean, "oct_red", "tcd_month_red", Vector3.Zero, Vector3.Zero, true));
            fmonth.Add(SpawnProp(delorean, "nov_red", "tcd_month_red", Vector3.Zero, Vector3.Zero, true));
            fmonth.Add(SpawnProp(delorean, "dec_red", "tcd_month_red", Vector3.Zero, Vector3.Zero, true));

            fday1 = getDigits(delorean, "tcd_day1_red", time.Future);
            fday2 = getDigits(delorean, "tcd_day2_red", time.Future);
            fy1 = getDigits(delorean, "tcd_year1_red", time.Future);
            fy2 = getDigits(delorean, "tcd_year2_red", time.Future);
            fy3 = getDigits(delorean, "tcd_year3_red", time.Future);
            fy4 = getDigits(delorean, "tcd_year4_red", time.Future);
            fh1 = getDigits(delorean, "tcd_hour1_red", time.Future);
            fh2 = getDigits(delorean, "tcd_hour2_red", time.Future);
            fm1 = getDigits(delorean, "tcd_time1_red", time.Future);
            fm2 = getDigits(delorean, "tcd_time2_red", time.Future);
            fampm.Add(SpawnProp(delorean, "bttf_dest_am", "", Vector3.Zero, Vector3.Zero, true));
            fampm.Add(SpawnProp(delorean, "bttf_dest_pm", "", Vector3.Zero, Vector3.Zero, true));


            pastmonth.Add(SpawnProp(delorean, "jan_yellow", "tcd_month_yellow", Vector3.Zero, Vector3.Zero, true));
            pastmonth.Add(SpawnProp(delorean, "feb_yellow", "tcd_month_yellow", Vector3.Zero, Vector3.Zero, true));
            pastmonth.Add(SpawnProp(delorean, "mar_yellow", "tcd_month_yellow", Vector3.Zero, Vector3.Zero, true));
            pastmonth.Add(SpawnProp(delorean, "apr_yellow", "tcd_month_yellow", Vector3.Zero, Vector3.Zero, true));
            pastmonth.Add(SpawnProp(delorean, "may_yellow", "tcd_month_yellow", Vector3.Zero, Vector3.Zero, true));
            pastmonth.Add(SpawnProp(delorean, "jun_yellow", "tcd_month_yellow", Vector3.Zero, Vector3.Zero, true));
            pastmonth.Add(SpawnProp(delorean, "jul_yellow", "tcd_month_yellow", Vector3.Zero, Vector3.Zero, true));
            pastmonth.Add(SpawnProp(delorean, "aug_yellow", "tcd_month_yellow", Vector3.Zero, Vector3.Zero, true));
            pastmonth.Add(SpawnProp(delorean, "sep_yellow", "tcd_month_yellow", Vector3.Zero, Vector3.Zero, true));
            pastmonth.Add(SpawnProp(delorean, "oct_yellow", "tcd_month_yellow", Vector3.Zero, Vector3.Zero, true));
            pastmonth.Add(SpawnProp(delorean, "nov_yellow", "tcd_month_yellow", Vector3.Zero, Vector3.Zero, true));
            pastmonth.Add(SpawnProp(delorean, "dec_yellow", "tcd_month_yellow", Vector3.Zero, Vector3.Zero, true));

            pastday1 = getDigits(delorean, "tcd_day1_yellow", time.Past);
            pastday2 = getDigits(delorean, "tcd_day2_yellow", time.Past);
            pasty1 = getDigits(delorean, "tcd_year1_yellow", time.Past);
            pasty2 = getDigits(delorean, "tcd_year2_yellow", time.Past);
            pasty3 = getDigits(delorean, "tcd_year3_yellow", time.Past);
            pasty4 = getDigits(delorean, "tcd_year4_yellow", time.Past);
            pasth1 = getDigits(delorean, "tcd_hour1_yellow", time.Past);
            pasth2 = getDigits(delorean, "tcd_hour2_yellow", time.Past);
            pastm1 = getDigits(delorean, "tcd_time1_yellow", time.Past);
            pastm2 = getDigits(delorean, "tcd_time2_yellow", time.Past);
            pastampm.Add(SpawnProp(delorean, "bttf_pres_am", "", Vector3.Zero, Vector3.Zero, true));
            pastampm.Add(SpawnProp(delorean, "bttf_pres_pm", "", Vector3.Zero, Vector3.Zero, true));


            presmonth.Add(SpawnProp(delorean, "jan_green", "tcd_month_green", Vector3.Zero, Vector3.Zero, true));
            presmonth.Add(SpawnProp(delorean, "feb_green", "tcd_month_green", Vector3.Zero, Vector3.Zero, true));
            presmonth.Add(SpawnProp(delorean, "mar_green", "tcd_month_green", Vector3.Zero, Vector3.Zero, true));
            presmonth.Add(SpawnProp(delorean, "apr_green", "tcd_month_green", Vector3.Zero, Vector3.Zero, true));
            presmonth.Add(SpawnProp(delorean, "may_green", "tcd_month_green", Vector3.Zero, Vector3.Zero, true));
            presmonth.Add(SpawnProp(delorean, "jun_green", "tcd_month_green", Vector3.Zero, Vector3.Zero, true));
            presmonth.Add(SpawnProp(delorean, "jul_green", "tcd_month_green", Vector3.Zero, Vector3.Zero, true));
            presmonth.Add(SpawnProp(delorean, "aug_green", "tcd_month_green", Vector3.Zero, Vector3.Zero, true));
            presmonth.Add(SpawnProp(delorean, "sep_green", "tcd_month_green", Vector3.Zero, Vector3.Zero, true));
            presmonth.Add(SpawnProp(delorean, "oct_green", "tcd_month_green", Vector3.Zero, Vector3.Zero, true));
            presmonth.Add(SpawnProp(delorean, "nov_green", "tcd_month_green", Vector3.Zero, Vector3.Zero, true));
            presmonth.Add(SpawnProp(delorean, "dec_green", "tcd_month_green", Vector3.Zero, Vector3.Zero, true));

            presday1 = getDigits(delorean, "tcd_day1_green", time.Present);
            presday2 = getDigits(delorean, "tcd_day2_green", time.Present);
            presy1 = getDigits(delorean, "tcd_year1_green", time.Present);
            presy2 = getDigits(delorean, "tcd_year2_green", time.Present);
            presy3 = getDigits(delorean, "tcd_year3_green", time.Present);
            presy4 = getDigits(delorean, "tcd_year4_green", time.Present);
            presh1 = getDigits(delorean, "tcd_hour1_green", time.Present);
            presh2 = getDigits(delorean, "tcd_hour2_green", time.Present);
            presm1 = getDigits(delorean, "tcd_time1_green", time.Present);
            presm2 = getDigits(delorean, "tcd_time2_green", time.Present);
            presampm.Add(SpawnProp(delorean, "bttf_last_am", "", Vector3.Zero, Vector3.Zero, true));
            presampm.Add(SpawnProp(delorean, "bttf_last_pm", "", Vector3.Zero, Vector3.Zero, true));
        }

        private void showDigit(List<Prop> pdigit , int digit)
        {
            if (digit == 0)
            {
                pdigit[0].Alpha = 255;
                pdigit[1].Alpha = 0;
                pdigit[2].Alpha = 0;
                pdigit[3].Alpha = 0;
                pdigit[4].Alpha = 0;
                pdigit[5].Alpha = 0;
                pdigit[6].Alpha = 0;
                pdigit[7].Alpha = 0;
                pdigit[8].Alpha = 0;
                pdigit[9].Alpha = 0;
            }
            else if (digit == 1)
            {
                pdigit[0].Alpha = 0;
                pdigit[1].Alpha = 255;
                pdigit[2].Alpha = 0;
                pdigit[3].Alpha = 0;
                pdigit[4].Alpha = 0;
                pdigit[5].Alpha = 0;
                pdigit[6].Alpha = 0;
                pdigit[7].Alpha = 0;
                pdigit[8].Alpha = 0;
                pdigit[9].Alpha = 0;
            }
            else if (digit == 2)
            {
                pdigit[0].Alpha = 0;
                pdigit[1].Alpha = 0;
                pdigit[2].Alpha = 255;
                pdigit[3].Alpha = 0;
                pdigit[4].Alpha = 0;
                pdigit[5].Alpha = 0;
                pdigit[6].Alpha = 0;
                pdigit[7].Alpha = 0;
                pdigit[8].Alpha = 0;
                pdigit[9].Alpha = 0;
            }
            else if (digit == 3)
            {
                pdigit[0].Alpha = 0;
                pdigit[1].Alpha = 0;
                pdigit[2].Alpha = 0;
                pdigit[3].Alpha = 255;
                pdigit[4].Alpha = 0;
                pdigit[5].Alpha = 0;
                pdigit[6].Alpha = 0;
                pdigit[7].Alpha = 0;
                pdigit[8].Alpha = 0;
                pdigit[9].Alpha = 0;
            }
            else if (digit == 4)
            {
                pdigit[0].Alpha = 0;
                pdigit[1].Alpha = 0;
                pdigit[2].Alpha = 0;
                pdigit[3].Alpha = 0;
                pdigit[4].Alpha = 255;
                pdigit[5].Alpha = 0;
                pdigit[6].Alpha = 0;
                pdigit[7].Alpha = 0;
                pdigit[8].Alpha = 0;
                pdigit[9].Alpha = 0;
            }
            else if (digit == 5)
            {
                pdigit[0].Alpha = 0;
                pdigit[1].Alpha = 0;
                pdigit[2].Alpha = 0;
                pdigit[3].Alpha = 0;
                pdigit[4].Alpha = 0;
                pdigit[5].Alpha = 255;
                pdigit[6].Alpha = 0;
                pdigit[7].Alpha = 0;
                pdigit[8].Alpha = 0;
                pdigit[9].Alpha = 0;
            }
            else if (digit == 6)
            {
                pdigit[0].Alpha = 0;
                pdigit[1].Alpha = 0;
                pdigit[2].Alpha = 0;
                pdigit[3].Alpha = 0;
                pdigit[4].Alpha = 0;
                pdigit[5].Alpha = 0;
                pdigit[6].Alpha = 255;
                pdigit[7].Alpha = 0;
                pdigit[8].Alpha = 0;
                pdigit[9].Alpha = 0;
            }
            else if (digit == 7)
            {
                pdigit[0].Alpha = 0;
                pdigit[1].Alpha = 0;
                pdigit[2].Alpha = 0;
                pdigit[3].Alpha = 0;
                pdigit[4].Alpha = 0;
                pdigit[5].Alpha = 0;
                pdigit[6].Alpha = 0;
                pdigit[7].Alpha = 255;
                pdigit[8].Alpha = 0;
                pdigit[9].Alpha = 0;
            }
            else if (digit == 8)
            {
                pdigit[0].Alpha = 0;
                pdigit[1].Alpha = 0;
                pdigit[2].Alpha = 0;
                pdigit[3].Alpha = 0;
                pdigit[4].Alpha = 0;
                pdigit[5].Alpha = 0;
                pdigit[6].Alpha = 0;
                pdigit[7].Alpha = 0;
                pdigit[8].Alpha = 255;
                pdigit[9].Alpha = 0;
            }
            else if (digit == 9)
            {
                pdigit[0].Alpha = 0;
                pdigit[1].Alpha = 0;
                pdigit[2].Alpha = 0;
                pdigit[3].Alpha = 0;
                pdigit[4].Alpha = 0;
                pdigit[5].Alpha = 0;
                pdigit[6].Alpha = 0;
                pdigit[7].Alpha = 0;
                pdigit[8].Alpha = 0;
                pdigit[9].Alpha = 255;
            }
        }

        private void showMonth(List<Prop> pmonth, int digit)
        {
            if (digit == 0)
            {
                pmonth[0].Alpha = 255;
                pmonth[1].Alpha = 0;
                pmonth[2].Alpha = 0;
                pmonth[3].Alpha = 0;
                pmonth[4].Alpha = 0;
                pmonth[5].Alpha = 0;
                pmonth[6].Alpha = 0;
                pmonth[7].Alpha = 0;
                pmonth[8].Alpha = 0;
                pmonth[9].Alpha = 0;
                pmonth[10].Alpha = 0;
                pmonth[11].Alpha = 0;
            }
            else if (digit == 1)
            {
                pmonth[0].Alpha = 0;
                pmonth[1].Alpha = 255;
                pmonth[2].Alpha = 0;
                pmonth[3].Alpha = 0;
                pmonth[4].Alpha = 0;
                pmonth[5].Alpha = 0;
                pmonth[6].Alpha = 0;
                pmonth[7].Alpha = 0;
                pmonth[8].Alpha = 0;
                pmonth[9].Alpha = 0;
                pmonth[10].Alpha = 0;
                pmonth[11].Alpha = 0;
            }
            else if (digit == 2)
            {
                pmonth[0].Alpha = 0;
                pmonth[1].Alpha = 0;
                pmonth[2].Alpha = 255;
                pmonth[3].Alpha = 0;
                pmonth[4].Alpha = 0;
                pmonth[5].Alpha = 0;
                pmonth[6].Alpha = 0;
                pmonth[7].Alpha = 0;
                pmonth[8].Alpha = 0;
                pmonth[9].Alpha = 0;
                pmonth[10].Alpha = 0;
                pmonth[11].Alpha = 0;
            }
            else if (digit == 3)
            {
                pmonth[0].Alpha = 0;
                pmonth[1].Alpha = 0;
                pmonth[2].Alpha = 0;
                pmonth[3].Alpha = 255;
                pmonth[4].Alpha = 0;
                pmonth[5].Alpha = 0;
                pmonth[6].Alpha = 0;
                pmonth[7].Alpha = 0;
                pmonth[8].Alpha = 0;
                pmonth[9].Alpha = 0;
                pmonth[10].Alpha = 0;
                pmonth[11].Alpha = 0;
            }
            else if (digit == 4)
            {
                pmonth[0].Alpha = 0;
                pmonth[1].Alpha = 0;
                pmonth[2].Alpha = 0;
                pmonth[3].Alpha = 0;
                pmonth[4].Alpha = 255;
                pmonth[5].Alpha = 0;
                pmonth[6].Alpha = 0;
                pmonth[7].Alpha = 0;
                pmonth[8].Alpha = 0;
                pmonth[9].Alpha = 0;
                pmonth[10].Alpha = 0;
                pmonth[11].Alpha = 0;
            }
            else if (digit == 5)
            {
                pmonth[0].Alpha = 0;
                pmonth[1].Alpha = 0;
                pmonth[2].Alpha = 0;
                pmonth[3].Alpha = 0;
                pmonth[4].Alpha = 0;
                pmonth[5].Alpha = 255;
                pmonth[6].Alpha = 0;
                pmonth[7].Alpha = 0;
                pmonth[8].Alpha = 0;
                pmonth[9].Alpha = 0;
                pmonth[10].Alpha = 0;
                pmonth[11].Alpha = 0;
            }
            else if (digit == 6)
            {
                pmonth[0].Alpha = 0;
                pmonth[1].Alpha = 0;
                pmonth[2].Alpha = 0;
                pmonth[3].Alpha = 0;
                pmonth[4].Alpha = 0;
                pmonth[5].Alpha = 0;
                pmonth[6].Alpha = 255;
                pmonth[7].Alpha = 0;
                pmonth[8].Alpha = 0;
                pmonth[9].Alpha = 0;
                pmonth[10].Alpha = 0;
                pmonth[11].Alpha = 0;
            }
            else if (digit == 7)
            {
                pmonth[0].Alpha = 0;
                pmonth[1].Alpha = 0;
                pmonth[2].Alpha = 0;
                pmonth[3].Alpha = 0;
                pmonth[4].Alpha = 0;
                pmonth[5].Alpha = 0;
                pmonth[6].Alpha = 0;
                pmonth[7].Alpha = 255;
                pmonth[8].Alpha = 0;
                pmonth[9].Alpha = 0;
                pmonth[10].Alpha = 0;
                pmonth[11].Alpha = 0;
            }
            else if (digit == 8)
            {
                pmonth[0].Alpha = 0;
                pmonth[1].Alpha = 0;
                pmonth[2].Alpha = 0;
                pmonth[3].Alpha = 0;
                pmonth[4].Alpha = 0;
                pmonth[5].Alpha = 0;
                pmonth[6].Alpha = 0;
                pmonth[7].Alpha = 0;
                pmonth[8].Alpha = 255;
                pmonth[9].Alpha = 0;
                pmonth[10].Alpha = 0;
                pmonth[11].Alpha = 0;
            }
            else if (digit == 9)
            {
                pmonth[0].Alpha = 0;
                pmonth[1].Alpha = 0;
                pmonth[2].Alpha = 0;
                pmonth[3].Alpha = 0;
                pmonth[4].Alpha = 0;
                pmonth[5].Alpha = 0;
                pmonth[6].Alpha = 0;
                pmonth[7].Alpha = 0;
                pmonth[8].Alpha = 0;
                pmonth[9].Alpha = 255;
                pmonth[10].Alpha = 0;
                pmonth[11].Alpha = 0;
            }
            else if (digit == 10)
            {
                pmonth[0].Alpha = 0;
                pmonth[1].Alpha = 0;
                pmonth[2].Alpha = 0;
                pmonth[3].Alpha = 0;
                pmonth[4].Alpha = 0;
                pmonth[5].Alpha = 0;
                pmonth[6].Alpha = 0;
                pmonth[7].Alpha = 0;
                pmonth[8].Alpha = 0;
                pmonth[9].Alpha = 0;
                pmonth[10].Alpha = 255;
                pmonth[11].Alpha = 0;
            }
            else if (digit == 11)
            {
                pmonth[0].Alpha = 0;
                pmonth[1].Alpha = 0;
                pmonth[2].Alpha = 0;
                pmonth[3].Alpha = 0;
                pmonth[4].Alpha = 0;
                pmonth[5].Alpha = 0;
                pmonth[6].Alpha = 0;
                pmonth[7].Alpha = 0;
                pmonth[8].Alpha = 0;
                pmonth[9].Alpha = 0;
                pmonth[10].Alpha = 0;
                pmonth[11].Alpha = 255;
            }
        }

        public void Display(Vehicle delorean, bool refilltimecurcuits, int fmonth1, int fmonth2, int fday1, int fday2, int fy1, int fy2, int fy3, int fy4, int fh1, int fh2, string fampm, int fm1, int fm2, int presmonth1, int presmonth2, int presday1, int presday2, int presy1, int presy2, int presy3, int presy4, int presh1, int presh2, string presampm, int presm1, int presm2, int pastmonth1, int pastmonth2, int pastday1, int pastday2, int pasty1, int pasty2, int pasty3, int pasty4, int pasth1, int pasth2, string pastampm, int pastm1, int pastm2, bool bug)
        {
            if (refilltimecurcuits)
            {
                if (bug)
                {
                    showMonth(fmonth, ((fmonth1 * 10) + fmonth2) - 1);
                    showDigit(this.fday1, fday1);
                    showDigit(this.fday2, fday2);
                    showDigit(this.fy1, fy1);
                    showDigit(this.fy2, fy2);
                    showDigit(this.fy3, fy3);
                    showDigit(this.fy4, fy4);
                    showDigit(this.fh1, fh1);
                    showDigit(this.fh1, fh2);
                    showDigit(this.fm1, fm1);
                    showDigit(this.fm2, fm2);
                }

                showMonth(presmonth, ((presmonth1 * 10) + presmonth2) - 1);
                showDigit(this.presday1, presday1);
                showDigit(this.presday2, presday2);
                showDigit(this.presy1, presy1);
                showDigit(this.presy2, presy2);
                showDigit(this.presy3, presy3);
                showDigit(this.presy4, presy4);
                showDigit(this.presh1, presh1);
                showDigit(this.presh1, presh1);
                showDigit(this.presm1, presm1);
                showDigit(this.presm2, presm2);

                showMonth(pastmonth, ((pastmonth1 * 10) + pastmonth2) - 1);
                showDigit(this.pastday1, pastday1);
                showDigit(this.pastday2, pastday2);
                showDigit(this.pasty1, pasty1);
                showDigit(this.pasty2, pasty2);
                showDigit(this.pasty3, pasty3);
                showDigit(this.pasty4, pasty4);
                showDigit(this.pasth1, pasth1);
                showDigit(this.pasth1, pasth1);
                showDigit(this.pastm1, pastm1);
                showDigit(this.pastm2, pastm2);
            }

            //tcd_month_yellow
            //timecurcuitssystem.effectProps[delorean.NumberPlate.Trim()].SpawnProp(delorean, "aug_yellow", "tcd_month_yellow", delorean.GetBoneCoord("tcd_month_yellow"), new Vector3(0, 0, 0));
        }


        public Prop SpawnProp(Vehicle dmc12, string propName, string dummy, Vector3 pos, Vector3 rot, bool dates = false)
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
                    prop.AttachTo(dmc12, 0, boneOffset, new Vector3(dmc12.Rotation.X , dmc12.Rotation.Y, dmc12.Rotation.Z));
                    return prop;
                }

                if (propName.Equals("bttf_icebody"))
                {
                    ice = prop;
                    ice.Alpha = 0;
                    prop.AttachTo(dmc12, 0, Vector3.Zero, Vector3.Zero);
                    return prop;
                }

                if (dates)
                {
                    prop.Alpha = 0;
                }

                prop.AttachTo(dmc12, 0, boneOffset, new Vector3(dmc12.Rotation.X + rot.X, dmc12.Rotation.Y + rot.Y, dmc12.Rotation.Z + rot.Z));
                return prop;
            }
            else
            {
                UI.Notify(" Does not exist");
                return null;
            }
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

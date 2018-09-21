using GTA;
using GTA.Math;
using System;
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

        Prop fday1, fday2, fmonth, fy1, fy2, fy3, fy4, fh1, fh2, fm1, fm2, 
            presday1, presday2, presmonth, presy1, presy2, presy3, presy4, presh1, presh2, presm1, presm2, 
            pastday1, pastday2, pastmonth, pasty1, pasty2, pasty3, pasty4, pasth1, pasth2, pastm1, pastm2;
        Prop fampm, fampm2, presampm, presampm2, pastampm, pastampm2;
        //Prop collum;
        private Prop getDigits(Vehicle delorean, string dummy, int index, time displayType)
        {
            Prop temp = null;

            if (displayType == time.Present)
                temp = (SpawnProp(delorean, "digit_" + index + "_green", dummy, Vector3.Zero, Vector3.Zero));
            if (displayType == time.Future)
                temp = (SpawnProp(delorean, "digit_" + index + "_red", dummy, Vector3.Zero, Vector3.Zero));
            if (displayType == time.Past)
                temp = (SpawnProp(delorean, "digit_" + index + "_yellow", dummy, Vector3.Zero, Vector3.Zero));

            return temp;
        }

        string[] fmonthstr = new string[] {"jan_red", "feb_red", "mar_red", "apr_red", "may_red", "jun_red", "jul_red", "aug_red", "sep_red", "oct_red", "nov_red", "dec_red"};
        string[] presmonthstr = new string[] {"jan_green", "feb_green", "mar_green", "apr_green", "may_green", "jun_green", "jul_green", "aug_green", "sep_green", "oct_green", "nov_green", "dec_green"};
        string[] pastmonthstr = new string[] {"jan_yellow", "feb_yellow", "mar_yellow", "apr_yellow", "may_yellow", "jun_yellow", "jul_yellow", "aug_yellow", "sep_yellow", "oct_yellow", "nov_yellow", "dec_yellow"};

        Random flicker = new Random();
        Random rdates = new Random();
        bool flickering = false;
        int deathLimit = 500000;
        bool ticktock = false;
        DateTime GenererateRandomDate()
        {

            int year = rdates.Next(1900, 9999);
            int month = rdates.Next(1, 12);
            int day = DateTime.DaysInMonth(year, month);
            int hour = rdates.Next(1, 12);
            int min = rdates.Next(1, 59);

            int Day = rdates.Next(1, day);

            DateTime dt = new DateTime(year, month, Day, hour, min, 0);
            return dt;
        }

        public int[] GetDigits(int num)
        {
            return new int[] { (num % 100) / 10, (num % 10) };
        }

        public int[] GetYearDigits(int num)
        {
            return new int[] { num / 1000, (num % 1000) / 100, (num % 100) / 10, (num % 10) };
        }

        public void dateError()
        {
            DateTime rdate = GenererateRandomDate();
            int[] day = GetDigits(rdate.Day);
            int[] month = GetDigits(rdate.Month);
            int[] year = GetYearDigits(rdate.Year);
            int[] hour = GetDigits(rdate.Hour);
            int fullHour = rdate.Hour;
            int[] min = GetDigits(rdate.Minute);
            timecurcuitssystem.Settime(day[0], day[1], month[0], month[1], year[0], year[1], year[2], year[3], hour[0], hour[1], min[0], min[1], fullHour > 11 ? "pm" : "am");
        }

        public void destError(bool bug)
        {
            int alpha = 0;
            if (!bug)
                alpha = 255;
            else
                alpha = 0;
            this.fmonth.Alpha = alpha;
            this.fday1.Alpha = alpha;
            this.fday2.Alpha = alpha;
            this.fy1.Alpha = alpha;
            this.fy2.Alpha = alpha;
            this.fy3.Alpha = alpha;
            this.fy4.Alpha = alpha;
            this.fh1.Alpha = alpha;
            this.fh2.Alpha = alpha;
            this.fm1.Alpha = alpha;
            this.fm2.Alpha = alpha;
            this.fampm.Alpha = alpha;
            this.fampm2.Alpha = alpha;
        }

        public void flickerTick(Delorean dmc12, int health, bool bug)
        {
            if (dmc12.toggletimecurcuits)
            {
                if (health < 100 || ((DateTime.Now.Millisecond > 250 && DateTime.Now.Millisecond < 500) || (DateTime.Now.Millisecond > 750 && DateTime.Now.Millisecond <= 1000)))
                {
                    if (health < 100)
                    {
                        deathLimit--;
                        if (deathLimit == 0)
                        {
                            flickering = false;
                            timecurcuitssystem.switchCircuits();
                            deathLimit = 100;
                        }
                        ticktock = false;
                    }
                    else
                        deathLimit = 100;

                    if (!ticktock)
                    {
                        if (flickering)
                        {
                            if (health < 300)
                            {
                                int alpha = 0;
                                if (!bug)
                                    alpha = flicker.Next(40, 150);
                                else
                                    alpha = 0;
                                if (health < 200)
                                    this.fmonth.Alpha = alpha;
                                if (!bug)
                                    alpha = flicker.Next(40, 150);
                                else
                                    alpha = 0;
                                if (health < 200)
                                    this.fday1.Alpha = alpha;
                                if (!bug)
                                    alpha = flicker.Next(40, 150);
                                else
                                    alpha = 0;
                                if (health < 200)
                                    this.fday2.Alpha = alpha;
                                if (!bug)
                                    alpha = flicker.Next(40, 150);
                                else
                                    alpha = 0;
                                if (health < 200)
                                    this.fy1.Alpha = alpha;
                                if (!bug)
                                    alpha = flicker.Next(40, 150);
                                else
                                    alpha = 0;
                                if (health < 200)
                                    this.fy2.Alpha = alpha;
                                if (!bug)
                                    alpha = flicker.Next(40, 150);
                                else
                                    alpha = 0;
                                if (health < 200)
                                    this.fy3.Alpha = alpha;
                                if (!bug)
                                    alpha = flicker.Next(40, 150);
                                else
                                    alpha = 0;
                                if (health < 200)
                                    this.fy4.Alpha = alpha;
                                if (!bug)
                                    alpha = flicker.Next(40, 150);
                                else
                                    alpha = 0;
                                if (health < 200)
                                    this.fh1.Alpha = alpha;
                                if (!bug)
                                    alpha = flicker.Next(40, 150);
                                else
                                    alpha = 0;
                                if (health < 200)
                                    this.fh2.Alpha = alpha;
                                if (!bug)
                                    alpha = flicker.Next(40, 150);
                                else
                                    alpha = 0;
                                if (health < 200)
                                    this.fm1.Alpha = alpha;
                                if (!bug)
                                    alpha = flicker.Next(40, 150);
                                else
                                    alpha = 0;
                                if (health < 200)
                                    this.fm2.Alpha = alpha;
                                if (!bug)
                                    alpha = flicker.Next(40, 150);
                                else
                                    alpha = 0;
                                if (health < 200)
                                    this.fampm.Alpha = alpha;
                                if (!bug)
                                    alpha = flicker.Next(40, 150);
                                else
                                    alpha = 0;
                                if (health < 200)
                                    this.fampm2.Alpha = alpha;
                                alpha = flicker.Next(40, 150);
                                this.pastmonth.Alpha = alpha;
                                alpha = flicker.Next(40, 150);
                                this.pastday1.Alpha = alpha;
                                alpha = flicker.Next(40, 150);
                                this.pastday2.Alpha = alpha;
                                alpha = flicker.Next(40, 150);
                                this.pasty1.Alpha = alpha;
                                alpha = flicker.Next(40, 150);
                                this.pasty2.Alpha = alpha;
                                alpha = flicker.Next(40, 150);
                                this.pasty3.Alpha = alpha;
                                alpha = flicker.Next(40, 150);
                                this.pasty4.Alpha = alpha;
                                alpha = flicker.Next(40, 150);
                                this.pasth1.Alpha = alpha;
                                alpha = flicker.Next(40, 150);
                                this.pasth2.Alpha = alpha;
                                alpha = flicker.Next(40, 150);
                                this.pastm1.Alpha = alpha;
                                alpha = flicker.Next(40, 150);
                                this.pastm2.Alpha = alpha;
                                alpha = flicker.Next(40, 150);
                                this.pastampm.Alpha = alpha;
                                alpha = flicker.Next(40, 150);
                                this.pastampm2.Alpha = alpha;
                                alpha = flicker.Next(40, 150);
                                this.presmonth.Alpha = alpha;
                                alpha = flicker.Next(40, 150);
                                this.presday1.Alpha = alpha;
                                alpha = flicker.Next(40, 150);
                                this.presday2.Alpha = alpha;
                                alpha = flicker.Next(40, 150);
                                this.presy1.Alpha = alpha;
                                alpha = flicker.Next(40, 150);
                                this.presy2.Alpha = alpha;
                                alpha = flicker.Next(40, 150);
                                this.presy3.Alpha = alpha;
                                alpha = flicker.Next(40, 150);
                                this.presy4.Alpha = alpha;
                                alpha = flicker.Next(40, 150);
                                this.presh1.Alpha = alpha;
                                alpha = flicker.Next(40, 150);
                                this.presh2.Alpha = alpha;
                                alpha = flicker.Next(40, 150);
                                this.presm1.Alpha = alpha;
                                alpha = flicker.Next(40, 150);
                                this.presm2.Alpha = alpha;
                                alpha = flicker.Next(40, 150);
                                this.presampm.Alpha = alpha;
                                alpha = flicker.Next(40, 150);
                                this.presampm2.Alpha = alpha;
                                UI.ShowSubtitle("flicker " + flickering + "random: " + alpha + " death limit: " + deathLimit);
                            }
                        }
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
            }
        }

        public void Display(Vehicle delorean, bool displayOn, bool engineOn, bool refilltimecurcuits, float body, int fmonth1, int fmonth2, int fday1, int fday2, int fy1, int fy2, int fy3, int fy4, int fh1, int fh2, string fampm, int fm1, int fm2, int presmonth1, int presmonth2, int presday1, int presday2, int presy1, int presy2, int presy3, int presy4, int presh1, int presh2, string presampm, int presm1, int presm2, int pastmonth1, int pastmonth2, int pastday1, int pastday2, int pasty1, int pasty2, int pasty3, int pasty4, int pasth1, int pasth2, string pastampm, int pastm1, int pastm2)
        {
            if (refilltimecurcuits && displayOn)
            {
                flickering = false;
                this.fmonth?.Delete();
                this.fday1?.Delete();
                this.fday2?.Delete();
                this.fy1?.Delete();
                this.fy2?.Delete();
                this.fy3?.Delete();
                this.fy4?.Delete();
                this.fh1?.Delete();
                this.fh2?.Delete();
                this.fm1?.Delete();
                this.fm2?.Delete();
                this.pastmonth?.Delete();
                this.pastday1?.Delete();
                this.pastday2?.Delete();
                this.pasty1?.Delete();
                this.pasty2?.Delete();
                this.pasty3?.Delete();
                this.pasty4?.Delete();
                this.pasth1?.Delete();
                this.pasth2?.Delete();
                this.pastm1?.Delete();
                this.pastm2?.Delete();
                this.presmonth?.Delete();
                this.presday1?.Delete();
                this.presday2?.Delete();
                this.presy1?.Delete();
                this.presy2?.Delete();
                this.presy3?.Delete();
                this.presy4?.Delete();
                this.presh1?.Delete();
                this.presh2?.Delete();
                this.presm1?.Delete();
                this.presm2?.Delete();
                this.fampm?.Delete();
                this.fampm2?.Delete();
                this.pastampm?.Delete();
                this.pastampm2?.Delete();
                this.presampm?.Delete();
                this.presampm2?.Delete();

                this.fmonth = SpawnProp(delorean, fmonthstr[((fmonth1 * 10) + fmonth2) - 1], "tcd_month_red", Vector3.Zero, Vector3.Zero);
                this.fday1 = getDigits(delorean, "tcd_day1_red", fday1, time.Future);
                this.fday2 = getDigits(delorean, "tcd_day2_red", fday2, time.Future);
                this.fy1 = getDigits(delorean, "tcd_year1_red", fy1, time.Future);
                this.fy2 = getDigits(delorean, "tcd_year2_red", fy2, time.Future);
                this.fy3 = getDigits(delorean, "tcd_year3_red", fy3, time.Future);
                this.fy4 = getDigits(delorean, "tcd_year4_red", fy4, time.Future);
                this.fh1 = getDigits(delorean, "tcd_hour1_red", fh1, time.Future);
                this.fh2 = getDigits(delorean, "tcd_hour2_red", fh2, time.Future);
                this.fm1 = getDigits(delorean, "tcd_time1_red", fm1, time.Future);
                this.fm2 = getDigits(delorean, "tcd_time2_red", fm2, time.Future);
                this.fampm = SpawnProp(delorean, "bttf_red_am", "", Vector3.Zero, Vector3.Zero);
                this.fampm2 = SpawnProp(delorean, "bttf_red_pm", "", Vector3.Zero, Vector3.Zero); 

                this.pastmonth = SpawnProp(delorean, pastmonthstr[((pastmonth1 * 10) + pastmonth2) - 1], "tcd_month_yellow", Vector3.Zero, Vector3.Zero);
                this.pastday1 = getDigits(delorean, "tcd_day1_yellow",pastday1, time.Past);
                this.pastday2 = getDigits(delorean, "tcd_day2_yellow",pastday2, time.Past);
                this.pasty1 = getDigits(delorean, "tcd_year1_yellow",pasty1, time.Past);
                this.pasty2 = getDigits(delorean, "tcd_year2_yellow",pasty2, time.Past);
                this.pasty3 = getDigits(delorean, "tcd_year3_yellow",pasty3, time.Past);
                this.pasty4 = getDigits(delorean, "tcd_year4_yellow",pasty4, time.Past);
                this.pasth1 = getDigits(delorean, "tcd_hour1_yellow",pasth1, time.Past);
                this.pasth2 = getDigits(delorean, "tcd_hour2_yellow",pasth2, time.Past);
                this.pastm1 = getDigits(delorean, "tcd_time1_yellow",pastm1, time.Past);
                this.pastm2 = getDigits(delorean, "tcd_time2_yellow",pastm2, time.Past);
                this.pastampm = SpawnProp(delorean, "bttf_yellow_am", "", Vector3.Zero, Vector3.Zero);
                this.pastampm2 = SpawnProp(delorean, "bttf_yellow_pm", "", Vector3.Zero, Vector3.Zero);

                this.presmonth = (SpawnProp(delorean, presmonthstr[((pastmonth1 * 10) + pastmonth2) - 1], "tcd_month_green", Vector3.Zero, Vector3.Zero));
                this.presday1 = getDigits(delorean, "tcd_day1_green",presday1, time.Present);
                this.presday2 = getDigits(delorean, "tcd_day2_green",presday2, time.Present);
                this.presy1 = getDigits(delorean, "tcd_year1_green",presy1, time.Present);
                this.presy2 = getDigits(delorean, "tcd_year2_green",presy2, time.Present);
                this.presy3 = getDigits(delorean, "tcd_year3_green",presy3, time.Present);
                this.presy4 = getDigits(delorean, "tcd_year4_green",presy4, time.Present);
                this.presh1 = getDigits(delorean, "tcd_hour1_green",presh1, time.Present);
                this.presh2 = getDigits(delorean, "tcd_hour2_green",presh2, time.Present);
                this.presm1 = getDigits(delorean, "tcd_time1_green",presm1, time.Present);
                this.presm2 = getDigits(delorean, "tcd_time2_green",presm2, time.Present);
                this.presampm = (SpawnProp(delorean, "bttf_green_am", "", Vector3.Zero, Vector3.Zero));
                this.presampm2  = (SpawnProp(delorean, "bttf_green_pm", "", Vector3.Zero, Vector3.Zero));

                if (body <= 300)
                {
                    flickering = true;
                }
                else
                {
                    if (!engineOn)
                    {
                        this.fmonth.Alpha = 150;
                        this.fday1.Alpha = 150;
                        this.fday2.Alpha = 150;
                        this.fy1.Alpha = 150;
                        this.fy2.Alpha = 150;
                        this.fy3.Alpha = 150;
                        this.fy4.Alpha = 150;
                        this.fh1.Alpha = 150;
                        this.fh2.Alpha = 150;
                        this.fm1.Alpha = 150;
                        this.fm2.Alpha = 150;
                        if (this.fampm != null)
                            this.fampm.Alpha = 150;
                        if (this.fampm2 != null)
                            this.fampm2.Alpha = 150;

                        this.pastmonth.Alpha = 150;
                        this.pastday1.Alpha = 150;
                        this.pastday2.Alpha = 150;
                        this.pasty1.Alpha = 150;
                        this.pasty2.Alpha = 150;
                        this.pasty3.Alpha = 150;
                        this.pasty4.Alpha = 150;
                        this.pasth1.Alpha = 150;
                        this.pasth2.Alpha = 150;
                        this.pastm1.Alpha = 150;
                        this.pastm2.Alpha = 150;
                        if (this.pastampm != null)
                            this.pastampm.Alpha = 150;
                        if (this.pastampm2 != null)
                            this.pastampm2.Alpha = 150;

                        this.presmonth.Alpha = 150;
                        this.presday1.Alpha = 150;
                        this.presday2.Alpha = 150;
                        this.presy1.Alpha = 150;
                        this.presy2.Alpha = 150;
                        this.presy3.Alpha = 150;
                        this.presy4.Alpha = 150;
                        this.presh1.Alpha = 150;
                        this.presh2.Alpha = 150;
                        this.presm1.Alpha = 150;
                        this.presm2.Alpha = 150;
                        if (this.presampm != null)
                            this.presampm.Alpha = 150;
                        if (this.presampm2 != null)
                            this.presampm2.Alpha = 150;
                    }
                    else
                    {
                        this.fmonth.Alpha = 255;
                        this.fday1.Alpha = 255;
                        this.fday2.Alpha = 255;
                        this.fy1.Alpha = 255;
                        this.fy2.Alpha = 255;
                        this.fy3.Alpha = 255;
                        this.fy4.Alpha = 255;
                        this.fh1.Alpha = 255;
                        this.fh2.Alpha = 255;
                        this.fm1.Alpha = 255;
                        this.fm2.Alpha = 255;
                        if (this.fampm != null)
                        {
                            if (fampm == "am")
                                this.fampm.Alpha = 255;
                            else
                                this.fampm.Alpha = 0;
                        }
                        if (this.fampm2 != null)
                        {
                            if (fampm == "pm")
                                this.fampm2.Alpha = 255;
                            else
                                this.fampm2.Alpha = 0;
                        }

                        this.pastmonth.Alpha = 255;
                        this.pastday1.Alpha = 255;
                        this.pastday2.Alpha = 255;
                        this.pasty1.Alpha = 255;
                        this.pasty2.Alpha = 255;
                        this.pasty3.Alpha = 255;
                        this.pasty4.Alpha = 255;
                        this.pasth1.Alpha = 255;
                        this.pasth2.Alpha = 255;
                        this.pastm1.Alpha = 255;
                        this.pastm2.Alpha = 255;
                        if (this.pastampm != null)
                        {
                            if (pastampm == "am")
                                this.pastampm.Alpha = 255;
                            else
                                this.pastampm.Alpha = 0;
                        }
                        if (this.pastampm2 != null)
                        {
                            if (pastampm == "pm")
                                this.pastampm2.Alpha = 255;
                            else
                                this.pastampm.Alpha = 0;
                        }

                        this.presmonth.Alpha = 255;
                        this.presday1.Alpha = 255;
                        this.presday2.Alpha = 255;
                        this.presy1.Alpha = 255;
                        this.presy2.Alpha = 255;
                        this.presy3.Alpha = 255;
                        this.presy4.Alpha = 255;
                        this.presh1.Alpha = 255;
                        this.presh2.Alpha = 255;
                        this.presm1.Alpha = 255;
                        this.presm2.Alpha = 255;
                        if (this.presampm != null)
                        {
                            if (presampm == "am")
                                this.presampm.Alpha = 255;
                            else
                                this.presampm.Alpha = 0;
                        }
                        if (this.presampm2 != null)
                        {
                            if (presampm == "pm")
                                this.presampm2.Alpha = 255;
                            else
                                this.presampm2.Alpha = 0;
                        }
                    }
                }
            }
            else
            {
                flickering = false;
                this.fmonth?.Delete();
                this.fday1?.Delete();
                this.fday2?.Delete();
                this.fy1?.Delete();
                this.fy2?.Delete();
                this.fy3?.Delete();
                this.fy4?.Delete();
                this.fh1?.Delete();
                this.fh2?.Delete();
                this.fm1?.Delete();
                this.fm2?.Delete();
                this.fampm?.Delete();
                this.fampm2?.Delete();

                this.pastmonth?.Delete();
                this.pastday1?.Delete();
                this.pastday2?.Delete();
                this.pasty1?.Delete();
                this.pasty2?.Delete();
                this.pasty3?.Delete();
                this.pasty4?.Delete();
                this.pasth1?.Delete();
                this.pasth2?.Delete();
                this.pastm1?.Delete();
                this.pastm2?.Delete();
                this.pastampm?.Delete();
                this.pastampm2?.Delete();

                this.presmonth?.Delete();
                this.presday1?.Delete();
                this.presday2?.Delete();
                this.presy1?.Delete();
                this.presy2?.Delete();
                this.presy3?.Delete();
                this.presy4?.Delete();
                this.presh1?.Delete();
                this.presh2?.Delete();
                this.presm1?.Delete();
                this.presm2?.Delete();
                this.presampm?.Delete();
                this.presampm2?.Delete();

            }
            //tcd_month_yellow
            //timecurcuitssystem.effectProps[delorean.NumberPlate.Trim()].SpawnProp(delorean, "aug_yellow", "tcd_month_yellow", delorean.GetBoneCoord("tcd_month_yellow"), new Vector3(0, 0, 0));
        }


        public Prop SpawnProp(Vehicle dmc12, string propName, string dummy, Vector3 pos, Vector3 rot)
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
                    prop.AttachTo(dmc12, 0, boneOffset, new Vector3(0, 0, 0));
                    return prop;
                }

                if (propName.Equals("bttf_icebody"))
                {
                    ice = prop;
                    ice.Alpha = 0;
                    prop.AttachTo(dmc12, 0, Vector3.Zero, Vector3.Zero);
                    return prop;
                }

                prop.AttachTo(dmc12, 0, boneOffset, new Vector3(rot.X, rot.Y, rot.Z));
                return prop;
            }
            else
            {
                UI.Notify(" Does not exist: " + propName);
                return null;
            }
        }

        public void loadWormhole(Vehicle dmc12)
        {
            UI.Notify("Loading props...");
            
            for (int i = 1; i < 76; i++)
            {
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
                    prop?.Delete();
            }

            foreach (var prop in wormholeProps)
            {
                if (prop != null)
                    prop?.Delete();
            }

            foreach (var prop in sparkProps)
            {
                if (prop != null)
                    prop?.Delete();
            }

            coilsProp?.Delete();
            ice?.Delete();
            this.fmonth?.Delete();
            this.fday1?.Delete();
            this.fday2?.Delete();
            this.fy1?.Delete();
            this.fy2?.Delete();
            this.fy3?.Delete();
            this.fy4?.Delete();
            this.fh1?.Delete();
            this.fh2?.Delete();
            this.fm1?.Delete();
            this.fm2?.Delete();
            this.pastmonth?.Delete();
            this.pastday1?.Delete();
            this.pastday2?.Delete();
            this.pasty1?.Delete();
            this.pasty2?.Delete();
            this.pasty3?.Delete();
            this.pasty4?.Delete();
            this.pasth1?.Delete();
            this.pasth2?.Delete();
            this.pastm1?.Delete();
            this.pastm2?.Delete();
            this.presmonth?.Delete();
            this.presday1?.Delete();
            this.presday2?.Delete();
            this.presy1?.Delete();
            this.presy2?.Delete();
            this.presy3?.Delete();
            this.presy4?.Delete();
            this.presh1?.Delete();
            this.presh2?.Delete();
            this.presm1?.Delete();
            this.presm2?.Delete();
            this.fampm?.Delete();
            this.fampm2?.Delete();
            this.pastampm?.Delete();
            this.pastampm2?.Delete();
            this.presampm?.Delete();
            this.presampm2?.Delete();
            this.licenseplate?.Delete();
        }


    }
}

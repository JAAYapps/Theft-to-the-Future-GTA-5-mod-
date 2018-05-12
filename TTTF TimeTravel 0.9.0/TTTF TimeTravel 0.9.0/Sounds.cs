using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TTTF_TimeTravel_0._9._0
{
    class Sounds
    {
        public static string sounds = Application.StartupPath + @"\scripts\bttf sounds\";
        public static void initialLoad()
        {
            reenterybttf2 = new soundplayer(sounds + "REENTRY_BTTF2.wav", false);
            reenterybttf3 = new soundplayer(sounds + "REENTRY_BTTF3.wav", false);
            RCcontrolstop = new soundplayer(sounds + "stop_RC_control.wav", false);
            num0 = new soundplayer(sounds + "0.wav", false);
            num1 = new soundplayer(sounds + "1.wav", false);
            num2 = new soundplayer(sounds + "2.wav", false);
            num3 = new soundplayer(sounds + "3.wav", false);
            num4 = new soundplayer(sounds + "4.wav", false);
            num5 = new soundplayer(sounds + "5.wav", false);
            num6 = new soundplayer(sounds + "6.wav", false);
            num7 = new soundplayer(sounds + "7.wav", false);
            num8 = new soundplayer(sounds + "8.wav", false);
            num9 = new soundplayer(sounds + "9.wav", false);
            inputerror = new soundplayer(sounds + "input enter error.wav", false);
            inputenter = new soundplayer(sounds + "input enter.wav", false);
            inputoff = new soundplayer(sounds + "input_off.wav", false);
            inputon = new soundplayer(sounds + "input_on.wav", false);
            inputonempty = new soundplayer(sounds + "emptyswitch.wav", false);
            cirerror = new soundplayer(sounds + "Error.wav", false);
            cirerrorbttf3 = new soundplayer(sounds + "Error_BTTF3.wav", false);
            inputenterbttf3 = new soundplayer(sounds + "input_enter_bttf3.wav", false);
            inputoffbttf3 = new soundplayer(sounds + "input_off_bttf3.wav", false);
            inputonbttf2error = new soundplayer(sounds + "input_on_bttf2_error.wav", false);
            inputonbttf3 = new soundplayer(sounds + "input_on_bttf3.wav", false);
            Beep = new soundplayer(sounds + "beep.wav", false);
            inputonfeul = new soundplayer(sounds + "input_on_fuel.wav", false);
            Mrfrusionfill = new soundplayer(sounds + "mrfusion.wav", false);
            hoveron = new soundplayer(sounds + "hover_on.wav", false);
            hoveroff = new soundplayer(sounds + "hover_off.wav", false);
            hoverboost = new soundplayer(sounds + "HoverBoost.wav", false);
            hoverup = new soundplayer(sounds + "HoverUp.wav", false);
            plate = new soundplayer(sounds + "plate.wav", false);
            pr0load = new soundplayer(sounds + "preload.wav", false);
            trend = new soundplayer(sounds + "trend.wav", false);
            cold = new soundplayer(sounds + "cold.wav", false);
            empty = new soundplayer(sounds + "empty.wav", false);
            engineoff = new soundplayer(sounds + "engine_off.wav", false);
            engineon = new soundplayer(sounds + "engine_on.wav", false);
            Lightningbttf2 = new soundplayer(sounds + "Lightning_bttf2.wav", false);
            Lightningcuttscene = new soundplayer(sounds + "time_travel_BTTF2_lightning_cutscene.wav", false);
            Timetravelreentery = new soundplayer(sounds + "time_travel.wav", false);
            Timetravelreentery2 = new soundplayer(sounds + "time_travel2.wav", false);
            Timetravelreentery2f = new soundplayer(sounds + "time_travel_BTTF2_flying.wav", false);
            Timetravelreentery3 = new soundplayer(sounds + "time_travel3.wav", false);
            Timetravelreenterycutscene = new soundplayer(sounds + "time_travel_BTTF2_cutscene.wav", false);
            Timetravelreenterycutscene3 = new soundplayer(sounds + "time_travel_BTTF3_cutscene.mp3", false);
            reenterybttf1 = new soundplayer(sounds + "REENTRY_BTTF1.wav", false);
            reenterybttf1incar = new soundplayer(sounds + "REENTRY_BTTF1_in_car.wav", false);
            reenterybttf2 = new soundplayer(sounds + "REENTRY_BTTF2.wav", false);
            reenterybttf3 = new soundplayer(sounds + "REENTRY_BTTF3.wav", false);
            sparks = new soundplayer(sounds + "sparks.wav", true);
            sparksbttf3 = new soundplayer(sounds + "sparks_bttf3.wav", true);
            sparksfeul = new soundplayer(sounds + "sparks_fuel.wav", false);
            RCcontrolstart = new soundplayer(sounds + "start_RC_control.wav", false);
            RCcontrol = new soundplayer(sounds + "RC_control.wav", false);
            RCcontrolhandbreak = new soundplayer(sounds + "RC_control_handbrake.wav", false);
            Vent = new soundplayer(sounds + "vent.wav", false);
            Plut = new soundplayer(sounds + "Plutonium.wav", false);
            trainenter = new soundplayer(sounds + "train_trail_1.wav", false);
            trainstart = new soundplayer(sounds + "train_trail_2.wav", false);
            greatscott = new soundplayer(sounds + "Great scott.wav", false);
            doorcold = new soundplayer(sounds + "door_cold.wav", false);
            dooropen = new soundplayer(sounds + "door_open.wav", false);
            doorclose = new soundplayer(sounds + "doorclose.wav", false);
            Intro = new soundplayer(sounds + "Intro.wav", false);
            DeloreonEnter = new soundplayer(sounds + "DeloreonEnterScene.wav", false);
            Experimentstart = new soundplayer(sounds + "YouMadeItScene.wav", false);
            Experimentstartintro = new soundplayer(sounds + "TestIntroScene.wav", false);
            Experimentstartwithremote = new soundplayer(sounds + "TestwithDogScene.wav", false);
            Experimentstartwithreentry = new soundplayer(sounds + "ReentryScene.wav", false);
            Experimentsuccess = new soundplayer(sounds + "Testsuccess.wav", false);
            Libeads = new soundplayer(sounds + "LibeadsenterScene.wav", false);
            Chasescene = new soundplayer(sounds + "ChaseScene.wav", false);
        }
        public static void unLoad()
        {
            reenterybttf2 = null;
            reenterybttf3 = null;
            RCcontrolstop = null;
            num0 = null;
            num1 = null;
            num2 = null;
            num3 = null;
            num4 = null;
            num5 = null;
            num6 = null;
            num7 = null;
            num8 = null;
            num9 = null;
            inputerror = null;
            inputenter = null;
            inputoff = null;
            inputon = null;
            inputonempty = null;
            cirerror = null;
            cirerrorbttf3 = null;
            inputenterbttf3 = null;
            inputoffbttf3 = null;
            inputonbttf2error = null;
            inputonbttf3 = null;
            Beep = null;
            inputonfeul = null;
            Mrfrusionfill = null;
            hoveron = null;
            hoveroff = null;
            hoverboost = null;
            hoverup = null;
            plate = null;
            pr0load = null;
            trend = null;
            cold = null;
            empty = null;
            engineoff = null;
            engineon = null;
            Lightningbttf2 = null;
            Lightningcuttscene = null;
            Timetravelreentery = null;
            Timetravelreentery2 = null;
            Timetravelreentery2f = null;
            Timetravelreentery3 = null;
            Timetravelreenterycutscene = null;
            Timetravelreenterycutscene3 = null;
            reenterybttf1 = null;
            reenterybttf1incar = null;
            reenterybttf2 = null;
            reenterybttf3 = null;
            sparks = null;
            sparksbttf3 = null;
            sparksfeul = null;
            RCcontrolstart = null;
            RCcontrol = null;
            RCcontrolhandbreak = null;
            Vent = null;
            Plut = null;
            trainenter = null;
            trainstart = null;
            greatscott = null;
            doorcold = null;
            dooropen = null;
            doorclose = null;
            Intro = null;
            DeloreonEnter = null;
            Experimentstart = null;
            Experimentstartintro = null;
            Experimentstartwithremote = null;
            Experimentstartwithreentry = null;
            Experimentsuccess = null;
            Libeads = null;
            Chasescene = null;
        }
        public static soundplayer RCcontrolstop;
        public static soundplayer testSound;

        #region All sounds
        #region Time Curcuits sounds
        static public soundplayer num0;
        static public soundplayer num1;
        static public soundplayer num2;
        static public soundplayer num3;
        static public soundplayer num4;
        static public soundplayer num5;
        static public soundplayer num6;
        static public soundplayer num7;
        static public soundplayer num8;
        static public soundplayer num9;
        static public soundplayer inputerror;
        static public soundplayer inputenter;
        static public soundplayer inputoff;
        static public soundplayer inputon;
        static public soundplayer inputonempty;
        static public soundplayer cirerror;
        static public soundplayer cirerrorbttf3;
        static public soundplayer inputenterbttf3;
        static public soundplayer inputoffbttf3;
        static public soundplayer inputonbttf2error;
        static public soundplayer inputonbttf3;
        public static soundplayer Beep;
        public static soundplayer inputonfeul;
        #endregion

        #region Timetravelsounds

        public static soundplayer Mrfrusionfill;
        public static soundplayer hoveron;
        public static soundplayer hoveroff;
        public static soundplayer hoverboost;
        public static soundplayer hoverup;
        public static soundplayer plate;
        public static soundplayer pr0load;
        public static soundplayer trend;
        public static soundplayer cold;
        public static soundplayer empty;
        public static soundplayer engineoff;
        public static soundplayer engineon;
        public static soundplayer Lightningbttf2;
        public static soundplayer Lightningcuttscene;
        public static soundplayer Timetravelreentery;
        public static soundplayer Timetravelreentery2;
        public static soundplayer Timetravelreentery2f;
        public static soundplayer Timetravelreentery3;
        public static soundplayer Timetravelreenterycutscene;
        public static soundplayer Timetravelreenterycutscene3;
        public static soundplayer reenterybttf1;
        public static soundplayer reenterybttf1incar;
        public static soundplayer reenterybttf2;
        public static soundplayer reenterybttf3;
        public static soundplayer sparks;
        public static soundplayer sparksbttf3;
        public static soundplayer sparksfeul;
        public static soundplayer RCcontrolstart;
        public static soundplayer RCcontrol;
        public static soundplayer RCcontrolhandbreak;
        public static soundplayer Vent;
        public static soundplayer Plut;
        public static soundplayer trainenter;
        public static soundplayer trainstart;
        public static soundplayer greatscott;
        //public static soundplayer speedp = new soundplayer(Variableclass.sounds + "speed_edit.mp3");
        #endregion

        #region Door sounds
        public static soundplayer doorcold;
        public static soundplayer dooropen;
        public static soundplayer doorclose;
        #endregion

        #region cutscenes
        public static soundplayer Intro;
        public static soundplayer DeloreonEnter;
        public static soundplayer Experimentstart;
        public static soundplayer Experimentstartintro;
        public static soundplayer Experimentstartwithremote;
        public static soundplayer Experimentstartwithreentry;
        public static soundplayer Experimentsuccess;
        public static soundplayer Libeads;
        public static soundplayer Chasescene;
        #endregion
        #endregion
    }
}

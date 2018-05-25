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
            reenterybttf2 = new System.Media.SoundPlayer(sounds + "REENTRY_BTTF2.wav");
            reenterybttf3 = new System.Media.SoundPlayer(sounds + "REENTRY_BTTF3.wav");
            RCcontrolstop = new System.Media.SoundPlayer(sounds + "stop_RC_control.wav");
            num0 = new System.Media.SoundPlayer(sounds + "0.wav");
            num1 = new System.Media.SoundPlayer(sounds + "1.wav");
            num2 = new System.Media.SoundPlayer(sounds + "2.wav");
            num3 = new System.Media.SoundPlayer(sounds + "3.wav");
            num4 = new System.Media.SoundPlayer(sounds + "4.wav");
            num5 = new System.Media.SoundPlayer(sounds + "5.wav");
            num6 = new System.Media.SoundPlayer(sounds + "6.wav");
            num7 = new System.Media.SoundPlayer(sounds + "7.wav");
            num8 = new System.Media.SoundPlayer(sounds + "8.wav");
            num9 = new System.Media.SoundPlayer(sounds + "9.wav");
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
            Beep = new System.Media.SoundPlayer(sounds + "beep.wav");
            inputonfeul = new System.Media.SoundPlayer(sounds + "input_on_fuel.wav");
            Mrfrusionfill = new soundplayer(sounds + "mrfusion.wav", false);
            hoveron = new System.Media.SoundPlayer(sounds + "hover_on.wav");
            hoveroff = new System.Media.SoundPlayer(sounds + "hover_off.wav");
            hoverboost = new soundplayer(sounds + "HoverBoost.wav", false);
            hoverup = new soundplayer(sounds + "HoverUp.wav", false);
            plate = new System.Media.SoundPlayer(sounds + "plate.wav");
            pr0load = new soundplayer(sounds + "preload.wav", false);
            trend = new System.Media.SoundPlayer(sounds + "trend.wav");
            cold = new soundplayer(sounds + "cold.wav");
            empty = new soundplayer(sounds + "empty.wav", false);
            engineoff = new soundplayer(sounds + "engine_off.wav", false);
            engineon = new soundplayer(sounds + "engine_on.wav", false);
            Lightningbttf2 = new soundplayer(sounds + "Lightning_bttf2.wav", false);
            Lightningcuttscene = new soundplayer(sounds + "time_travel_BTTF2_lightning_cutscene.wav", false);
            Timetravelreentery = new System.Media.SoundPlayer(sounds + "time_travel.wav");
            Timetravelreentery2 = new System.Media.SoundPlayer(sounds + "time_travel2.wav");
            Timetravelreentery2f = new System.Media.SoundPlayer(sounds + "time_travel_BTTF2_flying.wav");
            Timetravelreentery3 = new System.Media.SoundPlayer(sounds + "time_travel3.wav");
            Timetravelreenterycutscene = new System.Media.SoundPlayer(sounds + "time_travel_BTTF2_cutscene.wav");
            Timetravelreenterycutscene3 = new System.Media.SoundPlayer(sounds + "time_travel_BTTF3_cutscene.wav");
            reenterybttf1 = new System.Media.SoundPlayer(sounds + "REENTRY_BTTF1.wav");
            reenterybttf1incar = new System.Media.SoundPlayer(sounds + "REENTRY_BTTF1_in_car.wav");
            reenterybttf2 = new System.Media.SoundPlayer(sounds + "REENTRY_BTTF2.wav");
            reenterybttf3 = new System.Media.SoundPlayer(sounds + "REENTRY_BTTF3.wav");
            sparks = new soundplayer(sounds + "sparks.wav", true);
            sparksbttf3 = new soundplayer(sounds + "sparks_bttf3.wav", true);
            sparksfeul = new soundplayer(sounds + "sparks_fuel.wav", false);
            RCcontrolstart = new System.Media.SoundPlayer(sounds + "start_RC_control.wav");
            RCcontrol = new System.Media.SoundPlayer(sounds + "RC_control.wav");
            RCcontrolhandbreak = new System.Media.SoundPlayer(sounds + "RC_control_handbrake.wav");
            Vent = new soundplayer(sounds + "vent.wav", false);
            Plut = new System.Media.SoundPlayer(sounds + "Plutonium.wav");
            trainenter = new soundplayer(sounds + "train_trail_1.wav", false);
            trainstart = new soundplayer(sounds + "train_trail_2.wav", false);
            greatscott = new System.Media.SoundPlayer(sounds + "Great scott.wav");
            doorcold = new System.Media.SoundPlayer(sounds + "door_cold.wav");
            dooropen = new System.Media.SoundPlayer(sounds + "door_open.wav");
            doorclose = new System.Media.SoundPlayer(sounds + "doorclose.wav");
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
        public static System.Media.SoundPlayer RCcontrolstop;
        public static soundplayer testSound;

        #region All sounds
        #region Time Curcuits sounds
        static public System.Media.SoundPlayer num0;
        static public System.Media.SoundPlayer num1;
        static public System.Media.SoundPlayer num2;
        static public System.Media.SoundPlayer num3;
        static public System.Media.SoundPlayer num4;
        static public System.Media.SoundPlayer num5;
        static public System.Media.SoundPlayer num6;
        static public System.Media.SoundPlayer num7;
        static public System.Media.SoundPlayer num8;
        static public System.Media.SoundPlayer num9;
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
        public static System.Media.SoundPlayer Beep;
        public static System.Media.SoundPlayer inputonfeul;
        #endregion

        #region Timetravelsounds

        public static soundplayer Mrfrusionfill;
        public static System.Media.SoundPlayer hoveron;
        public static System.Media.SoundPlayer hoveroff;
        public static soundplayer hoverboost;
        public static soundplayer hoverup;
        public static System.Media.SoundPlayer plate;
        public static soundplayer pr0load;
        public static System.Media.SoundPlayer trend;
        public static soundplayer cold;
        public static soundplayer empty;
        public static soundplayer engineoff;
        public static soundplayer engineon;
        public static soundplayer Lightningbttf2;
        public static soundplayer Lightningcuttscene;
        public static System.Media.SoundPlayer Timetravelreentery;
        public static System.Media.SoundPlayer Timetravelreentery2;
        public static System.Media.SoundPlayer Timetravelreentery2f;
        public static System.Media.SoundPlayer Timetravelreentery3;
        public static System.Media.SoundPlayer Timetravelreenterycutscene;
        public static System.Media.SoundPlayer Timetravelreenterycutscene3;
        public static System.Media.SoundPlayer reenterybttf1;
        public static System.Media.SoundPlayer reenterybttf1incar;
        public static System.Media.SoundPlayer reenterybttf2;
        public static System.Media.SoundPlayer reenterybttf3;
        public static soundplayer sparks;
        public static soundplayer sparksbttf3;
        public static soundplayer sparksfeul;
        public static System.Media.SoundPlayer RCcontrolstart;
        public static System.Media.SoundPlayer RCcontrol;
        public static System.Media.SoundPlayer RCcontrolhandbreak;
        public static soundplayer Vent;
        public static System.Media.SoundPlayer Plut;
        public static soundplayer trainenter;
        public static soundplayer trainstart;
        public static System.Media.SoundPlayer greatscott;
        //public static soundplayer speedp = new soundplayer(Variableclass.sounds + "speed_edit.mp3");
        #endregion

        #region Door sounds
        public static System.Media.SoundPlayer doorcold;
        public static System.Media.SoundPlayer dooropen;
        public static System.Media.SoundPlayer doorclose;
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

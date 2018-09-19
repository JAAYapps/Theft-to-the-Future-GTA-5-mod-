using GTA;
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
        public static void initialLoad(bool remote)
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
            num8 = new System.Media.SoundPlayer(sounds + "8.wav"); Script.Wait(200);
            num9 = new System.Media.SoundPlayer(sounds + "9.wav"); Script.Wait(200);
            inputerror = new soundplayer(sounds + "input enter error.wav", remote); Script.Wait(200);
            inputenter = new soundplayer(sounds + "input enter.wav", remote); Script.Wait(200);
            inputoff = new soundplayer(sounds + "input_off.wav", remote); Script.Wait(200);
            inputon = new soundplayer(sounds + "input_on.wav", remote); Script.Wait(200);
            inputonempty = new soundplayer(sounds + "emptyswitch.wav", remote); Script.Wait(200);
            cirerror = new soundplayer(sounds + "Error.wav", remote); Script.Wait(200);
            cirerrorbttf3 = new soundplayer(sounds + "Error_BTTF3.wav", remote); Script.Wait(200);
            inputenterbttf3 = new soundplayer(sounds + "input_enter_bttf3.wav", remote); Script.Wait(200);
            inputoffbttf3 = new soundplayer(sounds + "input_off_bttf3.wav", remote); Script.Wait(200);
            inputonbttf2error = new soundplayer(sounds + "input_on_bttf2_error.wav", remote); Script.Wait(200);
            inputonbttf3 = new soundplayer(sounds + "input_on_bttf3.wav", remote); Script.Wait(200);
            Beep = new System.Media.SoundPlayer(sounds + "beep.wav"); Script.Wait(200);
            inputonfeul = new System.Media.SoundPlayer(sounds + "input_on_fuel.wav"); Script.Wait(200);
            Mrfrusionfill = new soundplayer(sounds + "mrfusion.wav", remote); Script.Wait(200);
            hoveron = new System.Media.SoundPlayer(sounds + "hover_on.wav"); Script.Wait(200);
            hoveroff = new System.Media.SoundPlayer(sounds + "hover_off.wav"); Script.Wait(200);
            hoverboost = new soundplayer(sounds + "HoverBoost.wav", remote); Script.Wait(200);
            hoverup = new soundplayer(sounds + "HoverUp.wav", remote); Script.Wait(200);
            plate = new System.Media.SoundPlayer(sounds + "plate.wav"); Script.Wait(200);
            pr0load = new soundplayer(sounds + "preload.wav", remote); Script.Wait(200);
            trend = new System.Media.SoundPlayer(sounds + "trend.wav"); Script.Wait(200);
            cold = new soundplayer(sounds + "cold.wav"); Script.Wait(200);
            empty = new soundplayer(sounds + "empty.wav", remote); Script.Wait(200);
            engineoff = new soundplayer(sounds + "engine_off.wav", remote); Script.Wait(200);
            engineon = new soundplayer(sounds + "engine_on.wav", remote); Script.Wait(200);
            Lightningbttf2 = new soundplayer(sounds + "Lightning_bttf2.wav", remote); Script.Wait(200);
            Lightningcuttscene = new soundplayer(sounds + "time_travel_BTTF2_lightning_cutscene.wav", remote); Script.Wait(200);
            Timetravelreentery = new System.Media.SoundPlayer(sounds + "time_travel.wav"); Script.Wait(200);
            Timetravelreentery2 = new System.Media.SoundPlayer(sounds + "time_travel2.wav"); Script.Wait(200);
            Timetravelreentery2f = new System.Media.SoundPlayer(sounds + "time_travel_BTTF2_flying.wav"); Script.Wait(200);
            Timetravelreentery3 = new System.Media.SoundPlayer(sounds + "time_travel3.wav"); Script.Wait(200);
            Timetravelreenterycutscene = new System.Media.SoundPlayer(sounds + "time_travel_BTTF2_cutscene.wav"); Script.Wait(200);
            Timetravelreenterycutscene3 = new System.Media.SoundPlayer(sounds + "time_travel_BTTF3_cutscene.wav"); Script.Wait(200);
            reenterybttf1 = new System.Media.SoundPlayer(sounds + "REENTRY_BTTF1.wav"); Script.Wait(200);
            reenterybttf1incar = new System.Media.SoundPlayer(sounds + "REENTRY_BTTF1_in_car.wav"); Script.Wait(200);
            reenterybttf2 = new System.Media.SoundPlayer(sounds + "REENTRY_BTTF2.wav"); Script.Wait(200);
            reenterybttf3 = new System.Media.SoundPlayer(sounds + "REENTRY_BTTF3.wav"); Script.Wait(200);
            sparks = new soundplayer(sounds + "sparks.wav", remote, true); Script.Wait(200);
            sparksbttf3 = new soundplayer(sounds + "sparks_bttf3.wav", remote, true); Script.Wait(200);
            sparksfeul = new soundplayer(sounds + "sparks_fuel.wav", remote); Script.Wait(200);
            RCcontrolstart = new System.Media.SoundPlayer(sounds + "start_RC_control.wav"); Script.Wait(200);
            RCcontrol = new System.Media.SoundPlayer(sounds + "RC_control.wav"); Script.Wait(200);
            RCcontrolhandbreak = new System.Media.SoundPlayer(sounds + "RC_control_handbrake.wav"); Script.Wait(200);
            Vent = new soundplayer(sounds + "vent.wav", remote); Script.Wait(200);
            Plut = new System.Media.SoundPlayer(sounds + "Plutonium.wav"); Script.Wait(200);
            trainenter = new soundplayer(sounds + "train_trail_1.wav", remote); Script.Wait(200);
            trainstart = new soundplayer(sounds + "train_trail_2.wav", remote); Script.Wait(200);
            greatscott = new System.Media.SoundPlayer(sounds + "Great scott.wav"); Script.Wait(200);
            doorcold = new System.Media.SoundPlayer(sounds + "door_cold.wav"); Script.Wait(200);
            dooropen = new System.Media.SoundPlayer(sounds + "door_open.wav"); Script.Wait(200);
            doorclose = new System.Media.SoundPlayer(sounds + "doorclose.wav"); Script.Wait(200);
            Intro = new soundplayer(sounds + "Intro.wav", remote); Script.Wait(200);
            DeloreonEnter = new soundplayer(sounds + "DeloreonEnterScene.wav", remote); Script.Wait(200);
            Experimentstart = new soundplayer(sounds + "YouMadeItScene.wav", remote); Script.Wait(200);
            Experimentstartintro = new soundplayer(sounds + "TestIntroScene.wav", remote); Script.Wait(200);
            Experimentstartwithremote = new soundplayer(sounds + "TestwithDogScene.wav", remote); Script.Wait(200);
            Experimentstartwithreentry = new soundplayer(sounds + "ReentryScene.wav", remote); Script.Wait(200);
            Experimentsuccess = new soundplayer(sounds + "Testsuccess.wav", remote); Script.Wait(200);
            Libeads = new soundplayer(sounds + "LibeadsenterScene.wav", remote); Script.Wait(200);
            Chasescene = new soundplayer(sounds + "ChaseScene.wav", remote); Script.Wait(200);
        }
        public static void unLoad()
        {
            inputerror?.remove();
            inputenter?.remove();
            inputoff?.remove();
            inputon?.remove();
            inputonempty?.remove();
            cirerror?.remove();
            cirerrorbttf3?.remove();
            inputenterbttf3?.remove();
            inputoffbttf3?.remove();
            inputonbttf2error?.remove();
            inputonbttf3?.remove();
            Mrfrusionfill?.remove();
            hoverboost?.remove();
            hoverup?.remove();
            pr0load?.remove();
            cold?.remove();
            empty?.remove();
            engineoff?.remove();
            engineon?.remove();
            Lightningbttf2?.remove();
            Lightningcuttscene?.remove();
            sparks?.remove();
            sparksbttf3?.remove();
            sparksfeul?.remove();
            Vent?.remove();
            trainenter?.remove();
            trainstart?.remove();
            Intro?.remove();
            DeloreonEnter?.remove();
            Experimentstart?.remove();
            Experimentstartintro?.remove();
            Experimentstartwithremote?.remove();
            Experimentstartwithreentry?.remove();
            Experimentsuccess?.remove();
            Libeads?.remove();
            Chasescene?.remove();

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

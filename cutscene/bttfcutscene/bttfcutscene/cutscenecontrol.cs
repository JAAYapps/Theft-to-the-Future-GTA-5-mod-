using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTA;
using GTA.Native;
using GTA.Math;
using GTA.NaturalMotion;
using System.Windows.Forms;

namespace bttfcutscene
{
    public class cutscenecontrol : Script
    {
        public cutscenecontrol()
        {
            try
            {
                //Game.FadeScreenIn(500);
                Interval = 0;
                Tick += onTick;
                KeyUp += onKeyUp;
                KeyDown += onKeyDown;
                //loadscriptsettings();
            }
            catch (Exception e)
            {
                while (true)
                {
                    UI.ShowSubtitle(e.Message);
                    Wait(10);
                }
            }
        }

        private void onKeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void onKeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void onTick(object sender, EventArgs e)
        {
            
        }
    }
}

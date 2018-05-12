using GTA;
using GTA.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Delorean_Interior_Manager
{
    public class main : Script
    {
        static string sounds = Application.StartupPath + @"\scripts\bttf sounds\";

        public main()
        {
            try
            {
                //Game.FadeScreenIn(500);
                Interval = 0;
                Tick += onTick;
                fluxsound = new soundplayer(sounds + "flux_capacitor.wav", true);
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

        bool enable = false;
        soundplayer fluxsound;
        private void onTick(object sender, EventArgs e)
        {
            if (enable)
            {
                if (Function.Call<int>(Hash.GET_FOLLOW_VEHICLE_CAM_VIEW_MODE) == 4)
                {
                    if (fluxsound.getPlayStateStopped())
                        fluxsound.Play();
                }
                else
                {
                    fluxsound.Stop();
                }
            }

            
        }
    }
}

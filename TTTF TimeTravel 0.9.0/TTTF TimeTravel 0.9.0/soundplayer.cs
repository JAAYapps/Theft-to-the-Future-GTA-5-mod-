using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GTA;
using NAudio;
using NAudio.Wave;
using VarispeedDemo.SoundTouch;

namespace TTTF_TimeTravel_0._9._0
{
    class soundplayer
    {
        localsoundplayer localsound;
        bool remote = false;
        public soundplayer(string Path = "", bool remoteSound = false, bool playloop = false)
        {
            soundpath = Path;
            playLoopBool = playloop;
            remote = remoteSound;

            if (!remoteSound)
            {
                localsound = new localsoundplayer(playloop);
                localsound.LoadFile(false, out int i, Path);
                localsound.Play();
                localsound.Stop();
            }
            else
            {
                if (!connectstart)
                {
                    client = new SimpleTCP.SimpleTcpClient();
                    client.StringEncoder = Encoding.UTF8;
                    //client.DataReceived += luancherdata;
                    client.Connect("127.0.0.1", 10757);
                    client.WriteLine("new!" + soundpath + "!" + playLoopBool);
                    connectstart = true;
                }

            }
        }

        private SimpleTCP.SimpleTcpClient client;

        private bool connectstart = false;
        private void setConnection(bool connection)
        {
            connectstart = connection;
        }

        #region local sound
        string soundpath = "";

        public void loadFile(string targetFile)
        {
            localsound.LoadFile(false, out int i, targetFile);
        }

        float volume = 0f;
        public void Volume(float vol)
        {
            if (volume != vol)
            {
                volume = vol;
                if (!remote)
                {
                    localsound.Volume(vol);
                }
                else
                {
                    client.WriteLine("vol!" + soundpath + "!" + vol.ToString() + "!");
                }
            }
        }

        public void Volume(Entity item)
        {
            float vol = surroundAudio.CalculateStereo(item);
            if (volume != vol)
            {
                volume = vol;
                if (!remote)
                {
                    localsound.Volume(vol);
                }
                else
                {
                    client.WriteLine("vol!" + soundpath + "!" + vol.ToString() + "!");
                }
            }
        }

        public void Play()
        {
            if (!File.Exists(soundpath))
                GTA.UI.ShowSubtitle("Path " + soundpath + "Does not exist, or does not have privileges");

            if (!remote)
            {
                localsound.Play();
            }
            else
                client.WriteLine("Play!" + soundpath + "!");
        }

        bool playLoopBool = false;

        public bool pausebool = false;
        public void pause()
        {
            if (!pausebool)
            {
                if (!remote)
                {
                    localsound.pause();
                }
                else
                {
                    client.WriteLine("Pause!" + soundpath + "!");
                }

            }
        }

        public void resume()
        {
            if (pausebool)
            {
                if (!remote)
                {
                    localsound.resume();
                }
                else
                {
                    client.WriteLine("Resume!" + soundpath + "!");
                }
            }
        }

        public void Stop()
        {
            playLoopBool = false;
            if (!remote)
            {
                localsound.Stop();
            }
            else
            {
                client.WriteLine("Stop!" + soundpath + "!");
            }
        }

        public double gettime()
        {
            if (!remote)
                return double.Parse(localsound.currentTime(false));
            else
            {
                string temp = "";
                while (true)
                {
                    try
                    {
                        temp = client.WriteLineAndGetReply("time!" + soundpath + "!", TimeSpan.FromMilliseconds(5)).MessageString.Split(':')[1];
                        Script.Wait(1);
                        double.Parse(temp.Substring(0, temp.Count() - 1));
                        break;
                    }
                    catch
                    {

                    }
                }
                return double.Parse(temp.Substring(0, temp.Count() - 1));
            }

        }

        public bool gettimeend()
        {
            if (!remote)
                return (gettime() == double.Parse(localsound.currentTime(false, true)));
            else
            {
                string temp = "";
                while (true)
                {
                    try
                    {
                        temp = client.WriteLineAndGetReply("timeend!" + soundpath + "!", TimeSpan.FromMilliseconds(5)).MessageString.Split(':')[1];
                        Script.Wait(1);
                        bool i = double.Parse(temp.Substring(0, temp.Count() - 1)) == gettime();
                        break;
                    }
                    catch
                    {

                    }
                }
                return double.Parse(temp.Substring(0, temp.Count() - 1)) == gettime();
            }
        }

        public void settime(double durration)
        {
            if (!remote)
            {
                localsound.playBackPosition(durration);
            }
            else
            {
                client.WriteLine("settime!" + soundpath + "!" + durration);
            }
        }

        public bool getPlayState()
        {
            if (!remote)
                return localsound.getPlayState();
            else
            {
                string temp = "";
                while (true)
                {
                    try
                    {
                        temp = client.WriteLineAndGetReply("isplaying!" + soundpath + "!", TimeSpan.FromMilliseconds(5)).MessageString.Split(':')[1];
                        Script.Wait(1);
                        bool.Parse(temp.Substring(0, temp.Count() - 1));
                        break;
                    }
                    catch
                    {

                    }
                }
                UI.ShowSubtitle("Bool: " + temp.Substring(0, temp.Count() - 1));
                return bool.Parse(temp.Substring(0, temp.Count() - 1));
            }
        }

        public bool getPlayStatePaused()
        {
            if (!remote)
                return localsound.getPlayStatePaused();
            else
            {
                string temp = "";
                while (true)
                {
                    try
                    {
                        temp = client.WriteLineAndGetReply("ispaused!" + soundpath + "!", TimeSpan.FromMilliseconds(5)).MessageString.Split(':')[1];
                        Script.Wait(1);
                        bool.Parse(temp.Substring(0, temp.Count() - 1));
                        break;
                    }
                    catch
                    {

                    }
                }

                UI.ShowSubtitle("Bool: " + temp.Substring(0, temp.Count() - 1));
                return bool.Parse(temp.Substring(0, temp.Count() - 1));
            }
        }

        public bool getPlayStateStopped()
        {
            if (!remote)
                return localsound.getPlayStateStopped();
            else
            {
                string temp = "";
                while (true)
                {
                    try
                    {
                        temp = client.WriteLineAndGetReply("isstopped!" + soundpath + "!", TimeSpan.FromMilliseconds(5)).MessageString.Split(':')[1];
                        Script.Wait(1);
                        bool.Parse(temp.Substring(0, temp.Count() - 1));
                        break;
                    }
                    catch
                    {

                    }
                }
                UI.ShowSubtitle("Bool: " + temp.Substring(0, temp.Count() - 1));
                return bool.Parse(temp.Substring(0, temp.Count() - 1));
            }
        }

        public void playSpeed(float rate)
        {
            if (getPlayState())
            {
                if (!remote)
                    localsound.playBackRate(rate);
                    //speedControl.PlaybackRate = 0.5f + rate * 0.1f;
                else
                {
                    client.WriteLine("rate!" + soundpath + "!");
                }
            }
        }

        public void remove()
        {
            localsound.Stop();
            localsound.remove();
        }
        #endregion
    }
}
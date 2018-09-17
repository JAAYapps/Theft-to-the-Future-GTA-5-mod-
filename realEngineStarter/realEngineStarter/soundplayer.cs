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
        public soundplayer(string Path = "", bool remoteSound = false, bool playloop = false)
        {
            soundpath = Path;
            playLoopBool = playloop;

            if (!remoteSound)
            {
                if (wavePlayer == null)
                {
                    wavePlayer = new WaveOutEvent();
                }

                reader?.Dispose();
                speedControl?.Dispose();
                reader = null;
                speedControl = null;
                var file = soundpath;
                if (file != null && file != "")
                {
                    reader = new AudioFileReader(file);
                    speedControl = new VarispeedSampleProvider(reader, 100, new SoundTouchProfile(false, false));
                    wavePlayer.Init(speedControl);
                    Play();
                    //Script.Wait(1);
                    Stop();
                } 
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

        bool responded = false;
        public void luancherdata(object sender, SimpleTCP.Message e)
        {
            //UI.ShowSubtitle("responce! " + e.MessageString);

            try
            {
                if (e.MessageString.Contains("soundposition!"))
                {
                    time = double.Parse(e.MessageString.Replace("soundposition!", ""));
                    responded = true;
                }

                if (e.MessageString.Contains("totaltime!"))
                {
                    time = double.Parse(e.MessageString.Replace("totaltime!", ""));
                    responded = true;
                }
            }
            catch
            {

            }
        }

        private SimpleTCP.SimpleTcpClient client;

        private bool connectstart = false;
        private double time = 0;
        private void setConnection(bool connection)
        {
            connectstart = connection;
        }

        #region local sound
        private IWavePlayer wavePlayer;
        private VarispeedSampleProvider speedControl;
        private AudioFileReader reader;
        string soundpath = "";

        public void loadFile(string targatFile)
        {
            reader = null;
            speedControl = null;
            soundpath = targatFile;
            var file = soundpath;
            reader?.Dispose();
            speedControl?.Dispose();
            reader = null;
            speedControl = null;
            reader = new AudioFileReader(file);
            speedControl = new VarispeedSampleProvider(reader, 100, new SoundTouchProfile(false, false));
            wavePlayer.Init(speedControl);
        }

        float volume = 0f;
        public void Volume(float vol)
        {
            if (volume != vol)
            {
                volume = vol;
                if (reader != null)
                {
                    reader.Volume = vol;
                }
                else
                {
                    client.WriteLine("vol!" + soundpath + "!" + vol.ToString());
                }
            }
        }

        public void Volume(Entity item)
        {
            float vol = surroundAudio.CalculateStereo(item);
            if (volume != vol)
            {
                volume = vol;
                if (reader != null)
                {
                    reader.Volume = vol;
                }
                else
                {
                    client.WriteLine("vol!" + soundpath + "!" + vol.ToString());
                }
            }
        }

        public void Play()
        {
            if (!File.Exists(soundpath))
                GTA.UI.ShowSubtitle("Path " + soundpath + "Does not exist, or does not have privileges");

            if (reader != null)
            {
                reader.CurrentTime = TimeSpan.FromSeconds(0);
                speedControl.Reposition();
                wavePlayer.Play(); 
            }
            else
                client.WriteLine("Play!" + soundpath);
        }

        bool playLoopBool = false;
        private void loop(object sender, StoppedEventArgs stoppedEventArgs)
        {
            if (playLoopBool)
            {
                reader.CurrentTime = TimeSpan.FromSeconds(0);
                speedControl.Reposition();
                wavePlayer.Play();
            }
        }

        public bool pausebool = false;
        public void pause()
        {
            if (!pausebool)
            {
                if (reader != null)
                {
                    wavePlayer.Stop();
                    pausebool = true;
                }
                else
                {
                    client.WriteLine("Pause!" + soundpath);
                }

            }
        }

        public void resume()
        {
            if (pausebool)
            {
                if (reader != null)
                {
                    wavePlayer.Play();
                    pausebool = false;
                }
                else
                {
                    client.WriteLine("Resume!" + soundpath);
                }
            }
        }

        public void Stop()
        {
            playLoopBool = false;
            if (reader != null)
            {
                wavePlayer.Stop();
                reader.CurrentTime = TimeSpan.FromSeconds(0);
                speedControl.Reposition(); 
            }
            else
            {
                client.WriteLine("Stop!" + soundpath);
            }
        }

        public double gettime()
        {
            if (reader != null)
                return reader.CurrentTime.TotalMilliseconds;
            else
            {
                string temp = client.WriteLineAndGetReply("time!" + soundpath, TimeSpan.FromSeconds(10)).MessageString.Split(':')[1];
                return double.Parse(temp.Substring(0, temp.Count() - 1));               
            }

        }

        double endOfAudio = 0;
        public bool gettimeend()
        {
            if (reader != null)
                return (reader.CurrentTime.TotalMilliseconds == reader.TotalTime.TotalMilliseconds);
            else
            {
                string temp = client.WriteLineAndGetReply("timeend!" + soundpath, TimeSpan.FromSeconds(10)).MessageString.Split(':')[1];
                return double.Parse(temp.Substring(0, temp.Count() - 1)) == gettime();
            }
        }

        public void settime(double durration)
        {
            if (reader != null)
            {
                reader.CurrentTime = TimeSpan.FromMilliseconds(durration);
                speedControl.Reposition();
            }
            else
            {
                client.WriteLine("settime!" + soundpath + "!" + durration);
            }
        }

        bool PlayState = false;
        public bool getPlayState()
        {
            if (reader != null)
                return (wavePlayer.PlaybackState == PlaybackState.Playing);
            else
            {
                string temp = client.WriteLineAndGetReply("isplaying!" + soundpath, TimeSpan.FromSeconds(1)).MessageString.Split(':')[1];
                UI.ShowSubtitle("Bool: " + temp.Substring(0, temp.Count() - 1));
                return bool.Parse(temp.Substring(0, temp.Count() - 1));
            }
        }

        bool PlayStatePause = false;
        public bool getPlayStatePaused()
        {
            if (reader != null)
                return (wavePlayer.PlaybackState == PlaybackState.Paused);
            else
            {
                string temp = client.WriteLineAndGetReply("ispaused!" + soundpath, TimeSpan.FromSeconds(1)).MessageString.Split(':')[1];
                UI.ShowSubtitle("Bool: " + temp.Substring(0, temp.Count() - 1));
                return bool.Parse(temp.Substring(0, temp.Count() - 1));
            }
        }

        bool PlayStateStop = false;
        public bool getPlayStateStopped()
        {
            if (reader != null)
                return (wavePlayer.PlaybackState == PlaybackState.Stopped);
            else
            {
                string temp = client.WriteLineAndGetReply("isstopped!" + soundpath, TimeSpan.FromSeconds(1)).MessageString.Split(':')[1];
                UI.ShowSubtitle("Bool: " + temp.Substring(0, temp.Count() - 1));
                return bool.Parse(temp.Substring(0, temp.Count() - 1));
            }
        }

        public void playSpeed(float rate)
        {
            if (getPlayState())
            {
                if (reader != null)
                    speedControl.PlaybackRate = 0.5f + rate * 0.1f;
                else
                {
                    client.WriteLine("rate!" + soundpath);
                }
            }
        }
        #endregion
    }
}
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
        private IWavePlayer wavePlayer;
        private VarispeedSampleProvider speedControl;
        private AudioFileReader reader;
        string soundpath = "";

        public soundplayer(string Path = "", bool playloop = false)
        {
            soundpath = Path;

            if (wavePlayer == null)
            {
                wavePlayer = new WaveOutEvent();
            }

            playLoopBool = playloop;

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
                reader.Volume = vol;
            }
        }

        //bool isPlaying = false;
        public void Play()
        {
            if (!File.Exists(soundpath))
                GTA.UI.ShowSubtitle("Path " + soundpath + "Does not exist, or does not have privileges");
            reader.CurrentTime = TimeSpan.FromSeconds(0);
            speedControl.Reposition();
            wavePlayer.Play();
            //isPlaying = true;
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
            //isPlaying = false;
        }

        public bool pausebool = false;
        public void pause()
        {
            if (!pausebool)
            {
                wavePlayer.Stop();
                pausebool = true;
            }
        }

        public void resume()
        {
            if (pausebool)
            {
                wavePlayer.Play();
                pausebool = false;
            }
        }

        public void Stop()
        {
            playLoopBool = false;
            wavePlayer.Stop();
            reader.CurrentTime = TimeSpan.FromSeconds(0);
            speedControl.Reposition();
        }

        public double gettime()
        {
            return reader.CurrentTime.TotalMilliseconds;
        }

        public bool gettimeend()
        {
            return (reader.CurrentTime.TotalMilliseconds == reader.TotalTime.TotalMilliseconds);
        }

        public void settime(double durration)
        {
            reader.CurrentTime = TimeSpan.FromMilliseconds(durration);
            speedControl.Reposition();
        }

        public bool getPlayState()
        {
            return (wavePlayer.PlaybackState == PlaybackState.Playing);
        }

        public bool getPlayStatePaused()
        {
            return (wavePlayer.PlaybackState == PlaybackState.Paused);
        }

        public bool getPlayStateStopped()
        {
            return (wavePlayer.PlaybackState == PlaybackState.Stopped);
        }

        public void playSpeed(float rate)
        {
            if (getPlayState())
            {
                speedControl.PlaybackRate = 0.5f + rate * 0.1f;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio;
using NAudio.Wave;
using VarispeedDemo.SoundTouch;

namespace TTTF_TimeTravel_0._9._0
{
    class localsoundplayer
    {
        private IWavePlayer wavePlayer;
        private VarispeedSampleProvider speedControl;
        private AudioFileReader reader;

        public localsoundplayer(bool loop)
        {
            playLoopBool = loop;
        }

        public void Modes(bool mode)
        {
            if (speedControl != null)
            {
                var useTempo = mode;
                speedControl.SetSoundTouchProfile(new SoundTouchProfile(useTempo, false));
            }
        }

        public void LoadFile(bool mode, out int time, string fileName = "")
        {
            remove();
            reader?.Dispose();
            speedControl?.Dispose();
            reader = null;
            speedControl = null;
            string file;
            if (fileName == "")
                file = SelectFile();
            else
                file = fileName;
            time = 0;
            if (file == null) return;
            reader = new AudioFileReader(file);
            time = (int)(reader.TotalTime.TotalSeconds + 0.5);
            var useTempo = mode;
            speedControl = new VarispeedSampleProvider(reader, 100, new SoundTouchProfile(useTempo, false));
            if (wavePlayer == null)
            {
                wavePlayer = new WaveOutEvent();
                wavePlayer.PlaybackStopped += WavePlayerOnPlaybackStopped;
            }
            init = false;
            Play();
            Stop();
        }

        private string SelectFile()
        {
            var ofd = new OpenFileDialog();
            ofd.Filter = "MP3 Files|*.mp3|WAV Files|*.wav";
            return ofd.ShowDialog() == DialogResult.OK ? ofd.FileName : null;
        }

        bool play = false;
        bool init = false;
        public void Play()
        {
            if (speedControl == null)
            {
                if (speedControl == null) return;
            }

            try
            {
                if (!init)
                {
                    wavePlayer.Init(speedControl);
                    init = true;
                }
                else
                {
                    reader.CurrentTime = TimeSpan.FromSeconds(0);
                    speedControl.Reposition();
                }

                play = true;
            }
            catch
            {

            }

            wavePlayer.Play();
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

        public int Tick()
        {
            if (reader != null)
            {
                return (int)reader.CurrentTime.TotalSeconds;
            }

            return 0;
        }

        public string currentTime(bool str, bool total = false)
        {
            try
            {
                if (str)
                    return reader.CurrentTime.ToString("mm\\:ss") + " milliseconds: " + reader.CurrentTime.TotalMilliseconds;
                else
                {
                    if (total)
                    {
                        return reader.TotalTime.TotalMilliseconds.ToString(); 
                    }
                    else
                        return reader.CurrentTime.TotalMilliseconds.ToString();
                }

            }
            catch (Exception)
            {
                return "";
            }
        }

        public void Stop()
        {
            play = false;
            wavePlayer?.Stop();
            reader.CurrentTime = TimeSpan.FromSeconds(0);
            speedControl.Reposition();
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
            }
        }

        public void playBackPosition(double pos)
        {
            if (reader != null)
            {
                reader.CurrentTime = TimeSpan.FromSeconds(pos);
                speedControl.Reposition();
            }
        }

        public string playBackRate(float rate)
        {
            speedControl.PlaybackRate = 0.5f + rate * 0.1f;
            return $"x{speedControl.PlaybackRate:F2}";
        }

        bool playLoopBool = false;
        private void WavePlayerOnPlaybackStopped(object sender, StoppedEventArgs stoppedEventArgs)
        {
            if (stoppedEventArgs.Exception != null)
            {
                MessageBox.Show(stoppedEventArgs.Exception.Message, "Playback Stopped Unexpectedly");
            }
            else
            {
                reader.CurrentTime = TimeSpan.FromSeconds(0);
                speedControl.Reposition();
                if (playLoopBool && play)
                {
                    wavePlayer.Play();
                }
            }
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

        public void remove()
        {
            wavePlayer?.Dispose();
            speedControl?.Dispose();
            reader?.Dispose();
        }
    }
}
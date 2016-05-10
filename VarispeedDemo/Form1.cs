using System;
using System.Windows.Forms;
using NAudio.Wave;
using VarispeedDemo.SoundTouch;

namespace VarispeedDemo
{
    public partial class Form1 : Form
    {
        private IWavePlayer wavePlayer;
        private VarispeedSampleProvider speedControl;
        private AudioFileReader reader;

        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 500;
            timer1.Start();

            comboBoxModes.Items.Add("Speed");
            comboBoxModes.Items.Add("Tempo");
            comboBoxModes.SelectedIndex = 0;

            EnableControls(false);
        }

        private void OnButtonPlayClick(object sender, EventArgs e)
        {
            if (wavePlayer == null)
            {
                wavePlayer = new WaveOutEvent();
                wavePlayer.PlaybackStopped += WavePlayerOnPlaybackStopped;
            }
            if (speedControl == null)
            {
                LoadFile();
                if (speedControl == null) return;
            }
            
            wavePlayer.Init(speedControl);
            
            wavePlayer.Play();
            EnableControls(true);
        }

        private void WavePlayerOnPlaybackStopped(object sender, StoppedEventArgs stoppedEventArgs)
        {
            if (stoppedEventArgs.Exception != null)
            {
                MessageBox.Show(stoppedEventArgs.Exception.Message, "Playback Stopped Unexpectedly");
            }
            EnableControls(false);
        }

        private void EnableControls(bool isPlaying)
        {
            buttonPlay.Enabled = !isPlaying;
            buttonLoad.Enabled = !isPlaying;
            buttonStop.Enabled = isPlaying;
            comboBoxModes.Enabled = !isPlaying;
        }

        private string SelectFile()
        {
            var ofd = new OpenFileDialog();
            ofd.Filter = "MP3 Files|*.mp3";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                return ofd.FileName;
            }
            return null;
        }

        private void OnButtonStopClick(object sender, EventArgs e)
        {
            wavePlayer?.Stop();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            speedControl.PlaybackRate = 0.5f + trackBar1.Value*0.1f;
        }

        private void OnButtonLoadClick(object sender, EventArgs e)
        {
            LoadFile();
        }

        private void LoadFile()
        {
            reader?.Dispose();
            speedControl?.Dispose();
            reader = null;
            speedControl = null;

            var file = SelectFile();
            if (file == null) return;
            reader = new AudioFileReader(file);
            trackBarPlaybackPosition.Value = 0;
            trackBarPlaybackPosition.Maximum = (int) (reader.TotalTime.TotalSeconds + 0.5);
            var useTempo = comboBoxModes.SelectedIndex == 1;
            speedControl = new VarispeedSampleProvider(reader, 100, new SoundTouchProfile(useTempo, false));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (reader != null)
            {
                trackBarPlaybackPosition.Value = (int) reader.CurrentTime.TotalSeconds;
            }
        }
    }
}

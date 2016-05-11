using System;
using System.Windows.Forms;
using NAudio.Wave;
using VarispeedDemo.SoundTouch;

namespace VarispeedDemo
{
    public partial class MainForm : Form
    {
        private IWavePlayer wavePlayer;
        private VarispeedSampleProvider speedControl;
        private AudioFileReader reader;


        public MainForm()
        {
            InitializeComponent();
            timer1.Interval = 500;
            timer1.Start();
            Closing += OnMainFormClosing;

            comboBoxModes.Items.Add("Speed");
            comboBoxModes.Items.Add("Tempo");
            comboBoxModes.SelectedIndex = 0;

            EnableControls(false);
            
        }

        private void OnMainFormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            wavePlayer?.Dispose();
            speedControl?.Dispose();
            reader?.Dispose();
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
            return ofd.ShowDialog() == DialogResult.OK ? ofd.FileName : null;
        }

        private void OnButtonStopClick(object sender, EventArgs e)
        {
            wavePlayer?.Stop();
        }

        private void OnTrackBarPlaybackRateScroll(object sender, EventArgs e)
        {
            speedControl.PlaybackRate = 0.5f + trackBarPlaybackRate.Value*0.1f;
            labelPlaybackSpeed.Text = $"x{speedControl.PlaybackRate:F2}";
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
            DisplayPosition();
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
                DisplayPosition();
            }
        }

        private void DisplayPosition()
        {
            labelPosition.Text = reader.CurrentTime.ToString("mm\\:ss");
        }

        private void trackBarPlaybackPosition_Scroll(object sender, EventArgs e)
        {
            if (reader != null)
            {
                reader.CurrentTime = TimeSpan.FromSeconds(trackBarPlaybackPosition.Value);
                speedControl.Reposition();
            }
        }

        private void comboBoxModes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (speedControl != null)
            {
                var useTempo = comboBoxModes.SelectedIndex == 1;
                speedControl.SetSoundTouchProfile(new SoundTouchProfile(useTempo, false));
            }
        }
    }
}

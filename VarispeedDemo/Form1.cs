using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;
using VarispeedDemo.SoundTouch;

namespace VarispeedDemo
{
    public partial class Form1 : Form
    {
        private IWavePlayer wavePlayer;
        private VarispeedSampleProvider speedControl;

        public Form1()
        {
            InitializeComponent();
        }

        private void OnButtonPlayClick(object sender, EventArgs e)
        {
            if (wavePlayer == null)
            {
                wavePlayer = new WaveOutEvent();
            }
            if (speedControl == null)
            {
                var file = SelectFile();
                if (file == null) return;
                var audioFile = new AudioFileReader(file);
                speedControl = new VarispeedSampleProvider(audioFile, 100, new SoundTouchProfile(false, false));
                wavePlayer.Init(speedControl);
            }
            wavePlayer.Play();
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
    }
}

namespace VarispeedDemo
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.trackBarPlaybackRate = new System.Windows.Forms.TrackBar();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.comboBoxModes = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.trackBarPlaybackPosition = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.labelPlaybackSpeed = new System.Windows.Forms.Label();
            this.labelPosition = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPlaybackRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPlaybackPosition)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonPlay
            // 
            this.buttonPlay.Location = new System.Drawing.Point(94, 12);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(75, 23);
            this.buttonPlay.TabIndex = 0;
            this.buttonPlay.Text = "Play";
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.OnButtonPlayClick);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(175, 12);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(73, 23);
            this.buttonStop.TabIndex = 1;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.OnButtonStopClick);
            // 
            // trackBarPlaybackRate
            // 
            this.trackBarPlaybackRate.Location = new System.Drawing.Point(13, 76);
            this.trackBarPlaybackRate.Maximum = 20;
            this.trackBarPlaybackRate.Name = "trackBarPlaybackRate";
            this.trackBarPlaybackRate.Size = new System.Drawing.Size(230, 45);
            this.trackBarPlaybackRate.TabIndex = 2;
            this.trackBarPlaybackRate.Value = 5;
            this.trackBarPlaybackRate.Scroll += new System.EventHandler(this.OnTrackBarPlaybackRateScroll);
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(13, 12);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(75, 23);
            this.buttonLoad.TabIndex = 3;
            this.buttonLoad.Text = "Load";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.OnButtonLoadClick);
            // 
            // comboBoxModes
            // 
            this.comboBoxModes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxModes.FormattingEnabled = true;
            this.comboBoxModes.Location = new System.Drawing.Point(254, 12);
            this.comboBoxModes.Name = "comboBoxModes";
            this.comboBoxModes.Size = new System.Drawing.Size(121, 21);
            this.comboBoxModes.TabIndex = 4;
            this.comboBoxModes.SelectedIndexChanged += new System.EventHandler(this.comboBoxModes_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Playback Speed";
            // 
            // trackBarPlaybackPosition
            // 
            this.trackBarPlaybackPosition.Location = new System.Drawing.Point(18, 137);
            this.trackBarPlaybackPosition.Maximum = 100;
            this.trackBarPlaybackPosition.Name = "trackBarPlaybackPosition";
            this.trackBarPlaybackPosition.Size = new System.Drawing.Size(225, 45);
            this.trackBarPlaybackPosition.SmallChange = 5;
            this.trackBarPlaybackPosition.TabIndex = 2;
            this.trackBarPlaybackPosition.TickFrequency = 5;
            this.trackBarPlaybackPosition.Scroll += new System.EventHandler(this.trackBarPlaybackPosition_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Playback Position";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // labelPlaybackSpeed
            // 
            this.labelPlaybackSpeed.AutoSize = true;
            this.labelPlaybackSpeed.Location = new System.Drawing.Point(254, 76);
            this.labelPlaybackSpeed.Name = "labelPlaybackSpeed";
            this.labelPlaybackSpeed.Size = new System.Drawing.Size(27, 13);
            this.labelPlaybackSpeed.TabIndex = 6;
            this.labelPlaybackSpeed.Text = "x1.0";
            // 
            // labelPosition
            // 
            this.labelPosition.AutoSize = true;
            this.labelPosition.Location = new System.Drawing.Point(254, 137);
            this.labelPosition.Name = "labelPosition";
            this.labelPosition.Size = new System.Drawing.Size(34, 13);
            this.labelPosition.TabIndex = 6;
            this.labelPosition.Text = "00:00";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 262);
            this.Controls.Add(this.labelPosition);
            this.Controls.Add(this.labelPlaybackSpeed);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxModes);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.trackBarPlaybackPosition);
            this.Controls.Add(this.trackBarPlaybackRate);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonPlay);
            this.Name = "MainForm";
            this.Text = "NAudio SoundTouch Demo";
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPlaybackRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPlaybackPosition)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.TrackBar trackBarPlaybackRate;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.ComboBox comboBoxModes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trackBarPlaybackPosition;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label labelPlaybackSpeed;
        private System.Windows.Forms.Label labelPosition;
    }
}


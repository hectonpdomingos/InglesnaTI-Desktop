namespace inglesnati
{
    partial class Listening
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Listening));
            this.comboescolheraudio = new System.Windows.Forms.ComboBox();
            this.textooriginal = new System.Windows.Forms.TextBox();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.BTdownloadAudio = new System.Windows.Forms.Button();
            this.seutexto = new System.Windows.Forms.TextBox();
            this.BTcomparar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ComboBoxAudiosPBaixar = new System.Windows.Forms.ComboBox();
            this.BTenviartexto = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.BTplay = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.SuspendLayout();
            // 
            // comboescolheraudio
            // 
            this.comboescolheraudio.FormattingEnabled = true;
            this.comboescolheraudio.Location = new System.Drawing.Point(12, 37);
            this.comboescolheraudio.Name = "comboescolheraudio";
            this.comboescolheraudio.Size = new System.Drawing.Size(150, 21);
            this.comboescolheraudio.TabIndex = 2;
            // 
            // textooriginal
            // 
            this.textooriginal.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textooriginal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textooriginal.Location = new System.Drawing.Point(12, 121);
            this.textooriginal.Multiline = true;
            this.textooriginal.Name = "textooriginal";
            this.textooriginal.ReadOnly = true;
            this.textooriginal.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textooriginal.Size = new System.Drawing.Size(413, 262);
            this.textooriginal.TabIndex = 4;
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(12, 66);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(832, 49);
            this.axWindowsMediaPlayer1.TabIndex = 0;
            // 
            // BTdownloadAudio
            // 
            this.BTdownloadAudio.Location = new System.Drawing.Point(769, 35);
            this.BTdownloadAudio.Name = "BTdownloadAudio";
            this.BTdownloadAudio.Size = new System.Drawing.Size(75, 23);
            this.BTdownloadAudio.TabIndex = 5;
            this.BTdownloadAudio.Text = "Download";
            this.BTdownloadAudio.UseVisualStyleBackColor = true;
            this.BTdownloadAudio.Click += new System.EventHandler(this.BTdownloadAudio_Click);
            // 
            // seutexto
            // 
            this.seutexto.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.seutexto.Location = new System.Drawing.Point(431, 121);
            this.seutexto.Multiline = true;
            this.seutexto.Name = "seutexto";
            this.seutexto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.seutexto.Size = new System.Drawing.Size(413, 262);
            this.seutexto.TabIndex = 6;
            this.seutexto.Text = "Transcreva aqui todo o audio e depois compare com o texto original.";
            // 
            // BTcomparar
            // 
            this.BTcomparar.Location = new System.Drawing.Point(13, 390);
            this.BTcomparar.Name = "BTcomparar";
            this.BTcomparar.Size = new System.Drawing.Size(75, 23);
            this.BTcomparar.TabIndex = 7;
            this.BTcomparar.Text = "Comparar";
            this.BTcomparar.UseVisualStyleBackColor = true;
            this.BTcomparar.Click += new System.EventHandler(this.BTcomparar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Ouvir audios baixados";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(595, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Últimos audios disponibilizados";
            // 
            // ComboBoxAudiosPBaixar
            // 
            this.ComboBoxAudiosPBaixar.FormattingEnabled = true;
            this.ComboBoxAudiosPBaixar.Location = new System.Drawing.Point(598, 35);
            this.ComboBoxAudiosPBaixar.Name = "ComboBoxAudiosPBaixar";
            this.ComboBoxAudiosPBaixar.Size = new System.Drawing.Size(165, 21);
            this.ComboBoxAudiosPBaixar.TabIndex = 10;
            // 
            // BTenviartexto
            // 
            this.BTenviartexto.Location = new System.Drawing.Point(769, 390);
            this.BTenviartexto.Name = "BTenviartexto";
            this.BTenviartexto.Size = new System.Drawing.Size(75, 23);
            this.BTenviartexto.TabIndex = 11;
            this.BTenviartexto.Text = "Guardar";
            this.BTenviartexto.UseVisualStyleBackColor = true;
            this.BTenviartexto.Click += new System.EventHandler(this.BTenviartexto_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(553, 400);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(210, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Deseja guardar um rascunho do seu texto?";
            // 
            // BTplay
            // 
            this.BTplay.Location = new System.Drawing.Point(181, 37);
            this.BTplay.Name = "BTplay";
            this.BTplay.Size = new System.Drawing.Size(75, 23);
            this.BTplay.TabIndex = 14;
            this.BTplay.Text = "Play";
            this.BTplay.UseVisualStyleBackColor = true;
            this.BTplay.Click += new System.EventHandler(this.BTplay_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(338, 37);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(227, 23);
            this.progressBar1.TabIndex = 15;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // Listening
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(863, 502);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.BTplay);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BTenviartexto);
            this.Controls.Add(this.ComboBoxAudiosPBaixar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BTcomparar);
            this.Controls.Add(this.seutexto);
            this.Controls.Add(this.BTdownloadAudio);
            this.Controls.Add(this.textooriginal);
            this.Controls.Add(this.comboescolheraudio);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Listening";
            this.Text = "Listening";
            this.Load += new System.EventHandler(this.Listening_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.ComboBox comboescolheraudio;
        private System.Windows.Forms.TextBox textooriginal;
        private System.Windows.Forms.Button BTdownloadAudio;
        private System.Windows.Forms.TextBox seutexto;
        private System.Windows.Forms.Button BTcomparar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ComboBoxAudiosPBaixar;
        private System.Windows.Forms.Button BTenviartexto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BTplay;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}
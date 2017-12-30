namespace inglesnati
{
    partial class Atualizar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Atualizar));
            this.BTAtualizarPrograma = new System.Windows.Forms.Button();
            this.TBcorrecoesAtualizacao = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // BTAtualizarPrograma
            // 
            this.BTAtualizarPrograma.Location = new System.Drawing.Point(297, 36);
            this.BTAtualizarPrograma.Name = "BTAtualizarPrograma";
            this.BTAtualizarPrograma.Size = new System.Drawing.Size(105, 46);
            this.BTAtualizarPrograma.TabIndex = 0;
            this.BTAtualizarPrograma.Text = "Atualizar";
            this.BTAtualizarPrograma.UseVisualStyleBackColor = true;
            this.BTAtualizarPrograma.Click += new System.EventHandler(this.BTAtualizarPrograma_Click);
            // 
            // TBcorrecoesAtualizacao
            // 
            this.TBcorrecoesAtualizacao.Location = new System.Drawing.Point(12, 27);
            this.TBcorrecoesAtualizacao.Multiline = true;
            this.TBcorrecoesAtualizacao.Name = "TBcorrecoesAtualizacao";
            this.TBcorrecoesAtualizacao.Size = new System.Drawing.Size(279, 140);
            this.TBcorrecoesAtualizacao.TabIndex = 1;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 173);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(408, 28);
            this.progressBar1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Atualizações";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // Atualizar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(432, 205);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.TBcorrecoesAtualizacao);
            this.Controls.Add(this.BTAtualizarPrograma);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Atualizar";
            this.Text = "Atualização do programa Inglês na TI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTAtualizarPrograma;
        private System.Windows.Forms.TextBox TBcorrecoesAtualizacao;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}
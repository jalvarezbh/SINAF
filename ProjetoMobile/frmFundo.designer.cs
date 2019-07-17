namespace ProjetoMobile
{
    partial class frmFundo
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
            this.lblMensagem = new System.Windows.Forms.Label();
            this.lblVersao = new System.Windows.Forms.Label();
            this.ctrBarraInferior = new ProjetoMobile.Controles.BarraInferior();
            this.ctrBarraSuperior = new ProjetoMobile.Controles.BarraSuperior();
            this.pAtualizar = new System.Windows.Forms.Panel();
            this.timerLogOff = new System.Windows.Forms.Timer();
            this.SuspendLayout();
            // 
            // lblMensagem
            // 
            this.lblMensagem.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.lblMensagem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(19)))), ((int)(((byte)(95)))));
            this.lblMensagem.Location = new System.Drawing.Point(3, 131);
            this.lblMensagem.Name = "lblMensagem";
            this.lblMensagem.Size = new System.Drawing.Size(470, 260);
            this.lblMensagem.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblVersao
            // 
            this.lblVersao.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblVersao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(19)))), ((int)(((byte)(95)))));
            this.lblVersao.Location = new System.Drawing.Point(10, 82);
            this.lblVersao.Name = "lblVersao";
            this.lblVersao.Size = new System.Drawing.Size(454, 30);
            this.lblVersao.Text = "Versão 1.0.0";
            this.lblVersao.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ctrBarraInferior
            // 
            this.ctrBarraInferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ctrBarraInferior.Location = new System.Drawing.Point(0, 602);
            this.ctrBarraInferior.Name = "ctrBarraInferior";
            this.ctrBarraInferior.Size = new System.Drawing.Size(480, 38);
            this.ctrBarraInferior.TabIndex = 1;
            this.ctrBarraInferior.TabStop = false;
            this.ctrBarraInferior.Visible = false;
            // 
            // ctrBarraSuperior
            // 
            this.ctrBarraSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrBarraSuperior.Location = new System.Drawing.Point(0, 0);
            this.ctrBarraSuperior.Name = "ctrBarraSuperior";
            this.ctrBarraSuperior.Size = new System.Drawing.Size(480, 70);
            this.ctrBarraSuperior.TabIndex = 0;
            this.ctrBarraSuperior.TabStop = false;
            this.ctrBarraSuperior.Visible = false;
            // 
            // pAtualizar
            // 
            this.pAtualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(61)))), ((int)(((byte)(118)))));
            this.pAtualizar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pAtualizar.Location = new System.Drawing.Point(0, 564);
            this.pAtualizar.Name = "pAtualizar";
            this.pAtualizar.Size = new System.Drawing.Size(480, 38);
            this.pAtualizar.Visible = false;
            // 
            // timerLogOff
            // 
            this.timerLogOff.Interval = 100000;
            this.timerLogOff.Tick += new System.EventHandler(this.timerLogOff_Tick);
            // 
            // frmFundo
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(480, 640);
            this.ControlBox = false;
            this.Controls.Add(this.pAtualizar);
            this.Controls.Add(this.lblVersao);
            this.Controls.Add(this.lblMensagem);
            this.Controls.Add(this.ctrBarraInferior);
            this.Controls.Add(this.ctrBarraSuperior);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmFundo";
            this.Text = "PEP - Projeto Entrevista Premiada";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmFundo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ProjetoMobile.Controles.BarraSuperior ctrBarraSuperior;
        private ProjetoMobile.Controles.BarraInferior ctrBarraInferior;
        private System.Windows.Forms.Label lblMensagem;
        private System.Windows.Forms.Label lblVersao;
        private System.Windows.Forms.Panel pAtualizar;
        private System.Windows.Forms.Timer timerLogOff;
    }
}
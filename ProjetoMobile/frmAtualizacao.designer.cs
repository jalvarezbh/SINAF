namespace ProjetoMobile
{
    partial class frmAtualizacao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAtualizacao));
            this.pgbAtualizacao = new System.Windows.Forms.ProgressBar();
            this.tbxStatus = new System.Windows.Forms.TextBox();
            this.pgbUpDown = new System.Windows.Forms.ProgressBar();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.btnExecutar = new System.Windows.Forms.Button();
            this.lblVersao = new System.Windows.Forms.Label();
            this.ctrBarraSuperior = new ProjetoMobile.Controles.BarraSuperior();
            this.pAtualizar = new System.Windows.Forms.Panel();
            this.lblFaixa = new System.Windows.Forms.Label();
            this.picWIFI = new System.Windows.Forms.PictureBox();
            this.lblServidor = new System.Windows.Forms.Label();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.lblCorreio = new System.Windows.Forms.Label();
            this.btnDestravar = new System.Windows.Forms.Button();
            this.txtFTP = new System.Windows.Forms.TextBox();
            this.lblFTP = new System.Windows.Forms.Label();
            this.pAtualizar.SuspendLayout();
            this.SuspendLayout();
            // 
            // pgbAtualizacao
            // 
            this.pgbAtualizacao.Location = new System.Drawing.Point(50, 503);
            this.pgbAtualizacao.Name = "pgbAtualizacao";
            this.pgbAtualizacao.Size = new System.Drawing.Size(380, 38);
            // 
            // tbxStatus
            // 
            this.tbxStatus.Location = new System.Drawing.Point(50, 245);
            this.tbxStatus.Multiline = true;
            this.tbxStatus.Name = "tbxStatus";
            this.tbxStatus.ReadOnly = true;
            this.tbxStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxStatus.Size = new System.Drawing.Size(380, 248);
            this.tbxStatus.TabIndex = 0;
            this.tbxStatus.TabStop = false;
            // 
            // pgbUpDown
            // 
            this.pgbUpDown.Location = new System.Drawing.Point(50, 503);
            this.pgbUpDown.Name = "pgbUpDown";
            this.pgbUpDown.Size = new System.Drawing.Size(380, 38);
            // 
            // btnVoltar
            // 
            this.btnVoltar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(61)))), ((int)(((byte)(118)))));
            this.btnVoltar.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnVoltar.ForeColor = System.Drawing.Color.White;
            this.btnVoltar.Location = new System.Drawing.Point(10, 560);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(124, 36);
            this.btnVoltar.TabIndex = 12;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // btnExecutar
            // 
            this.btnExecutar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(61)))), ((int)(((byte)(118)))));
            this.btnExecutar.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnExecutar.ForeColor = System.Drawing.Color.White;
            this.btnExecutar.Location = new System.Drawing.Point(346, 560);
            this.btnExecutar.Name = "btnExecutar";
            this.btnExecutar.Size = new System.Drawing.Size(124, 36);
            this.btnExecutar.TabIndex = 10;
            this.btnExecutar.Text = "Executar";
            this.btnExecutar.Click += new System.EventHandler(this.btnExecutar_Click);
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
            // ctrBarraSuperior
            // 
            this.ctrBarraSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrBarraSuperior.Location = new System.Drawing.Point(0, 0);
            this.ctrBarraSuperior.Name = "ctrBarraSuperior";
            this.ctrBarraSuperior.Size = new System.Drawing.Size(480, 70);
            this.ctrBarraSuperior.TabIndex = 11;
            this.ctrBarraSuperior.TabStop = false;
            // 
            // pAtualizar
            // 
            this.pAtualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(61)))), ((int)(((byte)(118)))));
            this.pAtualizar.Controls.Add(this.lblFaixa);
            this.pAtualizar.Controls.Add(this.picWIFI);
            this.pAtualizar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pAtualizar.Location = new System.Drawing.Point(0, 602);
            this.pAtualizar.Name = "pAtualizar";
            this.pAtualizar.Size = new System.Drawing.Size(480, 38);
            // 
            // lblFaixa
            // 
            this.lblFaixa.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblFaixa.ForeColor = System.Drawing.Color.White;
            this.lblFaixa.Location = new System.Drawing.Point(41, 7);
            this.lblFaixa.Name = "lblFaixa";
            this.lblFaixa.Size = new System.Drawing.Size(158, 28);
            this.lblFaixa.Text = "WIFI";
            // 
            // picWIFI
            // 
            this.picWIFI.Image = ((System.Drawing.Image)(resources.GetObject("picWIFI.Image")));
            this.picWIFI.Location = new System.Drawing.Point(3, 3);
            this.picWIFI.Name = "picWIFI";
            this.picWIFI.Size = new System.Drawing.Size(32, 32);
            this.picWIFI.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // lblServidor
            // 
            this.lblServidor.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblServidor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(19)))), ((int)(((byte)(95)))));
            this.lblServidor.Location = new System.Drawing.Point(50, 161);
            this.lblServidor.Name = "lblServidor";
            this.lblServidor.Size = new System.Drawing.Size(60, 30);
            this.lblServidor.Text = "URL:";
            // 
            // txtURL
            // 
            this.txtURL.Enabled = false;
            this.txtURL.Location = new System.Drawing.Point(116, 150);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(314, 41);
            this.txtURL.TabIndex = 1;
            // 
            // lblCorreio
            // 
            this.lblCorreio.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblCorreio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(19)))), ((int)(((byte)(95)))));
            this.lblCorreio.Location = new System.Drawing.Point(10, 112);
            this.lblCorreio.Name = "lblCorreio";
            this.lblCorreio.Size = new System.Drawing.Size(454, 30);
            this.lblCorreio.Text = "Correio";
            this.lblCorreio.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnDestravar
            // 
            this.btnDestravar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(61)))), ((int)(((byte)(118)))));
            this.btnDestravar.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnDestravar.ForeColor = System.Drawing.Color.White;
            this.btnDestravar.Location = new System.Drawing.Point(179, 560);
            this.btnDestravar.Name = "btnDestravar";
            this.btnDestravar.Size = new System.Drawing.Size(124, 36);
            this.btnDestravar.TabIndex = 11;
            this.btnDestravar.Text = "Destravar";
            this.btnDestravar.Click += new System.EventHandler(this.btnDestravar_Click);
            // 
            // txtFTP
            // 
            this.txtFTP.Enabled = false;
            this.txtFTP.Location = new System.Drawing.Point(116, 201);
            this.txtFTP.Name = "txtFTP";
            this.txtFTP.Size = new System.Drawing.Size(314, 41);
            this.txtFTP.TabIndex = 2;
            // 
            // lblFTP
            // 
            this.lblFTP.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblFTP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(19)))), ((int)(((byte)(95)))));
            this.lblFTP.Location = new System.Drawing.Point(50, 212);
            this.lblFTP.Name = "lblFTP";
            this.lblFTP.Size = new System.Drawing.Size(60, 30);
            this.lblFTP.Text = "FTP:";
            // 
            // frmAtualizacao
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(480, 640);
            this.Controls.Add(this.txtFTP);
            this.Controls.Add(this.lblFTP);
            this.Controls.Add(this.btnDestravar);
            this.Controls.Add(this.lblCorreio);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.lblServidor);
            this.Controls.Add(this.ctrBarraSuperior);
            this.Controls.Add(this.pAtualizar);
            this.Controls.Add(this.lblVersao);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.btnExecutar);
            this.Controls.Add(this.pgbUpDown);
            this.Controls.Add(this.tbxStatus);
            this.Controls.Add(this.pgbAtualizacao);
            this.Location = new System.Drawing.Point(0, 0);
            this.MinimizeBox = false;
            this.Name = "frmAtualizacao";
            this.Text = "PEP - Projeto Entrevista Premiada";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmAtualizacao_Load);
            this.Activated += new System.EventHandler(this.FrmAtualizacao_Activated);
            this.pAtualizar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar pgbAtualizacao;
        private System.Windows.Forms.TextBox tbxStatus;
        private System.Windows.Forms.ProgressBar pgbUpDown;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Button btnExecutar;
        private System.Windows.Forms.Label lblVersao;
        private ProjetoMobile.Controles.BarraSuperior ctrBarraSuperior;
        private System.Windows.Forms.Panel pAtualizar;
        private System.Windows.Forms.Label lblServidor;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Label lblCorreio;
        private System.Windows.Forms.Label lblFaixa;
        public System.Windows.Forms.PictureBox picWIFI;
        private System.Windows.Forms.Button btnDestravar;
        private System.Windows.Forms.TextBox txtFTP;
        private System.Windows.Forms.Label lblFTP;
    }
}
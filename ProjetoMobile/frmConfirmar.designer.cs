namespace ProjetoMobile
{
    partial class frmConfirmar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfirmar));
            this.barraSuperior1 = new ProjetoMobile.Controles.BarraSuperior();
            this.lblMensagem = new System.Windows.Forms.Label();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.pAtualizar = new System.Windows.Forms.Panel();
            this.lblWIFI = new System.Windows.Forms.Label();
            this.picWIFI = new System.Windows.Forms.PictureBox();
            this.lblErro = new System.Windows.Forms.Label();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.lblSenha = new System.Windows.Forms.Label();
            this.pAtualizar.SuspendLayout();
            this.SuspendLayout();
            // 
            // barraSuperior1
            // 
            this.barraSuperior1.Dock = System.Windows.Forms.DockStyle.Top;
            this.barraSuperior1.Location = new System.Drawing.Point(0, 0);
            this.barraSuperior1.Name = "barraSuperior1";
            this.barraSuperior1.Size = new System.Drawing.Size(480, 70);
            this.barraSuperior1.TabIndex = 8;
            this.barraSuperior1.TabStop = false;
            // 
            // lblMensagem
            // 
            this.lblMensagem.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblMensagem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(19)))), ((int)(((byte)(95)))));
            this.lblMensagem.Location = new System.Drawing.Point(20, 85);
            this.lblMensagem.Name = "lblMensagem";
            this.lblMensagem.Size = new System.Drawing.Size(440, 110);
            this.lblMensagem.Text = "Mensagem";
            this.lblMensagem.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(61)))), ((int)(((byte)(118)))));
            this.btnConfirmar.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnConfirmar.ForeColor = System.Drawing.Color.White;
            this.btnConfirmar.Location = new System.Drawing.Point(336, 500);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(124, 36);
            this.btnConfirmar.TabIndex = 2;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.Click += new System.EventHandler(this.btnSim_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(61)))), ((int)(((byte)(118)))));
            this.btnCancelar.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(20, 500);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(124, 36);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // pAtualizar
            // 
            this.pAtualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(61)))), ((int)(((byte)(118)))));
            this.pAtualizar.Controls.Add(this.lblWIFI);
            this.pAtualizar.Controls.Add(this.picWIFI);
            this.pAtualizar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pAtualizar.Location = new System.Drawing.Point(0, 602);
            this.pAtualizar.Name = "pAtualizar";
            this.pAtualizar.Size = new System.Drawing.Size(480, 38);
            // 
            // lblWIFI
            // 
            this.lblWIFI.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblWIFI.ForeColor = System.Drawing.Color.White;
            this.lblWIFI.Location = new System.Drawing.Point(41, 7);
            this.lblWIFI.Name = "lblWIFI";
            this.lblWIFI.Size = new System.Drawing.Size(158, 28);
            this.lblWIFI.Text = "WIFI";
            // 
            // picWIFI
            // 
            this.picWIFI.Image = ((System.Drawing.Image)(resources.GetObject("picWIFI.Image")));
            this.picWIFI.Location = new System.Drawing.Point(3, 3);
            this.picWIFI.Name = "picWIFI";
            this.picWIFI.Size = new System.Drawing.Size(32, 32);
            this.picWIFI.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // lblErro
            // 
            this.lblErro.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblErro.ForeColor = System.Drawing.Color.Brown;
            this.lblErro.Location = new System.Drawing.Point(20, 350);
            this.lblErro.Name = "lblErro";
            this.lblErro.Size = new System.Drawing.Size(440, 120);
            this.lblErro.Text = "ERRO";
            this.lblErro.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblErro.Visible = false;
            // 
            // txtSenha
            // 
            this.txtSenha.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtSenha.Location = new System.Drawing.Point(200, 260);
            this.txtSenha.MaxLength = 10;
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.PasswordChar = '*';
            this.txtSenha.Size = new System.Drawing.Size(210, 38);
            this.txtSenha.TabIndex = 1;
            // 
            // lblSenha
            // 
            this.lblSenha.BackColor = System.Drawing.Color.Gainsboro;
            this.lblSenha.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblSenha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(19)))), ((int)(((byte)(95)))));
            this.lblSenha.Location = new System.Drawing.Point(90, 260);
            this.lblSenha.Name = "lblSenha";
            this.lblSenha.Size = new System.Drawing.Size(104, 38);
            this.lblSenha.Text = "Senha:";
            // 
            // frmConfirmar
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(480, 640);
            this.ControlBox = false;
            this.Controls.Add(this.txtSenha);
            this.Controls.Add(this.lblSenha);
            this.Controls.Add(this.lblErro);
            this.Controls.Add(this.pAtualizar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.lblMensagem);
            this.Controls.Add(this.barraSuperior1);
            this.Location = new System.Drawing.Point(0, 0);
            this.MinimizeBox = false;
            this.Name = "frmConfirmar";
            this.Text = "EPD - Atenção!";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pAtualizar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ProjetoMobile.Controles.BarraSuperior barraSuperior1;
        public System.Windows.Forms.Label lblMensagem;
        public System.Windows.Forms.Button btnConfirmar;
        public System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Panel pAtualizar;
        private System.Windows.Forms.Label lblWIFI;
        public System.Windows.Forms.PictureBox picWIFI;
        public System.Windows.Forms.Label lblErro;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.Label lblSenha;
    }
}
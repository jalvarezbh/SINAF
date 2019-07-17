namespace ProjetoMobile
{
    partial class frmDialog
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
            this.butCancelar = new System.Windows.Forms.Button();
            this.lblMensagem = new System.Windows.Forms.Label();
            this.butNao = new System.Windows.Forms.Button();
            this.butSim = new System.Windows.Forms.Button();
            this.barraInferior1 = new ProjetoMobile.Controles.BarraInferior();
            this.barraSuperior1 = new ProjetoMobile.Controles.BarraSuperior();
            this.SuspendLayout();
            // 
            // butCancelar
            // 
            this.butCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(61)))), ((int)(((byte)(118)))));
            this.butCancelar.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.butCancelar.ForeColor = System.Drawing.Color.White;
            this.butCancelar.Location = new System.Drawing.Point(20, 500);
            this.butCancelar.Name = "butCancelar";
            this.butCancelar.Size = new System.Drawing.Size(124, 36);
            this.butCancelar.TabIndex = 2;
            this.butCancelar.Text = "Cancelar";
            this.butCancelar.Click += new System.EventHandler(this.butCancelar_Click);
            // 
            // lblMensagem
            // 
            this.lblMensagem.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblMensagem.ForeColor = System.Drawing.Color.Brown;
            this.lblMensagem.Location = new System.Drawing.Point(20, 85);
            this.lblMensagem.Name = "lblMensagem";
            this.lblMensagem.Size = new System.Drawing.Size(440, 395);
            this.lblMensagem.Text = "Mensagem";
            this.lblMensagem.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // butNao
            // 
            this.butNao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(61)))), ((int)(((byte)(118)))));
            this.butNao.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.butNao.ForeColor = System.Drawing.Color.White;
            this.butNao.Location = new System.Drawing.Point(180, 500);
            this.butNao.Name = "butNao";
            this.butNao.Size = new System.Drawing.Size(124, 36);
            this.butNao.TabIndex = 1;
            this.butNao.Text = "Não";
            this.butNao.Click += new System.EventHandler(this.butNao_Click);
            // 
            // butSim
            // 
            this.butSim.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(61)))), ((int)(((byte)(118)))));
            this.butSim.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.butSim.ForeColor = System.Drawing.Color.White;
            this.butSim.Location = new System.Drawing.Point(336, 500);
            this.butSim.Name = "butSim";
            this.butSim.Size = new System.Drawing.Size(124, 36);
            this.butSim.TabIndex = 0;
            this.butSim.Text = "Sim";
            this.butSim.Click += new System.EventHandler(this.butSim_Click);
            // 
            // barraInferior1
            // 
            this.barraInferior1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barraInferior1.Location = new System.Drawing.Point(0, 602);
            this.barraInferior1.Name = "barraInferior1";
            this.barraInferior1.Size = new System.Drawing.Size(480, 38);
            this.barraInferior1.TabIndex = 7;
            this.barraInferior1.TabStop = false;
            // 
            // barraSuperior1
            // 
            this.barraSuperior1.Dock = System.Windows.Forms.DockStyle.Top;
            this.barraSuperior1.Location = new System.Drawing.Point(0, 0);
            this.barraSuperior1.Name = "barraSuperior1";
            this.barraSuperior1.Size = new System.Drawing.Size(480, 70);
            this.barraSuperior1.TabIndex = 6;
            this.barraSuperior1.TabStop = false;
            // 
            // frmDialog
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(480, 640);
            this.ControlBox = false;
            this.Controls.Add(this.butSim);
            this.Controls.Add(this.butNao);
            this.Controls.Add(this.lblMensagem);
            this.Controls.Add(this.butCancelar);
            this.Controls.Add(this.barraInferior1);
            this.Controls.Add(this.barraSuperior1);
            this.Location = new System.Drawing.Point(0, 0);
            this.MinimizeBox = false;
            this.Name = "frmDialog";
            this.Text = "PEP - Atenção!";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmDialog_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ProjetoMobile.Controles.BarraInferior barraInferior1;
        private ProjetoMobile.Controles.BarraSuperior barraSuperior1;
        public System.Windows.Forms.Label lblMensagem;
        public System.Windows.Forms.Button butNao;
        public System.Windows.Forms.Button butSim;
        public System.Windows.Forms.Button butCancelar;
    }
}
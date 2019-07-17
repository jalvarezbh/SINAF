namespace ProjetoMobile
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.picFundo = new System.Windows.Forms.PictureBox();
            this.lblMensagem = new System.Windows.Forms.Label();
            this.btnSair = new System.Windows.Forms.Button();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblSenha = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblVersao = new System.Windows.Forms.Label();
            this.picSincronismo = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.picBateria = new System.Windows.Forms.PictureBox();
            this.lblBateria = new System.Windows.Forms.Label();
            this.lblNumeroColetor = new System.Windows.Forms.Label();
            this.timStatusConexao = new System.Windows.Forms.Timer();
            this.btnSincronismo = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // picFundo
            // 
            this.picFundo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picFundo.Image = ((System.Drawing.Image)(resources.GetObject("picFundo.Image")));
            this.picFundo.Location = new System.Drawing.Point(0, 0);
            this.picFundo.Name = "picFundo";
            this.picFundo.Size = new System.Drawing.Size(480, 640);
            // 
            // lblMensagem
            // 
            this.lblMensagem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.lblMensagem.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblMensagem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(61)))), ((int)(((byte)(118)))));
            this.lblMensagem.Location = new System.Drawing.Point(42, 449);
            this.lblMensagem.Name = "lblMensagem";
            this.lblMensagem.Size = new System.Drawing.Size(404, 74);
            this.lblMensagem.Text = "Efetuando a solicitação, aguarde...";
            this.lblMensagem.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblMensagem.Visible = false;
            // 
            // btnSair
            // 
            this.btnSair.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(61)))), ((int)(((byte)(118)))));
            this.btnSair.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnSair.ForeColor = System.Drawing.Color.White;
            this.btnSair.Location = new System.Drawing.Point(88, 361);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(124, 36);
            this.btnSair.TabIndex = 4;
            this.btnSair.Text = "Sair";
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // txtSenha
            // 
            this.txtSenha.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtSenha.Location = new System.Drawing.Point(188, 295);
            this.txtSenha.MaxLength = 15;
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.PasswordChar = '*';
            this.txtSenha.Size = new System.Drawing.Size(220, 38);
            this.txtSenha.TabIndex = 2;
            this.txtSenha.GotFocus += new System.EventHandler(this.txtSenha_GotFocus);
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(61)))), ((int)(((byte)(118)))));
            this.btnOK.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnOK.ForeColor = System.Drawing.Color.White;
            this.btnOK.Location = new System.Drawing.Point(284, 361);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(124, 36);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "Ok";
            this.btnOK.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblSenha
            // 
            this.lblSenha.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.lblSenha.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblSenha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(61)))), ((int)(((byte)(118)))));
            this.lblSenha.Location = new System.Drawing.Point(67, 295);
            this.lblSenha.Name = "lblSenha";
            this.lblSenha.Size = new System.Drawing.Size(104, 38);
            this.lblSenha.Text = "Senha";
            this.lblSenha.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtUsuario.Location = new System.Drawing.Point(188, 251);
            this.txtUsuario.MaxLength = 15;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(220, 38);
            this.txtUsuario.TabIndex = 1;
            this.txtUsuario.GotFocus += new System.EventHandler(this.txtUsuario_GotFocus);
            // 
            // lblUsuario
            // 
            this.lblUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.lblUsuario.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(61)))), ((int)(((byte)(118)))));
            this.lblUsuario.Location = new System.Drawing.Point(67, 251);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(104, 38);
            this.lblUsuario.Text = "Usuário";
            this.lblUsuario.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblVersao
            // 
            this.lblVersao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.lblVersao.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.lblVersao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(61)))), ((int)(((byte)(118)))));
            this.lblVersao.Location = new System.Drawing.Point(234, 218);
            this.lblVersao.Name = "lblVersao";
            this.lblVersao.Size = new System.Drawing.Size(174, 30);
            this.lblVersao.Text = "Versão 1.00";
            this.lblVersao.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // picSincronismo
            // 
            this.picSincronismo.BackColor = System.Drawing.Color.White;
            this.picSincronismo.Image = ((System.Drawing.Image)(resources.GetObject("picSincronismo.Image")));
            this.picSincronismo.Location = new System.Drawing.Point(10, 4);
            this.picSincronismo.Name = "picSincronismo";
            this.picSincronismo.Size = new System.Drawing.Size(50, 30);
            this.picSincronismo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picSincronismo.Click += new System.EventHandler(this.picSincronismo_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(61)))), ((int)(((byte)(118)))));
            this.panel1.Controls.Add(this.picBateria);
            this.panel1.Controls.Add(this.lblBateria);
            this.panel1.Controls.Add(this.lblNumeroColetor);
            this.panel1.Controls.Add(this.picSincronismo);
            this.panel1.Controls.Add(this.btnSincronismo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 602);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(480, 38);
            // 
            // picBateria
            // 
            this.picBateria.Location = new System.Drawing.Point(437, 3);
            this.picBateria.Name = "picBateria";
            this.picBateria.Size = new System.Drawing.Size(38, 32);
            this.picBateria.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // lblBateria
            // 
            this.lblBateria.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblBateria.ForeColor = System.Drawing.Color.White;
            this.lblBateria.Location = new System.Drawing.Point(350, 7);
            this.lblBateria.Name = "lblBateria";
            this.lblBateria.Size = new System.Drawing.Size(82, 28);
            this.lblBateria.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblNumeroColetor
            // 
            this.lblNumeroColetor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(61)))), ((int)(((byte)(118)))));
            this.lblNumeroColetor.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblNumeroColetor.ForeColor = System.Drawing.Color.White;
            this.lblNumeroColetor.Location = new System.Drawing.Point(70, 7);
            this.lblNumeroColetor.Name = "lblNumeroColetor";
            this.lblNumeroColetor.Size = new System.Drawing.Size(250, 30);
            this.lblNumeroColetor.Text = "Versão 1.00";
            this.lblNumeroColetor.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // timStatusConexao
            // 
            this.timStatusConexao.Enabled = true;
            this.timStatusConexao.Interval = 500;
            this.timStatusConexao.Tick += new System.EventHandler(this.timStatusConexao_Tick);
            // 
            // btnSincronismo
            // 
            this.btnSincronismo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(61)))), ((int)(((byte)(118)))));
            this.btnSincronismo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnSincronismo.ForeColor = System.Drawing.Color.White;
            this.btnSincronismo.Location = new System.Drawing.Point(0, 0);
            this.btnSincronismo.Name = "btnSincronismo";
            this.btnSincronismo.Size = new System.Drawing.Size(70, 38);
            this.btnSincronismo.TabIndex = 7;
            this.btnSincronismo.Click += new System.EventHandler(this.picSincronismo_Click);
            // 
            // frmLogin
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(480, 640);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblVersao);
            this.Controls.Add(this.lblMensagem);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.txtSenha);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblSenha);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.picFundo);
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(0, 0);
            this.MinimizeBox = false;
            this.Name = "frmLogin";
            this.Text = "PEP - Projeto Entrevista Premiada";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.Closed += new System.EventHandler(this.frmLogin_Closed);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmLogin_KeyPress);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picFundo;
        private System.Windows.Forms.Label lblMensagem;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblSenha;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblVersao;
        private System.Windows.Forms.PictureBox picSincronismo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblNumeroColetor;
        public System.Windows.Forms.PictureBox picBateria;
        private System.Windows.Forms.Label lblBateria;
        private System.Windows.Forms.Timer timStatusConexao;
        private System.Windows.Forms.Button btnSincronismo;
    }
}
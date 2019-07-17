namespace ProjetoMobile
{
    partial class frmPremioAlterado
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
            this.btnSalvar = new System.Windows.Forms.Button();
            this.bntSair = new System.Windows.Forms.Button();
            this.tabFeedBack = new System.Windows.Forms.TabControl();
            this.tabPremioCadastro = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.pTabCadastro = new System.Windows.Forms.Panel();
            this.cmbAba1DataNascimentoAno = new System.Windows.Forms.ComboBox();
            this.cmbAba1DataNascimentoMes = new System.Windows.Forms.ComboBox();
            this.cmbAba1DataNascimentoDia = new System.Windows.Forms.ComboBox();
            this.lblAba1DataNascimentoSep2 = new System.Windows.Forms.Label();
            this.lblAba1DataNascimentoSep1 = new System.Windows.Forms.Label();
            this.txtAba1Email = new System.Windows.Forms.TextBox();
            this.txtAba1Celular = new System.Windows.Forms.TextBox();
            this.lblAba1Celular = new System.Windows.Forms.Label();
            this.txtAba1Telefone = new System.Windows.Forms.TextBox();
            this.lblAba1Telefone = new System.Windows.Forms.Label();
            this.cmbAba1Sexo = new System.Windows.Forms.ComboBox();
            this.lblAba1Sexo = new System.Windows.Forms.Label();
            this.txtAba1CPF = new System.Windows.Forms.TextBox();
            this.lblAba1CPF = new System.Windows.Forms.Label();
            this.lblAba1Email = new System.Windows.Forms.Label();
            this.lblAba1DataNascimento = new System.Windows.Forms.Label();
            this.tabEndereco = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblAba2CEPSep1 = new System.Windows.Forms.Label();
            this.txtAba2CEPbox2 = new System.Windows.Forms.TextBox();
            this.cmbAba2UF = new System.Windows.Forms.ComboBox();
            this.lblAba2UF = new System.Windows.Forms.Label();
            this.txtAba2Cidade = new System.Windows.Forms.TextBox();
            this.lblAba2Cidade = new System.Windows.Forms.Label();
            this.txtAba2Bairro = new System.Windows.Forms.TextBox();
            this.lblAba2Bairro = new System.Windows.Forms.Label();
            this.txtAba2Complemento = new System.Windows.Forms.TextBox();
            this.lblAba2Complemento = new System.Windows.Forms.Label();
            this.txtAba2Numero = new System.Windows.Forms.TextBox();
            this.lblAba2Numero = new System.Windows.Forms.Label();
            this.txtAba2Endereco = new System.Windows.Forms.TextBox();
            this.lblAba2Endereco = new System.Windows.Forms.Label();
            this.lblAba2CEP = new System.Windows.Forms.Label();
            this.txtAba2CEPbox1 = new System.Windows.Forms.TextBox();
            this.barraInferior1 = new ProjetoMobile.Controles.BarraInferior();
            this.barraSuperior1 = new ProjetoMobile.Controles.BarraSuperior();
            this.tabFeedBack.SuspendLayout();
            this.tabPremioCadastro.SuspendLayout();
            this.pTabCadastro.SuspendLayout();
            this.tabEndereco.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(61)))), ((int)(((byte)(118)))));
            this.btnSalvar.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnSalvar.ForeColor = System.Drawing.Color.White;
            this.btnSalvar.Location = new System.Drawing.Point(346, 560);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(124, 36);
            this.btnSalvar.TabIndex = 39;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // bntSair
            // 
            this.bntSair.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(61)))), ((int)(((byte)(118)))));
            this.bntSair.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.bntSair.ForeColor = System.Drawing.Color.White;
            this.bntSair.Location = new System.Drawing.Point(10, 560);
            this.bntSair.Name = "bntSair";
            this.bntSair.Size = new System.Drawing.Size(124, 36);
            this.bntSair.TabIndex = 38;
            this.bntSair.Text = "Voltar";
            this.bntSair.Click += new System.EventHandler(this.bntSair_Click);
            // 
            // tabFeedBack
            // 
            this.tabFeedBack.Controls.Add(this.tabPremioCadastro);
            this.tabFeedBack.Controls.Add(this.tabEndereco);
            this.tabFeedBack.Dock = System.Windows.Forms.DockStyle.None;
            this.tabFeedBack.Location = new System.Drawing.Point(0, 70);
            this.tabFeedBack.Name = "tabFeedBack";
            this.tabFeedBack.SelectedIndex = 0;
            this.tabFeedBack.Size = new System.Drawing.Size(480, 486);
            this.tabFeedBack.TabIndex = 37;
            // 
            // tabPremioCadastro
            // 
            this.tabPremioCadastro.BackColor = System.Drawing.Color.Gainsboro;
            this.tabPremioCadastro.Controls.Add(this.label1);
            this.tabPremioCadastro.Controls.Add(this.pTabCadastro);
            this.tabPremioCadastro.Location = new System.Drawing.Point(0, 0);
            this.tabPremioCadastro.Name = "tabPremioCadastro";
            this.tabPremioCadastro.Size = new System.Drawing.Size(480, 442);
            this.tabPremioCadastro.Text = "Cadastro";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(61)))), ((int)(((byte)(118)))));
            this.label1.Location = new System.Drawing.Point(10, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(450, 30);
            this.label1.Text = "Entrevista Premiada - Dados Cadastrais";
            // 
            // pTabCadastro
            // 
            this.pTabCadastro.AutoScroll = true;
            this.pTabCadastro.Controls.Add(this.cmbAba1DataNascimentoAno);
            this.pTabCadastro.Controls.Add(this.cmbAba1DataNascimentoMes);
            this.pTabCadastro.Controls.Add(this.cmbAba1DataNascimentoDia);
            this.pTabCadastro.Controls.Add(this.lblAba1DataNascimentoSep2);
            this.pTabCadastro.Controls.Add(this.lblAba1DataNascimentoSep1);
            this.pTabCadastro.Controls.Add(this.txtAba1Email);
            this.pTabCadastro.Controls.Add(this.txtAba1Celular);
            this.pTabCadastro.Controls.Add(this.lblAba1Celular);
            this.pTabCadastro.Controls.Add(this.txtAba1Telefone);
            this.pTabCadastro.Controls.Add(this.lblAba1Telefone);
            this.pTabCadastro.Controls.Add(this.cmbAba1Sexo);
            this.pTabCadastro.Controls.Add(this.lblAba1Sexo);
            this.pTabCadastro.Controls.Add(this.txtAba1CPF);
            this.pTabCadastro.Controls.Add(this.lblAba1CPF);
            this.pTabCadastro.Controls.Add(this.lblAba1Email);
            this.pTabCadastro.Controls.Add(this.lblAba1DataNascimento);
            this.pTabCadastro.Location = new System.Drawing.Point(10, 45);
            this.pTabCadastro.Name = "pTabCadastro";
            this.pTabCadastro.Size = new System.Drawing.Size(460, 400);
            // 
            // cmbAba1DataNascimentoAno
            // 
            this.cmbAba1DataNascimentoAno.Items.Add("F");
            this.cmbAba1DataNascimentoAno.Items.Add("M");
            this.cmbAba1DataNascimentoAno.Location = new System.Drawing.Point(245, 115);
            this.cmbAba1DataNascimentoAno.Name = "cmbAba1DataNascimentoAno";
            this.cmbAba1DataNascimentoAno.Size = new System.Drawing.Size(180, 41);
            this.cmbAba1DataNascimentoAno.TabIndex = 15;
            this.cmbAba1DataNascimentoAno.GotFocus += new System.EventHandler(this.Numero_GotFocus);
            // 
            // cmbAba1DataNascimentoMes
            // 
            this.cmbAba1DataNascimentoMes.Items.Add("F");
            this.cmbAba1DataNascimentoMes.Items.Add("M");
            this.cmbAba1DataNascimentoMes.Location = new System.Drawing.Point(135, 115);
            this.cmbAba1DataNascimentoMes.Name = "cmbAba1DataNascimentoMes";
            this.cmbAba1DataNascimentoMes.Size = new System.Drawing.Size(80, 41);
            this.cmbAba1DataNascimentoMes.TabIndex = 14;
            this.cmbAba1DataNascimentoMes.SelectedIndexChanged += new System.EventHandler(this.cmbAba1DataNascimentoMes_SelectedIndexChanged);
            this.cmbAba1DataNascimentoMes.GotFocus += new System.EventHandler(this.Numero_GotFocus);
            // 
            // cmbAba1DataNascimentoDia
            // 
            this.cmbAba1DataNascimentoDia.Items.Add("F");
            this.cmbAba1DataNascimentoDia.Items.Add("M");
            this.cmbAba1DataNascimentoDia.Location = new System.Drawing.Point(25, 115);
            this.cmbAba1DataNascimentoDia.Name = "cmbAba1DataNascimentoDia";
            this.cmbAba1DataNascimentoDia.Size = new System.Drawing.Size(80, 41);
            this.cmbAba1DataNascimentoDia.TabIndex = 13;
            this.cmbAba1DataNascimentoDia.GotFocus += new System.EventHandler(this.Numero_GotFocus);
            // 
            // lblAba1DataNascimentoSep2
            // 
            this.lblAba1DataNascimentoSep2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblAba1DataNascimentoSep2.Location = new System.Drawing.Point(220, 115);
            this.lblAba1DataNascimentoSep2.Name = "lblAba1DataNascimentoSep2";
            this.lblAba1DataNascimentoSep2.Size = new System.Drawing.Size(20, 38);
            this.lblAba1DataNascimentoSep2.Text = "/";
            // 
            // lblAba1DataNascimentoSep1
            // 
            this.lblAba1DataNascimentoSep1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblAba1DataNascimentoSep1.Location = new System.Drawing.Point(110, 115);
            this.lblAba1DataNascimentoSep1.Name = "lblAba1DataNascimentoSep1";
            this.lblAba1DataNascimentoSep1.Size = new System.Drawing.Size(20, 38);
            this.lblAba1DataNascimentoSep1.Text = "/";
            // 
            // txtAba1Email
            // 
            this.txtAba1Email.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtAba1Email.Location = new System.Drawing.Point(25, 340);
            this.txtAba1Email.MaxLength = 100;
            this.txtAba1Email.Name = "txtAba1Email";
            this.txtAba1Email.Size = new System.Drawing.Size(400, 38);
            this.txtAba1Email.TabIndex = 18;
            this.txtAba1Email.GotFocus += new System.EventHandler(this.Texto_GotFocus);
            this.txtAba1Email.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtAba1Email_KeyUp);
            this.txtAba1Email.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAba1Email_KeyPress);
            // 
            // txtAba1Celular
            // 
            this.txtAba1Celular.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtAba1Celular.Location = new System.Drawing.Point(25, 265);
            this.txtAba1Celular.MaxLength = 100;
            this.txtAba1Celular.Name = "txtAba1Celular";
            this.txtAba1Celular.Size = new System.Drawing.Size(400, 38);
            this.txtAba1Celular.TabIndex = 17;
            this.txtAba1Celular.Text = "(21)";
            this.txtAba1Celular.GotFocus += new System.EventHandler(this.Numero_GotFocus);
            this.txtAba1Celular.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Telefone_KeyPress);
            // 
            // lblAba1Celular
            // 
            this.lblAba1Celular.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblAba1Celular.Location = new System.Drawing.Point(25, 230);
            this.lblAba1Celular.Name = "lblAba1Celular";
            this.lblAba1Celular.Size = new System.Drawing.Size(400, 38);
            this.lblAba1Celular.Text = "Telefone Celular :";
            // 
            // txtAba1Telefone
            // 
            this.txtAba1Telefone.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtAba1Telefone.Location = new System.Drawing.Point(25, 190);
            this.txtAba1Telefone.MaxLength = 100;
            this.txtAba1Telefone.Name = "txtAba1Telefone";
            this.txtAba1Telefone.Size = new System.Drawing.Size(400, 38);
            this.txtAba1Telefone.TabIndex = 16;
            this.txtAba1Telefone.Text = "(21)";
            this.txtAba1Telefone.GotFocus += new System.EventHandler(this.Numero_GotFocus);
            this.txtAba1Telefone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Telefone_KeyPress);
            // 
            // lblAba1Telefone
            // 
            this.lblAba1Telefone.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblAba1Telefone.Location = new System.Drawing.Point(25, 155);
            this.lblAba1Telefone.Name = "lblAba1Telefone";
            this.lblAba1Telefone.Size = new System.Drawing.Size(400, 38);
            this.lblAba1Telefone.Text = "Telefone Residencial :";
            // 
            // cmbAba1Sexo
            // 
            this.cmbAba1Sexo.Items.Add("F");
            this.cmbAba1Sexo.Items.Add("M");
            this.cmbAba1Sexo.Location = new System.Drawing.Point(345, 40);
            this.cmbAba1Sexo.Name = "cmbAba1Sexo";
            this.cmbAba1Sexo.Size = new System.Drawing.Size(80, 41);
            this.cmbAba1Sexo.TabIndex = 12;
            this.cmbAba1Sexo.GotFocus += new System.EventHandler(this.Texto_GotFocus);
            // 
            // lblAba1Sexo
            // 
            this.lblAba1Sexo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblAba1Sexo.Location = new System.Drawing.Point(345, 5);
            this.lblAba1Sexo.Name = "lblAba1Sexo";
            this.lblAba1Sexo.Size = new System.Drawing.Size(80, 38);
            this.lblAba1Sexo.Text = "Sexo :";
            // 
            // txtAba1CPF
            // 
            this.txtAba1CPF.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtAba1CPF.Location = new System.Drawing.Point(25, 40);
            this.txtAba1CPF.MaxLength = 100;
            this.txtAba1CPF.Name = "txtAba1CPF";
            this.txtAba1CPF.Size = new System.Drawing.Size(300, 38);
            this.txtAba1CPF.TabIndex = 11;
            this.txtAba1CPF.GotFocus += new System.EventHandler(this.Numero_GotFocus);
            this.txtAba1CPF.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CPF_KeyPress);
            // 
            // lblAba1CPF
            // 
            this.lblAba1CPF.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblAba1CPF.Location = new System.Drawing.Point(25, 5);
            this.lblAba1CPF.Name = "lblAba1CPF";
            this.lblAba1CPF.Size = new System.Drawing.Size(250, 38);
            this.lblAba1CPF.Text = "CPF :";
            // 
            // lblAba1Email
            // 
            this.lblAba1Email.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblAba1Email.Location = new System.Drawing.Point(25, 305);
            this.lblAba1Email.Name = "lblAba1Email";
            this.lblAba1Email.Size = new System.Drawing.Size(200, 38);
            this.lblAba1Email.Text = "E-mail :";
            // 
            // lblAba1DataNascimento
            // 
            this.lblAba1DataNascimento.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblAba1DataNascimento.Location = new System.Drawing.Point(25, 80);
            this.lblAba1DataNascimento.Name = "lblAba1DataNascimento";
            this.lblAba1DataNascimento.Size = new System.Drawing.Size(250, 38);
            this.lblAba1DataNascimento.Text = "Data de Nascimento :";
            // 
            // tabEndereco
            // 
            this.tabEndereco.BackColor = System.Drawing.Color.Gainsboro;
            this.tabEndereco.Controls.Add(this.label5);
            this.tabEndereco.Controls.Add(this.panel1);
            this.tabEndereco.Location = new System.Drawing.Point(0, 0);
            this.tabEndereco.Name = "tabEndereco";
            this.tabEndereco.Size = new System.Drawing.Size(472, 448);
            this.tabEndereco.Text = "Endereço";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(61)))), ((int)(((byte)(118)))));
            this.label5.Location = new System.Drawing.Point(10, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(400, 30);
            this.label5.Text = "Entrevista Premiada - Endereço";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.lblAba2CEPSep1);
            this.panel1.Controls.Add(this.txtAba2CEPbox2);
            this.panel1.Controls.Add(this.cmbAba2UF);
            this.panel1.Controls.Add(this.lblAba2UF);
            this.panel1.Controls.Add(this.txtAba2Cidade);
            this.panel1.Controls.Add(this.lblAba2Cidade);
            this.panel1.Controls.Add(this.txtAba2Bairro);
            this.panel1.Controls.Add(this.lblAba2Bairro);
            this.panel1.Controls.Add(this.txtAba2Complemento);
            this.panel1.Controls.Add(this.lblAba2Complemento);
            this.panel1.Controls.Add(this.txtAba2Numero);
            this.panel1.Controls.Add(this.lblAba2Numero);
            this.panel1.Controls.Add(this.txtAba2Endereco);
            this.panel1.Controls.Add(this.lblAba2Endereco);
            this.panel1.Controls.Add(this.lblAba2CEP);
            this.panel1.Controls.Add(this.txtAba2CEPbox1);
            this.panel1.Location = new System.Drawing.Point(10, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(460, 400);
            // 
            // lblAba2CEPSep1
            // 
            this.lblAba2CEPSep1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblAba2CEPSep1.Location = new System.Drawing.Point(290, 10);
            this.lblAba2CEPSep1.Name = "lblAba2CEPSep1";
            this.lblAba2CEPSep1.Size = new System.Drawing.Size(20, 38);
            this.lblAba2CEPSep1.Text = "-";
            // 
            // txtAba2CEPbox2
            // 
            this.txtAba2CEPbox2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtAba2CEPbox2.Location = new System.Drawing.Point(320, 10);
            this.txtAba2CEPbox2.MaxLength = 3;
            this.txtAba2CEPbox2.Name = "txtAba2CEPbox2";
            this.txtAba2CEPbox2.Size = new System.Drawing.Size(105, 38);
            this.txtAba2CEPbox2.TabIndex = 22;
            this.txtAba2CEPbox2.GotFocus += new System.EventHandler(this.Numero_GotFocus);
            this.txtAba2CEPbox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CEP_KeyPress);
            // 
            // cmbAba2UF
            // 
            this.cmbAba2UF.Location = new System.Drawing.Point(345, 325);
            this.cmbAba2UF.Name = "cmbAba2UF";
            this.cmbAba2UF.Size = new System.Drawing.Size(80, 41);
            this.cmbAba2UF.TabIndex = 28;
            this.cmbAba2UF.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cmbAba2UF_KeyUp);
            this.cmbAba2UF.GotFocus += new System.EventHandler(this.Texto_GotFocus);
            // 
            // lblAba2UF
            // 
            this.lblAba2UF.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblAba2UF.Location = new System.Drawing.Point(345, 285);
            this.lblAba2UF.Name = "lblAba2UF";
            this.lblAba2UF.Size = new System.Drawing.Size(60, 38);
            this.lblAba2UF.Text = "UF :";
            // 
            // txtAba2Cidade
            // 
            this.txtAba2Cidade.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtAba2Cidade.Location = new System.Drawing.Point(25, 325);
            this.txtAba2Cidade.MaxLength = 100;
            this.txtAba2Cidade.Name = "txtAba2Cidade";
            this.txtAba2Cidade.Size = new System.Drawing.Size(300, 38);
            this.txtAba2Cidade.TabIndex = 27;
            this.txtAba2Cidade.GotFocus += new System.EventHandler(this.Texto_GotFocus);
            this.txtAba2Cidade.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UpperCase_KeyPress);
            // 
            // lblAba2Cidade
            // 
            this.lblAba2Cidade.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblAba2Cidade.Location = new System.Drawing.Point(25, 285);
            this.lblAba2Cidade.Name = "lblAba2Cidade";
            this.lblAba2Cidade.Size = new System.Drawing.Size(200, 38);
            this.lblAba2Cidade.Text = "Cidade :";
            // 
            // txtAba2Bairro
            // 
            this.txtAba2Bairro.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtAba2Bairro.Location = new System.Drawing.Point(25, 245);
            this.txtAba2Bairro.MaxLength = 100;
            this.txtAba2Bairro.Name = "txtAba2Bairro";
            this.txtAba2Bairro.Size = new System.Drawing.Size(400, 38);
            this.txtAba2Bairro.TabIndex = 26;
            this.txtAba2Bairro.GotFocus += new System.EventHandler(this.Texto_GotFocus);
            this.txtAba2Bairro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UpperCase_KeyPress);
            // 
            // lblAba2Bairro
            // 
            this.lblAba2Bairro.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblAba2Bairro.Location = new System.Drawing.Point(25, 210);
            this.lblAba2Bairro.Name = "lblAba2Bairro";
            this.lblAba2Bairro.Size = new System.Drawing.Size(200, 38);
            this.lblAba2Bairro.Text = "Bairro :";
            // 
            // txtAba2Complemento
            // 
            this.txtAba2Complemento.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtAba2Complemento.Location = new System.Drawing.Point(245, 170);
            this.txtAba2Complemento.MaxLength = 100;
            this.txtAba2Complemento.Name = "txtAba2Complemento";
            this.txtAba2Complemento.Size = new System.Drawing.Size(180, 38);
            this.txtAba2Complemento.TabIndex = 25;
            this.txtAba2Complemento.GotFocus += new System.EventHandler(this.Texto_GotFocus);
            // 
            // lblAba2Complemento
            // 
            this.lblAba2Complemento.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblAba2Complemento.Location = new System.Drawing.Point(245, 135);
            this.lblAba2Complemento.Name = "lblAba2Complemento";
            this.lblAba2Complemento.Size = new System.Drawing.Size(180, 38);
            this.lblAba2Complemento.Text = "Complemento :";
            // 
            // txtAba2Numero
            // 
            this.txtAba2Numero.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtAba2Numero.Location = new System.Drawing.Point(25, 170);
            this.txtAba2Numero.MaxLength = 100;
            this.txtAba2Numero.Name = "txtAba2Numero";
            this.txtAba2Numero.Size = new System.Drawing.Size(180, 38);
            this.txtAba2Numero.TabIndex = 24;
            this.txtAba2Numero.GotFocus += new System.EventHandler(this.Numero_GotFocus);
            this.txtAba2Numero.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Numero_KeyPress);
            // 
            // lblAba2Numero
            // 
            this.lblAba2Numero.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblAba2Numero.Location = new System.Drawing.Point(25, 135);
            this.lblAba2Numero.Name = "lblAba2Numero";
            this.lblAba2Numero.Size = new System.Drawing.Size(180, 38);
            this.lblAba2Numero.Text = "Número :";
            // 
            // txtAba2Endereco
            // 
            this.txtAba2Endereco.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtAba2Endereco.Location = new System.Drawing.Point(25, 95);
            this.txtAba2Endereco.MaxLength = 100;
            this.txtAba2Endereco.Name = "txtAba2Endereco";
            this.txtAba2Endereco.Size = new System.Drawing.Size(400, 38);
            this.txtAba2Endereco.TabIndex = 23;
            this.txtAba2Endereco.GotFocus += new System.EventHandler(this.Texto_GotFocus);
            this.txtAba2Endereco.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UpperCase_KeyPress);
            // 
            // lblAba2Endereco
            // 
            this.lblAba2Endereco.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblAba2Endereco.Location = new System.Drawing.Point(25, 60);
            this.lblAba2Endereco.Name = "lblAba2Endereco";
            this.lblAba2Endereco.Size = new System.Drawing.Size(200, 38);
            this.lblAba2Endereco.Text = "Endereço :";
            // 
            // lblAba2CEP
            // 
            this.lblAba2CEP.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblAba2CEP.Location = new System.Drawing.Point(25, 15);
            this.lblAba2CEP.Name = "lblAba2CEP";
            this.lblAba2CEP.Size = new System.Drawing.Size(70, 38);
            this.lblAba2CEP.Text = "CEP :";
            // 
            // txtAba2CEPbox1
            // 
            this.txtAba2CEPbox1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtAba2CEPbox1.Location = new System.Drawing.Point(100, 10);
            this.txtAba2CEPbox1.MaxLength = 5;
            this.txtAba2CEPbox1.Name = "txtAba2CEPbox1";
            this.txtAba2CEPbox1.Size = new System.Drawing.Size(180, 38);
            this.txtAba2CEPbox1.TabIndex = 21;
            this.txtAba2CEPbox1.GotFocus += new System.EventHandler(this.Numero_GotFocus);
            this.txtAba2CEPbox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CEP_KeyPress);
            // 
            // barraInferior1
            // 
            this.barraInferior1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barraInferior1.Location = new System.Drawing.Point(0, 602);
            this.barraInferior1.Name = "barraInferior1";
            this.barraInferior1.Size = new System.Drawing.Size(480, 38);
            this.barraInferior1.TabIndex = 36;
            // 
            // barraSuperior1
            // 
            this.barraSuperior1.Dock = System.Windows.Forms.DockStyle.Top;
            this.barraSuperior1.Location = new System.Drawing.Point(0, 0);
            this.barraSuperior1.Name = "barraSuperior1";
            this.barraSuperior1.Size = new System.Drawing.Size(480, 70);
            this.barraSuperior1.TabIndex = 35;
            // 
            // frmPremioAlterado
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(480, 640);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.bntSair);
            this.Controls.Add(this.tabFeedBack);
            this.Controls.Add(this.barraInferior1);
            this.Controls.Add(this.barraSuperior1);
            this.Location = new System.Drawing.Point(0, 0);
            this.MinimizeBox = false;
            this.Name = "frmPremioAlterado";
            this.Text = "frmPremioAlterado";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tabFeedBack.ResumeLayout(false);
            this.tabPremioCadastro.ResumeLayout(false);
            this.pTabCadastro.ResumeLayout(false);
            this.tabEndereco.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button bntSair;
        private System.Windows.Forms.TabControl tabFeedBack;
        private System.Windows.Forms.TabPage tabPremioCadastro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pTabCadastro;
        private System.Windows.Forms.TextBox txtAba1Email;
        private System.Windows.Forms.TextBox txtAba1Celular;
        private System.Windows.Forms.Label lblAba1Celular;
        private System.Windows.Forms.TextBox txtAba1Telefone;
        private System.Windows.Forms.Label lblAba1Telefone;
        private System.Windows.Forms.ComboBox cmbAba1Sexo;
        private System.Windows.Forms.Label lblAba1Sexo;
        private System.Windows.Forms.TextBox txtAba1CPF;
        private System.Windows.Forms.Label lblAba1CPF;
        private System.Windows.Forms.Label lblAba1Email;
        private System.Windows.Forms.Label lblAba1DataNascimento;
        private System.Windows.Forms.TabPage tabEndereco;
        private ProjetoMobile.Controles.BarraInferior barraInferior1;
        private ProjetoMobile.Controles.BarraSuperior barraSuperior1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbAba2UF;
        private System.Windows.Forms.Label lblAba2UF;
        private System.Windows.Forms.TextBox txtAba2Cidade;
        private System.Windows.Forms.Label lblAba2Cidade;
        private System.Windows.Forms.TextBox txtAba2Bairro;
        private System.Windows.Forms.Label lblAba2Bairro;
        private System.Windows.Forms.TextBox txtAba2Complemento;
        private System.Windows.Forms.Label lblAba2Complemento;
        private System.Windows.Forms.TextBox txtAba2Numero;
        private System.Windows.Forms.Label lblAba2Numero;
        private System.Windows.Forms.TextBox txtAba2Endereco;
        private System.Windows.Forms.Label lblAba2Endereco;
        private System.Windows.Forms.Label lblAba2CEP;
        private System.Windows.Forms.TextBox txtAba2CEPbox1;
        private System.Windows.Forms.Label lblAba1DataNascimentoSep2;
        private System.Windows.Forms.Label lblAba1DataNascimentoSep1;
        private System.Windows.Forms.ComboBox cmbAba1DataNascimentoDia;
        private System.Windows.Forms.ComboBox cmbAba1DataNascimentoAno;
        private System.Windows.Forms.ComboBox cmbAba1DataNascimentoMes;
        private System.Windows.Forms.Label lblAba2CEPSep1;
        private System.Windows.Forms.TextBox txtAba2CEPbox2;
    }
}
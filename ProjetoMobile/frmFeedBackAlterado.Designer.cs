namespace ProjetoMobile
{
    partial class frmFeedBackAlterado
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
            this.tabConsultorQuestao1 = new System.Windows.Forms.TabPage();
            this.pAba1Panel = new System.Windows.Forms.Panel();
            this.chkAba1PR = new System.Windows.Forms.CheckBox();
            this.chkAba1I = new System.Windows.Forms.CheckBox();
            this.chkAba1R = new System.Windows.Forms.CheckBox();
            this.chkAba1MR = new System.Windows.Forms.CheckBox();
            this.lblAba1Title = new System.Windows.Forms.Label();
            this.lblAba1PerguntaDescricao = new System.Windows.Forms.Label();
            this.lblAba1Pergunta = new System.Windows.Forms.Label();
            this.tabConsultorQuestao2 = new System.Windows.Forms.TabPage();
            this.pAba2Panel = new System.Windows.Forms.Panel();
            this.pMotivo = new System.Windows.Forms.Panel();
            this.pMotivoNao = new System.Windows.Forms.Panel();
            this.pMotivoNaoAgendado = new System.Windows.Forms.Panel();
            this.cmbAba2MotivoNaoAgendamentoMinuto = new System.Windows.Forms.ComboBox();
            this.cmbAba2MotivoNaoAgendamentoHora = new System.Windows.Forms.ComboBox();
            this.lblAba2MotivoNaoAgendamentoSep3 = new System.Windows.Forms.Label();
            this.lblAba2MotivoNaoAgendamentoHora = new System.Windows.Forms.Label();
            this.cmbAba2MotivoNaoAgendamentoAno = new System.Windows.Forms.ComboBox();
            this.cmbAba2MotivoNaoAgendamentoMes = new System.Windows.Forms.ComboBox();
            this.cmbAba2MotivoNaoAgendamentoDia = new System.Windows.Forms.ComboBox();
            this.lblAba2MotivoNaoAgendamentoSep2 = new System.Windows.Forms.Label();
            this.lblAba2MotivoNaoAgendamentoSep1 = new System.Windows.Forms.Label();
            this.lblAba2MotivoNaoAgendamento = new System.Windows.Forms.Label();
            this.cmbAba2MotivoNao = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.pMotivoSim = new System.Windows.Forms.Panel();
            this.lblAba2PerguntaSim = new System.Windows.Forms.Label();
            this.txtAba2MotivoSimProposta = new System.Windows.Forms.TextBox();
            this.pPergunta2Title = new System.Windows.Forms.Panel();
            this.chkAba2Nao = new System.Windows.Forms.CheckBox();
            this.chkAba2Sim = new System.Windows.Forms.CheckBox();
            this.lblAba2Title = new System.Windows.Forms.Label();
            this.lblAba2Pergunta = new System.Windows.Forms.Label();
            this.lblAba2PerguntaDescricao = new System.Windows.Forms.Label();
            this.barraInferior1 = new ProjetoMobile.Controles.BarraInferior();
            this.barraSuperior1 = new ProjetoMobile.Controles.BarraSuperior();
            this.tabFeedBack.SuspendLayout();
            this.tabConsultorQuestao1.SuspendLayout();
            this.pAba1Panel.SuspendLayout();
            this.tabConsultorQuestao2.SuspendLayout();
            this.pAba2Panel.SuspendLayout();
            this.pMotivo.SuspendLayout();
            this.pMotivoNao.SuspendLayout();
            this.pMotivoNaoAgendado.SuspendLayout();
            this.pMotivoSim.SuspendLayout();
            this.pPergunta2Title.SuspendLayout();
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
            this.btnSalvar.TabIndex = 34;
            this.btnSalvar.Text = "Concluir";
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
            this.bntSair.TabIndex = 33;
            this.bntSair.Text = "Voltar";
            this.bntSair.Click += new System.EventHandler(this.bntSair_Click);
            // 
            // tabFeedBack
            // 
            this.tabFeedBack.Controls.Add(this.tabConsultorQuestao1);
            this.tabFeedBack.Controls.Add(this.tabConsultorQuestao2);
            this.tabFeedBack.Dock = System.Windows.Forms.DockStyle.None;
            this.tabFeedBack.Location = new System.Drawing.Point(0, 70);
            this.tabFeedBack.Name = "tabFeedBack";
            this.tabFeedBack.SelectedIndex = 0;
            this.tabFeedBack.Size = new System.Drawing.Size(480, 486);
            this.tabFeedBack.TabIndex = 32;
            this.tabFeedBack.SelectedIndexChanged += new System.EventHandler(this.tabFeedBack_SelectedIndexChanged);
            // 
            // tabConsultorQuestao1
            // 
            this.tabConsultorQuestao1.BackColor = System.Drawing.Color.Gainsboro;
            this.tabConsultorQuestao1.Controls.Add(this.pAba1Panel);
            this.tabConsultorQuestao1.Location = new System.Drawing.Point(0, 0);
            this.tabConsultorQuestao1.Name = "tabConsultorQuestao1";
            this.tabConsultorQuestao1.Size = new System.Drawing.Size(480, 442);
            this.tabConsultorQuestao1.Text = "Pergunta 1";
            // 
            // pAba1Panel
            // 
            this.pAba1Panel.AutoScroll = true;
            this.pAba1Panel.Controls.Add(this.chkAba1PR);
            this.pAba1Panel.Controls.Add(this.chkAba1I);
            this.pAba1Panel.Controls.Add(this.chkAba1R);
            this.pAba1Panel.Controls.Add(this.chkAba1MR);
            this.pAba1Panel.Controls.Add(this.lblAba1Title);
            this.pAba1Panel.Controls.Add(this.lblAba1PerguntaDescricao);
            this.pAba1Panel.Controls.Add(this.lblAba1Pergunta);
            this.pAba1Panel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pAba1Panel.Location = new System.Drawing.Point(0, 0);
            this.pAba1Panel.Name = "pAba1Panel";
            this.pAba1Panel.Size = new System.Drawing.Size(480, 442);
            // 
            // chkAba1PR
            // 
            this.chkAba1PR.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.chkAba1PR.Location = new System.Drawing.Point(25, 330);
            this.chkAba1PR.Name = "chkAba1PR";
            this.chkAba1PR.Size = new System.Drawing.Size(300, 40);
            this.chkAba1PR.TabIndex = 64;
            this.chkAba1PR.Text = "Pouco receptivo";
            this.chkAba1PR.Click += new System.EventHandler(this.chkAba1_Click);
            // 
            // chkAba1I
            // 
            this.chkAba1I.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.chkAba1I.Location = new System.Drawing.Point(25, 280);
            this.chkAba1I.Name = "chkAba1I";
            this.chkAba1I.Size = new System.Drawing.Size(200, 40);
            this.chkAba1I.TabIndex = 63;
            this.chkAba1I.Text = "Indiferente";
            this.chkAba1I.Click += new System.EventHandler(this.chkAba1_Click);
            // 
            // chkAba1R
            // 
            this.chkAba1R.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.chkAba1R.Location = new System.Drawing.Point(25, 230);
            this.chkAba1R.Name = "chkAba1R";
            this.chkAba1R.Size = new System.Drawing.Size(200, 40);
            this.chkAba1R.TabIndex = 62;
            this.chkAba1R.Text = "Receptivo";
            this.chkAba1R.Click += new System.EventHandler(this.chkAba1_Click);
            // 
            // chkAba1MR
            // 
            this.chkAba1MR.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.chkAba1MR.Location = new System.Drawing.Point(25, 180);
            this.chkAba1MR.Name = "chkAba1MR";
            this.chkAba1MR.Size = new System.Drawing.Size(300, 40);
            this.chkAba1MR.TabIndex = 61;
            this.chkAba1MR.Text = "Muito receptivo";
            this.chkAba1MR.Click += new System.EventHandler(this.chkAba1_Click);
            // 
            // lblAba1Title
            // 
            this.lblAba1Title.BackColor = System.Drawing.Color.Gainsboro;
            this.lblAba1Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAba1Title.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblAba1Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(61)))), ((int)(((byte)(118)))));
            this.lblAba1Title.Location = new System.Drawing.Point(0, 0);
            this.lblAba1Title.Name = "lblAba1Title";
            this.lblAba1Title.Size = new System.Drawing.Size(480, 38);
            this.lblAba1Title.Text = "Espaço Consultor";
            this.lblAba1Title.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblAba1PerguntaDescricao
            // 
            this.lblAba1PerguntaDescricao.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblAba1PerguntaDescricao.Location = new System.Drawing.Point(25, 85);
            this.lblAba1PerguntaDescricao.Name = "lblAba1PerguntaDescricao";
            this.lblAba1PerguntaDescricao.Size = new System.Drawing.Size(423, 84);
            this.lblAba1PerguntaDescricao.Text = "Qual o grau de receptividade do(a) entrevistado(a) aos produtos SINAF apresentado" +
                "s?";
            // 
            // lblAba1Pergunta
            // 
            this.lblAba1Pergunta.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblAba1Pergunta.Location = new System.Drawing.Point(25, 45);
            this.lblAba1Pergunta.Name = "lblAba1Pergunta";
            this.lblAba1Pergunta.Size = new System.Drawing.Size(200, 38);
            this.lblAba1Pergunta.Text = "Pergunta 1 :";
            // 
            // tabConsultorQuestao2
            // 
            this.tabConsultorQuestao2.BackColor = System.Drawing.Color.Gainsboro;
            this.tabConsultorQuestao2.Controls.Add(this.pAba2Panel);
            this.tabConsultorQuestao2.Location = new System.Drawing.Point(0, 0);
            this.tabConsultorQuestao2.Name = "tabConsultorQuestao2";
            this.tabConsultorQuestao2.Size = new System.Drawing.Size(472, 448);
            this.tabConsultorQuestao2.Text = "Pergunta 2";
            // 
            // pAba2Panel
            // 
            this.pAba2Panel.Controls.Add(this.pMotivo);
            this.pAba2Panel.Controls.Add(this.pPergunta2Title);
            this.pAba2Panel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pAba2Panel.Location = new System.Drawing.Point(0, 6);
            this.pAba2Panel.Name = "pAba2Panel";
            this.pAba2Panel.Size = new System.Drawing.Size(472, 442);
            // 
            // pMotivo
            // 
            this.pMotivo.Controls.Add(this.pMotivoNao);
            this.pMotivo.Controls.Add(this.pMotivoSim);
            this.pMotivo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pMotivo.Location = new System.Drawing.Point(0, 180);
            this.pMotivo.Name = "pMotivo";
            this.pMotivo.Size = new System.Drawing.Size(472, 260);
            // 
            // pMotivoNao
            // 
            this.pMotivoNao.AutoScroll = true;
            this.pMotivoNao.Controls.Add(this.pMotivoNaoAgendado);
            this.pMotivoNao.Controls.Add(this.cmbAba2MotivoNao);
            this.pMotivoNao.Controls.Add(this.label23);
            this.pMotivoNao.Dock = System.Windows.Forms.DockStyle.Top;
            this.pMotivoNao.Location = new System.Drawing.Point(0, 100);
            this.pMotivoNao.Name = "pMotivoNao";
            this.pMotivoNao.Size = new System.Drawing.Size(472, 280);
            this.pMotivoNao.Visible = false;
            // 
            // pMotivoNaoAgendado
            // 
            this.pMotivoNaoAgendado.Controls.Add(this.cmbAba2MotivoNaoAgendamentoMinuto);
            this.pMotivoNaoAgendado.Controls.Add(this.cmbAba2MotivoNaoAgendamentoHora);
            this.pMotivoNaoAgendado.Controls.Add(this.lblAba2MotivoNaoAgendamentoSep3);
            this.pMotivoNaoAgendado.Controls.Add(this.lblAba2MotivoNaoAgendamentoHora);
            this.pMotivoNaoAgendado.Controls.Add(this.cmbAba2MotivoNaoAgendamentoAno);
            this.pMotivoNaoAgendado.Controls.Add(this.cmbAba2MotivoNaoAgendamentoMes);
            this.pMotivoNaoAgendado.Controls.Add(this.cmbAba2MotivoNaoAgendamentoDia);
            this.pMotivoNaoAgendado.Controls.Add(this.lblAba2MotivoNaoAgendamentoSep2);
            this.pMotivoNaoAgendado.Controls.Add(this.lblAba2MotivoNaoAgendamentoSep1);
            this.pMotivoNaoAgendado.Controls.Add(this.lblAba2MotivoNaoAgendamento);
            this.pMotivoNaoAgendado.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pMotivoNaoAgendado.Location = new System.Drawing.Point(0, 80);
            this.pMotivoNaoAgendado.Name = "pMotivoNaoAgendado";
            this.pMotivoNaoAgendado.Size = new System.Drawing.Size(472, 200);
            this.pMotivoNaoAgendado.Visible = false;
            // 
            // cmbAba2MotivoNaoAgendamentoMinuto
            // 
            this.cmbAba2MotivoNaoAgendamentoMinuto.Items.Add("F");
            this.cmbAba2MotivoNaoAgendamentoMinuto.Items.Add("M");
            this.cmbAba2MotivoNaoAgendamentoMinuto.Location = new System.Drawing.Point(140, 125);
            this.cmbAba2MotivoNaoAgendamentoMinuto.Name = "cmbAba2MotivoNaoAgendamentoMinuto";
            this.cmbAba2MotivoNaoAgendamentoMinuto.Size = new System.Drawing.Size(80, 41);
            this.cmbAba2MotivoNaoAgendamentoMinuto.TabIndex = 33;
            this.cmbAba2MotivoNaoAgendamentoMinuto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbAba2MotivoNaoAgendamentoMinuto_KeyPress);
            this.cmbAba2MotivoNaoAgendamentoMinuto.GotFocus += new System.EventHandler(this.Numero_GotFocus);
            // 
            // cmbAba2MotivoNaoAgendamentoHora
            // 
            this.cmbAba2MotivoNaoAgendamentoHora.Items.Add("F");
            this.cmbAba2MotivoNaoAgendamentoHora.Items.Add("M");
            this.cmbAba2MotivoNaoAgendamentoHora.Location = new System.Drawing.Point(25, 125);
            this.cmbAba2MotivoNaoAgendamentoHora.Name = "cmbAba2MotivoNaoAgendamentoHora";
            this.cmbAba2MotivoNaoAgendamentoHora.Size = new System.Drawing.Size(80, 41);
            this.cmbAba2MotivoNaoAgendamentoHora.TabIndex = 32;
            this.cmbAba2MotivoNaoAgendamentoHora.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbAba2MotivoNaoAgendamentoHora_KeyPress);
            this.cmbAba2MotivoNaoAgendamentoHora.GotFocus += new System.EventHandler(this.Numero_GotFocus);
            // 
            // lblAba2MotivoNaoAgendamentoSep3
            // 
            this.lblAba2MotivoNaoAgendamentoSep3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblAba2MotivoNaoAgendamentoSep3.Location = new System.Drawing.Point(110, 130);
            this.lblAba2MotivoNaoAgendamentoSep3.Name = "lblAba2MotivoNaoAgendamentoSep3";
            this.lblAba2MotivoNaoAgendamentoSep3.Size = new System.Drawing.Size(20, 38);
            this.lblAba2MotivoNaoAgendamentoSep3.Text = ":";
            // 
            // lblAba2MotivoNaoAgendamentoHora
            // 
            this.lblAba2MotivoNaoAgendamentoHora.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblAba2MotivoNaoAgendamentoHora.Location = new System.Drawing.Point(25, 90);
            this.lblAba2MotivoNaoAgendamentoHora.Name = "lblAba2MotivoNaoAgendamentoHora";
            this.lblAba2MotivoNaoAgendamentoHora.Size = new System.Drawing.Size(250, 38);
            this.lblAba2MotivoNaoAgendamentoHora.Text = "Hora Agendada :";
            // 
            // cmbAba2MotivoNaoAgendamentoAno
            // 
            this.cmbAba2MotivoNaoAgendamentoAno.Items.Add("F");
            this.cmbAba2MotivoNaoAgendamentoAno.Items.Add("M");
            this.cmbAba2MotivoNaoAgendamentoAno.Location = new System.Drawing.Point(260, 40);
            this.cmbAba2MotivoNaoAgendamentoAno.Name = "cmbAba2MotivoNaoAgendamentoAno";
            this.cmbAba2MotivoNaoAgendamentoAno.Size = new System.Drawing.Size(160, 41);
            this.cmbAba2MotivoNaoAgendamentoAno.TabIndex = 26;
            this.cmbAba2MotivoNaoAgendamentoAno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbAba2MotivoNaoAgendamentoAno_KeyPress);
            this.cmbAba2MotivoNaoAgendamentoAno.GotFocus += new System.EventHandler(this.Numero_GotFocus);
            // 
            // cmbAba2MotivoNaoAgendamentoMes
            // 
            this.cmbAba2MotivoNaoAgendamentoMes.Items.Add("F");
            this.cmbAba2MotivoNaoAgendamentoMes.Items.Add("M");
            this.cmbAba2MotivoNaoAgendamentoMes.Location = new System.Drawing.Point(140, 40);
            this.cmbAba2MotivoNaoAgendamentoMes.Name = "cmbAba2MotivoNaoAgendamentoMes";
            this.cmbAba2MotivoNaoAgendamentoMes.Size = new System.Drawing.Size(80, 41);
            this.cmbAba2MotivoNaoAgendamentoMes.TabIndex = 25;
            this.cmbAba2MotivoNaoAgendamentoMes.SelectedIndexChanged += new System.EventHandler(this.cmbAba2MotivoNaoAgendamentoMes_SelectedIndexChanged);
            this.cmbAba2MotivoNaoAgendamentoMes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbAba2MotivoNaoAgendamentoMes_KeyPress);
            this.cmbAba2MotivoNaoAgendamentoMes.GotFocus += new System.EventHandler(this.Numero_GotFocus);
            // 
            // cmbAba2MotivoNaoAgendamentoDia
            // 
            this.cmbAba2MotivoNaoAgendamentoDia.Items.Add("F");
            this.cmbAba2MotivoNaoAgendamentoDia.Items.Add("M");
            this.cmbAba2MotivoNaoAgendamentoDia.Location = new System.Drawing.Point(25, 40);
            this.cmbAba2MotivoNaoAgendamentoDia.Name = "cmbAba2MotivoNaoAgendamentoDia";
            this.cmbAba2MotivoNaoAgendamentoDia.Size = new System.Drawing.Size(80, 41);
            this.cmbAba2MotivoNaoAgendamentoDia.TabIndex = 24;
            this.cmbAba2MotivoNaoAgendamentoDia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbAba2MotivoNaoAgendamentoDia_KeyPress);
            this.cmbAba2MotivoNaoAgendamentoDia.GotFocus += new System.EventHandler(this.Numero_GotFocus);
            // 
            // lblAba2MotivoNaoAgendamentoSep2
            // 
            this.lblAba2MotivoNaoAgendamentoSep2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblAba2MotivoNaoAgendamentoSep2.Location = new System.Drawing.Point(230, 45);
            this.lblAba2MotivoNaoAgendamentoSep2.Name = "lblAba2MotivoNaoAgendamentoSep2";
            this.lblAba2MotivoNaoAgendamentoSep2.Size = new System.Drawing.Size(20, 38);
            this.lblAba2MotivoNaoAgendamentoSep2.Text = "/";
            // 
            // lblAba2MotivoNaoAgendamentoSep1
            // 
            this.lblAba2MotivoNaoAgendamentoSep1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblAba2MotivoNaoAgendamentoSep1.Location = new System.Drawing.Point(110, 45);
            this.lblAba2MotivoNaoAgendamentoSep1.Name = "lblAba2MotivoNaoAgendamentoSep1";
            this.lblAba2MotivoNaoAgendamentoSep1.Size = new System.Drawing.Size(20, 38);
            this.lblAba2MotivoNaoAgendamentoSep1.Text = "/";
            // 
            // lblAba2MotivoNaoAgendamento
            // 
            this.lblAba2MotivoNaoAgendamento.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblAba2MotivoNaoAgendamento.Location = new System.Drawing.Point(25, 5);
            this.lblAba2MotivoNaoAgendamento.Name = "lblAba2MotivoNaoAgendamento";
            this.lblAba2MotivoNaoAgendamento.Size = new System.Drawing.Size(250, 38);
            this.lblAba2MotivoNaoAgendamento.Text = "Data Agendada :";
            // 
            // cmbAba2MotivoNao
            // 
            this.cmbAba2MotivoNao.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.cmbAba2MotivoNao.Location = new System.Drawing.Point(25, 40);
            this.cmbAba2MotivoNao.Name = "cmbAba2MotivoNao";
            this.cmbAba2MotivoNao.Size = new System.Drawing.Size(395, 38);
            this.cmbAba2MotivoNao.TabIndex = 23;
            this.cmbAba2MotivoNao.SelectedIndexChanged += new System.EventHandler(this.cmbAba2MotivoNao_SelectedIndexChanged);
            this.cmbAba2MotivoNao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbAba2MotivoNao_KeyPress);
            this.cmbAba2MotivoNao.GotFocus += new System.EventHandler(this.Texto_GotFocus);
            // 
            // label23
            // 
            this.label23.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label23.Location = new System.Drawing.Point(25, 5);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(400, 32);
            this.label23.Text = "Assinale abaixo o motivo:";
            // 
            // pMotivoSim
            // 
            this.pMotivoSim.Controls.Add(this.lblAba2PerguntaSim);
            this.pMotivoSim.Controls.Add(this.txtAba2MotivoSimProposta);
            this.pMotivoSim.Dock = System.Windows.Forms.DockStyle.Top;
            this.pMotivoSim.Location = new System.Drawing.Point(0, 0);
            this.pMotivoSim.Name = "pMotivoSim";
            this.pMotivoSim.Size = new System.Drawing.Size(472, 100);
            this.pMotivoSim.Visible = false;
            // 
            // lblAba2PerguntaSim
            // 
            this.lblAba2PerguntaSim.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblAba2PerguntaSim.Location = new System.Drawing.Point(25, 5);
            this.lblAba2PerguntaSim.Name = "lblAba2PerguntaSim";
            this.lblAba2PerguntaSim.Size = new System.Drawing.Size(180, 32);
            this.lblAba2PerguntaSim.Text = "Proposta nº :";
            // 
            // txtAba2MotivoSimProposta
            // 
            this.txtAba2MotivoSimProposta.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtAba2MotivoSimProposta.Location = new System.Drawing.Point(25, 40);
            this.txtAba2MotivoSimProposta.MaxLength = 100;
            this.txtAba2MotivoSimProposta.Name = "txtAba2MotivoSimProposta";
            this.txtAba2MotivoSimProposta.Size = new System.Drawing.Size(400, 38);
            this.txtAba2MotivoSimProposta.TabIndex = 22;
            this.txtAba2MotivoSimProposta.GotFocus += new System.EventHandler(this.Numero_GotFocus);
            // 
            // pPergunta2Title
            // 
            this.pPergunta2Title.Controls.Add(this.chkAba2Nao);
            this.pPergunta2Title.Controls.Add(this.chkAba2Sim);
            this.pPergunta2Title.Controls.Add(this.lblAba2Title);
            this.pPergunta2Title.Controls.Add(this.lblAba2Pergunta);
            this.pPergunta2Title.Controls.Add(this.lblAba2PerguntaDescricao);
            this.pPergunta2Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.pPergunta2Title.Location = new System.Drawing.Point(0, 0);
            this.pPergunta2Title.Name = "pPergunta2Title";
            this.pPergunta2Title.Size = new System.Drawing.Size(472, 180);
            // 
            // chkAba2Nao
            // 
            this.chkAba2Nao.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.chkAba2Nao.Location = new System.Drawing.Point(210, 120);
            this.chkAba2Nao.Name = "chkAba2Nao";
            this.chkAba2Nao.Size = new System.Drawing.Size(100, 40);
            this.chkAba2Nao.TabIndex = 68;
            this.chkAba2Nao.Text = "Não";
            this.chkAba2Nao.Click += new System.EventHandler(this.chkAba2chk1_Click);
            // 
            // chkAba2Sim
            // 
            this.chkAba2Sim.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.chkAba2Sim.Location = new System.Drawing.Point(25, 120);
            this.chkAba2Sim.Name = "chkAba2Sim";
            this.chkAba2Sim.Size = new System.Drawing.Size(100, 40);
            this.chkAba2Sim.TabIndex = 67;
            this.chkAba2Sim.Text = "Sim";
            this.chkAba2Sim.Click += new System.EventHandler(this.chkAba2chk1_Click);
            // 
            // lblAba2Title
            // 
            this.lblAba2Title.BackColor = System.Drawing.Color.Gainsboro;
            this.lblAba2Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAba2Title.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblAba2Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(61)))), ((int)(((byte)(118)))));
            this.lblAba2Title.Location = new System.Drawing.Point(0, 0);
            this.lblAba2Title.Name = "lblAba2Title";
            this.lblAba2Title.Size = new System.Drawing.Size(472, 38);
            this.lblAba2Title.Text = "FeedBack Consultor";
            this.lblAba2Title.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblAba2Pergunta
            // 
            this.lblAba2Pergunta.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblAba2Pergunta.Location = new System.Drawing.Point(25, 45);
            this.lblAba2Pergunta.Name = "lblAba2Pergunta";
            this.lblAba2Pergunta.Size = new System.Drawing.Size(200, 38);
            this.lblAba2Pergunta.Text = "Pergunta 2 :";
            // 
            // lblAba2PerguntaDescricao
            // 
            this.lblAba2PerguntaDescricao.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblAba2PerguntaDescricao.Location = new System.Drawing.Point(25, 85);
            this.lblAba2PerguntaDescricao.Name = "lblAba2PerguntaDescricao";
            this.lblAba2PerguntaDescricao.Size = new System.Drawing.Size(400, 32);
            this.lblAba2PerguntaDescricao.Text = "Realizou esta venda?";
            // 
            // barraInferior1
            // 
            this.barraInferior1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barraInferior1.Location = new System.Drawing.Point(0, 602);
            this.barraInferior1.Name = "barraInferior1";
            this.barraInferior1.Size = new System.Drawing.Size(480, 38);
            this.barraInferior1.TabIndex = 31;
            // 
            // barraSuperior1
            // 
            this.barraSuperior1.Dock = System.Windows.Forms.DockStyle.Top;
            this.barraSuperior1.Location = new System.Drawing.Point(0, 0);
            this.barraSuperior1.Name = "barraSuperior1";
            this.barraSuperior1.Size = new System.Drawing.Size(480, 70);
            this.barraSuperior1.TabIndex = 30;
            // 
            // frmFeedBackAlterado
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(480, 640);
            this.ControlBox = false;
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.bntSair);
            this.Controls.Add(this.tabFeedBack);
            this.Controls.Add(this.barraInferior1);
            this.Controls.Add(this.barraSuperior1);
            this.Location = new System.Drawing.Point(0, 0);
            this.MinimizeBox = false;
            this.Name = "frmFeedBackAlterado";
            this.Text = "frmFeedBackAlterado";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmFeedBackAlterado_Load);
            this.tabFeedBack.ResumeLayout(false);
            this.tabConsultorQuestao1.ResumeLayout(false);
            this.pAba1Panel.ResumeLayout(false);
            this.tabConsultorQuestao2.ResumeLayout(false);
            this.pAba2Panel.ResumeLayout(false);
            this.pMotivo.ResumeLayout(false);
            this.pMotivoNao.ResumeLayout(false);
            this.pMotivoNaoAgendado.ResumeLayout(false);
            this.pMotivoSim.ResumeLayout(false);
            this.pPergunta2Title.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button bntSair;
        private System.Windows.Forms.TabControl tabFeedBack;
        private System.Windows.Forms.TabPage tabConsultorQuestao1;
        private System.Windows.Forms.Label lblAba1Title;
        private System.Windows.Forms.Panel pAba1Panel;
        private System.Windows.Forms.Label lblAba1PerguntaDescricao;
        private System.Windows.Forms.Label lblAba1Pergunta;
        private System.Windows.Forms.TabPage tabConsultorQuestao2;
        private System.Windows.Forms.Label lblAba2Title;
        private System.Windows.Forms.Panel pAba2Panel;
        private ProjetoMobile.Controles.BarraInferior barraInferior1;
        private ProjetoMobile.Controles.BarraSuperior barraSuperior1;
        private System.Windows.Forms.Panel pPergunta2Title;
        private System.Windows.Forms.Label lblAba2Pergunta;
        private System.Windows.Forms.Label lblAba2PerguntaDescricao;
        private System.Windows.Forms.Panel pMotivo;
        private System.Windows.Forms.Panel pMotivoNao;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Panel pMotivoSim;
        private System.Windows.Forms.Label lblAba2PerguntaSim;
        private System.Windows.Forms.TextBox txtAba2MotivoSimProposta;
        private System.Windows.Forms.ComboBox cmbAba2MotivoNao;
        private System.Windows.Forms.Panel pMotivoNaoAgendado;
        private System.Windows.Forms.ComboBox cmbAba2MotivoNaoAgendamentoAno;
        private System.Windows.Forms.ComboBox cmbAba2MotivoNaoAgendamentoMes;
        private System.Windows.Forms.ComboBox cmbAba2MotivoNaoAgendamentoDia;
        private System.Windows.Forms.Label lblAba2MotivoNaoAgendamentoSep2;
        private System.Windows.Forms.Label lblAba2MotivoNaoAgendamentoSep1;
        private System.Windows.Forms.Label lblAba2MotivoNaoAgendamento;
        private System.Windows.Forms.CheckBox chkAba1PR;
        private System.Windows.Forms.CheckBox chkAba1I;
        private System.Windows.Forms.CheckBox chkAba1R;
        private System.Windows.Forms.CheckBox chkAba1MR;
        private System.Windows.Forms.CheckBox chkAba2Nao;
        private System.Windows.Forms.CheckBox chkAba2Sim;
        private System.Windows.Forms.ComboBox cmbAba2MotivoNaoAgendamentoMinuto;
        private System.Windows.Forms.ComboBox cmbAba2MotivoNaoAgendamentoHora;
        private System.Windows.Forms.Label lblAba2MotivoNaoAgendamentoSep3;
        private System.Windows.Forms.Label lblAba2MotivoNaoAgendamentoHora;
    }
}
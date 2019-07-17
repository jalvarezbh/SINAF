namespace ProjetoMobile
{
    partial class frmSelAgendamento
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
            this.pSelAgendamento = new System.Windows.Forms.Panel();
            this.lblSelTitle = new System.Windows.Forms.Label();
            this.dtgSelAgendamento = new System.Windows.Forms.DataGrid();
            this.barraSuperior1 = new ProjetoMobile.Controles.BarraSuperior();
            this.bntSair = new System.Windows.Forms.Button();
            this.barraInferior1 = new ProjetoMobile.Controles.BarraInferior();
            this.pSelAgendamento.SuspendLayout();
            this.SuspendLayout();
            // 
            // pSelAgendamento
            // 
            this.pSelAgendamento.BackColor = System.Drawing.Color.Transparent;
            this.pSelAgendamento.Controls.Add(this.lblSelTitle);
            this.pSelAgendamento.Controls.Add(this.dtgSelAgendamento);
            this.pSelAgendamento.Location = new System.Drawing.Point(0, 70);
            this.pSelAgendamento.Name = "pSelAgendamento";
            this.pSelAgendamento.Size = new System.Drawing.Size(480, 486);
            // 
            // lblSelTitle
            // 
            this.lblSelTitle.BackColor = System.Drawing.Color.Gainsboro;
            this.lblSelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSelTitle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblSelTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(61)))), ((int)(((byte)(118)))));
            this.lblSelTitle.Location = new System.Drawing.Point(0, 0);
            this.lblSelTitle.Name = "lblSelTitle";
            this.lblSelTitle.Size = new System.Drawing.Size(480, 38);
            this.lblSelTitle.Text = "Agendamentos";
            this.lblSelTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dtgSelAgendamento
            // 
            this.dtgSelAgendamento.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dtgSelAgendamento.Location = new System.Drawing.Point(10, 45);
            this.dtgSelAgendamento.Name = "dtgSelAgendamento";
            this.dtgSelAgendamento.Size = new System.Drawing.Size(460, 438);
            this.dtgSelAgendamento.TabIndex = 1;
            this.dtgSelAgendamento.Click += new System.EventHandler(this.dtgSelAgendamento_Click);
            // 
            // barraSuperior1
            // 
            this.barraSuperior1.Dock = System.Windows.Forms.DockStyle.Top;
            this.barraSuperior1.Location = new System.Drawing.Point(0, 0);
            this.barraSuperior1.Name = "barraSuperior1";
            this.barraSuperior1.Size = new System.Drawing.Size(480, 70);
            this.barraSuperior1.TabIndex = 1;
            // 
            // bntSair
            // 
            this.bntSair.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(61)))), ((int)(((byte)(118)))));
            this.bntSair.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.bntSair.ForeColor = System.Drawing.Color.White;
            this.bntSair.Location = new System.Drawing.Point(10, 560);
            this.bntSair.Name = "bntSair";
            this.bntSair.Size = new System.Drawing.Size(124, 36);
            this.bntSair.TabIndex = 4;
            this.bntSair.Text = "Voltar";
            this.bntSair.Click += new System.EventHandler(this.bntSair_Click);
            // 
            // barraInferior1
            // 
            this.barraInferior1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barraInferior1.Location = new System.Drawing.Point(0, 602);
            this.barraInferior1.Name = "barraInferior1";
            this.barraInferior1.Size = new System.Drawing.Size(480, 38);
            this.barraInferior1.TabIndex = 3;
            // 
            // frmSelAgendamento
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(480, 640);
            this.Controls.Add(this.bntSair);
            this.Controls.Add(this.barraInferior1);
            this.Controls.Add(this.pSelAgendamento);
            this.Controls.Add(this.barraSuperior1);
            this.Location = new System.Drawing.Point(0, 0);
            this.MinimizeBox = false;
            this.Name = "frmSelAgendamento";
            this.Text = "frmSelAgendamento";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pSelAgendamento.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pSelAgendamento;
        private System.Windows.Forms.DataGrid dtgSelAgendamento;
        private ProjetoMobile.Controles.BarraSuperior barraSuperior1;
        private System.Windows.Forms.Button bntSair;
        private ProjetoMobile.Controles.BarraInferior barraInferior1;
        private System.Windows.Forms.Label lblSelTitle;


    }
}
namespace ProjetoMobile
{
    partial class frmMenuAcesso
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
            this.txtTitChecklistVistoria = new System.Windows.Forms.Label();
            this.btnSair = new System.Windows.Forms.Button();
            this.lvMenu = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.imageList1 = new System.Windows.Forms.ImageList();
            this.barraInferior1 = new ProjetoMobile.Controles.BarraInferior();
            this.barraSuperior1 = new ProjetoMobile.Controles.BarraSuperior();
            this.SuspendLayout();
            // 
            // txtTitChecklistVistoria
            // 
            this.txtTitChecklistVistoria.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtTitChecklistVistoria.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(61)))), ((int)(((byte)(118)))));
            this.txtTitChecklistVistoria.Location = new System.Drawing.Point(10, 82);
            this.txtTitChecklistVistoria.Name = "txtTitChecklistVistoria";
            this.txtTitChecklistVistoria.Size = new System.Drawing.Size(210, 30);
            this.txtTitChecklistVistoria.Text = "Menu de Acesso";
            // 
            // btnSair
            // 
            this.btnSair.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(61)))), ((int)(((byte)(118)))));
            this.btnSair.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnSair.ForeColor = System.Drawing.Color.White;
            this.btnSair.Location = new System.Drawing.Point(10, 560);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(124, 36);
            this.btnSair.TabIndex = 3;
            this.btnSair.Text = "Voltar";
            this.btnSair.Click += new System.EventHandler(this.butSair_Click);
            // 
            // lvMenu
            // 
            this.lvMenu.Columns.Add(this.columnHeader1);
            this.lvMenu.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lvMenu.FullRowSelect = true;
            this.lvMenu.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvMenu.LargeImageList = this.imageList1;
            this.lvMenu.Location = new System.Drawing.Point(10, 115);
            this.lvMenu.Name = "lvMenu";
            this.lvMenu.Size = new System.Drawing.Size(460, 437);
            this.lvMenu.SmallImageList = this.imageList1;
            this.lvMenu.TabIndex = 12;
            this.lvMenu.SelectedIndexChanged += new System.EventHandler(this.lvMenu_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ColumnHeader";
            this.columnHeader1.Width = 250;
            // 
            // imageList1
            // 
            this.imageList1.ImageSize = new System.Drawing.Size(100, 100);
            // 
            // barraInferior1
            // 
            this.barraInferior1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barraInferior1.Location = new System.Drawing.Point(0, 602);
            this.barraInferior1.Name = "barraInferior1";
            this.barraInferior1.Size = new System.Drawing.Size(480, 38);
            this.barraInferior1.TabIndex = 5;
            // 
            // barraSuperior1
            // 
            this.barraSuperior1.Dock = System.Windows.Forms.DockStyle.Top;
            this.barraSuperior1.Location = new System.Drawing.Point(0, 0);
            this.barraSuperior1.Name = "barraSuperior1";
            this.barraSuperior1.Size = new System.Drawing.Size(480, 70);
            this.barraSuperior1.TabIndex = 4;
            // 
            // frmMenuAcesso
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(480, 640);
            this.ControlBox = false;
            this.Controls.Add(this.lvMenu);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.txtTitChecklistVistoria);
            this.Controls.Add(this.barraInferior1);
            this.Controls.Add(this.barraSuperior1);
            this.Location = new System.Drawing.Point(0, 0);
            this.MinimizeBox = false;
            this.Name = "frmMenuAcesso";
            this.Text = "PEP - Menu de Acesso";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMenuAcesso_Load);
            this.Closed += new System.EventHandler(this.frmMenuAcesso_Closed);
            this.Activated += new System.EventHandler(this.frmMenuAcesso_Activated);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmMenuAcesso_KeyPress);
            this.ResumeLayout(false);

        }

        #endregion

        private ProjetoMobile.Controles.BarraInferior barraInferior1;
        private ProjetoMobile.Controles.BarraSuperior barraSuperior1;
        private System.Windows.Forms.Label txtTitChecklistVistoria;
        private System.Windows.Forms.ListView lvMenu;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button btnSair;
    }
}
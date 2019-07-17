namespace ProjetoMobile.Controles
{
    partial class BarraInferior
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BarraInferior));
            this.timStatusConexao = new System.Windows.Forms.Timer();
            this.lblFaixa = new System.Windows.Forms.Label();
            this.lblBateria = new System.Windows.Forms.Label();
            this.picFaixa = new System.Windows.Forms.PictureBox();
            this.picBateria = new System.Windows.Forms.PictureBox();
            this.SuspendLayout();
            // 
            // timStatusConexao
            // 
            this.timStatusConexao.Enabled = true;
            this.timStatusConexao.Interval = 500;
            this.timStatusConexao.Tick += new System.EventHandler(this.timStatusConexao_Tick);
            // 
            // lblFaixa
            // 
            this.lblFaixa.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblFaixa.ForeColor = System.Drawing.Color.White;
            this.lblFaixa.Location = new System.Drawing.Point(41, 7);
            this.lblFaixa.Name = "lblFaixa";
            this.lblFaixa.Size = new System.Drawing.Size(158, 28);
            this.lblFaixa.Text = "ENTREVISTAS";
            // 
            // lblBateria
            // 
            this.lblBateria.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblBateria.ForeColor = System.Drawing.Color.White;
            this.lblBateria.Location = new System.Drawing.Point(347, 7);
            this.lblBateria.Name = "lblBateria";
            this.lblBateria.Size = new System.Drawing.Size(82, 28);
            this.lblBateria.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // picFaixa
            // 
            this.picFaixa.Image = ((System.Drawing.Image)(resources.GetObject("picFaixa.Image")));
            this.picFaixa.Location = new System.Drawing.Point(3, 3);
            this.picFaixa.Name = "picFaixa";
            this.picFaixa.Size = new System.Drawing.Size(32, 32);
            this.picFaixa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // picBateria
            // 
            this.picBateria.Location = new System.Drawing.Point(435, 3);
            this.picBateria.Name = "picBateria";
            this.picBateria.Size = new System.Drawing.Size(38, 32);
            this.picBateria.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // BarraInferior
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(61)))), ((int)(((byte)(118)))));
            this.Controls.Add(this.picBateria);
            this.Controls.Add(this.lblBateria);
            this.Controls.Add(this.lblFaixa);
            this.Controls.Add(this.picFaixa);
            this.Name = "BarraInferior";
            this.Size = new System.Drawing.Size(480, 38);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timStatusConexao;
        public System.Windows.Forms.PictureBox picFaixa;
        private System.Windows.Forms.Label lblFaixa;
        private System.Windows.Forms.Label lblBateria;
        public System.Windows.Forms.PictureBox picBateria;
    }
}

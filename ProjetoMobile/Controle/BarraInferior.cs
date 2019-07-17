using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ProjetoMobile.Persistencia;
using ProjetoMobile.Util;

namespace ProjetoMobile.Controles
{
    public partial class BarraInferior : UserControl, IDisposable
    {
        public BarraInferior()
        {
            InitializeComponent();

            new TFaixaPERSISTENCIA().VerificarFaixa();
            this.Refresh();
            TrocaCor();

            timStatusConexao.Enabled = true;
        }

        private void TrocaCor()
        {
            if (Program.CountFaixa > 0)
            {
                picFaixa.Image = ProjetoMobile.Properties.Resources.accept32;
                if (Program.CountFaixa > 1)
                    lblFaixa.Text = Program.CountFaixa + " - Entrevistas ";
                else
                    lblFaixa.Text = Program.CountFaixa + " - Entrevista ";
            }
            else
            {
                picFaixa.Image = ProjetoMobile.Properties.Resources.remove32;
                lblFaixa.Text = Program.CountFaixa + " - Entrevista ";
            }
            lblFaixa.Refresh();
        }

        private void VerificaBateria()
        {
            Bateria bateria = new Bateria();
            picBateria.Image = bateria.BatteryImage();
            lblBateria.Text = bateria.BatteryLifePercent.ToString() + "%";
            lblBateria.Refresh();
        }

        private void timStatusConexao_Tick(object sender, EventArgs e)
        {
            try
            {
                timStatusConexao.Enabled = false;
                TrocaCor();
                VerificaBateria();
                timStatusConexao.Enabled = true;
            }
            catch
            {
                this.timStatusConexao.Enabled = false;
                this.Dispose();
            }
        }

        #region IDisposable Members

        void IDisposable.Dispose()
        {
            if (!this.IsDisposed)
                this.timStatusConexao.Dispose();
        }

        #endregion
    }
}

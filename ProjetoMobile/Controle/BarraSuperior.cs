using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace ProjetoMobile.Controles
{
    public partial class BarraSuperior : UserControl, IDisposable
    {
        public BarraSuperior()
        {
            InitializeComponent();
            //pictureBox1.Image = SGF_Mobile.Properties.Resources.ColetorTopo;
            lblDataHora.Text = System.DateTime.Now.ToString("dd/MM/yyyy HH:mm");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                timer1.Enabled = false;
                lblDataHora.Text = System.DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                timer1.Enabled = true;
            }
            catch (Exception)
            {
                timer1.Enabled = false;
                this.Dispose();
            }
        }

        #region IDisposable Members

        void IDisposable.Dispose()
        {
            if (!this.IsDisposed)
                this.timer1.Dispose();
        }

        #endregion
    }
}

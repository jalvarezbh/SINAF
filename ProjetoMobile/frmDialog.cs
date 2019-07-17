using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ProjetoMobile
{
    public partial class frmDialog : Form
    {
        #region [ PROPERTIES ]

        public Dominio.Enumeradores.RespostaCaixaMensagem retorno;

        #endregion

        #region [ LOAD ]

        public frmDialog()
        {
            InitializeComponent();
            FocusOn();
            FocusOff();
            KeyDownTecla();
            KeyUpTecla();
        }

        private void frmDialog_Load(object sender, EventArgs e)
        {
            butCancelar.Visible = butCancelar.Enabled;
            butNao.Visible = butNao.Enabled;

            //Posiciona os botões
            if (!butCancelar.Enabled && !butNao.Enabled)
                butSim.Top = butCancelar.Top;
            if (!butCancelar.Enabled && butNao.Enabled)
            {
                butSim.Top = butNao.Top;
                butNao.Top = butCancelar.Top;
            }

            //Focaliza o botão padrão
            if (this.butCancelar.Enabled)
                this.butCancelar.Focus();
            else if (this.butNao.Enabled)
                this.butNao.Focus();
            else
                this.butSim.Focus();
        }             

        #endregion

        #region [ CONTROLS ]

        private void FocusOn()
        {
            butNao.GotFocus += new EventHandler(Program.btn_focusOn);
            butCancelar.GotFocus += new EventHandler(Program.btn_focusOn);
            butSim.GotFocus += new EventHandler(Program.btn_focusOn);
        }

        private void FocusOff()
        {
            butNao.LostFocus += new EventHandler(Program.btn_focusOffAzul);
            butCancelar.LostFocus += new EventHandler(Program.btn_focusOffAzul);
            butSim.LostFocus += new EventHandler(Program.btn_focusOffAzul);
        }

        private void KeyDownTecla()
        {
            //Only button and check

            butNao.KeyDown += new KeyEventHandler(Program.btn_enter);
            butCancelar.KeyDown += new KeyEventHandler(Program.btn_enter);
            butSim.KeyDown += new KeyEventHandler(Program.btn_enter);
        }

        private void KeyUpTecla()
        {
            butNao.KeyUp += new KeyEventHandler(Program.txtBox_next);
            butCancelar.KeyUp += new KeyEventHandler(Program.btn_next);
            butSim.KeyUp += new KeyEventHandler(Program.btn_next);
        }

        #endregion

        #region [ BUTTONS ]

        private void butSim_Click(object sender, EventArgs e)
        {
            retorno = Dominio.Enumeradores.RespostaCaixaMensagem.Sim;
            this.Close();
        }

        private void butNao_Click(object sender, EventArgs e)
        {
            retorno = Dominio.Enumeradores.RespostaCaixaMensagem.Nao;
            this.Close();
        }

        private void butCancelar_Click(object sender, EventArgs e)
        {
            retorno = Dominio.Enumeradores.RespostaCaixaMensagem.Cancelar;
            this.Close();
        }

        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace ProjetoMobile.Util
{
    public static class CaixaMensagem
    {
        #region [ DIALOG ]

        /// <summary>
        /// Mensagem com 1 opção de retorno
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static Dominio.Enumeradores.RespostaCaixaMensagem ExibirOk(string msg)
        {
            frmDialog dialogo = Program.DialogForm<frmDialog>();
            Dominio.Enumeradores.RespostaCaixaMensagem retorno;
            dialogo.butCancelar.Enabled = false;
            dialogo.butNao.Enabled = false;
            dialogo.butSim.Text = "Ok";
            dialogo.lblMensagem.Text = msg;
            dialogo.TopMost = true;
            MostraCursor.CursorAguarde(false);
            dialogo.ShowDialog();
            retorno = dialogo.retorno;
            dialogo.Dispose();
            //Program.DialogFormClose();
            return retorno;
        }

        /// <summary>
        /// Mensagem com 2 opções de retorno
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static Dominio.Enumeradores.RespostaCaixaMensagem ExibirSimNao(string msg)
        {
            frmDialog dialogo = Program.DialogForm<frmDialog>();
            Dominio.Enumeradores.RespostaCaixaMensagem retorno;
            dialogo.butCancelar.Enabled = false;
            dialogo.lblMensagem.Text = msg;
            dialogo.TopMost = true;
            MostraCursor.CursorAguarde(false);
            dialogo.ShowDialog();
            retorno = dialogo.retorno;
            dialogo.Dispose();
            //Program.DialogFormClose();
            return retorno;
        }

        /// <summary>
        /// Mensagem com 3 opções de retorno
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static Dominio.Enumeradores.RespostaCaixaMensagem ExibirSimNaoCancelar(string msg)
        {
            frmDialog dialogo = Program.DialogForm<frmDialog>();
            Dominio.Enumeradores.RespostaCaixaMensagem retorno;
            dialogo.lblMensagem.Text = msg;
            dialogo.TopMost = true;
            MostraCursor.CursorAguarde(false);
            dialogo.ShowDialog();
            retorno = dialogo.retorno;
            dialogo.Dispose();
            //Program.DialogFormClose();
            return retorno;
        }

        /// <summary>
        /// Mensagem com 1 opção de retorno e grava log de erro
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="erro"></param>
        /// <returns></returns>
        public static Dominio.Enumeradores.RespostaCaixaMensagem ExibirErro(string msg, string erro)
        {
            frmDialog dialogo = Program.DialogForm<frmDialog>();
            Dominio.Enumeradores.RespostaCaixaMensagem retorno;
            dialogo.butCancelar.Enabled = false;
            dialogo.butNao.Enabled = false;
            dialogo.butSim.Text = "Ok";
            dialogo.lblMensagem.Text = msg;
            dialogo.TopMost = true;
            MostraCursor.CursorAguarde(false);
            dialogo.ShowDialog();
            retorno = dialogo.retorno;
            dialogo.Dispose();
            //Program.DialogFormClose();
            LogErro.GravaLog(msg, erro);

            return retorno;
        }

        #endregion

        #region [ CONFIRM PASSWORD ]

        public static Dominio.Enumeradores.RespostaCaixaMensagem ConfirmarSenha(string msg, bool wifi)
        {
            frmConfirmar dialogo = Program.AbreForm<frmConfirmar>();
            Dominio.Enumeradores.RespostaCaixaMensagem retorno;
            dialogo.lblMensagem.Text = msg;
            dialogo.wifi = wifi;
            dialogo.TopMost = true;
            MostraCursor.CursorAguarde(false);
            dialogo.ShowDialog();
            retorno = dialogo.retorno;
            dialogo.Dispose();
            return retorno;
        }

        #endregion
    }
}

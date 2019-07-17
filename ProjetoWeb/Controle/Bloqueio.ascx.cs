using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjetoVO;
using ProjetoController;
using WebControls;

namespace ProjetoWeb.Controle
{
    public partial class Bloqueio : System.Web.UI.UserControl
    {
        #region [ PROPERTIES ]

        private TColetorCONTROLLER controller;

        public TColetorCONTROLLER Controller
        {
            get
            {
                if (controller == null)
                    controller = new TColetorCONTROLLER();

                return controller;

            }
        }

      
        private int _idColetor;
        public int IDColetor
        {
            get { return _idColetor; }
            set { _idColetor = value; }
        }

        #endregion

        #region [ PAGE LOAD ]

        protected void Page_Load(object sender, EventArgs e)
        {
           
                
        }

        #endregion

        #region [ METHODS ]

        private void Popular()
        {
            TColetorVO dadosColetor = new TColetorVO();
            dadosColetor.IDColetor = IDColetor;
            List<TColetorVO> listColetor = Controller.Listar(dadosColetor);

            if (listColetor.Count == 1)
                PreencheTela(listColetor[0]);

        }

        private void PreencheTela(TColetorVO coletorVO)
        {
            hiddenIDColetor.Value = coletorVO.IDColetor.ToString();
            txtNumeroSerie.Text = coletorVO.NumeroSerie;
            txtIMEI.Text = coletorVO.IMEI;
            
            txtDataUltimaAlteracao.Text = coletorVO.DataUltimaSincronizacao.HasValue ? coletorVO.DataUltimaSincronizacao.Value.ToShortDateString() : string.Empty;
            txtDiasSemSincronizar.Text = coletorVO.DataUltimaSincronizacao.HasValue ? ((TimeSpan)(DateTime.Now - coletorVO.DataUltimaSincronizacao.Value)).Days.ToString() : string.Empty;
            txtDataInativacao.Text = coletorVO.DataInativacao.HasValue ? coletorVO.DataInativacao.Value.ToShortDateString() : string.Empty;
        }

        public void ExibirModal(bool exibir)
        {
            if (exibir)
            {               
                ModalPopupExtender1.Show();
                panelModal.Visible = true;

                Popular();
            }
            else
            {
                ModalPopupExtender1.Hide();
            }
        }

        #endregion

        #region [ BUTTONS ]

        protected void btnSalvar_Click(object sender, EventArgs e)
        {            
            ModalPopupExtender1.Hide();
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            ExibirModal(false);
        }
        
        #endregion
    }
}
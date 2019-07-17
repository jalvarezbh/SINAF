using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjetoVO;
using ProjetoDAL;
using WebControls;
using System.Web;
using System.IO;
using System.Data.OleDb;
using System.Data;
using System.Web.Configuration;

namespace ProjetoController
{
    public class TAtendimentoCONTROLLER
    {
        #region [ BLL ]

        private TAtendimentoBLL _TAtendimentoBLL;

        public TAtendimentoBLL TAtendimentoBLL
        {
            get
            {
                if (_TAtendimentoBLL == null)
                    _TAtendimentoBLL = new TAtendimentoBLL();

                return _TAtendimentoBLL;

            }
        }

        private TFilialBLL _TFilialBLL;

        public TFilialBLL TFilialBLL
        {
            get
            {
                if (_TFilialBLL == null)
                    _TFilialBLL = new TFilialBLL();

                return _TFilialBLL;

            }
        }

        private TCidadeBLL _TCidadeBLL;

        public TCidadeBLL TCidadeBLL
        {
            get
            {
                if (_TCidadeBLL == null)
                    _TCidadeBLL = new TCidadeBLL();

                return _TCidadeBLL;

            }
        }

        private TBairroBLL _TBairroBLL;

        public TBairroBLL TBairroBLL
        {
            get
            {
                if (_TBairroBLL == null)
                    _TBairroBLL = new TBairroBLL();

                return _TBairroBLL;

            }
        }

        #endregion

        #region [ Métodos ]

        #region [ ImportarArquivo ]

        public void ImportarArquivo(string keyNomeDiretorio, string nomeArquivo, ref int numeroIncluido, ref int numeroNaoIncluido)
        {
            try
            {
                string urlRepositorioArquivos = WebConfigurationManager.AppSettings[keyNomeDiretorio];

                string path = HttpContext.Current.Server.MapPath(urlRepositorioArquivos + "\\" + nomeArquivo);
                DataSet dadosExcel = new DataSet();

                OleDbConnection connection = new OleDbConnection(WebConfigurationManager.AppSettings["ExcelCONNECT"].Replace("[path]", path).ToString());
                
                //OleDbConnection connection = new OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0;Data Source='"+path+"';Extended Properties=Excel 8.0;");
                //OleDbConnection connection = new OleDbConnection("provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + path + "';Extended Properties=Excel 12.0;");

                using (OleDbDataAdapter command = new OleDbDataAdapter("select * from [Plan1$]", connection))
                {
                    command.Fill(dadosExcel);
                }

                numeroIncluido = 0;
                numeroNaoIncluido = 0;

                if (dadosExcel != null)
                {
                    if (dadosExcel.Tables.Count > 0)
                    {
                        if (dadosExcel.Tables[0].Rows.Count > 0)
                        {

                            foreach (DataRow item in dadosExcel.Tables[0].Rows)
                            {
                                TAtendimentoVO dadosVO = new TAtendimentoVO();

                                dadosVO.IDFilial = TFilialBLL.ObterIDFilial(item["Filial"].ToString());
                                if (dadosVO.IDFilial == 0)
                                {
                                    if (!string.IsNullOrEmpty(item["Filial"].ToString()))
                                    {
                                        TFilialVO filialVO = new TFilialVO();
                                        filialVO.NomeFilial = item["Filial"].ToString();
                                        dadosVO.IDFilial = TFilialBLL.Inserir(filialVO);
                                    }
                                    else
                                        dadosVO.IDFilial = 0;
                                }

                                dadosVO.IDCidade = TCidadeBLL.ObterIDCidade(item["Cidade"].ToString());
                                dadosVO.IDBairro = TBairroBLL.ObterIDBairro(item["Bairro"].ToString());

                                if (dadosVO.IDFilial != 0 && dadosVO.IDCidade != 0 && dadosVO.IDBairro != 0)
                                {
                                    numeroIncluido += 1;
                                    if (TAtendimentoBLL.ObterAtendimento(dadosVO.IDFilial, dadosVO.IDCidade, dadosVO.IDBairro) == 0)
                                        TAtendimentoBLL.Inserir(dadosVO);
                                }
                                else
                                    numeroNaoIncluido += 1;

                            }
                        }
                    }
                }

            }
            catch (CABTECException)
            {
                 //throw new CABTECException(ex.Message);
                 throw new CABTECException("Erro ao Importar Arquivo Filial/Atendimento.");
            }
            catch (Exception)
            {
                throw new CABTECException("Erro ao Importar Arquivo Filial/Atendimento.");
            }
        }

        #endregion

        #endregion
    }
}

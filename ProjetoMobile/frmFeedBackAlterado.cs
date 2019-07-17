using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ProjetoMobile.Dominio;
using ProjetoMobile.Persistencia;
using ProjetoMobile.Dominio.Enumeradores;
using ProjetoMobile.Util;

namespace ProjetoMobile
{
    public partial class frmFeedBackAlterado : Form
    {
        #region [ PROPERTIES ]

        private TCombosEnumPERSISTENCIA controllerEnum;

        public TCombosEnumPERSISTENCIA ControllerEnum
        {
            get
            {
                if (controllerEnum == null)
                    controllerEnum = new TCombosEnumPERSISTENCIA();

                return controllerEnum;

            }
        }

        private TRespostaPERSISTENCIA controllerResposta;

        public TRespostaPERSISTENCIA ControllerResposta
        {
            get
            {
                if (controllerResposta == null)
                    controllerResposta = new TRespostaPERSISTENCIA();

                return controllerResposta;

            }
        }

        private TEntrevistaPERSISTENCIA controllerEntrevista;

        public TEntrevistaPERSISTENCIA ControllerEntrevista
        {
            get
            {
                if (controllerEntrevista == null)
                    controllerEntrevista = new TEntrevistaPERSISTENCIA();

                return controllerEntrevista;

            }
        }

        private TEntrevistadoPERSISTENCIA controllerEntrevistado;

        public TEntrevistadoPERSISTENCIA ControllerEntrevistado
        {
            get
            {
                if (controllerEntrevistado == null)
                    controllerEntrevistado = new TEntrevistadoPERSISTENCIA();

                return controllerEntrevistado;

            }
        }

        private TEntrevistadoEnderecoPERSISTENCIA controllerEntrevistadoEndereco;

        public TEntrevistadoEnderecoPERSISTENCIA ControllerEntrevistadoEndereco
        {
            get
            {
                if (controllerEntrevistadoEndereco == null)
                    controllerEntrevistadoEndereco = new TEntrevistadoEnderecoPERSISTENCIA();

                return controllerEntrevistadoEndereco;

            }
        }

        private TAgendamentoPERSISTENCIA controllerAgendamento;

        public TAgendamentoPERSISTENCIA ControllerAgendamento
        {
            get
            {
                if (controllerAgendamento == null)
                    controllerAgendamento = new TAgendamentoPERSISTENCIA();

                return controllerAgendamento;

            }
        }

        private TEntrevistaDOMINIO dadosTEntrevista;

        public TEntrevistaDOMINIO DadosTEntrevista
        {
            get
            {
                if (dadosTEntrevista == null)
                    dadosTEntrevista = new TEntrevistaDOMINIO();

                return dadosTEntrevista;
            }
            set
            {
                dadosTEntrevista = value;
            }
        }

        private List<TRespostaDOMINIO> dadosTResposta;

        public List<TRespostaDOMINIO> DadosTResposta
        {
            get
            {
                if (dadosTResposta == null)
                    dadosTResposta = new List<TRespostaDOMINIO>();

                return dadosTResposta;
            }
            set
            {
                dadosTResposta = value;
            }
        }

        private TAgendamentoDOMINIO dadosTAgendamento;

        public TAgendamentoDOMINIO DadosTAgendamento
        {
            get
            {
                if (dadosTAgendamento == null)
                    dadosTAgendamento = new TAgendamentoDOMINIO();

                return dadosTAgendamento;
            }
            set
            {
                dadosTAgendamento = value;
            }
        }

        private DataTable _dadosCmbAba2MotivoNaoAgendamentoDia;
        public DataTable DadosCmbAba2MotivoNaoAgendamentoDia
        {
            get { return _dadosCmbAba2MotivoNaoAgendamentoDia; }
            set { _dadosCmbAba2MotivoNaoAgendamentoDia = value; }
        }

        private string _textoCmbAba2MotivoNaoAgendamentoDia;
        public string TextoCmbAba2MotivoNaoAgendamentoDia
        {
            get { return _textoCmbAba2MotivoNaoAgendamentoDia; }
            set { _textoCmbAba2MotivoNaoAgendamentoDia = value; }
        }

        private DataTable _dadosCmbAba2MotivoNaoAgendamentoMes;
        public DataTable DadosCmbAba2MotivoNaoAgendamentoMes
        {
            get { return _dadosCmbAba2MotivoNaoAgendamentoMes; }
            set { _dadosCmbAba2MotivoNaoAgendamentoMes = value; }
        }

        private string _textoCmbAba2MotivoNaoAgendamentoMes;
        public string TextoCmbAba2MotivoNaoAgendamentoMes
        {
            get { return _textoCmbAba2MotivoNaoAgendamentoMes; }
            set { _textoCmbAba2MotivoNaoAgendamentoMes = value; }
        }

        private DataTable _dadosCmbAba2MotivoNaoAgendamentoAno;
        public DataTable DadosCmbAba2MotivoNaoAgendamentoAno
        {
            get { return _dadosCmbAba2MotivoNaoAgendamentoAno; }
            set { _dadosCmbAba2MotivoNaoAgendamentoAno = value; }
        }

        private string _textoCmbAba2MotivoNaoAgendamentoAno;
        public string TextoCmbAba2MotivoNaoAgendamentoAno
        {
            get { return _textoCmbAba2MotivoNaoAgendamentoAno; }
            set { _textoCmbAba2MotivoNaoAgendamentoAno = value; }
        }

        private DataTable _dadosCmbAba2MotivoNaoAgendamentoHora;
        public DataTable DadosCmbAba2MotivoNaoAgendamentoHora
        {
            get { return _dadosCmbAba2MotivoNaoAgendamentoHora; }
            set { _dadosCmbAba2MotivoNaoAgendamentoHora = value; }
        }

        private string _textoCmbAba2MotivoNaoAgendamentoHora;
        public string TextoCmbAba2MotivoNaoAgendamentoHora
        {
            get { return _textoCmbAba2MotivoNaoAgendamentoHora; }
            set { _textoCmbAba2MotivoNaoAgendamentoHora = value; }
        }

        private DataTable _dadosCmbAba2MotivoNaoAgendamentoMinuto;
        public DataTable DadosCmbAba2MotivoNaoAgendamentoMinuto
        {
            get { return _dadosCmbAba2MotivoNaoAgendamentoMinuto; }
            set { _dadosCmbAba2MotivoNaoAgendamentoMinuto = value; }
        }

        private string _textoCmbAba2MotivoNaoAgendamentoMinuto;
        public string TextoCmbAba2MotivoNaoAgendamentoMinuto
        {
            get { return _textoCmbAba2MotivoNaoAgendamentoMinuto; }
            set { _textoCmbAba2MotivoNaoAgendamentoMinuto = value; }
        }

        private DataTable _dadosCmbAba2MotivoNao;
        public DataTable DadosCmbAba2MotivoNao
        {
            get { return _dadosCmbAba2MotivoNao; }
            set { _dadosCmbAba2MotivoNao = value; }
        }

        private string _textoCmbAba2MotivoNao;
        public string TextoCmbAba2MotivoNao
        {
            get { return _textoCmbAba2MotivoNao; }
            set { _textoCmbAba2MotivoNao = value; }
        }

        private int _abaAnterior;
        public int AbaAnterior
        {
            get { return _abaAnterior; }
            set { _abaAnterior = value; }
        }

        #endregion

        #region [ LOAD ]

        public frmFeedBackAlterado()
        {
            InitializeComponent();

            FocusOn();
            FocusOff();
            KeyDownTecla();
            KeyUpTecla();
        }

        private void frmFeedBackAlterado_Load(object sender, EventArgs e)
        {
            try
            {
                MostraCursor.CursorAguarde(true);

                chkAba1MR.Focus();                

                PopularCombos();

                MostraCursor.CursorAguarde(false);

                if (Program.CodigoEntrevista > 0 && !Program.IncluirRegistro)
                    PreencheFeedBack();

            }
            catch (Exception ex)
            {
                LogErro.GravaLog("Erro no Load do feedback.", ex.Message);
            }
            finally
            {
                MostraCursor.CursorAguarde(false);
            }
        }

        #endregion

        #region [ METHODS ]

        #region [ RECOVER ]

        private void PopularCombos()
        {
            try
            {
                cmbAba2MotivoNao.DisplayMember = "Value";
                cmbAba2MotivoNao.ValueMember = "Key";
                cmbAba2MotivoNao.DataSource = ControllerEnum.ListaDePerguntaFeedBackMotivoNao();
                DadosCmbAba2MotivoNao = ControllerEnum.ListaDePerguntaFeedBackMotivoNao();
                TextoCmbAba2MotivoNao = string.Empty;

                cmbAba2MotivoNaoAgendamentoDia.DisplayMember = "Value";
                cmbAba2MotivoNaoAgendamentoDia.ValueMember = "Key";
                cmbAba2MotivoNaoAgendamentoDia.DataSource = ControllerEnum.ListaDeDiaData(0);
                DadosCmbAba2MotivoNaoAgendamentoDia = ControllerEnum.ListaDeDiaData(0);
                TextoCmbAba2MotivoNaoAgendamentoDia = string.Empty;

                cmbAba2MotivoNaoAgendamentoMes.DisplayMember = "Value";
                cmbAba2MotivoNaoAgendamentoMes.ValueMember = "Key";
                cmbAba2MotivoNaoAgendamentoMes.DataSource = ControllerEnum.ListaDeMesData();
                DadosCmbAba2MotivoNaoAgendamentoMes = ControllerEnum.ListaDeMesData();
                TextoCmbAba2MotivoNaoAgendamentoMes = string.Empty;

                cmbAba2MotivoNaoAgendamentoAno.DisplayMember = "Value";
                cmbAba2MotivoNaoAgendamentoAno.ValueMember = "Key";
                cmbAba2MotivoNaoAgendamentoAno.DataSource = ControllerEnum.ListaDeAnoDataAgenda();
                DadosCmbAba2MotivoNaoAgendamentoAno = ControllerEnum.ListaDeAnoDataAgenda();
                TextoCmbAba2MotivoNaoAgendamentoAno = string.Empty;

                cmbAba2MotivoNaoAgendamentoHora.DisplayMember = "Value";
                cmbAba2MotivoNaoAgendamentoHora.ValueMember = "Key";
                cmbAba2MotivoNaoAgendamentoHora.DataSource = ControllerEnum.ListaDeHoraAgenda();
                DadosCmbAba2MotivoNaoAgendamentoHora = ControllerEnum.ListaDeHoraAgenda();
                TextoCmbAba2MotivoNaoAgendamentoHora = string.Empty;

                cmbAba2MotivoNaoAgendamentoMinuto.DisplayMember = "Value";
                cmbAba2MotivoNaoAgendamentoMinuto.ValueMember = "Key";
                cmbAba2MotivoNaoAgendamentoMinuto.DataSource = ControllerEnum.ListaDeMinutoAgenda();
                DadosCmbAba2MotivoNaoAgendamentoMinuto = ControllerEnum.ListaDeMinutoAgenda();
                TextoCmbAba2MotivoNaoAgendamentoMinuto = string.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void PreencheFeedBack()
        {
            try
            {
                if (Program.CodigoEntrevista > 0)
                {
                    DataTable tableTRepostaFeed1 = ControllerResposta.SelecioneRespostaFeedBack(Program.CodigoEntrevista, (int)CodigoPergunta.FEEDBACKABA1);

                    if (tableTRepostaFeed1.Rows.Count == 1)
                    {
                        int feed = Convert.ToInt32(tableTRepostaFeed1.Rows[0]["CodigoOpcao"].ToString());
                        PreencheABA1(feed);
                    }

                    DataTable tableTRepostaFeed2 = ControllerResposta.SelecioneRespostaFeedBack(Program.CodigoEntrevista, (int)CodigoPergunta.FEEDBACKABA2);

                    if (tableTRepostaFeed2.Rows.Count == 1)
                    {
                        int opcao = Convert.ToInt32(tableTRepostaFeed2.Rows[0]["CodigoOpcao"].ToString());
                        int subopcao = Convert.ToInt32(tableTRepostaFeed2.Rows[0]["CodigoSeqResposta"].ToString());
                        string textosub = tableTRepostaFeed2.Rows[0]["TextoSubResposta"].ToString();
                        PreencheABA2(opcao, subopcao, textosub);
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void PreencheABA1(int codigo)
        {
            try
            {
                chkAba1MR.Checked = false;
                chkAba1R.Checked = false;
                chkAba1I.Checked = false;
                chkAba1PR.Checked = false;

                switch (codigo)
                {
                    case 1:
                        chkAba1MR.Checked = true;
                        break;
                    case 2:
                        chkAba1R.Checked = true;
                        break;
                    case 3:
                        chkAba1I.Checked = true;
                        break;
                    case 4:
                        chkAba1PR.Checked = true;
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void PreencheABA2(int codigo, int codigoSub, string textSub)
        {
            try
            {
                pMotivo.Visible = false;
                pMotivoSim.Visible = false;
                pMotivoNao.Visible = false;
                pMotivoNaoAgendado.Visible = false;
                txtAba2MotivoSimProposta.Text = string.Empty;
                chkAba2Sim.Checked = false;
                chkAba2Nao.Checked = false;

                switch (codigo)
                {
                    case 1:
                        pMotivo.Visible = true;
                        pMotivoSim.Visible = true;
                        chkAba2Sim.Checked = true;
                        txtAba2MotivoSimProposta.Text = textSub;//Program.CodigoEntrevista.ToString();
                        break;
                    case 2:
                        pMotivo.Visible = true;
                        pMotivoNao.Visible = true;
                        pMotivoNaoAgendado.Visible = codigoSub == 1;
                        chkAba2Nao.Checked = true;
                        cmbAba2MotivoNao.SelectedValue = codigoSub;

                        string[] opcaoSub = textSub.Split(':');

                        if (opcaoSub.Length > 1)
                        {
                            string dataCompleta = opcaoSub[1].Trim();
                            if (dataCompleta.Length >= 8)
                            {
                                string separacao = dataCompleta.Replace('.', '-').Replace('/', '-').Replace(',', '-').Replace(' ', '-').Replace(':', '-').ToString();
                                string[] dataSeparada = separacao.Split('-');

                                if (dataSeparada.Length > 4)
                                {
                                    cmbAba2MotivoNaoAgendamentoDia.SelectedValue = dataSeparada[0].ToString();

                                    cmbAba2MotivoNaoAgendamentoMes.SelectedValue = dataSeparada[1].ToString();

                                    cmbAba2MotivoNaoAgendamentoAno.SelectedValue = dataSeparada[2].ToString();

                                    cmbAba2MotivoNaoAgendamentoHora.SelectedValue = dataSeparada[3].ToString();

                                    cmbAba2MotivoNaoAgendamentoMinuto.SelectedValue = dataSeparada[4].ToString();
                                }
                            }
                        }

                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region [ FILL ]

        private void MapearCamposTEntrevista()
        {
            if (Program.CodigoEntrevista > 0)
            {
                DataTable tableTEntrevista = ControllerEntrevista.SelecioneEntrevista(Program.CodigoEntrevista);

                if (tableTEntrevista.Rows.Count == 1)
                {
                    DadosTEntrevista.CodigoEntrevista = Convert.ToInt64(tableTEntrevista.Rows[0]["CodigoEntrevista"]);
                    DadosTEntrevista.CodigoColaborador = Convert.ToInt32(tableTEntrevista.Rows[0]["CodigoColaborador"]);
                    DadosTEntrevista.DataEntrevista = DateTime.Now;
                    DadosTEntrevista.CodigoUsuario = Convert.ToInt32(tableTEntrevista.Rows[0]["CodigoUsuario"]);
                    DadosTEntrevista.DataInclusao = Convert.ToDateTime(tableTEntrevista.Rows[0]["DataInclusao"]);
                    DadosTEntrevista.CodigoQuestionario = Convert.ToInt32(tableTEntrevista.Rows[0]["CodigoQuestionario"]);
                    DadosTEntrevista.OrigemVenda = tableTEntrevista.Rows[0]["OrigemVenda"].ToString();
                }
            }
        }

        private void MapearCamposTResposta()
        {
            try
            {
                if (Program.CodigoEntrevista > 0)
                {
                    DadosTResposta.Clear();

                    int idABA1 = 0;
                    string respostaABA1 = string.Empty;

                    VerficaABA1(ref idABA1, ref respostaABA1);

                    TRespostaDOMINIO dadosFeedBack1 = new TRespostaDOMINIO();
                    dadosFeedBack1.CodigoEntrevista = Program.CodigoEntrevista;
                    dadosFeedBack1.CodigoPergunta = (int)CodigoPergunta.FEEDBACKABA1;
                    dadosFeedBack1.CodigoOpcao = idABA1;
                    dadosFeedBack1.TextoResposta = respostaABA1;

                    DadosTResposta.Add(dadosFeedBack1);

                    int idABA5SUB2 = 0;
                    string respostaABA5SUB2 = string.Empty;
                    int idABA5SUB2Opcao = 0;
                    string respostaABA5SUB2Opcao = string.Empty;

                    VerficaABA2(ref idABA5SUB2, ref respostaABA5SUB2, ref idABA5SUB2Opcao, ref respostaABA5SUB2Opcao);

                    TRespostaDOMINIO dadosFeedBack2 = new TRespostaDOMINIO();
                    dadosFeedBack2.CodigoEntrevista = Program.CodigoEntrevista;
                    dadosFeedBack2.CodigoPergunta = (int)CodigoPergunta.FEEDBACKABA2;
                    dadosFeedBack2.CodigoOpcao = idABA5SUB2;
                    dadosFeedBack2.TextoResposta = respostaABA5SUB2;
                    dadosFeedBack2.CodigoSeqPergunta = idABA5SUB2Opcao;
                    dadosFeedBack2.TextoSubResposta = respostaABA5SUB2Opcao;

                    DadosTResposta.Add(dadosFeedBack2);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void MapearCamposTAgendamento()
        {
            try
            {
                if (Program.CodigoEntrevista > 0)
                {
                    DataTable DadosTEntrevistado = ControllerEntrevistado.SelecioneEntrevistado(Program.CodigoEntrevista);

                    if (DadosTEntrevistado.Rows.Count > 0)
                    {
                        DataTable DadosTEntrevistadoEndereco = ControllerEntrevistadoEndereco.SelecioneEntrevistadoEndereco(Program.CodigoEntrevista);

                        if (DadosTEntrevistadoEndereco.Rows.Count > 0)
                        {
                            DadosTAgendamento.Nome = DadosTEntrevistado.Rows[0]["Nome"].ToString();
                            DadosTAgendamento.DataNascimento = Convert.ToDateTime(DadosTEntrevistado.Rows[0]["DataNascimento"].ToString());
                            DadosTAgendamento.Telefone = "(" + DadosTEntrevistado.Rows[0]["DDD"].ToString() + ")" + DadosTEntrevistado.Rows[0]["Telefone"].ToString();
                            DadosTAgendamento.Celular = "(" + DadosTEntrevistado.Rows[0]["DDDCelular"].ToString() + ")" + DadosTEntrevistado.Rows[0]["Celular"].ToString();
                            DadosTAgendamento.Email = DadosTEntrevistadoEndereco.Rows[0]["Email"].ToString();
                            DadosTAgendamento.CEP = DadosTEntrevistadoEndereco.Rows[0]["CEP"].ToString();
                            DadosTAgendamento.Logradouro = DadosTEntrevistadoEndereco.Rows[0]["Endereco"].ToString();
                            DadosTAgendamento.Numero = DadosTEntrevistadoEndereco.Rows[0]["Numero"].ToString();
                            DadosTAgendamento.Complemento = DadosTEntrevistadoEndereco.Rows[0]["Complemento"].ToString();
                            DadosTAgendamento.Bairro = DadosTEntrevistadoEndereco.Rows[0]["Bairro"].ToString();
                            DadosTAgendamento.Cidade = DadosTEntrevistadoEndereco.Rows[0]["Cidade"].ToString();
                            DadosTAgendamento.UF = DadosTEntrevistadoEndereco.Rows[0]["UF"].ToString();
                            string dataAgendada = cmbAba2MotivoNaoAgendamentoAno.Text + "-" + cmbAba2MotivoNaoAgendamentoMes.Text.PadLeft(2, '0') + "-" + cmbAba2MotivoNaoAgendamentoDia.Text.PadLeft(2, '0') + " " + cmbAba2MotivoNaoAgendamentoHora.Text.PadLeft(2, '0') + ":" + cmbAba2MotivoNaoAgendamentoMinuto.Text.PadLeft(2, '0');
                            DadosTAgendamento.DataAgendada = DateTime.ParseExact(dataAgendada, "yyyy-MM-dd HH:mm", null);

                            ControllerAgendamento.SalvarAgendamento(DadosTAgendamento);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void AcertarFocuCampos()
        {
            try
            {
                switch (tabFeedBack.SelectedIndex)
                {
                    case 0:
                        chkAba1MR.Focus();
                        AbaAnterior = 0;
                        break;
                    case 1:
                        chkAba2Sim.Focus();
                        AbaAnterior = 1;
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ValidarCampos()
        {
            try
            {
                #region [ ABA 1 ]

                int idABA1 = 0;
                string respostaABA1 = string.Empty;

                VerficaABA1(ref idABA1, ref respostaABA1);

                if (idABA1 == 0)
                    throw new Exception("Campo Pergunta 1 não informado!");

                #endregion

                #region [ ABA 2 ]

                if (!chkAba2Sim.Checked && !chkAba2Nao.Checked)
                    throw new Exception("Campo Pergunta 2 não informado!");

                if (chkAba2Sim.Checked)
                {
                    if (String.IsNullOrEmpty(txtAba2MotivoSimProposta.Text))
                        throw new Exception("Campo Proposta não informado!");
                }

                if (chkAba2Nao.Checked)
                {
                    if (Convert.ToInt32(cmbAba2MotivoNao.SelectedValue) == 0)
                        throw new Exception("Campo Motivo não informado!");

                    if (Convert.ToInt32(cmbAba2MotivoNao.SelectedValue) == (int)FeedBackMotivoNao.Agendado)
                    {
                        if (Convert.ToInt32(cmbAba2MotivoNaoAgendamentoDia.SelectedValue) == 0)
                            throw new Exception("Campo Agendamento não informado!");

                        if (Convert.ToInt32(cmbAba2MotivoNaoAgendamentoMes.SelectedValue) == 0)
                            throw new Exception("Campo Agendamento não informado!");

                        if (Convert.ToInt32(cmbAba2MotivoNaoAgendamentoAno.SelectedValue) == 0)
                            throw new Exception("Campo Agendamento não informado!");

                        if (Convert.ToInt32(cmbAba2MotivoNaoAgendamentoHora.SelectedValue) == 0)
                            throw new Exception("Campo Agendamento não informado!");

                        if (Convert.ToInt32(cmbAba2MotivoNaoAgendamentoMinuto.SelectedValue) == 0)
                            throw new Exception("Campo Agendamento não informado!");
                    }
                }

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void VerficaABA1(ref int id, ref string resposta)
        {
            try
            {
                id = 0;
                resposta = string.Empty;

                if (chkAba1MR.Checked)
                {
                    id = 1;
                    resposta = chkAba1MR.Text;
                    return;
                }

                if (chkAba1R.Checked)
                {
                    id = 2;
                    resposta = chkAba1R.Text;
                    return;
                }

                if (chkAba1I.Checked)
                {
                    id = 3;
                    resposta = chkAba1I.Text;
                    return;
                }

                if (chkAba1PR.Checked)
                {
                    id = 4;
                    resposta = chkAba1PR.Text;
                    return;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void VerficaABA2(ref int id, ref string resposta, ref int idSub, ref string respostaSub)
        {
            try
            {
                id = 0;
                resposta = string.Empty;
                idSub = 0;
                respostaSub = string.Empty;

                if (chkAba2Sim.Checked)
                {
                    id = 1;
                    resposta = chkAba2Sim.Text;
                    //Dia 09/01/2014 - Conversado com a Fátima independente de ser sim ou não fica sempre visível a subpergunta
                    idSub = 1;
                    respostaSub = txtAba2MotivoSimProposta.Text;
                    return;
                }

                if (chkAba2Nao.Checked)
                {
                    id = 2;
                    resposta = chkAba2Nao.Text;
                    idSub = Convert.ToInt32(cmbAba2MotivoNao.SelectedValue);

                    if (idSub == 1)
                    {
                        respostaSub = cmbAba2MotivoNaoAgendamentoDia.Text + "/" + cmbAba2MotivoNaoAgendamentoMes.Text + "/" + cmbAba2MotivoNaoAgendamentoAno.Text + " " + cmbAba2MotivoNaoAgendamentoHora.Text + ":" + cmbAba2MotivoNaoAgendamentoMinuto.Text;

                        MapearCamposTAgendamento();
                    }
                    //cmbAba2MotivoNao.Text + ": " + cmbAba2MotivoNaoAgendamentoDia.Text + "/" + cmbAba2MotivoNaoAgendamentoMes.Text + "/" + cmbAba2MotivoNaoAgendamentoAno.Text;
                    //Dia 10/01/2014 - E-mail com a Fátima
                    //else
                    //    respostaSub = cmbAba2MotivoNao.Text;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region [ CLEAR ]

        private void LimparAba2()
        {
            try
            {
                txtAba2MotivoSimProposta.Text = string.Empty;
                cmbAba2MotivoNao.SelectedValue = "0";
                cmbAba2MotivoNaoAgendamentoDia.SelectedValue = "0";
                cmbAba2MotivoNaoAgendamentoMes.SelectedValue = "0";
                cmbAba2MotivoNaoAgendamentoAno.SelectedValue = "0";
                pMotivo.Visible = false;
                pMotivoSim.Visible = false;
                pMotivoNao.Visible = false;
                pMotivoNaoAgendado.Visible = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #endregion

        #region [ CONTROLS ]

        private void Texto_GotFocus(object sender, EventArgs e)
        {
            try
            {
                //Aciona o botão Laranja
                var newstate = Symbol.Keyboard.KeyStates.KEYSTATE_UNSHIFT;
                Symbol.Keyboard.KeyPad teclado = new Symbol.Keyboard.KeyPad();
                teclado.SetKeyState(newstate, 0, true);
            }
            catch (Exception ex)
            {
                LogErro.GravaLog("Erro ao Texto_GotFocus do feedback.", ex.Message);
            }
        }

        private void Numero_GotFocus(object sender, EventArgs e)
        {
            try
            {
                //Aciona o botão Laranja
                var newstate = Symbol.Keyboard.KeyStates.KEYSTATE_NUMERIC_LOCK;
                Symbol.Keyboard.KeyPad teclado = new Symbol.Keyboard.KeyPad();
                teclado.SetKeyState(newstate, 0, true);
            }
            catch (Exception ex)
            {
                LogErro.GravaLog("Erro ao Texto_GotFocus do feedback.", ex.Message);
            }
        }

        #region [ Controls Aba 1 ]

        private void chkAba1_Click(object sender, EventArgs e)
        {
            try
            {
                bool objetoOrigem = ((CheckBox)sender).Checked;
                UnCheckedAba1();

                switch (((CheckBox)sender).Name)
                {
                    case "chkAba1MR":
                        chkAba1MR.Checked = objetoOrigem;
                        break;
                    case "chkAba1R":
                        chkAba1R.Checked = objetoOrigem;
                        break;
                    case "chkAba1I":
                        chkAba1I.Checked = objetoOrigem;
                        break;
                    case "chkAba1PR":
                        chkAba1PR.Checked = objetoOrigem;
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                LogErro.GravaLog("Erro ao chkAba1_Click do feedback.", ex.Message);
            }
        }

        private void UnCheckedAba1()
        {
            try
            {
                chkAba1MR.Checked = false;
                chkAba1R.Checked = false;
                chkAba1I.Checked = false;
                chkAba1PR.Checked = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void chkAba1PR_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    tabFeedBack.SelectedIndex = 1;
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                LogErro.GravaLog("Erro ao chkAba1PR_KeyUp do feedback.", ex.Message);
            }
        }

        #endregion

        #region [ Controls Aba 2 ]

        private void chkAba2chk1_Click(object sender, EventArgs e)
        {
            try
            {
                bool objetoOrigem = ((CheckBox)sender).Checked;
                UnCheckedAba2chk1();

                switch (((CheckBox)sender).Name)
                {
                    case "chkAba2Sim":
                        chkAba2Sim.Checked = objetoOrigem;
                        break;
                    case "chkAba2Nao":
                        chkAba2Nao.Checked = objetoOrigem;
                        break;
                    default:
                        break;
                }

                pMotivo.Visible = true;
                pMotivoSim.Visible = chkAba2Sim.Checked;
                pMotivoNao.Visible = chkAba2Nao.Checked;
                pMotivoNaoAgendado.Visible = false;

                if (chkAba2Sim.Checked)
                {
                    cmbAba2MotivoNao.SelectedIndex = 0;
                    cmbAba2MotivoNaoAgendamentoDia.SelectedIndex = 0;
                    cmbAba2MotivoNaoAgendamentoMes.SelectedIndex = 0;
                    cmbAba2MotivoNaoAgendamentoAno.SelectedIndex = 0;
                }

                if (chkAba2Nao.Checked)
                {
                    txtAba2MotivoSimProposta.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                LogErro.GravaLog("Erro ao chkAba2chk1_Click do feedback.", ex.Message);
            }
        }

        private void UnCheckedAba2chk1()
        {
            try
            {
                chkAba2Sim.Checked = false;
                chkAba2Nao.Checked = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void chkAba2Nao_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && chkAba2Sim.Checked)
                {
                    txtAba2MotivoSimProposta.Focus();
                    e.Handled = true;
                }
                else if (e.KeyCode == Keys.Enter && chkAba2Nao.Checked)
                {
                    cmbAba2MotivoNao.Focus();
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                LogErro.GravaLog("Erro ao chkAba2Nao_KeyUp do feedback.", ex.Message);
            }
        }

        private void txtAba2MotivoSimProposta_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnSalvar.Focus();
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                LogErro.GravaLog("Erro ao txtAba2MotivoSimProposta_KeyUp do feedback.", ex.Message);
            }
        }

        private void cmbAba2MotivoNao_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbAba2MotivoNaoAgendamentoDia.SelectedValue = "0";
                cmbAba2MotivoNaoAgendamentoMes.SelectedValue = "0";
                cmbAba2MotivoNaoAgendamentoAno.SelectedValue = "0";
                cmbAba2MotivoNaoAgendamentoHora.SelectedValue = "0";
                cmbAba2MotivoNaoAgendamentoMinuto.SelectedValue = "0";

                pMotivoNaoAgendado.Visible = Convert.ToInt32(cmbAba2MotivoNao.SelectedValue) == (int)FeedBackMotivoNao.Agendado;
            }
            catch (Exception ex)
            {
                LogErro.GravaLog("Erro ao cmbAba2MotivoNao_SelectedIndexChanged do feedback.", ex.Message);
            }
        }

        private void cmbAba2MotivoNaoAgendamentoDia_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 42 || e.KeyChar == 9  || e.KeyChar == 13)
                {
                    TextoCmbAba2MotivoNaoAgendamentoDia = string.Empty;
                    e.Handled = true;
                    return;
                }

                string atual = TextoCmbAba2MotivoNaoAgendamentoDia;
                TextoCmbAba2MotivoNaoAgendamentoDia += e.KeyChar.ToString();

                DataRow[] verificaCombo = DadosCmbAba2MotivoNaoAgendamentoDia.Select("Value LIKE '" + TextoCmbAba2MotivoNaoAgendamentoDia + "%'");
                if (verificaCombo.Length > 0)
                {
                    ((ComboBox)sender).SelectedValue = verificaCombo[0].ItemArray[0];
                }
                else
                {
                    TextoCmbAba2MotivoNaoAgendamentoDia = atual;
                }

                e.Handled = true;
            }
            catch (Exception ex)
            {
                LogErro.GravaLog("Erro ao cmbAba2MotivoNaoAgendamentoDia_KeyPress do feedback.", ex.Message);
            }
        }

        private void cmbAba2MotivoNaoAgendamentoMes_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 42 || e.KeyChar == 9  || e.KeyChar == 13)
                {
                    TextoCmbAba2MotivoNaoAgendamentoMes = string.Empty;
                    e.Handled = true;
                    return;
                }

                string atual = TextoCmbAba2MotivoNaoAgendamentoMes;
                TextoCmbAba2MotivoNaoAgendamentoMes += e.KeyChar.ToString();

                DataRow[] verificaCombo = DadosCmbAba2MotivoNaoAgendamentoMes.Select("Value LIKE '" + TextoCmbAba2MotivoNaoAgendamentoMes + "%'");
                if (verificaCombo.Length > 0)
                {
                    ((ComboBox)sender).SelectedValue = verificaCombo[0].ItemArray[0];
                }
                else
                {
                    TextoCmbAba2MotivoNaoAgendamentoMes = atual;
                }

                e.Handled = true;
            }
            catch (Exception ex)
            {
                LogErro.GravaLog("Erro ao cmbAba2MotivoNaoAgendamentoMes_KeyPress do feedback.", ex.Message);
            }
        }

        private void cmbAba2MotivoNaoAgendamentoMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int valor = Convert.ToInt32(cmbAba2MotivoNaoAgendamentoDia.SelectedValue);

                DataTable tabelaDias = ControllerEnum.ListaDeDiaData(Convert.ToInt32(cmbAba2MotivoNaoAgendamentoMes.SelectedValue));
                DataRow[] verificaTabela = tabelaDias.Select("Key = '" + valor + "'");

                cmbAba2MotivoNaoAgendamentoDia.DisplayMember = "Value";
                cmbAba2MotivoNaoAgendamentoDia.ValueMember = "Key";
                cmbAba2MotivoNaoAgendamentoDia.DataSource = tabelaDias;

                if (verificaTabela.Length > 0)
                    cmbAba2MotivoNaoAgendamentoDia.SelectedValue = valor;
            }
            catch (Exception ex)
            {
                LogErro.GravaLog("Erro ao cmbAba2MotivoNaoAgendamentoMes_SelectedIndexChanged do feedback.", ex.Message);
            }
        }

        private void cmbAba2MotivoNaoAgendamentoAno_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 42 || e.KeyChar == 9  || e.KeyChar == 13)
                {
                    TextoCmbAba2MotivoNaoAgendamentoAno = string.Empty;
                    e.Handled = true;
                    return;
                }

                string atual = TextoCmbAba2MotivoNaoAgendamentoAno;
                TextoCmbAba2MotivoNaoAgendamentoAno += e.KeyChar.ToString();

                DataRow[] verificaCombo = DadosCmbAba2MotivoNaoAgendamentoAno.Select("Value LIKE '%" + TextoCmbAba2MotivoNaoAgendamentoAno + "%'");
                if (verificaCombo.Length > 0)
                {
                    ((ComboBox)sender).SelectedValue = verificaCombo[0].ItemArray[0];
                }
                else
                {
                    TextoCmbAba2MotivoNaoAgendamentoAno = atual;
                }

                e.Handled = true;
            }
            catch (Exception ex)
            {
                LogErro.GravaLog("Erro ao cmbAba2MotivoNaoAgendamentoAno_KeyPress do feedback.", ex.Message);
            }
        }

        private void cmbAba2MotivoNaoAgendamentoHora_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 42 || e.KeyChar == 9  || e.KeyChar == 13)
                {
                    TextoCmbAba2MotivoNaoAgendamentoHora = string.Empty;
                    e.Handled = true;
                    return;
                }

                string atual = TextoCmbAba2MotivoNaoAgendamentoHora;
                TextoCmbAba2MotivoNaoAgendamentoHora += e.KeyChar.ToString();

                DataRow[] verificaCombo = DadosCmbAba2MotivoNaoAgendamentoHora.Select("Value LIKE '" + TextoCmbAba2MotivoNaoAgendamentoHora + "%'");
                if (verificaCombo.Length > 0)
                {
                    ((ComboBox)sender).SelectedValue = verificaCombo[0].ItemArray[0];
                }
                else
                {
                    TextoCmbAba2MotivoNaoAgendamentoHora = atual;
                }

                e.Handled = true;
            }
            catch (Exception ex)
            {
                LogErro.GravaLog("Erro ao cmbAba2MotivoNaoAgendamentoHora_KeyPress do feedback.", ex.Message);
            }
        }

        private void cmbAba2MotivoNaoAgendamentoMinuto_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 42 || e.KeyChar == 9  || e.KeyChar == 13)
                {
                    TextoCmbAba2MotivoNaoAgendamentoMinuto = string.Empty;
                    e.Handled = true;
                    return;
                }

                string atual = TextoCmbAba2MotivoNaoAgendamentoMinuto;
                TextoCmbAba2MotivoNaoAgendamentoMinuto += e.KeyChar.ToString();

                DataRow[] verificaCombo = DadosCmbAba2MotivoNaoAgendamentoMinuto.Select("Value LIKE '" + TextoCmbAba2MotivoNaoAgendamentoMinuto + "%'");
                if (verificaCombo.Length > 0)
                {
                    ((ComboBox)sender).SelectedValue = verificaCombo[0].ItemArray[0];
                }
                else
                {
                    TextoCmbAba2MotivoNaoAgendamentoMinuto = atual;
                }

                e.Handled = true;
            }
            catch (Exception ex)
            {
                LogErro.GravaLog("Erro ao cmbAba2MotivoNaoAgendamentoMinuto_KeyPress do feedback.", ex.Message);
            }
        }

        private void cmbAba2MotivoNaoAgendamentoMinuto_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnSalvar.Focus();
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                LogErro.GravaLog("Erro ao cmbAba2MotivoNaoAgendamentoMinuto_KeyUp do feedback.", ex.Message);
            }
        }

        private void cmbAba2MotivoNao_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 42 || e.KeyChar == 9  || e.KeyChar == 13)
                {
                    TextoCmbAba2MotivoNao = string.Empty;
                    e.Handled = true;
                    return;
                }

                string atual = TextoCmbAba2MotivoNao;
                TextoCmbAba2MotivoNao += e.KeyChar.ToString();

                DataRow[] verificaCombo = DadosCmbAba2MotivoNao.Select("Value LIKE '" + TextoCmbAba2MotivoNao + "%'");
                if (verificaCombo.Length > 0)
                {
                    ((ComboBox)sender).SelectedValue = verificaCombo[0].ItemArray[0];
                }
                else
                {
                    TextoCmbAba2MotivoNao = atual;
                }

                e.Handled = true;
            }
            catch (Exception ex)
            {
                LogErro.GravaLog("Erro ao cmbAba2MotivoNao_KeyPress do feedback.", ex.Message);
            }
        }

        private void cmbAba2MotivoNao_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && Convert.ToInt32(cmbAba2MotivoNao.SelectedValue) != (int)FeedBackMotivoNao.Agendado)
                {
                    btnSalvar.Focus();
                    e.Handled = true;
                }
                else if (e.KeyCode == Keys.Enter && Convert.ToInt32(cmbAba2MotivoNao.SelectedValue) == (int)FeedBackMotivoNao.Agendado)
                {
                    cmbAba2MotivoNaoAgendamentoDia.Focus();
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                LogErro.GravaLog("Erro ao cmbAba2MotivoNao_KeyUp do feedback.", ex.Message);
            }
        }

        #endregion

        private void FocusOn()
        {
            cmbAba2MotivoNaoAgendamentoMinuto.GotFocus += new EventHandler(Program.cmbBox_focusOn);
            cmbAba2MotivoNaoAgendamentoHora.GotFocus += new EventHandler(Program.cmbBox_focusOn);
            cmbAba2MotivoNaoAgendamentoAno.GotFocus += new EventHandler(Program.cmbBox_focusOn);
            cmbAba2MotivoNaoAgendamentoMes.GotFocus += new EventHandler(Program.cmbBox_focusOn);
            cmbAba2MotivoNaoAgendamentoDia.GotFocus += new EventHandler(Program.cmbBox_focusOn);
            cmbAba2MotivoNao.GotFocus += new EventHandler(Program.cmbBox_focusOn);
            txtAba2MotivoSimProposta.GotFocus += new EventHandler(Program.txtBox_focusOn);            
            btnSalvar.GotFocus += new EventHandler(Program.btn_focusOn);
            bntSair.GotFocus += new EventHandler(Program.btn_focusOn);
        }

        private void FocusOff()
        {
            cmbAba2MotivoNaoAgendamentoMinuto.LostFocus += new EventHandler(Program.cmbBox_focusOff);
            cmbAba2MotivoNaoAgendamentoHora.LostFocus += new EventHandler(Program.cmbBox_focusOff);
            cmbAba2MotivoNaoAgendamentoAno.LostFocus += new EventHandler(Program.cmbBox_focusOff);
            cmbAba2MotivoNaoAgendamentoMes.LostFocus += new EventHandler(Program.cmbBox_focusOff);
            cmbAba2MotivoNaoAgendamentoDia.LostFocus += new EventHandler(Program.cmbBox_focusOff);
            cmbAba2MotivoNao.LostFocus += new EventHandler(Program.cmbBox_focusOff);
            txtAba2MotivoSimProposta.LostFocus += new EventHandler(Program.txtBox_focusOff);
            btnSalvar.LostFocus += new EventHandler(Program.btn_focusOffAzul);
            bntSair.LostFocus += new EventHandler(Program.btn_focusOffAzul);
        }

        private void KeyDownTecla()
        {
            //Only button and check

            chkAba1PR.KeyDown += new KeyEventHandler(Program.chkBox_enter);
            chkAba1I.KeyDown += new KeyEventHandler(Program.chkBox_enter);
            chkAba1R.KeyDown += new KeyEventHandler(Program.chkBox_enter);
            chkAba1MR.KeyDown += new KeyEventHandler(Program.chkBox_enter);
            chkAba2Nao.KeyDown += new KeyEventHandler(Program.chkBox_enter);
            chkAba2Sim.KeyDown += new KeyEventHandler(Program.chkBox_enter);
            btnSalvar.KeyDown += new KeyEventHandler(Program.btn_enter);
            bntSair.KeyDown += new KeyEventHandler(Program.btn_enter);

        }

        private void KeyUpTecla()
        {
            chkAba1PR.KeyUp += new KeyEventHandler(chkAba1PR_KeyUp);
            chkAba1I.KeyUp += new KeyEventHandler(Program.chkBox_next);
            chkAba1R.KeyUp += new KeyEventHandler(Program.chkBox_next);
            chkAba1MR.KeyUp += new KeyEventHandler(Program.chkBox_next);
            chkAba2Nao.KeyUp += new KeyEventHandler(chkAba2Nao_KeyUp);
            chkAba2Sim.KeyUp += new KeyEventHandler(Program.chkBox_next);
            cmbAba2MotivoNaoAgendamentoMinuto.KeyUp += new KeyEventHandler(cmbAba2MotivoNaoAgendamentoMinuto_KeyUp);
            cmbAba2MotivoNaoAgendamentoHora.KeyUp += new KeyEventHandler(Program.cmbBox_next);
            cmbAba2MotivoNaoAgendamentoAno.KeyUp += new KeyEventHandler(Program.cmbBox_next);
            cmbAba2MotivoNaoAgendamentoMes.KeyUp += new KeyEventHandler(Program.cmbBox_next);
            cmbAba2MotivoNaoAgendamentoDia.KeyUp += new KeyEventHandler(Program.cmbBox_next);
            cmbAba2MotivoNao.KeyUp += new KeyEventHandler(cmbAba2MotivoNao_KeyUp);
            txtAba2MotivoSimProposta.KeyUp += new KeyEventHandler(txtAba2MotivoSimProposta_KeyUp);
            btnSalvar.KeyUp += new KeyEventHandler(Program.btn_next);
            bntSair.KeyUp += new KeyEventHandler(Program.btn_next);
        }

        #endregion

        #region [ BUTTONS ]

        private void bntSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Program.CodigoEntrevista > 0)
                {
                    MostraCursor.CursorAguarde(true);

                    ValidarCampos();

                    MapearCamposTResposta();

                    if (ControllerResposta.SalvarFeedBack(DadosTResposta))
                    {
                        MapearCamposTEntrevista();
                        DadosTEntrevista.Completa = true;
                        ControllerEntrevista.AtualizarEntrevista(dadosTEntrevista);

                        MostraCursor.CursorAguarde(false);
                        CaixaMensagem.ExibirOk("Formulário concluído com sucesso!");
                        Program.CodigoEntrevista = 0;
                        this.Close();
                    }
                    else
                    {
                        MostraCursor.CursorAguarde(false);
                        CaixaMensagem.ExibirOk("Erro ao salvar o FeedBack!");
                    }
                }
            }
            catch (Exception ex)
            {
                MostraCursor.CursorAguarde(false);
                CaixaMensagem.ExibirOk(ex.Message);
                LogErro.GravaLog("Erro ao Salvar.", ex.Message);
            }
        }

        private void tabFeedBack_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostraCursor.CursorAguarde(true);
            if (AbaAnterior != tabFeedBack.SelectedIndex)
            {
                switch (AbaAnterior)
                {
                    case 0:
                        //espaço reservado para salvar por aba
                        AcertarFocuCampos();
                        break;
                    case 1:
                        AcertarFocuCampos();
                        break;
                    default:
                        break;
                }
            }

            MostraCursor.CursorAguarde(false);
        }

        #endregion
    }
}
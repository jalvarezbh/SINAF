using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Symbol;
using ProjetoMobile.Dominio;
using ProjetoMobile.Persistencia;
using ProjetoMobile.Dominio.Enumeradores;
using ProjetoMobile.Util;
using System.Globalization;

namespace ProjetoMobile
{
    public partial class frmEntrevista : Form
    {
        #region [ PROPERTIES ]

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

        private TGPSPERSISTENCIA controllerGPS;

        public TGPSPERSISTENCIA ControllerGPS
        {
            get
            {
                if (controllerGPS == null)
                    controllerGPS = new TGPSPERSISTENCIA();

                return controllerGPS;
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

        private TLogradouroPERSISTENCIA controllerLogradouro;

        public TLogradouroPERSISTENCIA ControllerLogradouro
        {
            get
            {
                if (controllerLogradouro == null)
                    controllerLogradouro = new TLogradouroPERSISTENCIA();

                return controllerLogradouro;

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

        private TPlanoPERSISTENCIA controllerPlano;

        public TPlanoPERSISTENCIA ControllerPlano
        {
            get
            {
                if (controllerPlano == null)
                    controllerPlano = new TPlanoPERSISTENCIA();

                return controllerPlano;

            }
        }

        private TPlanoProtecaoPERSISTENCIA controllerPlanoProtecao;

        public TPlanoProtecaoPERSISTENCIA ControllerPlanoProtecao
        {
            get
            {
                if (controllerPlanoProtecao == null)
                    controllerPlanoProtecao = new TPlanoProtecaoPERSISTENCIA();

                return controllerPlanoProtecao;

            }
        }

        private TPlanoSeniorPERSISTENCIA controllerPlanoSenior;

        public TPlanoSeniorPERSISTENCIA ControllerPlanoSenior
        {
            get
            {
                if (controllerPlanoSenior == null)
                    controllerPlanoSenior = new TPlanoSeniorPERSISTENCIA();

                return controllerPlanoSenior;

            }
        }

        private TPlanoCasalPERSISTENCIA controllerPlanoCasal;

        public TPlanoCasalPERSISTENCIA ControllerPlanoCasal
        {
            get
            {
                if (controllerPlanoCasal == null)
                    controllerPlanoCasal = new TPlanoCasalPERSISTENCIA();

                return controllerPlanoCasal;

            }
        }

        private TSimuladorProdutoPERSISTENCIA controllerSimuladorProduto;

        public TSimuladorProdutoPERSISTENCIA ControllerSimuladorProduto
        {
            get
            {
                if (controllerSimuladorProduto == null)
                    controllerSimuladorProduto = new TSimuladorProdutoPERSISTENCIA();

                return controllerSimuladorProduto;

            }
        }

        private TSimuladorSubRendaPERSISTENCIA controllerSimuladorSubRenda;

        public TSimuladorSubRendaPERSISTENCIA ControllerSimuladorSubRenda
        {
            get
            {
                if (controllerSimuladorSubRenda == null)
                    controllerSimuladorSubRenda = new TSimuladorSubRendaPERSISTENCIA();

                return controllerSimuladorSubRenda;

            }
        }

        private TSimuladorSubAgregadoPERSISTENCIA controllerSimuladorSubAgregado;

        public TSimuladorSubAgregadoPERSISTENCIA ControllerSimuladorSubAgregado
        {
            get
            {
                if (controllerSimuladorSubAgregado == null)
                    controllerSimuladorSubAgregado = new TSimuladorSubAgregadoPERSISTENCIA();

                return controllerSimuladorSubAgregado;
            }
        }

        private TSimuladorSubFuneralPERSISTENCIA controllerSimuladorSubFuneral;

        public TSimuladorSubFuneralPERSISTENCIA ControllerSimuladorSubFuneral
        {
            get
            {
                if (controllerSimuladorSubFuneral == null)
                    controllerSimuladorSubFuneral = new TSimuladorSubFuneralPERSISTENCIA();

                return controllerSimuladorSubFuneral;
            }
        }

        private TFaixaPERSISTENCIA controllerFaixa;

        public TFaixaPERSISTENCIA ControllerFaixa
        {
            get
            {
                if (controllerFaixa == null)
                    controllerFaixa = new TFaixaPERSISTENCIA();

                return controllerFaixa;
            }
        }

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

        private TProfissaoPERSISTENCIA controllerProfissao;

        public TProfissaoPERSISTENCIA ControllerProfissao
        {
            get
            {
                if (controllerProfissao == null)
                    controllerProfissao = new TProfissaoPERSISTENCIA();

                return controllerProfissao;

            }
        }

        private TEstadoPERSISTENCIA controllerEstado;

        public TEstadoPERSISTENCIA ControllerEstado
        {
            get
            {
                if (controllerEstado == null)
                    controllerEstado = new TEstadoPERSISTENCIA();

                return controllerEstado;

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

        private TPlanoProtecaoDOMINIO dadosTPlanoProtecao;

        public TPlanoProtecaoDOMINIO DadosTPlanoProtecao
        {
            get
            {
                if (dadosTPlanoProtecao == null)
                    dadosTPlanoProtecao = new TPlanoProtecaoDOMINIO();

                return dadosTPlanoProtecao;
            }
            set
            {
                dadosTPlanoProtecao = value;
            }
        }

        private TPlanoSeniorDOMINIO dadosTPlanoSenior;

        public TPlanoSeniorDOMINIO DadosTPlanoSenior
        {
            get
            {
                if (dadosTPlanoSenior == null)
                    dadosTPlanoSenior = new TPlanoSeniorDOMINIO();

                return dadosTPlanoSenior;
            }
            set
            {
                dadosTPlanoSenior = value;
            }
        }

        private TPlanoCasalDOMINIO dadosTPlanoCasal;

        public TPlanoCasalDOMINIO DadosTPlanoCasal
        {
            get
            {
                if (dadosTPlanoCasal == null)
                    dadosTPlanoCasal = new TPlanoCasalDOMINIO();

                return dadosTPlanoCasal;
            }
            set
            {
                dadosTPlanoCasal = value;
            }
        }

        private TPlanoProtecaoDOMINIO dadosTPlanoProtecaoNovo;

        public TPlanoProtecaoDOMINIO DadosTPlanoProtecaoNovo
        {
            get
            {
                if (dadosTPlanoProtecaoNovo == null)
                    dadosTPlanoProtecaoNovo = new TPlanoProtecaoDOMINIO();

                return dadosTPlanoProtecaoNovo;
            }
            set
            {
                dadosTPlanoProtecaoNovo = value;
            }
        }

        private TPlanoProtecaoDOMINIO dadosTPlanoProtecaoRendaNovo;

        public TPlanoProtecaoDOMINIO DadosTPlanoProtecaoRendaNovo
        {
            get
            {
                if (dadosTPlanoProtecaoRendaNovo == null)
                    dadosTPlanoProtecaoRendaNovo = new TPlanoProtecaoDOMINIO();

                return dadosTPlanoProtecaoRendaNovo;
            }
            set
            {
                dadosTPlanoProtecaoRendaNovo = value;
            }
        }

        private TPlanoSeniorDOMINIO dadosTPlanoSeniorNovo;

        public TPlanoSeniorDOMINIO DadosTPlanoSeniorNovo
        {
            get
            {
                if (dadosTPlanoSeniorNovo == null)
                    dadosTPlanoSeniorNovo = new TPlanoSeniorDOMINIO();

                return dadosTPlanoSeniorNovo;
            }
            set
            {
                dadosTPlanoSeniorNovo = value;
            }
        }

        private TPlanoCasalDOMINIO dadosTPlanoCasalNovo;

        public TPlanoCasalDOMINIO DadosTPlanoCasalNovo
        {
            get
            {
                if (dadosTPlanoCasalNovo == null)
                    dadosTPlanoCasalNovo = new TPlanoCasalDOMINIO();

                return dadosTPlanoCasalNovo;
            }
            set
            {
                dadosTPlanoCasalNovo = value;
            }
        }

        private List<ProdutoPrincipal> _produtoDisponivel;

        public List<ProdutoPrincipal> ProdutoDisponivel
        {
            get { return _produtoDisponivel; }
            set { _produtoDisponivel = value; }
        }

        private List<TAgregadoDOMINIO> _listaAgregadoNovo;

        public List<TAgregadoDOMINIO> ListaAgregadoNovo
        {
            get
            {
                if (_listaAgregadoNovo == null)
                    _listaAgregadoNovo = new List<TAgregadoDOMINIO>();

                return _listaAgregadoNovo;
            }
            set { _listaAgregadoNovo = value; }
        }

        private List<TAgregadoDOMINIO> _listaAgregadoTemp;

        public List<TAgregadoDOMINIO> ListaAgregadoTemp
        {
            get
            {
                if (_listaAgregadoTemp == null)
                    _listaAgregadoTemp = new List<TAgregadoDOMINIO>();

                return _listaAgregadoTemp;
            }
            set { _listaAgregadoTemp = value; }
        }

        private TSimuladorProdutoDOMINIO dadosTSimuladorProduto;

        public TSimuladorProdutoDOMINIO DadosTSimuladorProduto
        {
            get
            {
                if (dadosTSimuladorProduto == null)
                    dadosTSimuladorProduto = new TSimuladorProdutoDOMINIO();

                return dadosTSimuladorProduto;
            }
            set
            {
                dadosTSimuladorProduto = value;
            }
        }

        private List<TSimuladorSubAgregadoDOMINIO> dadosTSimuladorSubAgregado;

        public List<TSimuladorSubAgregadoDOMINIO> DadosTSimuladorSubAgregado
        {
            get
            {
                if (dadosTSimuladorSubAgregado == null)
                    dadosTSimuladorSubAgregado = new List<TSimuladorSubAgregadoDOMINIO>();

                return dadosTSimuladorSubAgregado;
            }
            set
            {
                dadosTSimuladorSubAgregado = value;
            }
        }

        private TSimuladorSubFuneralDOMINIO dadosTSimuladorSubFuneral;

        public TSimuladorSubFuneralDOMINIO DadosTSimuladorSubFuneral
        {
            get
            {
                if (dadosTSimuladorSubFuneral == null)
                    dadosTSimuladorSubFuneral = new TSimuladorSubFuneralDOMINIO();

                return dadosTSimuladorSubFuneral;
            }
            set
            {
                dadosTSimuladorSubFuneral = value;
            }
        }

        private TSimuladorSubRendaDOMINIO dadosTSimuladorSubRenda;

        public TSimuladorSubRendaDOMINIO DadosTSimuladorSubRenda
        {
            get
            {
                if (dadosTSimuladorSubRenda == null)
                    dadosTSimuladorSubRenda = new TSimuladorSubRendaDOMINIO();

                return dadosTSimuladorSubRenda;
            }
            set
            {
                dadosTSimuladorSubRenda = value;
            }
        }

        private int _faixaBase;
        public int FaixaBase
        {
            get { return _faixaBase; }
            set { _faixaBase = value; }
        }

        private int _resposta2;
        public int Resposta2
        {
            get { return _resposta2; }
            set { _resposta2 = value; }
        }

        private int _resposta7;
        public int Resposta7
        {
            get { return _resposta7; }
            set { _resposta7 = value; }
        }

        private int _abaAnterior;
        public int AbaAnterior
        {
            get { return _abaAnterior; }
            set { _abaAnterior = value; }
        }

        private int _subAbaAnterior;
        public int SubAbaAnterior
        {
            get { return _subAbaAnterior; }
            set { _subAbaAnterior = value; }
        }

        private int _simuladorAbaAnterior;
        public int SimuladorAbaAnterior
        {
            get { return _simuladorAbaAnterior; }
            set { _simuladorAbaAnterior = value; }
        }

        private int _simuladorAbaTabelaAnterior;
        public int SimuladorAbaTabelaAnterior
        {
            get { return _simuladorAbaTabelaAnterior; }
            set { _simuladorAbaTabelaAnterior = value; }
        }

        private decimal _premioPlano;
        public decimal PremioPlano
        {
            get { return _premioPlano; }
            set { _premioPlano = value; }
        }

        private decimal _premioAgregado;
        public decimal PremioAgregado
        {
            get { return _premioAgregado; }
            set { _premioAgregado = value; }
        }

        private decimal _premioAgregadoParcial;
        public decimal PremioAgregadoParcial
        {
            get { return _premioAgregadoParcial; }
            set { _premioAgregadoParcial = value; }
        }

        private List<decimal> _premioAgregadoTemp;
        public List<decimal> PremioAgregadoTemp
        {
            get
            {
                if (_premioAgregadoTemp != null)
                    return _premioAgregadoTemp;
                else
                    return new List<decimal>();
            }
            set { _premioAgregadoTemp = value; }
        }

        private decimal _premioRenda;
        public decimal PremioRenda
        {
            get { return _premioRenda; }
            set { _premioRenda = value; }
        }

        private decimal _premioRendaCapital;
        public decimal PremioRendaCapital
        {
            get { return _premioRendaCapital; }
            set { _premioRendaCapital = value; }
        }

        public decimal PremioTotal
        {
            get { return _premioPlano + _premioAgregado + _premioRenda; }
        }

        private int _produtoCalculo;
        public int ProdutoCalculo
        {
            get { return _produtoCalculo; }
            set { _produtoCalculo = value; }
        }

        private decimal _premioTotalMax;
        public decimal PremioTotalMax
        {
            get { return _premioTotalMax; }
            set { _premioTotalMax = value; }
        }

        #endregion

        #region [ LOAD ]

        public frmEntrevista()
        {
            InitializeComponent();
            MostraCursor.CursorAguarde(true);

            FocusOn();
            FocusOff();
            KeyDownTecla();
            KeyUpTecla();

            AbaAnterior = 0;
            Program.RegistroAntigo = false;

            if (Program.CodigoEntrevista > 0)
            {
                PopularCombosRegistroAntigo();
                PreencherCamposRegistroAntigo();
                VerificarBloqueioCamposEntrevistaAntiga();
            }

            AcertarFocuCampos();

            MostraCursor.CursorAguarde(false);
        }

        #endregion

        #region [ RECOVER ]

        private void PopularCombosRegistroAntigo()
        {
            PopularCombosAbaPessoal();
            PopularCombosAbaFormulario();
            PopularCombosAbaDados();
            PopularCombosAbaEndereco();
        }

        private void PreencherCamposRegistroAntigo()
        {
            MapearCamposPrincipal();
            PreencherCamposAbaPessoal();
            MapearCamposAbaPessoal();
            PreencherCamposAbaFormulario();
            MapearCamposAbaFormularioSubAba1();
            MapearCamposAbaFormularioSubAba2();
            MapearCamposAbaFormularioSubAba3();
            MapearCamposAbaFormularioSubAba4();
            MapearCamposAbaFormularioSubAba5();
            MapearCamposAbaFormularioSubAba6();
            MapearCamposAbaFormularioSubAba7();
            PreencherCamposAbaDados();
            MapearCamposAbaDados();
            PreencherCamposAbaEndereco();
            MapearCamposAbaEndereco();
            PopularSimulador();
        }

        private void VerificarBloqueioCamposEntrevistaAntiga()
        {
            if (ControllerFaixa.VerificarFaixaEntrevistaAntiga(Program.CodigoEntrevista))
            {
                Program.RegistroAntigo = true;
                BloquearCamposAbaPessoal();
                BloquearCamposAbaFormulario();
                BloquearCamposAbaDados();
                BloquearCamposAbaEndereco();
                BloquearCamposAbaSimulador();
                btnSalvar.Enabled = false;
                btnConcluir.Enabled = false;
            }
            else
            {
                Program.RegistroAntigo = false;
            }
        }

        #endregion

        #region [ FILL ]

        private void MapearCamposPrincipal()
        {
            if (Program.CodigoEntrevista == 0)
            {
                Program.CodigoEntrevista = Program.CodigoFaixa;
                DadosTEntrevista.CodigoEntrevista = Program.CodigoFaixa;
                DadosTEntrevista.CodigoColaborador = Program.CodigoColaborador;
                DadosTEntrevista.DataEntrevista = DateTime.Now;
                DadosTEntrevista.CodigoUsuario = Program.IDUsuario;
                DadosTEntrevista.DataInclusao = DateTime.Now;
                DadosTEntrevista.CodigoQuestionario = 4;
                DadosTEntrevista.OrigemVenda = "";//Dia 09/01/2014 Conversado com a Fátima para deixar vazio o valor
            }
            else
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
        }

        private void AcertarFocuCampos()
        {
            switch (tabEntrevista.SelectedIndex)
            {
                case 0:
                    PopularCombosAbaPessoal();
                    PreencherCamposAbaPessoal();
                    txtAba1Nome.Focus();
                    AbaAnterior = 0;
                    break;
                case 1:
                    if (ValidarCamposAbaPessoal())
                    {
                        PopularCombosAbaFormulario();
                        PreencherCamposAbaFormulario();
                        tabControlPerguntas.SelectedIndex = 0;
                        cmbAba2Sub1Grau.Focus();
                        AbaAnterior = 1;
                    }
                    else
                        tabEntrevista.SelectedIndex = AbaAnterior;
                    break;
                case 2:
                    if (ValidarCamposAbaPessoal()
                        && ValidarCamposAbaFormulario())
                    {
                        PopularCombosAbaDados();
                        PreencherCamposAbaDados();
                        txtAba3CPF.Focus();
                        AbaAnterior = 2;
                    }
                    else
                        tabEntrevista.SelectedIndex = AbaAnterior;
                    break;
                case 3:

                    if (ValidarCamposAbaPessoal()
                        && ValidarCamposAbaFormulario()
                        && ValidarCamposAbaDados(false))
                    {
                        PopularCombosAbaEndereco();
                        PreencherCamposAbaEndereco();
                        txtAba4CEPbox1.Focus();
                        AbaAnterior = 3;
                    }
                    else
                        tabEntrevista.SelectedIndex = AbaAnterior;
                    break;
                case 4:
                    if (ValidarCamposAbaPessoal()
                        && ValidarCamposAbaFormulario()
                        && ValidarCamposAbaDados(false)
                        && ValidarCamposAbaEndereco())
                    {
                        //TODO JOAO Verificar regra 81 anos 
                        if (ControllerEnum.FaixaEtariaDataNascimento(DadosTEntrevistado.DataNascimento.GetValueOrDefault()) == (int)FaixaEtaria.PREMIO_81)
                        {
                            Util.CaixaMensagem.ExibirOk("Entrevistado com mais de 81 anos, é possível concluir a Entrevista sem acesso ao simulador.");
                            tabEntrevista.SelectedIndex = AbaAnterior;
                        }
                        else
                        {
                            PopularSimulador();
                            tabControlSimulador.SelectedIndex = 0;
                            AbaAnterior = 4;
                        }
                    }
                    else
                        tabEntrevista.SelectedIndex = AbaAnterior;
                    break;
                default:
                    break;

            }
        }

        #endregion

        #region [ CONTROLS ]

        private void UpperCase_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((TextBox)sender).Text.Length == 0 && e.KeyChar != Convert.ToChar(Keys.Back) && e.KeyChar != Convert.ToChar(Keys.Enter))
            {
                ((TextBox)sender).Text = char.ToUpper(e.KeyChar).ToString();
                ((TextBox)sender).SelectionStart = ((TextBox)sender).Text.Length;
                e.Handled = true;
                return;
            }

            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                e.Handled = true;
        }

        private void Texto_GotFocus(object sender, EventArgs e)
        {
            var newstate = Symbol.Keyboard.KeyStates.KEYSTATE_UNSHIFT;
            Symbol.Keyboard.KeyPad teclado = new Symbol.Keyboard.KeyPad();
            teclado.SetKeyState(newstate, 0, true);
        }

        private void Numero_KeyPress(object sender, KeyPressEventArgs e)
        {
            char digitoSaida = '0';
            bool verificado = false;

            var newstate = Symbol.Keyboard.KeyStates.KEYSTATE_NUMERIC_LOCK;
            Symbol.Keyboard.KeyPad teclado = new Symbol.Keyboard.KeyPad();
            teclado.SetKeyState(newstate, 0, true);

            if (((TextBox)sender).Text.Length == 9 && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
                return;
            }

            verificado = new Util.Mask().ApenasNumero(e.KeyChar, ref digitoSaida);

            if (verificado)
            {
                ((TextBox)sender).Text = ((TextBox)sender).Text + digitoSaida;
                ((TextBox)sender).SelectionStart = ((TextBox)sender).Text.Length;
                e.Handled = true;
            }
            else
            {
                if (e.KeyChar != Convert.ToChar(8))
                    e.Handled = true;
            }
        }

        private void Numero_GotFocus(object sender, EventArgs e)
        {
            var newstate = Symbol.Keyboard.KeyStates.KEYSTATE_NUMERIC_LOCK;
            Symbol.Keyboard.KeyPad teclado = new Symbol.Keyboard.KeyPad();
            teclado.SetKeyState(newstate, 0, true);
        }

        private void FocusOn()
        {
            #region [ ABA 1 ]

            txtAba1Nome.GotFocus += new EventHandler(Program.txtBox_focusOn);
            cmbAba1EstadoCivil.GotFocus += new EventHandler(Program.cmbBox_focusOn);
            cmbAba1Profissao.GotFocus += new EventHandler(Program.cmbBox_focusOn);
            cmbAba1DataNascimentoDia.GotFocus += new EventHandler(Program.cmbBox_focusOn);
            cmbAba1DataNascimentoMes.GotFocus += new EventHandler(Program.cmbBox_focusOn);
            cmbAba1DataNascimentoAno.GotFocus += new EventHandler(Program.cmbBox_focusOn);
            cmbAba1DataNascimentoDia.GotFocus += new EventHandler(Program.cmbBox_focusOn);
            cmbAba1DataNascimentoMes.GotFocus += new EventHandler(Program.cmbBox_focusOn);
            cmbAba1DataNascimentoAno.GotFocus += new EventHandler(Program.cmbBox_focusOn);
            cmbAba1ConjugeProfissao.GotFocus += new EventHandler(Program.cmbBox_focusOn);

            #endregion

            #region [ ABA 2 ]

            cmbAba2Sub1Grau.GotFocus += new EventHandler(Program.cmbBox_focusOn);
            txtAba2Sub1Idade.GotFocus += new EventHandler(Program.txtBox_focusOn);
            btnAba2Sub1Adicionar.GotFocus += new EventHandler(Program.btn_focusOn);
            btnAba2Sub1Remover.GotFocus += new EventHandler(Program.btn_focusOn);

            cmbAba2Sub2Renda.GotFocus += new EventHandler(Program.cmbBox_focusOn);

            txtAba2Sub3Outro.GotFocus += new EventHandler(Program.txtBox_focusOn);

            txtAba2Sub4Prepara.GotFocus += new EventHandler(Program.txtBox_focusOn);

            txtAba2Sub5JateveQual.GotFocus += new EventHandler(Program.txtBox_focusOn);

            #endregion

            #region [ ABA 3 ]

            txtAba3CPF.GotFocus += new EventHandler(Program.txtBox_focusOn);
            cmbAba3Sexo.GotFocus += new EventHandler(Program.cmbBox_focusOn);
            cmbAba3DataNascimentoDia.GotFocus += new EventHandler(Program.cmbBox_focusOn);
            cmbAba3DataNascimentoMes.GotFocus += new EventHandler(Program.cmbBox_focusOn);
            cmbAba3DataNascimentoAno.GotFocus += new EventHandler(Program.cmbBox_focusOn);
            txtAba3Telefone.GotFocus += new EventHandler(Program.txtBox_focusOn);
            txtAba3Celular.GotFocus += new EventHandler(Program.txtBox_focusOn);
            txtAba3Email.GotFocus += new EventHandler(Program.txtBox_focusOn);

            #endregion

            #region [ ABA 4 ]

            txtAba4CEPbox1.GotFocus += new EventHandler(Program.txtBox_focusOn);
            txtAba4CEPbox2.GotFocus += new EventHandler(Program.txtBox_focusOn);
            btnAba4CEP.GotFocus += new EventHandler(Program.btn_focusOn);
            txtAba4Endereco.GotFocus += new EventHandler(Program.txtBox_focusOn);
            txtAba4Bairro.GotFocus += new EventHandler(Program.txtBox_focusOn);
            txtAba4Numero.GotFocus += new EventHandler(Program.txtBox_focusOn);
            cmbAba4Complemento.GotFocus += new EventHandler(Program.cmbBox_focusOn);
            txtAba4Complemento.GotFocus += new EventHandler(Program.txtBox_focusOn);
            btnAba4ComplementoRm.GotFocus += new EventHandler(Program.btn_focusOn);
            btnAba4ComplementoAd.GotFocus += new EventHandler(Program.btn_focusOn);
            txtAba4Cidade.GotFocus += new EventHandler(Program.txtBox_focusOn);
            cmbAba4UF.GotFocus += new EventHandler(Program.cmbBox_focusOn);

            #endregion

            #region [ ABA 5 ]

            cmbAba5Sub1APMorte.GotFocus += new EventHandler(Program.cmbBox_focusOn);
            cmbAba5Sub1SeniorMorte.GotFocus += new EventHandler(Program.cmbBox_focusOn);
            cmbAba5Sub1CasalMorte.GotFocus += new EventHandler(Program.cmbBox_focusOn);
            cmbAba5Sub1APFuneral.GotFocus += new EventHandler(Program.cmbBox_focusOn);
            cmbAba5Sub1SeniorFuneral.GotFocus += new EventHandler(Program.cmbBox_focusOn);
            cmbAba5Sub1CasalFuneral.GotFocus += new EventHandler(Program.cmbBox_focusOn);
            btnAba5Sub1Voltar.GotFocus += new EventHandler(Program.btn_focusOn);
            btnAba5Sub1Salvar.GotFocus += new EventHandler(Program.btn_focusOn);

            cmbAba5Sub2Parentesco.GotFocus += new EventHandler(Program.cmbBox_focusOn);
            txtAba5Sub2Idade.GotFocus += new EventHandler(Program.txtBox_focusOn);
            btnAba5Sub2Remover.GotFocus += new EventHandler(Program.btn_focusOn);
            btnAba5Sub2Adicionar.GotFocus += new EventHandler(Program.btn_focusOn);
            btnAba5Sub2Voltar.GotFocus += new EventHandler(Program.btn_focusOn);
            btnAba5Sub2Salvar.GotFocus += new EventHandler(Program.btn_focusOn);

            cmbAba5Sub3Valor.GotFocus += new EventHandler(Program.cmbBox_focusOn);
            cmbAba5Sub3Periodo.GotFocus += new EventHandler(Program.cmbBox_focusOn);
            btnAba5Sub3Voltar.GotFocus += new EventHandler(Program.btn_focusOn);
            btnAba5Sub3Salvar.GotFocus += new EventHandler(Program.btn_focusOn);

            cmbAba5Sub4Produto.GotFocus += new EventHandler(Program.cmbBox_focusOn);
            btnAba5Sub4Produto.GotFocus += new EventHandler(Program.btn_focusOn);
            btnAba5Sub4DTProtecao.GotFocus += new EventHandler(Program.btn_focusOn);
            btnAba5Sub4DTSenior.GotFocus += new EventHandler(Program.btn_focusOn);
            btnAba5Sub4DTCasal.GotFocus += new EventHandler(Program.btn_focusOn);
            btnAba5Sub4DTAgregado.GotFocus += new EventHandler(Program.btn_focusOn);
            btnAba5Sub4DTRenda.GotFocus += new EventHandler(Program.btn_focusOn);

            cmbAba5Sub5Sub1Produto.GotFocus += new EventHandler(Program.cmbBox_focusOn);
            cmbAba5Sub5Sub1FaixaBase.GotFocus += new EventHandler(Program.cmbBox_focusOn);

            cmbAba5Sub5Sub2Morte.GotFocus += new EventHandler(Program.cmbBox_focusOn);
            cmbAba5Sub5Sub2Funeral.GotFocus += new EventHandler(Program.cmbBox_focusOn);

            cmbAba5Sub5Sub3Funeral.GotFocus += new EventHandler(Program.cmbBox_focusOn);
            cmbAba5Sub5Sub3Parentesco.GotFocus += new EventHandler(Program.cmbBox_focusOn);
            txtAba5Sub5Sub3Idade.GotFocus += new EventHandler(Program.txtBox_focusOn);
            btnAba5Sub5Sub3Adicionar.GotFocus += new EventHandler(Program.btn_focusOn);
            btnAba5Sub5Sub3Remover.GotFocus += new EventHandler(Program.btn_focusOn);

            cmbAba5Sub5Sub4Periodo.GotFocus += new EventHandler(Program.cmbBox_focusOn);
            cmbAba5Sub5Sub4Valor.GotFocus += new EventHandler(Program.cmbBox_focusOn);

            #endregion

            bntSair.GotFocus += new EventHandler(Program.btn_focusOn);
            btnSalvar.GotFocus += new EventHandler(Program.btn_focusOn);
            btnConcluir.GotFocus += new EventHandler(Program.btn_focusOn);
        }

        private void FocusOff()
        {
            #region [ ABA 1 ]

            txtAba1Nome.LostFocus += new EventHandler(Program.txtBox_focusOff);
            cmbAba1EstadoCivil.LostFocus += new EventHandler(Program.cmbBox_focusOff);
            cmbAba1Profissao.LostFocus += new EventHandler(Program.cmbBox_focusOff);
            cmbAba1DataNascimentoDia.LostFocus += new EventHandler(Program.cmbBox_focusOff);
            cmbAba1DataNascimentoMes.LostFocus += new EventHandler(Program.cmbBox_focusOff);
            cmbAba1DataNascimentoAno.LostFocus += new EventHandler(Program.cmbBox_focusOff);
            cmbAba1DataNascimentoDia.LostFocus += new EventHandler(Program.cmbBox_focusOff);
            cmbAba1DataNascimentoMes.LostFocus += new EventHandler(Program.cmbBox_focusOff);
            cmbAba1DataNascimentoAno.LostFocus += new EventHandler(Program.cmbBox_focusOff);
            cmbAba1ConjugeProfissao.LostFocus += new EventHandler(Program.cmbBox_focusOff);

            #endregion

            #region [ ABA 2 ]

            cmbAba2Sub1Grau.LostFocus += new EventHandler(Program.cmbBox_focusOff);
            txtAba2Sub1Idade.LostFocus += new EventHandler(Program.txtBox_focusOff);
            btnAba2Sub1Adicionar.LostFocus += new EventHandler(Program.btn_focusOffWhite);
            btnAba2Sub1Remover.LostFocus += new EventHandler(Program.btn_focusOffWhite);

            cmbAba2Sub2Renda.LostFocus += new EventHandler(Program.cmbBox_focusOff);

            txtAba2Sub3Outro.LostFocus += new EventHandler(Program.txtBox_focusOff);

            txtAba2Sub4Prepara.LostFocus += new EventHandler(Program.txtBox_focusOff);

            txtAba2Sub5JateveQual.LostFocus += new EventHandler(Program.txtBox_focusOff);

            #endregion

            #region [ ABA 3 ]

            txtAba3CPF.LostFocus += new EventHandler(Program.txtBox_focusOff);
            cmbAba3Sexo.LostFocus += new EventHandler(Program.cmbBox_focusOff);
            cmbAba3DataNascimentoDia.LostFocus += new EventHandler(Program.cmbBox_focusOff);
            cmbAba3DataNascimentoMes.LostFocus += new EventHandler(Program.cmbBox_focusOff);
            cmbAba3DataNascimentoAno.LostFocus += new EventHandler(Program.cmbBox_focusOff);
            txtAba3Telefone.LostFocus += new EventHandler(Program.txtBox_focusOff);
            txtAba3Celular.LostFocus += new EventHandler(Program.txtBox_focusOff);
            txtAba3Email.LostFocus += new EventHandler(Program.txtBox_focusOff);

            #endregion

            #region [ ABA 4 ]

            txtAba4CEPbox1.LostFocus += new EventHandler(Program.txtBox_focusOff);
            txtAba4CEPbox2.LostFocus += new EventHandler(Program.txtBox_focusOff);
            btnAba4CEP.LostFocus += new EventHandler(Program.btn_focusOffWhite);
            txtAba4Endereco.LostFocus += new EventHandler(Program.txtBox_focusOff);
            txtAba4Bairro.LostFocus += new EventHandler(Program.txtBox_focusOff);
            txtAba4Numero.LostFocus += new EventHandler(Program.txtBox_focusOff);
            cmbAba4Complemento.LostFocus += new EventHandler(Program.cmbBox_focusOff);
            txtAba4Complemento.LostFocus += new EventHandler(Program.txtBox_focusOff);
            btnAba4ComplementoRm.LostFocus += new EventHandler(Program.btn_focusOffWhite);
            btnAba4ComplementoAd.LostFocus += new EventHandler(Program.btn_focusOffWhite);
            txtAba4Cidade.LostFocus += new EventHandler(Program.txtBox_focusOff);
            cmbAba4UF.LostFocus += new EventHandler(Program.cmbBox_focusOff);

            #endregion

            #region [ ABA 5 ]

            cmbAba5Sub1APMorte.LostFocus += new EventHandler(Program.cmbBox_focusOff);
            cmbAba5Sub1SeniorMorte.LostFocus += new EventHandler(Program.cmbBox_focusOff);
            cmbAba5Sub1CasalMorte.LostFocus += new EventHandler(Program.cmbBox_focusOff);
            cmbAba5Sub1APFuneral.LostFocus += new EventHandler(Program.cmbBox_focusOff);
            cmbAba5Sub1SeniorFuneral.LostFocus += new EventHandler(Program.cmbBox_focusOff);
            cmbAba5Sub1CasalFuneral.LostFocus += new EventHandler(Program.cmbBox_focusOff);
            btnAba5Sub1Voltar.LostFocus += new EventHandler(Program.btn_focusOffWhite);
            btnAba5Sub1Salvar.LostFocus += new EventHandler(Program.btn_focusOffWhite);

            cmbAba5Sub2Parentesco.LostFocus += new EventHandler(Program.cmbBox_focusOff);
            txtAba5Sub2Idade.LostFocus += new EventHandler(Program.txtBox_focusOff);
            btnAba5Sub2Remover.LostFocus += new EventHandler(Program.btn_focusOffWhite);
            btnAba5Sub2Adicionar.LostFocus += new EventHandler(Program.btn_focusOffWhite);
            btnAba5Sub2Voltar.LostFocus += new EventHandler(Program.btn_focusOffWhite);
            btnAba5Sub2Salvar.LostFocus += new EventHandler(Program.btn_focusOffWhite);

            cmbAba5Sub3Valor.LostFocus += new EventHandler(Program.cmbBox_focusOff);
            cmbAba5Sub3Periodo.LostFocus += new EventHandler(Program.cmbBox_focusOff);
            btnAba5Sub3Voltar.LostFocus += new EventHandler(Program.btn_focusOffWhite);
            btnAba5Sub3Salvar.LostFocus += new EventHandler(Program.btn_focusOffWhite);

            cmbAba5Sub4Produto.LostFocus += new EventHandler(Program.cmbBox_focusOff);
            btnAba5Sub4Produto.LostFocus += new EventHandler(Program.btn_focusOffWhite);
            btnAba5Sub4DTProtecao.LostFocus += new EventHandler(Program.btn_focusOffWhite);
            btnAba5Sub4DTSenior.LostFocus += new EventHandler(Program.btn_focusOffWhite);
            btnAba5Sub4DTCasal.LostFocus += new EventHandler(Program.btn_focusOffWhite);
            btnAba5Sub4DTAgregado.LostFocus += new EventHandler(Program.btn_focusOffWhite);
            btnAba5Sub4DTRenda.LostFocus += new EventHandler(Program.btn_focusOffWhite);

            cmbAba5Sub5Sub1Produto.LostFocus += new EventHandler(Program.cmbBox_focusOff);
            cmbAba5Sub5Sub1FaixaBase.LostFocus += new EventHandler(Program.cmbBox_focusOff);

            cmbAba5Sub5Sub2Morte.LostFocus += new EventHandler(Program.cmbBox_focusOff);
            cmbAba5Sub5Sub2Funeral.LostFocus += new EventHandler(Program.cmbBox_focusOff);

            cmbAba5Sub5Sub3Funeral.LostFocus += new EventHandler(Program.cmbBox_focusOff);
            cmbAba5Sub5Sub3Parentesco.LostFocus += new EventHandler(Program.cmbBox_focusOff);
            txtAba5Sub5Sub3Idade.LostFocus += new EventHandler(Program.txtBox_focusOff);
            btnAba5Sub5Sub3Adicionar.LostFocus += new EventHandler(Program.btn_focusOffWhite);
            btnAba5Sub5Sub3Remover.LostFocus += new EventHandler(Program.btn_focusOffWhite);

            cmbAba5Sub5Sub4Periodo.LostFocus += new EventHandler(Program.cmbBox_focusOff);
            cmbAba5Sub5Sub4Valor.LostFocus += new EventHandler(Program.cmbBox_focusOff);

            #endregion

            bntSair.LostFocus += new EventHandler(Program.btn_focusOffAzul);
            btnSalvar.LostFocus += new EventHandler(Program.btn_focusOffAzul);
            btnConcluir.LostFocus += new EventHandler(Program.btn_focusOffAzul);
        }

        private void KeyDownTecla()
        {
            //Only button and check

            #region [ ABA 2 ]

            chkAba2Sub1Nao.KeyDown += new KeyEventHandler(Program.chkBox_enter);
            chkAba2Sub1Sim.KeyDown += new KeyEventHandler(Program.chkBox_enter);
            btnAba2Sub1Adicionar.KeyDown += new KeyEventHandler(Program.btn_enter);
            btnAba2Sub1Remover.KeyDown += new KeyEventHandler(Program.btn_enter);

            chkAba2Sub3Outro.KeyDown += new KeyEventHandler(Program.chkBox_enter);

            chkAba2Sub3Nada.KeyDown += new KeyEventHandler(Program.chkBox_enter);
            chkAba2Sub3Casa.KeyDown += new KeyEventHandler(Program.chkBox_enter);
            chkAba2Sub3Junta.KeyDown += new KeyEventHandler(Program.chkBox_enter);
            chkAba2Sub4NaoPrepara.KeyDown += new KeyEventHandler(Program.chkBox_enter);

            chkAba2Sub5Nao.KeyDown += new KeyEventHandler(Program.chkBox_enter);
            chkAba2Sub5Sim.KeyDown += new KeyEventHandler(Program.chkBox_enter);
            chkAba2Sub5Jateve.KeyDown += new KeyEventHandler(Program.chkBox_enter);
            chkAba2Sub5Tem.KeyDown += new KeyEventHandler(Program.chkBox_enter);
            chkAba2Sub5Nunca.KeyDown += new KeyEventHandler(Program.chkBox_enter);

            chkAba2Sub6Sim.KeyDown += new KeyEventHandler(Program.chkBox_enter);
            chkAba2Sub6Nao.KeyDown += new KeyEventHandler(Program.chkBox_enter);

            chkAba2Sub7v15.KeyDown += new KeyEventHandler(Program.chkBox_enter);
            chkAba2Sub7v20.KeyDown += new KeyEventHandler(Program.chkBox_enter);
            chkAba2Sub7v25.KeyDown += new KeyEventHandler(Program.chkBox_enter);
            chkAba2Sub7v30.KeyDown += new KeyEventHandler(Program.chkBox_enter);
            chkAba2Sub7v35.KeyDown += new KeyEventHandler(Program.chkBox_enter);
            chkAba2Sub7v45.KeyDown += new KeyEventHandler(Program.chkBox_enter);
            chkAba2Sub7v55.KeyDown += new KeyEventHandler(Program.chkBox_enter);
            chkAba2Sub7v65.KeyDown += new KeyEventHandler(Program.chkBox_enter);
            chkAba2Sub7v75.KeyDown += new KeyEventHandler(Program.chkBox_enter);
            chkAba2Sub7v90.KeyDown += new KeyEventHandler(Program.chkBox_enter);
            chkAba2Sub7v110.KeyDown += new KeyEventHandler(Program.chkBox_enter);

            #endregion

            #region [ ABA 4 ]

            btnAba4CEP.KeyDown += new KeyEventHandler(Program.btn_enter);
            btnAba4ComplementoRm.KeyDown += new KeyEventHandler(Program.btn_enter);
            btnAba4ComplementoAd.KeyDown += new KeyEventHandler(Program.btn_enter);

            #endregion

            #region [ ABA 5 ]

            btnAba5Sub1Voltar.KeyDown += new KeyEventHandler(Program.btn_enter);
            btnAba5Sub1Salvar.KeyDown += new KeyEventHandler(Program.btn_enter);

            btnAba5Sub2Remover.KeyDown += new KeyEventHandler(Program.btn_enter);
            btnAba5Sub2Adicionar.KeyDown += new KeyEventHandler(Program.btn_enter);
            btnAba5Sub2Voltar.KeyDown += new KeyEventHandler(Program.btn_enter);
            btnAba5Sub2Salvar.KeyDown += new KeyEventHandler(Program.btn_enter);

            btnAba5Sub3Voltar.KeyDown += new KeyEventHandler(Program.btn_enter);
            btnAba5Sub3Salvar.KeyDown += new KeyEventHandler(Program.btn_enter);

            btnAba5Sub4Produto.KeyDown += new KeyEventHandler(Program.btn_enter);
            btnAba5Sub4DTProtecao.KeyDown += new KeyEventHandler(Program.btn_enter);
            btnAba5Sub4DTSenior.KeyDown += new KeyEventHandler(Program.btn_enter);
            btnAba5Sub4DTCasal.KeyDown += new KeyEventHandler(Program.btn_enter);
            btnAba5Sub4DTAgregado.KeyDown += new KeyEventHandler(Program.btn_enter);
            btnAba5Sub4DTRenda.KeyDown += new KeyEventHandler(Program.btn_enter);

            btnAba5Sub5Sub3Adicionar.KeyDown += new KeyEventHandler(Program.btn_enter);
            btnAba5Sub5Sub3Remover.KeyDown += new KeyEventHandler(Program.btn_enter);

            #endregion

            bntSair.KeyDown += new KeyEventHandler(Program.btn_enter);
            btnSalvar.KeyDown += new KeyEventHandler(Program.btn_enter);
            btnConcluir.KeyDown += new KeyEventHandler(Program.btn_enter);

        }

        private void KeyUpTecla()
        {
            #region [ ABA 1 ]

            txtAba1Nome.KeyUp += new KeyEventHandler(Program.txtBox_next);
            cmbAba1EstadoCivil.KeyUp += new KeyEventHandler(Program.cmbBox_next);
            cmbAba1Profissao.KeyUp += new KeyEventHandler(cmbAba1Profissao_KeyUp);
            cmbAba1DataNascimentoDia.KeyUp += new KeyEventHandler(Program.cmbBox_next);
            cmbAba1DataNascimentoMes.KeyUp += new KeyEventHandler(Program.cmbBox_next);
            cmbAba1DataNascimentoAno.KeyUp += new KeyEventHandler(Program.cmbBox_next);
            cmbAba1DataNascimentoDia.KeyUp += new KeyEventHandler(Program.cmbBox_next);
            cmbAba1DataNascimentoMes.KeyUp += new KeyEventHandler(Program.cmbBox_next);
            cmbAba1DataNascimentoAno.KeyUp += new KeyEventHandler(Program.cmbBox_next);
            cmbAba1ConjugeProfissao.KeyUp += new KeyEventHandler(cmbAba1ConjugeProfissao_KeyUp);

            #endregion

            #region [ ABA 2 ]

            cmbAba2Sub1Grau.KeyUp += new KeyEventHandler(Program.cmbBox_next);
            chkAba2Sub1Nao.KeyUp += new KeyEventHandler(Program.chkBox_next);
            chkAba2Sub1Sim.KeyUp += new KeyEventHandler(Program.chkBox_next);
            txtAba2Sub1Idade.KeyUp += new KeyEventHandler(Program.txtBox_next);
            btnAba2Sub1Adicionar.KeyUp += new KeyEventHandler(Program.btn_next);
            btnAba2Sub1Remover.KeyUp += new KeyEventHandler(btnAba2Sub1Remover_KeyUp);

            cmbAba2Sub2Renda.KeyUp += new KeyEventHandler(cmbAba2Sub2Renda_KeyUp);

            txtAba2Sub3Outro.KeyUp += new KeyEventHandler(txtAba2Sub3Outro_KeyUp);
            chkAba2Sub3Outro.KeyUp += new KeyEventHandler(chkAba2Sub3Outro_KeyUp);

            chkAba2Sub3Nada.KeyUp += new KeyEventHandler(Program.chkBox_next);
            chkAba2Sub3Casa.KeyUp += new KeyEventHandler(Program.chkBox_next);
            chkAba2Sub3Junta.KeyUp += new KeyEventHandler(Program.chkBox_next);
            txtAba2Sub4Prepara.KeyUp += new KeyEventHandler(txtAba2Sub4Prepara_KeyUp);
            chkAba2Sub4NaoPrepara.KeyUp += new KeyEventHandler(chkAba2Sub4NaoPrepara_KeyUp);

            chkAba2Sub5Nao.KeyUp += new KeyEventHandler(Program.chkBox_next);
            chkAba2Sub5Sim.KeyUp += new KeyEventHandler(Program.chkBox_next);
            chkAba2Sub5Jateve.KeyUp += new KeyEventHandler(Program.chkBox_next);
            chkAba2Sub5Tem.KeyUp += new KeyEventHandler(Program.chkBox_next);
            chkAba2Sub5Nunca.KeyUp += new KeyEventHandler(chkAba2Sub5Nunca_KeyUp);
            txtAba2Sub5JateveQual.KeyUp += new KeyEventHandler(txtAba2Sub5JateveQual_KeyUp);

            chkAba2Sub6Sim.KeyUp += new KeyEventHandler(Program.chkBox_next);
            chkAba2Sub6Nao.KeyUp += new KeyEventHandler(chkAba2Sub6Nao_KeyUp);

            chkAba2Sub7v15.KeyUp += new KeyEventHandler(Program.chkBox_next);
            chkAba2Sub7v20.KeyUp += new KeyEventHandler(Program.chkBox_next);
            chkAba2Sub7v25.KeyUp += new KeyEventHandler(Program.chkBox_next);
            chkAba2Sub7v30.KeyUp += new KeyEventHandler(Program.chkBox_next);
            chkAba2Sub7v35.KeyUp += new KeyEventHandler(Program.chkBox_next);
            chkAba2Sub7v45.KeyUp += new KeyEventHandler(Program.chkBox_next);
            chkAba2Sub7v55.KeyUp += new KeyEventHandler(Program.chkBox_next);
            chkAba2Sub7v65.KeyUp += new KeyEventHandler(Program.chkBox_next);
            chkAba2Sub7v75.KeyUp += new KeyEventHandler(Program.chkBox_next);
            chkAba2Sub7v90.KeyUp += new KeyEventHandler(Program.chkBox_next);
            chkAba2Sub7v110.KeyUp += new KeyEventHandler(chkAba2Sub7v110_KeyUp);

            #endregion

            #region [ ABA 3 ]

            txtAba3CPF.KeyUp += new KeyEventHandler(Program.txtBox_next);
            cmbAba3Sexo.KeyUp += new KeyEventHandler(Program.cmbBox_next);
            cmbAba3DataNascimentoDia.KeyUp += new KeyEventHandler(Program.cmbBox_next);
            cmbAba3DataNascimentoMes.KeyUp += new KeyEventHandler(Program.cmbBox_next);
            cmbAba3DataNascimentoAno.KeyUp += new KeyEventHandler(Program.cmbBox_next);
            txtAba3Telefone.KeyUp += new KeyEventHandler(Program.txtBox_next);
            txtAba3Celular.KeyUp += new KeyEventHandler(Program.txtBox_next);
            txtAba3Email.KeyUp += new KeyEventHandler(txtAba3Email_KeyUp);

            #endregion

            #region [ ABA 4 ]

            txtAba4CEPbox1.KeyUp += new KeyEventHandler(Program.txtBox_next);
            txtAba4CEPbox2.KeyUp += new KeyEventHandler(Program.txtBox_next);
            btnAba4CEP.KeyUp += new KeyEventHandler(Program.btn_next);
            txtAba4Endereco.KeyUp += new KeyEventHandler(Program.txtBox_next);
            txtAba4Bairro.KeyUp += new KeyEventHandler(Program.txtBox_next);
            txtAba4Numero.KeyUp += new KeyEventHandler(Program.txtBox_next);
            cmbAba4Complemento.KeyUp += new KeyEventHandler(Program.cmbBox_next);
            txtAba4Complemento.KeyUp += new KeyEventHandler(Program.txtBox_next);
            btnAba4ComplementoRm.KeyUp += new KeyEventHandler(Program.btn_next);
            btnAba4ComplementoAd.KeyUp += new KeyEventHandler(Program.btn_next);
            txtAba4Cidade.KeyUp += new KeyEventHandler(Program.txtBox_next);
            cmbAba4UF.KeyUp += new KeyEventHandler(cmbAba4UF_KeyUp);

            #endregion

            #region [ ABA 5 ]

            cmbAba5Sub1APMorte.KeyUp += new KeyEventHandler(Program.cmbBox_next);
            cmbAba5Sub1SeniorMorte.KeyUp += new KeyEventHandler(Program.cmbBox_next);
            cmbAba5Sub1CasalMorte.KeyUp += new KeyEventHandler(Program.cmbBox_next);
            cmbAba5Sub1APFuneral.KeyUp += new KeyEventHandler(cmbAba5Sub1APFuneral_KeyUp);
            cmbAba5Sub1SeniorFuneral.KeyUp += new KeyEventHandler(cmbAba5Sub1SeniorFuneral_KeyUp);
            cmbAba5Sub1CasalFuneral.KeyUp += new KeyEventHandler(cmbAba5Sub1CasalFuneral_KeyUp);
            btnAba5Sub1Voltar.KeyUp += new KeyEventHandler(Program.btn_next);
            btnAba5Sub1Salvar.KeyUp += new KeyEventHandler(btnAba5Sub1Salvar_KeyUp);

            cmbAba5Sub2Parentesco.KeyUp += new KeyEventHandler(Program.cmbBox_next);
            txtAba5Sub2Idade.KeyUp += new KeyEventHandler(Program.txtBox_next);
            btnAba5Sub2Remover.KeyUp += new KeyEventHandler(Program.btn_next);
            btnAba5Sub2Adicionar.KeyUp += new KeyEventHandler(Program.btn_next);
            btnAba5Sub2Voltar.KeyUp += new KeyEventHandler(Program.btn_next);
            btnAba5Sub2Salvar.KeyUp += new KeyEventHandler(btnAba5Sub2Salvar_KeyUp);

            cmbAba5Sub3Valor.KeyUp += new KeyEventHandler(Program.cmbBox_next);
            cmbAba5Sub3Periodo.KeyUp += new KeyEventHandler(Program.cmbBox_next);
            btnAba5Sub3Voltar.KeyUp += new KeyEventHandler(Program.btn_next);
            btnAba5Sub3Salvar.KeyUp += new KeyEventHandler(btnAba5Sub3Salvar_KeyUp);

            cmbAba5Sub4Produto.KeyUp += new KeyEventHandler(Program.cmbBox_next);
            btnAba5Sub4Produto.KeyUp += new KeyEventHandler(btnAba5Sub4Produto_KeyUp);
            btnAba5Sub4DTProtecao.KeyUp += new KeyEventHandler(btnAba5Sub4DTProtecao_KeyUp);
            btnAba5Sub4DTSenior.KeyUp += new KeyEventHandler(btnAba5Sub4DTSenior_KeyUp);
            btnAba5Sub4DTCasal.KeyUp += new KeyEventHandler(btnAba5Sub4DTCasal_KeyUp);
            btnAba5Sub4DTAgregado.KeyUp += new KeyEventHandler(btnAba5Sub4DTAgregado_KeyUp);
            btnAba5Sub4DTRenda.KeyUp += new KeyEventHandler(btnAba5Sub4DTRenda_KeyUp);

            cmbAba5Sub5Sub1Produto.KeyUp += new KeyEventHandler(Program.cmbBox_next);
            cmbAba5Sub5Sub1FaixaBase.KeyUp += new KeyEventHandler(cmbAba5Sub5Sub1FaixaBase_KeyUp);

            cmbAba5Sub5Sub2Morte.KeyUp += new KeyEventHandler(Program.cmbBox_next);
            cmbAba5Sub5Sub2Funeral.KeyUp += new KeyEventHandler(cmbAba5Sub5Sub2Funeral_KeyUp);

            cmbAba5Sub5Sub3Funeral.KeyUp += new KeyEventHandler(Program.cmbBox_next);
            cmbAba5Sub5Sub3Parentesco.KeyUp += new KeyEventHandler(Program.cmbBox_next);
            txtAba5Sub5Sub3Idade.KeyUp += new KeyEventHandler(Program.txtBox_next);
            btnAba5Sub5Sub3Adicionar.KeyUp += new KeyEventHandler(Program.btn_next);
            btnAba5Sub5Sub3Remover.KeyUp += new KeyEventHandler(btnAba5Sub5Sub3Remover_KeyUp);

            cmbAba5Sub5Sub4Periodo.KeyUp += new KeyEventHandler(Program.cmbBox_next);
            cmbAba5Sub5Sub4Valor.KeyUp += new KeyEventHandler(cmbAba5Sub5Sub4Valor_KeyUp);

            #endregion

            bntSair.KeyUp += new KeyEventHandler(Program.btn_next);
            btnSalvar.KeyUp += new KeyEventHandler(Program.btn_next);
            btnConcluir.KeyUp += new KeyEventHandler(Program.btn_next);

        }

        #endregion

        #region [ BUTTONS ]

        private void bntSair_Click(object sender, EventArgs e)
        {
            Program.CodigoEntrevista = 0;
            this.Close();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                Util.MostraCursor.CursorAguarde(true);

                MapearCamposPrincipal();

                switch (tabEntrevista.SelectedIndex)
                {
                    case 0:
                        if (SalvarAbaPessoal())
                            AcertarFocuCampos();
                        break;
                    case 1:
                        if (SalvarAbaFormulario())
                            AcertarFocuCampos();
                        break;
                    case 2:
                        if (SalvarAbaDados())
                            AcertarFocuCampos();
                        break;
                    case 3:
                        if (SalvarAbaEndereco())
                            AcertarFocuCampos();
                        break;
                    case 4:
                            SalvarAbaSimulador();
                            AcertarFocuCampos();
                        break;
                    default:
                        break;
                }

                Program.CodigoEntrevista = DadosTEntrevista.CodigoEntrevista;

                Util.MostraCursor.CursorAguarde(false);

            }
            catch (Exception ex)
            {
                Util.MostraCursor.CursorAguarde(false);
                Util.LogErro.GravaLog("Erro ao salvar o formulário.", ex.Message);
            }
        }

        private void btnConcluir_Click(object sender, EventArgs e)
        {
            try
            {
                Util.MostraCursor.CursorAguarde(true);

                MapearCamposPrincipal();

                Program.CodigoEntrevista = DadosTEntrevista.CodigoEntrevista;

                Util.CaixaMensagem.ExibirOk("Número Entrevista: " + Program.CodigoEntrevista.ToString());
                Util.MostraCursor.CursorAguarde(true);

                switch (tabEntrevista.SelectedIndex)
                {
                    case 0:
                        if (SalvarAbaPessoal())
                            if (SalvarAbaFormulario())
                                if (SalvarAbaDados())
                                    if (SalvarAbaEndereco())
                                    {
                                        finalizarEntrevista(true);
                                    }
                        break;
                    case 1:
                        if (SalvarAbaFormulario())
                            if (SalvarAbaDados())
                                if (SalvarAbaEndereco())
                                {
                                    finalizarEntrevista(true);
                                }
                        break;
                    case 2:
                        if (SalvarAbaDados())
                            if (SalvarAbaEndereco())
                            {
                                finalizarEntrevista(true);
                            }
                        break;
                    case 3:
                        if (SalvarAbaEndereco())
                        {
                            finalizarEntrevista(true);
                        }
                        break;
                    case 4:
                        //Alteração para exibir o número de entrevista antes de salvar os dados do simulador
                        //Mesmo se der erro ao salvar manda para a tela feedback
                        try
                        {
                            finalizarEntrevista(false);
                        }
                        catch
                        {
                            Program.TrocaForm<frmFeedBackAlterado>();
                            this.Tag = false;
                            this.Close();
                        }

                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Util.MostraCursor.CursorAguarde(false);
                Util.LogErro.GravaLog("Erro ao salvar o formulário.", ex.Message);
            }
            finally
            {
                Util.MostraCursor.CursorAguarde(false);
            }
        }

        private void tabEntrevista_SelectedIndexChanged(object sender, EventArgs e)
        {
            Util.MostraCursor.CursorAguarde(true);

            if (!Program.RegistroAntigo)
            {
                if (AbaAnterior < tabEntrevista.SelectedIndex)
                {
                    switch (AbaAnterior)
                    {
                        case 0:
                            MapearCamposPrincipal();
                            if (SalvarAbaPessoal())
                                AcertarFocuCampos();
                            break;
                        case 1:
                            if (SalvarAbaFormulario())
                                AcertarFocuCampos();
                            break;
                        case 2:
                            if (SalvarAbaDados())
                                AcertarFocuCampos();
                            break;
                        case 3:
                            if (SalvarAbaEndereco())
                                AcertarFocuCampos();
                            break;
                        case 4:
                            AcertarFocuCampos();
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    AcertarFocuCampos();
                }
            }
            Util.MostraCursor.CursorAguarde(false);
        }

        private void frmEntrevista_Closed(object sender, EventArgs e)
        {
            this.barraInferior1.Dispose();
            this.barraSuperior1.Dispose();
        }

        private void finalizarEntrevista(bool popularSimulador)
        {
            try
            {
                if (popularSimulador)
                    PopularSimulador();

                SalvarAbaSimulador();

                Program.TrocaForm<frmFeedBackAlterado>();
                this.Tag = false;
                this.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
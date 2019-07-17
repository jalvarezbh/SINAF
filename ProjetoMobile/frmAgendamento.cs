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
    public partial class frmAgendamento : Form
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

        private DataTable _dadosCmbAba1DataNascimentoDia;
        public DataTable DadosCmbAba1DataNascimentoDia
        {
            get { return _dadosCmbAba1DataNascimentoDia; }
            set { _dadosCmbAba1DataNascimentoDia = value; }
        }

        private string _textoCmbAba1DataNascimentoDia;
        public string TextoCmbAba1DataNascimentoDia
        {
            get { return _textoCmbAba1DataNascimentoDia; }
            set { _textoCmbAba1DataNascimentoDia = value; }
        }

        private DataTable _dadosCmbAba1DataNascimentoMes;
        public DataTable DadosCmbAba1DataNascimentoMes
        {
            get { return _dadosCmbAba1DataNascimentoMes; }
            set { _dadosCmbAba1DataNascimentoMes = value; }
        }

        private string _textoCmbAba1DataNascimentoMes;
        public string TextoCmbAba1DataNascimentoMes
        {
            get { return _textoCmbAba1DataNascimentoMes; }
            set { _textoCmbAba1DataNascimentoMes = value; }
        }

        private DataTable _dadosCmbAba1DataNascimentoAno;
        public DataTable DadosCmbAba1DataNascimentoAno
        {
            get { return _dadosCmbAba1DataNascimentoAno; }
            set { _dadosCmbAba1DataNascimentoAno = value; }
        }

        private string _textoCmbAba1DataNascimentoAno;
        public string TextoCmbAba1DataNascimentoAno
        {
            get { return _textoCmbAba1DataNascimentoAno; }
            set { _textoCmbAba1DataNascimentoAno = value; }
        }

        private DataTable _dadosCmbAba2Complemento;
        public DataTable DadosCmbAba2Complemento
        {
            get { return _dadosCmbAba2Complemento; }
            set { _dadosCmbAba2Complemento = value; }
        }

        private string _textoCmbAba2Complemento;
        public string TextoCmbAba2Complemento
        {
            get { return _textoCmbAba2Complemento; }
            set { _textoCmbAba2Complemento = value; }
        }

        private DataTable _dadosCmbAba2UF;
        public DataTable DadosCmbAba2UF
        {
            get { return _dadosCmbAba2UF; }
            set { _dadosCmbAba2UF = value; }
        }

        private string _textoCmbAba2UF;
        public string TextoCmbAba2UF
        {
            get { return _textoCmbAba2UF; }
            set { _textoCmbAba2UF = value; }
        }

        private DataTable _dadosCmbAba3DataAgendadaDia;
        public DataTable DadosCmbAba3DataAgendadaDia
        {
            get { return _dadosCmbAba3DataAgendadaDia; }
            set { _dadosCmbAba3DataAgendadaDia = value; }
        }

        private string _textoCmbAba3DataAgendadaDia;
        public string TextoCmbAba3DataAgendadaDia
        {
            get { return _textoCmbAba3DataAgendadaDia; }
            set { _textoCmbAba3DataAgendadaDia = value; }
        }

        private DataTable _dadosCmbAba3DataAgendadaMes;
        public DataTable DadosCmbAba3DataAgendadaMes
        {
            get { return _dadosCmbAba3DataAgendadaMes; }
            set { _dadosCmbAba3DataAgendadaMes = value; }
        }

        private string _textoCmbAba3DataAgendadaMes;
        public string TextoCmbAba3DataAgendadaMes
        {
            get { return _textoCmbAba3DataAgendadaMes; }
            set { _textoCmbAba3DataAgendadaMes = value; }
        }

        private DataTable _dadosCmbAba3DataAgendadaAno;
        public DataTable DadosCmbAba3DataAgendadaAno
        {
            get { return _dadosCmbAba3DataAgendadaAno; }
            set { _dadosCmbAba3DataAgendadaAno = value; }
        }

        private string _textoCmbAba3DataAgendadaAno;
        public string TextoCmbAba3DataAgendadaAno
        {
            get { return _textoCmbAba3DataAgendadaAno; }
            set { _textoCmbAba3DataAgendadaAno = value; }
        }

        private DataTable _dadosCmbAba3HoraAgendadaHora;
        public DataTable DadosCmbAba3HoraAgendadaHora
        {
            get { return _dadosCmbAba3HoraAgendadaHora; }
            set { _dadosCmbAba3HoraAgendadaHora = value; }
        }

        private string _textoCmbAba3HoraAgendadaHora;
        public string TextoCmbAba3HoraAgendadaHora
        {
            get { return _textoCmbAba3HoraAgendadaHora; }
            set { _textoCmbAba3HoraAgendadaHora = value; }
        }

        private DataTable _dadosCmbAba3HoraAgendadaMinuto;
        public DataTable DadosCmbAba3HoraAgendadaMinuto
        {
            get { return _dadosCmbAba3HoraAgendadaMinuto; }
            set { _dadosCmbAba3HoraAgendadaMinuto = value; }
        }

        private string _textoCmbAba3HoraAgendadaMinuto;
        public string TextoCmbAba3HoraAgendadaMinuto
        {
            get { return _textoCmbAba3HoraAgendadaMinuto; }
            set { _textoCmbAba3HoraAgendadaMinuto = value; }
        }

        private int _abaAnterior;
        public int AbaAnterior
        {
            get { return _abaAnterior; }
            set { _abaAnterior = value; }
        }

        #endregion

        #region [ LOAD ]

        public frmAgendamento()
        {
            InitializeComponent();

            txtAba1Nome.Focus();

            FocusOn();
            FocusOff();
            KeyDownTecla();
            KeyUpTecla();

            PopularCombos();

            if (Program.IDAgendamento > 0)
            {
                PreencheCamposTAgendamento();
                btnExcluir.Visible = true;
            }
        }

        #endregion

        #region [ RECOVER ]

        private void PopularCombos()
        {
            cmbAba1DataNascimentoDia.DisplayMember = "Value";
            cmbAba1DataNascimentoDia.ValueMember = "Key";
            cmbAba1DataNascimentoDia.DataSource = ControllerEnum.ListaDeDiaData(0);
            DadosCmbAba1DataNascimentoDia = ControllerEnum.ListaDeDiaData(0);
            TextoCmbAba1DataNascimentoDia = string.Empty;

            cmbAba1DataNascimentoMes.DisplayMember = "Value";
            cmbAba1DataNascimentoMes.ValueMember = "Key";
            cmbAba1DataNascimentoMes.DataSource = ControllerEnum.ListaDeMesData();
            DadosCmbAba1DataNascimentoMes = ControllerEnum.ListaDeMesData();
            TextoCmbAba1DataNascimentoMes = string.Empty;

            cmbAba1DataNascimentoAno.DisplayMember = "Value";
            cmbAba1DataNascimentoAno.ValueMember = "Key";
            cmbAba1DataNascimentoAno.DataSource = ControllerEnum.ListaDeAnoDataNascimento(true);
            DadosCmbAba1DataNascimentoAno = ControllerEnum.ListaDeAnoDataNascimento(true);
            TextoCmbAba1DataNascimentoAno = string.Empty;

            cmbAba2Complemento.DisplayMember = "Value";
            cmbAba2Complemento.ValueMember = "Key";
            cmbAba2Complemento.DataSource = ControllerEnum.ListaDeComplemento();
            DadosCmbAba2Complemento = ControllerEnum.ListaDeComplemento();
            TextoCmbAba2Complemento = string.Empty;

            cmbAba2UF.DisplayMember = "Sigla";
            cmbAba2UF.ValueMember = "IDEstado";
            cmbAba2UF.DataSource = ControllerEstado.ListaDeEstado();
            DadosCmbAba2UF = ControllerEstado.ListaDeEstado();
            TextoCmbAba2UF = string.Empty;

            cmbAba3DataAgendadaDia.DisplayMember = "Value";
            cmbAba3DataAgendadaDia.ValueMember = "Key";
            cmbAba3DataAgendadaDia.DataSource = ControllerEnum.ListaDeDiaData(0);
            DadosCmbAba3DataAgendadaDia = ControllerEnum.ListaDeDiaData(0);
            TextoCmbAba3DataAgendadaDia = string.Empty;

            cmbAba3DataAgendadaMes.DisplayMember = "Value";
            cmbAba3DataAgendadaMes.ValueMember = "Key";
            cmbAba3DataAgendadaMes.DataSource = ControllerEnum.ListaDeMesData();
            DadosCmbAba3DataAgendadaMes = ControllerEnum.ListaDeMesData();
            TextoCmbAba3DataAgendadaMes = string.Empty;

            cmbAba3DataAgendadaAno.DisplayMember = "Value";
            cmbAba3DataAgendadaAno.ValueMember = "Key";
            cmbAba3DataAgendadaAno.DataSource = ControllerEnum.ListaDeAnoDataAgenda();
            DadosCmbAba3DataAgendadaAno = ControllerEnum.ListaDeAnoDataAgenda();
            TextoCmbAba3DataAgendadaAno = string.Empty;

            cmbAba3HoraAgendadaHora.DisplayMember = "Value";
            cmbAba3HoraAgendadaHora.ValueMember = "Key";
            cmbAba3HoraAgendadaHora.DataSource = ControllerEnum.ListaDeHoraAgenda();
            DadosCmbAba3HoraAgendadaHora = ControllerEnum.ListaDeHoraAgenda();
            TextoCmbAba3HoraAgendadaHora = string.Empty;

            cmbAba3HoraAgendadaMinuto.DisplayMember = "Value";
            cmbAba3HoraAgendadaMinuto.ValueMember = "Key";
            cmbAba3HoraAgendadaMinuto.DataSource = ControllerEnum.ListaDeMinutoAgenda();
            DadosCmbAba3HoraAgendadaMinuto = ControllerEnum.ListaDeMinutoAgenda();
            TextoCmbAba3HoraAgendadaMinuto = string.Empty;
        }

        private void PreencheCamposTAgendamento()
        {
            try
            {
                if (Program.IDAgendamento > 0)
                {
                    DataTable tableTAgendamento = ControllerAgendamento.SelecioneAgendamento(Program.IDAgendamento);

                    if (tableTAgendamento.Rows.Count == 1)
                    {
                        txtAba1Nome.Text = tableTAgendamento.Rows[0]["Nome"].ToString();

                        DateTime dataCompleta = Convert.ToDateTime(tableTAgendamento.Rows[0]["DataNascimento"]);
                        cmbAba1DataNascimentoDia.SelectedValue = dataCompleta.Day;
                        cmbAba1DataNascimentoMes.SelectedValue = dataCompleta.Month;
                        cmbAba1DataNascimentoAno.SelectedValue = dataCompleta.Year;

                        txtAba1Telefone.Text = tableTAgendamento.Rows[0]["Telefone"].ToString();
                        txtAba1Celular.Text = tableTAgendamento.Rows[0]["Celular"].ToString();

                        txtAba1Email.Text = tableTAgendamento.Rows[0]["Email"].ToString();

                        txtAba2Endereco.Text = tableTAgendamento.Rows[0]["Logradouro"].ToString();
                        txtAba2Numero.Text = tableTAgendamento.Rows[0]["Numero"].ToString();

                        string[] complementos = tableTAgendamento.Rows[0]["Complemento"].ToString().Split('-');
                        foreach (string item in complementos)
                        {
                            lstAba2Complemento.Items.Add(item);
                        }


                        cmbAba2Complemento.SelectedIndex = 0;
                        txtAba2Complemento.Text = string.Empty;

                        txtAba2Bairro.Text = tableTAgendamento.Rows[0]["Bairro"].ToString();
                        txtAba2Cidade.Text = tableTAgendamento.Rows[0]["Cidade"].ToString();
                        cmbAba2UF.Text = tableTAgendamento.Rows[0]["UF"].ToString();

                        DateTime dataAgendada = Convert.ToDateTime(tableTAgendamento.Rows[0]["DataAgendada"]);
                        cmbAba3DataAgendadaDia.SelectedValue = dataAgendada.Day;
                        cmbAba3DataAgendadaMes.SelectedValue = dataAgendada.Month;
                        cmbAba3DataAgendadaAno.SelectedValue = dataAgendada.Year;
                        cmbAba3HoraAgendadaHora.SelectedValue = dataAgendada.Hour;
                        cmbAba3HoraAgendadaMinuto.SelectedValue = dataAgendada.Minute;

                        txtAba3PontoReferencia.Text = tableTAgendamento.Rows[0]["PontoReferencia"].ToString();

                        string cepCompleto = tableTAgendamento.Rows[0]["CEP"].ToString();
                        if (cepCompleto.Length >= 8)
                        {
                            txtAba2CEPbox1.Text = cepCompleto.Substring(0, 5);
                            txtAba2CEPbox2.Text = cepCompleto.Substring(5, 3);
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                LogErro.GravaLog("Erro ao recuperar o formulário TAgendamento.", ex.Message);
                CaixaMensagem.ExibirOk("Erro ao recuperar o agendamento!");
            }

        }

        private void PesquisarCEP(string numeroTextCEP)
        {
            int numeroCEP = Convert.ToInt32(numeroTextCEP);

            DataTable tableEndereco = ControllerLogradouro.PesquisaCEP(numeroCEP);

            if (tableEndereco.Rows.Count > 0)
            {
                txtAba2Endereco.Text = tableEndereco.Rows[0]["NomeLogradouro"].ToString();
                txtAba2Bairro.Text = tableEndereco.Rows[0]["NomeBairro"].ToString();
                txtAba2Cidade.Text = tableEndereco.Rows[0]["NomeCidade"].ToString();
                cmbAba2UF.SelectedValue = tableEndereco.Rows[0]["IDEstado"].ToString();
            }
        }

        #endregion

        #region [ FILL ]

        private void AcertarFocuCampos()
        {
            switch (tabFormulario.SelectedIndex)
            {
                case 0:
                    txtAba1Nome.Focus();
                    AbaAnterior = 0;
                    break;
                case 1:
                    txtAba2CEPbox1.Focus();
                    AbaAnterior = 1;
                    break;
                case 2:
                    cmbAba3DataAgendadaDia.Focus();
                    AbaAnterior = 2;
                    break;
                default:
                    break;
            }
        }

        private void MapearCamposTAgendamento()
        {
            DadosTAgendamento.IDAgendamento = Program.IDAgendamento;

            DadosTAgendamento.Nome = txtAba1Nome.Text;

            string dataCompleta = cmbAba1DataNascimentoAno.Text + "-" + cmbAba1DataNascimentoMes.Text.PadLeft(2, '0') + "-" + cmbAba1DataNascimentoDia.Text.PadLeft(2, '0');
            DadosTAgendamento.DataNascimento = DateTime.ParseExact(dataCompleta, "yyyy-MM-dd", null);

            DadosTAgendamento.Telefone = txtAba1Telefone.Text;

            DadosTAgendamento.Celular = txtAba1Celular.Text;

            DadosTAgendamento.Email = txtAba1Email.Text;

            string cepCompleto = txtAba2CEPbox1.Text + txtAba2CEPbox2.Text;

            DadosTAgendamento.CEP = cepCompleto;

            DadosTAgendamento.Logradouro = txtAba2Endereco.Text;
            DadosTAgendamento.Numero = txtAba2Numero.Text;

            string complemento = string.Empty;
            foreach (string item in lstAba2Complemento.Items)
            {
                complemento += "-" + item;
            }

            if (complemento.Length > 1)
                DadosTAgendamento.Complemento = complemento.Substring(1, complemento.Length - 1);
            else
                DadosTAgendamento.Complemento = string.Empty;

            DadosTAgendamento.Bairro = txtAba2Bairro.Text;
            DadosTAgendamento.Cidade = txtAba2Cidade.Text;
            DadosTAgendamento.UF = cmbAba2UF.Text;

            string dataAgendada = cmbAba3DataAgendadaAno.Text + "-" + cmbAba3DataAgendadaMes.Text.PadLeft(2, '0') + "-" + cmbAba3DataAgendadaDia.Text.PadLeft(2, '0') + " " + cmbAba3HoraAgendadaHora.Text.PadLeft(2, '0') + ":" + cmbAba3HoraAgendadaMinuto.Text.PadLeft(2, '0');
            DadosTAgendamento.DataAgendada = DateTime.ParseExact(dataAgendada, "yyyy-MM-dd HH:mm", null);

            DadosTAgendamento.PontoReferencia = txtAba3PontoReferencia.Text;

        }

        #endregion

        #region [ AUTHENTICATE ]

        private bool ValidarCampos()
        {
            try
            {
                #region [ ABA 1 ]

                if (string.IsNullOrEmpty(txtAba1Nome.Text))
                {
                    MostraCursor.CursorAguarde(false);
                    CaixaMensagem.ExibirOk("Campo Nome não informado!");
                    tabFormulario.SelectedIndex = 0;
                    txtAba1Nome.Focus();
                    return false;
                }

                if (Convert.ToInt32(cmbAba1DataNascimentoDia.SelectedValue) == 0)
                {
                    MostraCursor.CursorAguarde(false);
                    CaixaMensagem.ExibirOk("Campo Data de Nascimento (DIA) é obrigatório!");
                    tabFormulario.SelectedIndex = 0;
                    cmbAba1DataNascimentoDia.Focus();
                    return false;
                }

                if (Convert.ToInt32(cmbAba1DataNascimentoMes.SelectedValue) == 0)
                {
                    MostraCursor.CursorAguarde(false);
                    CaixaMensagem.ExibirOk("Campo Data de Nascimento (MÊS) é obrigatório!");
                    tabFormulario.SelectedIndex = 0;
                    cmbAba1DataNascimentoMes.Focus();
                    return false;
                }

                if (Convert.ToInt32(cmbAba1DataNascimentoAno.SelectedValue) == 0)
                {
                    MostraCursor.CursorAguarde(false);
                    CaixaMensagem.ExibirOk("Campo Data de Nascimento (ANO) é obrigatório!");
                    tabFormulario.SelectedIndex = 0;
                    cmbAba1DataNascimentoAno.Focus();
                    return false;
                }

                if (string.IsNullOrEmpty(txtAba1Telefone.Text) && string.IsNullOrEmpty(txtAba1Celular.Text))
                {
                    MostraCursor.CursorAguarde(false);
                    CaixaMensagem.ExibirOk("Campo Telefone Residencial ou Telefone Celular é obrigatório!");
                    tabFormulario.SelectedIndex = 0;
                    txtAba1Telefone.Focus();
                    return false;
                }


                if (string.IsNullOrEmpty(txtAba1Email.Text))
                {
                    MostraCursor.CursorAguarde(false);
                    CaixaMensagem.ExibirOk("Campo E-Mail não foi preenchido!");
                }

                #endregion

                #region [ ABA 2 ]

                if (string.IsNullOrEmpty(txtAba2CEPbox1.Text))
                {
                    MostraCursor.CursorAguarde(false);
                    CaixaMensagem.ExibirOk("Campo CEP é obrigatório!");
                    tabFormulario.SelectedIndex = 1;
                    txtAba2CEPbox1.Focus();
                    return false;
                }

                if (string.IsNullOrEmpty(txtAba2CEPbox2.Text))
                {
                    MostraCursor.CursorAguarde(false);
                    CaixaMensagem.ExibirOk("Campo CEP é obrigatório!");
                    tabFormulario.SelectedIndex = 1;
                    txtAba2CEPbox2.Focus();
                    return false;
                }

                if (txtAba2CEPbox1.Text.Length < 5)
                {
                    MostraCursor.CursorAguarde(false);
                    CaixaMensagem.ExibirOk("Campo CEP inválido!");
                    tabFormulario.SelectedIndex = 1;
                    txtAba2CEPbox1.Focus();
                    return false;
                }

                if (txtAba2CEPbox2.Text.Length < 3)
                {
                    MostraCursor.CursorAguarde(false);
                    CaixaMensagem.ExibirOk("Campo CEP inválido!");
                    tabFormulario.SelectedIndex = 1;
                    txtAba2CEPbox2.Focus();
                    return false;
                }

                if (string.IsNullOrEmpty(txtAba2Endereco.Text))
                {
                    MostraCursor.CursorAguarde(false);
                    CaixaMensagem.ExibirOk("Campo Endereço é obrigatório!");
                    tabFormulario.SelectedIndex = 1;
                    txtAba2Endereco.Focus();
                    return false;
                }

                if (string.IsNullOrEmpty(txtAba2Bairro.Text))
                {
                    MostraCursor.CursorAguarde(false);
                    CaixaMensagem.ExibirOk("Campo Bairro é obrigatório!");
                    tabFormulario.SelectedIndex = 1;
                    txtAba2Bairro.Focus();
                    return false;
                }

                if (string.IsNullOrEmpty(txtAba2Cidade.Text))
                {
                    MostraCursor.CursorAguarde(false);
                    CaixaMensagem.ExibirOk("Campo Cidade é obrigatório!");
                    tabFormulario.SelectedIndex = 1;
                    txtAba2Cidade.Focus();
                    return false;
                }

                if (cmbAba2UF.SelectedIndex <= 0)
                {
                    MostraCursor.CursorAguarde(false);
                    CaixaMensagem.ExibirOk("Campo UF é obrigatório!");
                    tabFormulario.SelectedIndex = 1;
                    cmbAba2UF.Focus();
                    return false;
                }

                #endregion

                #region [ ABA 3 ]

                if (Convert.ToInt32(cmbAba3DataAgendadaDia.SelectedValue) == 0)
                {
                    MostraCursor.CursorAguarde(false);
                    CaixaMensagem.ExibirOk("Campo Data Agendada (DIA) é obrigatório!");
                    tabFormulario.SelectedIndex = 2;
                    cmbAba3DataAgendadaDia.Focus();
                    return false;
                }

                if (Convert.ToInt32(cmbAba3DataAgendadaMes.SelectedValue) == 0)
                {
                    MostraCursor.CursorAguarde(false);
                    CaixaMensagem.ExibirOk("Campo Data Agendada (MÊS) é obrigatório!");
                    tabFormulario.SelectedIndex = 2;
                    cmbAba3DataAgendadaMes.Focus();
                    return false;
                }

                if (Convert.ToInt32(cmbAba3DataAgendadaAno.SelectedValue) == 0)
                {
                    MostraCursor.CursorAguarde(false);
                    CaixaMensagem.ExibirOk("Campo Data Agendada (ANO) é obrigatório!");
                    tabFormulario.SelectedIndex = 2;
                    cmbAba3DataAgendadaAno.Focus();
                    return false;
                }

                if (Convert.ToInt32(cmbAba3HoraAgendadaHora.SelectedValue) == 0)
                {
                    MostraCursor.CursorAguarde(false);
                    CaixaMensagem.ExibirOk("Campo Hora Agendada (HORA) é obrigatório!");
                    tabFormulario.SelectedIndex = 2;
                    cmbAba3HoraAgendadaHora.Focus();
                    return false;
                }

                if (Convert.ToInt32(cmbAba3HoraAgendadaMinuto.SelectedValue) == 0)
                {
                    MostraCursor.CursorAguarde(false);
                    CaixaMensagem.ExibirOk("Campo Hora Agendada (MINUTO) é obrigatório!");
                    tabFormulario.SelectedIndex = 2;
                    cmbAba3HoraAgendadaMinuto.Focus();
                    return false;
                }

                #endregion

                return true;
            }
            catch (Exception ex)
            {
                MostraCursor.CursorAguarde(false);
                LogErro.GravaLog("Erro ao validar Agendamento.", ex.Message);
                CaixaMensagem.ExibirOk("Erro ao validar Agendamento!");
                return false;
            }
        }

        #endregion

        #region [ CONTROLS ]

        private void UpperCase_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((TextBox)sender).Text.Length == 0 && e.KeyChar != Convert.ToChar(8))
            {
                ((TextBox)sender).Text = char.ToUpper(e.KeyChar).ToString();
                ((TextBox)sender).SelectionStart = ((TextBox)sender).Text.Length;
                e.Handled = true;
                return;
            }
        }

        private void Texto_GotFocus(object sender, EventArgs e)
        {
            //Aciona o botão Laranja
            var newstate = Symbol.Keyboard.KeyStates.KEYSTATE_UNSHIFT;
            Symbol.Keyboard.KeyPad teclado = new Symbol.Keyboard.KeyPad();
            teclado.SetKeyState(newstate, 0, true);
        }

        private void Telefone_KeyPress(object sender, KeyPressEventArgs e)
        {
            char digitoSaida = '0';
            bool verificado = false;

            //Aciona o botão Laranja
            var newstate = Symbol.Keyboard.KeyStates.KEYSTATE_NUMERIC_LOCK;
            Symbol.Keyboard.KeyPad teclado = new Symbol.Keyboard.KeyPad();
            teclado.SetKeyState(newstate, 0, true);

            if (((TextBox)sender).Text.Length == 15 && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
                return;
            }

            verificado = new Util.Mask().ApenasNumero(e.KeyChar, ref digitoSaida);

            if (verificado)
            {
                if ((txtAba1Telefone.Focused && ((TextBox)sender).Text.Length < 13)
                    || (txtAba1Celular.Focused && ((TextBox)sender).Text.Length < 14))
                {
                    if (((TextBox)sender).Text.Length == 0)
                        ((TextBox)sender).Text = "(" + digitoSaida;
                    else if (((TextBox)sender).Text.Length == 3)
                        ((TextBox)sender).Text = ((TextBox)sender).Text + ")" + digitoSaida;
                    else if (((TextBox)sender).Text.Length == 8)
                        ((TextBox)sender).Text = ((TextBox)sender).Text + "-" + digitoSaida;
                    else
                        ((TextBox)sender).Text = ((TextBox)sender).Text + digitoSaida;

                    ((TextBox)sender).SelectionStart = ((TextBox)sender).Text.Length;
                    e.Handled = true;
                }
            }
            else
            {
                if (e.KeyChar != Convert.ToChar(8))
                    e.Handled = true;
            }
        }

        private void CEP_KeyPress(object sender, KeyPressEventArgs e)
        {
            char digitoSaida = '0';
            bool verificado = false;

            //Aciona o botão Laranja
            var newstate = Symbol.Keyboard.KeyStates.KEYSTATE_NUMERIC_LOCK;
            Symbol.Keyboard.KeyPad teclado = new Symbol.Keyboard.KeyPad();
            teclado.SetKeyState(newstate, 0, true);

            if (e.KeyChar == Convert.ToChar(8))
                return;

            if (((TextBox)sender).Name.Equals("txtAba2CEPbox1") && txtAba2CEPbox1.Text.Length == 4)
            {
                verificado = new Util.Mask().ApenasNumero(e.KeyChar, ref digitoSaida);

                if (verificado)
                {
                    ((TextBox)sender).Text = ((TextBox)sender).Text + digitoSaida;
                    ((TextBox)sender).SelectionStart = ((TextBox)sender).Text.Length;
                    e.Handled = true;
                }

                txtAba2CEPbox2.Focus();
                return;
            }

            if (((TextBox)sender).Name.Equals("txtAba2CEPbox2") && txtAba2CEPbox2.Text.Length == 3)
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
                e.Handled = true;


            int tamanho = txtAba2CEPbox1.Text.Length + txtAba2CEPbox2.Text.Length;
            if (tamanho == 8)
            {
                MostraCursor.CursorAguarde(true);
                PesquisarCEP(txtAba2CEPbox1.Text + txtAba2CEPbox2.Text);
                txtAba2Endereco.Focus();
                MostraCursor.CursorAguarde(false);
            }
        }

        private void Numero_KeyPress(object sender, KeyPressEventArgs e)
        {
            char digitoSaida = '0';
            bool verificado = false;

            //Aciona o botão Laranja
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
            //Aciona o botão Laranja
            var newstate = Symbol.Keyboard.KeyStates.KEYSTATE_NUMERIC_LOCK;
            Symbol.Keyboard.KeyPad teclado = new Symbol.Keyboard.KeyPad();
            teclado.SetKeyState(newstate, 0, true);
        }

        #region [ Controls Aba 1 ]

        private void cmbAba1DataNascimentoDia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 42 || e.KeyChar == 9  || e.KeyChar == 13)
            {
                TextoCmbAba1DataNascimentoDia = string.Empty;
                e.Handled = true;
                return;
            }

            string atual = TextoCmbAba1DataNascimentoDia;
            TextoCmbAba1DataNascimentoDia += e.KeyChar.ToString();

            DataRow[] verificaCombo = DadosCmbAba1DataNascimentoDia.Select("Value LIKE '" + TextoCmbAba1DataNascimentoDia + "%'");
            if (verificaCombo.Length > 0)
            {
                ((ComboBox)sender).SelectedValue = verificaCombo[0].ItemArray[0];
            }
            else
            {
                TextoCmbAba1DataNascimentoDia = atual;
            }

            e.Handled = true;
        }

        private void cmbAba1DataNascimentoMes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 42 || e.KeyChar == 9  || e.KeyChar == 13)
            {
                TextoCmbAba1DataNascimentoMes = string.Empty;
                e.Handled = true;
                return;
            }

            string atual = TextoCmbAba1DataNascimentoMes;
            TextoCmbAba1DataNascimentoMes += e.KeyChar.ToString();

            DataRow[] verificaCombo = DadosCmbAba1DataNascimentoMes.Select("Value LIKE '" + TextoCmbAba1DataNascimentoMes + "%'");
            if (verificaCombo.Length > 0)
            {
                ((ComboBox)sender).SelectedValue = verificaCombo[0].ItemArray[0];
            }
            else
            {
                TextoCmbAba1DataNascimentoMes = atual;
            }

            e.Handled = true;
        }

        private void cmbAba1DataNascimentoMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            int valor = Convert.ToInt32(cmbAba1DataNascimentoDia.SelectedValue);

            DataTable tabelaDias = ControllerEnum.ListaDeDiaData(Convert.ToInt32(cmbAba1DataNascimentoMes.SelectedValue));
            DataRow[] verificaTabela = tabelaDias.Select("Key = '" + valor + "'");

            cmbAba1DataNascimentoDia.DisplayMember = "Value";
            cmbAba1DataNascimentoDia.ValueMember = "Key";
            cmbAba1DataNascimentoDia.DataSource = tabelaDias;
            DadosCmbAba1DataNascimentoDia = tabelaDias;
            TextoCmbAba1DataNascimentoDia = string.Empty;

            if (verificaTabela.Length > 0)
                cmbAba1DataNascimentoDia.SelectedValue = valor;
        }

        private void cmbAba1DataNascimentoAno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 42 || e.KeyChar == 9  || e.KeyChar == 13)
            {
                TextoCmbAba1DataNascimentoAno = string.Empty;
                e.Handled = true;
                return;
            }


            string atual = TextoCmbAba1DataNascimentoAno;
            TextoCmbAba1DataNascimentoAno += e.KeyChar.ToString();

            int duplaBase = DateTime.Now.Year % 100;
            int centenaBase = duplaBase / 10;

            DataRow[] verificaCombo;

            if (TextoCmbAba1DataNascimentoAno.Length == 1 && Convert.ToInt32(TextoCmbAba1DataNascimentoAno) > centenaBase)
                verificaCombo = DadosCmbAba1DataNascimentoAno.Select("Value LIKE '19" + TextoCmbAba1DataNascimentoAno + "%'");
            else if (TextoCmbAba1DataNascimentoAno.Length == 1 && Convert.ToInt32(TextoCmbAba1DataNascimentoAno) < centenaBase)
                verificaCombo = DadosCmbAba1DataNascimentoAno.Select("Value LIKE '20" + TextoCmbAba1DataNascimentoAno + "%'");
            else if (TextoCmbAba1DataNascimentoAno.Length == 2 && Convert.ToInt32(TextoCmbAba1DataNascimentoAno) > duplaBase)
                verificaCombo = DadosCmbAba1DataNascimentoAno.Select("Value LIKE '19" + TextoCmbAba1DataNascimentoAno + "%'");
            else if (TextoCmbAba1DataNascimentoAno.Length == 2 && Convert.ToInt32(TextoCmbAba1DataNascimentoAno) < duplaBase)
                verificaCombo = DadosCmbAba1DataNascimentoAno.Select("Value LIKE '20" + TextoCmbAba1DataNascimentoAno + "%'");
            else
            {
                TextoCmbAba1DataNascimentoAno = string.Empty;
                e.Handled = true;
                return;
            }

            if (verificaCombo.Length > 0)
            {
                ((ComboBox)sender).SelectedValue = verificaCombo[0].ItemArray[0];
            }
            else
            {
                TextoCmbAba1DataNascimentoAno = atual;
            }

            e.Handled = true;
        }

        private void txtAba1Email_KeyPress(object sender, KeyPressEventArgs e)
        {

            //Aciona o botão Laranja
            var newstate = Symbol.Keyboard.KeyStates.KEYSTATE_UNSHIFT;
            Symbol.Keyboard.KeyPad teclado = new Symbol.Keyboard.KeyPad();
            teclado.SetKeyState(newstate, 0, true);

            if (e.KeyChar == Convert.ToChar('*'))
            {
                if (txtAba1Email.Text.Contains(".com"))
                    txtAba1Email.Text = txtAba1Email.Text + ".br";
                else
                    txtAba1Email.Text = txtAba1Email.Text + ".com";

                txtAba1Email.SelectionStart = txtAba1Email.Text.Length;
                e.Handled = true;
                return;
            }
            else
            {
                if (e.KeyChar == Convert.ToChar(','))
                {
                    txtAba1Email.Text = txtAba1Email.Text + "@";
                    txtAba1Email.SelectionStart = txtAba1Email.Text.Length;
                    e.Handled = true;
                    return;
                }
            }

        }

        private void txtAba1Email_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tabFormulario.SelectedIndex = 1;
                txtAba2CEPbox1.Focus();
                e.Handled = true;
            }
        }

        #endregion

        #region [ Controls Aba 2 ]

        private void cmbAba2Complemento_GotFocus(object sender, EventArgs e)
        {
            var newstate = Symbol.Keyboard.KeyStates.KEYSTATE_UNSHIFT;
            Symbol.Keyboard.KeyPad teclado = new Symbol.Keyboard.KeyPad();
            teclado.SetKeyState(newstate, 0, true);

            TextoCmbAba2Complemento = string.Empty;
        }

        private void cmbAba2Complemento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 42 || e.KeyChar == 9  || e.KeyChar == 13)
            {
                TextoCmbAba2Complemento = string.Empty;
                e.Handled = true;
                return;
            }

            string atual = TextoCmbAba2Complemento;
            TextoCmbAba2Complemento += e.KeyChar.ToString();

            DataRow[] verificaCombo = DadosCmbAba2Complemento.Select("Value LIKE '" + TextoCmbAba2Complemento + "%'");
            if (verificaCombo.Length > 0)
            {
                ((ComboBox)sender).SelectedValue = verificaCombo[0].ItemArray[0];
            }
            else
            {
                TextoCmbAba2Complemento = atual;
            }

            e.Handled = true;
        }

        private void txtAba2Complemento_GotFocus(object sender, EventArgs e)
        {
            if (cmbAba2Complemento.SelectedValue.Equals("Apto"))
            {
                var newstate = Symbol.Keyboard.KeyStates.KEYSTATE_NUMERIC_LOCK;
                Symbol.Keyboard.KeyPad teclado = new Symbol.Keyboard.KeyPad();
                teclado.SetKeyState(newstate, 0, true);
            }
            else
            {
                var newstate = Symbol.Keyboard.KeyStates.KEYSTATE_UNSHIFT;
                Symbol.Keyboard.KeyPad teclado = new Symbol.Keyboard.KeyPad();
                teclado.SetKeyState(newstate, 0, true);
            }
        }

        private void btnAba2ComplementoAd_Click(object sender, EventArgs e)
        {
            if (cmbAba2Complemento.SelectedIndex <= 0)
                cmbAba2Complemento.Focus();
            else
                if (string.IsNullOrEmpty(txtAba2Complemento.Text) && !txtAba2Complemento.Text.Equals("Casa") && !txtAba2Complemento.Text.Equals("Fundos"))
                    txtAba2Complemento.Focus();
                else
                {
                    if (string.IsNullOrEmpty(txtAba2Complemento.Text))
                        lstAba2Complemento.Items.Add(cmbAba2Complemento.Text);
                    else
                        lstAba2Complemento.Items.Add(cmbAba2Complemento.Text + " : " + txtAba2Complemento.Text);

                    cmbAba2Complemento.SelectedIndex = 0;
                    txtAba2Complemento.Text = string.Empty;
                }
        }

        private void btnAba2ComplementoRm_Click(object sender, EventArgs e)
        {
            if (lstAba2Complemento.SelectedIndex > -1)
            {
                lstAba2Complemento.Items.RemoveAt(lstAba2Complemento.SelectedIndex);
            }
        }

        private void cmbAba2UF_GotFocus(object sender, EventArgs e)
        {
            var newstate = Symbol.Keyboard.KeyStates.KEYSTATE_UNSHIFT;
            Symbol.Keyboard.KeyPad teclado = new Symbol.Keyboard.KeyPad();
            teclado.SetKeyState(newstate, 0, true);

            TextoCmbAba2UF = string.Empty;
        }

        private void cmbAba2UF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 42 || e.KeyChar == 9  || e.KeyChar == 13)
            {
                TextoCmbAba2UF = string.Empty;
                e.Handled = true;
                return;
            }

            string atual = TextoCmbAba2UF;
            TextoCmbAba2UF += e.KeyChar.ToString();

            DataRow[] verificaCombo = DadosCmbAba2UF.Select("Sigla LIKE '" + TextoCmbAba2UF + "%'");
            if (verificaCombo.Length > 0)
            {
                ((ComboBox)sender).SelectedValue = verificaCombo[0].ItemArray[0];
            }
            else
            {
                TextoCmbAba2UF = atual;
            }

            e.Handled = true;
        }

        private void cmbAba2UF_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tabFormulario.SelectedIndex = 2;
                cmbAba3DataAgendadaDia.Focus();
                e.Handled = true;
            }
        }

        #endregion

        #region [ Controls Aba 3 ]

        private void cmbAba3DataAgendadaDia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 42 || e.KeyChar == 9  || e.KeyChar == 13)
            {
                TextoCmbAba3DataAgendadaDia = string.Empty;
                e.Handled = true;
                return;
            }

            string atual = TextoCmbAba3DataAgendadaDia;
            TextoCmbAba3DataAgendadaDia += e.KeyChar.ToString();

            DataRow[] verificaCombo = DadosCmbAba3DataAgendadaDia.Select("Value LIKE '" + TextoCmbAba3DataAgendadaDia + "%'");
            if (verificaCombo.Length > 0)
            {
                ((ComboBox)sender).SelectedValue = verificaCombo[0].ItemArray[0];
            }
            else
            {
                TextoCmbAba3DataAgendadaDia = atual;
            }

            e.Handled = true;
        }

        private void cmbAba3DataAgendadaMes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 42 || e.KeyChar == 9  || e.KeyChar == 13)
            {
                TextoCmbAba3DataAgendadaMes = string.Empty;
                e.Handled = true;
                return;
            }

            string atual = TextoCmbAba3DataAgendadaMes;
            TextoCmbAba3DataAgendadaMes += e.KeyChar.ToString();

            DataRow[] verificaCombo = DadosCmbAba3DataAgendadaMes.Select("Value LIKE '" + TextoCmbAba3DataAgendadaMes + "%'");
            if (verificaCombo.Length > 0)
            {
                ((ComboBox)sender).SelectedValue = verificaCombo[0].ItemArray[0];
            }
            else
            {
                TextoCmbAba3DataAgendadaMes = atual;
            }

            e.Handled = true;
        }

        private void cmbAba3DataAgendadaMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            int valor = Convert.ToInt32(cmbAba3DataAgendadaDia.SelectedValue);

            DataTable tabelaDias = ControllerEnum.ListaDeDiaData(Convert.ToInt32(cmbAba3DataAgendadaMes.SelectedValue));
            DataRow[] verificaTabela = tabelaDias.Select("Key = '" + valor + "'");

            cmbAba3DataAgendadaDia.DisplayMember = "Value";
            cmbAba3DataAgendadaDia.ValueMember = "Key";
            cmbAba3DataAgendadaDia.DataSource = tabelaDias;
            DadosCmbAba3DataAgendadaDia = tabelaDias;
            TextoCmbAba3DataAgendadaDia = string.Empty;

            if (verificaTabela.Length > 0)
                cmbAba3DataAgendadaDia.SelectedValue = valor;
        }

        private void cmbAba3DataAgendadaAno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 42 || e.KeyChar == 9  || e.KeyChar == 13)
            {
                TextoCmbAba3DataAgendadaAno = string.Empty;
                e.Handled = true;
                return;
            }

            string atual = TextoCmbAba3DataAgendadaAno;
            TextoCmbAba3DataAgendadaAno += e.KeyChar.ToString();

            DataRow[] verificaCombo = DadosCmbAba3DataAgendadaAno.Select("Value LIKE '%" + TextoCmbAba3DataAgendadaAno + "%'");
            if (verificaCombo.Length > 0)
            {
                ((ComboBox)sender).SelectedValue = verificaCombo[0].ItemArray[0];
            }
            else
            {
                TextoCmbAba3DataAgendadaAno = atual;
            }

            e.Handled = true;
        }

        private void cmbAba3HoraAgendadaHora_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 42 || e.KeyChar == 9  || e.KeyChar == 13)
            {
                TextoCmbAba3HoraAgendadaHora = string.Empty;
                e.Handled = true;
                return;
            }

            string atual = TextoCmbAba3HoraAgendadaHora;
            TextoCmbAba3HoraAgendadaHora += e.KeyChar.ToString();

            DataRow[] verificaCombo = DadosCmbAba3HoraAgendadaHora.Select("Value LIKE '" + TextoCmbAba3HoraAgendadaHora + "%'");
            if (verificaCombo.Length > 0)
            {
                ((ComboBox)sender).SelectedValue = verificaCombo[0].ItemArray[0];
            }
            else
            {
                TextoCmbAba3HoraAgendadaHora = atual;
            }

            e.Handled = true;
        }

        private void cmbAba3HoraAgendadaMinuto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 42 || e.KeyChar == 9  || e.KeyChar == 13)
            {
                TextoCmbAba3HoraAgendadaMinuto = string.Empty;
                e.Handled = true;
                return;
            }

            string atual = TextoCmbAba3HoraAgendadaMinuto;
            TextoCmbAba3HoraAgendadaMinuto += e.KeyChar.ToString();

            DataRow[] verificaCombo = DadosCmbAba3HoraAgendadaMinuto.Select("Value LIKE '" + TextoCmbAba3HoraAgendadaMinuto + "%'");
            if (verificaCombo.Length > 0)
            {
                ((ComboBox)sender).SelectedValue = verificaCombo[0].ItemArray[0];
            }
            else
            {
                TextoCmbAba3HoraAgendadaMinuto = atual;
            }

            e.Handled = true;
        }

        private void txtAba3PontoReferencia_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSalvar.Focus();
                e.Handled = true;
            }
        }

        #endregion

        private void FocusOn()
        {
            txtAba1Nome.GotFocus += new EventHandler(Program.txtBox_focusOn);
            cmbAba1DataNascimentoAno.GotFocus += new EventHandler(Program.cmbBox_focusOn);
            cmbAba1DataNascimentoMes.GotFocus += new EventHandler(Program.cmbBox_focusOn);
            cmbAba1DataNascimentoDia.GotFocus += new EventHandler(Program.cmbBox_focusOn);
            txtAba1Telefone.GotFocus += new EventHandler(Program.txtBox_focusOn);
            txtAba1Celular.GotFocus += new EventHandler(Program.txtBox_focusOn);
            txtAba1Email.GotFocus += new EventHandler(Program.txtBox_focusOn);

            txtAba2CEPbox1.GotFocus += new EventHandler(Program.txtBox_focusOn);
            txtAba2CEPbox2.GotFocus += new EventHandler(Program.txtBox_focusOn);
            txtAba2Endereco.GotFocus += new EventHandler(Program.txtBox_focusOn);
            txtAba2Numero.GotFocus += new EventHandler(Program.txtBox_focusOn);
            txtAba2Complemento.GotFocus += new EventHandler(Program.txtBox_focusOn);
            btnAba2ComplementoRm.GotFocus += new EventHandler(Program.btn_focusOn);
            btnAba2ComplementoAd.GotFocus += new EventHandler(Program.btn_focusOn);
            cmbAba2Complemento.GotFocus += new EventHandler(Program.cmbBox_focusOn);
            txtAba2Bairro.GotFocus += new EventHandler(Program.txtBox_focusOn);
            txtAba2Cidade.GotFocus += new EventHandler(Program.txtBox_focusOn);
            cmbAba2UF.GotFocus += new EventHandler(Program.cmbBox_focusOn);

            cmbAba3HoraAgendadaMinuto.GotFocus += new EventHandler(Program.cmbBox_focusOn);
            cmbAba3HoraAgendadaHora.GotFocus += new EventHandler(Program.cmbBox_focusOn);
            cmbAba3DataAgendadaAno.GotFocus += new EventHandler(Program.cmbBox_focusOn);
            cmbAba3DataAgendadaMes.GotFocus += new EventHandler(Program.cmbBox_focusOn);
            cmbAba3DataAgendadaDia.GotFocus += new EventHandler(Program.cmbBox_focusOn);
            txtAba3PontoReferencia.GotFocus += new EventHandler(Program.txtBox_focusOn);

            btnExcluir.GotFocus += new EventHandler(Program.btn_focusOn);
            bntSair.GotFocus += new EventHandler(Program.btn_focusOn);
            btnSalvar.GotFocus += new EventHandler(Program.btn_focusOn);
        }

        private void FocusOff()
        {
            txtAba1Nome.LostFocus += new EventHandler(Program.txtBox_focusOff);
            cmbAba1DataNascimentoAno.LostFocus += new EventHandler(Program.cmbBox_focusOff);
            cmbAba1DataNascimentoMes.LostFocus += new EventHandler(Program.cmbBox_focusOff);
            cmbAba1DataNascimentoDia.LostFocus += new EventHandler(Program.cmbBox_focusOff);
            txtAba1Telefone.LostFocus += new EventHandler(Program.txtBox_focusOff);
            txtAba1Celular.LostFocus += new EventHandler(Program.txtBox_focusOff);
            txtAba1Email.LostFocus += new EventHandler(Program.txtBox_focusOff);

            txtAba2CEPbox1.LostFocus += new EventHandler(Program.txtBox_focusOff);
            txtAba2CEPbox2.LostFocus += new EventHandler(Program.txtBox_focusOff);
            txtAba2Endereco.LostFocus += new EventHandler(Program.txtBox_focusOff);
            txtAba2Numero.LostFocus += new EventHandler(Program.txtBox_focusOff);
            txtAba2Complemento.LostFocus += new EventHandler(Program.txtBox_focusOff);
            btnAba2ComplementoRm.LostFocus += new EventHandler(Program.btn_focusOffWhite);
            btnAba2ComplementoAd.LostFocus += new EventHandler(Program.btn_focusOffWhite);
            cmbAba2Complemento.LostFocus += new EventHandler(Program.cmbBox_focusOff);
            txtAba2Bairro.LostFocus += new EventHandler(Program.txtBox_focusOff);
            txtAba2Cidade.LostFocus += new EventHandler(Program.txtBox_focusOff);
            cmbAba2UF.LostFocus += new EventHandler(Program.cmbBox_focusOff);

            cmbAba3HoraAgendadaMinuto.LostFocus += new EventHandler(Program.cmbBox_focusOff);
            cmbAba3HoraAgendadaHora.LostFocus += new EventHandler(Program.cmbBox_focusOff);
            cmbAba3DataAgendadaAno.LostFocus += new EventHandler(Program.cmbBox_focusOff);
            cmbAba3DataAgendadaMes.LostFocus += new EventHandler(Program.cmbBox_focusOff);
            cmbAba3DataAgendadaDia.LostFocus += new EventHandler(Program.cmbBox_focusOff);
            txtAba3PontoReferencia.LostFocus += new EventHandler(Program.txtBox_focusOff);

            btnExcluir.LostFocus += new EventHandler(Program.btn_focusOffAzul);
            bntSair.LostFocus += new EventHandler(Program.btn_focusOffAzul);
            btnSalvar.LostFocus += new EventHandler(Program.btn_focusOffAzul);                     
        }

        private void KeyDownTecla()
        {
            //Only button and check
            
            btnAba2ComplementoRm.KeyDown += new KeyEventHandler(Program.btn_enter);
            btnAba2ComplementoAd.KeyDown += new KeyEventHandler(Program.btn_enter);
            btnExcluir.KeyDown += new KeyEventHandler(Program.btn_enter);
            bntSair.KeyDown += new KeyEventHandler(Program.btn_enter);
            btnSalvar.KeyDown += new KeyEventHandler(Program.btn_enter);
            
        }

        private void KeyUpTecla()
        {
            txtAba1Nome.KeyUp += new KeyEventHandler(Program.txtBox_next);
            cmbAba1DataNascimentoAno.KeyUp += new KeyEventHandler(Program.cmbBox_next);
            cmbAba1DataNascimentoMes.KeyUp += new KeyEventHandler(Program.cmbBox_next);
            cmbAba1DataNascimentoDia.KeyUp += new KeyEventHandler(Program.cmbBox_next); 
            txtAba1Telefone.KeyUp += new KeyEventHandler(Program.txtBox_next);
            txtAba1Celular.KeyUp += new KeyEventHandler(Program.txtBox_next);
            txtAba1Email.KeyUp += new KeyEventHandler(txtAba1Email_KeyUp);

            txtAba2CEPbox1.KeyUp += new KeyEventHandler(Program.txtBox_next);
            txtAba2CEPbox2.KeyUp += new KeyEventHandler(Program.txtBox_next);
            txtAba2Endereco.KeyUp += new KeyEventHandler(Program.txtBox_next);
            txtAba2Numero.KeyUp += new KeyEventHandler(Program.txtBox_next);
            txtAba2Complemento.KeyUp += new KeyEventHandler(Program.txtBox_next);
            btnAba2ComplementoRm.KeyUp += new KeyEventHandler(Program.btn_next);
            btnAba2ComplementoAd.KeyUp += new KeyEventHandler(Program.btn_next);
            cmbAba2Complemento.KeyUp += new KeyEventHandler(Program.cmbBox_next);
            txtAba2Bairro.KeyUp += new KeyEventHandler(Program.txtBox_next);
            txtAba2Cidade.KeyUp += new KeyEventHandler(Program.txtBox_next);
            cmbAba2UF.KeyUp += new KeyEventHandler(cmbAba2UF_KeyUp);

            cmbAba3HoraAgendadaMinuto.KeyUp += new KeyEventHandler(Program.cmbBox_next);
            cmbAba3HoraAgendadaHora.KeyUp += new KeyEventHandler(Program.cmbBox_next);
            cmbAba3DataAgendadaAno.KeyUp += new KeyEventHandler(Program.cmbBox_next);
            cmbAba3DataAgendadaMes.KeyUp += new KeyEventHandler(Program.cmbBox_next);
            cmbAba3DataAgendadaDia.KeyUp += new KeyEventHandler(Program.cmbBox_next);
            txtAba3PontoReferencia.KeyUp += new KeyEventHandler(txtAba3PontoReferencia_KeyUp);

            btnExcluir.KeyUp += new KeyEventHandler(Program.btn_next);
            bntSair.KeyUp += new KeyEventHandler(Program.btn_next);
            btnSalvar.KeyUp += new KeyEventHandler(Program.btn_next);  
            
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
                MostraCursor.CursorAguarde(true);

                if (!ValidarCampos())
                    return;

                MapearCamposTAgendamento();

                if (ControllerAgendamento.SalvarAgendamento(DadosTAgendamento))
                {
                    MostraCursor.CursorAguarde(false);
                    CaixaMensagem.ExibirOk("Agendamento salvo com sucesso!");
                    this.Close();
                }
                else
                {
                    MostraCursor.CursorAguarde(false);
                    CaixaMensagem.ExibirOk("Erro ao salvar o Agendamento!");
                }
            }
            catch (Exception ex)
            {
                MostraCursor.CursorAguarde(false);
                LogErro.GravaLog("Erro ao Salvar.", ex.Message);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {

                if (MessageBox.Show("Deseja excluir o agendamento?", "PEP",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button2) == DialogResult.No)
                    return;


                MostraCursor.CursorAguarde(true);

                if (ControllerAgendamento.ExcluirAgendamento(Program.IDAgendamento))
                {
                    MostraCursor.CursorAguarde(false);
                    CaixaMensagem.ExibirOk("Agendamento excluído com sucesso!");
                    this.Close();
                }
                else
                {
                    MostraCursor.CursorAguarde(false);
                    CaixaMensagem.ExibirOk("Erro ao excluir o Agendamento!");
                }
            }
            catch (Exception ex)
            {
                MostraCursor.CursorAguarde(false);
                LogErro.GravaLog("Erro ao Excluir.", ex.Message);
            }
        }

        private void tabFormulario_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostraCursor.CursorAguarde(true);
            if (AbaAnterior != tabFormulario.SelectedIndex)
            {
                switch (AbaAnterior)
                {
                    case 0:
                        AcertarFocuCampos();
                        break;
                    case 1:
                        AcertarFocuCampos();
                        break;
                    case 2:
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
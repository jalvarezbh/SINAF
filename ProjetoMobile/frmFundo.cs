using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using ProjetoMobile.Util;
using ProjetoMobile.Persistencia;
using System.Threading;

namespace ProjetoMobile
{
    public partial class frmFundo : Form
    {
        #region [ PROPERTIES ]

        /// <summary>
        /// Pilha dos forms abertos
        /// </summary>
        private static Stack<Type> FormsAbertos;

        /// <summary>
        /// Ponteiro do form fechando atualmente, utilizado para evitar chamadas indevidas do 
        /// </summary>
        private static IntPtr closingForm;

        /// <summary>
        /// Trata o evento de um form fechado, removendo o form do dicionário de notificação
        /// </summary>
        private static EventHandler form_Closed = new EventHandler(novoForm_Closed);

        private static Form formAtual;

        /// <summary>
        /// Trata um evento de Log
        /// </summary>
        private static Action<String> mensagemLog = new Action<String>(notificaMensagem);

        /// <summary>
        /// Dicionário de forms com controles que devem ter o texto atualizado com a última mensagem de log
        /// </summary>
        private static Dictionary<IntPtr, Control> dicStatus = new Dictionary<IntPtr, Control>();

        ControleAtualizacao controleAtual = new ControleAtualizacao();

        TParametroPERSISTENCIA controleParametro = new TParametroPERSISTENCIA();

        UserActivity _userActivity = new UserActivity();

        #endregion
        
        #region [ LOAD ]

        public frmFundo()
        {
            InitializeComponent();

            ControleFormulario(this);
            this.TopMost = false;
            this.Activated += new EventHandler(frmFundo_Activated);
            _userActivity.Start(this, new Action<bool>(SignalActivity));
            _threadEntrevistaAtiva = LerGravarXML.ObterValor("ThreadEntrevista", false);
            if (_threadEntrevistaAtiva)
            {
                mreFormEntrevistaDisponivel = new ManualResetEvent(false);
                mreFormEntrevistaExibido = new ManualResetEvent(false);
                mreFormEntrevistaExibir = new ManualResetEvent(false);
                AgendarCriacaoEntrevista();
            }
        }

        void frmFundo_Activated(object sender, EventArgs e)
        {
            //if (formAtual != null)
            //    formAtual.Activate();
        }

        private void frmFundo_Load(object sender, EventArgs e)
        {
            DataTable tableParametro = controleParametro.SelecioneParametros();

            if (tableParametro.Rows.Count > 0)
                Program.TempoLogOff = Convert.ToInt32(tableParametro.Rows[0]["TempoLogOff"]);
            else
                Program.TempoLogOff = 20;

            lblVersao.Text = "Versão:" + Assembly.GetExecutingAssembly().GetName().Version.ToString();

            AbreForm(typeof(frmLogin));
        }

        #endregion

        #region [ METHODS ]

        /// <summary>
        /// Método de Controle
        /// </summary>
        /// <param name="frmFundo">Form que é exibido durante a troca de form atual</param>
        public void ControleFormulario(Form frmFundo)
        {
            FormsAbertos = new Stack<Type>();
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            FormsAbertos.Clear();
            AbreForm(typeof(frmLogin));
        }

        public static void LimparPilha()
        {
            FormsAbertos.Clear();
            AbreForm(typeof(frmLogin));
        }

        /// <summary>
        /// Abre um novo form e fecha o atual
        /// </summary>
        /// <param name="novoForm">Novo form</param>
        public static Form TrocaForm(Type novoForm)
        {
            FormsAbertos.Pop();
            return AbreForm(novoForm);
        }

        private static Form TrocarFormAtual(Type tipoNovoForm, Form novoForm)
        {
            FormsAbertos.Push(tipoNovoForm);
            if (formAtual != null)
            {
                formAtual.Closed -= form_Closed;
                //Apenas o form entrevista executa numa thread separada e não executa esse comando
                try
                {
                    if (!formAtual.InvokeRequired)
                        formAtual.Close();
                }
                catch
                {
                }
            }
            formAtual = novoForm;
            return formAtual;
        }

        public static Form AbreForm(Type tipoNovoForm)
        {
            if (_threadEntrevistaAtiva && tipoNovoForm == typeof(frmEntrevista) && Program.CodigoEntrevista == 0)
                return ExibirFormEntrevista();
            return AbreForm(tipoNovoForm, true);
        }

        /// <summary>
        /// Abre um novo form
        /// </summary>
        /// <param name="novoForm">Novo form</param>
        public static Form AbreForm(Type tipoNovoForm, Boolean threadPrincipal)
        {
            //Caso seja o callback do form de entrevista, passa a chama à thread principal
            if (threadPrincipal && Program.fundo.InvokeRequired)
                return (Form)Program.fundo.Invoke(new Func<Type, Boolean, Form>(AbreForm), new Object[] { tipoNovoForm, threadPrincipal });
            
            //Caso seja uma criação fora da thread principal, cria o form de entrevista
            var novoForm = (Form)(threadPrincipal ?
                Activator.CreateInstance(tipoNovoForm) :
                new frmEntrevista());

            if (threadPrincipal)
            {
                novoForm.Show();
                novoForm.TopMost = true;
                novoForm.ControlBox = false;
                novoForm.Activate();
            }

            novoForm.AutoScaleMode = AutoScaleMode.None;
            
            //var statusBar = RecuperaControles(novoForm).OfType<StatusBar>().FirstOrDefault();
            //if (statusBar != null)
            //    InscreveForm(novoForm, statusBar);

            novoForm.Closed += form_Closed;

            if (threadPrincipal)
                return TrocarFormAtual(tipoNovoForm, novoForm);

            return novoForm;
        }

        /// <summary>
        /// Para não perder dados do Form Anterior
        /// </summary>
        /// <param name="novoForm">Novo form</param>
        public static Form DialogForm(Type tipoNovoForm)
        {
            var novoForm = (Form)Activator.CreateInstance(tipoNovoForm);
            novoForm.Show();
            novoForm.TopMost = true;
            novoForm.ControlBox = false;
            novoForm.AutoScaleMode = AutoScaleMode.None;
            novoForm.Activate();
            //var statusBar = RecuperaControles(novoForm).OfType<StatusBar>().FirstOrDefault();
            //if (statusBar != null)
            //    InscreveForm(novoForm, statusBar);

            //formAtual = novoForm;

            return novoForm;
        }

        /// <summary>
        /// Caso o form fechando seja o atual, exibe o form anterior e remove o form da lista de notificação de mensagens
        /// </summary>
        /// <param name="sender">Form fechado</param>
        /// <param name="e">Evento</param>
        static void novoForm_Closed(object sender, EventArgs e)
        {
            Type fecharForm = FormsAbertos.Peek();
            FormsAbertos.Pop();

            while (fecharForm == FormsAbertos.Peek())
                FormsAbertos.Pop();

            AbreForm(FormsAbertos.Pop());
        }

        /// <summary>
        /// atualiza os StatusBar com a útlima mensagem de Log
        /// </summary>
        /// <param name="mensagem">Mensagem de log</param>
        private static void notificaMensagem(String mensagem)
        {
            try
            {
                foreach (var item in dicStatus.Values)
                    if (!item.IsDisposed)
                        if (item.InvokeRequired)
                            item.Invoke(new Action<Control, String>((controle, texto) => controle.Text = texto), new Object[] { item, mensagem });
                        else
                            item.Text = mensagem;
            }
            catch
            {                
            }
            Application.DoEvents();
        }

        /// <summary>
        /// Inscreve um form para ter um campo setado com as mensagens de log.
        /// A inscrição é desfeita automaticamente quando o form é fechado.
        /// </summary>
        /// <param name="form">Form a ser incrito</param>
        /// <param name="controle">Controle que deve receber a mensagem</param>
        public static void InscreveForm(Form form, Control controle)
        {
            if (!dicStatus.ContainsKey(form.Handle))
                dicStatus.Add(form.Handle, controle);
        }

        /// <summary>
        /// Enumera todos controes contidos em um controle
        /// </summary>
        /// <param name="controle">Controle</param>
        /// <returns>Itens contidos no controle e seus subitens</returns>
        public static IEnumerable<Control> RecuperaControles(Control controle)
        {
            foreach (var item in controle.Controls.OfType<Control>())
            {
                yield return item;
                foreach (var subItem in RecuperaControles(item))
                    yield return subItem;
            }
        }

        #endregion

        #region [ CONTROLS ]

        private void SignalActivity(bool IsUserActive)
        {
            if (Program.Usuario != null && Program.IDUsuario > 0 && IsUserActive)
            {
                timerLogOff.Enabled = false;
                timerLogOff.Interval = Program.TempoLogOff * 1000 * 60;
                timerLogOff.Enabled = true;
            }
        }

        private void timerLogOff_Tick(object sender, EventArgs e)
        {

            if (FormsAbertos.Peek() != typeof(frmLogin) && FormsAbertos.Peek() != typeof(frmAtualizacao) &&

            (Program.TempoLogOff > 0))
            {
                LimparPilha();
            }
            else
            {
                timerLogOff.Enabled = false;
            }
        }

        #endregion

        #region [ THREAD ENTREVISTA ]

        private static Boolean _threadEntrevistaAtiva;
        private static ManualResetEvent mreFormEntrevistaDisponivel;
        private static ManualResetEvent mreFormEntrevistaExibir;
        private static ManualResetEvent mreFormEntrevistaExibido;
        private static frmEntrevista formEntrevista;

        private static void AgendarCriacaoEntrevista()
        {
            mreFormEntrevistaDisponivel.Reset();
            ThreadPool.QueueUserWorkItem(new WaitCallback(CriarFormEntrevista));
        }

        /// <summary>
        /// Metodo responsável pelo ciclo de vida do formEntrevista
        /// </summary>
        /// <param name="state">Ignorado, apenas para atender a interface esperada por um callback do ThreadPool</param>
        private static void CriarFormEntrevista(Object state)
        {
            var form = formEntrevista = (frmEntrevista)AbreForm(typeof(frmEntrevista), false);
            mreFormEntrevistaDisponivel.Set();
            mreFormEntrevistaExibir.WaitOne();
            mreFormEntrevistaExibir.Reset();
            AgendarCriacaoEntrevista();
            TrocarFormAtual(typeof(frmEntrevista), form);            
            form.WindowState = FormWindowState.Maximized;
            mreFormEntrevistaExibido.Set();
            form.ShowDialog();           
        }

        private static frmEntrevista ExibirFormEntrevista()
        {
            while (!mreFormEntrevistaDisponivel.WaitOne(100, false))
                Application.DoEvents();
            mreFormEntrevistaExibir.Set();
            while (!mreFormEntrevistaExibido.WaitOne(100, false))
                Application.DoEvents();
            mreFormEntrevistaExibido.Reset();
            return formEntrevista;
        }

        #endregion
    }
}
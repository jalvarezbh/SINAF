using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Reflection;
using System.Timers;
using log4net;
[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace ProjetoService
{
    partial class importacaoService : ServiceBase
    {
        private static readonly ILog Log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
               
        private Timer _Timer;
        
        public importacaoService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Log.Info("Serviço Importação da Base SINAF iniciado às " + DateTime.Now);

            try
            {
                EventLog.WriteEntry("Inicio Timer " + DateTime.Now);

                System.IO.Directory.SetCurrentDirectory(System.AppDomain.CurrentDomain.BaseDirectory);

                ExecutarSincronismo();

                int? valor = new ServiceBaseSINAF.SyncSINAFSoapClient().ObterPrimeiroServico();

                _Timer = new Timer(86400000);

                if (valor.HasValue)
                    if (valor > 0)
                        _Timer = new Timer(valor.Value * 86400000);


                _Timer.Elapsed += timer_Elapsed;

                _Timer.Enabled = true;

                _Timer.Start();

            }
            catch (Exception ex)
            {
                Log.Error("Ocorreu um erro ao iniciar o sincronismo", ex);
            }
        }

        protected override void OnStop()
        {
            Log.Info("Serviço Importação da Base SINAF parado às " + DateTime.Now);
            _Timer.Stop();
        }

        public void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            ExecutarSincronismo();
        }

        public void ExecutarSincronismo()
        {
            try
            {   
                Log.Info("Importação SINAF Base Dados iniciado às " + DateTime.Now);
                                
                if (new ServiceBaseSINAF.SyncSINAFSoapClient().ImportarBaseSINAF())
                    Log.Info("SINAF Base Dados importação com sucesso.");
                else
                    Log.Info("SINAF Base Dados Básico erro na importação.");

                Log.Info("Importação SINAF Base Dados finalizado às " + DateTime.Now);

                Log.Info("Importação SINAF Base Correios iniciado às " + DateTime.Now);

                if (new ServiceBaseSINAF.SyncSINAFSoapClient().ImportarBancoCorreio())
                    Log.Info("SINAF Base Correios importação com sucesso.");
                else
                    Log.Info("SINAF Base Correios erro na importação.");

                Log.Info("Importação SINAF Base Correios finalizado às " + DateTime.Now);
            }
            catch (Exception ex)
            {
                //EventLog.WriteEntry("Erro Importação. " + ex.Message);
                Log.Error("Ocorreu um erro ao executar o sincronismo", ex);
            }
        }
    }
}

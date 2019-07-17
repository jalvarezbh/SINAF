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

namespace ProjetoServiceExportacao
{
    partial class exportacaoService : ServiceBase
    {
        private static readonly ILog Log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
               
        private Timer _Timer;
        
        public exportacaoService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Log.Info("Serviço exportação para a base SINAF iniciado às " + DateTime.Now);

            try
            {
                EventLog.WriteEntry("Inicio Timer " + DateTime.Now);

                System.IO.Directory.SetCurrentDirectory(System.AppDomain.CurrentDomain.BaseDirectory);

                ExecutarExportacao();

                _Timer = new Timer(1800000);

                _Timer.Elapsed += timer_Elapsed;

                _Timer.Enabled = true;

                _Timer.Start();

            }
            catch (Exception ex)
            {
                Log.Error("Ocorreu um erro ao iniciar a exportação", ex);
            }
        }

        protected override void OnStop()
        {
            Log.Info("Serviço exportação para a Base SINAF parado às " + DateTime.Now);
            _Timer.Stop();
        }

        public void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (DateTime.Now.Hour >= 8 && DateTime.Now.Hour <= 20)
                ExecutarExportacao();
        }

        public void ExecutarExportacao()
        {
            try
            {
                Log.Info("Exportação para a Base SINAF iniciado às " + DateTime.Now);
                if (new ServiceBaseSINAF.SyncSINAFSoapClient().ExportarBaseSINAF())
                {
                    Log.Info("Exportação realizada com sucesso.");
                }
                else
                {
                   Log.Info("Erro na exportação para a Base SINAF.");
                }
            }
            catch (Exception ex)
            {
                Log.Error("Ocorreu um erro ao executar a exportação", ex);
            }
        }
    }
}

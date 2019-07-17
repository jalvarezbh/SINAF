using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace ProjetoService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            ////teste
            //importacaoService teste = new importacaoService();
            //teste.timer_Elapsed(null,null);

            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
            { 
                new importacaoService() 
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}

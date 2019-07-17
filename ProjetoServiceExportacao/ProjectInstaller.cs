using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;


namespace ProjetoServiceExportacao
{
    [RunInstaller(true)]
    public partial class ProjectInstaller2 : Installer
    {
        public ProjectInstaller2()
        {
            InitializeComponent();
        }
    }
}

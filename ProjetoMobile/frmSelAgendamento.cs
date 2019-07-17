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

namespace ProjetoMobile
{
    public partial class frmSelAgendamento : Form
    {
        #region [ PROPERTIES ]

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
        
        #endregion

        #region [ LOAD ]

        public frmSelAgendamento()
        {
            InitializeComponent();
            FocusOn();
            FocusOff();
            KeyDownTecla();
            KeyUpTecla();
            ModeloGrid();
        }

        #endregion

        #region [ METHODS ]

        private void ModeloGrid()
        {
            var estiloGrid = new DataGridTableStyle();
            estiloGrid.MappingName = "TAgendamento";
                        
            estiloGrid.GridColumnStyles.Add(new DataGridTextBoxColumn()
            {
                HeaderText = "Nome",
                MappingName = "Nome",
                Width = 250,
                NullText = " "
            });

            estiloGrid.GridColumnStyles.Add(new DataGridTextBoxColumn()
            {
                HeaderText = "Telefone",
                MappingName = "Telefone",
                NullText = " ",
                Width = 150
            });           

            dtgSelAgendamento.TableStyles.Add(estiloGrid);

            RecuperarDados();
        }

        private void RecuperarDados()
        {
            DataTable dadosGrid = ControllerAgendamento.SelecioneAgendamento(0);

            if (dadosGrid.Rows.Count > 0)
            {
                this.dtgSelAgendamento.Enabled = false;
                this.dtgSelAgendamento.DataBindings.Clear();
                this.dtgSelAgendamento.DataSource = dadosGrid;
                this.dtgSelAgendamento.DataBindings.Add("Tag", dtgSelAgendamento.DataSource, "IDAgendamento");
                dtgSelAgendamento.Enabled = true;
            }
        }

        #endregion

        #region [ CONTROLS ]

        private void dtgSelAgendamento_Click(object sender, EventArgs e)
        {
            Program.IDAgendamento = Convert.ToInt32(dtgSelAgendamento.Tag);
            Program.AbreForm<frmAgendamento>();            
        }

        private void FocusOn()
        {            
            bntSair.GotFocus += new EventHandler(Program.btn_focusOn);
        }

        private void FocusOff()
        {            
            bntSair.LostFocus += new EventHandler(Program.btn_focusOffAzul);
        }

        private void KeyDownTecla()
        {
            //Only button and check           
            bntSair.KeyDown += new KeyEventHandler(Program.btn_enter);
        }

        private void KeyUpTecla()
        {            
            bntSair.KeyUp += new KeyEventHandler(Program.btn_next);
        }

        #endregion

        #region [ BUTTONS ]

        private void bntSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion                
       
    }
}
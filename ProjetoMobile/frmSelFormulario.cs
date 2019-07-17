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
using DataGridCustomColumns;
using ProjetoMobile.Util;

namespace ProjetoMobile
{
    public partial class frmSelFormulario : Form
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

        #endregion

        #region [ LOAD ]

        public frmSelFormulario()
        {
            InitializeComponent();
            MostraCursor.CursorAguarde(true);
            FocusOn();
            FocusOff();
            KeyDownTecla();
            KeyUpTecla();
            ModeloGrid();
            MostraCursor.CursorAguarde(false);
        }

        #endregion

        #region [ METHODS ]

        private void ModeloGrid()
        {
            var estiloGrid = new DataGridTableStyle();
            estiloGrid.MappingName = "Formulario";

            estiloGrid.GridColumnStyles.Add(new DataGridCustomLightColumn()
            {
                Owner = dtgSelFormulario,
                HeaderText = " ",
                MappingName = "Completa",
                NullText = "-Unknown-",
                Width = 33,
                ReadOnly = true,
                Alignment = HorizontalAlignment.Center,
                AlternatingBackColor = Color.White,
            });


            estiloGrid.GridColumnStyles.Add(new DataGridTextBoxColumn()
            {
                HeaderText = "Nome",
                MappingName = "Nome",
                Width = 260,
                NullText = " "
            });

            estiloGrid.GridColumnStyles.Add(new DataGridTextBoxColumn()
            {
                HeaderText = "Data",
                MappingName = "DataEntrevista",
                Format = "dd/MM/yyyy",
                NullText = " ",
                Width = 120
            });

            estiloGrid.GridColumnStyles.Add(new DataGridTextBoxColumn()
            {
                HeaderText = "Motivo",
                MappingName = "Motivo",
                NullText = " ",
                Width = 400
            });

            dtgSelFormulario.TableStyles.Add(estiloGrid);

            RecuperarDados();
        }

        private void RecuperarDados()
        {
            ControllerEntrevista.ValidarEntrevistaCompleta();
            DataTable dadosGrid = ControllerEntrevista.ListaEntrevistaEntrevistado();

            this.dtgSelFormulario.Enabled = false;
            this.dtgSelFormulario.DataBindings.Clear();
            this.dtgSelFormulario.DataSource = dadosGrid;
            this.dtgSelFormulario.DataBindings.Add("Tag", dtgSelFormulario.DataSource, "CodigoEntrevista");
            dtgSelFormulario.Enabled = true;
        }

        #endregion

        #region [ CONTROLS ]

        private void dtgSelFormulario_Click(object sender, EventArgs e)
        {
            Program.CodigoEntrevista = Convert.ToInt64(dtgSelFormulario.Tag);
            Program.AbreForm<frmEntrevista>();
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
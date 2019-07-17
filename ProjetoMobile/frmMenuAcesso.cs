using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ProjetoMobile.Util;

namespace ProjetoMobile
{
    public partial class frmMenuAcesso : Form
    {
        #region [ LOAD ]

        public frmMenuAcesso()
        {
            InitializeComponent();

            FocusOn();
            FocusOff();
            KeyDownTecla();
            KeyUpTecla();
        }

        private void frmMenuAcesso_Load(object sender, EventArgs e)
        {
            if (Program.CountFaixa > 0)
                imageList1.Images.Add(ProjetoMobile.Properties.Resources.Menu_note_edit);
            else
                imageList1.Images.Add(ProjetoMobile.Properties.Resources.Menu_note_remove);

            imageList1.Images.Add(ProjetoMobile.Properties.Resources.Menu_note_accept);
            imageList1.Images.Add(ProjetoMobile.Properties.Resources.Menu_folder_edit);
            imageList1.Images.Add(ProjetoMobile.Properties.Resources.Menu_folder_accept);
            imageList1.Images.Add(ProjetoMobile.Properties.Resources.Menu_folder_tabelas);
            ListViewItem item;

            item = new ListViewItem();
            item.ImageIndex = 0;
            item.Text = "Entrevista";
            this.lvMenu.Items.Add(item);

            item = new ListViewItem();
            item.ImageIndex = 1;
            item.Text = "Consultas";
            this.lvMenu.Items.Add(item);

            item = new ListViewItem();
            item.ImageIndex = 2;
            item.Text = "Agendar";
            this.lvMenu.Items.Add(item);

            item = new ListViewItem();
            item.ImageIndex = 3;
            item.Text = "Agendamento";
            this.lvMenu.Items.Add(item);

            item = new ListViewItem();
            item.ImageIndex = 4;
            item.Text = "Tabelas";
            this.lvMenu.Items.Add(item);

            lvMenu.View = View.LargeIcon;

            lvMenu.Refresh();

            this.Refresh();

            lvMenu.Focus();
        }

        private void frmMenuAcesso_Activated(object sender, EventArgs e)
        {
        }

        private void frmMenuAcesso_Closed(object sender, EventArgs e)
        {
        }

        private void frmMenuAcesso_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(27))
                butSair_Click(sender, e);
        }

        #endregion

        #region [ CONTROLS ]

        private void lvMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Util.MostraCursor.CursorAguarde(true);

                if (lvMenu.FocusedItem != null)
                {
                    switch (lvMenu.FocusedItem.Index)
                    {
                        case 0:
                            if (Program.CountFaixa > 0)
                            {
                                Program.IncluirRegistro = true;
                                Program.CodigoEntrevista = 0;
                                Program.AbreForm<frmEntrevista>();
                            }
                            else
                            {
                                CaixaMensagem.ExibirOk("Não existe faixa disponível! Favor sincronizar o coletor.");
                                return;
                            }
                            break;
                        case 1:
                            Program.IncluirRegistro = false;
                            Program.FormularioSeleciona = "frmEntrevista";
                            Program.AbreForm<frmSelFormulario>();
                            break;
                        case 2:
                            Program.IDAgendamento = 0;
                            Program.AbreForm<frmAgendamento>();
                            break;
                        case 3:
                            Program.FormularioSeleciona = "frmAgendamento";
                            Program.AbreForm<frmSelAgendamento>();
                            break;
                        case 4:
                            Program.AbreForm<frmTabela>();
                            break;
                    }

                    this.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Util.MostraCursor.CursorAguarde(false);
            }            
        }

        private void FocusOn()
        {
            btnSair.GotFocus += new EventHandler(Program.btn_focusOn);
        }

        private void FocusOff()
        {
            btnSair.LostFocus += new EventHandler(Program.btn_focusOffAzul);
        }

        private void KeyDownTecla()
        {
            //Only button and check
            btnSair.KeyDown += new KeyEventHandler(Program.btn_enter);
        }

        private void KeyUpTecla()
        {
            btnSair.KeyUp += new KeyEventHandler(Program.btn_next);
        }

        #endregion

        #region [ BUTTONS ]

        private void butSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}
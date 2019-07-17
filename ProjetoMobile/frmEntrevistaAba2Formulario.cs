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
using System.Globalization;
using ProjetoMobile.Util;

namespace ProjetoMobile
{
    public partial class frmEntrevista
    {
        #region [ PROPERTIES ]

        private List<TRespostaDOMINIO> dadosTRespostaSub1;

        public List<TRespostaDOMINIO> DadosTRespostaSub1
        {
            get
            {
                if (dadosTRespostaSub1 == null)
                    dadosTRespostaSub1 = new List<TRespostaDOMINIO>();

                return dadosTRespostaSub1;
            }
            set
            {
                dadosTRespostaSub1 = value;
            }
        }

        private List<TRespostaDOMINIO> dadosTRespostaSub2;

        public List<TRespostaDOMINIO> DadosTRespostaSub2
        {
            get
            {
                if (dadosTRespostaSub2 == null)
                    dadosTRespostaSub2 = new List<TRespostaDOMINIO>();

                return dadosTRespostaSub2;
            }
            set
            {
                dadosTRespostaSub2 = value;
            }
        }

        private List<TRespostaDOMINIO> dadosTRespostaSub3;

        public List<TRespostaDOMINIO> DadosTRespostaSub3
        {
            get
            {
                if (dadosTRespostaSub3 == null)
                    dadosTRespostaSub3 = new List<TRespostaDOMINIO>();

                return dadosTRespostaSub3;
            }
            set
            {
                dadosTRespostaSub3 = value;
            }
        }

        private List<TRespostaDOMINIO> dadosTRespostaSub4;

        public List<TRespostaDOMINIO> DadosTRespostaSub4
        {
            get
            {
                if (dadosTRespostaSub4 == null)
                    dadosTRespostaSub4 = new List<TRespostaDOMINIO>();

                return dadosTRespostaSub4;
            }
            set
            {
                dadosTRespostaSub4 = value;
            }
        }

        private List<TRespostaDOMINIO> dadosTRespostaSub5;

        public List<TRespostaDOMINIO> DadosTRespostaSub5
        {
            get
            {
                if (dadosTRespostaSub5 == null)
                    dadosTRespostaSub5 = new List<TRespostaDOMINIO>();

                return dadosTRespostaSub5;
            }
            set
            {
                dadosTRespostaSub5 = value;
            }
        }

        private List<TRespostaDOMINIO> dadosTRespostaSub6;

        public List<TRespostaDOMINIO> DadosTRespostaSub6
        {
            get
            {
                if (dadosTRespostaSub6 == null)
                    dadosTRespostaSub6 = new List<TRespostaDOMINIO>();

                return dadosTRespostaSub6;
            }
            set
            {
                dadosTRespostaSub6 = value;
            }
        }

        private List<TRespostaDOMINIO> dadosTRespostaSub7;

        public List<TRespostaDOMINIO> DadosTRespostaSub7
        {
            get
            {
                if (dadosTRespostaSub7 == null)
                    dadosTRespostaSub7 = new List<TRespostaDOMINIO>();

                return dadosTRespostaSub7;
            }
            set
            {
                dadosTRespostaSub7 = value;
            }
        }

        private DataTable _dadosCmbAba2Sub1Grau;
        public DataTable DadosCmbAba2Sub1Grau
        {
            get { return _dadosCmbAba2Sub1Grau; }
            set { _dadosCmbAba2Sub1Grau = value; }
        }

        private string _textoCmbAba2Sub1Grau;
        public string TextoCmbAba2Sub1Grau
        {
            get { return _textoCmbAba2Sub1Grau; }
            set { _textoCmbAba2Sub1Grau = value; }
        }

        private DataTable _dadosCmbAba2Sub2Renda;
        public DataTable DadosCmbAba2Sub2Renda
        {
            get { return _dadosCmbAba2Sub2Renda; }
            set { _dadosCmbAba2Sub2Renda = value; }
        }

        private string _textoCmbAba2Sub2Renda;
        public string TextoCmbAba2Sub2Renda
        {
            get { return _textoCmbAba2Sub2Renda; }
            set { _textoCmbAba2Sub2Renda = value; }
        }

        #endregion

        #region [ RECOVER ]

        private void PopularCombosAbaFormulario()
        {
            try
            {
                cmbAba2Sub1Grau.DisplayMember = "Value";
                cmbAba2Sub1Grau.ValueMember = "Key";
                cmbAba2Sub1Grau.DataSource = ControllerEnum.ListaDeParentesco(true, false);
                DadosCmbAba2Sub1Grau = ControllerEnum.ListaDeParentesco(true, false);
                TextoCmbAba2Sub1Grau = string.Empty;

                cmbAba2Sub2Renda.DisplayMember = "Value";
                cmbAba2Sub2Renda.ValueMember = "Key";
                cmbAba2Sub2Renda.DataSource = ControllerEnum.ListaDePerguntaRenda();
                DadosCmbAba2Sub2Renda = ControllerEnum.ListaDePerguntaRenda();
                TextoCmbAba2Sub2Renda = string.Empty;
            }
            catch (Exception ex)
            {
                Util.LogErro.GravaLog("Erro ao popular Aba Formulário.", ex.Message);
            }
        }

        private void PreencherCamposAbaFormulario()
        {
            try
            {
                if (Program.CodigoEntrevista > 0)
                {
                    DataTable tableTResposta = ControllerResposta.SelecioneResposta(Program.CodigoEntrevista);

                    string respostaABA1 = string.Empty;
                    lstAba2Sub1Parentes.Items.Clear();

                    if (tableTResposta.Rows.Count == 0)
                    {
                        if (DadosTEntrevistado.DataNascimentoConjuge.HasValue)
                        {
                            TimeSpan tempo = DateTime.Now - DadosTEntrevistado.DataNascimentoConjuge.Value;
                            int ano = (int)Math.Floor(tempo.TotalDays / 365.25);

                            lstAba2Sub1Parentes.Items.Add(GrauParentesco.CONJUGE.GetStringValue() + " - " + ano.ToString() + " - Não");
                        }
                    }

                    foreach (DataRow item in tableTResposta.Rows)
                    {
                        switch (Convert.ToInt32(item["CodigoPergunta"]))
                        {
                            case (int)CodigoPergunta.ABA1:

                                #region [ ABA 1 ]

                                switch (Convert.ToInt32(item["CodigoSeqResposta"]))
                                {
                                    case (int)CodigoSeqPergunta.PARENTESCO:
                                        respostaABA1 = item["TextoResposta"].ToString();
                                        break;
                                    case (int)CodigoSeqPergunta.IDADE:
                                        respostaABA1 += " - " + item["TextoResposta"].ToString();
                                        break;
                                    case (int)CodigoSeqPergunta.AJUDADESPESA:
                                        respostaABA1 += " - " + item["TextoResposta"].ToString();
                                        lstAba2Sub1Parentes.Items.Add(respostaABA1);
                                        break;
                                    default:
                                        break;
                                }

                                lblAba2Sub1NumeroParentesValor.Text = lstAba2Sub1Parentes.Items.Count.ToString();

                                #endregion

                                break;

                            case (int)CodigoPergunta.ABA2:

                                #region [ ABA 2 ]

                                cmbAba2Sub2Renda.SelectedValue = item["CodigoOpcao"].ToString();
                                Resposta2 = Convert.ToInt32(cmbAba2Sub2Renda.SelectedValue);
                                #endregion

                                break;

                            case (int)CodigoPergunta.ABA3:

                                #region [ ABA 3 ]

                                PreencherABA2SUB3(Convert.ToInt32(item["CodigoOpcao"]), item["TextoSubResposta"].ToString());

                                #endregion

                                break;

                            case (int)CodigoPergunta.ABA4:

                                #region [ ABA 4 ]

                                PreencherABA2SUB4(Convert.ToInt32(item["CodigoOpcao"]), item["TextoResposta"].ToString());

                                #endregion

                                break;

                            case (int)CodigoPergunta.ABA5:

                                #region [ ABA 5 ]

                                PreencherABA2SUB5(Convert.ToInt32(item["CodigoOpcao"]));

                                //if (Convert.ToInt32(item["CodigoOpcao"]) == 2)
                                PreencherABA2SUB5N(Convert.ToInt32(item["CodigoSeqResposta"]), item["TextoSubResposta"].ToString());

                                #endregion

                                break;

                            case (int)CodigoPergunta.ABA6:

                                #region [ ABA 6 ]

                                PreencherABA2SUB6(Convert.ToInt32(item["CodigoOpcao"]));

                                #endregion

                                break;

                            case (int)CodigoPergunta.ABA7:

                                #region [ ABA 7 ]

                                PreencherABA2SUB7(Convert.ToInt32(item["CodigoOpcao"]));

                                #endregion

                                break;

                            default:
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Util.LogErro.GravaLog("Erro ao preencher Aba Formulário.", ex.Message);
            }
        }

        private void BloquearCamposAbaFormulario()
        {
            try
            {
                cmbAba2Sub1Grau.Enabled = false;
                txtAba2Sub1Idade.Enabled = false;
                chkAba2Sub1Sim.Enabled = false;
                chkAba2Sub1Nao.Enabled = false;
                lstAba2Sub1Parentes.Enabled = false;
                btnAba2Sub1Adicionar.Enabled = false;
                btnAba2Sub1Remover.Enabled = false;
                cmbAba2Sub2Renda.Enabled = false;
                chkAba2Sub3Junta.Enabled = false;
                chkAba2Sub3Casa.Enabled = false;
                chkAba2Sub3Nada.Enabled = false;
                chkAba2Sub3Outro.Enabled = false;
                txtAba2Sub3Outro.Enabled = false;
                txtAba2Sub4Prepara.Enabled = false;
                chkAba2Sub4NaoPrepara.Enabled = false;
                chkAba2Sub5Sim.Enabled = false;
                chkAba2Sub5Nao.Enabled = false;
                chkAba2Sub5Tem.Enabled = false;
                chkAba2Sub5Nunca.Enabled = false;
                chkAba2Sub5Jateve.Enabled = false;
                txtAba2Sub5JateveQual.Enabled = false;
                chkAba2Sub6Sim.Enabled = false;
                chkAba2Sub6Nao.Enabled = false;
                chkAba2Sub7v15.Enabled = false;
                chkAba2Sub7v20.Enabled = false;
                chkAba2Sub7v25.Enabled = false;
                chkAba2Sub7v30.Enabled = false;
                chkAba2Sub7v35.Enabled = false;
                chkAba2Sub7v45.Enabled = false;
                chkAba2Sub7v55.Enabled = false;
                chkAba2Sub7v65.Enabled = false;
                chkAba2Sub7v75.Enabled = false;
                chkAba2Sub7v90.Enabled = false;
                chkAba2Sub7v110.Enabled = false;


            }
            catch (Exception ex)
            {
                Util.LogErro.GravaLog("Erro ao desativar campos Aba Formulário.", ex.Message);
            }

        }

        private void PreencherABA2SUB3(int codigo, string resposta)
        {
            chkAba2Sub3Junta.Checked = false;
            chkAba2Sub3Casa.Checked = false;
            chkAba2Sub3Nada.Checked = false;
            chkAba2Sub3Outro.Checked = false;
            txtAba2Sub3Outro.Text = string.Empty;

            switch (codigo)
            {
                case 1:
                    chkAba2Sub3Junta.Checked = true;
                    break;
                case 2:
                    chkAba2Sub3Casa.Checked = true;
                    break;
                case 3:
                    chkAba2Sub3Nada.Checked = true;
                    break;
                case 4:
                    chkAba2Sub3Outro.Checked = true;
                    txtAba2Sub3Outro.Text = resposta;
                    break;
                default:
                    break;
            }
        }

        private void PreencherABA2SUB4(int codigo, string resposta)
        {
            txtAba2Sub4Prepara.Text = string.Empty;
            chkAba2Sub4NaoPrepara.Checked = false;

            switch (codigo)
            {
                case 1:
                    txtAba2Sub4Prepara.Text = resposta;
                    break;
                case 2:
                    chkAba2Sub4NaoPrepara.Checked = true;
                    break;
                default:
                    break;
            }
        }

        private void PreencherABA2SUB5(int codigo)
        {
            chkAba2Sub5Sim.Checked = false;
            chkAba2Sub5Nao.Checked = false;
            switch (codigo)
            {
                case 1:
                    chkAba2Sub5Sim.Checked = true;
                    break;
                case 2:
                    chkAba2Sub5Nao.Checked = true;
                    break;
                default:
                    break;
            }
        }

        private void PreencherABA2SUB5N(int codigo, string resposta)
        {
            chkAba2Sub5Tem.Checked = false;
            chkAba2Sub5Jateve.Checked = false;
            chkAba2Sub5Nunca.Checked = false;
            txtAba2Sub5JateveQual.Text = string.Empty;
            txtAba2Sub5JateveQual.Enabled = false;
            txtAba2Sub5JateveQual.BackColor = System.Drawing.Color.Gainsboro;

            switch (codigo)
            {
                case 1:
                    chkAba2Sub5Tem.Checked = true;
                    txtAba2Sub5JateveQual.Enabled = true;
                    txtAba2Sub5JateveQual.BackColor = System.Drawing.Color.White;
                    txtAba2Sub5JateveQual.Text = resposta;
                    break;
                case 2:
                    chkAba2Sub5Jateve.Checked = true;
                    txtAba2Sub5JateveQual.Enabled = true;
                    txtAba2Sub5JateveQual.BackColor = System.Drawing.Color.White;
                    txtAba2Sub5JateveQual.Text = resposta;
                    break;
                case 3:
                    chkAba2Sub5Nunca.Checked = true;
                    break;
                default:
                    break;
            }
        }

        private void PreencherABA2SUB6(int codigo)
        {
            chkAba2Sub6Sim.Checked = false;
            chkAba2Sub6Nao.Checked = false;

            switch (codigo)
            {
                case 1:
                    chkAba2Sub6Sim.Checked = true;
                    break;
                case 2:
                    chkAba2Sub6Nao.Checked = true;
                    break;
                default:
                    break;
            }
        }

        private void PreencherABA2SUB7(int codigo)
        {
            chkAba2Sub7v15.Checked = false;
            chkAba2Sub7v20.Checked = false;
            chkAba2Sub7v25.Checked = false;
            chkAba2Sub7v30.Checked = false;
            chkAba2Sub7v35.Checked = false;
            chkAba2Sub7v45.Checked = false;
            chkAba2Sub7v55.Checked = false;
            chkAba2Sub7v65.Checked = false;
            chkAba2Sub7v75.Checked = false;
            chkAba2Sub7v90.Checked = false;
            chkAba2Sub7v110.Checked = false;
            Resposta7 = codigo;

            switch (codigo)
            {
                case 1:
                    chkAba2Sub7v15.Checked = true;
                    break;
                case 2:
                    chkAba2Sub7v20.Checked = true;
                    break;
                case 3:
                    chkAba2Sub7v25.Checked = true;
                    break;
                case 4:
                    chkAba2Sub7v30.Checked = true;
                    break;
                case 5:
                    chkAba2Sub7v35.Checked = true;
                    break;
                case 6:
                    chkAba2Sub7v45.Checked = true;
                    break;
                case 7:
                    chkAba2Sub7v55.Checked = true;
                    break;
                case 8:
                    chkAba2Sub7v65.Checked = true;
                    break;
                case 9:
                    chkAba2Sub7v75.Checked = true;
                    break;
                case 10:
                    chkAba2Sub7v90.Checked = true;
                    break;
                case 11:
                    chkAba2Sub7v110.Checked = true;
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region [ FILL ]

        private void MapearCamposAbaFormularioSubAba1()
        {
            try
            {
                DadosTRespostaSub1 = new List<TRespostaDOMINIO>();

                int opcaoList = 0;
                foreach (string item in lstAba2Sub1Parentes.Items)
                {
                    opcaoList += 1;

                    if (!string.IsNullOrEmpty(item))
                    {
                        string[] dadosString = item.Split('-');

                        TRespostaDOMINIO dadosRespostaABA1A = new TRespostaDOMINIO();
                        dadosRespostaABA1A.CodigoEntrevista = DadosTEntrevista.CodigoEntrevista;
                        dadosRespostaABA1A.CodigoPergunta = (int)CodigoPergunta.ABA1;
                        dadosRespostaABA1A.CodigoOpcao = opcaoList;
                        dadosRespostaABA1A.CodigoSeqPergunta = (int)CodigoSeqPergunta.PARENTESCO;
                        dadosRespostaABA1A.TextoResposta = dadosString[0].ToString().Trim();

                        DadosTRespostaSub1.Add(dadosRespostaABA1A);

                        TRespostaDOMINIO dadosRespostaABA1B = new TRespostaDOMINIO();
                        dadosRespostaABA1B.CodigoEntrevista = DadosTEntrevista.CodigoEntrevista;
                        dadosRespostaABA1B.CodigoPergunta = (int)CodigoPergunta.ABA1;
                        dadosRespostaABA1B.CodigoOpcao = opcaoList;
                        dadosRespostaABA1B.CodigoSeqPergunta = (int)CodigoSeqPergunta.IDADE;
                        dadosRespostaABA1B.TextoResposta = dadosString[1].ToString().Trim();

                        DadosTRespostaSub1.Add(dadosRespostaABA1B);

                        TRespostaDOMINIO dadosRespostaABA1C = new TRespostaDOMINIO();
                        dadosRespostaABA1C.CodigoEntrevista = DadosTEntrevista.CodigoEntrevista;
                        dadosRespostaABA1C.CodigoPergunta = (int)CodigoPergunta.ABA1;
                        dadosRespostaABA1C.CodigoOpcao = opcaoList;
                        dadosRespostaABA1C.CodigoSeqPergunta = (int)CodigoSeqPergunta.AJUDADESPESA;
                        dadosRespostaABA1C.TextoResposta = dadosString[2].ToString().Trim();

                        DadosTRespostaSub1.Add(dadosRespostaABA1C);

                    }
                }
            }
            catch (Exception ex)
            {
                Util.LogErro.GravaLog("Erro ao mapear Aba Formulario.", ex.Message);
                Util.CaixaMensagem.ExibirOk("Erro ao mapear Aba Formulario Pergunta 1!");
            }
        }

        private void MapearCamposAbaFormularioSubAba2()
        {
            try
            {
                DadosTRespostaSub2 = new List<TRespostaDOMINIO>();

                TRespostaDOMINIO dadosRespostaABA2 = new TRespostaDOMINIO();

                dadosRespostaABA2.CodigoEntrevista = DadosTEntrevista.CodigoEntrevista;
                dadosRespostaABA2.CodigoPergunta = (int)CodigoPergunta.ABA2;
                dadosRespostaABA2.CodigoOpcao = Convert.ToInt32(cmbAba2Sub2Renda.SelectedValue);
                dadosRespostaABA2.CodigoSeqPergunta = (int)CodigoSeqPergunta.COMUM;
                dadosRespostaABA2.TextoResposta = cmbAba2Sub2Renda.Text;

                Resposta2 = Convert.ToInt32(cmbAba2Sub2Renda.SelectedValue);

                DadosTRespostaSub2.Add(dadosRespostaABA2);

            }
            catch (Exception ex)
            {
                Util.LogErro.GravaLog("Erro ao mapear Aba Formulario.", ex.Message);
                Util.CaixaMensagem.ExibirOk("Erro ao mapear Aba Formulario Pergunta 2!");
            }
        }

        private void MapearCamposAbaFormularioSubAba3()
        {
            try
            {
                DadosTRespostaSub3 = new List<TRespostaDOMINIO>();

                TRespostaDOMINIO dadosRespostaABA3 = new TRespostaDOMINIO();
                int idABA3 = 0;
                string respostaABA3 = string.Empty;
                string justificativaABA3 = string.Empty;

                VerficarABA2SUB3(ref idABA3, ref respostaABA3, ref justificativaABA3);
                dadosRespostaABA3.CodigoEntrevista = DadosTEntrevista.CodigoEntrevista;
                dadosRespostaABA3.CodigoPergunta = (int)CodigoPergunta.ABA3;
                dadosRespostaABA3.CodigoOpcao = idABA3;
                dadosRespostaABA3.CodigoSeqPergunta = (int)CodigoSeqPergunta.COMUM;
                dadosRespostaABA3.TextoResposta = respostaABA3;
                dadosRespostaABA3.TextoSubResposta = justificativaABA3;

                DadosTRespostaSub3.Add(dadosRespostaABA3);

            }
            catch (Exception ex)
            {
                Util.LogErro.GravaLog("Erro ao mapear Aba Formulario.", ex.Message);
                Util.CaixaMensagem.ExibirOk("Erro ao mapear Aba Formulario Pergunta 3!");
            }
        }

        private void MapearCamposAbaFormularioSubAba4()
        {
            try
            {
                DadosTRespostaSub4 = new List<TRespostaDOMINIO>();

                TRespostaDOMINIO dadosRespostaABA4 = new TRespostaDOMINIO();
                string respostaABA4 = string.Empty;

                dadosRespostaABA4.CodigoEntrevista = DadosTEntrevista.CodigoEntrevista;
                dadosRespostaABA4.CodigoPergunta = (int)CodigoPergunta.ABA4;
                dadosRespostaABA4.CodigoSeqPergunta = (int)CodigoSeqPergunta.COMUM;

                if (!string.IsNullOrEmpty(txtAba2Sub4Prepara.Text))
                {
                    dadosRespostaABA4.CodigoOpcao = 1;
                    dadosRespostaABA4.TextoResposta = txtAba2Sub4Prepara.Text;
                    DadosTRespostaSub4.Add(dadosRespostaABA4);
                }
                else if (chkAba2Sub4NaoPrepara.Checked)
                {
                    dadosRespostaABA4.CodigoOpcao = 2;
                    dadosRespostaABA4.TextoResposta = chkAba2Sub4NaoPrepara.Text;
                    DadosTRespostaSub4.Add(dadosRespostaABA4);
                }

            }
            catch (Exception ex)
            {
                Util.LogErro.GravaLog("Erro ao mapear Aba Formulario.", ex.Message);
                Util.CaixaMensagem.ExibirOk("Erro ao mapear Aba Formulario Pergunta 4!");
            }
        }

        private void MapearCamposAbaFormularioSubAba5()
        {
            try
            {
                DadosTRespostaSub5 = new List<TRespostaDOMINIO>();

                TRespostaDOMINIO dadosRespostaABA5 = new TRespostaDOMINIO();
                int idABA5 = 0;
                string respostaABA5 = string.Empty;
                VerficarABA2SUB5(ref idABA5, ref respostaABA5);
                dadosRespostaABA5.CodigoEntrevista = DadosTEntrevista.CodigoEntrevista;
                dadosRespostaABA5.CodigoPergunta = (int)CodigoPergunta.ABA5;
                dadosRespostaABA5.CodigoOpcao = idABA5;
                dadosRespostaABA5.CodigoSeqPergunta = (int)CodigoSeqPergunta.COMUM;
                dadosRespostaABA5.TextoResposta = respostaABA5;

                int idABA5N = 0;
                string respostaABA5N = string.Empty;

                //Dia 09/01/2014 - Conversado com a Fátima independente de ser sim ou não fica sempre visível a subpergunta
                VerficarABA2SUB5N(ref idABA5N, ref respostaABA5N);
                dadosRespostaABA5.CodigoSeqPergunta = idABA5N;
                dadosRespostaABA5.TextoSubResposta = respostaABA5N;
                
                DadosTRespostaSub5.Add(dadosRespostaABA5);

            }
            catch (Exception ex)
            {
                Util.LogErro.GravaLog("Erro ao mapear Aba Formulario.", ex.Message);
                Util.CaixaMensagem.ExibirOk("Erro ao mapear Aba Formulario Pergunta 5!");
            }
        }

        private void MapearCamposAbaFormularioSubAba6()
        {
            try
            {
                DadosTRespostaSub6 = new List<TRespostaDOMINIO>();

                TRespostaDOMINIO dadosRespostaABA6 = new TRespostaDOMINIO();
                int idABA6 = 0;
                string respostaABA6 = string.Empty;
                VerficarABA2SUB6(ref idABA6, ref respostaABA6);
                dadosRespostaABA6.CodigoEntrevista = DadosTEntrevista.CodigoEntrevista;
                dadosRespostaABA6.CodigoPergunta = (int)CodigoPergunta.ABA6;
                dadosRespostaABA6.CodigoOpcao = idABA6;
                dadosRespostaABA6.CodigoSeqPergunta = (int)CodigoSeqPergunta.COMUM;
                dadosRespostaABA6.TextoResposta = respostaABA6;

                DadosTRespostaSub6.Add(dadosRespostaABA6);

            }
            catch (Exception ex)
            {
                Util.LogErro.GravaLog("Erro ao mapear Aba Formulario.", ex.Message);
                Util.CaixaMensagem.ExibirOk("Erro ao mapear Aba Formulario Pergunta 6!");
            }
        }

        private void MapearCamposAbaFormularioSubAba7()
        {
            try
            {
                DadosTRespostaSub7 = new List<TRespostaDOMINIO>();

                TRespostaDOMINIO dadosRespostaABA7 = new TRespostaDOMINIO();
                int idABA7 = 0;
                string respostaABA7 = string.Empty;
                VerficarABA2SUB7(ref idABA7, ref respostaABA7);

                dadosRespostaABA7.CodigoEntrevista = DadosTEntrevista.CodigoEntrevista;
                dadosRespostaABA7.CodigoPergunta = (int)CodigoPergunta.ABA7;
                dadosRespostaABA7.CodigoOpcao = idABA7;
                dadosRespostaABA7.CodigoSeqPergunta = (int)CodigoSeqPergunta.COMUM;
                dadosRespostaABA7.TextoResposta = respostaABA7;

                DadosTRespostaSub7.Add(dadosRespostaABA7);

            }
            catch (Exception ex)
            {
                Util.LogErro.GravaLog("Erro ao mapear Aba Formulario.", ex.Message);
                Util.CaixaMensagem.ExibirOk("Erro ao mapear Aba Formulario Pergunta 7!");
            }
        }

        private string VerficarABA2SUB1()
        {
            if (chkAba2Sub1Sim.Checked)
                return "Sim";

            if (chkAba2Sub1Nao.Checked)
                return "Não";

            return "Não";
        }

        private void VerficarABA2SUB3(ref int id, ref string resposta, ref string justificativa)
        {
            id = 0;
            resposta = string.Empty;
            justificativa = string.Empty;

            if (chkAba2Sub3Junta.Checked)
            {
                id = 1;
                resposta = chkAba2Sub3Junta.Text;
                return;
            }

            if (chkAba2Sub3Casa.Checked)
            {
                id = 2;
                resposta = chkAba2Sub3Casa.Text;
                return;
            }

            if (chkAba2Sub3Nada.Checked)
            {
                id = 3;
                resposta = chkAba2Sub3Nada.Text;
                return;
            }

            if (chkAba2Sub3Outro.Checked)
            {
                id = 4;
                resposta = chkAba2Sub3Outro.Text;
                justificativa = txtAba2Sub3Outro.Text;
                return;
            }

        }

        private void VerficarABA2SUB5(ref int id, ref string resposta)
        {
            id = 0;
            resposta = string.Empty;

            if (chkAba2Sub5Sim.Checked)
            {
                id = 1;
                resposta = chkAba2Sub5Sim.Text;
                return;
            }

            if (chkAba2Sub5Nao.Checked)
            {
                id = 2;
                resposta = chkAba2Sub5Nao.Text;
                return;
            }

        }

        private void VerficarABA2SUB5N(ref int id, ref string resposta)
        {
            id = 0;
            resposta = string.Empty;

            if (chkAba2Sub5Tem.Checked)
            {
                id = 1;
                resposta = txtAba2Sub5JateveQual.Text;
                return;
            }

            if (chkAba2Sub5Jateve.Checked)
            {
                id = 2;
                resposta = txtAba2Sub5JateveQual.Text;
                return;
            }

            if (chkAba2Sub5Nunca.Checked)
            {
                id = 3;
                resposta = chkAba2Sub5Nunca.Text;
                return;
            }

        }

        private void VerficarABA2SUB6(ref int id, ref string resposta)
        {
            id = 0;
            resposta = string.Empty;

            if (chkAba2Sub6Sim.Checked)
            {
                id = 1;
                resposta = chkAba2Sub6Sim.Text;
                return;
            }

            if (chkAba2Sub6Nao.Checked)
            {
                id = 2;
                resposta = chkAba2Sub6Nao.Text;
                return;
            }

        }

        private void VerficarABA2SUB7(ref int id, ref string resposta)
        {
            id = 0;
            Resposta7 = 0;
            resposta = string.Empty;

            if (chkAba2Sub7v15.Checked)
            {
                id = 1;
                Resposta7 = 1;
                resposta = chkAba2Sub7v15.Text;
                return;
            }

            if (chkAba2Sub7v20.Checked)
            {
                id = 2;
                Resposta7 = 2;
                resposta = chkAba2Sub7v20.Text;
                return;
            }

            if (chkAba2Sub7v25.Checked)
            {
                id = 3;
                Resposta7 = 3;
                resposta = chkAba2Sub7v25.Text;
                return;
            }

            if (chkAba2Sub7v30.Checked)
            {
                id = 4;
                Resposta7 = 4;
                resposta = chkAba2Sub7v30.Text;
                return;
            }

            if (chkAba2Sub7v35.Checked)
            {
                id = 5;
                Resposta7 = 5;
                resposta = chkAba2Sub7v35.Text;
                return;
            }

            if (chkAba2Sub7v45.Checked)
            {
                id = 6;
                Resposta7 = 6;
                resposta = chkAba2Sub7v45.Text;
                return;
            }

            if (chkAba2Sub7v55.Checked)
            {
                id = 7;
                Resposta7 = 7;
                resposta = chkAba2Sub7v55.Text;
                return;
            }

            if (chkAba2Sub7v65.Checked)
            {
                id = 8;
                Resposta7 = 8;
                resposta = chkAba2Sub7v65.Text;
                return;
            }

            if (chkAba2Sub7v75.Checked)
            {
                id = 9;
                Resposta7 = 9;
                resposta = chkAba2Sub7v75.Text;
                return;
            }

            if (chkAba2Sub7v90.Checked)
            {
                id = 10;
                Resposta7 = 10;
                resposta = chkAba2Sub7v90.Text;
                return;
            }

            if (chkAba2Sub7v110.Checked)
            {
                id = 11;
                Resposta7 = 11;
                resposta = chkAba2Sub7v110.Text;
                return;
            }

        }

        private void AcertarFocuSubCampos()
        {
            switch (tabControlPerguntas.SelectedIndex)
            {
                case 0:
                    cmbAba2Sub1Grau.Focus();
                    SubAbaAnterior = 0;
                    break;
                case 1:
                    cmbAba2Sub2Renda.Focus();
                    SubAbaAnterior = 1;
                    break;
                case 2:
                    if (ValidarCamposAbaFormularioSubAba2())
                    {
                        chkAba2Sub3Junta.Focus();
                        SubAbaAnterior = 2;
                    }
                    else
                        tabControlPerguntas.SelectedIndex = SubAbaAnterior;
                    break;
                case 3:
                    if (ValidarCamposAbaFormularioSubAba2()
                     && ValidarCamposAbaFormularioSubAba3())
                    {
                        txtAba2Sub4Prepara.Focus();
                        SubAbaAnterior = 3;
                    }
                    else
                        tabControlPerguntas.SelectedIndex = SubAbaAnterior;
                    break;
                case 4:
                    if (ValidarCamposAbaFormularioSubAba2()
                     && ValidarCamposAbaFormularioSubAba3()
                     && ValidarCamposAbaFormularioSubAba4())
                    {
                        chkAba2Sub5Sim.Focus();
                        SubAbaAnterior = 4;
                    }
                    else
                        tabControlPerguntas.SelectedIndex = SubAbaAnterior;
                    break;
                case 5:
                    if (ValidarCamposAbaFormularioSubAba2()
                     && ValidarCamposAbaFormularioSubAba3()
                     && ValidarCamposAbaFormularioSubAba4()
                     && ValidarCamposAbaFormularioSubAba5())
                    {
                        chkAba2Sub6Sim.Focus();
                        SubAbaAnterior = 5;
                    }
                    else
                        tabControlPerguntas.SelectedIndex = SubAbaAnterior;
                    break;
                case 6:
                    if (ValidarCamposAbaFormularioSubAba2()
                     && ValidarCamposAbaFormularioSubAba3()
                     && ValidarCamposAbaFormularioSubAba4()
                     && ValidarCamposAbaFormularioSubAba5()
                     && ValidarCamposAbaFormularioSubAba6())
                    {
                        chkAba2Sub7v15.Focus();
                        SubAbaAnterior = 6;
                    }
                    else
                        tabControlPerguntas.SelectedIndex = SubAbaAnterior;
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region [ AUTHENTICATE ]

        private bool ValidarCamposAbaFormulario()
        {
            try
            {
                if (!ValidarCamposAbaFormularioSubAba2())
                    return false;

                if (!ValidarCamposAbaFormularioSubAba3())
                    return false;

                if (!ValidarCamposAbaFormularioSubAba4())
                    return false;

                if (!ValidarCamposAbaFormularioSubAba5())
                    return false;

                if (!ValidarCamposAbaFormularioSubAba6())
                    return false;

                if (!ValidarCamposAbaFormularioSubAba7())
                    return false;

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool ValidarCamposAbaFormularioSubAba2()
        {
            try
            {
                if (cmbAba2Sub2Renda.SelectedIndex <= 0)
                {
                    Util.MostraCursor.CursorAguarde(false);
                    Util.CaixaMensagem.ExibirOk("Formulário - Pergunta 2 é obrigatória!");
                    cmbAba2Sub2Renda.Focus();
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                Util.MostraCursor.CursorAguarde(false);
                Util.LogErro.GravaLog("Erro ao validar Aba Formulario Pergunta 2.", ex.Message);
                Util.CaixaMensagem.ExibirOk("Erro ao validar Aba Formulario Pergunta 2!");
                return false;
            }


        }

        private bool ValidarCamposAbaFormularioSubAba3()
        {
            try
            {
                if (!chkAba2Sub3Casa.Checked &&
                    !chkAba2Sub3Junta.Checked &&
                    !chkAba2Sub3Nada.Checked &&
                    !chkAba2Sub3Outro.Checked)
                {
                    Util.MostraCursor.CursorAguarde(false);
                    Util.CaixaMensagem.ExibirOk("Formulário - Pergunta 3 é obrigatória!");
                    chkAba2Sub3Junta.Focus();
                    return false;
                }

                if (chkAba2Sub3Outro.Checked && string.IsNullOrEmpty(txtAba2Sub3Outro.Text))
                {
                    Util.MostraCursor.CursorAguarde(false);
                    Util.CaixaMensagem.ExibirOk("Formulário - Pergunta 3 é obrigatório informar a descrição!");
                    txtAba2Sub3Outro.Focus();
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                Util.MostraCursor.CursorAguarde(false);
                Util.LogErro.GravaLog("Erro ao validar Aba Formulario Pergunta 3.", ex.Message);
                Util.CaixaMensagem.ExibirOk("Erro ao validar Aba Formulario Pergunta 3!");
                return false;
            }


        }

        private bool ValidarCamposAbaFormularioSubAba4()
        {
            try
            {
                if (string.IsNullOrEmpty(txtAba2Sub4Prepara.Text.Replace("/r", " ").Replace("/n", " ").Trim()) &&
                    !chkAba2Sub4NaoPrepara.Checked)
                {
                    Util.MostraCursor.CursorAguarde(false);
                    Util.CaixaMensagem.ExibirOk("Formulário - Pergunta 4 é obrigatória!");
                    txtAba2Sub4Prepara.Focus();
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                Util.MostraCursor.CursorAguarde(false);
                Util.LogErro.GravaLog("Erro ao validar Aba Formulario Pergunta 4.", ex.Message);
                Util.CaixaMensagem.ExibirOk("Erro ao validar Aba Formulario Pergunta 4!");
                return false;
            }


        }

        private bool ValidarCamposAbaFormularioSubAba5()
        {
            try
            {
                if (!chkAba2Sub5Sim.Checked &&
                    !chkAba2Sub5Nao.Checked)
                {
                    Util.MostraCursor.CursorAguarde(false);
                    Util.CaixaMensagem.ExibirOk("Formulário - Pergunta 5 é obrigatória!");
                    chkAba2Sub5Sim.Focus();
                    return false;
                }
                else
                {

                    if (!chkAba2Sub5Tem.Checked &&
                        !chkAba2Sub5Nunca.Checked &&
                        !chkAba2Sub5Jateve.Checked)
                    {
                        Util.MostraCursor.CursorAguarde(false);
                        Util.CaixaMensagem.ExibirOk("Formulário - Pergunta 5 é obrigatório a Opção!");
                        chkAba2Sub5Tem.Focus();
                        return false;
                    }
                    else if ((chkAba2Sub5Tem.Checked || chkAba2Sub5Jateve.Checked) && (string.IsNullOrEmpty(txtAba2Sub5JateveQual.Text)))
                    {
                        Util.MostraCursor.CursorAguarde(false);
                        Util.CaixaMensagem.ExibirOk("Formulário - Pergunta 5 é obrigatório informar Qual!");
                        txtAba2Sub5JateveQual.Focus();
                        return false;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                Util.MostraCursor.CursorAguarde(false);
                Util.LogErro.GravaLog("Erro ao validar Aba Formulario Pergunta 5.", ex.Message);
                Util.CaixaMensagem.ExibirOk("Erro ao validar Aba Formulario Pergunta 5!");
                return false;
            }


        }

        private bool ValidarCamposAbaFormularioSubAba6()
        {
            try
            {
                if (!chkAba2Sub6Sim.Checked &&
                    !chkAba2Sub6Nao.Checked)
                {
                    Util.MostraCursor.CursorAguarde(false);
                    Util.CaixaMensagem.ExibirOk("Formulário - Pergunta 6 é obrigatória!");
                    chkAba2Sub6Sim.Focus();
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                Util.MostraCursor.CursorAguarde(false);
                Util.LogErro.GravaLog("Erro ao validar Aba Formulario Pergunta 6.", ex.Message);
                Util.CaixaMensagem.ExibirOk("Erro ao validar Aba Formulario Pergunta 6!");
                return false;
            }


        }

        private bool ValidarCamposAbaFormularioSubAba7()
        {
            try
            {
                if (!chkAba2Sub7v15.Checked &&
                    !chkAba2Sub7v20.Checked &&
                    !chkAba2Sub7v25.Checked &&
                    !chkAba2Sub7v30.Checked &&
                    !chkAba2Sub7v35.Checked &&
                    !chkAba2Sub7v45.Checked &&
                    !chkAba2Sub7v55.Checked &&
                    !chkAba2Sub7v65.Checked &&
                    !chkAba2Sub7v75.Checked &&
                    !chkAba2Sub7v90.Checked &&
                    !chkAba2Sub7v110.Checked)
                {
                    Util.MostraCursor.CursorAguarde(false);
                    Util.CaixaMensagem.ExibirOk("Formulário - Pergunta 7 é obrigatória!");
                    chkAba2Sub7v15.Focus();
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                Util.MostraCursor.CursorAguarde(false);
                Util.LogErro.GravaLog("Erro ao validar Aba Formulario Pergunta 7.", ex.Message);
                Util.CaixaMensagem.ExibirOk("Erro ao validar Aba Formulario Pergunta 7!");
                return false;
            }

        }

        #endregion

        #region [ CONTROLS ]

        #region [ SUB 1 ]

        private void cmbAba2Sub1Grau_GotFocus(object sender, EventArgs e)
        {
            var newstate = Symbol.Keyboard.KeyStates.KEYSTATE_UNSHIFT;
            Symbol.Keyboard.KeyPad teclado = new Symbol.Keyboard.KeyPad();
            teclado.SetKeyState(newstate, 0, true);

            TextoCmbAba2Sub1Grau = string.Empty;
        }

        private void cmbAba2Sub1Grau_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 42 || e.KeyChar == 9 || e.KeyChar == 13)
            {
                TextoCmbAba2Sub1Grau = string.Empty;
                e.Handled = true;
                return;
            }

            string atual = TextoCmbAba2Sub1Grau;
            TextoCmbAba2Sub1Grau += e.KeyChar.ToString();

            DataRow[] verificaCombo = DadosCmbAba2Sub1Grau.Select("Value LIKE '" + TextoCmbAba2Sub1Grau + "%'");
            if (verificaCombo.Length > 0)
            {
                ((ComboBox)sender).SelectedValue = verificaCombo[0].ItemArray[0];
            }
            else
            {
                TextoCmbAba2Sub1Grau = atual;
            }

            e.Handled = true;
        }

        private void chkAba2Sub1_Click(object sender, EventArgs e)
        {
            bool objetoOrigem = ((CheckBox)sender).Checked;
            UnCheckedAba2Sub1();

            switch (((CheckBox)sender).Name)
            {
                case "chkAba2Sub1Sim":
                    chkAba2Sub1Sim.Checked = objetoOrigem;
                    break;
                case "chkAba2Sub1Nao":
                    chkAba2Sub1Nao.Checked = objetoOrigem;
                    break;
                default:
                    break;
            }
        }

        private void UnCheckedAba2Sub1()
        {
            chkAba2Sub1Sim.Checked = false;
            chkAba2Sub1Nao.Checked = false;
        }

        private void btnAba2Sub1Adicionar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAba2Sub1Idade.Text))
            {
                CaixaMensagem.ExibirOk("O Campo Idade é Obrigatório!");
                txtAba2Sub1Idade.Focus();
                return;
            }

            lstAba2Sub1Parentes.Items.Add(cmbAba2Sub1Grau.Text + " - " + txtAba2Sub1Idade.Text + " - " + VerficarABA2SUB1());

            cmbAba2Sub1Grau.SelectedIndex = 0;
            TextoCmbAba2Sub1Grau = string.Empty;
            txtAba2Sub1Idade.Text = string.Empty;
            UnCheckedAba2Sub1();

            lblAba2Sub1NumeroParentesValor.Text = lstAba2Sub1Parentes.Items.Count.ToString();

            cmbAba2Sub1Grau.Focus();
        }

        private void btnAba2Sub1Remover_Click(object sender, EventArgs e)
        {
            if (lstAba2Sub1Parentes.SelectedIndex > -1)
            {
                lstAba2Sub1Parentes.Items.RemoveAt(lstAba2Sub1Parentes.SelectedIndex);

                lblAba2Sub1NumeroParentesValor.Text = lstAba2Sub1Parentes.Items.Count.ToString();
            }
        }

        private void btnAba2Sub1Remover_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tabControlPerguntas.SelectedIndex = 1;
                e.Handled = true;
            }
        }

        #endregion

        #region [ SUB 2 ]

        private void cmbAba2Sub2Renda_GotFocus(object sender, EventArgs e)
        {
            var newstate = Symbol.Keyboard.KeyStates.KEYSTATE_UNSHIFT;
            Symbol.Keyboard.KeyPad teclado = new Symbol.Keyboard.KeyPad();
            teclado.SetKeyState(newstate, 0, true);

            TextoCmbAba2Sub2Renda = string.Empty;
        }

        private void cmbAba2Sub2Renda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 42 || e.KeyChar == 9 || e.KeyChar == 13)
            {
                TextoCmbAba2Sub2Renda = string.Empty;
                e.Handled = true;
                return;
            }

            string atual = TextoCmbAba2Sub2Renda;
            TextoCmbAba2Sub2Renda += e.KeyChar.ToString();

            DataRow[] verificaCombo = DadosCmbAba2Sub2Renda.Select("Value LIKE '%" + TextoCmbAba2Sub2Renda + "%'");
            if (verificaCombo.Length > 0)
            {
                ((ComboBox)sender).SelectedValue = verificaCombo[0].ItemArray[0];
            }
            else
            {
                TextoCmbAba2Sub2Renda = atual;
            }

            e.Handled = true;
        }

        private void cmbAba2Sub2Renda_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tabControlPerguntas.SelectedIndex = 2;
                e.Handled = true;
            }
        }

        private void cmbAba2Sub2Renda_LostFocus(object sender, EventArgs e)
        {
            Resposta2 = Convert.ToInt32(cmbAba2Sub2Renda.SelectedValue);
        }

        #endregion

        #region [ SUB 3 ]

        private void chkAba2Sub3_Click(object sender, EventArgs e)
        {
            bool objetoOrigem = ((CheckBox)sender).Checked;
            UnCheckedAba2Sub3();

            switch (((CheckBox)sender).Name)
            {
                case "chkAba2Sub3Casa":
                    chkAba2Sub3Casa.Checked = objetoOrigem;
                    break;
                case "chkAba2Sub3Junta":
                    chkAba2Sub3Junta.Checked = objetoOrigem;
                    break;
                case "chkAba2Sub3Nada":
                    chkAba2Sub3Nada.Checked = objetoOrigem;
                    break;
                case "chkAba2Sub3Outro":
                    chkAba2Sub3Outro.Checked = objetoOrigem;
                    txtAba2Sub3Outro.Enabled = true;
                    txtAba2Sub3Outro.BackColor = System.Drawing.Color.White;
                    break;
                default:
                    break;
            }
        }

        private void UnCheckedAba2Sub3()
        {
            chkAba2Sub3Casa.Checked = false;
            chkAba2Sub3Junta.Checked = false;
            chkAba2Sub3Nada.Checked = false;
            chkAba2Sub3Outro.Checked = false;
            txtAba2Sub3Outro.Enabled = false;
            txtAba2Sub3Outro.BackColor = System.Drawing.Color.Gainsboro;
        }

        private void chkAba2Sub3Outro_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !((CheckBox)sender).Checked)
            {
                tabControlPerguntas.SelectedIndex = 3;
                e.Handled = true;
            }
        }

        private void txtAba2Sub3Outro_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tabControlPerguntas.SelectedIndex = 3;
                e.Handled = true;
            }
        }

        #endregion

        #region [ SUB 4 ]

        private void txtAba2Sub4Prepara_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((TextBox)sender).Text.Length == 0 && e.KeyChar != Convert.ToChar(8) && e.KeyChar != Convert.ToChar(13))
            {
                ((TextBox)sender).Text = char.ToUpper(e.KeyChar).ToString();
                ((TextBox)sender).SelectionStart = ((TextBox)sender).Text.Length;

                chkAba2Sub4NaoPrepara.Checked = false;
                chkAba2Sub4NaoPrepara.Enabled = false;
                e.Handled = true;
                return;
            }
            else
            {
                if (((TextBox)sender).Text.Length == 1 && e.KeyChar == Convert.ToChar(8))
                {
                    ((TextBox)sender).Text = string.Empty;
                    ((TextBox)sender).SelectionStart = ((TextBox)sender).Text.Length;

                    chkAba2Sub4NaoPrepara.Checked = false;
                    chkAba2Sub4NaoPrepara.Enabled = true;
                    e.Handled = true;
                    return;
                }
            }

        }

        private void txtAba2Sub4Prepara_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrEmpty(txtAba2Sub4Prepara.Text.Replace("/r", " ").Replace("/n", " ").Trim()))
            {
                tabControlPerguntas.SelectedIndex = 4;
                e.Handled = true;
            }
            else
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtAba2Sub4Prepara.Text = string.Empty;
                    txtAba2Sub4Prepara.Parent.SelectNextControl(txtAba2Sub4Prepara, true, true, true, true);
                }
            }
        }

        private void chkAba2Sub4NaoPrepara_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tabControlPerguntas.SelectedIndex = 4;
                e.Handled = true;
            }
        }

        #endregion

        #region [ SUB 5 ]

        private void chkAba2Sub5chk1_Click(object sender, EventArgs e)
        {
            bool objetoOrigem = ((CheckBox)sender).Checked;
            UnCheckedAba2Sub5chk1();
            switch (((CheckBox)sender).Name)
            {
                case "chkAba2Sub5Sim":
                    chkAba2Sub5Sim.Checked = objetoOrigem;
                    break;
                case "chkAba2Sub5Nao":
                    chkAba2Sub5Nao.Checked = objetoOrigem;
                    break;
                default:
                    break;
            }
        }

        private void UnCheckedAba2Sub5chk1()
        {
            chkAba2Sub5Sim.Checked = false;
            chkAba2Sub5Nao.Checked = false;
        }

        private void chkAba2Sub5chk2_Click(object sender, EventArgs e)
        {
            bool objetoOrigem = ((CheckBox)sender).Checked;
            UnCheckedAba2Sub5chk2();

            switch (((CheckBox)sender).Name)
            {
                case "chkAba2Sub5Tem":
                    chkAba2Sub5Tem.Checked = objetoOrigem;
                    txtAba2Sub5JateveQual.Enabled = true;
                    txtAba2Sub5JateveQual.BackColor = System.Drawing.Color.White;
                    break;
                case "chkAba2Sub5Jateve":
                    chkAba2Sub5Jateve.Checked = objetoOrigem;
                    txtAba2Sub5JateveQual.Enabled = true;
                    txtAba2Sub5JateveQual.BackColor = System.Drawing.Color.White;
                    break;
                case "chkAba2Sub5Nunca":
                    chkAba2Sub5Nunca.Checked = objetoOrigem;
                    break;
                default:
                    break;
            }
        }

        private void UnCheckedAba2Sub5chk2()
        {
            chkAba2Sub5Tem.Checked = false;
            chkAba2Sub5Jateve.Checked = false;
            chkAba2Sub5Nunca.Checked = false;
            txtAba2Sub5JateveQual.Enabled = false;
            txtAba2Sub5JateveQual.BackColor = System.Drawing.Color.Gainsboro;
        }

        private void chkAba2Sub5Nunca_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!((CheckBox)sender).Checked)
                {
                    chkAba2Sub5Nunca.Parent.SelectNextControl(chkAba2Sub5Nunca, true, true, true, true);
                }
                else
                {
                    tabControlPerguntas.SelectedIndex = 5;
                    e.Handled = true;
                }
            }
        }

        private void txtAba2Sub5JateveQual_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tabControlPerguntas.SelectedIndex = 5;
                e.Handled = true;
            }
        }

        #endregion

        #region [ SUB 6 ]

        private void chkAba2Sub6_Click(object sender, EventArgs e)
        {
            bool objetoOrigem = ((CheckBox)sender).Checked;
            UnCheckedAba2Sub6();

            switch (((CheckBox)sender).Name)
            {
                case "chkAba2Sub6Sim":
                    chkAba2Sub6Sim.Checked = objetoOrigem;
                    break;
                case "chkAba2Sub6Nao":
                    chkAba2Sub6Nao.Checked = objetoOrigem;
                    break;
                default:
                    break;
            }
        }

        private void UnCheckedAba2Sub6()
        {
            chkAba2Sub6Sim.Checked = false;
            chkAba2Sub6Nao.Checked = false;
        }

        private void chkAba2Sub6Nao_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tabControlPerguntas.SelectedIndex = 6;
                e.Handled = true;
            }
        }

        #endregion

        #region [ SUB 7 ]

        private void chkAba2Sub7_Click(object sender, EventArgs e)
        {
            bool objetoOrigem = ((CheckBox)sender).Checked;
            UnCheckedAba2Sub7();

            switch (((CheckBox)sender).Name)
            {
                case "chkAba2Sub7v15":
                    chkAba2Sub7v15.Checked = objetoOrigem;
                    Resposta7 = 1;
                    break;
                case "chkAba2Sub7v20":
                    chkAba2Sub7v20.Checked = objetoOrigem;
                    Resposta7 = 2;
                    break;
                case "chkAba2Sub7v25":
                    chkAba2Sub7v25.Checked = objetoOrigem;
                    Resposta7 = 3;
                    break;
                case "chkAba2Sub7v30":
                    chkAba2Sub7v30.Checked = objetoOrigem;
                    Resposta7 = 4;
                    break;
                case "chkAba2Sub7v35":
                    chkAba2Sub7v35.Checked = objetoOrigem;
                    Resposta7 = 5;
                    break;
                case "chkAba2Sub7v45":
                    chkAba2Sub7v45.Checked = objetoOrigem;
                    Resposta7 = 6;
                    break;
                case "chkAba2Sub7v55":
                    chkAba2Sub7v55.Checked = objetoOrigem;
                    Resposta7 = 7;
                    break;
                case "chkAba2Sub7v65":
                    chkAba2Sub7v65.Checked = objetoOrigem;
                    Resposta7 = 8;
                    break;
                case "chkAba2Sub7v75":
                    chkAba2Sub7v75.Checked = objetoOrigem;
                    Resposta7 = 9;
                    break;
                case "chkAba2Sub7v90":
                    chkAba2Sub7v90.Checked = objetoOrigem;
                    Resposta7 = 10;
                    break;
                case "chkAba2Sub7v110":
                    chkAba2Sub7v110.Checked = objetoOrigem;
                    Resposta7 = 11;
                    break;
                default:
                    break;
            }
        }

        private void UnCheckedAba2Sub7()
        {
            chkAba2Sub7v15.Checked = false;
            chkAba2Sub7v20.Checked = false;
            chkAba2Sub7v25.Checked = false;
            chkAba2Sub7v30.Checked = false;
            chkAba2Sub7v35.Checked = false;
            chkAba2Sub7v45.Checked = false;
            chkAba2Sub7v55.Checked = false;
            chkAba2Sub7v65.Checked = false;
            chkAba2Sub7v75.Checked = false;
            chkAba2Sub7v90.Checked = false;
            chkAba2Sub7v110.Checked = false;
        }

        private void chkAba2Sub7v110_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tabEntrevista.SelectedIndex = 2;
                e.Handled = true;
            }
        }

        #endregion

        private void tabControlPerguntas_SelectedIndexChanged(object sender, EventArgs e)
        {
            Util.MostraCursor.CursorAguarde(true);
            if (SubAbaAnterior < tabControlPerguntas.SelectedIndex)
            {
                switch (SubAbaAnterior)
                {
                    case 0:
                        if (SalvarAbaFormularioSub1())
                            AcertarFocuSubCampos();
                        break;
                    case 1:
                        if (SalvarAbaFormularioSub2())
                            AcertarFocuSubCampos();
                        break;
                    case 2:
                        if (SalvarAbaFormularioSub3())
                            AcertarFocuSubCampos();
                        break;
                    case 3:
                        if (SalvarAbaFormularioSub4())
                            AcertarFocuSubCampos();
                        break;
                    case 4:
                        if (SalvarAbaFormularioSub5())
                            AcertarFocuSubCampos();
                        break;
                    case 5:
                        if (SalvarAbaFormularioSub6())
                            AcertarFocuSubCampos();
                        break;
                    case 6:
                        if (SalvarAbaFormularioSub7())
                            AcertarFocuSubCampos();
                        break;
                    default:
                        break;
                }
            }
            else
            {
                AcertarFocuSubCampos();
            }

            Util.MostraCursor.CursorAguarde(false);
        }

        #endregion

        #region [ SAVE ]

        private bool SalvarAbaFormulario()
        {
            try
            {
                if (!SalvarAbaFormularioSub1())
                    return false;

                if (!SalvarAbaFormularioSub2())
                    return false;

                if (!SalvarAbaFormularioSub3())
                    return false;

                if (!SalvarAbaFormularioSub4())
                    return false;

                if (!SalvarAbaFormularioSub5())
                    return false;

                if (!SalvarAbaFormularioSub6())
                    return false;

                if (!SalvarAbaFormularioSub7())
                    return false;

                return true;
            }
            catch (Exception ex)
            {
                Util.LogErro.GravaLog("Erro ao salvar Aba Formulário.", ex.Message);
                return false;
            }
        }

        private bool SalvarAbaFormularioSub1()
        {
            try
            {
                MapearCamposAbaFormularioSubAba1();

                if (DadosTRespostaSub1.Count > 0)
                    ControllerResposta.SalvarRespostaAgregados(DadosTRespostaSub1);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool SalvarAbaFormularioSub2()
        {
            try
            {
                if (ValidarCamposAbaFormularioSubAba2())
                {
                    MapearCamposAbaFormularioSubAba2();

                    if (DadosTRespostaSub2.Count > 0)
                        ControllerResposta.SalvarResposta(DadosTRespostaSub2);
                    return true;
                }
                else
                {
                    tabEntrevista.SelectedIndex = 1;
                    tabControlPerguntas.SelectedIndex = 1;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool SalvarAbaFormularioSub3()
        {
            try
            {
                if (ValidarCamposAbaFormularioSubAba3())
                {
                    MapearCamposAbaFormularioSubAba3();

                    if (DadosTRespostaSub3.Count > 0)
                        ControllerResposta.SalvarResposta(DadosTRespostaSub3);

                    return true;
                }
                else
                {
                    tabEntrevista.SelectedIndex = 1;
                    tabControlPerguntas.SelectedIndex = 2;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool SalvarAbaFormularioSub4()
        {
            try
            {
                if (ValidarCamposAbaFormularioSubAba4())
                {
                    MapearCamposAbaFormularioSubAba4();

                    if (DadosTRespostaSub4.Count > 0)
                        ControllerResposta.SalvarResposta(DadosTRespostaSub4);

                    return true;
                }
                else
                {
                    tabEntrevista.SelectedIndex = 1;
                    tabControlPerguntas.SelectedIndex = 3;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool SalvarAbaFormularioSub5()
        {
            try
            {
                if (ValidarCamposAbaFormularioSubAba5())
                {
                    MapearCamposAbaFormularioSubAba5();

                    if (DadosTRespostaSub5.Count > 0)
                        ControllerResposta.SalvarResposta(DadosTRespostaSub5);

                    return true;
                }
                else
                {
                    tabEntrevista.SelectedIndex = 1;
                    tabControlPerguntas.SelectedIndex = 4;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool SalvarAbaFormularioSub6()
        {
            try
            {
                if (ValidarCamposAbaFormularioSubAba6())
                {
                    MapearCamposAbaFormularioSubAba6();

                    if (DadosTRespostaSub6.Count > 0)
                        ControllerResposta.SalvarResposta(DadosTRespostaSub6);

                    return true;
                }
                else
                {
                    tabEntrevista.SelectedIndex = 1;
                    tabControlPerguntas.SelectedIndex = 5;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool SalvarAbaFormularioSub7()
        {
            try
            {
                if (ValidarCamposAbaFormularioSubAba7())
                {
                    MapearCamposAbaFormularioSubAba7();

                    if (DadosTRespostaSub7.Count > 0)
                        ControllerResposta.SalvarResposta(DadosTRespostaSub7);

                    return true;
                }
                else
                {
                    tabEntrevista.SelectedIndex = 1;
                    tabControlPerguntas.SelectedIndex = 6;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

    }
}

using ProjetoMobile.Dominio.Enumeradores;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlServerCe;
using ProjetoMobile;
using System.Data;
using ProjetoMobile.Dominio;

namespace ProjetoMobile.Persistencia
{
    public class TCombosEnumPERSISTENCIA
    {
        public DataTable ListaDeEstadoCivil()
        {
            DataTable dadosTable = new DataTable();
            DataColumn columnKey = new DataColumn("Key");
            DataColumn columnValue = new DataColumn("Value");
            DataRow rowEmpyt;

            dadosTable.Columns.Add(columnKey);
            dadosTable.Columns.Add(columnValue);

            rowEmpyt = dadosTable.NewRow();
            rowEmpyt["Key"] = 0;
            rowEmpyt["Value"] = string.Empty;
            dadosTable.Rows.Add(rowEmpyt);

            rowEmpyt = dadosTable.NewRow();
            rowEmpyt["Key"] = (int)EstadoCivil.Solteiro;
            rowEmpyt["Value"] = EstadoCivil.Solteiro.GetStringValue();
            dadosTable.Rows.Add(rowEmpyt);

            rowEmpyt = dadosTable.NewRow();
            rowEmpyt["Key"] = (int)EstadoCivil.Casado;
            rowEmpyt["Value"] = EstadoCivil.Casado.GetStringValue();
            dadosTable.Rows.Add(rowEmpyt);

            rowEmpyt = dadosTable.NewRow();
            rowEmpyt["Key"] = (int)EstadoCivil.Viuvo;
            rowEmpyt["Value"] = EstadoCivil.Viuvo.GetStringValue();
            dadosTable.Rows.Add(rowEmpyt);

            rowEmpyt = dadosTable.NewRow();
            rowEmpyt["Key"] = (int)EstadoCivil.Divorciado;
            rowEmpyt["Value"] = EstadoCivil.Divorciado.GetStringValue();
            dadosTable.Rows.Add(rowEmpyt);

            rowEmpyt = dadosTable.NewRow();
            rowEmpyt["Key"] = (int)EstadoCivil.UniaoEstavel;
            rowEmpyt["Value"] = EstadoCivil.UniaoEstavel.GetStringValue();
            dadosTable.Rows.Add(rowEmpyt);

            return dadosTable;
        }

        public int FaixaEtariaDataNascimento(DateTime dataNascimento)
        {
            TimeSpan tempo = DateTime.Now - dataNascimento;
            int diferencial = (int)Math.Floor(tempo.TotalDays / 365.25);

            if (18 <= diferencial && diferencial <= 30)
                return (int)FaixaEtaria.PREMIO_18_30;

            if (31 <= diferencial && diferencial <= 40)
                return (int)FaixaEtaria.PREMIO_31_40;

            if (41 <= diferencial && diferencial <= 45)
                return (int)FaixaEtaria.PREMIO_41_45;

            if (46 <= diferencial && diferencial <= 50)
                return (int)FaixaEtaria.PREMIO_46_50;

            if (51 <= diferencial && diferencial <= 55)
                return (int)FaixaEtaria.PREMIO_51_55;

            if (56 <= diferencial && diferencial <= 60)
                return (int)FaixaEtaria.PREMIO_56_60;

            if (61 <= diferencial && diferencial <= 65)
                return (int)FaixaEtaria.PREMIO_61_65;

            if (66 <= diferencial && diferencial <= 70)
                return (int)FaixaEtaria.PREMIO_66_70;

            if (71 <= diferencial && diferencial <= 75)
                return (int)FaixaEtaria.PREMIO_71_75;

            if (76 <= diferencial && diferencial <= 80)
                return (int)FaixaEtaria.PREMIO_76_80;

            if (81 <= diferencial)
                return (int)FaixaEtaria.PREMIO_81;

            return 0;
        }

        public DataTable ListaDeFaixaEtaria(int produto)
        {            
           DataTable dadosTable = new DataTable();
           DataColumn columnKey = new DataColumn("Key");
           DataColumn columnValue = new DataColumn("Value");
           DataRow rowEmpyt;

           dadosTable.Columns.Add(columnKey);
           dadosTable.Columns.Add(columnValue);

           rowEmpyt = dadosTable.NewRow();
           rowEmpyt["Key"] = 0;
           rowEmpyt["Value"] = string.Empty;
           dadosTable.Rows.Add(rowEmpyt);

           if (produto == (int)ProdutoPrincipal.PLANOPROTECAO || produto == 0)
           {
               rowEmpyt = dadosTable.NewRow();
               rowEmpyt["Key"] = (int)FaixaEtaria.PREMIO_18_30;
               rowEmpyt["Value"] = FaixaEtaria.PREMIO_18_30.GetStringValue();
               dadosTable.Rows.Add(rowEmpyt);

               rowEmpyt = dadosTable.NewRow();
               rowEmpyt["Key"] = (int)FaixaEtaria.PREMIO_31_40;
               rowEmpyt["Value"] = FaixaEtaria.PREMIO_31_40.GetStringValue();
               dadosTable.Rows.Add(rowEmpyt);

               rowEmpyt = dadosTable.NewRow();
               rowEmpyt["Key"] = (int)FaixaEtaria.PREMIO_41_45;
               rowEmpyt["Value"] = FaixaEtaria.PREMIO_41_45.GetStringValue();
               dadosTable.Rows.Add(rowEmpyt);

               rowEmpyt = dadosTable.NewRow();
               rowEmpyt["Key"] = (int)FaixaEtaria.PREMIO_46_50;
               rowEmpyt["Value"] = FaixaEtaria.PREMIO_46_50.GetStringValue();
               dadosTable.Rows.Add(rowEmpyt);

               rowEmpyt = dadosTable.NewRow();
               rowEmpyt["Key"] = (int)FaixaEtaria.PREMIO_51_55;
               rowEmpyt["Value"] = FaixaEtaria.PREMIO_51_55.GetStringValue();
               dadosTable.Rows.Add(rowEmpyt);

               rowEmpyt = dadosTable.NewRow();
               rowEmpyt["Key"] = (int)FaixaEtaria.PREMIO_56_60;
               rowEmpyt["Value"] = FaixaEtaria.PREMIO_56_60.GetStringValue();
               dadosTable.Rows.Add(rowEmpyt);
           }

           rowEmpyt = dadosTable.NewRow();
           rowEmpyt["Key"] = (int)FaixaEtaria.PREMIO_61_65;
           rowEmpyt["Value"] = FaixaEtaria.PREMIO_61_65.GetStringValue();
           dadosTable.Rows.Add(rowEmpyt);

           if (produto == (int)ProdutoPrincipal.PLANOSENIOR || produto == (int)ProdutoPrincipal.PLANOCASAL || produto == 0)
           {
               rowEmpyt = dadosTable.NewRow();
               rowEmpyt["Key"] = (int)FaixaEtaria.PREMIO_66_70;
               rowEmpyt["Value"] = FaixaEtaria.PREMIO_66_70.GetStringValue();
               dadosTable.Rows.Add(rowEmpyt);

               rowEmpyt = dadosTable.NewRow();
               rowEmpyt["Key"] = (int)FaixaEtaria.PREMIO_71_75;
               rowEmpyt["Value"] = FaixaEtaria.PREMIO_71_75.GetStringValue();
               dadosTable.Rows.Add(rowEmpyt);

               rowEmpyt = dadosTable.NewRow();
               rowEmpyt["Key"] = (int)FaixaEtaria.PREMIO_76_80;
               rowEmpyt["Value"] = FaixaEtaria.PREMIO_76_80.GetStringValue();
               dadosTable.Rows.Add(rowEmpyt);
           }

           return dadosTable;           
        }

        public DataTable ListaDeCapitalLimitado()
        {
            DataTable dadosTable = new DataTable();
            DataColumn columnKey = new DataColumn("Key");
            DataColumn columnValue = new DataColumn("Value");
            DataRow rowEmpyt;

            dadosTable.Columns.Add(columnKey);
            dadosTable.Columns.Add(columnValue);

            rowEmpyt = dadosTable.NewRow();
            rowEmpyt["Key"] = 0;
            rowEmpyt["Value"] = string.Empty;
            dadosTable.Rows.Add(rowEmpyt);

            rowEmpyt = dadosTable.NewRow();
            rowEmpyt["Key"] = (int)CapitalLimitado.Sim;
            rowEmpyt["Value"] = CapitalLimitado.Sim.GetStringValue();
            dadosTable.Rows.Add(rowEmpyt);

            rowEmpyt = dadosTable.NewRow();
            rowEmpyt["Key"] = (int)CapitalLimitado.Nao;
            rowEmpyt["Value"] = CapitalLimitado.Nao.GetStringValue();
            dadosTable.Rows.Add(rowEmpyt);
                      
            return dadosTable;
        }

        public DataTable ListaDeParentesco(bool conjuge, bool simulador)
        {
            DataTable dadosTable = new DataTable();
            DataColumn columnKey = new DataColumn("Key");
            DataColumn columnValue = new DataColumn("Value");
            
            dadosTable.Columns.Add(columnKey);
            dadosTable.Columns.Add(columnValue);

            DataRow dadosRow = dadosTable.NewRow();
            dadosRow["Key"] = 0;
            dadosRow["Value"] = string.Empty;
            dadosTable.Rows.Add(dadosRow);

            if (conjuge)
            {
                dadosRow = dadosTable.NewRow();
                dadosRow["Key"] = (int)GrauParentesco.CONJUGE;
                dadosRow["Value"] = GrauParentesco.CONJUGE.GetStringValue();
                dadosTable.Rows.Add(dadosRow);
            }

            dadosRow = dadosTable.NewRow();
            dadosRow["Key"] = (int)GrauParentesco.FILHO;
            dadosRow["Value"] = GrauParentesco.FILHO.GetStringValue();
            dadosTable.Rows.Add(dadosRow);

            dadosRow = dadosTable.NewRow();
            dadosRow["Key"] = (int)GrauParentesco.PAI;
            dadosRow["Value"] = GrauParentesco.PAI.GetStringValue();
            dadosTable.Rows.Add(dadosRow);

            dadosRow = dadosTable.NewRow();
            dadosRow["Key"] = (int)GrauParentesco.MAE;
            dadosRow["Value"] = GrauParentesco.MAE.GetStringValue();
            dadosTable.Rows.Add(dadosRow);

            dadosRow = dadosTable.NewRow();
            dadosRow["Key"] = (int)GrauParentesco.SOGRO;
            dadosRow["Value"] = GrauParentesco.SOGRO.GetStringValue();
            dadosTable.Rows.Add(dadosRow);

            dadosRow = dadosTable.NewRow();
            dadosRow["Key"] = (int)GrauParentesco.GENRO;
            dadosRow["Value"] = GrauParentesco.GENRO.GetStringValue();
            dadosTable.Rows.Add(dadosRow);

            dadosRow = dadosTable.NewRow();
            dadosRow["Key"] = (int)GrauParentesco.NORA;
            dadosRow["Value"] = GrauParentesco.NORA.GetStringValue();
            dadosTable.Rows.Add(dadosRow);

            dadosRow = dadosTable.NewRow();
            dadosRow["Key"] = (int)GrauParentesco.IRMAO;
            dadosRow["Value"] = GrauParentesco.IRMAO.GetStringValue();
            dadosTable.Rows.Add(dadosRow);

            dadosRow = dadosTable.NewRow();
            dadosRow["Key"] = (int)GrauParentesco.NETO;
            dadosRow["Value"] = GrauParentesco.NETO.GetStringValue();
            dadosTable.Rows.Add(dadosRow);

            dadosRow = dadosTable.NewRow();
            dadosRow["Key"] = (int)GrauParentesco.BISNETO;
            dadosRow["Value"] = GrauParentesco.BISNETO.GetStringValue();
            dadosTable.Rows.Add(dadosRow);

            dadosRow = dadosTable.NewRow();
            dadosRow["Key"] = (int)GrauParentesco.ENTEADO;
            dadosRow["Value"] = GrauParentesco.ENTEADO.GetStringValue();
            dadosTable.Rows.Add(dadosRow);

            if (!simulador)
            {
                dadosRow = dadosTable.NewRow();
                dadosRow["Key"] = (int)GrauParentesco.AVOM;
                dadosRow["Value"] = GrauParentesco.AVOM.GetStringValue();
                dadosTable.Rows.Add(dadosRow);

                dadosRow = dadosTable.NewRow();
                dadosRow["Key"] = (int)GrauParentesco.AVOF;
                dadosRow["Value"] = GrauParentesco.AVOF.GetStringValue();
                dadosTable.Rows.Add(dadosRow);

                dadosRow = dadosTable.NewRow();
                dadosRow["Key"] = (int)GrauParentesco.OUTRO;
                dadosRow["Value"] = GrauParentesco.OUTRO.GetStringValue();
                dadosTable.Rows.Add(dadosRow);
            }         

            return dadosTable;
        }

        public DataTable ListaDePerguntaRenda()
        {
            DataTable dadosTable = new DataTable();
            DataColumn columnKey = new DataColumn("Key");
            DataColumn columnValue = new DataColumn("Value");
            DataRow rowEmpyt;

            dadosTable.Columns.Add(columnKey);
            dadosTable.Columns.Add(columnValue);

            rowEmpyt = dadosTable.NewRow();
            rowEmpyt["Key"] = 0;
            rowEmpyt["Value"] = string.Empty;
            dadosTable.Rows.Add(rowEmpyt);

            rowEmpyt = dadosTable.NewRow();
            rowEmpyt["Key"] = (int)PerguntaRenda.ATE_800;
            rowEmpyt["Value"] = PerguntaRenda.ATE_800.GetStringValue();
            dadosTable.Rows.Add(rowEmpyt);

            rowEmpyt = dadosTable.NewRow();
            rowEmpyt["Key"] = (int)PerguntaRenda.DE_801_1000;
            rowEmpyt["Value"] = PerguntaRenda.DE_801_1000.GetStringValue();
            dadosTable.Rows.Add(rowEmpyt);

            rowEmpyt = dadosTable.NewRow();
            rowEmpyt["Key"] = (int)PerguntaRenda.DE_1001_1200;
            rowEmpyt["Value"] = PerguntaRenda.DE_1001_1200.GetStringValue();
            dadosTable.Rows.Add(rowEmpyt);

            rowEmpyt = dadosTable.NewRow();
            rowEmpyt["Key"] = (int)PerguntaRenda.DE_1201_1400;
            rowEmpyt["Value"] = PerguntaRenda.DE_1201_1400.GetStringValue();
            dadosTable.Rows.Add(rowEmpyt);

            rowEmpyt = dadosTable.NewRow();
            rowEmpyt["Key"] = (int)PerguntaRenda.DE_1401_1600;
            rowEmpyt["Value"] = PerguntaRenda.DE_1401_1600.GetStringValue();
            dadosTable.Rows.Add(rowEmpyt);

            rowEmpyt = dadosTable.NewRow();
            rowEmpyt["Key"] = (int)PerguntaRenda.DE_1601_2000;
            rowEmpyt["Value"] = PerguntaRenda.DE_1601_2000.GetStringValue();
            dadosTable.Rows.Add(rowEmpyt);

            rowEmpyt = dadosTable.NewRow();
            rowEmpyt["Key"] = (int)PerguntaRenda.DE_2001_2500;
            rowEmpyt["Value"] = PerguntaRenda.DE_2001_2500.GetStringValue();
            dadosTable.Rows.Add(rowEmpyt);

            rowEmpyt = dadosTable.NewRow();
            rowEmpyt["Key"] = (int)PerguntaRenda.DE_2501_3000;
            rowEmpyt["Value"] = PerguntaRenda.DE_2501_3000.GetStringValue();
            dadosTable.Rows.Add(rowEmpyt);

            rowEmpyt = dadosTable.NewRow();
            rowEmpyt["Key"] = (int)PerguntaRenda.DE_3001_3500;
            rowEmpyt["Value"] = PerguntaRenda.DE_3001_3500.GetStringValue();
            dadosTable.Rows.Add(rowEmpyt);

            rowEmpyt = dadosTable.NewRow();
            rowEmpyt["Key"] = (int)PerguntaRenda.DE_3501_4000;
            rowEmpyt["Value"] = PerguntaRenda.DE_3501_4000.GetStringValue();
            dadosTable.Rows.Add(rowEmpyt);
                       
            rowEmpyt = dadosTable.NewRow();
            rowEmpyt["Key"] = (int)PerguntaRenda.ACIMA_4001;
            rowEmpyt["Value"] = PerguntaRenda.ACIMA_4001.GetStringValue();
            dadosTable.Rows.Add(rowEmpyt);

            rowEmpyt = dadosTable.NewRow();
            rowEmpyt["Key"] = (int)PerguntaRenda.NAO_INFORMA;
            rowEmpyt["Value"] = PerguntaRenda.NAO_INFORMA.GetStringValue();
            dadosTable.Rows.Add(rowEmpyt);

            
            return dadosTable;
        }

        public DataTable ListaDePerguntaPremio()
        {
            DataTable dadosTable = new DataTable();
            DataColumn columnKey = new DataColumn("Key");
            DataColumn columnValue = new DataColumn("Value");
            DataRow rowEmpyt;

            dadosTable.Columns.Add(columnKey);
            dadosTable.Columns.Add(columnValue);

            rowEmpyt = dadosTable.NewRow();
            rowEmpyt["Key"] = 0;
            rowEmpyt["Value"] = string.Empty;
            dadosTable.Rows.Add(rowEmpyt);

            rowEmpyt = dadosTable.NewRow();
            rowEmpyt["Key"] = (int)PerguntaPremio.PREMIO_15;
            rowEmpyt["Value"] = PerguntaPremio.PREMIO_15.GetStringValue();
            dadosTable.Rows.Add(rowEmpyt);

            rowEmpyt = dadosTable.NewRow();
            rowEmpyt["Key"] = (int)PerguntaPremio.PREMIO_20;
            rowEmpyt["Value"] = PerguntaPremio.PREMIO_20.GetStringValue();
            dadosTable.Rows.Add(rowEmpyt);

            rowEmpyt = dadosTable.NewRow();
            rowEmpyt["Key"] = (int)PerguntaPremio.PREMIO_25;
            rowEmpyt["Value"] = PerguntaPremio.PREMIO_25.GetStringValue();
            dadosTable.Rows.Add(rowEmpyt);

            rowEmpyt = dadosTable.NewRow();
            rowEmpyt["Key"] = (int)PerguntaPremio.PREMIO_30;
            rowEmpyt["Value"] = PerguntaPremio.PREMIO_30.GetStringValue();
            dadosTable.Rows.Add(rowEmpyt);

            rowEmpyt = dadosTable.NewRow();
            rowEmpyt["Key"] = (int)PerguntaPremio.PREMIO_35;
            rowEmpyt["Value"] = PerguntaPremio.PREMIO_35.GetStringValue();
            dadosTable.Rows.Add(rowEmpyt);

            rowEmpyt = dadosTable.NewRow();
            rowEmpyt["Key"] = (int)PerguntaPremio.PREMIO_45;
            rowEmpyt["Value"] = PerguntaPremio.PREMIO_45.GetStringValue();
            dadosTable.Rows.Add(rowEmpyt);

            rowEmpyt = dadosTable.NewRow();
            rowEmpyt["Key"] = (int)PerguntaPremio.PREMIO_55;
            rowEmpyt["Value"] = PerguntaPremio.PREMIO_55.GetStringValue();
            dadosTable.Rows.Add(rowEmpyt);

            rowEmpyt = dadosTable.NewRow();
            rowEmpyt["Key"] = (int)PerguntaPremio.PREMIO_65;
            rowEmpyt["Value"] = PerguntaPremio.PREMIO_65.GetStringValue();
            dadosTable.Rows.Add(rowEmpyt);

            rowEmpyt = dadosTable.NewRow();
            rowEmpyt["Key"] = (int)PerguntaPremio.PREMIO_75;
            rowEmpyt["Value"] = PerguntaPremio.PREMIO_75.GetStringValue();
            dadosTable.Rows.Add(rowEmpyt);

            rowEmpyt = dadosTable.NewRow();
            rowEmpyt["Key"] = (int)PerguntaPremio.PREMIO_90;
            rowEmpyt["Value"] = PerguntaPremio.PREMIO_90.GetStringValue();
            dadosTable.Rows.Add(rowEmpyt);

            rowEmpyt = dadosTable.NewRow();
            rowEmpyt["Key"] = (int)PerguntaPremio.PREMIO_110;
            rowEmpyt["Value"] = PerguntaPremio.PREMIO_110.GetStringValue();
            dadosTable.Rows.Add(rowEmpyt);

            return dadosTable;
        }

        public DataTable ListaDeSexo()
        {
            DataTable dadosTable = new DataTable();
            DataColumn columnKey = new DataColumn("Key");
            DataColumn columnValue = new DataColumn("Value");
            DataRow rowEmpyt;

            dadosTable.Columns.Add(columnKey);
            dadosTable.Columns.Add(columnValue);

            rowEmpyt = dadosTable.NewRow();
            rowEmpyt["Key"] = 0;
            rowEmpyt["Value"] = string.Empty;
            dadosTable.Rows.Add(rowEmpyt);

            rowEmpyt = dadosTable.NewRow();
            rowEmpyt["Key"] = "F";
            rowEmpyt["Value"] = "F";
            dadosTable.Rows.Add(rowEmpyt);

            rowEmpyt = dadosTable.NewRow();
            rowEmpyt["Key"] = "M";
            rowEmpyt["Value"] = "M";
            dadosTable.Rows.Add(rowEmpyt);

            return dadosTable;
        }

        public DataTable ListaDeDiaData(int Mes)
        {
            DataTable dadosTable = new DataTable();
            DataColumn columnKey = new DataColumn("Key");
            DataColumn columnValue = new DataColumn("Value");
            DataRow rowEmpyt;

            dadosTable.Columns.Add(columnKey);
            dadosTable.Columns.Add(columnValue);

            rowEmpyt = dadosTable.NewRow();
            rowEmpyt["Key"] = 0;
            rowEmpyt["Value"] = string.Empty;
            dadosTable.Rows.Add(rowEmpyt);

            int quantidadeDias = 0;
            List<int> Meses31 = new List<int>{0,1,3,5,7,8,10,12};
            List<int> Meses30 = new List<int>{4,6,9,11};
                        
            if (Mes == 2)
                quantidadeDias = 28;

            if (Meses30.Contains(Mes))
                quantidadeDias = 30;

            if (Meses31.Contains(Mes))
                quantidadeDias = 31;

            for (int i = 1; i <= quantidadeDias; i++)
            {
                rowEmpyt = dadosTable.NewRow();
                rowEmpyt["Key"] = i;
                rowEmpyt["Value"] = i.ToString();
                dadosTable.Rows.Add(rowEmpyt);
            }

            return dadosTable;
        }

        public DataTable ListaDeMesData()
        {
            DataTable dadosTable = new DataTable();
            DataColumn columnKey = new DataColumn("Key");
            DataColumn columnValue = new DataColumn("Value");
            DataRow rowEmpyt;

            dadosTable.Columns.Add(columnKey);
            dadosTable.Columns.Add(columnValue);

            rowEmpyt = dadosTable.NewRow();
            rowEmpyt["Key"] = 0;
            rowEmpyt["Value"] = string.Empty;
            dadosTable.Rows.Add(rowEmpyt);
            
            for (int i = 1; i <= 12; i++)
            {
                rowEmpyt = dadosTable.NewRow();
                rowEmpyt["Key"] = i;
                rowEmpyt["Value"] = i.ToString();
                dadosTable.Rows.Add(rowEmpyt);
            }

            return dadosTable;
        }

        public DataTable ListaDeAnoDataNascimento(bool titular)
        {
            DataTable dadosTable = new DataTable();
            DataColumn columnKey = new DataColumn("Key");
            DataColumn columnValue = new DataColumn("Value");
            DataRow rowEmpyt;

            dadosTable.Columns.Add(columnKey);
            dadosTable.Columns.Add(columnValue);

            rowEmpyt = dadosTable.NewRow();
            rowEmpyt["Key"] = 0;
            rowEmpyt["Value"] = string.Empty;
            dadosTable.Rows.Add(rowEmpyt);

            int AnoAtual;
            int AnoPeriodo;
            if (titular)
            {
                AnoAtual = DateTime.Now.Year - 18;
                AnoPeriodo = 63;
            }
            else
            {
                AnoAtual = DateTime.Now.Year;
                AnoPeriodo = 81;
            }

            for (int i = AnoAtual - AnoPeriodo; i <= AnoAtual; i++)
            {
                rowEmpyt = dadosTable.NewRow();
                rowEmpyt["Key"] = i;
                rowEmpyt["Value"] = i.ToString();
                dadosTable.Rows.Add(rowEmpyt);
            }

            return dadosTable;
        }

        public DataTable ListaDeAnoDataAgenda()
        {
            DataTable dadosTable = new DataTable();
            DataColumn columnKey = new DataColumn("Key");
            DataColumn columnValue = new DataColumn("Value");
            DataRow rowEmpyt;

            dadosTable.Columns.Add(columnKey);
            dadosTable.Columns.Add(columnValue);

            rowEmpyt = dadosTable.NewRow();
            rowEmpyt["Key"] = 0;
            rowEmpyt["Value"] = string.Empty;
            dadosTable.Rows.Add(rowEmpyt);

            int AnoAtual = DateTime.Now.Year;

            for (int i = AnoAtual; i <= AnoAtual + 5; i++)
            {
                rowEmpyt = dadosTable.NewRow();
                rowEmpyt["Key"] = i;
                rowEmpyt["Value"] = i.ToString();
                dadosTable.Rows.Add(rowEmpyt);
            }

            return dadosTable;
        }

        public DataTable ListaDeHoraAgenda()
        {
            DataTable dadosTable = new DataTable();
            DataColumn columnKey = new DataColumn("Key");
            DataColumn columnValue = new DataColumn("Value");
            DataRow rowEmpyt;

            dadosTable.Columns.Add(columnKey);
            dadosTable.Columns.Add(columnValue);

            rowEmpyt = dadosTable.NewRow();
            rowEmpyt["Key"] = 0;
            rowEmpyt["Value"] = string.Empty;
            dadosTable.Rows.Add(rowEmpyt);
                        
            for (int i = 0; i < 24; i++)
            {
                rowEmpyt = dadosTable.NewRow();
                rowEmpyt["Key"] = i;
                rowEmpyt["Value"] = i.ToString().PadLeft(2,'0');
                dadosTable.Rows.Add(rowEmpyt);
            }

            return dadosTable;
        }

        public DataTable ListaDeMinutoAgenda()
        {
            DataTable dadosTable = new DataTable();
            DataColumn columnKey = new DataColumn("Key");
            DataColumn columnValue = new DataColumn("Value");
            DataRow rowEmpyt;

            dadosTable.Columns.Add(columnKey);
            dadosTable.Columns.Add(columnValue);

            rowEmpyt = dadosTable.NewRow();
            rowEmpyt["Key"] = 0;
            rowEmpyt["Value"] = string.Empty;
            dadosTable.Rows.Add(rowEmpyt);

            for (int i = 0; i < 60; i++)
            {
                rowEmpyt = dadosTable.NewRow();
                rowEmpyt["Key"] = i;
                rowEmpyt["Value"] = i.ToString().PadLeft(2, '0');
                dadosTable.Rows.Add(rowEmpyt);
            }

            return dadosTable;
        }

        public DataTable ListaDeComplemento()
        {
            DataTable dadosTable = new DataTable();
            DataColumn columnKey = new DataColumn("Key");
            DataColumn columnValue = new DataColumn("Value");
            DataRow rowEmpyt;

            dadosTable.Columns.Add(columnKey);
            dadosTable.Columns.Add(columnValue);

            rowEmpyt = dadosTable.NewRow();
            rowEmpyt["Key"] = 0;
            rowEmpyt["Value"] = string.Empty;
            dadosTable.Rows.Add(rowEmpyt);

            rowEmpyt = dadosTable.NewRow();
            rowEmpyt["Key"] = "Apto";
            rowEmpyt["Value"] = "Apto";
            dadosTable.Rows.Add(rowEmpyt);

            rowEmpyt = dadosTable.NewRow();
            rowEmpyt["Key"] = "Bloco";
            rowEmpyt["Value"] = "Bloco";
            dadosTable.Rows.Add(rowEmpyt);

            rowEmpyt = dadosTable.NewRow();
            rowEmpyt["Key"] = "Casa";
            rowEmpyt["Value"] = "Casa";
            dadosTable.Rows.Add(rowEmpyt);

            rowEmpyt = dadosTable.NewRow();
            rowEmpyt["Key"] = "Fundos";
            rowEmpyt["Value"] = "Fundos";
            dadosTable.Rows.Add(rowEmpyt);

            rowEmpyt = dadosTable.NewRow();
            rowEmpyt["Key"] = "Lote";
            rowEmpyt["Value"] = "Lote";
            dadosTable.Rows.Add(rowEmpyt);

            rowEmpyt = dadosTable.NewRow();
            rowEmpyt["Key"] = "Quadra";
            rowEmpyt["Value"] = "Quadra";
            dadosTable.Rows.Add(rowEmpyt);

            return dadosTable;
        }
        
        public DataTable ListaDePerguntaFeedBackRecepcao()
        {
            DataTable dadosTable = new DataTable();
            DataColumn columnKey = new DataColumn("Key");
            DataColumn columnValue = new DataColumn("Value");
            DataRow rowEmpyt;

            dadosTable.Columns.Add(columnKey);
            dadosTable.Columns.Add(columnValue);

            rowEmpyt = dadosTable.NewRow();
            rowEmpyt["Key"] = 0;
            rowEmpyt["Value"] = string.Empty;
            dadosTable.Rows.Add(rowEmpyt);

            rowEmpyt = dadosTable.NewRow();
            rowEmpyt["Key"] = (int)FeedBackRecepcao.MuitoReceptivo;
            rowEmpyt["Value"] = FeedBackRecepcao.MuitoReceptivo.GetStringValue();
            dadosTable.Rows.Add(rowEmpyt);

            rowEmpyt = dadosTable.NewRow();
            rowEmpyt["Key"] = (int)FeedBackRecepcao.Receptivo;
            rowEmpyt["Value"] = FeedBackRecepcao.Receptivo.GetStringValue();
            dadosTable.Rows.Add(rowEmpyt);

            rowEmpyt = dadosTable.NewRow();
            rowEmpyt["Key"] = (int)FeedBackRecepcao.Indiferente;
            rowEmpyt["Value"] = FeedBackRecepcao.Indiferente.GetStringValue();
            dadosTable.Rows.Add(rowEmpyt);

            rowEmpyt = dadosTable.NewRow();
            rowEmpyt["Key"] = (int)FeedBackRecepcao.PoucoReceptivo;
            rowEmpyt["Value"] = FeedBackRecepcao.PoucoReceptivo.GetStringValue();
            dadosTable.Rows.Add(rowEmpyt);

            return dadosTable;
        }

        public DataTable ListaDePerguntaFeedBackProposta()
        {
            DataTable dadosTable = new DataTable();
            DataColumn columnKey = new DataColumn("Key");
            DataColumn columnValue = new DataColumn("Value");
            DataRow rowEmpyt;

            dadosTable.Columns.Add(columnKey);
            dadosTable.Columns.Add(columnValue);

            rowEmpyt = dadosTable.NewRow();
            rowEmpyt["Key"] = 0;
            rowEmpyt["Value"] = string.Empty;
            dadosTable.Rows.Add(rowEmpyt);

            rowEmpyt = dadosTable.NewRow();
            rowEmpyt["Key"] = (int)FeedBackProposta.Sim;
            rowEmpyt["Value"] = FeedBackProposta.Sim.GetStringValue();
            dadosTable.Rows.Add(rowEmpyt);

            rowEmpyt = dadosTable.NewRow();
            rowEmpyt["Key"] = (int)FeedBackProposta.Nao;
            rowEmpyt["Value"] = FeedBackProposta.Nao.GetStringValue();
            dadosTable.Rows.Add(rowEmpyt);

            return dadosTable;
        }

        public DataTable ListaDePerguntaFeedBackMotivoNao()
        {
            DataTable dadosTable = new DataTable();
            DataColumn columnKey = new DataColumn("Key");
            DataColumn columnValue = new DataColumn("Value");
            DataRow rowEmpyt;

            dadosTable.Columns.Add(columnKey);
            dadosTable.Columns.Add(columnValue);

            rowEmpyt = dadosTable.NewRow();
            rowEmpyt["Key"] = 0;
            rowEmpyt["Value"] = string.Empty;
            dadosTable.Rows.Add(rowEmpyt);

            rowEmpyt = dadosTable.NewRow();
            rowEmpyt["Key"] = (int)FeedBackMotivoNao.Agendado;
            rowEmpyt["Value"] = FeedBackMotivoNao.Agendado.GetStringValue();
            dadosTable.Rows.Add(rowEmpyt);

            rowEmpyt = dadosTable.NewRow();
            rowEmpyt["Key"] = (int)FeedBackMotivoNao.Contato3Dias;
            rowEmpyt["Value"] = FeedBackMotivoNao.Contato3Dias.GetStringValue();
            dadosTable.Rows.Add(rowEmpyt);

            rowEmpyt = dadosTable.NewRow();
            rowEmpyt["Key"] = (int)FeedBackMotivoNao.Cliente;
            rowEmpyt["Value"] = FeedBackMotivoNao.Cliente.GetStringValue();
            dadosTable.Rows.Add(rowEmpyt);

            rowEmpyt = dadosTable.NewRow();
            rowEmpyt["Key"] = (int)FeedBackMotivoNao.Completo81Anos;
            rowEmpyt["Value"] = FeedBackMotivoNao.Completo81Anos.GetStringValue();
            dadosTable.Rows.Add(rowEmpyt);

            rowEmpyt = dadosTable.NewRow();
            rowEmpyt["Key"] = (int)FeedBackMotivoNao.AgregadoOutro;
            rowEmpyt["Value"] = FeedBackMotivoNao.AgregadoOutro.GetStringValue();
            dadosTable.Rows.Add(rowEmpyt);

            rowEmpyt = dadosTable.NewRow();
            rowEmpyt["Key"] = (int)FeedBackMotivoNao.SeguroVidaOutro;
            rowEmpyt["Value"] = FeedBackMotivoNao.SeguroVidaOutro.GetStringValue();
            dadosTable.Rows.Add(rowEmpyt);

            rowEmpyt = dadosTable.NewRow();
            rowEmpyt["Key"] = (int)FeedBackMotivoNao.FuneralOutro;
            rowEmpyt["Value"] = FeedBackMotivoNao.FuneralOutro.GetStringValue();
            dadosTable.Rows.Add(rowEmpyt);

            rowEmpyt = dadosTable.NewRow();
            rowEmpyt["Key"] = (int)FeedBackMotivoNao.SemFinanceiro;
            rowEmpyt["Value"] = FeedBackMotivoNao.SemFinanceiro.GetStringValue();
            dadosTable.Rows.Add(rowEmpyt);

            rowEmpyt = dadosTable.NewRow();
            rowEmpyt["Key"] = (int)FeedBackMotivoNao.Desempregado;
            rowEmpyt["Value"] = FeedBackMotivoNao.Desempregado.GetStringValue();
            dadosTable.Rows.Add(rowEmpyt);

            rowEmpyt = dadosTable.NewRow();
            rowEmpyt["Key"] = (int)FeedBackMotivoNao.NaoInformado;
            rowEmpyt["Value"] = FeedBackMotivoNao.NaoInformado.GetStringValue();
            dadosTable.Rows.Add(rowEmpyt);

            rowEmpyt = dadosTable.NewRow();
            rowEmpyt["Key"] = (int)FeedBackMotivoNao.SemInteresse;
            rowEmpyt["Value"] = FeedBackMotivoNao.SemInteresse.GetStringValue();
            dadosTable.Rows.Add(rowEmpyt);

            return dadosTable;
        }
    }
}

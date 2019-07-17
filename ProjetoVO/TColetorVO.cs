using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoVO
{
    [Serializable]
    public class TColetorVO
    {
        public Int32 IDColetor { get; set; }

        public String NumeroSerie { get; set; }

        public String IMEI { get; set; }

        public String Fabricante { get; set; }

        public String Modelo { get; set; }

        public Int32? IDUsuarioResponsavel { get; set; }

        public Int32 IDUsuarioCadastro { get; set; }

        public String NomeUsuarioResponsavel { get; set; }

        public String NomeUsuarioCadastro { get; set; }

        public DateTime DataCadastro { get; set; }

        public Boolean Ativo { get; set; }

        public String GridAtivo { get { return Ativo ? "Sim" : "Não"; } }

        public Boolean? ConsultaAtivo { get; set; }

        public DateTime? DataInativacao { get; set; }

        public Boolean UsoBackup { get; set; }

        public String GridUsoBackup { get { return UsoBackup ? "Sim" : "Não"; } }

        public Boolean? ConsultaUsoBackup { get; set; }

        public String MotivoInativacao { get; set; }

        public DateTime? DataUltimaSincronizacao { get; set; }

        public DateTime? DataInativacaoInicio { get; set; }

        public DateTime? DataInativacaoFim { get; set; }

        public DateTime? DataUltimaSincronizacaoInicio { get; set; }

        public DateTime? DataUltimaSincronizacaoFim { get; set; }

        public String IDColetorIDVendedor { get { return IDColetor.ToString() +'#'+IDUsuarioResponsavel.GetValueOrDefault() ;} }

        public DateTime? DataRelatorioInicio { get; set; }

        public DateTime? DataRelatorioFinal { get; set; }

        public String TipoRelatorio { get; set; }

        public String NomeVendedor { get; set; }

        public String UnidadeVendedor { get; set; }

        public Int32? NumeroFaixaCarregadas { get; set; }

        public Boolean? TodasFaixaCarregadas { get; set; }

        public Int32? IDUsuarioVendedor { get; set; }

    }
}

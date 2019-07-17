using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjetoVO;
using ProjetoDAL.Banco;

namespace ProjetoDAL
{
    public class MobileTSimuladorProdutoBLL
    {
        #region [ ListarRelatorioHistoricoSimulador ]

        public IQueryable<MobileTSimuladorProdutoVO> ListarRelatorioHistoricoSimulador(MobileTSimuladorProdutoVO filtro)
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.MobileTSimuladorProduto
                         join funeral in banco.MobileTSimuladorSubFuneral on new { registro.IDSimuladorProduto, registro.CodigoEntrevista } equals new { funeral.IDSimuladorProduto, funeral.CodigoEntrevista }
                         join entrevista in banco.MobileTEntrevista on registro.CodigoEntrevista equals entrevista.CodigoEntrevista
                         join entrevistado in banco.MobileTEntrevistado on registro.CodigoEntrevista equals entrevistado.CodigoEntrevista
                         join upload in banco.HistoricoTEntrevistaUpload on registro.CodigoEntrevista equals upload.CodigoEntrevista
                         join usuario in banco.TUsuario on entrevista.CodigoUsuario equals usuario.IDUsuario
                         select new MobileTSimuladorProdutoVO
                         {
                             IDSimuladorProduto = registro.IDSimuladorProduto,

                             CodigoEntrevista = registro.CodigoEntrevista,

                             Produto = registro.Produto,

                             PremioTotal = registro.PremioTotal,

                             FaixaEtaria = registro.FaixaEtaria.HasValue ? registro.FaixaEtaria.Value : 0,

                             FaixaEtariaConjuge = registro.FaixaEtariaConjuge.HasValue ? registro.FaixaEtariaConjuge.Value : 0,

                             RespostaBaseRenda = registro.RespostaBaseRenda.HasValue ? registro.RespostaBaseRenda.Value : 0,

                             RespostaBaseDisposto = registro.RespostaBaseDisposto.HasValue ? registro.RespostaBaseDisposto.Value : 0,

                             TipoRegistro = registro.TipoRegistro,

                             NomeVendedor = usuario.Abreviado,

                             NumeroColetor = upload.HistoricoTSincronismo.HistoricoTColetor.NumeroColetor,

                             DataEntrevista = entrevista.DataEntrevista.HasValue ? entrevista.DataEntrevista.Value : DateTime.Now,

                             NomeEntrevistado = entrevistado.Nome,

                             CPFEntrevistado = entrevistado.CPF,

                             ProtecaoCategoriaFuneral = funeral.ProtecaoCategoria,

                             ProtecaoPremioFuneral = funeral.ProtecaoPremio,

                             ProtecaoCapitalFuneral = funeral.ProtecaoCoberturaMorte,

                             CasalCategoriaFuneral = funeral.CasalCategoria,

                             CasalPremioFuneral = funeral.CasalPremio,

                             CasalCapitalFuneral = funeral.CasalCoberturaMorte,

                             SeniorCategoriaFuneral = funeral.SeniorCategoria,

                             SeniorPremioFuneral = funeral.SeniorPremio,

                             SeniorCapitalFuneral = funeral.SeniorCoberturaMorte,

                             NumeroAgregados = banco.MobileTSimuladorSubAgregado.Where(w => w.IDSimuladorProduto == registro.IDSimuladorProduto && w.CodigoEntrevista == registro.CodigoEntrevista).Count(),

                             PremioAgregados = banco.MobileTSimuladorSubAgregado.Where(w => w.IDSimuladorProduto == registro.IDSimuladorProduto && w.CodigoEntrevista == registro.CodigoEntrevista).Sum(r => r.PremioAgregado),

                             PremioRenda = banco.MobileTSimuladorSubRenda.Where(w => w.IDSimuladorProduto == registro.IDSimuladorProduto && w.CodigoEntrevista == registro.CodigoEntrevista).FirstOrDefault().PremioRenda,

                             Proposta = banco.MobileTResposta.Where(r =>r.CodigoEntrevista == registro.CodigoEntrevista && r.CodigoPergunta.Value == 36 && r.CodigoOpcao == 1).Select(s => s.TextoSubResposta).FirstOrDefault(),

                         }).AsQueryable();


            if (!string.IsNullOrEmpty(filtro.NumeroColetor))
                query = query.Where(registro => registro.NumeroColetor.Contains(filtro.NumeroColetor));

            if (!string.IsNullOrEmpty(filtro.NomeVendedor))
                query = query.Where(registro => registro.NomeVendedor.Contains(filtro.NomeVendedor));
                        
            if (filtro.DataEntrevistaInicio.HasValue)
                query = query.Where(registro => registro.DataEntrevista >= filtro.DataEntrevistaInicio.Value);

            if (filtro.DataEntrevistaFinal.HasValue)
                query = query.Where(registro => registro.DataEntrevista <= filtro.DataEntrevistaFinal.Value);

            if (filtro.CodigoEntrevista > 0)
                query = query.Where(registro => registro.CodigoEntrevista == filtro.CodigoEntrevista);

            if (!filtro.ExibirCompleto)
                query = query.Where(registro => !registro.TipoRegistro.Equals("H"));

            query = query.OrderBy(order => order.CodigoEntrevista).ThenBy(order => order.IDSimuladorProduto);

            return query;
        }

        #endregion
    }
}

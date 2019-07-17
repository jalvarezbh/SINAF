CREATE TABLE [dbo].[MobileTSimuladorProduto] (
    [CodigoEntrevista]     BIGINT         NOT NULL,
    [Produto]              NVARCHAR (50)  NOT NULL,
    [PremioTotal]          NUMERIC (8, 2) NOT NULL,
    [FaixaEtaria]          INT            NULL,
    [FaixaEtariaConjuge]   INT            NULL,
    [RespostaBaseRenda]    INT            NULL,
    [RespostaBaseDisposto] INT            NULL,
    [IDSimuladorProduto] BIGINT NOT NULL, 
    [TipoRegistro] NCHAR(1) NOT NULL, 
    CONSTRAINT [MobileTSimuladorProduto_PK] PRIMARY KEY CLUSTERED ([CodigoEntrevista] ASC, [IDSimuladorProduto] ASC) WITH (STATISTICS_NORECOMPUTE = ON)
);


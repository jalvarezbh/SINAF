CREATE TABLE [dbo].[MobileTSimuladorSubFuneral] (
    [CodigoEntrevista]            BIGINT         NOT NULL,
    [ProtecaoCoberturaMorte]      NUMERIC (8, 2) NULL,
    [ProtecaoCoberturaAcidente]   NUMERIC (8, 2) NULL,
    [ProtecaoCoberturaEmergencia] NUMERIC (8, 2) NULL,
    [ProtecaoCategoria]           NVARCHAR (50)  NULL,
    [ProtecaoPremio]              NUMERIC (8, 2) NULL,
    [SeniorCoberturaMorte]        NUMERIC (8, 2) NULL,
    [SeniorCategoria]             NVARCHAR (50)  NULL,
    [SeniorPremio]                NUMERIC (8, 2) NULL,
    [CasalCoberturaMorte]         NUMERIC (8, 2) NULL,
    [CasalCoberturaConjuge]       NUMERIC (8, 2) NULL,
    [CasalCategoria]              NVARCHAR (50)  NULL,
    [CasalPremio]                 NUMERIC (8, 2) NULL,
    [IDSimuladorProduto] BIGINT NOT NULL, 
    CONSTRAINT [MobileTSimuladorSubFuneral_PK] PRIMARY KEY CLUSTERED ([CodigoEntrevista] ASC, [IDSimuladorProduto] ASC) WITH (STATISTICS_NORECOMPUTE = ON)
);


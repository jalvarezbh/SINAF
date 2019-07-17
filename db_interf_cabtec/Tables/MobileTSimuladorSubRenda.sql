CREATE TABLE [dbo].[MobileTSimuladorSubRenda] (
    [CodigoEntrevista] BIGINT         NOT NULL,
    [Periodo]          NVARCHAR (50)  NOT NULL,
    [ValorRenda]       NUMERIC (8, 2) NOT NULL,
    [Capital]          NUMERIC (8, 2) NOT NULL,
    [PremioRenda]      NUMERIC (8, 2) NOT NULL,
    [IDSimuladorProduto] BIGINT NOT NULL, 
    CONSTRAINT [MobileTSimuladorSubRenda_PK] PRIMARY KEY CLUSTERED ([CodigoEntrevista] ASC, [IDSimuladorProduto] ASC) WITH (STATISTICS_NORECOMPUTE = ON)
);


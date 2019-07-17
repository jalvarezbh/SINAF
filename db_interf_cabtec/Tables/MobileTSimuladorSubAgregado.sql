CREATE TABLE [dbo].[MobileTSimuladorSubAgregado] (
    [IDSimuladorSubAgregado] BIGINT         IDENTITY (1, 1) NOT NULL,
    [CodigoEntrevista]       BIGINT         NOT NULL,
    [GrauParentesco]         NVARCHAR (50)  NOT NULL,
    [Idade]                  INT            NOT NULL,
    [PremioAgregado]         NUMERIC (8, 2) NOT NULL,
    [Funeral]                NVARCHAR (50)  NOT NULL,
    [IDSimuladorProduto] BIGINT NOT NULL, 
    CONSTRAINT [MobileTSimuladorSubAgregado_PK] PRIMARY KEY CLUSTERED ([IDSimuladorSubAgregado] ASC, [CodigoEntrevista] ASC, [IDSimuladorProduto] ASC) WITH (STATISTICS_NORECOMPUTE = ON)
);


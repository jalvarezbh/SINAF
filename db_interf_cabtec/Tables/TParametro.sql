CREATE TABLE [dbo].[TParametro] (
    [IDParametro]               INT IDENTITY (1, 1) NOT NULL,
    [TempoLogOff]               INT NULL,
    [PrazoSincronismoDia]       INT NULL,
    [EstoqueMaximoWeb]          INT NULL,
    [EstoqueMinimoWeb]          INT NULL,
    [EstoqueMaximoColetor]      INT NULL,
    [EstoqueMinimoColetor]      INT NULL,
    [TempoDadosServidorDias]    INT NULL,
    [TempoVerificaERPDias]      INT NULL,
    [VersaoBaseCorreio]         INT NULL,
    [TempoEntrevistaColetor]    INT NULL,
    [TempoEntrevistaIncompleta] INT NULL,
    CONSTRAINT [PK_TParametro] PRIMARY KEY CLUSTERED ([IDParametro] ASC) WITH (STATISTICS_NORECOMPUTE = ON)
);


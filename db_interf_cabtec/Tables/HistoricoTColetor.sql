CREATE TABLE [dbo].[HistoricoTColetor] (
    [IDHistoricoColetor]     INT          IDENTITY (1, 1) NOT NULL,
    [NumeroColetor]          VARCHAR (50) NOT NULL,
    [DataUltimoSincronismo]  DATETIME     NOT NULL,
    [NumeroTotalSincronismo] INT          NOT NULL,
    [NumeroTotalEntrevista]  INT          NOT NULL,
    [VersaoSistema]          VARCHAR (12) DEFAULT ('1.0.1.0') NOT NULL,
    CONSTRAINT [PK_HistoricoTColetor] PRIMARY KEY CLUSTERED ([IDHistoricoColetor] ASC) WITH (STATISTICS_NORECOMPUTE = ON)
);


CREATE TABLE [dbo].[HistoricoTSincronismo] (
    [IDHistoricoSincronismo] INT      IDENTITY (1, 1) NOT NULL,
    [IDHistoricoColetor]     INT      NOT NULL,
    [DataSincronismo]        DATETIME NOT NULL,
    [NumeroUpload]           INT      NOT NULL,
    [NumeroDownload]         INT      NOT NULL,
    [IDVendedor]             INT      NOT NULL,
    CONSTRAINT [PK_HistoricoTSincronismo] PRIMARY KEY CLUSTERED ([IDHistoricoSincronismo] ASC) WITH (STATISTICS_NORECOMPUTE = ON),
    CONSTRAINT [FK_HistoricoTSincronismo_HistoricoTColetor] FOREIGN KEY ([IDHistoricoColetor]) REFERENCES [dbo].[HistoricoTColetor] ([IDHistoricoColetor]),
    CONSTRAINT [FK_HistoricoTSincronismo_TUsuario] FOREIGN KEY ([IDVendedor]) REFERENCES [dbo].[TUsuario] ([IDUsuario])
);


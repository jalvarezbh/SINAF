CREATE TABLE [dbo].[HistoricoTEntrevistaDownload] (
    [IDHistoricoEntrevistaDownload] INT        IDENTITY (1, 1) NOT NULL,
    [CodigoEntrevista]              FLOAT (53) NOT NULL,
    [IDHistoricoSincronismo]        INT        NOT NULL,
    CONSTRAINT [PK_HistoricoTEntrevistaDownload] PRIMARY KEY CLUSTERED ([IDHistoricoEntrevistaDownload] ASC) WITH (STATISTICS_NORECOMPUTE = ON),
    CONSTRAINT [FK_HistoricoTEntrevistaDownload_HistoricoTSincronismo] FOREIGN KEY ([IDHistoricoSincronismo]) REFERENCES [dbo].[HistoricoTSincronismo] ([IDHistoricoSincronismo])
);


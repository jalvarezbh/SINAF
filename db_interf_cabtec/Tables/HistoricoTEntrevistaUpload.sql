CREATE TABLE [dbo].[HistoricoTEntrevistaUpload] (
    [IDHistoricoEntrevistaUpload] INT        IDENTITY (1, 1) NOT NULL,
    [CodigoEntrevista]            FLOAT (53) NOT NULL,
    [IDHistoricoSincronismo]      INT        NOT NULL,
    CONSTRAINT [PK_HistoricoTEntrevistaUpload] PRIMARY KEY CLUSTERED ([IDHistoricoEntrevistaUpload] ASC) WITH (STATISTICS_NORECOMPUTE = ON),
    CONSTRAINT [FK_HistoricoTEntrevistaUpload_HistoricoTSincronismo] FOREIGN KEY ([IDHistoricoSincronismo]) REFERENCES [dbo].[HistoricoTSincronismo] ([IDHistoricoSincronismo])
);


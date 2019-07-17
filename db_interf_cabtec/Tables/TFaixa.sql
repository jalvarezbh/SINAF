CREATE TABLE [dbo].[TFaixa] (
    [IDFaixa]                         INT        IDENTITY (1, 1) NOT NULL,
    [CodigoFaixa]                     FLOAT (53) NOT NULL,
    [Usado]                           BIT        NOT NULL,
    [IDResponsavel]                   INT        NULL,
    [DataDownloadBase]                DATETIME   NULL,
    [DataUtilizado]                   DATETIME   NULL,
    [IDHistoricoTSincronismoDownload] INT        NULL,
    [IDHistoricoTSincronismoUpload]   INT        NULL,
    PRIMARY KEY CLUSTERED ([IDFaixa] ASC) WITH (STATISTICS_NORECOMPUTE = ON),
    CONSTRAINT [FK_TFaixa_TUsuario] FOREIGN KEY ([IDResponsavel]) REFERENCES [dbo].[TUsuario] ([IDUsuario])
);


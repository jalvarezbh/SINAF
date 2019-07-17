CREATE TABLE [dbo].[MobileTEntrevista] (
    [CodigoEntrevista]   BIGINT       NOT NULL,
    [CodigoColaborador]  SMALLINT     NULL,
    [DataEntrevista]     DATETIME     NULL,
    [CodigoUsuario]      INT          NOT NULL,
    [DataInclusao]       DATETIME     NULL,
    [CodigoQuestionario] SMALLINT     NULL,
    [OrigemVenda]        NVARCHAR (3) NULL,
    [Exportado]          BIT          NULL,
    CONSTRAINT [MobileTEntrevista_PK] PRIMARY KEY CLUSTERED ([CodigoEntrevista] ASC) WITH (STATISTICS_NORECOMPUTE = ON)
);


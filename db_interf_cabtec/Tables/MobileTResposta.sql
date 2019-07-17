CREATE TABLE [dbo].[MobileTResposta] (
    [CodigoEntrevista]  BIGINT        NOT NULL,
    [CodigoPergunta]    SMALLINT      NULL,
    [CodigoOpcao]       INT           NULL,
    [CodigoSeqResposta] INT           NULL,
    [TextoResposta]     NVARCHAR (50) NULL,
    [TextoSubResposta]  NVARCHAR (50) NULL,
    [IDResposta]        INT           IDENTITY (1, 1) NOT NULL,
    [Exportado]         BIT           NULL,
    CONSTRAINT [MobileTResposta_PK] PRIMARY KEY CLUSTERED ([IDResposta] ASC) WITH (STATISTICS_NORECOMPUTE = ON)
);


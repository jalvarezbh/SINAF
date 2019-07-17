CREATE TABLE [dbo].[MobileTIncompletaResposta] (
    [CodigoEntrevista]     BIGINT        NOT NULL,
    [CodigoPergunta]       SMALLINT      NULL,
    [CodigoOpcao]          INT           NULL,
    [CodigoSeqResposta]    INT           NULL,
    [TextoResposta]        NVARCHAR (50) NULL,
    [TextoSubResposta]     NVARCHAR (50) NULL,
    [IDIncompletaResposta] INT           IDENTITY (1, 1) NOT NULL,
    CONSTRAINT [MobileTIncompletaResposta_PK] PRIMARY KEY CLUSTERED ([IDIncompletaResposta] ASC) WITH (STATISTICS_NORECOMPUTE = ON)
);


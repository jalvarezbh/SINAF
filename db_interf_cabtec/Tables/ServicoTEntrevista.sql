CREATE TABLE [dbo].[ServicoTEntrevista] (
    [IDServico]         INT           IDENTITY (1, 1) NOT NULL,
    [CodigoEntrevista]  BIGINT        NOT NULL,
    [CodigoColaborador] SMALLINT      NULL,
    [DataEntrevista]    DATETIME      NULL,
    [Mensagem]          VARCHAR (250) NULL,
    [DataErro]          DATETIME      NULL,
    CONSTRAINT [PK_ServicoTEntrevista] PRIMARY KEY CLUSTERED ([IDServico] ASC) WITH (STATISTICS_NORECOMPUTE = ON)
);


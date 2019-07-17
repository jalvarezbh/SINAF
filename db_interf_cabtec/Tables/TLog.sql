CREATE TABLE [dbo].[TLog] (
    [IDLog]     INT          IDENTITY (1, 1) NOT NULL,
    [Tabela]    VARCHAR (50) NOT NULL,
    [IDUsuario] INT          NOT NULL,
    [Data]      DATETIME     NOT NULL,
    [Tipo]      VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_TLog] PRIMARY KEY CLUSTERED ([IDLog] ASC) WITH (STATISTICS_NORECOMPUTE = ON),
    CONSTRAINT [FK_TLog_TUsuario] FOREIGN KEY ([IDUsuario]) REFERENCES [dbo].[TUsuario] ([IDUsuario])
);


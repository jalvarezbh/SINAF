CREATE TABLE [dbo].[TAtendimento] (
    [IDAtendimento] INT IDENTITY (1, 1) NOT NULL,
    [IDFilial]      INT NOT NULL,
    [IDBairro]      INT NOT NULL,
    [IDCidade]      INT NOT NULL,
    CONSTRAINT [PK_TAtendimento] PRIMARY KEY CLUSTERED ([IDAtendimento] ASC) WITH (STATISTICS_NORECOMPUTE = ON),
    CONSTRAINT [FK_TAtendimento_TFilial] FOREIGN KEY ([IDFilial]) REFERENCES [dbo].[TFilial] ([IDFilial])
);


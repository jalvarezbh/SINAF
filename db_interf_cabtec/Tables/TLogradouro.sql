CREATE TABLE [dbo].[TLogradouro] (
    [IDLogradouro]   INT            IDENTITY (1, 1) NOT NULL,
    [NomeLogradouro] NVARCHAR (100) NOT NULL,
    [IDBairro]       INT            NOT NULL,
    [CEP]            INT            NOT NULL,
    [IDCidade]       INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([IDLogradouro] ASC) WITH (STATISTICS_NORECOMPUTE = ON),
    CONSTRAINT [TBairro_FK] FOREIGN KEY ([IDBairro]) REFERENCES [dbo].[TBairro] ([IDBairro]),
    CONSTRAINT [TCidade_LOGFK] FOREIGN KEY ([IDCidade]) REFERENCES [dbo].[TCidade] ([IDCidade])
);


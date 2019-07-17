CREATE TABLE [dbo].[TBairro] (
    [IDBairro]   INT            IDENTITY (1, 1) NOT NULL,
    [NomeBairro] NVARCHAR (100) NOT NULL,
    [IDCidade]   INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([IDBairro] ASC) WITH (STATISTICS_NORECOMPUTE = ON),
    CONSTRAINT [TCidade_FK] FOREIGN KEY ([IDCidade]) REFERENCES [dbo].[TCidade] ([IDCidade])
);


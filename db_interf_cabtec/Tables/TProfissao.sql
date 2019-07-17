CREATE TABLE [dbo].[TProfissao] (
    [IDProfissao]     INT            NOT NULL,
    [NomeProfissao]   NVARCHAR (100) NOT NULL,
    [CapitalLimitado] BIT            NOT NULL,
    PRIMARY KEY CLUSTERED ([IDProfissao] ASC) WITH (STATISTICS_NORECOMPUTE = ON)
);


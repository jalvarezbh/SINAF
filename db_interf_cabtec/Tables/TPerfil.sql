CREATE TABLE [dbo].[TPerfil] (
    [IDPerfil]  INT          IDENTITY (1, 1) NOT NULL,
    [Descricao] VARCHAR (50) NOT NULL,
    [Ativo]     BIT          NULL,
    CONSTRAINT [PK_TPerfil] PRIMARY KEY CLUSTERED ([IDPerfil] ASC) WITH (STATISTICS_NORECOMPUTE = ON)
);


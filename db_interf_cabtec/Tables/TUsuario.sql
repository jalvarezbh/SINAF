CREATE TABLE [dbo].[TUsuario] (
    [IDUsuario]         INT          IDENTITY (1, 1) NOT NULL,
    [Nome]              VARCHAR (50) NOT NULL,
    [Login]             VARCHAR (50) NOT NULL,
    [Senha]             VARCHAR (50) NOT NULL,
    [IDPerfil]          INT          NOT NULL,
    [Email]             VARCHAR (50) NULL,
    [CodigoColaborador] INT          NOT NULL,
    [Unidade]           VARCHAR (50) NOT NULL,
    [Cargo]             VARCHAR (50) NULL,
    [Ativo]             BIT          NOT NULL,
    [Abreviado] VARCHAR(50) NOT NULL DEFAULT '', 
    CONSTRAINT [PK_TUsuario] PRIMARY KEY CLUSTERED ([IDUsuario] ASC) WITH (STATISTICS_NORECOMPUTE = ON),
    CONSTRAINT [FK_TUsuario_TPerfil] FOREIGN KEY ([IDPerfil]) REFERENCES [dbo].[TPerfil] ([IDPerfil])
);


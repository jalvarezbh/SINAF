CREATE TABLE [dbo].[TPerfilCargo] (
    [IDPerfilCargo] INT          IDENTITY (1, 1) NOT NULL,
    [IDPerfil]      INT          NOT NULL,
    [Cargo]         VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_TPerfilCargo] PRIMARY KEY CLUSTERED ([IDPerfilCargo] ASC) WITH (STATISTICS_NORECOMPUTE = ON),
    CONSTRAINT [FK_TPerfilCargo_TPerfil] FOREIGN KEY ([IDPerfil]) REFERENCES [dbo].[TPerfil] ([IDPerfil])
);


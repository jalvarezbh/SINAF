CREATE TABLE [dbo].[TMenuPerfil] (
    [IDMenuPerfil] INT IDENTITY (1, 1) NOT NULL,
    [IDMenu]       INT NULL,
    [IDPerfil]     INT NULL,
    [Ativo]        BIT NULL,
    CONSTRAINT [PK_TMenuPerfil] PRIMARY KEY CLUSTERED ([IDMenuPerfil] ASC) WITH (STATISTICS_NORECOMPUTE = ON),
    CONSTRAINT [FK_TMenuPerfil_TMenu] FOREIGN KEY ([IDMenu]) REFERENCES [dbo].[TMenu] ([IDMenu]),
    CONSTRAINT [FK_TMenuPerfil_TPerfil] FOREIGN KEY ([IDPerfil]) REFERENCES [dbo].[TPerfil] ([IDPerfil])
);


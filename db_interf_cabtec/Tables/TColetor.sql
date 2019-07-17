CREATE TABLE [dbo].[TColetor] (
    [IDColetor]                INT          IDENTITY (1, 1) NOT NULL,
    [NumeroSerie]              VARCHAR (50) NOT NULL,
    [IMEI]                     VARCHAR (50) NOT NULL,
    [Fabricante]               VARCHAR (50) NOT NULL,
    [Modelo]                   VARCHAR (50) NOT NULL,
    [CodigoUsuarioResponsavel] INT          NULL,
    [CodigoUsuarioCadastro]    INT          NOT NULL,
    [DataCadastro]             DATETIME     NOT NULL,
    [Ativo]                    BIT          NOT NULL,
    [DataInativacao]           DATETIME     NULL,
    [UsoBackup]                BIT          NOT NULL,
    [MotivoInativacao]         VARCHAR (50) NULL,
    [DataUltimaSincronizacao]  DATETIME     NULL,
    CONSTRAINT [PK_TColetor] PRIMARY KEY CLUSTERED ([IDColetor] ASC) WITH (STATISTICS_NORECOMPUTE = ON)
);


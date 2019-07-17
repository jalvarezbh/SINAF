CREATE TABLE [dbo].[MobileTEntrevistado] (
    [CodigoEntrevista]       BIGINT        NOT NULL,
    [Nome]                   NVARCHAR (50) NULL,
    [CPF]                    NVARCHAR (14) NULL,
    [DataNascimento]         DATETIME      NULL,
    [EstadoCivil]            SMALLINT      NULL,
    [IDProfissao]            SMALLINT      NULL,
    [FaixaEtaria]            SMALLINT      NULL,
    [FaixaEtariaConjuge]     SMALLINT      NULL,
    [IDProfissaoConjuge]     SMALLINT      NULL,
    [CapitalLimitado]        NVARCHAR (1)  NULL,
    [CapitalLimitadoConjuge] NVARCHAR (1)  NULL,
    [DDD]                    NVARCHAR (2)  NULL,
    [Telefone]               NVARCHAR (13) NULL,
    [DDDCelular]             NVARCHAR (2)  NULL,
    [Celular]                NVARCHAR (13) NULL,
    [Sexo]                   NVARCHAR (1)  NULL,
    [Informacao]             BIT           NULL,
    [Exportado]              BIT           NULL,
    CONSTRAINT [MobileTEntrevistado_PK] PRIMARY KEY CLUSTERED ([CodigoEntrevista] ASC) WITH (STATISTICS_NORECOMPUTE = ON)
);


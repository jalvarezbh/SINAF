﻿CREATE TABLE [dbo].[MobileTIncompleta] (
    [CodigoEntrevista]       BIGINT        NOT NULL,
    [DataEntrevista]         DATETIME      NOT NULL,
    [CodigoUsuario]          INT           NULL,
    [CapitalLimitado]        NVARCHAR (1)  NULL,
    [CapitalLimitadoConjuge] NVARCHAR (1)  NULL,
    [Celular]                NVARCHAR (13) NULL,
    [CPF]                    NVARCHAR (14) NULL,
    [DataNascimento]         DATETIME      NULL,
    [DataNascimentoConjuge]  DATETIME      NULL,
    [DDD]                    NVARCHAR (2)  NULL,
    [DDDCelular]             NVARCHAR (2)  NULL,
    [EstadoCivil]            SMALLINT      NULL,
    [FaixaEtaria]            SMALLINT      NULL,
    [FaixaEtariaConjuge]     SMALLINT      NULL,
    [IDProfissao]            SMALLINT      NULL,
    [IDProfissaoConjuge]     SMALLINT      NULL,
    [Nome]                   NVARCHAR (50) NULL,
    [Sexo]                   NVARCHAR (1)  NULL,
    [Telefone]               NVARCHAR (13) NULL,
    [Bairro]                 NVARCHAR (50) NULL,
    [CEP]                    NVARCHAR (8)  NULL,
    [Cidade]                 NVARCHAR (50) NULL,
    [Complemento]            NVARCHAR (50) NULL,
    [Email]                  NVARCHAR (50) NULL,
    [Endereco]               NVARCHAR (50) NULL,
    [Numero]                 INT           NULL,
    [UF]                     NVARCHAR (2)  NULL,
    [Motivo]                 NVARCHAR (50) NULL,
    [DataInclusao]           DATETIME      NULL,
    CONSTRAINT [PK_MobileTIncompleta] PRIMARY KEY CLUSTERED ([CodigoEntrevista] ASC)
);


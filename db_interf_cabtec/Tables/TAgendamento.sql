﻿CREATE TABLE [dbo].[TAgendamento] (
    [IDAgendamento]        INT           IDENTITY (1, 1) NOT NULL,
    [Nome]                 VARCHAR (50)  NOT NULL,
    [DataNascimento]       DATETIME      NOT NULL,
    [Email]                VARCHAR (50)  NULL,
    [Telefone]             VARCHAR (20)  NULL,
    [Celular]              VARCHAR (20)  NULL,
    [CEP]                  INT           NOT NULL,
    [Logradouro]           VARCHAR (100) NOT NULL,
    [Numero]               INT           NULL,
    [Complemento]          VARCHAR (50)  NULL,
    [Bairro]               VARCHAR (100) NOT NULL,
    [Cidade]               VARCHAR (100) NOT NULL,
    [UF]                   VARCHAR (2)   NOT NULL,
    [PontoReferencia]      VARCHAR (250) NULL,
    [IDUsuarioAgendamento] INT           NOT NULL,
    [IDUsuarioVendedor]    INT           NULL,
    [IDAtendimento]        INT           NULL,
    [DataAgendada]         DATETIME      NULL,
    CONSTRAINT [PK_TAgendamento] PRIMARY KEY CLUSTERED ([IDAgendamento] ASC) WITH (STATISTICS_NORECOMPUTE = ON),
    CONSTRAINT [FK_TAgendamento_TAtendimento] FOREIGN KEY ([IDAtendimento]) REFERENCES [dbo].[TAtendimento] ([IDAtendimento]),
    CONSTRAINT [FK_TAgendamento_TUsuario] FOREIGN KEY ([IDUsuarioAgendamento]) REFERENCES [dbo].[TUsuario] ([IDUsuario]),
    CONSTRAINT [FK_TAgendamento_TUsuario1] FOREIGN KEY ([IDUsuarioVendedor]) REFERENCES [dbo].[TUsuario] ([IDUsuario])
);


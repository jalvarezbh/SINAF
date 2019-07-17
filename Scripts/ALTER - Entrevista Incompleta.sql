USE [db_interf_cabtec]
GO

CREATE TABLE [dbo].[MobileTIncompleta](
	[CodigoEntrevista] [bigint] NOT NULL,
	[DataEntrevista] [datetime] NOT NULL,
	[CodigoUsuario] [int] NULL,
	[CapitalLimitado] [nvarchar](1) NULL,
	[CapitalLimitadoConjuge] [nvarchar](1) NULL,
	[Celular] [nvarchar](13) NULL,
	[CPF] [nvarchar](14) NULL,
	[DataNascimento] [datetime] NULL,
	[DataNascimentoConjuge] [datetime] NULL,
	[DDD] [nvarchar](2) NULL,
	[DDDCelular] [nvarchar](2) NULL,
	[EstadoCivil] [smallint] NULL,
	[FaixaEtaria] [smallint] NULL,
	[FaixaEtariaConjuge] [smallint] NULL,
	[IDProfissao] [smallint] NULL,
	[IDProfissaoConjuge] [smallint] NULL,
	[Nome] [nvarchar](50) NULL,
	[Sexo] [nvarchar](1) NULL,
	[Telefone] [nvarchar](13) NULL,
	[Bairro] [nvarchar](50) NULL,
	[CEP] [nvarchar](8) NULL,
	[Cidade] [nvarchar](50) NULL,
	[Complemento] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Endereco] [nvarchar](50) NULL,
	[Numero] [int] NULL,
	[UF] [nvarchar](2) NULL,
	[Motivo] [nvarchar](50) NULL,
 CONSTRAINT [PK_MobileTIncompleta] PRIMARY KEY CLUSTERED 
(
	[CodigoEntrevista] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

USE [db_interf_cabtec]
GO
CREATE TABLE [dbo].[MobileTIncompletaResposta](
	[CodigoEntrevista] [bigint] NOT NULL,
	[CodigoPergunta] [smallint] NULL,
	[CodigoOpcao] [int] NULL,
	[CodigoSeqResposta] [int] NULL,
	[TextoResposta] [nvarchar](50) NULL,
	[TextoSubResposta] [nvarchar](50) NULL,
	[IDIncompletaResposta] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [MobileTIncompletaResposta_PK] PRIMARY KEY CLUSTERED 
(
	[IDIncompletaResposta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = ON, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

USE [db_interf_cabtec]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TParametro]') AND type in (N'U'))
DROP TABLE [dbo].[TParametro]
GO

USE [db_interf_cabtec]
GO

CREATE TABLE [dbo].[TParametro](
	[IDParametro] [int] IDENTITY(1,1) NOT NULL,
	[TempoLogOff] [int] NULL,
	[PrazoSincronismoDia] [int] NULL,
	[EstoqueMaximoWeb] [int] NULL,
	[EstoqueMinimoWeb] [int] NULL,
	[EstoqueMaximoColetor] [int] NULL,
	[EstoqueMinimoColetor] [int] NULL,
	[TempoDadosServidorDias] [int] NULL,
	[TempoVerificaERPDias] [int] NULL,
	[VersaoBaseCorreio] [int] NULL,
	[TempoEntrevistaColetor] [int] NULL,
	[TempoEntrevistaIncompleta] [int] NULL,
 CONSTRAINT [PK_TParametro] PRIMARY KEY CLUSTERED 
(
	[IDParametro] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = ON, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

USE [db_interf_cabtec]
GO

ALTER TABLE HistoricoTColetor
ADD VersaoSistema varchar(12) NOT NULL DEFAULT '1.0.1.0'
GO
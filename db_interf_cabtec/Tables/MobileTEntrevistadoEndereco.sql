CREATE TABLE [dbo].[MobileTEntrevistadoEndereco] (
    [CodigoEntrevista] BIGINT        NOT NULL,
    [Endereco]         NVARCHAR (50) NULL,
    [Numero]           INT           NULL,
    [Bairro]           NVARCHAR (50) NULL,
    [Cidade]           NVARCHAR (50) NULL,
    [UF]               NVARCHAR (2)  NULL,
    [CEP]              NVARCHAR (8)  NULL,
    [Complemento]      NVARCHAR (50) NULL,
    [Email]            NVARCHAR (50) NULL,
    [Exportado]        BIT           NULL,
    CONSTRAINT [MobileTEntrevistadoEndereco_PK] PRIMARY KEY CLUSTERED ([CodigoEntrevista] ASC) WITH (STATISTICS_NORECOMPUTE = ON)
);


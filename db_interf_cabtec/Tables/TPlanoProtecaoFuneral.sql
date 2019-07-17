CREATE TABLE [dbo].[TPlanoProtecaoFuneral] (
    [IDPlanoProtecaoFuneral] INT            IDENTITY (1, 1) NOT NULL,
    [Categoria]              VARCHAR (50)   NOT NULL,
    [Codigo]                 INT            NOT NULL,
    [Ate_20]                 NUMERIC (8, 2) NULL,
    [De_21_40]               NUMERIC (8, 2) NULL,
    [De_41_50]               NUMERIC (8, 2) NULL,
    [De_51_60]               NUMERIC (8, 2) NULL,
    [De_61_65]               NUMERIC (8, 2) NULL,
    [De_66_70]               NUMERIC (8, 2) NULL,
    [De_71_75]               NUMERIC (8, 2) NULL,
    [De_76_80]               NUMERIC (8, 2) NULL,
    CONSTRAINT [PK_TPlanoProtecaoFuneral] PRIMARY KEY CLUSTERED ([IDPlanoProtecaoFuneral] ASC) WITH (STATISTICS_NORECOMPUTE = ON)
);


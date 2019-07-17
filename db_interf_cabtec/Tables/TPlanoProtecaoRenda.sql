CREATE TABLE [dbo].[TPlanoProtecaoRenda] (
    [IDPlanoProtecaoRenda]  INT            IDENTITY (1, 1) NOT NULL,
    [RendaPeriodo]          VARCHAR (50)   NOT NULL,
    [CoberturaRendaMensal]  NUMERIC (8, 2) NOT NULL,
    [CoberturaCapitalTotal] NUMERIC (8, 2) NOT NULL,
    [Premio_18_30]          NUMERIC (8, 2) NULL,
    [Premio_31_40]          NUMERIC (8, 2) NULL,
    [Premio_41_45]          NUMERIC (8, 2) NULL,
    [Premio_46_50]          NUMERIC (8, 2) NULL,
    [Premio_51_55]          NUMERIC (8, 2) NULL,
    [Premio_56_60]          NUMERIC (8, 2) NULL,
    [Premio_61_65]          NUMERIC (8, 2) NULL,
    CONSTRAINT [PK_TPlanoProtecaoRenda] PRIMARY KEY CLUSTERED ([IDPlanoProtecaoRenda] ASC) WITH (STATISTICS_NORECOMPUTE = ON)
);


CREATE TABLE [dbo].[TPlanoProtecao] (
    [IDPlanoProtecao]     INT            IDENTITY (1, 1) NOT NULL,
    [Codigo]              INT            NOT NULL,
    [CoberturaMorte]      NUMERIC (8, 2) NOT NULL,
    [CoberturaAcidente]   NUMERIC (8, 2) NOT NULL,
    [CoberturaEmergencia] NUMERIC (8, 2) NOT NULL,
    [Premio_18_30]        NUMERIC (8, 2) NULL,
    [Premio_31_40]        NUMERIC (8, 2) NULL,
    [Premio_41_45]        NUMERIC (8, 2) NULL,
    [Premio_46_50]        NUMERIC (8, 2) NULL,
    [Premio_51_55]        NUMERIC (8, 2) NULL,
    [Premio_56_60]        NUMERIC (8, 2) NULL,
    [Premio_61_65]        NUMERIC (8, 2) NULL,
    [NomePlano]           VARCHAR (50)   NOT NULL,
    CONSTRAINT [PK_TPlanoProtecao] PRIMARY KEY CLUSTERED ([IDPlanoProtecao] ASC) WITH (STATISTICS_NORECOMPUTE = ON)
);


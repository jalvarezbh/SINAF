CREATE TABLE [dbo].[TPlanoCasal] (
    [IDPlanoCasal]     INT            IDENTITY (1, 1) NOT NULL,
    [Codigo]           INT            NOT NULL,
    [NomePlano]        VARCHAR (50)   NOT NULL,
    [CoberturaMorte]   NUMERIC (8, 2) NOT NULL,
    [CoberturaConjuge] NUMERIC (8, 2) NOT NULL,
    [Premio_61_65]     NUMERIC (8, 2) NULL,
    [Premio_66_70]     NUMERIC (8, 2) NULL,
    [Premio_71_75]     NUMERIC (8, 2) NULL,
    [Premio_76_80]     NUMERIC (8, 2) NULL,
    CONSTRAINT [PK_TPlanoSeniorCasal] PRIMARY KEY CLUSTERED ([IDPlanoCasal] ASC) WITH (STATISTICS_NORECOMPUTE = ON)
);


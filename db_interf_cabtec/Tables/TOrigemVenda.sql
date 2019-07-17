CREATE TABLE [dbo].[TOrigemVenda] (
    [IDOrigemVenda]     INT          IDENTITY (1, 1) NOT NULL,
    [CodigoOrigemVenda] VARCHAR (3)  NOT NULL,
    [NomeOrigemVenda]   VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([IDOrigemVenda] ASC) WITH (STATISTICS_NORECOMPUTE = ON)
);


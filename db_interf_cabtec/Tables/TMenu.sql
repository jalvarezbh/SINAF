CREATE TABLE [dbo].[TMenu] (
    [IDMenu]    INT          IDENTITY (1, 1) NOT NULL,
    [Descricao] VARCHAR (50) NOT NULL,
    [IDMenuPai] INT          NULL,
    [Mobile]    BIT          NULL,
    [Url]       VARCHAR (50) NOT NULL,
    [Ordenacao] INT          NOT NULL,
    CONSTRAINT [PK_TMenu] PRIMARY KEY CLUSTERED ([IDMenu] ASC) WITH (STATISTICS_NORECOMPUTE = ON)
);


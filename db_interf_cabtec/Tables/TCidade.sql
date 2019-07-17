CREATE TABLE [dbo].[TCidade] (
    [IDCidade]   INT            IDENTITY (1, 1) NOT NULL,
    [NomeCidade] NVARCHAR (100) NOT NULL,
    [IDEstado]   INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([IDCidade] ASC) WITH (STATISTICS_NORECOMPUTE = ON),
    CONSTRAINT [TEstado_FK] FOREIGN KEY ([IDEstado]) REFERENCES [dbo].[TEstado] ([IDEstado])
);


CREATE TABLE [dbo].[MobileTGPS] (
    [IDMobileTGPS]     INT           IDENTITY (1, 1) NOT NULL,
    [CodigoEntrevista] BIGINT        NULL,
    [Latitude]         NVARCHAR (15) NULL,
    [Longitude]        NVARCHAR (15) NULL,
    [DataCadastro]     DATETIME      NULL,
    CONSTRAINT [MobileTGPS_PK] PRIMARY KEY CLUSTERED ([IDMobileTGPS] ASC) WITH (STATISTICS_NORECOMPUTE = ON)
);


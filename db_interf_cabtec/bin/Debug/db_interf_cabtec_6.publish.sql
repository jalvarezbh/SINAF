﻿/*
Deployment script for db_interf_cabtec

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "db_interf_cabtec"
:setvar DefaultFilePrefix "db_interf_cabtec"
:setvar DefaultDataPath "C:\Arquivos de programas\Microsoft SQL Server\MSSQL.1\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Arquivos de programas\Microsoft SQL Server\MSSQL.1\MSSQL\DATA\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
PRINT N'Starting rebuilding table [dbo].[MobileTSimuladorProduto]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_MobileTSimuladorProduto] (
    [CodigoEntrevista]     BIGINT         NOT NULL,
    [Produto]              NVARCHAR (50)  NOT NULL,
    [PremioTotal]          NUMERIC (8, 2) NOT NULL,
    [FaixaEtaria]          INT            NULL,
    [FaixaEtariaConjuge]   INT            NULL,
    [RespostaBaseRenda]    INT            NULL,
    [RespostaBaseDisposto] INT            NULL,
    [IDSimuladorProduto]   BIGINT         NOT NULL,
    [TipoRegistro]         NCHAR (1)      NOT NULL,
    CONSTRAINT [tmp_ms_xx_constraint_MobileTSimuladorProduto_PK] PRIMARY KEY CLUSTERED ([CodigoEntrevista] ASC, [IDSimuladorProduto] ASC) WITH (STATISTICS_NORECOMPUTE = ON)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[MobileTSimuladorProduto])
    BEGIN
        INSERT INTO [dbo].[tmp_ms_xx_MobileTSimuladorProduto] ([CodigoEntrevista], [IDSimuladorProduto], [Produto], [PremioTotal], [FaixaEtaria], [FaixaEtariaConjuge], [RespostaBaseRenda], [RespostaBaseDisposto], [TipoRegistro])
        SELECT   [CodigoEntrevista],
                 [IDSimuladorProduto],
                 [Produto],
                 [PremioTotal],
                 [FaixaEtaria],
                 [FaixaEtariaConjuge],
                 [RespostaBaseRenda],
                 [RespostaBaseDisposto],
                 [TipoRegistro]
        FROM     [dbo].[MobileTSimuladorProduto]
        ORDER BY [CodigoEntrevista] ASC, [IDSimuladorProduto] ASC;
    END

DROP TABLE [dbo].[MobileTSimuladorProduto];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_MobileTSimuladorProduto]', N'MobileTSimuladorProduto';

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_constraint_MobileTSimuladorProduto_PK]', N'MobileTSimuladorProduto_PK', N'OBJECT';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Update complete.';


GO

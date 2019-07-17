ALTER TABLE TEntrevista
ADD Completa bit NOT NULL DEFAULT 'true'
GO

ALTER TABLE TEntrevista
ADD Motivo nvarchar(50)
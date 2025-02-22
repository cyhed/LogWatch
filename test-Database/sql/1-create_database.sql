-- Создание базы данных
CREATE DATABASE SURIMI_PROD;
GO

-- Переключение на созданную базу данных
USE SURIMI_PROD;
GO

-- Создание таблицы для хранения номеров участков
CREATE TABLE dbo.AreaNumbers (
	AREANUMBER nvarchar(4) COLLATE Cyrillic_General_CI_AS NOT NULL,
	DESCRIPTION nvarchar(64) COLLATE Cyrillic_General_CI_AS NOT NULL,
	CONSTRAINT PK_AreaNumbers PRIMARY KEY (AREANUMBER)
);
GO

-- Создание таблицы для хранения статусов логов
CREATE TABLE dbo.LogsStatusCodes (
	STATUS nvarchar(2) COLLATE Cyrillic_General_CI_AS NOT NULL,
	DESCRIPTION nvarchar(255) COLLATE Cyrillic_General_CI_AS NOT NULL,
	Importance bit NULL,
	CONSTRAINT PK_LogsStatusCodes PRIMARY KEY (STATUS)
);
GO

-- Создание таблицы для хранения логов
CREATE TABLE dbo.Logs (
	GUID nvarchar(36) COLLATE Cyrillic_General_CI_AS 
         DEFAULT (CONVERT(nvarchar(36), NEWID())) NOT NULL,
	[DATETIME] datetime DEFAULT GETDATE() NOT NULL,
	AREANUMBER nvarchar(4) COLLATE Cyrillic_General_CI_AS NULL,
	LINEID nvarchar(3) COLLATE Cyrillic_General_CI_AS NULL,
	STATUS nvarchar(2) COLLATE Cyrillic_General_CI_AS NULL,
	CONSTRAINT PK_Logs PRIMARY KEY (GUID, [DATETIME])
);
GO

CREATE NONCLUSTERED INDEX ix_status 
  ON dbo.Logs (STATUS) 
  INCLUDE ([DATETIME]);
GO

-- Добавление внешних ключей

ALTER TABLE dbo.Logs 
ADD CONSTRAINT FK_Logs_AreaNumbers 
FOREIGN KEY (AREANUMBER) 
REFERENCES dbo.AreaNumbers(AREANUMBER);
GO

ALTER TABLE dbo.Logs 
ADD CONSTRAINT FK_Logs_LogsStatusCodes 
FOREIGN KEY (STATUS) 
REFERENCES dbo.LogsStatusCodes(STATUS) 
ON DELETE SET NULL 
ON UPDATE CASCADE;
GO

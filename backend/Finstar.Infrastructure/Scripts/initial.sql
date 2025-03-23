BEGIN TRAN
IF NOT EXISTS(SELECT [name] FROM [sys].[databases] WHERE [name] = 'Finstar')
	CREATE DATABASE [Finstar]

IF NOT EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id('dbo.items'))
	CREATE TABLE [dbo].[items] (
		[id] INT PRIMARY KEY,
		[code] INT,
		[value] VARCHAR(MAX)
);

IF (NOT EXISTS(SELECT * FROM sys.types WHERE name = 'ItemsTableType'))
CREATE TYPE [ItemsTableType] AS TABLE (
		[id] INT PRIMARY KEY,
		[code] INT,
		[value] VARCHAR(MAX)
);
COMMIT TRAN

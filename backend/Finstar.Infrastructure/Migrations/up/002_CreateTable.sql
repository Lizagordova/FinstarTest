IF NOT EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id('dbo.items'))
CREATE TABLE [dbo].[items] (
    [id] INT PRIMARY KEY,
    [code] INT,
    [value] VARCHAR(MAX)
    );
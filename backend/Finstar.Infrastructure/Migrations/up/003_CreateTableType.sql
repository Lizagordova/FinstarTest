IF (NOT EXISTS(SELECT * FROM sys.types WHERE name = 'ItemsTableType'))
CREATE TYPE [ItemsTableType] AS TABLE (
    [id] INT PRIMARY KEY,
    [code] INT,
    [value] VARCHAR(MAX)
);
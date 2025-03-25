IF EXISTS (SELECT * FROM sys.procedures  WHERE name  ='p_items_insert')  
    DROP PROCEDURE [dbo].[p_items_insert] 
GO

CREATE PROCEDURE [dbo].[p_items_insert]
	@items [ItemsTableType] READONLY
AS
BEGIN
	BEGIN TRAN
	DELETE FROM [items];

	INSERT INTO [items] SELECT * FROM @items;
	COMMIT
END
GO

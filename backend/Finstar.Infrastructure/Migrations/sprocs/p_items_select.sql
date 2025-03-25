IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID('[dbo].[p_items_select]'))  
    DROP PROCEDURE [dbo].[p_items_select] 
GO

CREATE Procedure [dbo].[p_items_select]
	@codeFilter INT = NULL,
	@valueFilter VARCHAR(MAX) = NULL,
	@offset INT = 0,
	@pageSize INT = 10
AS
BEGIN
	SELECT *
	FROM [items]
	WHERE ((@codeFilter IS NULL) OR ([code] = @codeFilter)) AND
		((@valueFilter IS NULL) OR ([value] = @valueFilter))
	ORDER BY [id]
	OFFSET @offset ROWS
	FETCH NEXT @pageSize ROWS ONLY;

    SELECT COUNT(*)
    FROM [items]
    WHERE ((@codeFilter IS NULL) OR ([code] = @codeFilter)) AND
    ((@valueFilter IS NULL) OR ([value] = @valueFilter)) 
END
GO
CREATE PROCEDURE sp_GetAllBlogPosts 	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT PostId, Title, Creator, Dt FROM BlogPosts
END
USE [DataStore]
GO

IF EXISTS(SELECT * FROM sys.objects WHERE type = 'P' AND name = 'Update_Product_By_Id')
DROP PROCEDURE Update_Product_By_Id
GO

CREATE PROCEDURE [dbo].[Update_Product_By_Id]
	@Id UNIQUEIDENTIFIER,
	@Name VARCHAR(100),
    @CreationDate DATETIME2,
    @UpdateDate DATETIME2
AS
BEGIN
	UPDATE [dbo].[Product]
	   SET [Name] = @Name
		  ,[CreationDate] = @CreationDate
		  ,[UpdateDate] = @UpdateDate
	 WHERE [Id] = @Id
END
GO
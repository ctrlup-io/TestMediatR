USE [DataStore]
GO

IF EXISTS(SELECT * FROM sys.objects WHERE type = 'P' AND name = 'Delete_Product_By_Id')
DROP PROCEDURE Delete_Product_By_Id
GO

CREATE PROCEDURE [dbo].[Delete_Product_By_Id]
	@Id UNIQUEIDENTIFIER
AS
BEGIN
DELETE FROM [dbo].[Product]
      WHERE [Id] = @Id
END
GO
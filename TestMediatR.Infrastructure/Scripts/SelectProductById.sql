USE [DataStore]
GO

IF EXISTS(SELECT * FROM sys.objects WHERE type = 'P' AND name = 'Select_Product_By_Id')
DROP PROCEDURE Select_Product_By_Id
GO

CREATE PROCEDURE [dbo].[Select_Product_By_Id]
@Id UNIQUEIDENTIFIER
AS
BEGIN
SELECT [Id]
      ,[Name]
      ,[CreationDate]
      ,[UpdateDate]
  FROM [dbo].[Product]
  WHERE [Id] = @Id
END
GO

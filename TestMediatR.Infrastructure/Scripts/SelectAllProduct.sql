USE [DataStore]
GO

IF EXISTS(SELECT * FROM sys.objects WHERE type = 'P' AND name = 'Select_All_Product')
DROP PROCEDURE Select_All_Product
GO

CREATE PROCEDURE [dbo].[Select_All_Product]
AS
BEGIN
SELECT [Id]
      ,[Name]
      ,[CreationDate]
      ,[UpdateDate]
  FROM [dbo].[Product]
END
GO

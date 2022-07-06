USE [DataStore]
GO

IF EXISTS(SELECT * FROM sys.objects WHERE type = 'P' AND name = 'Insert_Product')
DROP PROCEDURE Insert_Product
GO

CREATE PROCEDURE [dbo].[Insert_Product]
    @Name VARCHAR(100),
    @CreationDate DATETIME2,
    @UpdateDate DATETIME2
AS
BEGIN
INSERT INTO [dbo].[Product]
           ([Name]
           ,[CreationDate]
           ,[UpdateDate])
     VALUES
           (@Name
           ,@CreationDate
           ,@UpdateDate)
END
GO
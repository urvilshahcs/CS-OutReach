CREATE DATABASE UTDallasCSOutreach
GO

USE UTDallasCSOutreach
GO

GO
CREATE TABLE DynamicMenu(MenuID varbinary(50) PRIMARY KEY,MenuName varchar(1000),URL varchar(1000))
GO

CREATE PROC ListAllMenuItems
AS
BEGIN
SELECT * FROM DynamicMenu 
END
GO

CREATE PROC AddMenuItem (@MenuName varchar(1000), @URL varchar(1000))
AS
BEGIN
INSERT INTO DynamicMenu VALUES(HASHBYTES('MD5',CONCAT(@MenuName,SYSDATETIME())),@MenuName,@URL)
END
GO

EXEC AddMenuItem 'Coding Club','http://localhost/Pages/Common/CodingClub.aspx'
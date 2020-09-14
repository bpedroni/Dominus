USE master;
GO

-- Delete the dominus database if it exists.
IF EXISTS(SELECT * from sys.databases WHERE name='dominus')
BEGIN
    DROP DATABASE dominus;
END
-- Create a new database called dominus.
CREATE DATABASE dominus;
GO

-- Delete the etesp login if it exists.
IF EXISTS(SELECT * from sys.syslogins WHERE name='etesp')
BEGIN
	DROP LOGIN etesp;
END
-- Create a new login called etesp.  
CREATE LOGIN etesp WITH PASSWORD=N'etesp',
DEFAULT_DATABASE = dominus,
CHECK_EXPIRATION = OFF,
CHECK_POLICY = OFF
GO

USE dominus;
GO

-- Create a new user called etesp.  
CREATE USER etesp FOR LOGIN etesp

-- Add the necessary roles for the etesp user.
ALTER ROLE db_datareader ADD MEMBER etesp
ALTER ROLE db_datawriter ADD MEMBER etesp
ALTER ROLE db_ddladmin ADD MEMBER etesp
ALTER ROLE db_owner ADD MEMBER etesp
GO

USE master;
GO

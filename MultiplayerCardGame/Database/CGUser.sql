CREATE TABLE [dbo].[User]
(
	[Id] Varchar(50) NOT NULL PRIMARY KEY,
	[userName] varchar(20) NOT NULL,
	[email] varchar(30) NOT NULL,
	[UserPassword] varchar(30) NOT NULL,
	[tableId] int,
	[userType] varchar(20), 
    [UserStatus] VARCHAR(20)
)

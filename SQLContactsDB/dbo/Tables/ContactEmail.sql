CREATE TABLE [dbo].[ContactEmail]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ContactId] INT NOT NULL, 
    [EmailAdressId] INT NOT NULL
)

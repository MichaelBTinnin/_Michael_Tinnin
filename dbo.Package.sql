CREATE TABLE [dbo].[Package]
(
	[PackageId] UNIQUEIDENTIFIER NOT NULL,
	[SenderId]  UNIQUEIDENTIFIER NOT NULL,
	[RecipientId] UNIQUEIDENTIFIER NOT NULL,
	[Weight]    INT,
	[CostPerOunce] INT,
	[Type] varchar (50)
)

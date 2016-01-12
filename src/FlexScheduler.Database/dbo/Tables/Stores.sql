CREATE TABLE [dbo].[Stores] (
    [Id]     BIGINT        IDENTITY (1, 1) NOT NULL,
    [Name]   NVARCHAR (35) NOT NULL,
	[Street] NVARCHAR(35) NOT NULL,
    [City]   NVARCHAR (35) NOT NULL,
    [State]  CHAR (2)      NOT NULL,
    [Zip]    NVARCHAR (6)  NOT NULL,
    CONSTRAINT [PK_Stores_Id] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [UQ_Stores] UNIQUE NONCLUSTERED ([Name] ASC)
);


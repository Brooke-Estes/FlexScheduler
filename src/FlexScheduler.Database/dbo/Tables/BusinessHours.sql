CREATE TABLE [dbo].[BusinessHours] (
    [Id]            BIGINT         IDENTITY (1, 1) NOT NULL,
    [Discriminator] NVARCHAR (15)  NOT NULL,
    [Store]         NVARCHAR (35)  NOT NULL,
    [StartOfWeek]   DATETIME       NOT NULL,
    [EndOfWeek]     DATETIME       NOT NULL,
    [Hours]         NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_BusinessHours] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [UQ_BusinessHours] UNIQUE NONCLUSTERED ([Discriminator] ASC, [Store] ASC, [StartOfWeek] ASC, [EndOfWeek] ASC)
);


﻿CREATE TABLE [dbo].[Email] (
    [Id] int NOT NULL,
    [Value]  NVARCHAR (MAX) NOT NULL,
    [Name]   NVARCHAR (MAX) NOT NULL, 
    CONSTRAINT [PK_Email_Id] PRIMARY KEY CLUSTERED (Id)
);


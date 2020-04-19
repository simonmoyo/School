﻿CREATE TABLE [dbo].[Students]
(
    [ID] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [Name] VARCHAR(50) NOT NULL,
    [Subjects] VARCHAR(250) NOT NULL,
    [ClassID] VARCHAR(250) NOT NULL,
    [AddedOn] DATE NOT NULL DEFAULT GETDATE()
)

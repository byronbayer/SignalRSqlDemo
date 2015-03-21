CREATE TABLE [dbo].[JobInfo] (
    [JobId]  INT          NOT NULL,
    [Name]   VARCHAR (50) NULL,
    [Status] VARCHAR (50) NULL,
    CONSTRAINT [PK_JobInfo] PRIMARY KEY CLUSTERED ([JobId] ASC)
);


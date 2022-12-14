Build started...
Build succeeded.
The Entity Framework tools version '6.0.9' is older than that of the runtime '6.0.10'. Update the tools for the latest features and bug fixes. See https://aka.ms/AAc1fbw for more information.
info: Microsoft.EntityFrameworkCore.Infrastructure[10403]
      Entity Framework Core 6.0.10 initialized 'DBGame' using provider 'Microsoft.EntityFrameworkCore.SqlServer:6.0.10' with options: None
IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Users] (
    [UserId] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Gmail] nvarchar(max) NOT NULL,
    [Password] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([UserId])
);
GO

CREATE TABLE [Games] (
    [GameId] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Status] bit NOT NULL,
    [UserId] int NULL,
    CONSTRAINT [PK_Games] PRIMARY KEY ([GameId]),
    CONSTRAINT [FK_Games_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([UserId])
);
GO

CREATE TABLE [Quizzes] (
    [QuizId] int NOT NULL IDENTITY,
    [GameId] int NOT NULL,
    [Question] nvarchar(max) NOT NULL,
    [Option1] nvarchar(max) NOT NULL,
    [Option2] nvarchar(max) NOT NULL,
    [Option3] nvarchar(max) NOT NULL,
    [Option4] nvarchar(max) NOT NULL,
    [Correct] int NOT NULL,
    CONSTRAINT [PK_Quizzes] PRIMARY KEY ([QuizId]),
    CONSTRAINT [FK_Quizzes_Games_GameId] FOREIGN KEY ([GameId]) REFERENCES [Games] ([GameId]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Games_UserId] ON [Games] ([UserId]);
GO

CREATE INDEX [IX_Quizzes_GameId] ON [Quizzes] ([GameId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221018192537_FirstVersion', N'6.0.10');
GO

COMMIT;
GO



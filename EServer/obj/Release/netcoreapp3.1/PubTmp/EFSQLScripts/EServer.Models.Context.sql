IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200917081451_InitialMigration')
BEGIN
    CREATE TABLE [Motorcycles] (
        [Id] uniqueidentifier NOT NULL,
        [Name] nvarchar(max) NULL,
        [Serialnumber] nvarchar(max) NULL,
        CONSTRAINT [PK_Motorcycles] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200917081451_InitialMigration')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name', N'Serialnumber') AND [object_id] = OBJECT_ID(N'[Motorcycles]'))
        SET IDENTITY_INSERT [Motorcycles] ON;
    INSERT INTO [Motorcycles] ([Id], [Name], [Serialnumber])
    VALUES ('dee4f94d-d127-498a-b238-7ce5d9350e0c', N'Yamaha XJ6', NULL);
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name', N'Serialnumber') AND [object_id] = OBJECT_ID(N'[Motorcycles]'))
        SET IDENTITY_INSERT [Motorcycles] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200917081451_InitialMigration')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200917081451_InitialMigration', N'3.1.8');
END;

GO


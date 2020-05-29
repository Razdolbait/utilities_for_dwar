
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/25/2019 15:49:41
-- Generated from EDMX file: D:\андрей\VS_project\PetsModels\PetsModels\Models\Pet.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [DWAR2];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ElementPet]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PetSet] DROP CONSTRAINT [FK_ElementPet];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[PetSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PetSet];
GO
IF OBJECT_ID(N'[dbo].[ElementSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ElementSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'PetSet'
CREATE TABLE [dbo].[PetSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Element_Id] int  NOT NULL
);
GO

-- Creating table 'ElementSet'
CREATE TABLE [dbo].[ElementSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'PetSet'
ALTER TABLE [dbo].[PetSet]
ADD CONSTRAINT [PK_PetSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ElementSet'
ALTER TABLE [dbo].[ElementSet]
ADD CONSTRAINT [PK_ElementSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Element_Id] in table 'PetSet'
ALTER TABLE [dbo].[PetSet]
ADD CONSTRAINT [FK_ElementPet]
    FOREIGN KEY ([Element_Id])
    REFERENCES [dbo].[ElementSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ElementPet'
CREATE INDEX [IX_FK_ElementPet]
ON [dbo].[PetSet]
    ([Element_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------
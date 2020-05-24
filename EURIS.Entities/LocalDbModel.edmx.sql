
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/24/2020 17:04:50
-- Generated from EDMX file: C:\Lavori\RICERCA LAVORO\Euris\EURISTest_vs2015_EN\EURIS.Entities\LocalDbModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [LocalDb];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Product]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Product];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Product'
CREATE TABLE [dbo].[Product] (
    [Code] nvarchar(10)  NOT NULL,
    [Description] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Catalog'
CREATE TABLE [dbo].[Catalog] (
    [Code] nvarchar(10)  NOT NULL,
    [Description] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'ProductCatalog'
CREATE TABLE [dbo].[ProductCatalog] (
    [Product_Code] nvarchar(10)  NOT NULL,
    [Catalog_Code] nvarchar(10)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Code] in table 'Product'
ALTER TABLE [dbo].[Product]
ADD CONSTRAINT [PK_Product]
    PRIMARY KEY CLUSTERED ([Code] ASC);
GO

-- Creating primary key on [Code] in table 'Catalog'
ALTER TABLE [dbo].[Catalog]
ADD CONSTRAINT [PK_Catalog]
    PRIMARY KEY CLUSTERED ([Code] ASC);
GO

-- Creating primary key on [Product_Code], [Catalog_Code] in table 'ProductCatalog'
ALTER TABLE [dbo].[ProductCatalog]
ADD CONSTRAINT [PK_ProductCatalog]
    PRIMARY KEY CLUSTERED ([Product_Code], [Catalog_Code] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Product_Code] in table 'ProductCatalog'
ALTER TABLE [dbo].[ProductCatalog]
ADD CONSTRAINT [FK_ProductCatalog_Product]
    FOREIGN KEY ([Product_Code])
    REFERENCES [dbo].[Product]
        ([Code])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Catalog_Code] in table 'ProductCatalog'
ALTER TABLE [dbo].[ProductCatalog]
ADD CONSTRAINT [FK_ProductCatalog_Catalog]
    FOREIGN KEY ([Catalog_Code])
    REFERENCES [dbo].[Catalog]
        ([Code])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductCatalog_Catalog'
CREATE INDEX [IX_FK_ProductCatalog_Catalog]
ON [dbo].[ProductCatalog]
    ([Catalog_Code]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------
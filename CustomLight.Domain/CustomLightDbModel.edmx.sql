
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/27/2017 07:46:53
-- Generated from EDMX file: D:\Work\VisualStudio\cl\CustomLight.Domain\CustomLightDbModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [CustomLight];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ProductCategories_Categories]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductCategories] DROP CONSTRAINT [FK_ProductCategories_Categories];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductCategories_Products]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductCategories] DROP CONSTRAINT [FK_ProductCategories_Products];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductImages_Images]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductImages] DROP CONSTRAINT [FK_ProductImages_Images];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductImages_Products]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductImages] DROP CONSTRAINT [FK_ProductImages_Products];
GO
IF OBJECT_ID(N'[dbo].[FK_ProjectCategories_Categories]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProjectCategories] DROP CONSTRAINT [FK_ProjectCategories_Categories];
GO
IF OBJECT_ID(N'[dbo].[FK_ProjectCategories_Projects]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProjectCategories] DROP CONSTRAINT [FK_ProjectCategories_Projects];
GO
IF OBJECT_ID(N'[dbo].[FK_ProjectImages_Images]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProjectImages] DROP CONSTRAINT [FK_ProjectImages_Images];
GO
IF OBJECT_ID(N'[dbo].[FK_ProjectImages_Projects]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProjectImages] DROP CONSTRAINT [FK_ProjectImages_Projects];
GO
IF OBJECT_ID(N'[dbo].[FK_Specifications_Products]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Specifications] DROP CONSTRAINT [FK_Specifications_Products];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Categories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Categories];
GO
IF OBJECT_ID(N'[dbo].[Images]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Images];
GO
IF OBJECT_ID(N'[dbo].[Pages]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pages];
GO
IF OBJECT_ID(N'[dbo].[ProductCategories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductCategories];
GO
IF OBJECT_ID(N'[dbo].[ProductImages]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductImages];
GO
IF OBJECT_ID(N'[dbo].[Products]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Products];
GO
IF OBJECT_ID(N'[dbo].[ProjectCategories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProjectCategories];
GO
IF OBJECT_ID(N'[dbo].[ProjectImages]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProjectImages];
GO
IF OBJECT_ID(N'[dbo].[Projects]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Projects];
GO
IF OBJECT_ID(N'[dbo].[Specifications]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Specifications];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Categories'
CREATE TABLE [dbo].[Categories] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [ShortDescription] nvarchar(max)  NULL,
    [Icon] varbinary(max)  NULL,
    [IconMimeType] nvarchar(max)  NULL,
    [Created] datetime  NOT NULL,
    [Updated] datetime  NOT NULL
);
GO

-- Creating table 'Images'
CREATE TABLE [dbo].[Images] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ImageData] varbinary(max)  NOT NULL,
    [ImageMimeType] nvarchar(max)  NOT NULL,
    [Created] datetime  NOT NULL,
    [Updated] datetime  NOT NULL
);
GO

-- Creating table 'Pages'
CREATE TABLE [dbo].[Pages] (
    [Id] int  NOT NULL,
    [Alias] nvarchar(max)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [PageContent] nvarchar(max)  NULL,
    [Created] datetime  NOT NULL,
    [Updated] datetime  NOT NULL
);
GO

-- Creating table 'Products'
CREATE TABLE [dbo].[Products] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [ShortDescription] nvarchar(max)  NULL,
    [Icon] varbinary(max)  NULL,
    [IconMimeType] nvarchar(max)  NULL,
    [IsPublished] bit  NOT NULL,
    [Created] datetime  NOT NULL,
    [Updated] datetime  NOT NULL
);
GO

-- Creating table 'Projects'
CREATE TABLE [dbo].[Projects] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [ShortDescription] nvarchar(max)  NULL,
    [Icon] varbinary(max)  NULL,
    [IconMimeType] nvarchar(max)  NULL,
    [IsPublished] bit  NOT NULL,
    [Created] datetime  NOT NULL,
    [Updated] datetime  NOT NULL
);
GO

-- Creating table 'Specifications'
CREATE TABLE [dbo].[Specifications] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Diameter] int  NULL,
    [Length] int  NULL,
    [Width] int  NULL,
    [Height] int  NULL,
    [Power] int  NULL,
    [LightOutput] int  NULL,
    [Price] float  NOT NULL,
    [Created] datetime  NOT NULL,
    [Updated] datetime  NOT NULL,
    [Product_Id] int  NOT NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'ProductCategories'
CREATE TABLE [dbo].[ProductCategories] (
    [Categories_Id] int  NOT NULL,
    [Products_Id] int  NOT NULL
);
GO

-- Creating table 'ProductImages'
CREATE TABLE [dbo].[ProductImages] (
    [Images_Id] int  NOT NULL,
    [Products_Id] int  NOT NULL
);
GO

-- Creating table 'ProjectCategories'
CREATE TABLE [dbo].[ProjectCategories] (
    [Categories_Id] int  NOT NULL,
    [Projects_Id] int  NOT NULL
);
GO

-- Creating table 'ProjectImages'
CREATE TABLE [dbo].[ProjectImages] (
    [Images_Id] int  NOT NULL,
    [Projects_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Categories'
ALTER TABLE [dbo].[Categories]
ADD CONSTRAINT [PK_Categories]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Images'
ALTER TABLE [dbo].[Images]
ADD CONSTRAINT [PK_Images]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Pages'
ALTER TABLE [dbo].[Pages]
ADD CONSTRAINT [PK_Pages]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [PK_Products]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Projects'
ALTER TABLE [dbo].[Projects]
ADD CONSTRAINT [PK_Projects]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Specifications'
ALTER TABLE [dbo].[Specifications]
ADD CONSTRAINT [PK_Specifications]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [Categories_Id], [Products_Id] in table 'ProductCategories'
ALTER TABLE [dbo].[ProductCategories]
ADD CONSTRAINT [PK_ProductCategories]
    PRIMARY KEY CLUSTERED ([Categories_Id], [Products_Id] ASC);
GO

-- Creating primary key on [Images_Id], [Products_Id] in table 'ProductImages'
ALTER TABLE [dbo].[ProductImages]
ADD CONSTRAINT [PK_ProductImages]
    PRIMARY KEY CLUSTERED ([Images_Id], [Products_Id] ASC);
GO

-- Creating primary key on [Categories_Id], [Projects_Id] in table 'ProjectCategories'
ALTER TABLE [dbo].[ProjectCategories]
ADD CONSTRAINT [PK_ProjectCategories]
    PRIMARY KEY CLUSTERED ([Categories_Id], [Projects_Id] ASC);
GO

-- Creating primary key on [Images_Id], [Projects_Id] in table 'ProjectImages'
ALTER TABLE [dbo].[ProjectImages]
ADD CONSTRAINT [PK_ProjectImages]
    PRIMARY KEY CLUSTERED ([Images_Id], [Projects_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Product_Id] in table 'Specifications'
ALTER TABLE [dbo].[Specifications]
ADD CONSTRAINT [FK_Specifications_Products]
    FOREIGN KEY ([Product_Id])
    REFERENCES [dbo].[Products]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Specifications_Products'
CREATE INDEX [IX_FK_Specifications_Products]
ON [dbo].[Specifications]
    ([Product_Id]);
GO

-- Creating foreign key on [Categories_Id] in table 'ProductCategories'
ALTER TABLE [dbo].[ProductCategories]
ADD CONSTRAINT [FK_ProductCategories_Categories]
    FOREIGN KEY ([Categories_Id])
    REFERENCES [dbo].[Categories]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Products_Id] in table 'ProductCategories'
ALTER TABLE [dbo].[ProductCategories]
ADD CONSTRAINT [FK_ProductCategories_Products]
    FOREIGN KEY ([Products_Id])
    REFERENCES [dbo].[Products]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductCategories_Products'
CREATE INDEX [IX_FK_ProductCategories_Products]
ON [dbo].[ProductCategories]
    ([Products_Id]);
GO

-- Creating foreign key on [Images_Id] in table 'ProductImages'
ALTER TABLE [dbo].[ProductImages]
ADD CONSTRAINT [FK_ProductImages_Images]
    FOREIGN KEY ([Images_Id])
    REFERENCES [dbo].[Images]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Products_Id] in table 'ProductImages'
ALTER TABLE [dbo].[ProductImages]
ADD CONSTRAINT [FK_ProductImages_Products]
    FOREIGN KEY ([Products_Id])
    REFERENCES [dbo].[Products]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductImages_Products'
CREATE INDEX [IX_FK_ProductImages_Products]
ON [dbo].[ProductImages]
    ([Products_Id]);
GO

-- Creating foreign key on [Categories_Id] in table 'ProjectCategories'
ALTER TABLE [dbo].[ProjectCategories]
ADD CONSTRAINT [FK_ProjectCategories_Categories]
    FOREIGN KEY ([Categories_Id])
    REFERENCES [dbo].[Categories]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Projects_Id] in table 'ProjectCategories'
ALTER TABLE [dbo].[ProjectCategories]
ADD CONSTRAINT [FK_ProjectCategories_Projects]
    FOREIGN KEY ([Projects_Id])
    REFERENCES [dbo].[Projects]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProjectCategories_Projects'
CREATE INDEX [IX_FK_ProjectCategories_Projects]
ON [dbo].[ProjectCategories]
    ([Projects_Id]);
GO

-- Creating foreign key on [Images_Id] in table 'ProjectImages'
ALTER TABLE [dbo].[ProjectImages]
ADD CONSTRAINT [FK_ProjectImages_Images]
    FOREIGN KEY ([Images_Id])
    REFERENCES [dbo].[Images]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Projects_Id] in table 'ProjectImages'
ALTER TABLE [dbo].[ProjectImages]
ADD CONSTRAINT [FK_ProjectImages_Projects]
    FOREIGN KEY ([Projects_Id])
    REFERENCES [dbo].[Projects]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProjectImages_Projects'
CREATE INDEX [IX_FK_ProjectImages_Projects]
ON [dbo].[ProjectImages]
    ([Projects_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------
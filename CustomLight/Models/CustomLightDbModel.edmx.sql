
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/30/2017 15:30:42
-- Generated from EDMX file: D:\Work\VisualStudio\cl\CustomLight\Models\CustomLightDbModel.edmx
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

IF OBJECT_ID(N'[dbo].[FK_CategoryProduct_Category]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CategoryProduct] DROP CONSTRAINT [FK_CategoryProduct_Category];
GO
IF OBJECT_ID(N'[dbo].[FK_CategoryProduct_Product]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CategoryProduct] DROP CONSTRAINT [FK_CategoryProduct_Product];
GO
IF OBJECT_ID(N'[dbo].[FK_CategoryProject_Category]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CategoryProject] DROP CONSTRAINT [FK_CategoryProject_Category];
GO
IF OBJECT_ID(N'[dbo].[FK_CategoryProject_Project]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CategoryProject] DROP CONSTRAINT [FK_CategoryProject_Project];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductProductImage]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductImages] DROP CONSTRAINT [FK_ProductProductImage];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductSpecificationValue]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SpecificationValues] DROP CONSTRAINT [FK_ProductSpecificationValue];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductTypeProduct]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Products] DROP CONSTRAINT [FK_ProductTypeProduct];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductTypeSpecificationTitle]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SpecificationTitles] DROP CONSTRAINT [FK_ProductTypeSpecificationTitle];
GO
IF OBJECT_ID(N'[dbo].[FK_ProjectProjectImage]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProjectImages] DROP CONSTRAINT [FK_ProjectProjectImage];
GO
IF OBJECT_ID(N'[dbo].[FK_SpecificationTitleSpecificationValue]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SpecificationValues] DROP CONSTRAINT [FK_SpecificationTitleSpecificationValue];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Categories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Categories];
GO
IF OBJECT_ID(N'[dbo].[CategoryProduct]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CategoryProduct];
GO
IF OBJECT_ID(N'[dbo].[CategoryProject]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CategoryProject];
GO
IF OBJECT_ID(N'[dbo].[Essentials]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Essentials];
GO
IF OBJECT_ID(N'[dbo].[Orders]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Orders];
GO
IF OBJECT_ID(N'[dbo].[Pages]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pages];
GO
IF OBJECT_ID(N'[dbo].[ProductImages]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductImages];
GO
IF OBJECT_ID(N'[dbo].[Products]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Products];
GO
IF OBJECT_ID(N'[dbo].[ProductTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductTypes];
GO
IF OBJECT_ID(N'[dbo].[ProjectImages]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProjectImages];
GO
IF OBJECT_ID(N'[dbo].[Projects]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Projects];
GO
IF OBJECT_ID(N'[dbo].[Slides]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Slides];
GO
IF OBJECT_ID(N'[dbo].[SpecificationTitles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SpecificationTitles];
GO
IF OBJECT_ID(N'[dbo].[SpecificationValues]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SpecificationValues];
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

-- Creating table 'Essentials'
CREATE TABLE [dbo].[Essentials] (
    [Id] int  NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [LogoImageData] varbinary(max)  NOT NULL,
    [LogoImageMimeType] nvarchar(max)  NOT NULL,
    [About] nvarchar(max)  NOT NULL,
    [Address] nvarchar(max)  NOT NULL,
    [Phone] nvarchar(max)  NOT NULL,
    [Boss] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Orders'
CREATE TABLE [dbo].[Orders] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [OrderString] nvarchar(max)  NOT NULL,
    [Created] datetime  NOT NULL
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

-- Creating table 'ProductImages'
CREATE TABLE [dbo].[ProductImages] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ImageData] varbinary(max)  NOT NULL,
    [ImageMimeType] nvarchar(max)  NOT NULL,
    [ProductId] int  NOT NULL
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
    [Updated] datetime  NOT NULL,
    [ProductTypeId] int  NOT NULL
);
GO

-- Creating table 'ProductTypes'
CREATE TABLE [dbo].[ProductTypes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ProjectImages'
CREATE TABLE [dbo].[ProjectImages] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ImageData] varbinary(max)  NOT NULL,
    [ImageMimeType] nvarchar(max)  NOT NULL,
    [ProjectId] int  NOT NULL
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

-- Creating table 'Slides'
CREATE TABLE [dbo].[Slides] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ImageData] varbinary(max)  NOT NULL,
    [ImageMimeType] nvarchar(max)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'SpecificationTitles'
CREATE TABLE [dbo].[SpecificationTitles] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [ProductTypeId] int  NOT NULL
);
GO

-- Creating table 'SpecificationValues'
CREATE TABLE [dbo].[SpecificationValues] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Value] nvarchar(max)  NOT NULL,
    [ProductId] int  NOT NULL,
    [SpecificationTitleId] int  NOT NULL
);
GO

-- Creating table 'CategoryProduct'
CREATE TABLE [dbo].[CategoryProduct] (
    [Categories_Id] int  NOT NULL,
    [Products_Id] int  NOT NULL
);
GO

-- Creating table 'CategoryProject'
CREATE TABLE [dbo].[CategoryProject] (
    [Categories_Id] int  NOT NULL,
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

-- Creating primary key on [Id] in table 'Essentials'
ALTER TABLE [dbo].[Essentials]
ADD CONSTRAINT [PK_Essentials]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [PK_Orders]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Pages'
ALTER TABLE [dbo].[Pages]
ADD CONSTRAINT [PK_Pages]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProductImages'
ALTER TABLE [dbo].[ProductImages]
ADD CONSTRAINT [PK_ProductImages]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [PK_Products]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProductTypes'
ALTER TABLE [dbo].[ProductTypes]
ADD CONSTRAINT [PK_ProductTypes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProjectImages'
ALTER TABLE [dbo].[ProjectImages]
ADD CONSTRAINT [PK_ProjectImages]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Projects'
ALTER TABLE [dbo].[Projects]
ADD CONSTRAINT [PK_Projects]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Slides'
ALTER TABLE [dbo].[Slides]
ADD CONSTRAINT [PK_Slides]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SpecificationTitles'
ALTER TABLE [dbo].[SpecificationTitles]
ADD CONSTRAINT [PK_SpecificationTitles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SpecificationValues'
ALTER TABLE [dbo].[SpecificationValues]
ADD CONSTRAINT [PK_SpecificationValues]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Categories_Id], [Products_Id] in table 'CategoryProduct'
ALTER TABLE [dbo].[CategoryProduct]
ADD CONSTRAINT [PK_CategoryProduct]
    PRIMARY KEY CLUSTERED ([Categories_Id], [Products_Id] ASC);
GO

-- Creating primary key on [Categories_Id], [Projects_Id] in table 'CategoryProject'
ALTER TABLE [dbo].[CategoryProject]
ADD CONSTRAINT [PK_CategoryProject]
    PRIMARY KEY CLUSTERED ([Categories_Id], [Projects_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ProductId] in table 'ProductImages'
ALTER TABLE [dbo].[ProductImages]
ADD CONSTRAINT [FK_ProductProductImage]
    FOREIGN KEY ([ProductId])
    REFERENCES [dbo].[Products]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductProductImage'
CREATE INDEX [IX_FK_ProductProductImage]
ON [dbo].[ProductImages]
    ([ProductId]);
GO

-- Creating foreign key on [ProductId] in table 'SpecificationValues'
ALTER TABLE [dbo].[SpecificationValues]
ADD CONSTRAINT [FK_ProductSpecificationValue]
    FOREIGN KEY ([ProductId])
    REFERENCES [dbo].[Products]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductSpecificationValue'
CREATE INDEX [IX_FK_ProductSpecificationValue]
ON [dbo].[SpecificationValues]
    ([ProductId]);
GO

-- Creating foreign key on [ProductTypeId] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [FK_ProductTypeProduct]
    FOREIGN KEY ([ProductTypeId])
    REFERENCES [dbo].[ProductTypes]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductTypeProduct'
CREATE INDEX [IX_FK_ProductTypeProduct]
ON [dbo].[Products]
    ([ProductTypeId]);
GO

-- Creating foreign key on [ProductTypeId] in table 'SpecificationTitles'
ALTER TABLE [dbo].[SpecificationTitles]
ADD CONSTRAINT [FK_ProductTypeSpecificationTitle]
    FOREIGN KEY ([ProductTypeId])
    REFERENCES [dbo].[ProductTypes]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductTypeSpecificationTitle'
CREATE INDEX [IX_FK_ProductTypeSpecificationTitle]
ON [dbo].[SpecificationTitles]
    ([ProductTypeId]);
GO

-- Creating foreign key on [ProjectId] in table 'ProjectImages'
ALTER TABLE [dbo].[ProjectImages]
ADD CONSTRAINT [FK_ProjectProjectImage]
    FOREIGN KEY ([ProjectId])
    REFERENCES [dbo].[Projects]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProjectProjectImage'
CREATE INDEX [IX_FK_ProjectProjectImage]
ON [dbo].[ProjectImages]
    ([ProjectId]);
GO

-- Creating foreign key on [SpecificationTitleId] in table 'SpecificationValues'
ALTER TABLE [dbo].[SpecificationValues]
ADD CONSTRAINT [FK_SpecificationTitleSpecificationValue]
    FOREIGN KEY ([SpecificationTitleId])
    REFERENCES [dbo].[SpecificationTitles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SpecificationTitleSpecificationValue'
CREATE INDEX [IX_FK_SpecificationTitleSpecificationValue]
ON [dbo].[SpecificationValues]
    ([SpecificationTitleId]);
GO

-- Creating foreign key on [Categories_Id] in table 'CategoryProduct'
ALTER TABLE [dbo].[CategoryProduct]
ADD CONSTRAINT [FK_CategoryProduct_Category]
    FOREIGN KEY ([Categories_Id])
    REFERENCES [dbo].[Categories]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Products_Id] in table 'CategoryProduct'
ALTER TABLE [dbo].[CategoryProduct]
ADD CONSTRAINT [FK_CategoryProduct_Product]
    FOREIGN KEY ([Products_Id])
    REFERENCES [dbo].[Products]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CategoryProduct_Product'
CREATE INDEX [IX_FK_CategoryProduct_Product]
ON [dbo].[CategoryProduct]
    ([Products_Id]);
GO

-- Creating foreign key on [Categories_Id] in table 'CategoryProject'
ALTER TABLE [dbo].[CategoryProject]
ADD CONSTRAINT [FK_CategoryProject_Category]
    FOREIGN KEY ([Categories_Id])
    REFERENCES [dbo].[Categories]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Projects_Id] in table 'CategoryProject'
ALTER TABLE [dbo].[CategoryProject]
ADD CONSTRAINT [FK_CategoryProject_Project]
    FOREIGN KEY ([Projects_Id])
    REFERENCES [dbo].[Projects]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CategoryProject_Project'
CREATE INDEX [IX_FK_CategoryProject_Project]
ON [dbo].[CategoryProject]
    ([Projects_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------

-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/12/2023 16:04:56
-- Generated from EDMX file: C:\Users\alexc\OneDrive\Рабочий стол\материалы\workplan\WorkPlan\Base\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [workplan];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Applications_Departments]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Applications] DROP CONSTRAINT [FK_Applications_Departments];
GO
IF OBJECT_ID(N'[dbo].[FK_Applications_Goods]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Applications] DROP CONSTRAINT [FK_Applications_Goods];
GO
IF OBJECT_ID(N'[dbo].[FK_Applications_Status]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Applications] DROP CONSTRAINT [FK_Applications_Status];
GO
IF OBJECT_ID(N'[dbo].[FK_Applications_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Applications] DROP CONSTRAINT [FK_Applications_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_Employee_Departments]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employee] DROP CONSTRAINT [FK_Employee_Departments];
GO
IF OBJECT_ID(N'[dbo].[FK_Employee_Specializations]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employee] DROP CONSTRAINT [FK_Employee_Specializations];
GO
IF OBJECT_ID(N'[dbo].[FK_FinalPlan_Applications]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FinalPlan] DROP CONSTRAINT [FK_FinalPlan_Applications];
GO
IF OBJECT_ID(N'[dbo].[FK_Structure_Employee]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Structure] DROP CONSTRAINT [FK_Structure_Employee];
GO
IF OBJECT_ID(N'[dbo].[FK_Users_Employee]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users] DROP CONSTRAINT [FK_Users_Employee];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Applications]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Applications];
GO
IF OBJECT_ID(N'[dbo].[Departments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Departments];
GO
IF OBJECT_ID(N'[dbo].[Employee]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employee];
GO
IF OBJECT_ID(N'[dbo].[FinalPlan]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FinalPlan];
GO
IF OBJECT_ID(N'[dbo].[Goods]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Goods];
GO
IF OBJECT_ID(N'[dbo].[Specializations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Specializations];
GO
IF OBJECT_ID(N'[dbo].[Status]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Status];
GO
IF OBJECT_ID(N'[dbo].[Structure]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Structure];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Applications'
CREATE TABLE [dbo].[Applications] (
    [ID_application] int IDENTITY(1,1) NOT NULL,
    [ID_goods] int  NULL,
    [Количество] int  NULL,
    [ID_status] int  NULL,
    [ID_department] int  NULL,
    [ID_creator] int  NULL,
    [created_at] datetime  NULL,
    [year] int  NULL,
    [year1price] decimal(19,4)  NULL,
    [year2price] decimal(19,4)  NULL,
    [year3price] decimal(19,4)  NULL,
    [yearAprice] decimal(19,4)  NULL
);
GO

-- Creating table 'Departments'
CREATE TABLE [dbo].[Departments] (
    [ID_department] int IDENTITY(1,1) NOT NULL,
    [Название] nvarchar(50)  NULL,
    [Кол_во_сотрудников] nvarchar(50)  NULL
);
GO

-- Creating table 'Employee'
CREATE TABLE [dbo].[Employee] (
    [ID_employee] int IDENTITY(1,1) NOT NULL,
    [ФИО] nvarchar(50)  NULL,
    [ID_specialization] int  NULL,
    [ID_department] int  NULL
);
GO

-- Creating table 'FinalPlan'
CREATE TABLE [dbo].[FinalPlan] (
    [ID_finalplan] int IDENTITY(1,1) NOT NULL,
    [ID_application] int  NOT NULL
);
GO

-- Creating table 'Goods'
CREATE TABLE [dbo].[Goods] (
    [ID_goods] int IDENTITY(1,1) NOT NULL,
    [Название] nvarchar(50)  NULL,
    [Цена] decimal(19,4)  NULL,
    [code] nvarchar(50)  NULL
);
GO

-- Creating table 'Specializations'
CREATE TABLE [dbo].[Specializations] (
    [id_specialization] int IDENTITY(1,1) NOT NULL,
    [Name_specialization] nvarchar(50)  NULL
);
GO

-- Creating table 'Status'
CREATE TABLE [dbo].[Status] (
    [ID_status] int IDENTITY(1,1) NOT NULL,
    [Статус] nvarchar(50)  NULL
);
GO

-- Creating table 'Structure'
CREATE TABLE [dbo].[Structure] (
    [ID_structure] int IDENTITY(1,1) NOT NULL,
    [id_Emp] int  NOT NULL,
    [roleo] nvarchar(50)  NOT NULL
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

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [ID_user] int IDENTITY(1,1) NOT NULL,
    [Логин] nvarchar(50)  NULL,
    [Пароль] nvarchar(50)  NULL,
    [ID_employee] int  NULL,
    [Права] nvarchar(50)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID_application] in table 'Applications'
ALTER TABLE [dbo].[Applications]
ADD CONSTRAINT [PK_Applications]
    PRIMARY KEY CLUSTERED ([ID_application] ASC);
GO

-- Creating primary key on [ID_department] in table 'Departments'
ALTER TABLE [dbo].[Departments]
ADD CONSTRAINT [PK_Departments]
    PRIMARY KEY CLUSTERED ([ID_department] ASC);
GO

-- Creating primary key on [ID_employee] in table 'Employee'
ALTER TABLE [dbo].[Employee]
ADD CONSTRAINT [PK_Employee]
    PRIMARY KEY CLUSTERED ([ID_employee] ASC);
GO

-- Creating primary key on [ID_finalplan] in table 'FinalPlan'
ALTER TABLE [dbo].[FinalPlan]
ADD CONSTRAINT [PK_FinalPlan]
    PRIMARY KEY CLUSTERED ([ID_finalplan] ASC);
GO

-- Creating primary key on [ID_goods] in table 'Goods'
ALTER TABLE [dbo].[Goods]
ADD CONSTRAINT [PK_Goods]
    PRIMARY KEY CLUSTERED ([ID_goods] ASC);
GO

-- Creating primary key on [id_specialization] in table 'Specializations'
ALTER TABLE [dbo].[Specializations]
ADD CONSTRAINT [PK_Specializations]
    PRIMARY KEY CLUSTERED ([id_specialization] ASC);
GO

-- Creating primary key on [ID_status] in table 'Status'
ALTER TABLE [dbo].[Status]
ADD CONSTRAINT [PK_Status]
    PRIMARY KEY CLUSTERED ([ID_status] ASC);
GO

-- Creating primary key on [ID_structure] in table 'Structure'
ALTER TABLE [dbo].[Structure]
ADD CONSTRAINT [PK_Structure]
    PRIMARY KEY CLUSTERED ([ID_structure] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [ID_user] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([ID_user] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ID_department] in table 'Applications'
ALTER TABLE [dbo].[Applications]
ADD CONSTRAINT [FK_Applications_Departments]
    FOREIGN KEY ([ID_department])
    REFERENCES [dbo].[Departments]
        ([ID_department])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Applications_Departments'
CREATE INDEX [IX_FK_Applications_Departments]
ON [dbo].[Applications]
    ([ID_department]);
GO

-- Creating foreign key on [ID_goods] in table 'Applications'
ALTER TABLE [dbo].[Applications]
ADD CONSTRAINT [FK_Applications_Goods]
    FOREIGN KEY ([ID_goods])
    REFERENCES [dbo].[Goods]
        ([ID_goods])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Applications_Goods'
CREATE INDEX [IX_FK_Applications_Goods]
ON [dbo].[Applications]
    ([ID_goods]);
GO

-- Creating foreign key on [ID_status] in table 'Applications'
ALTER TABLE [dbo].[Applications]
ADD CONSTRAINT [FK_Applications_Status]
    FOREIGN KEY ([ID_status])
    REFERENCES [dbo].[Status]
        ([ID_status])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Applications_Status'
CREATE INDEX [IX_FK_Applications_Status]
ON [dbo].[Applications]
    ([ID_status]);
GO

-- Creating foreign key on [ID_creator] in table 'Applications'
ALTER TABLE [dbo].[Applications]
ADD CONSTRAINT [FK_Applications_Users]
    FOREIGN KEY ([ID_creator])
    REFERENCES [dbo].[Users]
        ([ID_user])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Applications_Users'
CREATE INDEX [IX_FK_Applications_Users]
ON [dbo].[Applications]
    ([ID_creator]);
GO

-- Creating foreign key on [ID_application] in table 'FinalPlan'
ALTER TABLE [dbo].[FinalPlan]
ADD CONSTRAINT [FK_FinalPlan_Applications]
    FOREIGN KEY ([ID_application])
    REFERENCES [dbo].[Applications]
        ([ID_application])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FinalPlan_Applications'
CREATE INDEX [IX_FK_FinalPlan_Applications]
ON [dbo].[FinalPlan]
    ([ID_application]);
GO

-- Creating foreign key on [ID_department] in table 'Employee'
ALTER TABLE [dbo].[Employee]
ADD CONSTRAINT [FK_Employee_Departments]
    FOREIGN KEY ([ID_department])
    REFERENCES [dbo].[Departments]
        ([ID_department])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Employee_Departments'
CREATE INDEX [IX_FK_Employee_Departments]
ON [dbo].[Employee]
    ([ID_department]);
GO

-- Creating foreign key on [ID_specialization] in table 'Employee'
ALTER TABLE [dbo].[Employee]
ADD CONSTRAINT [FK_Employee_Specializations]
    FOREIGN KEY ([ID_specialization])
    REFERENCES [dbo].[Specializations]
        ([id_specialization])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Employee_Specializations'
CREATE INDEX [IX_FK_Employee_Specializations]
ON [dbo].[Employee]
    ([ID_specialization]);
GO

-- Creating foreign key on [id_Emp] in table 'Structure'
ALTER TABLE [dbo].[Structure]
ADD CONSTRAINT [FK_Structure_Employee]
    FOREIGN KEY ([id_Emp])
    REFERENCES [dbo].[Employee]
        ([ID_employee])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Structure_Employee'
CREATE INDEX [IX_FK_Structure_Employee]
ON [dbo].[Structure]
    ([id_Emp]);
GO

-- Creating foreign key on [ID_employee] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [FK_Users_Employee]
    FOREIGN KEY ([ID_employee])
    REFERENCES [dbo].[Employee]
        ([ID_employee])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Users_Employee'
CREATE INDEX [IX_FK_Users_Employee]
ON [dbo].[Users]
    ([ID_employee]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------
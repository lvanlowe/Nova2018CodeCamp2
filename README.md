# Nova2018CodeCamp2
Add To GitHub
SQL to Create Databases
    
    CREATE TABLE [pwso].[Sport] (
    [id]          INT          IDENTITY (1, 1) NOT NULL,
    [Name]        VARCHAR (25) NOT NULL,
    [CanRegister] BIT          DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
    );

    CREATE TABLE [pwso].[Location] (
    [id]      INT          IDENTITY (1, 1) NOT NULL,
    [Name]    VARCHAR (25) NULL,
    [Year]    INT          NOT NULL,
    [SportId] INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_Location_Sport] FOREIGN KEY ([SportId]) REFERENCES [pwso].[Sport] ([id])
    );
    
    CREATE TABLE [dbo].[Coach] (
    [Id]         INT          NOT NULL,
    [FirstName]  VARCHAR (50) NOT NULL,
    [LastName]   VARCHAR (50) NOT NULL,
    [LocationId] INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Coach_Location] FOREIGN KEY ([LocationId]) REFERENCES [pwso].[Location] ([id])
    );
    
To Reverse engineer your model
Run the following command to create a model from the existing database:
Scaffold-DbContext "Server=(local);Database=Nova2018CodeCamp;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir DatabaseModels
    
Note: Scaffold-DbContext does not work with .Net Standard 2.0 at this time.    

# ProductManagement


# Project Technology used
1) .Net framework 4.5.2
2) Asp.net MVC 5
3) Sql Server 2012 express edition
4) Dapper.1.50.5
5) Unity.5.8.6
6) Swashbuckle.5.6.0 for documentation
7) Moq.4.8.3 for Unit testing
8) Visual Studio 2015 for development


# Project Setup Steps
1) Setting Connection String
Need to change connection string in below path

ContactMangement/Applications/CM.WebApi/Web.config 
 <connectionStrings>
    <add connectionString="<your connection string to database"" name="CMconnection" />
 </connectionStrings>


2) Setting Database

Also run the following query to create database table

/****** Object:  Table [dbo].[cm_contact]  ******/

SET ANSI_NULLS ON

GO

SET QUOTED_IDENTIFIER ON

GO

CREATE TABLE [dbo].[cm_product]( [Id] [int] IDENTITY(1,1) NOT NULL, [Name] nvarchar NOT NULL, [description] nvarchar(max) NOT NULL, [price] DECIMAL(10,2) NOT NULL, [Status] nchar NOT NULL, CONSTRAINT [PK_cm_contact] PRIMARY KEY CLUSTERED ( [Id] ASC )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] ) ON [PRIMARY]

GO



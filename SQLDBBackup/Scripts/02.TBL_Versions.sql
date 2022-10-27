USE [EquityPositionsDB]
GO

/****** Object:  Table [dbo].[Versions]    Script Date: 10/27/2022 7:44:39 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Versions]') AND type in (N'U'))
DROP TABLE [dbo].[Versions]
GO

/****** Object:  Table [dbo].[Versions]    Script Date: 10/27/2022 7:44:39 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Versions](
	[VersionID] [int] IDENTITY(1,1) NOT NULL,
	[Version] [nvarchar](10) NOT NULL
) ON [PRIMARY]
GO



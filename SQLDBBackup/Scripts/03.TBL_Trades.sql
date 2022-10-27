USE [EquityPositionsDB]
GO

ALTER TABLE [dbo].[Trades] DROP CONSTRAINT [DF_Trades_CreatedAt]
GO

/****** Object:  Table [dbo].[Trades]    Script Date: 10/27/2022 7:44:19 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Trades]') AND type in (N'U'))
DROP TABLE [dbo].[Trades]
GO

/****** Object:  Table [dbo].[Trades]    Script Date: 10/27/2022 7:44:19 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Trades](
	[TradeID] [int] IDENTITY(1,1) NOT NULL,
	[SecurityCode] [nvarchar](10) NOT NULL,
	[Side] [nvarchar](10) NOT NULL,
	[CreatedAt] [datetime] NOT NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Trades] ADD  CONSTRAINT [DF_Trades_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO



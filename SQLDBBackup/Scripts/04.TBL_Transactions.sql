USE [EquityPositionsDB]
GO

ALTER TABLE [dbo].[Transactions] DROP CONSTRAINT [DF_Transactions_ModifiedAt]
GO

/****** Object:  Table [dbo].[Transactions]    Script Date: 10/27/2022 7:44:29 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Transactions]') AND type in (N'U'))
DROP TABLE [dbo].[Transactions]
GO

/****** Object:  Table [dbo].[Transactions]    Script Date: 10/27/2022 7:44:29 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Transactions](
	[TransactionID] [int] IDENTITY(1,1) NOT NULL,
	[TradeID] [int] NOT NULL,
	[Version] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Operation] [nvarchar](10) NOT NULL,
	[Side] [nvarchar](10) NOT NULL,
	[ModifiedAt] [datetime] NOT NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Transactions] ADD  CONSTRAINT [DF_Transactions_ModifiedAt]  DEFAULT (getdate()) FOR [ModifiedAt]
GO



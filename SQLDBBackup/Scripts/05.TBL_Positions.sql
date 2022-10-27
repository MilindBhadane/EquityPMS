USE [EquityPositionsDB]
GO

/****** Object:  Table [dbo].[Positions]    Script Date: 10/27/2022 7:44:09 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Positions]') AND type in (N'U'))
DROP TABLE [dbo].[Positions]
GO

/****** Object:  Table [dbo].[Positions]    Script Date: 10/27/2022 7:44:09 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Positions](
	[PositionID] [int] IDENTITY(1,1) NOT NULL,
	[TradeID] [int] NOT NULL,
	[Quantity] [int] NOT NULL
) ON [PRIMARY]
GO



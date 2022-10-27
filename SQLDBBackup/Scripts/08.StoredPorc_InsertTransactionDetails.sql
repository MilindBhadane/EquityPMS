USE [EquityPositionsDB]
GO

/****** Object:  StoredProcedure [dbo].[InsertTransactionDetails]    Script Date: 10/27/2022 7:45:18 PM ******/
DROP PROCEDURE [dbo].[InsertTransactionDetails]
GO

/****** Object:  StoredProcedure [dbo].[InsertTransactionDetails]    Script Date: 10/27/2022 7:45:18 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[InsertTransactionDetails]
	 @Quantity int,
	 @SecurityCode nvarchar(10),
	 @Operation nvarchar(10),
	 @Side nvarchar(10)
AS
BEGIN

	SET NOCOUNT ON;

	DECLARE @tradeID int = 0;
	DECLARE @versionID int = 0;

	--INSERT TradeID if it doesnt exists.

	IF NOT EXISTS (SELECT TradeID FROM Trades WHERE SecurityCode = @SecurityCode AND Side = @Side)
	BEGIN
		IF (@Operation = 'CANCEL')
		BEGIN
			IF EXISTS (SELECT TradeID FROM Trades WHERE SecurityCode = @SecurityCode)
			BEGIN
				SELECT @tradeID = TradeID FROM Trades WHERE SecurityCode = @SecurityCode
			END
		END
		ELSE
		BEGIN
			INSERT INTO Trades (SecurityCode, Side)
			VALUES (@SecurityCode, @Side);
			SELECT @tradeID = @@IDENTITY;
		END
	END
	ELSE
	BEGIN
		IF (@Operation = 'CANCEL')
		BEGIN
			IF EXISTS (SELECT TradeID FROM Trades WHERE SecurityCode = @SecurityCode)
			BEGIN
				SELECT @tradeID = TradeID FROM Trades WHERE SecurityCode = @SecurityCode
			END
		END
		ELSE
		BEGIN
			SELECT @tradeID = TradeID FROM Trades WHERE SecurityCode = @SecurityCode AND Side = @Side
		END
	END

	-- Get Version ID
	IF EXISTS (SELECT VersionID FROM Versions WHERE [Version] = @Operation)
	BEGIN 
		SELECT @versionID = VersionID FROM Versions WHERE [Version] = @Operation
	END

    -- Insert Transactions Data in Transaction table
	INSERT INTO Transactions(TradeID, [Version], Quantity, Operation, Side)
	VALUES (@tradeID, @versionID, @Quantity, @Operation, @Side)

	IF EXISTS (SELECT TradeID FROM Positions WHERE TradeID = @tradeID)
	BEGIN 

		UPDATE Positions
		SET Quantity =  CASE @Operation
							 WHEN  'CANCEL'  THEN 0
							 WHEN  'UPDATE'  THEN @Quantity
							 ELSE   CASE @Side
										 WHEN  'BUY'  THEN  Quantity + @Quantity 
										 WHEN  'SELL' THEN  Quantity - @Quantity  
									END
						END
		WHERE TradeID = @tradeID;

	END
	ELSE
	BEGIN
		Declare @posQty int 
		SELECT @posQty= Case @Side	WHEN  'BUY'  THEN  @Quantity  
									WHEN  'SELL' THEN  @Quantity * -1 END;

		IF (@Operation = 'CANCEL') 
		BEGIN 
			SET @posQty = 0;
		END

		INSERT INTO Positions (TradeID, Quantity)
		VALUES (@tradeID, @posQty);
	END


END
GO



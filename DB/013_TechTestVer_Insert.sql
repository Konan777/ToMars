SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON

DECLARE @malahitVersion int;
/* Указать версию БД для которой должен выполняться скрипт*/
SET @malahitVersion = 12;

BEGIN TRANSACTION;
BEGIN TRY

	/* Проверка текущей версии базы данных */
	IF NOT EXISTS (SELECT * FROM [dbo].[SysDatabaseVersion] WHERE [MalahitVersion]=@malahitVersion)
	BEGIN
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;
		PRINT ('Данный скрипт не соответствует текущей версии базы данных');
		RETURN;
	END

	/* Скрипты изменения БД - начало */
	--------------------------------------------------------------------------------------------------------


EXEC dbo.sp_executesql @statement = N'


ALTER PROCEDURE [dbo].[TechTestVer_Insert]
	@TechTestVerId int output
   ,@TechTestUid uniqueidentifier
   ,@ReplicatesPrimary int
   ,@ReplicatesSecondary int
   ,@ReplicatesMax int
   ,@Order int
   ,@GroupCalc bit
   ,@Name nvarchar(150)
   ,@TechUid UNIQUEIDENTIFIER
   ,@TechVerId INT
   ,@MeasureGroup NVARCHAR(50)
   ,@AEUid uniqueidentifier
   ,@DimsItem int
   ,@AETestUid uniqueidentifier

AS
BEGIN
	DECLARE @date_e datetime
	SET @date_e = GETDATE()
	--Создание версии для объекта
	--Своей версии у показателя нет.

	--DECLARE @StartDate DATETIME, @StopDate DATETIME;
	--IF (@TechVerId <0)
	--BEGIN
	--	SELECT TOP (1) @StartDate = [Version].[StartDate], 
	--		   @StopDate = [Version].[StopDate]	
	--	FROM [TechVer] INNER JOIN [Version] ON [TechVer].[TechVerId] = [Version].[VersionId]
	--	WHERE [TechVer].[TechUid] = @TechUid
	--	AND [Version].[StartDate]<=@date_e AND [Version].[StopDate] >= @date_e
	--END
	--ELSE
	--BEGIN
	--	SELECT  @StartDate = [Version].[StartDate], 
	--		   @StopDate = [Version].[StopDate]	
	--	FROM [TechVer] INNER JOIN [Version] ON [TechVer].[TechVerId] = [Version].[VersionId]
	--	WHERE [TechVer].[TechVerId] = @TechVerId
	
	--END
	
	--	INSERT INTO [dbo].[Version]
	--		   ([StartDate], [StopDate], [CreationDate], [ChangeDate], [ObjectUid])
	--	 VALUES
	--		   (@StartDate, @StopDate, @date_e, @date_e, @TechTestUid);

	--	SET @TechTestVerId = @@IDENTITY;

	INSERT INTO [dbo].[TechTestVer]
			   (--[TechTestVerId]
			   [TechTestUid]
			   ,[ReplicatesPrimary]
			   ,[ReplicatesSecondary]
			   ,[ReplicatesMax]
			   ,[Order]
			   ,[GroupCalc]
			   ,[Name]
			   ,[TechVerId]
			   ,[MeasureGroup]
			   ,[AEUid] 
			   ,[DimsItem] 
			   ,[AETestUid])
		 VALUES
			   (--@TechTestVerId
			   @TechTestUid
			   ,@ReplicatesPrimary
			   ,@ReplicatesSecondary
			   ,@ReplicatesMax
			   ,@Order
			   ,@GroupCalc
			   ,@Name
			   ,@TechVerId
			   ,@MeasureGroup
			   ,@AEUid
			   ,@DimsItem
               ,@AETestUid)
	
	SET @TechTestVerId = @@IDENTITY;
END
'


EXEC dbo.sp_executesql @statement = N'


ALTER PROCEDURE [dbo].[TechTestVer_Update]
	@TechTestVerId int
   ,@TechTestUid uniqueidentifier
   ,@ReplicatesPrimary int
   ,@ReplicatesSecondary int
   ,@ReplicatesMax int
   ,@Order int
   ,@GroupCalc bit
   ,@Name nvarchar(150)
   ,@TechUid UNIQUEIDENTIFIER
   ,@TechVerId INT
   ,@MeasureGroup NVARCHAR(50)
   ,@AEUid uniqueidentifier
   ,@DimsItem int
   ,@AETestUid uniqueidentifier
AS
BEGIN

	UPDATE [dbo].[TechTestVer]
	   SET [ReplicatesPrimary] = @ReplicatesPrimary
		  ,[ReplicatesSecondary] = @ReplicatesSecondary
		  ,[ReplicatesMax] = @ReplicatesMax
		  ,[Order] = @Order
		  ,[GroupCalc] = @GroupCalc
		  ,[Name] = @Name
		  ,[MeasureGroup] = @MeasureGroup
		  ,[AEUid] = @AEUid
		  ,[DimsItem] = @DimsItem
		  ,[AETestUid] = @AETestUid
	 WHERE [TechTestVerId] = @TechTestVerId
	   AND [TechTestUid] = @TechTestUid
	   
	DECLARE @date_e datetime
	SET @date_e = GETDATE()
	--Создание версии для объекта
	
	--DECLARE @StartDate DATETIME, @StopDate DATETIME;
	
	--IF (@TechVerId <0)
	--BEGIN
	--	SELECT TOP (1) @StartDate = [Version].[StartDate], 
	--		   @StopDate = [Version].[StopDate]	
	--	FROM [TechVer] INNER JOIN [Version] ON [TechVer].[TechVerId] = [Version].[VersionId]
	--	WHERE [TechVer].[TechUid] = @TechUid
	--	AND [Version].[StartDate]<=@date_e AND [Version].[StopDate] >= @date_e
	--END
	--ELSE
	--BEGIN
	--	SELECT  @StartDate = [Version].[StartDate], 
	--		   @StopDate = [Version].[StopDate]	
	--	FROM [TechVer] INNER JOIN [Version] ON [TechVer].[TechVerId] = [Version].[VersionId]
	--	WHERE [TechVer].[TechVerId] = @TechVerId
	
	--END
	   
	--   UPDATE [dbo].[Version]
	--	   SET [ChangeDate] = GETDATE(), [StartDate] = @StartDate, [StopDate] = @StopDate
	--	WHERE VersionId = @TechTestVerId
END

'

EXEC dbo.sp_executesql @statement = N'


ALTER FUNCTION [dbo].[TechTestVer_Get]
(
	@TechUid UNIQUEIDENTIFIER,
	@TimeStamp DATETIME = NULL
)
RETURNS TABLE
AS
	RETURN
		SELECT 
		[TTV].[TechTestVerId],
		[TT].[TechTestUid],
		[TS].[TestId],
		[TS].[TestType],
		[TT].[TechUid],
		[TTV].[ReplicatesPrimary],
		[TTV].[ReplicatesSecondary],
		[TTV].[ReplicatesMax],
		[TTV].[Order],
		[TTV].[GroupCalc],
		[TTV].[Name],
		[TTV].[TechVerId],
		[V].[StartDate],
		[V].[StopDate],
		[TTA].[EngUnitId],
		[EU].[LAbbreviation] AS [EngUnitLAbbr],
		[TTA].[Digits],
		[TTD].[DigitalSetId],
		[TTF].[FileTypeUid],
		[TTG].[CalcType],
		[TTG].[IsCritical],
		[TTG].[IsReplicatesRelative],
		[TTV].[MeasureGroup],
		[TTV].[AEUid],
		[TTV].[DimsItem],
		[TTV].[AETestUid]

		FROM [TechTest] AS [TT]
		INNER JOIN [Test] AS [TS] ON [TT].[TestId] = [TS].[TestId]
		INNER JOIN [TechTestVer] AS [TTV] ON [TT].[TechTestUid] = [TTV].[TechTestUid]
		INNER JOIN [Version] AS [V] ON [TTV].[TechVerId] = [V].[VersionId] AND
		((@TimeStamp IS NULL) OR ( (@TimeStamp IS NOT NULL ) AND  
		(@TimeStamp BETWEEN [V].[StartDate] AND [V].[StopDate])))
		LEFT JOIN [TechTestAnalog] AS [TTA] ON [TTV].[TechTestVerId] = [TTA].[TechTestVerId]
		LEFT JOIN [EngUnit] AS [EU] ON [TTA].[EngUnitId] = [EU].[EngUnitId]
		LEFT JOIN [TechTestDigit] AS [TTD] ON [TTV].[TechTestVerId] = [TTD].[TechTestVerId]
		LEFT JOIN [TechTestFile] AS [TTF] ON [TTV].[TechTestVerId] = [TTF].[TechTestVerId]
		LEFT JOIN [TechTestGroup] AS [TTG] ON [TTV].[TechTestVerId] = [TTG].[TechTestVerId]
		
	WHERE [TT].[TechUid] = @TechUid;
'

	--------------------------------------------------------------------------------------------------------
	/* Скрипты изменения БД - конец */

	/* Указываем версию новой базы данных */
	UPDATE [dbo].[SysDatabaseVersion]
		SET [MalahitVersion] = (@malahitVersion + 1)
	WHERE [MalahitVersion]=@malahitVersion;

END TRY
BEGIN CATCH
    SELECT 
        ERROR_NUMBER() AS ErrorNumber,
        ERROR_SEVERITY() AS ErrorSeverity,
        ERROR_STATE() as ErrorState,
        ERROR_PROCEDURE() as ErrorProcedure,
        ERROR_LINE() as ErrorLine,
        ERROR_MESSAGE() as ErrorMessage;

    IF @@TRANCOUNT > 0
        ROLLBACK TRANSACTION;
END CATCH;

IF @@TRANCOUNT > 0
    COMMIT TRANSACTION;

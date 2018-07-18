CREATE PROCEDURE [dbo].[ClbGraphSeriesTest_Update]
	-- Системные параметры
	@RaiseError bit = 1,
			
	-- Данные
	@ClbrGraphSeriesTestUid uniqueidentifier,
	@ClbrGraphSeriesUid uniqueidentifier,
	@TechTestUid uniqueidentifier,
	@Value float,
	@Flags float
	
AS
BEGIN	
	SET NOCOUNT ON;

	BEGIN TRY		

		Declare @oldClbrGraphSeriesTestUid uniqueidentifier,
		Declare @oldClbrGraphSeriesUid uniqueidentifier,
		Declare @oldTechTestUid uniqueidentifier,
		Declare @oldValue float,
		Declare @oldFlags float

	
		SELECT 			
			@oldClbrGraphSeriesTestUid = [ClbrGraphSeriesTestUid],
			@oldClbrGraphSeriesUid = [ClbrGraphSeriesUid],
			@oldTechTestUid = [TechTestUid],
			@oldValue = [Value],
			@oldFlags = [Flags]
		FROM [ClbGraphSeriesTest]
		WHERE [ClbrGraphSeriesTestUid] = @ClbrGraphSeriesTestUid
	

		-- Изменение данных в [ClbGraphSeriesTest]
		UPDATE [ClbGraphSeriesTest]
		SET 
			[ClbrGraphSeriesTestUid] = @oldClbrGraphSeriesTestUid,
			[ClbrGraphSeriesUid] = @oldClbrGraphSeriesUid,
			[TechTestUid] = @oldTechTestUid,
			[Value] = @oldValue,
			[Flags] = @oldFlags 
		WHERE [ClbrGraphSeriesTestUid] = @ClbrGraphSeriesTestUid;

		-- Проверка числа обработанных записей
		EXEC [dbo].[sp_RowCountCheck] N'ClbGraphSeriesTest', @@ROWCOUNT, @RaiseError;

		-- Запись события в лог
		EXEC [dbo].[ClbrGraph_Log]
			N'U',
			@OldGraphSeriesTestUid,
			@OldClbrGraphSeriesUid,
			@OldTechTestUid,
			@OldValue,
			@OldFlags,
			@ClbrGraphSeriesTestUid,
			@ClbrGraphSeriesUid,
			@TechTestUid,
			@Value,
			@Flags;

	END TRY
	BEGIN CATCH
		-- Ошибка
		EXEC [dbo].[sp_UpdateRowError] N'ClbGraphSeriesTest', @RaiseError;
	END CATCH;
END;

CREATE PROCEDURE [dbo].[ClbGraphSeriesTest_Delete]
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

		-- Удаление данных из [ClbGraphSeriesTest]
		DELETE FROM [ClbGraphSeriesTest]
		WHERE ([ClbrGraphSeriesTestUid] = @ClbrGraphSeriesTestUid)

		-- Проверка числа обработанных записей
		EXEC [dbo].[sp_RowCountCheck] N'ClbGraphSeriesTest', @@ROWCOUNT, @RaiseError;

		-- Запись события в лог
		EXEC [dbo].[ClbGraphSeriesTest_Log]
			N'D',
			@ClbrGraphSeriesTestUid,
			@ClbrGraphSeriesUid,
			@TechTestUid,
			@Value,
			@Flags,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL;
							
	END TRY
	BEGIN CATCH
		-- Ошибка
		EXEC [dbo].[sp_DeleteRowError] N'ClbGraphSeriesTest', @RaiseError;
	END CATCH;
END;

GO



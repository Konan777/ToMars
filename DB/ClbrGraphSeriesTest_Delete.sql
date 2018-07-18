CREATE PROCEDURE [dbo].[ClbrGraphSeriesTest_Delete]
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

		-- Удаление данных из [ClbrGraphSeriesTest]
		DELETE FROM [ClbrGraphSeriesTest]
		WHERE ([ClbrGraphSeriesTestUid] = @ClbrGraphSeriesTestUid)

		-- Проверка числа обработанных записей
		EXEC [dbo].[sp_RowCountCheck] N'ClbrGraphSeriesTest', @@ROWCOUNT, @RaiseError;

		-- Запись события в лог
		EXEC [dbo].[ClbrGraphSeriesTest_Log]
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
		EXEC [dbo].[sp_DeleteRowError] N'ClbrGraphSeriesTest', @RaiseError;
	END CATCH;
END;

GO



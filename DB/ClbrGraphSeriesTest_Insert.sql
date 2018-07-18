CREATE PROCEDURE [dbo].[ClbrGraphSeriesTest_Insert]
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

		-- Вставка данных в [ClbrGraphSeriesTest]
		INSERT INTO [ClbrGraphSeriesTest] (
			[ClbrGraphSeriesTestUid],
			[ClbrGraphSeriesUid],
			[TechTestUid],
			[Value],
			[Flags]
		) VALUES (
			@ClbrGraphSeriesTestUid,
			@ClbrGraphSeriesUid,
			@TechTestUid,
			@Value,
			@Flags
		);

		-- Проверка числа обработанных записей
		EXEC [dbo].[sp_RowCountCheck] N'ClbrGraphSeriesTest', @@ROWCOUNT, @RaiseError;

		-- Запись события в лог
		EXEC [dbo].[ClbrGraphSeriesTest_Log]
			N'I',
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			@ClbrGraphSeriesTestUid,
			@ClbrGraphSeriesUid,
			@TechTestUid,
			@Value,
			@Flags;

	END TRY
	BEGIN CATCH
		-- Ошибка
		EXEC [dbo].[sp_InsertRowError] N'ClbrGraphSeriesTest', @RaiseError;
	END CATCH;
END;

GO



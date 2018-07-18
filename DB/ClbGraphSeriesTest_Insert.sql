CREATE PROCEDURE [dbo].[ClbGraphSeriesTest_Insert]
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

		-- Вставка данных в [ClbrGraphEqp]
		INSERT INTO [ClbGraphSeriesTest] (
			[ClbrGraphEqpUid],
			[ClbrGraphUid],
			[EqpUid]
		) VALUES (
			@ClbrGraphEqpUid,
			@ClbrGraphUid,
			@EqpUid);

		-- Проверка числа обработанных записей
		EXEC [dbo].[sp_RowCountCheck] N'ClbGraphSeriesTest', @@ROWCOUNT, @RaiseError;

		-- Запись события в лог
		EXEC [dbo].[ClbGraphSeriesTest_Log]
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
		EXEC [dbo].[sp_InsertRowError] N'ClbGraphSeriesTest', @RaiseError;
	END CATCH;
END;

GO



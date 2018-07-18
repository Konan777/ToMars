CREATE PROCEDURE [dbo].[ClbrGraphSeries_Delete]
	-- Системные параметры
	@RaiseError bit = 1,
	
	-- Данные
	@ClbrGraphSeriesUid uniqueidentifier,
	@ClbrGraphUid uniqueidentifier,
	@ClbrGraphWSUid uniqueidentifier,
	@Name nvarchar(150),
	@SeriesType int
AS
BEGIN	
	SET NOCOUNT ON;

	BEGIN TRY

		-- Удаление данных из [ClbrGraphSeries]
		DELETE FROM [ClbrGraphSeries]
		WHERE ([ClbrGraphSeriesUid] = @ClbrGraphSeriesUid)

		-- Проверка числа обработанных записей
		EXEC [dbo].[sp_RowCountCheck] N'ClbrGraphSeries', @@ROWCOUNT, @RaiseError;

		-- Запись события в лог
		EXEC [dbo].[ClbrGraphSeries_Log]
			N'D',
			@ClbrGraphSeriesUid,
			@ClbrGraphUid,
			@ClbrGraphWSUid,
			@Name,
			@SeriesType,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL;
							
	END TRY
	BEGIN CATCH
		-- Ошибка
		EXEC [dbo].[sp_DeleteRowError] N'ClbrGraphSeries', @RaiseError;
	END CATCH;
END;

GO



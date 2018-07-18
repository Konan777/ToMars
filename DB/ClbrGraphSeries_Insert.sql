CREATE PROCEDURE [dbo].[ClbrGraphSeries_Insert]
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

		-- Вставка данных в [ClbrGraphSeries]
		INSERT INTO [ClbrGraphSeries] (
			[ClbrGraphSeriesUid],
			[ClbrGraphUid],
			[ClbrGraphWSUid],
			[Name],
			[SeriesType],
		) VALUES (
			@ClbrGraphSeriesUid,
			@ClbrGraphUid,
			@ClbrGraphWSUid,
			@Name,
			@SeriesType
		);

		-- Проверка числа обработанных записей
		EXEC [dbo].[sp_RowCountCheck] N'ClbrGraphSeries', @@ROWCOUNT, @RaiseError;

		-- Запись события в лог
		EXEC [dbo].[ClbrGraphSeries_Log]
			N'I',
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			@ClbrGraphSeriesUid,
			@ClbrGraphUid,
			@ClbrGraphWSUid,
			@Name,
			@SeriesType,

	END TRY
	BEGIN CATCH
		-- Ошибка
		EXEC [dbo].[sp_InsertRowError] N'ClbrGraphSeries', @RaiseError;
	END CATCH;
END;

GO



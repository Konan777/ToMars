CREATE PROCEDURE [dbo].[ClbrGraphSeries_Update]
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

		Declare @oldClbrGraphSeriesUid uniqueidentifier
		Declare @oldClbrGraphUid uniqueidentifier
		Declare @oldClbrGraphWSUid uniqueidentifier
		Declare @oldName nvarchar(150)
		Declare @oldSeriesType int


	
		SELECT 			
			@oldClbrGraphSeriesUid = [ClbrGraphSeriesUid],
			@oldClbrGraphUid = [ClbrGraphUid],
			@oldClbrGraphWSUid = [ClbrGraphWSUid],
			@oldName = [Name],
			@oldSeriesType = [SeriesType]
		FROM [ClbrGraphSeries]
		WHERE [ClbrGraphSeriesUid] = @ClbrGraphSeriesUid
	

		-- Изменение данных в [ClbrGraphSeries]
		UPDATE [ClbrGraphSeries]
		SET 
			[ClbrGraphSeriesUid] = @ClbrGraphSeriesUid,
			[ClbrGraphUid] = @ClbrGraphUid,
			[ClbrGraphWSUid] = @ClbrGraphWSUid,
			[Name] = @Name,
			[SeriesType] = @SeriesType
		WHERE [ClbrGraphSeriesUid] = @ClbrGraphSeriesUid;

		-- Проверка числа обработанных записей
		EXEC [dbo].[sp_RowCountCheck] N'ClbrGraphSeries', @@ROWCOUNT, @RaiseError;

		-- Запись события в лог
		EXEC [dbo].[ClbrGraphSeries_Log]
			N'U',
			@oldClbrGraphSeriesUid,
			@oldClbrGraphUid,
			@oldClbrGraphWSUid,
			@oldName,
			@oldSeriesType,
			@ClbrGraphSeriesUid,
			@ClbrGraphUid,
			@ClbrGraphWSUid,
			@Name,
			@SeriesType

	END TRY
	BEGIN CATCH
		-- Ошибка
		EXEC [dbo].[sp_UpdateRowError] N'ClbrGraphSeries', @RaiseError;
	END CATCH;
END;

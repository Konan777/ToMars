CREATE PROCEDURE [dbo].[ClbrGraphSeries_Insert]
	-- ��������� ���������
	@RaiseError bit = 1,
	
	-- ������
	@ClbrGraphSeriesUid uniqueidentifier,
	@ClbrGraphUid uniqueidentifier,
	@ClbrGraphWSUid uniqueidentifier,
	@Name nvarchar(150),
	@SeriesType int
AS
BEGIN	
	SET NOCOUNT ON;

	BEGIN TRY

		-- ������� ������ � [ClbrGraphSeries]
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

		-- �������� ����� ������������ �������
		EXEC [dbo].[sp_RowCountCheck] N'ClbrGraphSeries', @@ROWCOUNT, @RaiseError;

		-- ������ ������� � ���
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
		-- ������
		EXEC [dbo].[sp_InsertRowError] N'ClbrGraphSeries', @RaiseError;
	END CATCH;
END;

GO



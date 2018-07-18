CREATE PROCEDURE [dbo].[ClbrGraphSeries_Delete]
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

		-- �������� ������ �� [ClbrGraphSeries]
		DELETE FROM [ClbrGraphSeries]
		WHERE ([ClbrGraphSeriesUid] = @ClbrGraphSeriesUid)

		-- �������� ����� ������������ �������
		EXEC [dbo].[sp_RowCountCheck] N'ClbrGraphSeries', @@ROWCOUNT, @RaiseError;

		-- ������ ������� � ���
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
		-- ������
		EXEC [dbo].[sp_DeleteRowError] N'ClbrGraphSeries', @RaiseError;
	END CATCH;
END;

GO



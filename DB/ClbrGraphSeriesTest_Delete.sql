CREATE PROCEDURE [dbo].[ClbrGraphSeriesTest_Delete]
	-- ��������� ���������
	@RaiseError bit = 1,
	
	-- ������
	@ClbrGraphSeriesTestUid uniqueidentifier,
	@ClbrGraphSeriesUid uniqueidentifier,
	@TechTestUid uniqueidentifier,
	@Value float,
	@Flags float
AS
BEGIN	
	SET NOCOUNT ON;

	BEGIN TRY

		-- �������� ������ �� [ClbrGraphSeriesTest]
		DELETE FROM [ClbrGraphSeriesTest]
		WHERE ([ClbrGraphSeriesTestUid] = @ClbrGraphSeriesTestUid)

		-- �������� ����� ������������ �������
		EXEC [dbo].[sp_RowCountCheck] N'ClbrGraphSeriesTest', @@ROWCOUNT, @RaiseError;

		-- ������ ������� � ���
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
		-- ������
		EXEC [dbo].[sp_DeleteRowError] N'ClbrGraphSeriesTest', @RaiseError;
	END CATCH;
END;

GO



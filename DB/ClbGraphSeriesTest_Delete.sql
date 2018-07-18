CREATE PROCEDURE [dbo].[ClbGraphSeriesTest_Delete]
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

		-- �������� ������ �� [ClbGraphSeriesTest]
		DELETE FROM [ClbGraphSeriesTest]
		WHERE ([ClbrGraphSeriesTestUid] = @ClbrGraphSeriesTestUid)

		-- �������� ����� ������������ �������
		EXEC [dbo].[sp_RowCountCheck] N'ClbGraphSeriesTest', @@ROWCOUNT, @RaiseError;

		-- ������ ������� � ���
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
		-- ������
		EXEC [dbo].[sp_DeleteRowError] N'ClbGraphSeriesTest', @RaiseError;
	END CATCH;
END;

GO



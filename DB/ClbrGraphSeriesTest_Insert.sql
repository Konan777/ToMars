CREATE PROCEDURE [dbo].[ClbrGraphSeriesTest_Insert]
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

		-- ������� ������ � [ClbrGraphSeriesTest]
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

		-- �������� ����� ������������ �������
		EXEC [dbo].[sp_RowCountCheck] N'ClbrGraphSeriesTest', @@ROWCOUNT, @RaiseError;

		-- ������ ������� � ���
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
		-- ������
		EXEC [dbo].[sp_InsertRowError] N'ClbrGraphSeriesTest', @RaiseError;
	END CATCH;
END;

GO



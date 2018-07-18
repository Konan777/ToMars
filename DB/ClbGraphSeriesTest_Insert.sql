CREATE PROCEDURE [dbo].[ClbGraphSeriesTest_Insert]
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

		-- ������� ������ � [ClbrGraphEqp]
		INSERT INTO [ClbGraphSeriesTest] (
			[ClbrGraphEqpUid],
			[ClbrGraphUid],
			[EqpUid]
		) VALUES (
			@ClbrGraphEqpUid,
			@ClbrGraphUid,
			@EqpUid);

		-- �������� ����� ������������ �������
		EXEC [dbo].[sp_RowCountCheck] N'ClbGraphSeriesTest', @@ROWCOUNT, @RaiseError;

		-- ������ ������� � ���
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
		-- ������
		EXEC [dbo].[sp_InsertRowError] N'ClbGraphSeriesTest', @RaiseError;
	END CATCH;
END;

GO



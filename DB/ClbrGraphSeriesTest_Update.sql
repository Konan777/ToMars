CREATE PROCEDURE [dbo].[ClbrGraphSeriesTest_Update]
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

		Declare @oldClbrGraphSeriesTestUid uniqueidentifier,
		Declare @oldClbrGraphSeriesUid uniqueidentifier,
		Declare @oldTechTestUid uniqueidentifier,
		Declare @oldValue float,
		Declare @oldFlags float

	
		SELECT 			
			@oldClbrGraphSeriesTestUid = [ClbrGraphSeriesTestUid],
			@oldClbrGraphSeriesUid = [ClbrGraphSeriesUid],
			@oldTechTestUid = [TechTestUid],
			@oldValue = [Value],
			@oldFlags = [Flags]
		FROM [ClbrGraphSeriesTest]
		WHERE [ClbrGraphSeriesTestUid] = @ClbrGraphSeriesTestUid
	

		-- ��������� ������ � [ClbrGraphSeriesTest]
		UPDATE [ClbrGraphSeriesTest]
		SET 
			[ClbrGraphSeriesTestUid] = @ClbrGraphSeriesTestUid,
			[ClbrGraphSeriesUid] = @ClbrGraphSeriesUid,
			[TechTestUid] = @TechTestUid,
			[Value] = @Value,
			[Flags] = @Flags 
		WHERE [ClbrGraphSeriesTestUid] = @ClbrGraphSeriesTestUid;

		-- �������� ����� ������������ �������
		EXEC [dbo].[sp_RowCountCheck] N'ClbrGraphSeriesTest', @@ROWCOUNT, @RaiseError;

		-- ������ ������� � ���
		EXEC [dbo].[ClbrGraphSeriesTest_Log]
			N'U',
			@OldGraphSeriesTestUid,
			@OldClbrGraphSeriesUid,
			@OldTechTestUid,
			@OldValue,
			@OldFlags,
			@ClbrGraphSeriesTestUid,
			@ClbrGraphSeriesUid,
			@TechTestUid,
			@Value,
			@Flags;

	END TRY
	BEGIN CATCH
		-- ������
		EXEC [dbo].[sp_UpdateRowError] N'ClbrGraphSeriesTest', @RaiseError;
	END CATCH;
END;

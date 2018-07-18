CREATE PROCEDURE [dbo].[ClbGraphSeriesTest_Update]
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
		FROM [ClbGraphSeriesTest]
		WHERE [ClbrGraphSeriesTestUid] = @ClbrGraphSeriesTestUid
	

		-- ��������� ������ � [ClbGraphSeriesTest]
		UPDATE [ClbGraphSeriesTest]
		SET 
			[ClbrGraphSeriesTestUid] = @oldClbrGraphSeriesTestUid,
			[ClbrGraphSeriesUid] = @oldClbrGraphSeriesUid,
			[TechTestUid] = @oldTechTestUid,
			[Value] = @oldValue,
			[Flags] = @oldFlags 
		WHERE [ClbrGraphSeriesTestUid] = @ClbrGraphSeriesTestUid;

		-- �������� ����� ������������ �������
		EXEC [dbo].[sp_RowCountCheck] N'ClbGraphSeriesTest', @@ROWCOUNT, @RaiseError;

		-- ������ ������� � ���
		EXEC [dbo].[ClbrGraph_Log]
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
		EXEC [dbo].[sp_UpdateRowError] N'ClbGraphSeriesTest', @RaiseError;
	END CATCH;
END;

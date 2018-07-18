CREATE PROCEDURE [dbo].[ClbGraphSeriesTest_Log]
	@EventType nvarchar(2),

	@oldClbrGraphSeriesTestUid uniqueidentifier,
	@oldClbrGraphSeriesUid uniqueidentifier,
	@oldTechTestUid uniqueidentifier,
	@oldValue float,
	@oldFlags float,

	@newClbrGraphSeriesTestUid uniqueidentifier,
	@newClbrGraphSeriesUid uniqueidentifier,
	@newTechTestUid uniqueidentifier,
	@newValue float,
	@newFlags float


AS
BEGIN	
	DECLARE @sysEventLogId int;
	EXEC [dbo].[spc_sys_LogEvent] N'ClbGraphSeriesTest', @EventType, @sysEventLogId OUTPUT;
	EXEC [dbo].[spc_sys_LogEventData] @sysEventLogId, N'ClbrGraphSeriesTestUid', @oldClbrGraphSeriesTestUid, @newClbrGraphSeriesTestUid, 1;
	EXEC [dbo].[spc_sys_LogEventData] @sysEventLogId, N'ClbrGraphSeriesUid', @oldClbrGraphSeriesUid, @newClbrGraphSeriesUid;
	EXEC [dbo].[spc_sys_LogEventData] @sysEventLogId, N'TechTestUid', @oldTechTestUid, @newTechTestUid;
	EXEC [dbo].[spc_sys_LogEventData] @sysEventLogId, N'Value', @oldValue, @newValue;
	EXEC [dbo].[spc_sys_LogEventData] @sysEventLogId, N'Flags', @oldFlags, @newFlags;
END;
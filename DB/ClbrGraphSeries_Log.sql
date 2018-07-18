CREATE PROCEDURE [dbo].[ClbrGraphSeries_Log]
	@EventType nvarchar(2),

	@oldClbrGraphSeriesUid uniqueidentifier,
	@oldClbrGraphUid uniqueidentifier,
	@oldClbrGraphWSUid uniqueidentifier,
	@oldName nvarchar(150),
	@oldSeriesType int,

	@newClbrGraphSeriesUid uniqueidentifier,
	@newClbrGraphUid uniqueidentifier,
	@newClbrGraphWSUid uniqueidentifier,
	@newName nvarchar(150),
	@newSeriesType int


AS
BEGIN	
	DECLARE @sysEventLogId int;
	EXEC [dbo].[spc_sys_LogEvent] N'ClbrGraphSeries', @EventType, @sysEventLogId OUTPUT;
	EXEC [dbo].[spc_sys_LogEventData] @sysEventLogId, N'ClbrGraphSeriesUid', @oldClbrGraphSeriesUid, @newClbrGraphSeriesUid;
	EXEC [dbo].[spc_sys_LogEventData] @sysEventLogId, N'ClbrGraphUid', @oldClbrGraphUid, @newClbrGraphUid;
	EXEC [dbo].[spc_sys_LogEventData] @sysEventLogId, N'ClbrGraphWSUid', @oldClbrGraphWSUid, @newClbrGraphWSUid;
	EXEC [dbo].[spc_sys_LogEventData] @sysEventLogId, N'Name', @oldName, @newName;
	EXEC [dbo].[spc_sys_LogEventData] @sysEventLogId, N'SeriesType', @oldSeriesType, @newSeriesType;
END;
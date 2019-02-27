delete from TestApp01
GO

declare
	@dtst date = GetDate()-10
	,@dten date = GetDate()
	,@xml nvarchar(max) = '
		<ROOT>
		  <APPLICATION ID="15" AccountId="100500" CreatedOn="2019-01-01 02:11:23" Source="vk" Medium="cpm" Campaign="RKO_leadform_av1" Content="47754476" />
		  <APPLICATION AccountId="4DB9D8B6-6B6B-4940-86CF-A9C8016E058A" CreatedOn="2019-01-01 03:39:47" DateStatus="2019-01-01 03:39:50" Label="Телефон подтвержден" />
		</ROOT>
	'
exec [dbo].BulkInsertDataRaw @XML, 1, @dtst, @dten, 0,'dbo', 'TestApp01', 'CreatedOn'


delete from TestApp02
GO
declare
	@dtst date = GetDate()-10
	,@dten date = GetDate()
	,@xml nvarchar(max) = '
		<ROOT>
		  <ITEM Id="1" AccountId="4157B988-6A0D-E911-9688-005056B7EBA8" CreatedOn="2019-01-01 02:11:23" Source="vk" Medium="cpm" Campaign="RKO_leadform_av1" Content="47754476" Col001="2019-02-02" Col002="02:02:02" Col003="12.34" Col004="12.34" Col005="4157B988-6A0D-E911-9688-005056B7EBA8" />
		  <ITEM Id="2" AccountId="4DB9D8B6-6B6B-4940-86CF-A9C8016E058A" CreatedOn="2019-01-01 03:39:47" DateStatus="2019-01-01 03:39:50" Label="Телефон подтвержден" />
		</ROOT>
	'

exec [dbo].BulkInsertDataRaw @XML, 1, @dtst, @dten, 0,'dbo', 'TestApp02', 'CreatedOn'


delete from TestApp03
GO
declare
	@dtst date = GetDate()-10
	,@dten date = GetDate()
	,@xml nvarchar(max) = '
		<ROOT>
		  <APPLICATION Id="1" AtomId="33" AccountId="4157B988-6A0D-E911-9688-005056B7EBA8" CreatedOn="2019-01-01 02:11:23" Source="vk" Medium="cpm" Campaign="RKO_leadform_av1" Content="47754476" />
		  <APPLICATION Id="2" AtomId="44" AccountId="4DB9D8B6-6B6B-4940-86CF-A9C8016E058A" CreatedOn="2019-01-01 03:39:47" DateStatus="2019-01-01 03:39:50" Label="Телефон подтвержден" />
		</ROOT>
	'

exec [dbo].BulkInsertDataRaw @XML, 1, @dtst, @dten, 0,'dbo', 'TestApp03', 'CreatedOn'

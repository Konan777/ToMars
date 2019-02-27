IF OBJECT_ID('[dbo].[BulkInsertDataRaw]', 'P') IS NOT NULL drop procedure [dbo].BulkInsertDataRaw;
GO

CREATE PROCEDURE [dbo].[BulkInsertDataRaw] (
	@xmlString NVARCHAR(MAX), 
	@cleanup BIT, 
	@startDate DATE, 
	@endDate DATE, 
	@mapOnly BIT,
	@tableAndSchema as NVARCHAR(50),
	@cleanupFilterColumn as NVARCHAR(50)
) AS
BEGIN
	DECLARE
		@columns NVARCHAR(MAX)			-- [Id], [Date], [AtomId]
		,@schema NVARCHAR(MAX)			-- [Id] [int], [Date] [datetime], [AtomId] [int] 
		,@createSchema NVARCHAR(MAX)	-- [Source]	[NVARCHAR](max) NULL,
		,@updateStatement NVARCHAR(max) -- [Id] = T.[Id], [Date] = T.[Date],
		,@insertStatement NVARCHAR(max) -- T.[Id], T.[Date]
		,@col_name NVARCHAR(MAX)
		,@col_type NVARCHAR(MAX)
		,@max_len INT
		,@nullable NVARCHAR(MAX)
		,@statement NVARCHAR(max)
		,@tStatement VARCHAR(max)
		,@primaryKey NVARCHAR(max)
		,@columnsNoPrimaryKey NVARCHAR(MAX)			
		,@columnsToInsert NVARCHAR(MAX)			
		,@joinByPrimaryKeyCondition NVARCHAR(MAX)
		,@condPKIsNull NVARCHAR(MAX)
		,@condPKIsNotNull NVARCHAR(MAX)
		,@identityKey NVARCHAR(MAX)
		,@errorMessage NVARCHAR(MAX)
		,@tableSchema as NVARCHAR(50)
		,@tableName as NVARCHAR(50)

	-- унификация
	SET @tableSchema = REPLACE(REPLACE(@tableAndSchema, '[',''),']','')
	SET @tableName = SUBSTRING(@tableSchema, CHARINDEX('.', @tableSchema)+1, LEN(@tableSchema))
	SET @tableSchema = SUBSTRING(@tableSchema, 0, CHARINDEX('.', @tableSchema))
	SET @tableAndSchema = '['+@tableSchema+'].['+@tableName+']'
	SET @cleanupFilterColumn = REPLACE(REPLACE(@cleanupFilterColumn, '[',''),']','')

	DECLARE 
		columns_cursor CURSOR FOR  
		SELECT COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH, IS_NULLABLE
		FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME=@tableName and TABLE_SCHEMA=@tableSchema
	
	-- Соберем поля первичного ключа не являющегося identity
	SELECT @primaryKey = COALESCE(@primaryKey + ', ', '') + c.name,
		@joinByPrimaryKeyCondition = COALESCE(@joinByPrimaryKeyCondition + ' AND ', '') + 'T.['+c.name+'] = ['+@tableSchema+'].['+@tableName+'].['+c.name+']',
		@condPKIsNotNull = COALESCE(@condPKIsNotNull + ' AND ', '') + '['+@tableSchema+'].['+@tableName+'].['+c.name+'] IS NOT NULL',
		@condPKIsNull = COALESCE(@condPKIsNull + ' AND ', '') + '['+@tableSchema+'].['+@tableName+'].['+c.name+'] is null'
	FROM 
		sys.tables t 
		LEFT JOIN sys.columns c ON c.OBJECT_ID = t.OBJECT_ID
		LEFT JOIN sys.identity_columns idc ON idc.OBJECT_ID = t.OBJECT_ID AND idc.column_id = c.column_id AND idc.is_identity = 1
		LEFT JOIN sys.index_columns ic ON ic.OBJECT_ID = t.OBJECT_ID AND ic.column_id = c.column_id
		LEFT JOIN sys.indexes i ON i.OBJECT_ID = t.OBJECT_ID AND i.index_id = ic.index_id AND i.is_primary_key = 1
	WHERE t.type = 'U' AND (idc.is_identity = 1 OR i.is_primary_key = 1 OR c.name = 'ID') 
		and idc.is_identity is null and i.is_primary_key IS NOT NULL and t.name=@tableName

	-- Соберем поле первичного ключа _являющегося_ identity
	SELECT @identityKey=c.name,
		@joinByPrimaryKeyCondition = COALESCE(@joinByPrimaryKeyCondition + ' AND ', '') + 'T.['+c.name+'] = ['+@tableSchema+'].['+@tableName+'].['+c.name+']',
		@condPKIsNotNull = COALESCE(@condPKIsNotNull + ' AND ', '') + '['+@tableSchema+'].['+@tableName+'].['+c.name+'] IS NOT NULL',
		@condPKIsNull = COALESCE(@condPKIsNull + ' AND ', '') + '['+@tableSchema+'].['+@tableName+'].['+c.name+'] is null'
	FROM 
		sys.tables t 
		LEFT JOIN sys.columns c ON c.OBJECT_ID = t.OBJECT_ID
		LEFT JOIN sys.identity_columns idc ON idc.OBJECT_ID = t.OBJECT_ID AND idc.column_id = c.column_id AND idc.is_identity = 1
		LEFT JOIN sys.index_columns ic ON ic.OBJECT_ID = t.OBJECT_ID AND ic.column_id = c.column_id
		LEFT JOIN sys.indexes i ON i.OBJECT_ID = t.OBJECT_ID AND i.index_id = ic.index_id AND i.is_primary_key = 1
	WHERE t.type = 'U' AND (idc.is_identity = 1 OR i.is_primary_key = 1 OR c.name = 'ID') 
		and idc.is_identity=1 and i.is_primary_key IS NOT NULL and t.name=@tableName

	--PRINT '@primaryKey:'+@primaryKey
	--PRINT '@identityKey:'+@identityKey

	-- { Соберем @columns и @schema
	OPEN columns_cursor;  
	FETCH NEXT FROM columns_cursor INTO @col_name, @col_type, @max_len, @nullable;  
	WHILE @@FETCH_STATUS = 0  
	BEGIN
		SET @columns = COALESCE(@columns + ', ', '') + '['+@col_name+']'
		
		-- первичные ключи не апдейтим и не вставляем
		if UPPER(@col_name)!=upper(@identityKey) or @identityKey is null
		BEGIN
			SET @updateStatement = COALESCE(@updateStatement + ', ', '') + '['+@col_name+'] = T.['+@col_name+']'
			SET @insertStatement = COALESCE(@insertStatement + ', ', '') + 'T.['+@col_name+']'
			SET @columnsToInsert = COALESCE(@columnsToInsert + ', ', '') + '['+@col_name+']'
		END

		IF @col_type in ('int', 'bigint', 'bit','datetime', 'date', 'time', 'money', 'float', 'uniqueidentifier') 
		BEGIN
			SET @schema = COALESCE(@schema + ', ', '') + '['+@col_name+']' +' ['+@col_type+'] '
			SET @createSchema = COALESCE(@createSchema + ', ', '') + '['+@col_name+']' +' ['+@col_type+'] NULL' 
		END
		ELSE IF (@col_type in ('NVARCHAR', 'varchar') and @max_len = -1) 
		BEGIN
			SET @schema = COALESCE(@schema + ', ', '') + '['+@col_name+']' +' ['+@col_type+'](MAX) '
			SET @createSchema = COALESCE(@createSchema + ', ', '') + '['+@col_name+']' +' ['+@col_type+'](MAX) NULL'
		END
		ELSE IF (@col_type in ('NVARCHAR', 'varchar') and @max_len>0) 
		BEGIN
			SET @schema = COALESCE(@schema + ', ', '') + '['+@col_name+']' +' ['+@col_type+']('+COALESCE(CAST(@max_len as NVARCHAR(20)), '')+') '
			SET @createSchema = COALESCE(@createSchema + ', ', '') + '['+@col_name+']' +' ['+@col_type+']('+COALESCE(CAST(@max_len as NVARCHAR(20)), '')+') NULL'
		END
		ELSE 
		BEGIN
			SET @errorMessage='not implemented column type:'+@col_type
			RAISERROR(@errorMessage,16,1)
			RETURN
		END
		-- добавить условия для других типов данных
	
		FETCH NEXT FROM columns_cursor INTO @col_name, @col_type,  @max_len, @nullable;
	END
	
	/*PRINT '@columns:'+@columns
	PRINT '@schema:'+@schema
	PRINT '@createSchema:'+@createSchema
	PRINT '@joinByPrimaryKeyCondition:'+@joinByPrimaryKeyCondition
	PRINT '@updateStatement:'+@updateStatement
	PRINT '@joinByPrimaryKeyCondition:'+@joinByPrimaryKeyCondition
	PRINT '@condPKIsNotNull:'+@condPKIsNotNull*/

	CLOSE columns_cursor;  
	DEALLOCATE columns_cursor;  
	-- } Соберем @columns и @schema

    SET NOCOUNT ON

	IF @cleanup = 1 
	BEGIN
		SET @statement = '
		DECLARE @endDatePlusOneDay DATE
		SELECT @endDatePlusOneDay = DATEADD(DAY, 1, @endDate)
		DELETE		'+@tableAndSchema+'
		WHERE		['+@cleanupFilterColumn+'] >= @startDate AND ['+@cleanupFilterColumn+'] < @endDatePlusOneDay'
		
		EXEC dbo.sp_executesql @statement, N'@endDate datetime, @startDate datetime',@endDate, @startDate;
		
		--PRINT 'cleaned:'+cast(@@ROWCOUNT as NVARCHAR)
	END

	if @mapOnly = 1 and CHARINDEX('AtomId', @columns)>0
	BEGIN
		SET	@tStatement = 'DECLARE @t TABLE ('+@createSchema+') '+
			'DECLARE @XMLDocPointer INT    
			EXEC sp_xml_preparedocument @XMLDocPointer OUTPUT, @XmlString

			INSERT INTO @t('+@columns+')    
			SELECT		'+@columns+'
			FROM OPENXML(@XMLDocPointer,''/ROOT/ITEM'', 1)    
			WITH	('+@schema+')
	
			PRINT @@ROWCOUNT

			EXEC sp_xml_removedocument @XMLDocPointer 

			UPDATE		'+@tableAndSchema+'
			SET			[AtomId]		= T.[AtomId],
						[Version]		= T.[Version],
						[BindingRuleId]		= T.[BindingRuleId]
			FROM		'+@tableAndSchema+'
			INNER JOIN	@t AS T ON T.[Id] = '+@tableAndSchema+'.[Id]

			--PRINT ''MAPPED:''+cast(@@ROWCOUNT as varchar)'
	END
	ELSE
	BEGIN
		SET	@tStatement = 'DECLARE @t TABLE ('+@createSchema+') '+
			'DECLARE @XMLDocPointer INT    
			EXEC sp_xml_preparedocument @XMLDocPointer OUTPUT, @XmlString

			INSERT INTO @t('+@columns+')    
			SELECT		'+@columns+'
			FROM OPENXML(@XMLDocPointer,''/ROOT/ITEM'', 1)    
			WITH	('+@schema+')
	
			EXEC sp_xml_removedocument @XMLDocPointer 

			UPDATE		'+@tableAndSchema+'
			SET			'+@updateStatement+'
			FROM		@t AS T
			INNER JOIN	'+@tableAndSchema+' ON '+@joinByPrimaryKeyCondition+'
			WHERE '+@condPKIsNotNull+'

			--PRINT ''UPDATED:''+cast(@@ROWCOUNT as varchar)

			INSERT INTO '+@tableAndSchema+' ('+@columnsToInsert+')
			SELECT		'+@insertStatement+'
			FROM		@t AS T
			LEFT JOIN	'+@tableAndSchema+'	ON '+@joinByPrimaryKeyCondition+'
			WHERE '+@condPKIsNull+'

			--PRINT ''INSERTED:''+cast(@@ROWCOUNT as varchar)'
	END

	-- почему то обрезает NVARCHAR(max) до 4000 символов. собираем сперва в varchar(max)//
	SET @statement = @tStatement

	--print @statement

	EXEC dbo.sp_executesql @statement,N'@xmlString NVARCHAR(MAX), @cleanup BIT, @startDate DATE, @endDate DATE, @mapOnly BIT, @tableSchema as NVARCHAR(50), @tableName as NVARCHAR(50) ',@xmlString, @cleanup, @startDate, @endDate, @mapOnly, @tableSchema, @tableName

END

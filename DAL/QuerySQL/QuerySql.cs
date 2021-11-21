using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class QuerySql
    {
		//get table
        public string text =
            @"	SELECT main.COLUMN_NAME,main.IS_NULLABLE,DATA_TYPE, CHARACTER_MAXIMUM_LENGTH ,SPACE(2) AS IS_PK , SPACE(2) AS IS_FK,SPACE(1) Is_IDENTITY INTO #KQ1

                FROM INFORMATION_SCHEMA.COLUMNS AS main

                WHERE TABLE_NAME = @tb 

                ; WITH #ISKEY AS (SELECT TABLE_NAME, COLUMN_NAME , CAST( CONSTRAINT_NAME AS CHAR(2)) AS IS_KEY 
								FROM INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE
								)
				SELECT COLUMN_NAME, ISNULL([PK],'') AS PK, ISNULL([FK],'') AS FK INTO #KQ2 FROM #ISKEY
				PIVOT(MAX(IS_KEY) FOR IS_KEY IN ([PK],[FK])) AS OK
                UPDATE #KQ1 SET IS_PK=PK ,IS_FK=FK,Is_IDENTITY=IsIDentity.is_identity
				FROM #KQ2 ,sys.columns AS IsIDentity  WHERE #KQ1.COLUMN_NAME=#KQ2.COLUMN_NAME AND	IsIDentity.[object_id] = object_id(@tb) AND IsIDentity.is_identity='1'

				SELECT* FROM #KQ1
				DROP TABLE #KQ1
				DROP TABLE #KQ2
                 ";

        public string StoreProcedureParameter =
                @"select pa.name as param#,t.name as type#, pa.max_length from sys.parameters pa
                inner join sys.procedures pr on pa.object_id = pr.object_id
                inner join sys.types t on pa.system_type_id = t.system_type_id AND pa.user_type_id = t.user_type_id
                where pr.object_id = @id";

		public string GenScriptsForExistingTables =
				@"DECLARE @table_name SYSNAME
			SELECT @table_name = @tb

			DECLARE 
				  @object_name SYSNAME
				, @object_id INT

			SELECT 
				  @object_name = '[' + s.name + '].[' + o.name + ']'
				, @object_id = o.[object_id]
			FROM sys.objects o WITH (NOWAIT)
			JOIN sys.schemas s WITH (NOWAIT) ON o.[schema_id] = s.[schema_id]
			WHERE s.name + '.' + o.name = @table_name
				AND o.[type] = 'U'
				AND o.is_ms_shipped = 0

			DECLARE @SQL NVARCHAR(MAX) = ''

			;WITH index_column AS 
			(
				SELECT 
					  ic.[object_id]
					, ic.index_id
					, ic.is_descending_key
					, ic.is_included_column
					, c.name
				FROM sys.index_columns ic WITH (NOWAIT)
				JOIN sys.columns c WITH (NOWAIT) ON ic.[object_id] = c.[object_id] AND ic.column_id = c.column_id
				WHERE ic.[object_id] = @object_id
			),
			fk_columns AS 
			(
				 SELECT 
					  k.constraint_object_id
					, cname = c.name
					, rcname = rc.name
				FROM sys.foreign_key_columns k WITH (NOWAIT)
				JOIN sys.columns rc WITH (NOWAIT) ON rc.[object_id] = k.referenced_object_id AND rc.column_id = k.referenced_column_id 
				JOIN sys.columns c WITH (NOWAIT) ON c.[object_id] = k.parent_object_id AND c.column_id = k.parent_column_id
				WHERE k.parent_object_id = @object_id
			)
			SELECT @SQL = 'CREATE TABLE ' + @object_name + CHAR(13) + '(' + CHAR(13) + STUFF((
				SELECT CHAR(9) + ', [' + c.name + '] ' + 
					CASE WHEN c.is_computed = 1
						THEN 'AS ' + cc.[definition] 
						ELSE UPPER(tp.name) + 
							CASE WHEN tp.name IN ('varchar', 'char', 'varbinary', 'binary', 'text')
								   THEN '(' + CASE WHEN c.max_length = -1 THEN 'MAX' ELSE CAST(c.max_length AS VARCHAR(5)) END + ')'
								 WHEN tp.name IN ('nvarchar', 'nchar', 'ntext')
								   THEN '(' + CASE WHEN c.max_length = -1 THEN 'MAX' ELSE CAST(c.max_length / 2 AS VARCHAR(5)) END + ')'
								 WHEN tp.name IN ('datetime2', 'time2', 'datetimeoffset') 
								   THEN '(' + CAST(c.scale AS VARCHAR(5)) + ')'
								 WHEN tp.name = 'decimal' 
								   THEN '(' + CAST(c.[precision] AS VARCHAR(5)) + ',' + CAST(c.scale AS VARCHAR(5)) + ')'
								ELSE ''
							END +
							CASE WHEN c.collation_name IS NOT NULL THEN ' COLLATE ' + c.collation_name ELSE '' END +
							CASE WHEN c.is_nullable = 1 THEN ' NULL' ELSE ' NOT NULL' END +
							CASE WHEN dc.[definition] IS NOT NULL THEN ' DEFAULT' + dc.[definition] ELSE '' END + 
							CASE WHEN ic.is_identity = 1 THEN ' IDENTITY(' + CAST(ISNULL(ic.seed_value, '0') AS CHAR(1)) + ',' + CAST(ISNULL(ic.increment_value, '1') AS CHAR(1)) + ')' ELSE '' END 
					END + CHAR(13)
				FROM sys.columns c WITH (NOWAIT)
				JOIN sys.types tp WITH (NOWAIT) ON c.user_type_id = tp.user_type_id
				LEFT JOIN sys.computed_columns cc WITH (NOWAIT) ON c.[object_id] = cc.[object_id] AND c.column_id = cc.column_id
				LEFT JOIN sys.default_constraints dc WITH (NOWAIT) ON c.default_object_id != 0 AND c.[object_id] = dc.parent_object_id AND c.column_id = dc.parent_column_id
				LEFT JOIN sys.identity_columns ic WITH (NOWAIT) ON c.is_identity = 1 AND c.[object_id] = ic.[object_id] AND c.column_id = ic.column_id
				WHERE c.[object_id] = @object_id
				ORDER BY c.column_id
				FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 2, CHAR(9) + ' ')
				+ ISNULL((SELECT CHAR(9) + ', CONSTRAINT [' + k.name + '] PRIMARY KEY (' + 
								(SELECT STUFF((
									 SELECT ', [' + c.name + '] ' + CASE WHEN ic.is_descending_key = 1 THEN 'DESC' ELSE 'ASC' END
									 FROM sys.index_columns ic WITH (NOWAIT)
									 JOIN sys.columns c WITH (NOWAIT) ON c.[object_id] = ic.[object_id] AND c.column_id = ic.column_id
									 WHERE ic.is_included_column = 0
										 AND ic.[object_id] = k.parent_object_id 
										 AND ic.index_id = k.unique_index_id     
									 FOR XML PATH(N''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 2, ''))
						+ ')' + CHAR(13)
						FROM sys.key_constraints k WITH (NOWAIT)
						WHERE k.parent_object_id = @object_id 
							AND k.[type] = 'PK'), '') + ')'  + CHAR(13)
				+ ISNULL((SELECT (
					SELECT CHAR(13) +
						 'ALTER TABLE ' + @object_name + ' WITH' 
						+ CASE WHEN fk.is_not_trusted = 1 
							THEN ' NOCHECK' 
							ELSE ' CHECK' 
						  END + 
						  ' ADD CONSTRAINT [' + fk.name  + '] FOREIGN KEY(' 
						  + STUFF((
							SELECT ', [' + k.cname + ']'
							FROM fk_columns k
							WHERE k.constraint_object_id = fk.[object_id]
							FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 2, '')
						   + ')' +
						  ' REFERENCES [' + SCHEMA_NAME(ro.[schema_id]) + '].[' + ro.name + '] ('
						  + STUFF((
							SELECT ', [' + k.rcname + ']'
							FROM fk_columns k
							WHERE k.constraint_object_id = fk.[object_id]
							FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 2, '')
						   + ')'
						+ CASE 
							WHEN fk.delete_referential_action = 1 THEN ' ON DELETE CASCADE' 
							WHEN fk.delete_referential_action = 2 THEN ' ON DELETE SET NULL'
							WHEN fk.delete_referential_action = 3 THEN ' ON DELETE SET DEFAULT' 
							ELSE '' 
						  END
						+ CASE 
							WHEN fk.update_referential_action = 1 THEN ' ON UPDATE CASCADE'
							WHEN fk.update_referential_action = 2 THEN ' ON UPDATE SET NULL'
							WHEN fk.update_referential_action = 3 THEN ' ON UPDATE SET DEFAULT'  
							ELSE '' 
						  END 
						+ CHAR(13) + 'ALTER TABLE ' + @object_name + ' CHECK CONSTRAINT [' + fk.name  + ']' + CHAR(13)
					FROM sys.foreign_keys fk WITH (NOWAIT)
					JOIN sys.objects ro WITH (NOWAIT) ON ro.[object_id] = fk.referenced_object_id
					WHERE fk.parent_object_id = @object_id
					FOR XML PATH(N''), TYPE).value('.', 'NVARCHAR(MAX)')), '')
				+ ISNULL(((SELECT
					 CHAR(13) + 'CREATE' + CASE WHEN i.is_unique = 1 THEN ' UNIQUE' ELSE '' END 
							+ ' NONCLUSTERED INDEX [' + i.name + '] ON ' + @object_name + ' (' +
							STUFF((
							SELECT ', [' + c.name + ']' + CASE WHEN c.is_descending_key = 1 THEN ' DESC' ELSE ' ASC' END
							FROM index_column c
							WHERE c.is_included_column = 0
								AND c.index_id = i.index_id
							FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 2, '') + ')'  
							+ ISNULL(CHAR(13) + 'INCLUDE (' + 
								STUFF((
								SELECT ', [' + c.name + ']'
								FROM index_column c
								WHERE c.is_included_column = 1
									AND c.index_id = i.index_id
								FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 2, '') + ')', '')  + CHAR(13)
					FROM sys.indexes i WITH (NOWAIT)
					WHERE i.[object_id] = @object_id
						AND i.is_primary_key = 0
						AND i.[type] = 2
					FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)')
				), '')

			SELECT @SQL";
    }
}

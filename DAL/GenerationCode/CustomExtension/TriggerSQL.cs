using Model.Expression;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.GenerationCode.CustomExtension
{
    public class TriggerSQL
    {
        string _triggerHeader = @"
			CREATE TRIGGER[dbo].[DML_{{nametable}}_ChangeLog] ON[dbo].[{{nametable}}]
				AFTER INSERT, UPDATE, DELETE AS
				  BEGIN
			SET NOCOUNT ON;
			DECLARE @_cont_inf sql_variant;
			SET @_cont_inf = (SELECT SESSION_CONTEXT(N'user_id'))
			-- Check to context info to bypass trigger
			IF ISNULL(@_cont_inf,'') = ''
			BEGIN
				PRINT 'Bypass trigger DML_{{nametable}}_ChangeLog!';
				RETURN;
			END
			-- Get command info from context including owner command and action command
			DECLARE @userId AS int;
			SET @userId = -1;
				SELECT @userId = CAST(@_cont_inf as int); 

			-- Get current UTC time
			DECLARE @t AS datetime;
				SET @t = GETUTCDATE();

			-- Get unique key for current connection session
			DECLARE @sid AS varchar(66);
				SELECT @sid = REPLACE(CAST(connection_id AS varchar(40)), '-', '') + '-' +
						LTRIM(STR(session_id)) + '-' +
						LTRIM(STR(transaction_id))
				FROM sys.dm_exec_requests
				WHERE session_id = @@SPID;

			-- Determine type of trigger
			DECLARE @type AS char (6);	
			IF NOT EXISTS(SELECT TOP 1 * FROM deleted)
			BEGIN
				SET @type = 'INSERT';
			END
			ELSE IF NOT EXISTS(SELECT TOP 1 * FROM inserted)
			BEGIN
				SET @type = 'DELETE';
			END
			ELSE
			BEGIN
				SET @type = 'UPDATE';	
				UPDATE {{nametable}} SET[ModifiedAt] = @t
				   WHERE[Id] IN(SELECT Id FROM inserted WHERE[ModifiedAt] <> @t);

				END
			IF @type = 'INSERT'
			BEGIN
				INSERT INTO[B00EventLog]
							(TableName
							, RowId
							, Command
							, LastWriteBy
							, LastWriteAt
							, SessionId)
						(SELECT '{{nametable}}'--tên bảng
								, i.Id
								,@type--loại thao tác
								,@userId-- người dùng thao tác dữ liệu
								, @t--thời gian
								, @sid --session
							  FROM inserted i);
				END
		
				ELSE
			BEGIN
				INSERT INTO[B00EventLog]
						(TableName
						, ColumnName
						, RowId
						, Command
						, LastValue
						, NewValue
						, LastWriteBy
						, LastWriteAt
						, SessionId)
					(";
        string _triggerbody = @"
					-- Log change for column {{parameters.pass}}
					SELECT '{{nametable}}'
							,'{{parameters.pass}}'
							,d.Id
							,@type
							,CONVERT(nvarchar(254), d.{{parameters.pass}}, 20)
							,CONVERT(nvarchar(254), i.{{parameters.pass}}, 20)
							,@userId
							,@t
							,@sid
						FROM deleted AS d LEFT OUTER JOIN
							inserted AS i ON d.Id = i.Id
						WHERE
							(@type = 'UPDATE' AND UPDATE({{parameters.pass}}) AND d.{{parameters.pass}}<> i.{{parameters.pass}})
					UNION ALL";
        string _triggerFooter = @"
	
					-- Log delete if DelLogColList is empty
					SELECT '{{nametable}}'
							,''
							,d.Id
							,@type
							,''
							,''
							,@userId
							,@t
							,@sid
						FROM deleted AS d
					WHERE @type = 'DELETE' 
					);
			END
		END;
";

        public string GenTrigger(string tableName, Dictionary<string, List<string>> model)
        {
            ExpressionCSharp cSharp = new ExpressionCSharp();
            string trigger = string.Empty;
            var field = model["insert"].Where(x => x.EndsWith("#p")).ToList();
			 trigger += _triggerHeader.Replace(cSharp.NameTable, tableName) + "\n";
			_triggerbody = _triggerbody.Replace(cSharp.NameTable, tableName);
            for (int i = 0; i < field.Count; i++)
            {
                string[] type = field[i].Split('#');
                trigger += _triggerbody.Replace(cSharp.ParametersPass, type[1]) + "\n";
            }
            trigger += _triggerFooter.Replace(cSharp.NameTable, tableName);

            return trigger;
        }
    }
}

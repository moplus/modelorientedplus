<CONFIG>
	NAME MDLEntityBaseModel
	CATEGORY Entity
	NODE SqlTable
</CONFIG>
<CONTENT>
</CONTENT><OUTPUT>
<%%:
if (PrimaryKeyColumnCount == 1 && PrimaryAndForeignKeyColumnCount == 1)
{
	CurrentEntity = null
	with (Entity from Solution.Find(SourceName, SqlTableName))
	{
		CurrentEntity = Entity
	}
	if (CurrentEntity != null)
	{
		foreach (SqlColumn where InPrimaryKey == true limit 1)
		{
			CurrentSqlColumn = SqlColumn
		}
		foreach (SqlForeignKey)
		{
			foreach (SqlForeignKeyColumn where SqlForeignKeyColumnName == CurrentSqlColumn.SqlColumnName)
			{
				with (Entity from Solution.Find(SourceName, ReferencedTable))
				{
					CurrentEntity.BaseEntityID = Entity.EntityID
					return
				}
			}
		}
	}
	else
	{
		trace("Entity not found for db table: ", SqlTableName)
	}
}
%%></OUTPUT>
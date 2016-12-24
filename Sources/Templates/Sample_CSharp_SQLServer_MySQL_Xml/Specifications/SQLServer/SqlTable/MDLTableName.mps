<CONFIG>
	NAME MDLTableName
	NODE SqlTable
</CONFIG>
<CONTENT>
<%%=SqlTableName.Replace("[dbo].", "").Replace("[", "").Replace("]", "")%%></CONTENT>
<CONFIG>
	NAME MDLSqlModel
	NODE SpecificationSource
	TOPLEVEL False
</CONFIG>
<CONTENT>
</CONTENT><OUTPUT>
<%%:
progress(SqlDatabase.SqlTableCount * 2)
foreach(SqlTable where MDLTableName.ToLower().StartsWith("sys") == false)
{
	// create/update feature
	<%%>MDLFeatureModel%%>
	progress
}
foreach(SqlTable where MDLTableName.ToLower().StartsWith("sys") == false)
{
	// create/update basic entity
	<%%>MDLEntityCoreModel%%>
	progress
}
%%></OUTPUT>
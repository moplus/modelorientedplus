<CONFIG>
	NAME MDLSqlModel
	NODE SpecificationSource
	TOPLEVEL False
</CONFIG>
<CONTENT>
</CONTENT><OUTPUT>
<%%:
progress(SqlDatabase.SqlTableCount * 2)
foreach(SqlTable where LIBIsModelTable == true)
{
	// create/update feature
	<%%>MDLFeatureModel%%>
	progress
}
foreach(SqlTable where LIBIsModelTable == true)
{
	// create/update basic entity
	<%%>MDLEntityCoreModel%%>
	progress
}
%%></OUTPUT>
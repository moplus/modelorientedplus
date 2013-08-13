<CONFIG>
	NAME MDLBlockName
	CATEGORY Block
	NODE SqlTable
	TOPLEVEL False
</CONFIG>
<CONTENT>
<%%:
// set block name
var tableName = SqlTableName.CapitalCase()
//
// remove spaces
//
tableName = tableName.Replace(" ", "").Replace("_", "")
//
// singularize NOTE: this is a generalization, you may want to update these rules
//
if (tableName.EndsWith("ies") == true)
{
	// replace with y
	tableName = tableName.Substring(0, tableName.Length - 3) + "y"
}
else if (tableName.EndsWith("xes") == true || tableName.EndsWith("ses") == true)
{
	// chop off es
	tableName = tableName.Substring(0, tableName.Length - 2)
}
else if (tableName.EndsWith("as") == true || tableName.EndsWith("is") == true || tableName.EndsWith("os") == true || tableName.EndsWith("us") == true)
{
	// leave as is
}
else if (tableName.EndsWith("s") == true)
{
	// chop off s
	tableName = tableName.Substring(0, tableName.Length - 1)
}
<%%=tableName%%>
%%></CONTENT>
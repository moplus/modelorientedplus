<CONFIG>
	NAME MDLEntityName
	CATEGORY Entity
	NODE SqlTable
	TOPLEVEL False
</CONFIG>
<CONTENT>
<%%:
// set entity name  NOTE: this is a generalization based on some table naming conventions, you may want to update these rules
var tableName
if ((MDLTableName.StartsWith("tbl") == true || MDLTableName.StartsWith("tlkp") == true || MDLTableName.StartsWith("trel") == true) && MDLTableName.IndexOf("_") > 0)
{
	tableName = MDLTableName.Substring(MDLTableName.IndexOf("_")).Substring(1)
}
else
{
	tableName = MDLTableName
}
//
// remove spaces and underscores
//
tableName = tableName.CapitalCase().Replace(" ", "").Replace("_", "")
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
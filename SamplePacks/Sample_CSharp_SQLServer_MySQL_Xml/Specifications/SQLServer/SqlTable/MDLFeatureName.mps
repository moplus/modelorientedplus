<CONFIG>
	NAME MDLFeatureName
	CATEGORY Feature
	NODE SqlTable
</CONFIG>
<CONTENT>
<%%:
// strip table types
if (MDLTableName.StartsWith("tbl") == true)
{
	// strip entity names
	if (MDLTableName.IndexOf("_") > 0)
	{
		<%%=MDLTableName.Substring(0, MDLTableName.IndexOf("_")).Substring(3)%%>
	}
	else
	{
		<%%=MDLTableName.Substring(3)%%>
	}
}
else if (MDLTableName.StartsWith("tlkp") == true || MDLTableName.StartsWith("trel") == true)
{
	// strip entity names
	if (MDLTableName.IndexOf("_") > 0)
	{
		<%%=MDLTableName.Substring(0, MDLTableName.IndexOf("_")).Substring(4)%%>
	}
	else
	{
		<%%=MDLTableName.Substring(4)%%>
	}
}

// set default feature if none found
if (Text == "")
{
	<%%-Domain%%>
}
%%></CONTENT>
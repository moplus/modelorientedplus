<CONFIG>
	NAME MDLCollectionName
	CATEGORY Collection
	NODE Relationship
	TOPLEVEL False
</CONFIG>
<CONTENT>
<%%:
param baseName
var pluralizeName = true // set to false to use simple "List" form for plural
var pluralName = baseName
var propertyPrefix = MDLPropertyNamePrefix
if (baseName.StartsWith(propertyPrefix) == false)
{
	<%%=propertyPrefix%%>
}
if (pluralizeName == true)
{
	if (baseName.ToLower().EndsWith("y") == true)
	{
		pluralName = baseName.Substring(0, baseName.Length - 1) + "ies"
	}
	else if (baseName.ToLower().EndsWith("s") == true || baseName.ToLower().EndsWith("x") == true)
	{
		pluralName = baseName + "es"
	}
	else
	{
		pluralName = baseName + "s"
	}
	<%%=pluralName%%>
}
else
{
	<%%-s%%><%%=baseName%%><%%-List%%>
}
%%></CONTENT>
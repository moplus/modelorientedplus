<CONFIG>
	NAME MDLEntityReferenceName
	CATEGORY EntityReference
	NODE Relationship
	TOPLEVEL False
</CONFIG>
<CONTENT>
<%%:
param baseName
var propertyPrefix = MDLPropertyNamePrefix
if (baseName.StartsWith(propertyPrefix) == false)
{
	<%%=propertyPrefix%%>
}
<%%=baseName%%>
%%></CONTENT>
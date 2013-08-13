<CONFIG>
	NAME MDLCollectionName
	CATEGORY Collection
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
<%%=baseName%%><%%-List%%>
%%></CONTENT>
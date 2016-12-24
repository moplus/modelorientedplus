<CONFIG>
	NAME MDLPropertyReferenceName
	CATEGORY PropertyReference
	NODE RelationshipProperty
	TOPLEVEL False
</CONFIG>
<CONTENT>
<%%:
param baseName

var propertyPrefix = Relationship.MDLPropertyNamePrefix
if (baseName.StartsWith(propertyPrefix) == false)
{
	<%%=propertyPrefix%%>
}
<%%=baseName%%>
%%></CONTENT>